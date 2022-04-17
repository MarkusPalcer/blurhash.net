using System;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Blurhash.ImageSharp
{
    public static class Blurhasher
    {
        /// <summary>
        /// Encodes a picture into a Blurhash string
        /// </summary>
        /// <param name="image">The picture to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <returns>The resulting Blurhash string</returns>
        public static string Encode(Image<Rgb24> image, int componentsX, int componentsY)
        {
            return Core.Encode(ConvertBitmap(image), componentsX, componentsY);
        }

        /// <summary>
        /// Decodes a Blurhash string into a <c>SixLabors.ImageSharp.Image</c>
        /// </summary>
        /// <param name="blurhash">The blurhash string to decode</param>
        /// <param name="outputWidth">The desired width of the output in pixels</param>
        /// <param name="outputHeight">The desired height of the output in pixels</param>
        /// <param name="punch">A value that affects the contrast of the decoded image. 1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.</param>
        /// <returns>The decoded preview</returns>
        public static Image<Rgb24> Decode(string blurhash, int outputWidth, int outputHeight, double punch = 1.0)
        {
            var pixelData = new Pixel[outputWidth, outputHeight];
            Core.Decode(blurhash, pixelData, punch);
            return ConvertToBitmap(pixelData);
        }

        /// <summary>
        /// Encodes a picture into a Blurhash string
        /// </summary>
        /// <param name="image">The picture to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <returns>The resulting Blurhash string</returns>
        public static string Encode(Image<Rgba32> image, int componentsX, int componentsY)
        {
            return Core.Encode(ConvertBitmap(image), componentsX, componentsY);
        }

        /// <summary>
        /// Converts the given bitmap to the library-independent representation used within the Blurhash-core
        /// </summary>
        /// <param name="sourceBitmap">The bitmap to encode</param>
        internal static Pixel[,] ConvertBitmap<T>(Image<T> sourceBitmap) where T : unmanaged, IPixel<T>
        {
            if (typeof(T) != typeof(Rgba32) && typeof(T) != typeof(Rgb24))
                throw new ArgumentOutOfRangeException(nameof(sourceBitmap), "Only Rgba32 and Rgb24 are supported");

            var width = sourceBitmap.Width;
            var height = sourceBitmap.Height;
            var bytesPerPixel = sourceBitmap.PixelType.BitsPerPixel / 8;

            var result = new Pixel[width, height];

            sourceBitmap.ProcessPixelRows(pixelAccessor =>
            {
                for (var y = 0; y < pixelAccessor.Height; y++)
                {
                    var rgbValues = MemoryMarshal.AsBytes(pixelAccessor.GetRowSpan(y));

                    var index = 0;

                    for (var x = 0; x < width; x++)
                    {
                        result[x, y].Red = MathUtils.SRgbToLinear(rgbValues[index]);
                        result[x, y].Green = MathUtils.SRgbToLinear(rgbValues[index + 1]);
                        result[x, y].Blue = MathUtils.SRgbToLinear(rgbValues[index + 2]);
                        index += bytesPerPixel;
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Converts the library-independent representation of pixels into a bitmap
        /// </summary>
        /// <param name="pixelData">The library-independent representation of the image</param>
        /// <returns>A <c>Image&lt;Rgb24&gt;</c> in 24bpp-RGB representation</returns>
        internal static Image<Rgb24> ConvertToBitmap(Pixel[,] pixelData)
        {
            var width = pixelData.GetLength(0);
            var height = pixelData.GetLength(1);

            Rgb24[] data = new Rgb24[width*height];
            for (int y = 0; y < height; y++)
            {
                Span<Rgb24> rowSpan = data.AsSpan().Slice(y * width, width);
                for (int x = 0; x < width; x++)
                {
                    var pixel = pixelData[x, y];
                    ref Rgb24 dest = ref rowSpan[x];
                    dest.R = (byte) MathUtils.LinearTosRgb(pixel.Red);
                    dest.G = (byte) MathUtils.LinearTosRgb(pixel.Green);
                    dest.B = (byte) MathUtils.LinearTosRgb(pixel.Blue);
                }
            }

            return Image.WrapMemory(Configuration.Default, new Memory<Rgb24>(data), width, height);
        }
    }
}

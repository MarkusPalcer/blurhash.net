using System;
using Blurhash.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Blurhash.ImageSharp
{
    public class Decoder : CoreDecoder
    {
        /// <summary>
        /// Decodes a Blurhash string into a <c>System.Drawing.Image</c>
        /// </summary>
        /// <param name="blurhash">The blurhash string to decode</param>
        /// <param name="outputWidth">The desired width of the output in pixels</param>
        /// <param name="outputHeight">The desired height of the output in pixels</param>
        /// <param name="punch">A value that affects the contrast of the decoded image. 1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.</param>
        /// <returns>The decoded preview</returns>
        public Image<Rgb24> Decode(string blurhash, int outputWidth, int outputHeight, double punch = 1.0)
        {
            var pixelData = CoreDecode(blurhash, outputWidth, outputHeight, punch);
            return ConvertToBitmap(pixelData);
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

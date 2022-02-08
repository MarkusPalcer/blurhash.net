using System;
using System.Runtime.InteropServices;
using Blurhash.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Blurhash.ImageSharp
{
    public class Encoder : CoreEncoder 
    {
        /// <summary>
        /// Encodes a picture into a Blurhash string
        /// </summary>
        /// <param name="image">The picture to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <returns>The resulting Blurhash string</returns>
        public string Encode(Image<Rgb24> image, int componentsX, int componentsY)
        {
            return CoreEncode(ConvertBitmap(image), componentsX, componentsY);
        }
        
        /// <summary>
        /// Encodes a picture into a Blurhash string
        /// </summary>
        /// <param name="image">The picture to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <returns>The resulting Blurhash string</returns>
        public string Encode(Image<Rgba32> image, int componentsX, int componentsY)
        {
            return CoreEncode(ConvertBitmap(image), componentsX, componentsY);
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
    }
}
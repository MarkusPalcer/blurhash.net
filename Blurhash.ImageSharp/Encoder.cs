using System;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Blurhash.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

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
        public string Encode(Image<Rgba32> image, int componentsX, int componentsY)
        {
            return CoreEncode(ConvertBitmap(image), componentsX, componentsY);
        }

        /// <summary>
        /// Converts the given bitmap to the library-independent representation used within the Blurhash-core
        /// </summary>
        /// <param name="sourceBitmap">The bitmap to encode</param>
        public static Pixel[,] ConvertBitmap(Image<Rgba32> sourceBitmap)
        {
            var width = sourceBitmap.Width;
            var height = sourceBitmap.Height;
            var stride = width * 4;
            
            var rgbValues = MemoryMarshal.Cast<Rgba32, byte>(sourceBitmap.GetPixelSpan());
            var bytes = rgbValues.Length;

            var result = new Pixel[width, height];

            Parallel.ForEach(Enumerable.Range(0, height), y =>
            {
                var rgbValues = MemoryMarshal.Cast<Rgba32, byte>(sourceBitmap.GetPixelSpan());
                var index = stride * y;

                for (var x = 0; x < width; x++)
                {
                    result[x, y].Red = MathUtils.SRgbToLinear(rgbValues[index]);
                    result[x, y].Green = MathUtils.SRgbToLinear(rgbValues[index + 1]);
                    result[x, y].Blue = MathUtils.SRgbToLinear(rgbValues[index + 2]);
                    index += 4;
                }
            });

            return result;
        }
    }
}
using System.Drawing.Imaging;
using Blurhash.Core;

// ReSharper disable once CheckNamespace Justification: Meant to extend the System.Drawing.Common-Namespace
namespace System.Drawing.Common.Blurhash
{
    /// <summary>
    /// The Blurhash encoder for use with the <code>System.Drawing.Common</code> package
    /// </summary>
    public class Encoder : CoreEncoder
    {
        /// <summary>
        /// Encodes a picture into a Blurhash string
        /// </summary>
        /// <param name="image">The picture to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <returns>The resulting Blurhash string</returns>
        public string Encode(Image image, int componentsX, int componentsY)
        {
            return CoreEncode(ConvertBitmap(image as Bitmap ?? new Bitmap(image)), componentsX, componentsY);
        }

        /// <summary>
        /// Converts the given bitmap to the library-independent representation used within the Blurhash-core
        /// </summary>
        /// <param name="sourceBitmap">The bitmap to encode</param>
        public static unsafe Pixel[,] ConvertBitmap(Image sourceBitmap)
        {
            var width = sourceBitmap.Width;
            var height = sourceBitmap.Height;

            using (var temporaryBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            {
                using (var graphics = Graphics.FromImage(temporaryBitmap))
                {
                    graphics.DrawImageUnscaled(sourceBitmap, 0, 0);
                }

                // Lock the bitmap's bits.
                var bmpData = temporaryBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, temporaryBitmap.PixelFormat);

                // Get the address of the first line.
                var ptr = bmpData.Scan0;

                var result = new Pixel[width, height];

                byte* rgb = (byte*)ptr.ToPointer();
                for (var y = 0; y < height; y++)
                {
                    var index = bmpData.Stride * y;

                    for (var x = 0; x < width; x++)
                    {
                        ref var res = ref result[x, y];
                        res.Blue = MathUtils.SRgbToLinear(rgb[index++]);
                        res.Green = MathUtils.SRgbToLinear(rgb[index++]);
                        res.Red = MathUtils.SRgbToLinear(rgb[index++]);
                    }
                }

                temporaryBitmap.UnlockBits(bmpData);

                return result;
            }
        }
    }
}

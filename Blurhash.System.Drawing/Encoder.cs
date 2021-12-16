using System.Drawing.Imaging;
using Blurhash.Core;

namespace System.Drawing.Blurhash
{
    /// <summary>
    /// The Blurhash encoder for use with the <code>System.Drawing.dll</code>
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
            return CoreEncode(ConvertBitmap(image), componentsX, componentsY);
        }

        /// <summary>
        /// Converts the given bitmap to the library-independent representation used within the Blurhash-core
        /// </summary>
        /// <param name="sourceImage">The bitmap to encode</param>
        public static Pixel[,] ConvertBitmap(Image sourceImage)
        {
            var width = sourceImage.Width;
            var height = sourceImage.Height;

            if (sourceImage is Bitmap sourceBitmap && sourceBitmap.PixelFormat == PixelFormat.Format24bppRgb)
            {
                return ConvertBitmap(sourceBitmap, sourceBitmap.Width, sourceBitmap.Height);
            }

            using (var temporaryBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            {
                using (var graphics = Graphics.FromImage(temporaryBitmap))
                {
                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, width, height),
                        new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                }

                return ConvertBitmap(temporaryBitmap, width, height);
            }
        }

        private static unsafe Pixel[,] ConvertBitmap(Bitmap temporaryBitmap, int width, int height)
        {
            // Lock the bitmap's bits.
            var bmpData = temporaryBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                temporaryBitmap.PixelFormat);

            var result = new Pixel[width, height];

            // Convert raw bitmap data to pointer for direct access
            byte* data = (byte*)bmpData.Scan0.ToPointer();
            for (var x = 0; x < width; x++)
            {
                fixed (Pixel* pixelsBase = &result[x, 0])
                    for (var y = 0; y < height; y++)
                    {
                        var index = bmpData.Stride * y + x * 3;

                        pixelsBase[y] = new Pixel(
                            MathUtils.SRgbToLinear(data[index + 2]),
                            MathUtils.SRgbToLinear(data[index + 1]),
                            MathUtils.SRgbToLinear(data[index]));
                    }
            }

            temporaryBitmap.UnlockBits(bmpData);

            return result;
        }
    }
}

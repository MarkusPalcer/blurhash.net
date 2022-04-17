using System.Drawing.Imaging;
using Blurhash;

namespace System.Drawing.Blurhash
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
        public static string Encode(Image image, int componentsX, int componentsY)
        {
            return Core.Encode(ConvertBitmap(image as Bitmap ?? new Bitmap(image)), componentsX, componentsY);
        }

        /// <summary>
        /// Decodes a Blurhash string into a <c>System.Drawing.Image</c>
        /// </summary>
        /// <param name="blurhash">The blurhash string to decode</param>
        /// <param name="outputWidth">The desired width of the output in pixels</param>
        /// <param name="outputHeight">The desired height of the output in pixels</param>
        /// <param name="punch">A value that affects the contrast of the decoded image. 1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.</param>
        /// <returns>The decoded preview</returns>
        public static Image Decode(string blurhash, int outputWidth, int outputHeight, double punch = 1.0)
        {
            var pixelData = new Pixel[outputWidth, outputHeight];
            Core.Decode(blurhash, pixelData, punch);
            return ConvertToBitmap(pixelData);
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

        /// <summary>
        /// Converts the library-independent representation of pixels into a bitmap
        /// </summary>
        /// <param name="pixelData">The library-independent representation of the image</param>
        /// <returns>A <c>System.Drawing.Bitmap</c> in 32bpp-RGB representation</returns>
        public static unsafe Bitmap ConvertToBitmap(Pixel[,] pixelData)
        {
            var width = pixelData.GetLength(0);
            var height = pixelData.GetLength(1);

            var data = new byte[width * height * 4];

            var index = 0;
            for (var yPixel = 0; yPixel < height; yPixel++)
            for (var xPixel = 0; xPixel < width; xPixel++)
            {
                var pixel = pixelData[xPixel, yPixel];

                data[index++] = (byte)MathUtils.LinearTosRgb(pixel.Blue);
                data[index++] = (byte)MathUtils.LinearTosRgb(pixel.Green);
                data[index++] = (byte)MathUtils.LinearTosRgb(pixel.Red);
                data[index++] = 0;
            }

            Bitmap bmp;

            fixed (byte* ptr = data)
            {
                bmp = new Bitmap(width, height, width * 4, PixelFormat.Format32bppRgb, new IntPtr(ptr));
            }

            return bmp;
        }
    }
}

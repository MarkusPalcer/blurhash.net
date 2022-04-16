using System.Drawing.Imaging;
using Blurhash.Core;

// ReSharper disable once CheckNamespace Justification: Meant to extend the System.Drawing.Common-Namespace
namespace System.Drawing.Common.Blurhash
{
    /// <summary>
    /// The Blurhash-Decoder for use with the System.Drawing.Common package
    /// </summary>
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
        public Image Decode(string blurhash, int outputWidth, int outputHeight, double punch = 1.0)
        {
            var pixelData = new Pixel[outputWidth, outputHeight];
            CoreDecode(blurhash, pixelData, punch);
            return ConvertToBitmap(pixelData);
        }

        /// <summary>
        /// Converts the library-independent representation of pixels into a bitmap
        /// </summary>
        /// <param name="pixelData">The library-independent representation of the image</param>
        /// <returns>A <c>System.Drawing.Bitmap</c> in 32bpp-RGB representation</returns>
        internal static unsafe Bitmap ConvertToBitmap(Pixel[,] pixelData)
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

using System.Drawing;
using Blurhash.Microsoft.Extensions.Core;
using System.Drawing.Blurhash;

namespace Blurhash.Microsoft.Extensions.System.Drawing
{

    /// <inheritdoc />
    public class ImageConverter : IImageConverter<Image>
    {
        /// <inheritdoc />
        public Pixel[,] ImageToPixels(Image image) => Blurhasher.ConvertBitmap(image);

        /// <inheritdoc />
        public Image PixelsToImage(Pixel[,] pixels) => Blurhasher.ConvertToBitmap(pixels);
    }
}

using System;

namespace Blurhash.Microsoft.Extensions.Core
{

    /// <inheritdoc />
    public class Blurhasher<TImage> : IBlurhasher<TImage>
    {
        private readonly IImageConverter<TImage> imageConverter;

        public Blurhasher(IImageConverter<TImage> imageConverter)
        {
            this.imageConverter = imageConverter;
        }

        /// <inheritdoc />
        public string Encode(TImage image, int componentsX, int componentsY, IProgress<int> progressCallback = null)
        {
            return Blurhash.Core.Encode(imageConverter.ImageToPixels(image), componentsX, componentsY,
                progressCallback);
        }

        /// <inheritdoc />
        public TImage Decode(string hash, int outputWidth, int outputHeight, double punch = 1,
            IProgress<int> progressCallback = null)
        {
            var pixels = new Pixel[outputWidth, outputHeight];
            Blurhash.Core.Decode(hash, pixels, punch, progressCallback);
            return imageConverter.PixelsToImage(pixels);
        }
    }
}

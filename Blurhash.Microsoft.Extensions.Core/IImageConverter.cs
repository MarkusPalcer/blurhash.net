namespace Blurhash.Microsoft.Extensions.Core
{
    /// <summary>
    /// The abstract conversion of an image to the internal array of pixels
    /// </summary>
    /// <typeparam name="TImage">The type of the image</typeparam>
    public interface IImageConverter<TImage>
    {
        /// <summary>
        /// Converts an image to the pixel array
        /// </summary>
        Pixel[,] ImageToPixels(TImage image);

        /// <summary>
        /// Converts a pixel array to an image
        /// </summary>
        TImage PixelsToImage(Pixel[,] pixels);
    }
}

using System;

namespace Blurhash.Microsoft.Extensions.Core
{

    /// <summary>
    /// Abstracts away the blurhash algorithm
    /// </summary>
    /// <typeparam name="TImage">The Image-Type that is hashed and created</typeparam>
    public interface IBlurhasher<TImage>
    {
        /// <summary>
        /// Encodes a picture into a Blurhash string
        /// </summary>
        /// <param name="image">The picture to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <param name="progressCallback">An optional progress handler to receive progress updates</param>
        /// <returns>The resulting Blurhash string</returns>
        string Encode(TImage image, int componentsX, int componentsY, IProgress<int> progressCallback = null);

        /// <summary>
        /// Decodes a Blurhash string into an image
        /// </summary>
        /// <param name="hash">The blurhash string to decode</param>
        /// <param name="outputWidth">The desired width of the output in pixels</param>
        /// <param name="outputHeight">The desired height of the output in pixels</param>
        /// <param name="punch">
        ///     A value that affects the contrast of the decoded image.
        ///     1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.
        /// </param>
        /// <param name="progressCallback">An optional progress handler to receive progress updates</param>
        /// <returns>The decoded preview</returns>
        TImage Decode(string hash, int outputWidth, int outputHeight, double punch = 1.0,
            IProgress<int> progressCallback = null);
    }
}

using System.Drawing;
using Blurhash.Microsoft.Extensions.Core;

namespace Blurhash.Microsoft.Extensions.System.Drawing
{
    /// <inheritdoc cref="Blurhash.Microsoft.Extensions.System.Drawing.IBlurhasher" />
    public class BlurhasherImpl : Blurhasher<Image>, IBlurhasher
    {
        public BlurhasherImpl(IImageConverter<Image> imageConverter) : base(imageConverter)
        {
        }
    }
}

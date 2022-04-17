using System.Drawing;
using Blurhash.Microsoft.Extensions.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Blurhash.Microsoft.Extensions.System.Drawing
{

    public static class Extensions
    {
        /// <summary>
        /// Adds the blurhash core and the converter for <see cref="Image"/> to the given <see cref="IServiceCollection"/><br />
        /// Also enables you to request <see cref="IBlurhasher"/>
        /// </summary>
        public static IServiceCollection AddBlurhash(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddBlurhashCore()
                .AddSingleton<IImageConverter<Image>, ImageConverter>()
                .AddSingleton<IBlurhasher, BlurhasherImpl>();
        }
    }
}

using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Blurhash.Microsoft.Extensions.Core
{

    public static class Extensions
    {
        /// <summary>
        /// Adds the Blurhash core to the dependency container.<br />
        /// Just supply your own implementation of <see cref="IImageConverter{TImage}"/> and you're ready to go.
        /// </summary>
        public static IServiceCollection AddBlurhashCore(this IServiceCollection serviceCollection)
        {
            if (serviceCollection.Any(x => x.ServiceType == typeof(IBlurhasher<>))) return serviceCollection;

            serviceCollection.AddSingleton(typeof(IBlurhasher<>), typeof(Blurhasher<>));
            return serviceCollection;
        }
    }
}

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Blurhash.ImageSharp.Test
{
    [TestClass]
    public class EncoderTest
    {
        [TestMethod]
        public async Task EncodingTests()
        {
            var sourceImage = await Image.LoadAsync<Rgba32>(@"Resources\Specimens\Sample.png");

            var encoder = new Encoder();
            var result = encoder.Encode(sourceImage, 9, 9);

            Assert.AreEqual(
                "|20Ktja2e-eSe8g2e9gNene,dCg$gOf8gieTf+eTgNd=g$eSeSgOeng3f7heeng4e.eTfie.g3e.Z#d;g4gOg4f7e.f6f,gigNf+eSeSe-g3emg3g3e-eTgOgNf+g3eTf+eTf+emf+e.eTgNeng3e.gOe:fif5f6g3eTf+",
                result);
        }
    }
}

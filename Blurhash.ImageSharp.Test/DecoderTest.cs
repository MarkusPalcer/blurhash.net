using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixLabors.ImageSharp;

namespace Blurhash.ImageSharp.Test
{
    [TestClass]
    public class DecoderTest
    {
        [TestMethod]
        public async Task DecodingTests()
        {
            const string sourceHash =
                "|20Ktja2e-eSe8g2e9gNene,dCg$gOf8gieTf+eTgNd=g$eSeSgOeng3f7heeng4e.eTfie.g3e.Z#d;g4gOg4f7e.f6f,gigNf+eSeSe-g3emg3g3e-eTgOgNf+g3eTf+eTf+emf+e.eTgNeng3e.gOe:fif5f6g3eTf+";

            var encoder = new Decoder();
            var result = encoder.Decode(sourceHash, 200, 200);

            await using var ms = new MemoryStream();
            await result.SaveAsPngAsync(ms);
            ms.Position = 0;
            using var resultStream = new BinaryReader(ms);
            var resultBytes = resultStream.ReadBytes((int)ms.Length);

            await using var expectation = File.OpenRead(@"Resources\Expectations\BlurResult1.png");
            using var fileStream = new BinaryReader(expectation);
            var actualBytes = fileStream.ReadBytes((int)expectation.Length);

            CollectionAssert.AreEqual(resultBytes, actualBytes);
        }
    }
}

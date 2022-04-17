using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Xunit;

namespace Blurhash.ImageSharp.Test
{
    public class BlurhasherTests
    {
        const string SourceHash = "|20Ktja2e-eSe8g2e9gNene,dCg$gOf8gieTf+eTgNd=g$eSeSgOeng3f7heeng4e.eTfie.g3e.Z#d;g4gOg4f7e.f6f,gigNf+eSeSe-g3emg3g3e-eTgOgNf+g3eTf+eTf+emf+e.eTgNeng3e.gOe:fif5f6g3eTf+";

        [Fact]
        public async Task DecodingTests()
        {
            var result = Blurhasher.Decode(SourceHash, 200, 200);

            await using var ms = new MemoryStream();
            await result.SaveAsPngAsync(ms);
            ms.Position = 0;
            using var resultStream = new BinaryReader(ms);
            var resultBytes = resultStream.ReadBytes((int)ms.Length);

            await using var expectation = File.OpenRead(@"Resources\Expectations\BlurResult1.png");
            using var fileStream = new BinaryReader(expectation);
            var actualBytes = fileStream.ReadBytes((int)expectation.Length);

            resultBytes.Should().BeEquivalentTo(actualBytes);
        }

        [Fact]
        public async Task EncodingTests()
        {
            var sourceImage = await Image.LoadAsync<Rgba32>(@"Resources\Specimens\Sample.png");

            var result = Blurhasher.Encode(sourceImage, 9, 9);

            result.Should().Be(SourceHash);
        }
    }
}

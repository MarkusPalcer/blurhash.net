using System.Drawing.Blurhash;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

// ReSharper disable once CheckNamespace Justification: Meant to extend the System.Drawing.Common-Namespace
namespace System.Drawing.Common
{
    public class ImageConversionTest
    {
        [Fact]
        public void TestConversion24BppRgb()
        {
            var rnd = new Random();

            var sourceImage = new Bitmap(20, 20, PixelFormat.Format24bppRgb);

            for (var x = 0; x < 20; x++)
                for (var y = 0; y < 20; y++)
                {
                    sourceImage.SetPixel(x, y, Color.FromArgb(rnd.Next(0, 2) * 255, rnd.Next(0, 2) * 255, rnd.Next(0, 2) * 255));
                }

            var sourceData = Blurhasher.ConvertBitmap(sourceImage);

            for (var x = 0; x < 20; x++)
            for (var y = 0; y < 20; y++)
            {
                var pixel = sourceImage.GetPixel(x, y);

                sourceData[x, y].Red.Should().BeApproximately(pixel.R == 0 ? 0.0 : 1.0, double.Epsilon);
                sourceData[x, y].Green.Should().BeApproximately(pixel.G == 0 ? 0.0 : 1.0, double.Epsilon);
                sourceData[x, y].Blue.Should().BeApproximately(pixel.B == 0 ? 0.0 : 1.0, double.Epsilon);
            }

            var targetImage = Blurhasher.ConvertToBitmap(sourceData);

            for (var x = 0; x < 20; x++)
            for (var y = 0; y < 20; y++)
            {
                targetImage.GetPixel(x, y).Should().Be(sourceImage.GetPixel(x, y));
            }
        }

        [Fact]
        public void TestConversion32BppRgb()
        {
            var rnd = new Random();

            var sourceImage = new Bitmap(20, 20, PixelFormat.Format32bppRgb);

            for (var x = 0; x < 20; x++)
            for (var y = 0; y < 20; y++)
            {
                sourceImage.SetPixel(x, y, Color.FromArgb(rnd.Next(0, 2) * 255, rnd.Next(0, 2) * 255, rnd.Next(0, 2) * 255));
            }

            var sourceData = Blurhasher.ConvertBitmap(sourceImage);

            for (var x = 0; x < 20; x++)
            for (var y = 0; y < 20; y++)
            {
                var pixel = sourceImage.GetPixel(x, y);

                sourceData[x, y].Red.Should().BeApproximately(pixel.R == 0 ? 0.0 : 1.0, double.Epsilon);
                sourceData[x, y].Green.Should().BeApproximately(pixel.G == 0 ? 0.0 : 1.0, double.Epsilon);
                sourceData[x, y].Blue.Should().BeApproximately(pixel.B == 0 ? 0.0 : 1.0, double.Epsilon);
            }

            var targetImage = Blurhasher.ConvertToBitmap(sourceData);

            for (var x = 0; x < 20; x++)
            for (var y = 0; y < 20; y++)
            {
                targetImage.GetPixel(x, y).Should().Be(sourceImage.GetPixel(x, y));
            }
        }

        [Fact]
        public void TestEncoding()
        {
            var img = Image.FromFile("TestData\\input.jpg");


            using (var scope = new AssertionScope()) {
                foreach (var x in Enumerable.Range(1, 9))
                foreach (var y in Enumerable.Range(1, 9))
                {
                    var hash = Blurhasher.Encode(img, x, y);
                    hash.Should().Be(ImageConversionTestCases.ExpectedHashes[(x, y)], $" the hash for {x} by {y} components should be correct");
                }
            }
        }

        [Fact]
        public void TestDecoding()
        {
            foreach (var componentsX in Enumerable.Range(1, 9))
            foreach (var componentsY in Enumerable.Range(1, 9))
            {
                using (var actualImage = (Bitmap)Blurhasher.Decode(ImageConversionTestCases.ExpectedHashes[(componentsX, componentsY)], 300, 190))
                using (var expectedStream = new FileStream($"TestData\\{componentsX}x{componentsY}.png", FileMode.Open))
                using (var actualStream = new MemoryStream())
                {
                    actualImage.Save(actualStream, ImageFormat.Png);
                    actualStream.Seek(0, SeekOrigin.Begin);

                    actualStream.Length.Should().Be(expectedStream.Length);

                    var actualByte = actualStream.ReadByte();
                    var expectedByte = expectedStream.ReadByte();

                    while (actualByte > -1)
                    {
                        actualByte.Should().Be(expectedByte);

                        actualByte = actualStream.ReadByte();
                        expectedByte = expectedStream.ReadByte();
                    }
                }
            }
        }
    }
}

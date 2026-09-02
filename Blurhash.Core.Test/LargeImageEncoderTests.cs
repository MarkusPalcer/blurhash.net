using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Blurhash.Tests;

public class LargeImageEncoderTests
{
    [Fact]
    public void Encode()
    {
        var pixels = JsonConvert.DeserializeObject<Pixel[,]>(File.ReadAllText("TestData/testImage.json"))!;
        var result = LargeImageEncoder.Encode(pixels, 9, 9);
        result.Should()
            .Be(
                "|LLqO$PTrh^j9g=i$9+lP8?ZM|M{RYRo,ZW,JDR=tTo~ENVZeGrwJ~EUEf}]RWMxVyil+RS[cDv}YWw0vhTIOnq{K5gKbZ.PTcv-#SO:OrWBKia2X_voXMM-WGw1rGRixsLuoHOTRiIoVft7E9KGs}#prDKck#r?bWRoV$");
    }
}
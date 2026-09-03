using System;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Blurhash.Tests;

public class StreamedEncoderTests
{
    [Fact]
    public void Encode()
    {
        var pixels = JsonConvert.DeserializeObject<Pixel[,]>(File.ReadAllText("TestData/testImage.json"))!;
        var width = pixels.GetLength(0);
        var height = pixels.GetLength(1);

        var encoder = new StreamedEncoder(9, 9, width, height);

        Span<StreamedPixel> pixelBuffer = stackalloc StreamedPixel[height];
        for (var xPixel = 0; xPixel < width; xPixel++)
        {
            for (var yPixel = 0; yPixel < height; yPixel++)
            {
                var pixel = pixels[xPixel, yPixel];
                pixelBuffer[yPixel] = new StreamedPixel(pixel.Red, pixel.Green, pixel.Blue, xPixel, yPixel);
            }

            encoder.Process(pixelBuffer);
        }

        var result = encoder.Finish();
        result.Should()
            .Be(
                "|LLqO$PTrh^j9g=i$9+lP8?ZM|M{RYRo,ZW,JDR=tTo~ENVZeGrwJ~EUEf}]RWMxVyil+RS[cDv}YWw0vhTIOnq{K5gKbZ.PTcv-#SO:OrWBKia2X_voXMM-WGw1rGRixsLuoHOTRiIoVft7E9KGs}#prDKck#r?bWRoV$");
    }
}
using System;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Blurhash.Tests;

public class StreamedDecoderTests
{
    private static readonly Pixel[,] ReferenceResult;
    private static readonly string ReferenceInput;

    static StreamedDecoderTests()
    {
        var pixels = JsonConvert.DeserializeObject<Pixel[,]>(File.ReadAllText("TestData/testImage.json"))!;
        ReferenceInput = Core.Encode(pixels, 9, 9);
        ReferenceResult = new Pixel[50, 50];
        Core.Decode(ReferenceInput, ReferenceResult);
    }
    
    [Fact]
    public void Decode()
    {
        var result = new Pixel[50, 50];

        void ResultCallback(ReadOnlySpan<StreamedPixel> data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var pixel = data[i];
                result[pixel.X, pixel.Y] = new Pixel { Red = pixel.Red, Green = pixel.Green, Blue = pixel.Blue };
            }
        }

        var decoder = new StreamedDecoder(ReferenceInput, 50, 50, ResultCallback);
        decoder.Decode();
        result.Should().BeEquivalentTo(ReferenceResult);
    }
}
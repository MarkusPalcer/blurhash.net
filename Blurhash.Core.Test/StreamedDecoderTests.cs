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
        var decoder = new StreamedDecoder(ReferenceInput, 50, 50);
        var result = decoder.Decode();
        result.Should().BeEquivalentTo(ReferenceResult);
    }
}
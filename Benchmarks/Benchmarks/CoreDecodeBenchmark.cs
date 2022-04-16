using System.Drawing;
using BenchmarkDotNet.Attributes;
using Benchmarks.Helpers;
using Blurhash.Core;
using Blurhash.Core.Test;

namespace Benchmarks;

[MemoryDiagnoser]
public class CoreDecodeBenchmark
{
    public static readonly Image SampleImage = Image.FromFile("Samples\\flower.jpg");

    private Pixel[,] pixels = null!;

    [GlobalSetup]
    public void CreatePixels()
    {
        pixels = new Pixel[SampleImage.Width, SampleImage.Height];
    }

    [Benchmark(Baseline = true)]
    public void Original()
    {
        var decoder = new CoreDecoderHelper();
        decoder.Decode(
            TestData.Data.First(x => x.ComponentsX == 9 && x.ComponentsY == 9).Hash,
            pixels);
    }
}

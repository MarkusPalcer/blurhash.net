using System.Drawing;
using BenchmarkDotNet.Attributes;
using Blurhash;

namespace Benchmarks.Benchmarks;

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
        Core.Decode(Blurhash.Tests.TestData.Data.First(x => x.ComponentsX == 9 && x.ComponentsY == 9).Hash, pixels);
    }
}

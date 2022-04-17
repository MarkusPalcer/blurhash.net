using System.Drawing;
using System.Drawing.Blurhash;
using BenchmarkDotNet.Attributes;
using Blurhash;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class CoreEncodeBenchmark
{
    private static readonly Pixel[,] SampleImage = Blurhasher.ConvertBitmap(new Bitmap(Image.FromFile("Samples\\flower.jpg")));

    [Benchmark(Baseline = true)]
    public void Original()
    {
        var _ = Core.Encode(SampleImage, 9, 9);
    }
}

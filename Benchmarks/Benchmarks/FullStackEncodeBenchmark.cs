using System.Drawing;
using System.Drawing.Blurhash;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class FullStackEncodeBenchmark
{
    private static readonly Image SampleImage = Image.FromFile("Samples\\flower.jpg");

    [Benchmark(Baseline = true)]
    public void Original()
    {
        var _ = Blurhasher.Encode(SampleImage, 9, 9);
    }
}

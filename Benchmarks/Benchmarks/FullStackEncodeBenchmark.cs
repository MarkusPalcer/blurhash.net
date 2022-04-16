using System.Drawing;
using System.Drawing.Common.Blurhash;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class FullStackEncodeBenchmark
{
    public static readonly Image SampleImage = Image.FromFile("Samples\\flower.jpg");

    [Benchmark(Baseline = true)]
    public void Original()
    {
        var encoder = new Encoder();
        var result = encoder.Encode(SampleImage, 9, 9);
    }
}

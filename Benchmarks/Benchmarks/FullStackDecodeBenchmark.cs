using System.Drawing;
using System.Drawing.Blurhash;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class FullStackDecodeBenchmark
{
    private static readonly Image SampleImage = Image.FromFile("Samples\\flower.jpg");

    [Benchmark(Baseline = true)]
    public void Original()
    {
        Blurhasher.Decode(ImageConversionTestCases.ExpectedHashes[(9, 9)], SampleImage.Width, SampleImage.Height).Dispose();
    }
}

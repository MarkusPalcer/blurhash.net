using System.Drawing;
using System.Drawing.Blurhash.DotNetFramework.Test;
using System.Drawing.Common.Blurhash;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class FullStackDecodeBenchmark
{
    public static readonly Image SampleImage = Image.FromFile("Samples\\flower.jpg");


    [Benchmark(Baseline = true)]
    public void Original()
    {
        var decoder = new Decoder();
        decoder.Decode(ImageConversionTestCases.ExpectedHashes[(9, 9)], SampleImage.Width, SampleImage.Height).Dispose();
    }
}

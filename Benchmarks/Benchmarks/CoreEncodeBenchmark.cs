using System.Drawing;
using BenchmarkDotNet.Attributes;
using System.Drawing.Common.Blurhash;
using Benchmarks.Helpers;
using Blurhash.Core;

namespace Benchmarks;

[MemoryDiagnoser]
public class CoreEncodeBenchmark
{
    public static readonly Pixel[,] SampleImage = Encoder.ConvertBitmap(new Bitmap(Image.FromFile("Samples\\flower.jpg")));

    [Benchmark(Baseline = true)]
    public void Original()
    {
        var encoder = new CoreEncoderHelper();
        var result = encoder.Encode(SampleImage, 9, 9);
    }
}

using System.Drawing;
using System.Drawing.Common.Blurhash;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser()]
public class EncoderConvertBitmapBenchmark
{
    public static readonly Bitmap SampleImage = new Bitmap(Image.FromFile("Samples\\flower.jpg"));

    [Benchmark]
    public void Benchmark()
    {
        Encoder.ConvertBitmap(SampleImage);
    }
}

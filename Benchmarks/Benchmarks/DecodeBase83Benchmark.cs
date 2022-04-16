using BenchmarkDotNet.Attributes;
using Blurhash.Core;

namespace Benchmarks;

[MemoryDiagnoser]
public class DecodeBase83Benchmark
{
    private string stringData;

    [GlobalSetup]
    public void Setup()
    {
        stringData = "xfd2";
    }

    [Benchmark(Baseline = true)]
    public void Original()
    {
        Base83.DecodeBase83(stringData.AsSpan().Slice(2,2));
    }
}
using BenchmarkDotNet.Attributes;
using Blurhash;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class DecodeBase83Benchmark
{
    private string stringData = null!;

    [GlobalSetup]
    public void Setup()
    {
        stringData = "xfd2";
    }

    [Benchmark(Baseline = true)]
    public void Original()
    {
        stringData.AsSpan().Slice(2,2).DecodeBase83();
    }
}

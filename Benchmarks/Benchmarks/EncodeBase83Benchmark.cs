using BenchmarkDotNet.Attributes;
using Blurhash;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class EncodeBase83Benchmark
{
    const int X = 5;

    [Benchmark(Baseline = true)]
    public void Original()
    {
        Span<char> output = stackalloc char[1];
        X.EncodeBase83(output);
    }
}

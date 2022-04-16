using BenchmarkDotNet.Attributes;
using Blurhash.Core;

namespace Benchmarks;

[MemoryDiagnoser]
public class EncodeBase83Benchmark
{
    const int x = 5;

    [Benchmark(Baseline = true)]
    public void Original()
    {
        Span<char> output = stackalloc char[1];
        x.EncodeBase83(output);
    }
}

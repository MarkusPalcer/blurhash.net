using BenchmarkDotNet.Attributes;
using Blurhash;
using Newtonsoft.Json;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class Core
{
    private Pixel[,] pixels = null!;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        pixels = JsonConvert.DeserializeObject<Pixel[,]>(File.ReadAllText("Samples/testImage.json"))!;
        ArgumentNullException.ThrowIfNull(pixels);
    }
    
    [Benchmark(Baseline = true)]
    public string Encode()
    {
        return Blurhash.Core.Encode(pixels, 9, 9);
    }
}
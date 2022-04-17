using BenchmarkDotNet.Running;
using Benchmarks;
using Benchmarks.Benchmarks;

// BenchmarkRunner.Run<FullStackEncodeBenchmark>();
// BenchmarkRunner.Run<FullStackDecodeBenchmark>();
// BenchmarkRunner.Run<EncodeBase83Benchmark>();
// BenchmarkRunner.Run<DecodeBase83Benchmark>();
BenchmarkRunner.Run<CoreEncodeBenchmark>();
// BenchmarkRunner.Run<CoreDecodeBenchmark>();
// BenchmarkRunner.Run<EncoderConvertBitmapBenchmark>();

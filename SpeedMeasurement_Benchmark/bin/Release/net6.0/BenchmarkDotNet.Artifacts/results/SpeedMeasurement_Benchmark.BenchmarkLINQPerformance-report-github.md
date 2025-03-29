```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19044.5608/21H2/November2021Update)
Intel Core i5-6200U CPU 2.30GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.407
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2


```
| Method | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------- |---------:|---------:|---------:|-------:|----------:|
| Single | 583.7 ns | 11.61 ns | 18.08 ns | 0.0248 |      40 B |
| First  | 286.9 ns |  5.83 ns |  6.24 ns | 0.0253 |      40 B |

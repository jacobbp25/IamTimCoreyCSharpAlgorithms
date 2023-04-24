``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22621
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.102
  [Host]     : .NET Core 7.0.3 (CoreCLR 7.0.323.6910, CoreFX 7.0.323.6910), X64 RyuJIT
  DefaultJob : .NET Core 7.0.3 (CoreCLR 7.0.323.6910, CoreFX 7.0.323.6910), X64 RyuJIT


```
|               Method |             Mean |           Error |          StdDev |           Median |
|--------------------- |-----------------:|----------------:|----------------:|-----------------:|
|   TestConcatenate500 |        81.402 μs |       2.4995 μs |       7.2117 μs |        79.146 μs |
|  TestConcatenate5000 |     7,446.772 μs |     268.0897 μs |     786.2607 μs |     7,249.980 μs |
| TestConcatenate50000 | 1,857,217.990 μs | 122,951.6917 μs | 360,596.0281 μs | 1,781,463.900 μs |
|            TestSb500 |         3.934 μs |       0.2020 μs |       0.5830 μs |         3.827 μs |
|           TestSb5000 |        48.684 μs |       4.7554 μs |      14.0213 μs |        48.229 μs |
|          TestSb50000 |       429.607 μs |      28.1608 μs |      82.5906 μs |       412.531 μs |

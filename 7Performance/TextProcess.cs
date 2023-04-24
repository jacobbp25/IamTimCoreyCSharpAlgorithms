using System.Text;
using BenchmarkDotNet.Attributes;

namespace TextProccessing;

public class TextProcess
{
    private const string _appendText = "test";
    public void TestConcatenation(int iterations)
    {
        var conTest = "";

        for (int i = 0; i < iterations; i++)
        {
            conTest = conTest + _appendText;
        }
    }

    public void TestSb(int iterations)
    {
        var sbTest = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            sbTest.Append(_appendText);
        }
    }
}

public class BottleneckProcessBenchmark
{
    private static readonly TextProcess process = new TextProcess();

    [Benchmark]
    public void TestConcatenate500()
    {
        process.TestConcatenation(500);
    }

    [Benchmark]
    public void TestConcatenate5000()
    {
        process.TestConcatenation(5000);
    }

    [Benchmark]
    public void TestConcatenate50000()
    {
        process.TestConcatenation(50000);
    }

    [Benchmark]
    public void TestSb500()
    {
        process.TestSb(500);
    }

    [Benchmark]
    public void TestSb5000()
    {
        process.TestSb(5000);
    }

    [Benchmark]
    public void TestSb50000()
    {
        process.TestSb(50000);
    }
}
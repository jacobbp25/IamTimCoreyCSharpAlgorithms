/*

Test concatenation performance vs stringbuilder

*/


using TextProccessing;
using BenchmarkDotNet.Running;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        //results in artifacts directory
        //var summary = BenchmarkRunner.Run<BottleneckProcessBenchmark>();

        var test = new TextProcess();
        //test.TestSb(10);

        //Stopwatch stopwatch = Stopwatch.StartNew();
        //stopwatch.Start();
        //test.TestConcatenation(500); //1ms
        //test.TestConcatenation(5000); //14ms
        //test.TestConcatenation(50000); //1172ms

        //test.TestSb(500); //0ms
        //test.TestSb(5000); //0ms
        //test.TestSb(50000); //1ms
        //stopwatch.Stop();
        //System.Console.WriteLine($"Time Taken: {stopwatch.ElapsedMilliseconds} ms");
        //int[] iterations = new int[] { 500, 5000, 50000 };
        // CalculateSpeed(test.TestSb, iterations, "Test String Builder");
        // CalculateSpeed(test.TestConcatenation, iterations, "Test Concatenation");

        int[] iterations = new int[] { 500000, 5000000 };
        CalculateSpeed(DoubleTest, iterations, "Test Double");
        CalculateSpeed(DecimalTest, iterations, "Test Decimal");
    }

    public static void CalculateSpeed(Action<int> methodToTest, int[] repatitions, string testName)
    {
        for (int i = 0; i < repatitions.Length; i++)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            methodToTest(repatitions[i]);
            stopwatch.Stop();
            System.Console.WriteLine($"{testName} {repatitions[i]} reps: {stopwatch.ElapsedMilliseconds} ms");
        }


    }

    public static void DoubleTest(int reps)
    {
        double x = 4.25;
        double y = 25.75;
        for (int i = 0; i < reps; i++)
        {
            x += y;
        }
    }

    public static void DecimalTest(int reps)
    {
        decimal x = 4.25m;
        decimal y = 25.75m;
        for (int i = 0; i < reps; i++)
        {
            x += y;
        }
    }
}
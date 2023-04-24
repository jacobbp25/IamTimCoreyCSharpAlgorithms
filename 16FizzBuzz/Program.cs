/*
Create a console app that prints out from 1-100
Fizz when a number is divisible by 3
Buzz when divisible by 3 and 5

Create it as simply as possible, then refactor to only perform each division once

Bonus:
Refactor again to add in Jazz (7) and to accept any bounds (handle special numbers correctly).  Write it so that it can add more checks without adding more code.  Then, create a reusable system that can apply rules in a specified order.
*/

using System.Text;
using FizzBuzz;

//MyOriginalSolution();
//SimpleSolution();
//RefactoredSimpleSolution();

var rules = new List<DivisibleRuleInfo>(){
    new DivisibleRuleInfo("FizzBuzzJazz",new [] {3,5,7}),
    new DivisibleRuleInfo("BuzzJazz",new [] {5,7}),
    new DivisibleRuleInfo("FizzJazz",new [] {3,7}),
    new DivisibleRuleInfo("FizzBuzz",new [] {3,5}),
    new DivisibleRuleInfo("Jazz",new [] {7}),
    new DivisibleRuleInfo("Buzz",new [] {5}),
    new DivisibleRuleInfo("Fizz",new [] {3})
};

ReusableRefactor(rules, -105, 105).ForEach(x => System.Console.WriteLine(x));

static void MyOriginalSolution()
{
    var lowerBound = 1;
    var upperBound = 100;

    var sb = new StringBuilder();

    for (int i = lowerBound; i <= upperBound; i++)
    {
        sb.Append(FizzBuzz(i)).Append("-");
    }

    System.Console.WriteLine(sb.ToString());
}

static string FizzBuzz(int input)
{
    var output = input.ToString();

    if (input % 3 == 0)
        output = "Fizz";

    if (input % 5 == 0)
        output = "Buzz";

    if (input % 3 == 0 && input % 5 == 0)
        output = "FizzBuzz";

    if (input % 7 == 0)
        output = "Jazz";

    return output;
}

static void SimpleSolution()
{
    for (int i = 1; i <= 100; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
            System.Console.WriteLine($"FizzBuzz ({i})");
        else if (i % 3 == 0)
            System.Console.WriteLine($"Fizz ({i})");
        else if (i % 5 == 0)
            System.Console.WriteLine($"Buzz ({i})");
        else
            System.Console.WriteLine(i);

    }
}

static void RefactoredSimpleSolution()
{
    //remove duplicate math operations (divisions)
    bool isFizz = false;
    bool isBuzz = false;

    for (int i = 1; i <= 100; i++)
    {
        isFizz = (i % 3 == 0);
        isBuzz = (i % 5 == 0);

        if (isFizz && isBuzz)
            System.Console.WriteLine($"FizzBuzz ({i})");
        else if (isFizz)
            System.Console.WriteLine($"Fizz ({i})");
        else if (isBuzz)
            System.Console.WriteLine($"Buzz ({i})");
        else
            System.Console.WriteLine(i);

    }
}

static void FlexibileRefactor(int lowerBound = 1, int upperBound = 100)

{
    Dictionary<int, string> rules = new Dictionary<int, string>(){
        {3,"Fizz"},
        {5,"Buzz"},
        {7,"Jazz"}
    };

    for (var i = lowerBound; i <= upperBound; i++)
    {
        var result = "";
        if (i == 0)
        {
            System.Console.WriteLine(0);
            continue;
        }
        foreach (var rule in rules)
        {
            if (i % rule.Key == 0)
            {
                result += rule.Value;
            }
        }

        if (result.Length != 0)
            System.Console.WriteLine($"{result} ({i})");
        else
            System.Console.WriteLine(i);
    }


}

static List<string> ReusableRefactor(List<DivisibleRuleInfo> rules, int lowerBound, int upperBound)
{
    var output = new List<string>();
    for (var i = lowerBound; i <= upperBound; i++)
    {
        var isFound = false;
        if (i == 0)
        {
            output.Add("0");
            continue;
        }
        foreach (var rule in rules)
        {
            if (NumIsDivsibleBy(i, rule.MustBeDivisibleBySet))
            {
                output.Add($"{rule.WordToPrint} ({i})");
                isFound = true;
                break;
            }
        }

        if (!isFound)
            output.Add(i.ToString());
    }
    return output;
}

static bool NumIsDivsibleBy(int num, int[] values)
{
    for (var i = 0; i < values.Length; i++)
    {
        if (num % values[i] != 0)
        {
            return false;
        }
    }

    return true;
}

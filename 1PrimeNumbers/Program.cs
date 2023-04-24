Console.WriteLine("Prime Number Challenge");

bool validInput = false;
int testInteger = 0;
string continueLooping = "";

do
{

    do
    {
        validInput = false;
        System.Console.WriteLine("Please Enter A Number:");
        var input = Console.ReadLine();

        validInput = int.TryParse(input, out testInteger);
    } while (!validInput);

    System.Console.WriteLine($"You entered {testInteger}");
    var factors = CheckForPrime(testInteger);

    if (factors.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"Is Prime: {testInteger}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"Is Composite: {testInteger}");
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine($"There are Factors {factors.Count} in {testInteger}");

        IEnumerable<int> primeFactors = from factor in factors
                                        where factor.Value == true
                                        select factor.Key;

        System.Console.WriteLine($"The largest prime factor is: {primeFactors.Max()}");
        System.Console.WriteLine();
        System.Console.WriteLine("Here are all of the prime factors.");
        foreach (var item in primeFactors)
        {
            System.Console.WriteLine($"-- {item}");
        }

    }

    System.Console.WriteLine();
    System.Console.WriteLine("===============================");
    System.Console.WriteLine();
    System.Console.WriteLine("Do you want to test again? [yes/no]");
    continueLooping = Console.ReadLine();
    if (String.IsNullOrEmpty(continueLooping))
        continueLooping = "yes";
} while (continueLooping!.ToLower() == "yes");





static Dictionary<int, bool?> CheckForPrime(int input)
{
    int max = input / 2;
    Dictionary<int, bool?> output = new Dictionary<int, bool?>();

    for (int i = 2; i <= max; i++)
    {
        if (input % i == 0)
        {
            output.Add(i, null);
        }
    }

    if (output.Count > 0)
    {
        foreach (var factor in output)
        {
            if (CheckForPrime(factor.Key).Count == 0)
                output[factor.Key] = true;
            else
                output[factor.Key] = false;
        }
    }

    return output;
}

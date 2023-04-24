/*
console app that can identify a palindrome (same forward and backward like racecar).  Create an overload to check for an int to see if it is a palindrome.

bonus
ignore, spacing, casing ans special characters when identifying palindromes.  For instance, "stack cats" is a palindrome.  Also create an overload method to handle doubles as well (so 12.321 is a palindrome).
*/

using System.Text.RegularExpressions;

var testStrings = new List<string> {
    "racecar",
    "stack cats",
    "Stack cats",
    "jacob"
};

foreach (var test in testStrings)
{
    System.Console.WriteLine(Palindrome.IsPalindrome(test));
}

System.Console.WriteLine("--------------------------");

var testInts = new List<int> {
    123,
    123321
};

foreach (var num in testInts)
{
    System.Console.WriteLine(Palindrome.IsPalindrome(num));
}

System.Console.WriteLine("=======================");

var testDouble = new List<double> {
    12.321,
    123.321
};

foreach (var num in testDouble)
{
    System.Console.WriteLine(Palindrome.IsPalindrome(num));
}

static class Palindrome
{
    public static bool IsPalindrome(string input)
    {
        var cleanString = CleanString(input);
        var reverse = new string(cleanString.Reverse().ToArray());
        return reverse == cleanString;
    }

    public static bool IsPalindrome(int input)
    {
        var intString = input.ToString();
        return IsPalindrome(intString);
    }

    public static bool IsPalindrome(double input)
    {
        var doubleString = input.ToString();
        return IsPalindrome(doubleString);
    }

    private static string CleanString(string input)
    {
        Regex alphaCheck = new Regex("[^a-zA-Z0-9]");
        var cleanedText = alphaCheck.Replace(input, "").ToLower();
        return cleanedText;
    }
}




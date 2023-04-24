using WordCountChallenge;
/*
Loop through strings and identify:
 the total character count (count line returns as 1)
 the number of characters excluding whitespace and line returns
 the number fo words in the string
 list each word, ensuring it is a valid word

 Bonus:
 identify: 
    the unique word list
    the unique character list (just alpha)
    the most used character
*/

using System.Text.RegularExpressions;

string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

foreach (var item in tests)
{
    System.Console.WriteLine($"Total Words: {StringFunctions.GetWordCount(item)}");
    System.Console.WriteLine($"Total Characters: {StringFunctions.GetCharactersLineEqualsOne(item)}");
    System.Console.WriteLine($"Total Characters no space: {StringFunctions.GetCharacterCountMinusLineReturnAndSpaces(item)}");
    System.Console.WriteLine($"Most used word: {StringFunctions.GetMostUsedWord(item)}");
    System.Console.WriteLine($"Most used character: {StringFunctions.GetMostUsedCharacter(item)}");
    System.Console.WriteLine("***** Unique Words *****");

    var uniqueWords = StringFunctions.GetUniqueWords(item);
    uniqueWords.ForEach(x => System.Console.WriteLine($"---- {x}"));

    System.Console.WriteLine("******************************");
}

/* 
    First string (tests[0]) Values:
    * Total Words: 14
    * Total Characters: 89
    * Character count (minus line returns and spaces): 60
    * Most used word: the (2 times)
    * Most used character: e (10 times)

    Second string (tests[1]) Values:
    * Total Words: 45
    * Total Characters: 276
    * Character count (minus line returns and spaces): 230
    * Most used word: the (6 times)
    * Most used character: t (24 times)
*/
using System.Text.RegularExpressions;

namespace WordCountChallenge;
public static class StringFunctions
{
    public static int GetCharactersLineEqualsOne(string input)
    {
        input = FindUniqueCharacters(input);
        var charArray = input.ToCharArray();
        return charArray.Length;
    }

    public static int GetCharacterCountMinusLineReturnAndSpaces(string input)
    {
        input = FindUniqueCharacters(input).Replace(" ", "");
        var charArray = input.ToCharArray();
        return charArray.Length;
    }

    public static string FindUniqueCharacters(string input)
    {
        input = input.Replace(Environment.NewLine, " ");
        Regex alphaCheck = new Regex("[^a-zA-Z.,()]");
        var cleanedText = alphaCheck.Replace(input, " ").ToLower();
        return cleanedText;
    }

    public static string RemovePunctuationAndLower(string input)
    {
        Regex alphaCheck = new Regex("[^a-zA-Z ]");
        var cleanedText = alphaCheck.Replace(input, " ").ToLower();
        return cleanedText;
    }

    public static int GetWordCount(string input)
    {
        var words = input.Split().ToList<string>().Where(x => x != "");
        return words.Count();
    }

    public static List<string> GetUniqueWords(string input)
    {
        var words = GetWords(input);
        var result = new List<string>();

        result = (
                    from word in words
                    group word by word into g
                    orderby g.Key.ToString() ascending
                    select g.Key.ToString()
                ).ToList();

        return result;
    }

    public static List<string> GetWords(string input)
    {
        input = RemovePunctuationAndLower(input);
        return input.Split().ToList<string>().Where(x => x != "").ToList();
    }

    public static (string, int) GetMostUsedWord(string input)
    {
        var words = GetWords(input);
        var findCounts = from word in words
                         group word by word into g
                         orderby g.Count() descending
                         select new
                         {
                             Total = g.Count(),
                             Word = g.Key.ToString()
                         };

        return (findCounts.First().Word, findCounts.First().Total);
        // var wordsDic = words
        //         .GroupBy(p => p)
        //         .ToDictionary(p => p.Key, q => q.Count());
        // var result = ("", 0);
        // var maxCount = 0;

        // foreach (var item in wordsDic)
        // {
        //     if (item.Value > maxCount)
        //     {
        //         maxCount = item.Value;
        //         result = (item.Key, item.Value);
        //     }
        // }
        // return result;
    }

    public static (string, int) GetMostUsedCharacter(string input)
    {
        input = FindUniqueCharacters(RemovePunctuationAndLower(input)).Replace(" ", "");
        var letters = input.ToCharArray();


        var findCounts = from letter in letters
                         group letter by letter into g
                         orderby g.Count() descending
                         select new
                         {
                             Total = g.Count(),
                             Word = g.Key.ToString()
                         };

        return (findCounts.First().Word, findCounts.First().Total);
        // var letterDic = letters
        //         .GroupBy(p => p)
        //         .ToDictionary(p => p.Key, q => q.Count());
        // var result = ("", 0);
        // var maxCount = 0;

        // foreach (var item in letterDic)
        // {
        //     if (item.Value > maxCount)
        //     {
        //         maxCount = item.Value;
        //         result = ((String)item.Key.ToString(), item.Value);
        //     }
        // }
        //return result;
    }
}
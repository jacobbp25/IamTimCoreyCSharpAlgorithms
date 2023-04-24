/*
Find strings in file primary.txt upon input from console (old text, new text)

Bonus: Using the given text file (bonus.txt), find all the parameters (using code) that are inside curly braces.  Ask the user for replacement values.  Only ask once per parameter name.  So when you find {FirstName}, ask for the FirstName value and replace it.
*/

using System.Text.RegularExpressions;

#region basic

using StreamReader sr = File.OpenText("primary.txt");
var text = sr.ReadToEnd();
sr.Close();

System.Console.WriteLine("Find:");
var findText = Console.ReadLine() ?? "";
System.Console.WriteLine("Replace With:");
var replaceText = Console.ReadLine() ?? "";

var pattern = @$"\b(?:{findText})\b";

text = Regex.Replace(text, pattern, replaceText);

System.Console.WriteLine(text);

using StreamWriter sw = new StreamWriter("primary.txt");
sw.Write(text);
sw.Close();

#endregion

#region bonus

using StreamReader sr2 = File.OpenText("bonus.txt");
var text2 = sr2.ReadToEnd();
sr2.Close();

var paramPattern = "{([^}]*)}";
var paramList = Regex.Matches(text2, paramPattern)
                    .Cast<Match>()
                    .Select(x => x.Value)
                    .ToHashSet();

var paramListValues = new List<InputParam>();

foreach (var param in paramList)
{
    var paramValue = new InputParam { ParamName = param };
    System.Console.WriteLine($"Please enter {paramValue.ParamDisplay}");
    paramValue.Value = Console.ReadLine() ?? "";
    paramListValues.Add(paramValue);
}

foreach (var param in paramListValues)
{
    text2 = Regex.Replace(text2, param.ParamName, param.Value);
}

using StreamWriter sw2 = new StreamWriter("bonus.txt");
sw2.Write(text2);
sw2.Close();

#endregion

class InputParam
{
    public string ParamName { get; set; } = string.Empty;
    public string ParamDisplay
    {
        get
        {
            return this.ParamName.Replace("{", "").Replace("}", "");
        }
    }
    public string Value { get; set; } = string.Empty;
}




//replace text
//write file to disk

//bonus
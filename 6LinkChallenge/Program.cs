/*
create link query that takes in a string and returns a list of all the letters in order regardless of case

bonus: modify linq query to return a list of anonymous objects, each witha  letter property and a count property.  Populate
the count with the number of times a letter is used.  Order the list by letter count (max first) and then by character
*/

var input = "Last Hello world";

// var letterList = from x in input
//                  orderby x.ToString().ToLower()
//                  select x.ToString().ToLower();

// foreach (var letter in letterList)
// {
//     System.Console.WriteLine(letter);
// }

var letters = from x in input
              group x by x.ToString().ToLower() into y
              orderby y.Count() descending, y.Key.ToString()
              select (new
              {
                  Letter = y.Key,
                  Count = y.Count()
              });

foreach (var letter in letters)
{
    System.Console.WriteLine($"{letter.Count} {letter.Letter}");
}
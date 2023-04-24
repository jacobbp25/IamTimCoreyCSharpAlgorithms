/*
Create console app with a temperature class

Have an insert method and a way to read the min, max, and average temperatures inserted

Insert 100 random temps between 1 and 100

Optimize for reading the min, max and ag

Bonus:
Add a Method that takes in word version of numbers from one to ten.  Then create an interface for the class.  Finally without breaking the interface optimize for insert instead.
*/
Random rnd = new Random();
var temps = new Temperature();

List<int> randomTemps = Enumerable.Repeat(1, 100).Select(_ => rnd.Next(101)).ToList<int>();
randomTemps.ForEach(x =>
{
    temps.Insert(x);
});

string[] words = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
List<string> randomWordTemps = Enumerable.Repeat(1, 100).Select(_ => words[rnd.Next(0, words.Length)]).ToList<string>();

randomWordTemps.ForEach(x =>
{
    temps.Insert(x);
});

System.Console.WriteLine($"Minimum: {temps.MinimumTemperature}");
System.Console.WriteLine($"Maximum: {temps.MaximumTemperature}");
System.Console.WriteLine($"Average: {temps.AverageTemperature}");
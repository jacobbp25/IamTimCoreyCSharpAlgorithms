using System.Reflection;
using System.Text;

namespace SampleDataBll;

public class Sample
{
    Random rnd;

    public Sample()
    {
        rnd = new Random();
    }

    public bool GenerateRandomBool()
    {
        return rnd.NextDouble() >= 0.5;
    }

    public double GenerateRandomDouble(double floor = 0, double ceiling = 1)
    {
        return floor + (rnd.NextDouble() * (ceiling - floor));
    }

    public string GenerateRandomPhone()
    {
        return GenerateRandomNumberMatch("(xxx) xxx-xxxx");
    }

    public string GenerateRandomZip()
    {
        return GenerateRandomNumberMatch("xxxxx-xxxx");
    }


    public int GenerateRandomInt(int floor = 0, int ceiling = 100)
    {
        return rnd.Next(minValue: floor, maxValue: ceiling);
    }

    public string GenerateRandomFirstName()
    {
        var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var filePath = buildDir + @"\first.txt";
        var lines = File.ReadAllLines(filePath);
        var randomInt = GenerateRandomInt(0, lines.Count());
        return lines[randomInt];
    }

    public string GenerateRandomLastName()
    {
        var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var filePath = buildDir + @"\last.txt";
        var lines = File.ReadAllLines(filePath);
        var randomInt = GenerateRandomInt(0, lines.Count());
        return lines[randomInt];
    }

    public string GenerateFullName()
    {
        return $"{GenerateRandomFirstName()} {GenerateRandomLastName()}";
    }

    public string GenerateRandomNumberMatch(string pattern)
    {
        var output = new StringBuilder();
        var patternArray = pattern.ToCharArray().ToList();

        patternArray.ForEach(x =>
        {
            if (x == 'x')
            {
                output.Append(GenerateRandomInt(0, 10));
            }
            else
            {
                output.Append(x);
            }
        });
        return output.ToString();
    }
}
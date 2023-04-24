public class Temperature : IHaveMinMaxAvg
{
    private List<int> Temperatures = new List<int>();
    public int MinimumTemperature
    {
        get
        {
            return Temperatures.Min();
        }
    }
    public int MaximumTemperature
    {
        get
        {
            return Temperatures.Max();
        }
    }
    public double AverageTemperature
    {
        get
        {
            return Temperatures.Average();
        }
    }
    // public int MinimumTemperature { get; private set; }
    // public int MaximumTemperature { get; private set; }
    // public double AverageTemperature { get; private set; }

    private Dictionary<string, int> _words { get; set; }
    public Temperature()
    {
        _words = new Dictionary<string, int>() {
            {"zero",0},
            {"one",1},
            {"two",2},
            {"three",3},
            {"four",4},
            {"five",5},
            {"six",6},
            {"seven",7},
            {"eight",8},
            {"nine",9},
            {"ten",10},
        };
    }
    public void Insert(int temperature)
    {
        Temperatures.Add(temperature);
    }

    public void Insert(string temperature)
    {
        temperature = temperature.ToLower();
        Insert(_words[temperature]);
    }

    // public void Insert(string temperature)
    // {
    //     WordNumbers enumVal;
    //     var isValue = Enum.TryParse<WordNumbers>(temperature, out enumVal);
    //     switch (enumVal)
    //     {
    //         case WordNumbers.zero:
    //             {
    //                 Insert(0);
    //                 break;
    //             }
    //         case WordNumbers.one:
    //             {
    //                 Insert(1);
    //                 break;
    //             }
    //         case WordNumbers.two:
    //             {
    //                 Insert(2);
    //                 break;
    //             }
    //         case WordNumbers.three:
    //             {
    //                 Insert(3);
    //                 break;
    //             }
    //         case WordNumbers.four:
    //             {
    //                 Insert(4);
    //                 break;
    //             }
    //         case WordNumbers.five:
    //             {
    //                 Insert(5);
    //                 break;
    //             }
    //         case WordNumbers.six:
    //             {
    //                 Insert(6);
    //                 break;
    //             }
    //         case WordNumbers.seven:
    //             {
    //                 Insert(7);
    //                 break;
    //             }
    //         case WordNumbers.eight:
    //             {
    //                 Insert(8);
    //                 break;
    //             }
    //         case WordNumbers.nine:
    //             {
    //                 Insert(9);
    //                 break;
    //             }
    //         case WordNumbers.ten:
    //             {
    //                 Insert(10);
    //                 break;
    //             }
    //         default: break;
    //     }
    // }
}

enum WordNumbers
{
    zero,
    one,
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine,
    ten
}
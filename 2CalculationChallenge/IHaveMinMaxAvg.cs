/*
Create console app with a temperature class

Have an insert method and a way to read the min, max, and average temperatures inserted

Insert 100 random temps between 1 and 100

Optimize for reading the min, max and ag

Bonus:
Add a Method that takes in word version of numbers from one to ten.  Then create an interface for the class.  Finally without breaking the interface optimize for insert instead.
*/




interface IHaveMinMaxAvg
{
    public double AverageTemperature { get; }
    public int MaximumTemperature { get; }
    public int MinimumTemperature { get; }
    public void Insert(int input);
    public void Insert(string input);
}

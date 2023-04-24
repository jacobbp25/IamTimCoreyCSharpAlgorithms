namespace FizzBuzz;
public struct DivisibleRuleInfo
{
    public string WordToPrint;
    public int[] MustBeDivisibleBySet;

    public DivisibleRuleInfo(string word, int[] numberSet)
    {
        WordToPrint = word;
        MustBeDivisibleBySet = numberSet;
    }
}
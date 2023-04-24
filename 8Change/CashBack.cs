namespace Change;

public static partial class Register
{
    public class CashBack
    {
        public int NumberOfDenomination { get; set; }
        public DenominationInfo Denomination { get; set; } = new();
    }
}
namespace Change;

public static partial class Register
{
    public static decimal CalculateChange(decimal amountOwed, decimal amountPaid)
    {
        var change = 0m;

        if (amountPaid < amountOwed)
            throw new Exception("I need more money for this");

        change = amountPaid - amountOwed;

        return change;
    }

    public static List<CashBack> CalculateSpecificChange(decimal amount, decimal highestDenomination = 100)
    {
        var returnCurrency = new List<CashBack>();
        var orderedDenominations = CurrencyValues.Denominations.OrderByDescending(x => x.Amount);

        foreach (var tender in orderedDenominations)
        {
            if (tender.Amount <= highestDenomination)
            {
                if (amount >= tender.Amount)
                {
                    var cashBack = new CashBack();
                    cashBack.NumberOfDenomination = (int)Math.Floor(amount / tender.Amount);
                    cashBack.Denomination = tender;
                    returnCurrency.Add(cashBack);
                    amount -= (tender.Amount * cashBack.NumberOfDenomination);
                }
            }
        }

        return returnCurrency;
    }
}
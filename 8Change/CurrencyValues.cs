namespace Change;

public static class CurrencyValues
{
    public static List<DenominationInfo> Denominations = new List<DenominationInfo>{
        new DenominationInfo {Name = "Hundred", Amount = 100m},
        new DenominationInfo {Name = "Fifty", Amount = 50m},
        new DenominationInfo {Name = "Twenty", Amount = 20m},
        new DenominationInfo {Name = "Ten", Amount = 10m},
        new DenominationInfo {Name = "Five", Amount = 5m},
        new DenominationInfo {Name = "One", Amount = 1m},
        new DenominationInfo {Name = "Quarter", Amount = 0.25m},
        new DenominationInfo {Name = "Dime", Amount = 0.1m},
        new DenominationInfo {Name = "Nickel", Amount = 0.05m},
        new DenominationInfo {Name = "Penny", Amount = 0.01m}
    };
}

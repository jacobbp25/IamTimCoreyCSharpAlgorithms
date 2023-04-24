/*
calculate change 
*/

using Change;

var price = 8.29m;
var amountGiven = 25m;

var change = Register.CalculateChange(price, amountGiven);
System.Console.WriteLine(change);

var tender = Register.CalculateSpecificChange(change, 100);

foreach (var currency in tender)
{
    if (currency != null)
        System.Console.WriteLine($"{currency.Denomination.Name} x {currency.NumberOfDenomination}");
}
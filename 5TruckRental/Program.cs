/*
calculate the cost to rent a truck

$25 first hour
$50 / additional hour[s]
Round up to the next hour after 10 minutes

Bonus
Instead of 25 for first hour, $5 for first 20 minutes
Write method in way that logic doe not have to change if we adjust that rule again

Also change the calculation to round up to days:
$400/weekday and $200/weekend day
A day is until the end of business not 24 hours
*/

using TruckRental;

// var rental = new RentalTruck(60, 25, 50);
// var startTime = new DateTime(
//     2023, 04, 20, 10, 00, 00
// );
// var endTime = new DateTime(
//     2023, 04, 20, 12, 11, 00
// );

// rental.StartRentalTime = startTime;
// rental.EndRentalTime = endTime;

// var price = rental.CalculateRentalPrice();
// System.Console.WriteLine($"Rental truck 25/first 50/hour Price {price}");

// System.Console.WriteLine("-------------------------");

// var rental2 = new RentalTruck(20, 5, 50);
// var startTime2 = new DateTime(
//     2023, 04, 20, 10, 00, 00
// );
// var endTime2 = new DateTime(
//     2023, 04, 20, 13, 00, 00
// );

// rental2.StartRentalTime = startTime2;
// rental2.EndRentalTime = endTime2;

// var price2 = rental2.CalculateRentalPrice();
// System.Console.WriteLine($"Rental truck 5/first 20 50/hour Price {price2}");
// System.Console.WriteLine("-------------------------");
// var rental3 = new RentalTruck(20, 5, 50);
// var startTime3 = new DateTime(
//     2023, 04, 14, 10, 00, 00
// );
// var endTime3 = new DateTime(
//     2023, 04, 15, 16, 11, 00
// );

// rental3.StartRentalTime = startTime3;
// rental3.EndRentalTime = endTime3;

// var price3 = rental3.CalculateRentalPrice();
// System.Console.WriteLine($"Rental truck over 1 day Price {price3}");

System.Console.WriteLine("-------------------------");
var rental4 = new RentalTruck(20, 5, 50);
var startTime4 = new DateTime(
    2019, 3, 15, 13, 21, 00
);
var endTime4 = new DateTime(
    2019, 3, 22, 11, 11, 00
);

rental4.StartRentalTime = startTime4;
rental4.EndRentalTime = endTime4;

var price4 = rental4.CalculateRentalPrice();
System.Console.WriteLine($"Rental truck over 1 day and returned on time {price4:C}");
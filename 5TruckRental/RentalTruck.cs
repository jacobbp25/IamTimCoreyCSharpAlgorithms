namespace TruckRental;

public class RentalTruck
{
    private readonly int initialDurationInMinutes;
    private readonly decimal initialRate;
    private readonly decimal regularRate;
    private readonly int weekdayRate;
    private readonly int weekendRate;
    private const int minutesInHour = 60;
    private const int minutesBeforeRoundingUp = 10;
    private const int returnCutoff = 12;
    public DateTime StartRentalTime { get; set; }
    public DateTime EndRentalTime { get; set; }
    public RentalTruck(int initialDurationInMinutes, decimal initialRate, decimal regularRate, int weekdayRate = 400, int weekendRate = 200)
    {
        this.initialDurationInMinutes = initialDurationInMinutes;
        this.initialRate = initialRate;
        this.regularRate = regularRate;
        this.weekdayRate = weekdayRate;
        this.weekendRate = weekendRate;
    }

    public decimal CalculateRentalPrice()
    {
        if (IsOverDayThreshold())
            return CalculateDailyRate();
        else
            return CalculateHourlyRate();
    }

    private decimal CalculateDailyRate()
    {
        System.Console.WriteLine("Daily Rate:");
        var rentalPrice = 0.00m;

        for (DateTime date = StartRentalTime; date.Date < EndRentalTime.Date; date = date.AddDays(1))
        {
            System.Console.WriteLine($"Date: {date} - type {date.DayOfWeek}");
            rentalPrice += GetDailyRate(date.DayOfWeek);
        }

        if (IsAfterOfficeClose())
        {
            var nextDay = EndRentalTime.Date.AddDays(1);
            System.Console.WriteLine($"Returned late  charing for {nextDay.DayOfWeek}");
            rentalPrice += GetDailyRate(nextDay.DayOfWeek);
        }

        return rentalPrice;
    }

    private decimal GetDailyRate(DayOfWeek dayOfWeek)
    {
        var dayRate = weekdayRate;

        if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday)
            dayRate = weekendRate;

        return dayRate;
    }

    private decimal CalculateHourlyRate()
    {
        System.Console.WriteLine("Hourly Rate:");
        var minutesOfRental = GetRentalDurationInMinutes();
        var rentalPrice = 0.00m;

        if (minutesOfRental <= initialDurationInMinutes)
            return initialRate;

        //calculate first rate
        rentalPrice += initialRate;
        minutesOfRental -= initialDurationInMinutes;

        //calculate remaining
        int hoursRented = minutesOfRental / minutesInHour;
        rentalPrice = rentalPrice + (hoursRented * regularRate);
        int remainingMinutes = minutesOfRental % minutesInHour;
        if (remainingMinutes >= minutesBeforeRoundingUp)
            rentalPrice += regularRate;

        return rentalPrice;
    }

    private int GetRentalDurationInMinutes()
    {
        var duration = EndRentalTime - StartRentalTime;

        var numberOfMinutes = TimeSpan.FromTicks(duration.Ticks).TotalMinutes;

        return Convert.ToInt32(numberOfMinutes);
    }

    private bool IsOverDayThreshold()
    {
        var hourlyRate = CalculateHourlyRate();
        if (hourlyRate < CalculateDailyRate())
            return false;

        if (StartRentalTime.Date.Day != EndRentalTime.Date.Day)
            return true;

        if (IsAfterOfficeClose())
            return true;

        return false;
    }

    private bool IsAfterOfficeClose()
    {
        return EndRentalTime.Hour >= returnCutoff;
    }
}
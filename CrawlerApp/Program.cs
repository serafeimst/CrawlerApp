using System.Globalization;
using CrawlerLibrary;

var data = Crawler.GetData();
var cultureInfo = new CultureInfo("el-GR");
DateTime dateFrom;
DateTime dateTo;
decimal amount;
decimal totalDays;

while (true)
{
    Console.Clear();
    Console.WriteLine("Date from (dd/mm/yyyy)");

    while (!DateTime.TryParse(Console.ReadLine(),cultureInfo,out dateFrom))
    {
        Console.WriteLine("Invalid input");
    }

    Console.WriteLine("Date to (dd/mm/yyyy)");

    while (!DateTime.TryParse(Console.ReadLine(), cultureInfo, out dateTo))
    {
        Console.WriteLine("Invalid input");
    }

    var interestRate = data.FirstOrDefault(d=>d.StartDate ==  dateFrom && d.EndDate == dateTo);

    Console.WriteLine("Give the amount");

    while (!decimal.TryParse(Console.ReadLine(), cultureInfo, out amount))
    {
        Console.WriteLine("Invalid input");
    }

    Console.WriteLine("Press 1 for 365 days or any other key for 360 days");

    if(Console.ReadLine().Equals("1"))
    {
        totalDays = 365m;
    }
    else
    {
        totalDays = 360m;
    }

    decimal days = (dateTo - dateFrom).Days + 1m;

    decimal legalInterest = Math.Round((days / totalDays) * interestRate.LegalPractitionerValue,2,MidpointRounding.AwayFromZero);
    decimal defaultInterest = Math.Round((days / totalDays) * interestRate.OverTimeValue,2,MidpointRounding.AwayFromZero);

    Console.WriteLine();
    Console.WriteLine($"Date from:{dateFrom.ToString("dd/MM/yyyy")} Date to:{dateTo.ToString("dd/MM/yyyy")} Days:{days}");

    Console.WriteLine();
    Console.WriteLine($"Legal interest");
    Console.WriteLine($"Interest rate : {interestRate.LegalPractitioner}   Interest : {legalInterest}");
    Console.WriteLine($"Initial: {amount}");
    Console.WriteLine($"Interest: {legalInterest}");
    Console.WriteLine($"Sum: {amount + legalInterest}");
    
    Console.WriteLine();
    Console.WriteLine($"Default interest");
    Console.WriteLine($"Interest rate : {interestRate.OverTime}   Interest : {defaultInterest}");
    Console.WriteLine($"Initial: {amount}");
    Console.WriteLine($"Interest: {defaultInterest}");
    Console.WriteLine($"Sum: {amount + defaultInterest}");
    
    Console.ReadKey();
}

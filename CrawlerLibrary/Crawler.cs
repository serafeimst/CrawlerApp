using System.Globalization;
using HtmlAgilityPack;

namespace CrawlerLibrary;

public class Crawler
{
    public static List<InterestRate> GetData()
    {
        var web = new HtmlWeb();
        var document = web.Load(Url.BankOfGreeceUrl);
        var tableRows = document.DocumentNode
            .SelectNodes("//table[contains(@class,'insuranceCompany__table')]/tbody/tr");
        
        var interestRates=new List<InterestRate>(); 
        
        foreach (var row in tableRows)
        {
            var cells = row.SelectNodes("td");
            var interestRate = new InterestRate();

            foreach (var cell in cells)
            {
                interestRate.StartDate = ConvertToDate(cells[0].InnerText.Trim());
                interestRate.EndDate = ConvertToDate(cells[1].InnerText.Trim());
                interestRate.AdministrativeAct = cells[2].InnerText.Trim();
                interestRate.FEK = cells[3].InnerText.Trim();
                interestRate.LegalPractitioner = cells[4].InnerText.Trim();
                interestRate.OverTime = cells[5].InnerText.Trim();
                interestRate.LegalPractitionerValue = ConvertToDecimal(cells[4].InnerText.Trim())/10;
                interestRate.OverTimeValue = ConvertToDecimal(cells[5].InnerText.Trim())/10;
            }
            
            interestRates.Add(interestRate);
        }
        
        return interestRates;
    }

    public static decimal ConvertToDecimal(string input)
    {
        var cultureInfo = new CultureInfo("el-GR");
        decimal value = decimal.Parse(input.Replace("%", ""),cultureInfo);

        return value;
    }

    public static DateTime ConvertToDate(string date)
    {
        if (date.Equals("-"))
        {
            return DateTime.Today;
        }
        
        var cultureInfo = new CultureInfo("el-GR");
        DateTime dateValue=DateTime.Parse(date, cultureInfo);
        
        return dateValue;
    }
}
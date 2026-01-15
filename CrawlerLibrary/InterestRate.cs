namespace CrawlerLibrary;

public class InterestRate
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string AdministrativeAct { get; set; }=String.Empty;
    public string FEK { get; set; }=String.Empty;
    public string LegalPractitioner { get; set; }=string.Empty;
    public string OverTime { get; set; }=string.Empty;  
    public decimal LegalPractitionerValue { get; set; }
    public decimal OverTimeValue { get; set; }
}
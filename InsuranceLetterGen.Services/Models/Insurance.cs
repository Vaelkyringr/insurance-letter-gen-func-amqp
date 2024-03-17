namespace InsuranceLetterGen.Services.Models;

public class Insurance
{
    public string InsuranceNumber { get; init; } = null!;

    public decimal YearlyPremium { get; set; }

    public string InsurerName { get; set; } = null!;

    public DateTime StartPeriod { get; init; }

    public DateTime EndPeriod { get; init; }

    public List<string> Coverages { get; set; } = new List<string>();
}

    //"InsuranceNumber": "ROHP6DFAVF"
    //"YearlyPremium": 6272
    //"InsurerName": "Insurer",
    //"StartPeriod": "2024-03-14T17:45:33.893Z",
    //"EndPeriod": "2024-03-14T17:45:33.893Z",
    //"Coverages": ["Drulle"]

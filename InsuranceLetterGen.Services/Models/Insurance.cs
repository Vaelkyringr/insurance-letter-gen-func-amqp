namespace InsuranceLetterGen.Services.Models;

public class Insurance
{
    public string InsuranceNumber { get; init; } = null!;

    public decimal YearlyPremium { get; set; }

    public DateTime StartPeriod { get; init; }

    public DateTime EndPeriod { get; init; }
}
namespace InsuranceLetterGen.Services.Models;

public class Insurance
{
    public string InsuranceNumber { get; set; } = null!;

    public decimal YearlyPremium { get; set; }

    public string Description { get; set; } = null!;
}
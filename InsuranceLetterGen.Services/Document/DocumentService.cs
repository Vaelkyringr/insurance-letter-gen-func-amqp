using InsuranceLetterGen.Services.Models;

namespace InsuranceLetterGen.Services.Document;

public class DocumentService : IDocumentService
{
    public MemoryStream CreateInsuranceDocument(Insurance insurance)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = QuestPDF.Fluent.Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(16));

                page.Header()
                    .Text($"Insurance {insurance.InsuranceNumber}")
                    .SemiBold().FontSize(30).FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);
                        x.Item().Text($"Insured by: {insurance.InsurerName}");
                        x.Item().Text($"Premium: {insurance.YearlyPremium}");
                        x.Item().Text($"Period: {insurance.StartPeriod} - {insurance.EndPeriod}");
                        x.Item().Text($"Coverages: {string.Join(", ", insurance.Coverages)}");
                        x.Item().Text(Placeholders.LoremIpsum());
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        });

        var stream = new MemoryStream();
        document.GeneratePdf(stream);
        stream.Position = 0;

        return stream;
    }
}
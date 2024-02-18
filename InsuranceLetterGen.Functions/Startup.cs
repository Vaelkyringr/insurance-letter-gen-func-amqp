[assembly: FunctionsStartup(typeof(InsuranceLetterGen.Functions.Startup))]

namespace InsuranceLetterGen.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.AddTransient<IBlobStorageService, BlobStorageService>();
        builder.Services.AddTransient<IDocumentService, DocumentService>();
    }
}
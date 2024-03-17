using InsuranceLetterGen.Services.Document;
using InsuranceLetterGen.Services.Storage;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IBlobStorageService, BlobStorageService>();
        services.AddSingleton<IDocumentService, DocumentService>();
    })
    .Build();

host.Run();
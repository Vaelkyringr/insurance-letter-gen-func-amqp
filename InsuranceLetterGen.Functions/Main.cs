using InsuranceLetterGen.Services.Document;
using InsuranceLetterGen.Services.Models;
using InsuranceLetterGen.Services.Storage;

namespace InsuranceLetterGen.Functions;

public class Main
{
    private readonly ILogger _logger;
    private readonly IBlobStorageService _blobStorageService;
    private readonly IDocumentService _documentService;

    public Main(ILoggerFactory loggerFactory, IBlobStorageService blobStorageService, IDocumentService documentService)
    {
        _documentService = documentService;
        _blobStorageService = blobStorageService;
        _logger = loggerFactory.CreateLogger<Main>();
    }

    [Function("InsuranceLetterGen")]
    public async Task Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        // Create insurance letter
        var insurance = new Insurance { InsuranceNumber = "ABDHSKE" };
        var document = _documentService.CreateInsuranceDocument(insurance);

        // Store letter
        await _blobStorageService.UploadBlobAsync($"{insurance.InsuranceNumber}_{DateTime.Now:yyyyMMdd}_letter.pdf", document);
    }
}
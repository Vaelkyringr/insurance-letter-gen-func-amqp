using InsuranceLetterGen.Services.Document;
using InsuranceLetterGen.Services.Models;
using InsuranceLetterGen.Services.Storage;

namespace InsuranceLetterGen.Functions.V2;

public class Function
{
    private readonly ILogger _logger;
    private readonly IBlobStorageService _blobStorageService;
    private readonly IDocumentService _documentService;

    public Function(ILoggerFactory loggerFactory, IBlobStorageService blobStorageService, IDocumentService documentService)
    {
        _documentService = documentService;
        _blobStorageService = blobStorageService;
        _logger = loggerFactory.CreateLogger<Function>();
    }

    [Function("InsuranceLetterGen")]
    public async Task Run([RabbitMQTrigger("Insurance", ConnectionStringSetting = "DefaultQueueConnection")] string queueItem)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {queueItem}");

        // Create letter document
        var insurance = JsonConvert.DeserializeObject<Insurance>(queueItem);
        var document = _documentService.CreateInsuranceDocument(insurance);

        // Store letter
        await _blobStorageService.UploadBlobAsync($"{insurance.InsuranceNumber}_{DateTime.Now:yyyyMMdd}_letter.pdf", document);
    }
}
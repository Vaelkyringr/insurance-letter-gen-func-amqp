using InsuranceLetterGen.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace InsuranceLetterGen.Functions;

public class Function
{
    private readonly IDocumentService _documentService;
    private readonly IBlobStorageService _blobStorageService;

    public Function(IDocumentService documentService, IBlobStorageService blobStorageService)
    {
        _documentService = documentService;
        _blobStorageService = blobStorageService;
    }

    // Temporary function method
    [FunctionName("HttpFunction")]
    public void Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        // Create insurance letter PDF
        var insurance = new Insurance();
        var document = _documentService.CreateInsuranceDocument(insurance);

        // Store insurance letter
        //_blobStorageService.UploadBlobAsync();
    }

    //[FunctionName("Main")]
    //public void Run([RabbitMQTrigger("Insurance", ConnectionStringSetting = "RabbitMQConnection")]string myQueueItem, ILogger log)
    //{
    //    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
    //}
}
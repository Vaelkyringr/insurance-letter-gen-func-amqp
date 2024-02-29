using InsuranceLetterGen.Services.Document;
using InsuranceLetterGen.Services.Models;
using InsuranceLetterGen.Services.Storage;

namespace InsuranceLetterGen.Functions;

public class Function1
{
    private readonly ILogger _logger;
    private readonly IBlobStorageService _blobStorageService;
    private readonly IDocumentService _documentService;

    public Function1(ILoggerFactory loggerFactory, IBlobStorageService blobStorageService, IDocumentService documentService)
    {
        _documentService = documentService;
        _blobStorageService = blobStorageService;
        _logger = loggerFactory.CreateLogger<Function1>();
    }

    [Function("Function1")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        // Create insurance letter
        var insurance = new Insurance();
        var document = _documentService.CreateInsuranceDocument(insurance);

        // Store letter
        _blobStorageService.UploadBlobAsync("insurance-letter.pdf", document);

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString("Welcome to Azure Functions!");

        return response;
    }
}
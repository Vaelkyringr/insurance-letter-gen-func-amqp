using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace InsuranceLetterGen.Services.Storage;

public class BlobStorageService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorageService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("DefaultBlobConnection"));
    }

    public async Task UploadBlobAsync(string blobContainerName, string blobName, Stream content)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
        await blobContainerClient.CreateIfNotExistsAsync();
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(content, overwrite: true);
    }

    public async Task<Stream> GetBlobAsync(string blobContainerName, string blobName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        var response = await blobClient.DownloadAsync();

        return response.Value.Content;
    }
}

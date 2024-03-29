﻿namespace InsuranceLetterGen.Services.Storage;

public class BlobStorageService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string? _blobContainerName;

    public BlobStorageService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("DefaultBlobConnection"));
        _blobContainerName = Environment.GetEnvironmentVariable("BlobContainerName");
    }

    public async Task UploadBlobAsync(string blobName, Stream content)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_blobContainerName);
        await blobContainerClient.CreateIfNotExistsAsync();
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(content, overwrite: true);
    }

    public async Task<Stream> GetBlobAsync(string blobName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_blobContainerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        var response = await blobClient.DownloadAsync();

        return response.Value.Content;
    }
}

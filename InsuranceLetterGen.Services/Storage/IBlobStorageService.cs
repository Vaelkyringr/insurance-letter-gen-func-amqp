namespace InsuranceLetterGen.Services.Storage;

public interface IBlobStorageService
{
    Task UploadBlobAsync(string blobContainerName, string blobName, Stream content);

    Task<Stream> GetBlobAsync(string blobContainerName, string blobName);
}

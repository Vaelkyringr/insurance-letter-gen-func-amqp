namespace InsuranceLetterGen.Services.Storage;

public interface IBlobStorageService
{
    Task UploadBlobAsync(string blobName, Stream content);

    Task<Stream> GetBlobAsync(string blobName);
}
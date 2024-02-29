using InsuranceLetterGen.Services.Models;

namespace InsuranceLetterGen.Services.Document;

public interface IDocumentService
{
    MemoryStream CreateInsuranceDocument(Insurance insurance);
}
namespace DocumentStore.Core;

public interface IDocumentStoreService
{
    Task<bool> Add(IDocument document);
    Task<IDocument> Get(string documentId);
    Task<IDocument> Update(IDocument document);
}

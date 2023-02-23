namespace DocumentStore.Core.Repository;

public interface IDocumentRepository
{
    Task<bool> Add(IDocument document);
    Task<IDocument> Update(IDocument document);
    Task<IDocument> Get(string documentId);
}

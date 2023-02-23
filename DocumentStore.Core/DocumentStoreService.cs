using DocumentStore.Core.Repository;
using Microsoft.Extensions.Logging;

namespace DocumentStore.Core;

public class DocumentStoreService : IDocumentStoreService
{
    private readonly IDocumentRepository _repository;

    public DocumentStoreService(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Add(IDocument document)
    {
        var success = await _repository.Add(document);
        return success;
    }

    public async Task<IDocument> Get(string documentId)
    {
        if(string.IsNullOrWhiteSpace(documentId))
            throw new ArgumentNullException(nameof(documentId));

        var document = await _repository.Get(documentId);

        return document;
    }

    public async Task<IDocument> Update(IDocument document)
    {
        return await _repository.Update(document);
    }
}

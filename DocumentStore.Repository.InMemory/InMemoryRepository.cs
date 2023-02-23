using DocumentStore.Core;
using DocumentStore.Core.Repository;
using Microsoft.Extensions.Logging;

namespace DocumentStore.Repository.InMemory;

// this is simple store. Other stores can be implemented in as new library and registered in IoC
public class InMemoryRepository : IDocumentRepository
{
    private Dictionary<string, IDocument> _documents = new Dictionary<string, IDocument>();
    private readonly ILogger _logger;

    public InMemoryRepository(ILogger<InMemoryRepository> logger)
    {
        _logger = logger;
    }

    public Task<bool> Add(IDocument document)
    {
        if (_documents.ContainsKey(document.Id))
            throw new ArgumentException($"Document with id '{document.Id}' already exists");

        _documents[document.Id] = document;

        _logger.LogInformation($"Added new document with Id {document.Id}");
        return Task.FromResult(true);
    }

    public Task<IDocument> Get(string documentId)
    {
        if (!_documents.ContainsKey(documentId))
            throw new ArgumentException($"Document with id '{documentId}' not found");

        _logger.LogInformation($"Retrieved document with id {documentId}");
        return Task.FromResult(_documents[documentId]);
    }

    public Task<IDocument> Update(IDocument document)
    {
        if (!_documents.ContainsKey(document.Id))
            throw new ArgumentException($"Document with id '{document.Id}' not found");

        _documents[document.Id] = document;

        _logger.LogInformation($"Updated document with id {document.Id}");
        return Task.FromResult(_documents[document.Id]);
    }
}

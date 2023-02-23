namespace DocumentStore.Core.DocumentFormater;

public interface IDocumentFormatter
{
    Task<string> Transform(IDocument document);
}
using DocumentStore.Core.DocumentFormater;
using DocumentStore.Core.DocumentFormatter.Formatters;

namespace DocumentStore.Core.DocumentFormatter;

public class DocumentFormaterFactory : IDocumentFormaterFactory
{
    private readonly IServiceProvider _services;

    public DocumentFormaterFactory(IServiceProvider services)
    {
        _services = services;
    }
    public IDocumentFormatter CreateJsonFormatter()
        => _services.GetRequiredService<IJsonFormatter>();

    public IDocumentFormatter CreateXmlFormatter()
        => _services.GetRequiredService<IXmlFormatter>();

    // This is to demonstrate other posibilities
    public IDocumentFormatter CreateTxtFormatter()
        => throw new NotImplementedException();
}

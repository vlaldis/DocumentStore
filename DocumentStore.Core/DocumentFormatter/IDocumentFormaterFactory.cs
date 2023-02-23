using DocumentStore.Core.DocumentFormater;

namespace DocumentStore.Core.DocumentFormatter;

public interface IDocumentFormaterFactory
{
    IDocumentFormatter CreateXmlFormatter();
    IDocumentFormatter CreateJsonFormatter();
    IDocumentFormatter CreateTxtFormatter();
}

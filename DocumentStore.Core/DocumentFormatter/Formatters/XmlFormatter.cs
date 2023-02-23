using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Text.Json;

namespace DocumentStore.Core.DocumentFormatter.Formatters;

public class XmlFormatter : IXmlFormatter
{
    public async Task<string> Transform(IDocument document)
        => await Task.FromResult(ToXml(document));

    private static string ToXml(IDocument document)
    {
        var json = JsonSerializer.Serialize(document);
        var jsonReader = JsonReaderWriterFactory.CreateJsonReader(
            Encoding.ASCII.GetBytes(json),
            new XmlDictionaryReaderQuotas());
        var xml = XDocument.Load(jsonReader);
        
        return xml.ToString();
    }
}

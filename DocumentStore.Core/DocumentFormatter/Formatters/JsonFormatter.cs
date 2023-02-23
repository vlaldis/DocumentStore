using System.Text.Json;

namespace DocumentStore.Core.DocumentFormatter.Formatters;

public class JsonFormatter : IJsonFormatter
{
    public async Task<string> Transform(IDocument document)
        => await Task.FromResult(JsonSerializer.Serialize(document));
}

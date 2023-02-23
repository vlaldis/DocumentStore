namespace DocumentStore.Core;

public record Document : IDocument
{
    public required string Id { get; init; }
    public required List<string> Tags { get; init; }
    public required object Data { get; init; }
}

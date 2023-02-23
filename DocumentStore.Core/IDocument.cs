namespace DocumentStore.Core;

public interface IDocument
{
    string Id { get; init; }
    List<string> Tags { get; init; } // list as xmlSerializer can not serialize interfaces
    object Data { get; init; }
}

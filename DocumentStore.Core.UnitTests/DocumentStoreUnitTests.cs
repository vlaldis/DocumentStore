using DocumentStore.Core.Repository;
using Moq;
using NUnit.Framework;

namespace DocumentStore.Core.UnitTests;

// Again only sample,
// there should be alco classes with tests for eeach formatter
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task DocumentStore_Add_Success()
    {
        var documentRepository = new Mock<IDocumentRepository>();
        documentRepository.Setup(_ => _.Add(It.IsAny<IDocument>())).ReturnsAsync(true);
        var documentStoreService = new DocumentStoreService(documentRepository.Object);
        var document = CreateDocument;
        var success = await documentStoreService.Add(document);

        Assert.That(success, Is.True);
        documentRepository.Verify(_ => _.Add(It.IsAny<IDocument>()), Times.Once);
    }

    private static IDocument CreateDocument
        => new Document { Id = "Id", Tags = new List<string> { "tag1", "tag2" }, Data = "testData" };
}
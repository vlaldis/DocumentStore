
using DocumentStore.Core;
using DocumentStore.Core.Repository;
using Microsoft.Extensions.Logging;
using Moq;

namespace DocumentStore.Repository.InMemory.UnitTests;

// This is sample.
// There should be tests for update and get methods as well.
//The remaining tests are similar so skipping them to reduce time waste.
public class Tests
{
    [Test]
    public async Task InMemoryRepository_Add_Success()
    {
        var repository = CreateInMemoryRepository();
        var success = await AddSample(repository);
        Assert.That(success, Is.True);
    }

    [Test]
    public async Task InMemoryRepository_AddDuplicate_Throws()
    {
        var repository = CreateInMemoryRepository();
        await AddSample(repository);

        Assert.That(async () => await AddSample(repository), Throws.ArgumentException);
    }

    private static async Task<bool> AddSample(IDocumentRepository repository)
    {
        var data = "data";
        var document = new Document { Id = "1", Tags = new () { "t1", "t2" }, Data = data };
        return await repository.Add(document);
    }

    private static IDocumentRepository CreateInMemoryRepository()
    {
        var logger = new Mock<ILogger<InMemoryRepository>>();
        var repository = new InMemoryRepository(logger.Object);
        return repository;
    }
}
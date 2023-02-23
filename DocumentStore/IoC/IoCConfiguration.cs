using DocumentStore.Core;
using DocumentStore.Core.DocumentFormatter;
using DocumentStore.Core.DocumentFormatter.Formatters;
using DocumentStore.Core.Repository;
using DocumentStore.Repository.InMemory;

namespace DocumentStore.IoC;

public static class IoCConfiguration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IXmlFormatter, XmlFormatter>();
        services.AddTransient<IJsonFormatter, JsonFormatter>();

        services.AddSingleton<IDocumentStoreService, DocumentStoreService>(); 
        services.AddSingleton<IDocumentFormaterFactory, DocumentFormaterFactory>();
        services.AddSingleton<IDocumentRepository, InMemoryRepository>();
        return services;
    }
}

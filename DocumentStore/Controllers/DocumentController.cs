using DocumentStore.Core;
using DocumentStore.Core.DocumentFormater;
using DocumentStore.Core.DocumentFormatter;
using Microsoft.AspNetCore.Mvc;

namespace DocumentStore.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IDocumentStoreService _documentStore;
    private readonly IDocumentFormaterFactory _formatterFactory;
    private readonly ILogger<DocumentController> _logger;

    public DocumentController(
        IDocumentStoreService documentStore,
        IDocumentFormaterFactory formatterFactory,
        ILogger<DocumentController> logger)
    {
        _documentStore = documentStore;
        _formatterFactory = formatterFactory;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] Document document)
        => await TryExecute(async () => await _documentStore.Add(document));

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Document document)
        => await TryExecute(async () => await _documentStore.Update(document));
    
    // this way we can request multiple formats

    [HttpGet("{documentId}/json")]
    [HttpGet("{documentId}")]
    public async Task<ActionResult> GetJson(string documentId)
        => await GetWithFormater(documentId, _formatterFactory.CreateJsonFormatter());

    [HttpGet("{documentId}/xml")]
    public async Task<ActionResult> GetXml(string documentId)
        => await GetWithFormater(documentId, _formatterFactory.CreateXmlFormatter());

    private async Task<ActionResult> GetWithFormater(string documentId, IDocumentFormatter documentFormatter)
        => await TryExecute(async () =>
        {
            var document = await _documentStore.Get(documentId);
            return documentFormatter.Transform(document);
        });

    private async Task<ActionResult> TryExecute<T>(Func<Task<T>> func)
    {
        try
        {
            var response = await func();
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occured", ex);
            return Problem(ex.Message);
        }
    }
}
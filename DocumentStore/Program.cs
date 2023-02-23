using DocumentStore.IoC;

var builder = WebApplication.CreateBuilder(args);

// For now support only console logging (visible in docker console)
// Can be enhanced with LogStash/etc
builder.Logging.ClearProviders().AddConsole();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.RegisterServices();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add error handling middleware
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

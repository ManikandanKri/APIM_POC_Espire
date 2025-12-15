using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
     .ConfigureServices(services =>
    {
        services.AddSingleton<ValidationService>();
        services.AddHttpClient<SourceApiService>(client =>
        {
            client.BaseAddress = new Uri("https://source-system/api/");
        });
         services.AddHttpClient<DestinationApiService>(client =>
        {
            client.BaseAddress = new Uri("https://apim-gateway/");
        });
    })
    .Build();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();



//app.Run();
host.Run();



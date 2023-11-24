using Application.Configs;
using Infra.Configs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

// Logger
builder.Logging.ClearProviders();
var Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

// Injeções

DataDependencyInjection.AddDataDependencies(builder.Services, builder.Configuration);
DataDependencyInjection.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    c.ShowExtensions(); 
});



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

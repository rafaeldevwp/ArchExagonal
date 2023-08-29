
using Application.Configs;
using Bussiness.Interfaces.Services;
using Infra.Configs;
using Infra.Services.AlunoServices;
using Infra.Services.Matricula;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

//Logger
builder.Logging.ClearProviders();
var Logger = new LoggerConfiguration()
.MinimumLevel.Information()
.WriteTo.Console()
.CreateLogger();



//Injeções
builder.Services.AddScoped<IAlunoServices, AlunoServices>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
DataDependencyInjection.AdddataDependencies(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Logger.Information("Iniciando minha API");
    app.UseSwagger();
    
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

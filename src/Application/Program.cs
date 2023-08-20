using Bussiness.Interfaces.Services;
using Infra.Services.AlunoServices;
using Infra.Services.Matricula;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Logger
builder.Logging.ClearProviders();
var Logger = new LoggerConfiguration()
.MinimumLevel.Information()
.WriteTo.Console()
.CreateLogger();

//Injeções
builder.Services.AddScoped<IAlunoServices, AlunoServices>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();

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

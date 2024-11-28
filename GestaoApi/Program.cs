using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using GestaoApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var defaultCulture = builder.Configuration["Culture:DefaultCulture"];
    var supportedCultures = builder.Configuration.GetSection("Culture:SupportedCultures").Get<string[]>();
    var supportedUICultures = builder.Configuration.GetSection("Culture:SupportedUICultures").Get<string[]>();

});
builder.Services.AddDbContext<Contexto>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoBD"));
    });
builder.Services.AddCors ();
builder.Services.AddControllers()
 .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
      c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo
          {
              Title = "GestaoApi",
              Version = "v1"
          });
      });
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaXCargoRepository, PessoaXCargoRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IDocumentoCartaOficialDesligamentoRepository, DocumentoCartaOficialDesligamentoRepository>();

var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.Run();


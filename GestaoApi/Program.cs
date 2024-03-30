using System.Text.Json.Serialization;
using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
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
builder.Services.AddControllers();
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

var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
//app.MapPut("/api/pessoa", async context => {});
app.Run();
/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};*/


//app.Run();


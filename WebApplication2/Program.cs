using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trainacc API", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trainacc API V1");
    c.DocExpansion(DocExpansion.None); // Опционально
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
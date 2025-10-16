using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VotacaoAPI.Data;
using VotacaoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CIPAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Votação",
        Version = "v1",
        Description = "API para gerenciar votos e candidatos."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Votação v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
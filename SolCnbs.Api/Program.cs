using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SolCnbs.Api.Endpoints;
using SolCnbs.Data.Context;
using SolCnbs.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<SolDbContext>(opciones =>
    opciones.UseSqlServer("name=SolDbConnection"));

builder.Services.AddScoped<IAuditRegistryRepository, AuditRegistryRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference();

app.UseHttpsRedirection();
app.UseCors();

#region Endpoints Configuration
app.MapGroup("/api/config").MapTemplatesConfiguration();
app.MapGroup("/api/auditores").MapAuditorsRegistry();
#endregion Endpoints Configuration

app.Run();
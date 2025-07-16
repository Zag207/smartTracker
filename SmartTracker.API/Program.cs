using Mapster;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

using SmartTracker.Services;
using SmartTraсker.Data;
using SmartTraсker.Data.Repositories.EF;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Postgres"));
});
builder.Services.AddMapster();
builder.Services.AddOpenApi();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuth(configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();
app.Run();


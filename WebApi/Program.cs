using Application;
using Persistence;
using System.Reflection;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceService(builder.Configuration); //PersistenceService ile bağlantı
builder.Services.AddApplicationServices();

builder.Services.AddHttpContextAccessor(); //Business Rule Midleware Bağlantısı


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureCustomExceptionMiddlewre(); //Business Rule Midleware Bağlantısı

app.UseAuthorization();

app.MapControllers();

app.Run();

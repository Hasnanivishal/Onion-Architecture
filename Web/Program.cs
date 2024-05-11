using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Service;
using Service.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.PersonController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
builder.Services.AddSingleton<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

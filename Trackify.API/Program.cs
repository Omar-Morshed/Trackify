using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Trackify.Application;
using Trackify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers() //* To Serialize the Enum with System.Text.Json Library
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

// builder.Services.AddProblemDetails();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationConfigurations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

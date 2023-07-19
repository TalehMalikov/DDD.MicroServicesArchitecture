using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using Prometheus;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, configuration)
        => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddOptions<ConnectionOptions>().BindConfiguration(nameof(ConnectionOptions));
var connectionOptions = builder.Configuration.GetSection(nameof(ConnectionOptions)).Get<ConnectionOptions>();

builder.Services.AddInfrastructureServices(connectionOptions.DefaultConnectionString);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();

builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();


app.UseHttpsRedirection();

app.UseMetricServer();

app.UseAuthorization();

app.MapControllers();

app.Run();
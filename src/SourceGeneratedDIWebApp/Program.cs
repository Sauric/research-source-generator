using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ServiceProviderSG>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello world!");

app.MapGet("/dateonly", async ([FromServices] ServiceProviderSG provider) =>
{
    var dateProvider = provider.GetService<IDateOnlyProvider>();
    return (await dateProvider.GetDateOnly()).ToString("dd.MM.yyyy");
});

app.MapGet("/datestring", async ([FromServices] ServiceProviderSG provider) =>
{
    var dateProvider = provider.GetService<IDateStringProvider>();
    return await dateProvider.GetStringDate();
});

app.MapGet("/customer/{id:Guid}", async ([FromServices] ServiceProviderSG provider, [Required] Guid id) => 
{
    var customerRepo = provider.GetService<ICustomerRepo>();
    return await customerRepo.GetCustomerById(id);
});

app.MapGet("/customers", async ([FromServices] ServiceProviderSG provider) => 
{
    var customerRepo = provider.GetService<ICustomerRepo>();
    return await customerRepo.GetCustomers();
});

app.MapDelete("/customer/{id:Guid}", async ([FromServices] ServiceProviderSG provider, [Required] Guid id) => 
{
    var customerRepo = provider.GetService<ICustomerRepo>();
    return await customerRepo.DeleteCustomerById(id);
});

app.MapPost("/customer", async ([FromServices] ServiceProviderSG provider, [Required][FromBody] Customer customer) => 
{
    var customerRepo = provider.GetService<ICustomerRepo>();
    return await customerRepo.CreateCustomer(customer);
});

app.Run();

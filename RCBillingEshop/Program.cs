using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RCBillingEshop.API.Extensions;
using RCBillingEshop.Application.Validators;
using RCBillingEshop.Infrastructure.DataStore;
using RCBillingEshop.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(new ApiExceptionFilterAttribute()))
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddValidatorsFromAssemblyContaining(typeof(OrderValidator));
builder.Services.AddDbContext<BillingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Billing")));
builder.Services.AddBillingAppServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await app.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

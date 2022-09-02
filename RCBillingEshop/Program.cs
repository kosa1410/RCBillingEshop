using Billing.Api.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using RCBillingEshop.API;
using RCBillingEshop.Infrastructure.DataStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BillingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Billing")));
builder.Services.AddBillingAppServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await app.MigrateAsync();
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

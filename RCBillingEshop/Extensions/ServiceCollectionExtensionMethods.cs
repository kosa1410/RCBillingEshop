using FluentValidation;
using RCBillingEshop.Application.Services;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Application.Services.Strategies;
using RCBillingEshop.Application.Validators;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Repositories;
using RCBillingEshop.Core.Repositories.Base;
using RCBillingEshop.Infrastructure.DataStore;
using RCBillingEshop.Infrastructure.DataStore.Repositories;

namespace Billing.Api.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBillingAppServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IBillingService, BillingService>();
        services.AddScoped<IPaymentGatewayStrategy, GreatPaymentGatewayStrategy>();
        services.AddScoped<IPaymentGatewayStrategy, BadPaymentGatewayStrategy>();
        services.AddScoped<IPaymentGatewayStrategy, SanctionPaymentGatewayStrategy>();
        services.AddValidatorsFromAssemblyContaining<OrderValidator>();

        return services;
    }
}
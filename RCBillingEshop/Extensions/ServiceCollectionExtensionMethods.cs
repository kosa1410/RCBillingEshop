using FluentValidation;
using RCBillingEshop.Application.Services;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Application.Services.Strategies;
using RCBillingEshop.Application.Validators;
using RCBillingEshop.Core.Repositories.Base;
using RCBillingEshop.Infrastructure.DataStore.Repositories;

namespace RCBillingEshop.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBillingAppServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IBillingService, BillingService>();
        services.AddScoped<IPaymentContext, PaymentContext>();
        services.AddScoped<IPaymentGatewayStrategy, GreatPaymentGatewayStrategy>();
        services.AddScoped<IPaymentGatewayStrategy, BadPaymentGatewayStrategy>();
        services.AddScoped<IPaymentGatewayStrategy, SanctionPaymentGatewayStrategy>();
        services.AddValidatorsFromAssemblyContaining<OrderValidator>();

        return services;
    }
}
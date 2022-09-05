using RCBillingEshop.Application.DataModels.DomainModels;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services.Strategies;

public class BadPaymentGatewayStrategy : IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Money money, PaymentGateway gateway)
    {
        return new PaymentResponse() { IsSuccesed = false };
    }
}

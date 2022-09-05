using RCBillingEshop.Application.DataModels.DomainModels;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services.Abstractions;

public interface IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Money money, PaymentGateway gateway);
}

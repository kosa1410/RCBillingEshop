using RCBillingEshop.Application.DataModels.DomainModels;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services.Strategies;

public class SanctionPaymentGatewayStrategy : IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Money money, PaymentGateway gateway)
    {
        var newPrice = new Money() { SelectedCurrency = money.SelectedCurrency };
        newPrice.Amount = money.Amount * 10;
        return new PaymentResponse() { FullPayableAmount = newPrice, IsSuccesed = true };
    }
}

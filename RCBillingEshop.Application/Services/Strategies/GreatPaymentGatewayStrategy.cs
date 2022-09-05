using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services.Strategies;

public class GreatPaymentGatewayStrategy : IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Order order)
    {
        return new PaymentResponse() { FullPayableAmount = order.Price, IsSuccesed = true };
    }
}

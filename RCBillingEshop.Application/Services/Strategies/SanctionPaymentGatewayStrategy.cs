using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services.Strategies;

public class SanctionPaymentGatewayStrategy : IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Order order)
    {
        return new PaymentResponse() { FullPayableAmount = 10 * order.Price, IsSuccesed = true };
    }
}

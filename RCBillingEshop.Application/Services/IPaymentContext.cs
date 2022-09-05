using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services;

public interface IPaymentContext
{
    public void SetStrategy(IPaymentGatewayStrategy paymentGatewayStrategy);
    public PaymentResponse ExecutePaymentStrategy(Order order);
}
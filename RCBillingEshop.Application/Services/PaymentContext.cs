using RCBillingEshop.Application.DataModels.DomainModels;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services;

public class PaymentContext : IPaymentContext
{
    private IPaymentGatewayStrategy _paymentGatewayStrategy;

    public PaymentContext(IPaymentGatewayStrategy paymentGatewayStrategy)
    {
        _paymentGatewayStrategy = paymentGatewayStrategy;
    }

    public void SetStrategy(IPaymentGatewayStrategy paymentGatewayStrategy)
    {
        _paymentGatewayStrategy = paymentGatewayStrategy;
    }

    public PaymentResponse ExecutePaymentStrategy(Order order)
    {
        var money = new Money() { SelectedCurrency = order.Currency, Amount = order.Price };
        
        return _paymentGatewayStrategy.ProcessPayment(money, order.PaymentGateway);
    }

}
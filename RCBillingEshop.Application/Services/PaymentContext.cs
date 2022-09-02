using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services;

public class PaymentContext
{
    private readonly IPaymentGatewayStrategy _paymentGatewayStrategy;

    public PaymentContext(IPaymentGatewayStrategy paymentGatewayStrategy)
    {
        _paymentGatewayStrategy = paymentGatewayStrategy;
    }

    public PaymentResponse ExecutePaymentStrategy(Order order)
    {
        return _paymentGatewayStrategy.ProcessPayment(order);
    }

}

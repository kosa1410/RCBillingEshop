using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services;

public class GreatPaymentGatewayStrategy : IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Order order)
    {
        return new PaymentResponse() { FullPayableAmount = order.Price, isSuccesed = true };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services;

public class SanctionPaymentGatewayStrategy : IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Order order)
    {
        return new PaymentResponse() { FullPayableAmount = 10*order.Price, isSuccesed = true };
    }
}

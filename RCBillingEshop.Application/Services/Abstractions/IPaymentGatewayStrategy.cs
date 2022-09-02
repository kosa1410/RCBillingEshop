using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Services.Abstractions;

public interface IPaymentGatewayStrategy
{
    public PaymentResponse ProcessPayment(Order order);
}

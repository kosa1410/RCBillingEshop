using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.Mappers;

public static class PaymentGatewayMapper
{
    public static PaymentGatewayViewModel ToViewModel(PaymentGateway paymentGateway)
    {
        return new PaymentGatewayViewModel()
        {
            Destination = paymentGateway.Destination,
            Name = paymentGateway.Name,
        };
    }
}

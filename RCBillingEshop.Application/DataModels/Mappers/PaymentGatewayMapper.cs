using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.Mappers;

public static class PaymentGatewayMapper
{
    public static PaymentGatewayViewModel ToViewModel(this PaymentGateway paymentGateway)
    {
        return new PaymentGatewayViewModel()
        {
            Destination = paymentGateway.Destination,
            Name = paymentGateway.Name,
        };
    }
}

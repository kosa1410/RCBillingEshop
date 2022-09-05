using RCBillingEshop.Application.DataModels.DomainModels;

namespace RCBillingEshop.Application.DataModels.Responses;

public class PaymentResponse
{
    public bool IsSuccesed { get; set; }

    public Money FullPayableAmount { get; set; }
}

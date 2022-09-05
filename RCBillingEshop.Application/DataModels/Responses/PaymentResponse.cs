namespace RCBillingEshop.Application.DataModels.Responses;

public class PaymentResponse
{
    public bool IsSuccesed { get; set; }

    public decimal FullPayableAmount { get; set; }
}

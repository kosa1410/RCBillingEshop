namespace RCBillingEshop.Application.DataModels.ViewModels;

public class ReceiptViewModel
{
    public virtual OrderViewModel Order { get; set; }
    public decimal FullPayableAmount { get; set; }
}

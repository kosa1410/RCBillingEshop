using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.DataModels.ViewModels;

public class ReceiptViewModel
{
    public virtual OrderViewModel Order { get; set; }
    public decimal FullPayableAmount { get; set; }
    public Currency Currency { get; set; }
}

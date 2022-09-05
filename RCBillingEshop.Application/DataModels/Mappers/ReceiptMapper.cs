using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.Mappers;

public static class ReceiptMapper
{
    public static ReceiptViewModel ToViewModel(this Receipt receipt)
    {
        return new ReceiptViewModel()
        {
            Order = receipt.Order.ToViewModel(),
            FullPayableAmount = receipt.FullPayableAmount
        };
    } 
}

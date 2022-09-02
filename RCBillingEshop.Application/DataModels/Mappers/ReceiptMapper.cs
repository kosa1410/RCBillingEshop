using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.Mappers;

public static class ReceiptMapper
{
    public static ReceiptViewModel ToViewModel(Receipt receipt)
    {
        return new ReceiptViewModel()
        {
            Order = OrderMapper.ToViewModel(receipt.Order),
            FullPayableAmount = receipt.FullPayableAmount
        };
    } 
}

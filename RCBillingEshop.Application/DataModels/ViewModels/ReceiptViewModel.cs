using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.ViewModels;

public class ReceiptViewModel
{
    public virtual OrderViewModel Order { get; set; }
    public decimal FullPayableAmount { get; set; }
}

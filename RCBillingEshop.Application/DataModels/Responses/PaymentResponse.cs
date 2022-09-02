using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCBillingEshop.Application.DataModels.Responses;

public class PaymentResponse
{
    public bool isSuccesed { get; set; }

    public decimal FullPayableAmount { get; set; }
}

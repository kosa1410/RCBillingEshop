using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.DataModels.ViewModels;

public class OrderViewModel
{
    public int OrderNumber { get; set; }

    public Guid UserId { get; set; }

    public decimal Price { get; set; }

    public Currency Currency { get; set; }

    public PaymentGatewayViewModel PaymentGateway { get; set; }

    public string? Description { get; set; }

}

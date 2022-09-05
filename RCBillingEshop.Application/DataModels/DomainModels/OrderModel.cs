using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.DataModels.DomainModels;

public class OrderModel
{
    public int OrderNumber { get; set; }

    public Guid UserId { get; set; }

    public Money PriceValue { get; set; }
    public PaymentGateway PaymentGateway { get; set; }
    public Receipt Receipt { get; set; }
    public string? Description { get; set; }
}

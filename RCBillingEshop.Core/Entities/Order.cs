using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Core.Entities.Base;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Core.Entities;

public class Order : Entity
{
    public int OrderNumber { get; set; }

    public Guid UserId { get; set; }

    public decimal Price { get; set; }

    public Currency Currency { get; set; }

    public PaymentGateway PaymentGateway { get; set; }

    [Required, ForeignKey(nameof(Entities.PaymentGateway))]
    public Guid PaymentId { get; set; }

    public string? Description { get; set; }

    public virtual Receipt? Receipt { get; set; }
}

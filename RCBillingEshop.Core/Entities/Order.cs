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
    [Required]
    public int OrderNumber { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public Currency Currency { get; set; }

    public PaymentGateway PaymentGateway { get; set; }

    [Required, ForeignKey(nameof(Entities.PaymentGateway))]
    public Guid PaymentId { get; set; }

    public string? Description { get; set; }

    public virtual Receipt? Receipt { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RCBillingEshop.Core.Entities.Base;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Core.Entities;

public class Receipt : Entity
{
    [Required, ForeignKey(nameof(Entities.Order))]
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
    public decimal FullPayableAmount { get; set; }
    public Currency Currency { get; set; }
}

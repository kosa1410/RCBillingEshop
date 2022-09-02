using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RCBillingEshop.Core.Entities.Base;

namespace RCBillingEshop.Core.Entities;

public class PaymentGateway : Entity
{
    [Required, ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public string Name { get; set; }
    public string Destination { get; set; }
}
using RCBillingEshop.Core.Entities.Base;

namespace RCBillingEshop.Core.Entities;

public class PaymentGateway : Entity
{
    public ICollection<Order> Orders { get; set; }

    public string Name { get; set; }
    public string Destination { get; set; }
}
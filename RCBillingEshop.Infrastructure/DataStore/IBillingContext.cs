using Microsoft.EntityFrameworkCore;
using RCBillingEshop.Core.Entities;

namespace Billing.Application.Services
{
    public interface IBillingContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Receipt> Receipts { get; set; }
        DbSet<PaymentGateway> PaymentsGateways { get; set; }
    }
}
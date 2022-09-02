using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Infrastructure.DataStore;

public class BillingDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<PaymentGateway> PaymentGateways { get; set; }
    public DbSet<Receipt> Receipts { get; set; }

    public BillingDbContext(DbContextOptions options)
        : base(options)
    {
    }
}

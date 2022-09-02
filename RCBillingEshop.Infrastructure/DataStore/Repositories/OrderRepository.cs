using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Repositories;

namespace RCBillingEshop.Infrastructure.DataStore.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly BillingDbContext _billingDbContext;

    public OrderRepository(BillingDbContext billingDbContext) : base(billingDbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetOrderByOrderNumber(int orderNumber, CancellationToken token)
    {
        return await _billingDbContext.Set<Order>().Where(o => o.OrderNumber.Equals(orderNumber)).ToListAsync(token);
    }

}

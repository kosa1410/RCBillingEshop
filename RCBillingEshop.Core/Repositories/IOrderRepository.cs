using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Repositories.Base;

namespace RCBillingEshop.Core.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrderByOrderNumber(int orderNumber, CancellationToken token);

}

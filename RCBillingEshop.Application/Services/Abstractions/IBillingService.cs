using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.ViewModels;

namespace RCBillingEshop.Application.Services.Abstractions;

public interface IBillingService
{
    Task<Guid> CreateOrderAsync(OrderDto input, CancellationToken token);

    Task<IEnumerable<OrderViewModel>> FindOrderAsync(int orderNumber, CancellationToken token = default);

    Task<IEnumerable<OrderViewModel>> GetAllAsync(CancellationToken token);
}

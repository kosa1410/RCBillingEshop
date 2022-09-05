using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.ViewModels;

namespace RCBillingEshop.Application.Services.Abstractions;

public interface IBillingService
{
    Task<Guid> ProcessOrderAsync(OrderDto input, CancellationToken token = default);

    Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken token = default);
    Task<OrderViewModel> GetOrdersAsync(Guid guid, CancellationToken token);
}

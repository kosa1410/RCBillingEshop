using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.Mappers;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Application.Exceptions;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Application.Services.Strategies;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Enums;
using RCBillingEshop.Core.Repositories.Base;

namespace RCBillingEshop.Application.Services;

public class BillingService : IBillingService
{
    private readonly IRepository<Order> _repository;
    private readonly IPaymentContext _paymentContext;

    public BillingService(IRepository<Order> repository, IPaymentContext paymentContext)
    {
        _repository = repository;
        _paymentContext = paymentContext;
    }


    public async Task<Guid> ProcessOrderAsync(OrderDto input, CancellationToken token = default)
    {
        var createdOrder = await CreateOrderAsync(input, token);

        await ProcessOrderToPaymentGatewayAsync(createdOrder);

        return createdOrder.Id;
    }

    private async Task<Order> CreateOrderAsync(OrderDto input, CancellationToken token = default)
    {
        var order = input.ToEntity();

        return await _repository.AddAsync(order, token);

    }
    private async Task ProcessOrderToPaymentGatewayAsync(Order order)
    {
        _paymentContext.SetStrategy(GetGatewayStrategy(order.Currency));
        var paymentResponse = _paymentContext.ExecutePaymentStrategy(order);
        if (!paymentResponse.IsSuccesed)
        {
            throw new PaymentFailedException($"Payment failed for Order Id : {order.Id}");
        }

        order.Receipt = new Receipt()
        {
            FullPayableAmount = paymentResponse.FullPayableAmount.Amount,
            Currency = paymentResponse.FullPayableAmount.SelectedCurrency
        };
        await _repository.UpdateAsync(order);
    }

    private static IPaymentGatewayStrategy GetGatewayStrategy(Currency currency)
    {
        switch (currency)
        {
            case Currency.RUB:
                return new SanctionPaymentGatewayStrategy();
            case Currency.PLN:
                return new BadPaymentGatewayStrategy();
            default:
                return new GreatPaymentGatewayStrategy();
        }
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken token)
    {
        var orders = await _repository.GetAllAsync(token);
        return orders.Select(OrderMapper.ToViewModel).ToList();
    }

    public async Task<OrderViewModel> GetOrdersAsync(Guid guid,CancellationToken token)
    {
        var order = await _repository.GetByIdAsync(guid, token);
        if (order == null)
        {
            throw new EntityNotFoundException(typeof(Order),"There is no order with given id");
        }

        return order.ToViewModel();
    }
}

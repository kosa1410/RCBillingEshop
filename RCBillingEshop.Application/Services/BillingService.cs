using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.DomainModels;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.Mappers;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Application.Exceptions;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Application.Services.Strategies;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Enums;
using RCBillingEshop.Core.Repositories;
using RCBillingEshop.Core.Repositories.Base;

namespace RCBillingEshop.Application.Services;

public class BillingService : IBillingService
{
    private readonly IOrderRepository _repository;

    public BillingService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateOrderAsync(OrderDto input, CancellationToken token)
    {
        var order = OrderMapper.ToEntity(input);
        await _repository.AddAsync(order);

        await ProcessOrder(order);

        return order.Id;
    }

    private async Task ProcessOrder(Order order)
    {
        var paymentContext = new PaymentContext(GetGatewayStrategy(order.Currency));
        var paymentResponse = paymentContext.ExecutePaymentStrategy(order);
        if (!paymentResponse.isSuccesed)
        {
            throw new PaymentFailedException($"Payment failed for Order Id : {order.Id}");
        }

        order.Receipt = new Receipt()
        {
            FullPayableAmount = paymentResponse.FullPayableAmount
        };
        await _repository.UpdateAsync(order);
    }

    private IPaymentGatewayStrategy GetGatewayStrategy(Currency currency)
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
    public async Task<IEnumerable<OrderViewModel>> FindOrderAsync(int orderNumber, CancellationToken token = default)
    {
        var orders = await _repository.GetOrderByOrderNumber(orderNumber, token);
        return orders.Select(OrderMapper.ToViewModel).ToList();
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllAsync(CancellationToken token)
    {
        var orders = await _repository.GetAllAsync();
        return orders.Select(OrderMapper.ToViewModel).ToList();
    }
}

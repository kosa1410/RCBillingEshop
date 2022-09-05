using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.Mappers;

public static class OrderMapper
{

    public static OrderViewModel ToViewModel(this Order order)
    {
        return new OrderViewModel()
        {
            Currency = order.Currency,
            Description = order.Description,
            OrderNumber = order.OrderNumber,
            PaymentGateway = order.PaymentGateway.ToViewModel(),
            Price = order.Price,
            UserId = order.UserId,
        };
    }

    public static Order ToEntity(this OrderDto orderDto)
    {
        return new Order()
        {
            Currency = orderDto.Currency,
            Description = orderDto.Description,
            OrderNumber = orderDto.OrderNumber,
            Price = orderDto.Price,
            UserId = orderDto.UserId,
            PaymentGatewayId = orderDto.PaymentGatewayId,
        };
    }
}

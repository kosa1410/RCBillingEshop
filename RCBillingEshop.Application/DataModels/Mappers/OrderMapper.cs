using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.DataModels.Mappers;

public static class OrderMapper
{
    public static OrderViewModel ToViewModel(Order order)
    {
        return new OrderViewModel()
        {
            Currency = order.Currency,
            Description = order.Description,
            OrderNumber = order.OrderNumber,
            PaymentGateway = PaymentGatewayMapper.ToViewModel(order.PaymentGateway),
            Price = order.Price,
            UserId = order.UserId,
        };
    }

    public static Order ToEntity(OrderDto orderDto)
    {
        return new Order()
        {
            Currency = orderDto.Currency,
            Description = orderDto.Description,
            OrderNumber = orderDto.OrderNumber,
            Price = orderDto.Price,
            UserId = orderDto.UserId,
            PaymentId = orderDto.PaymentId,
        };
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using RCBillingEshop.Application.DataModels.DomainModels;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.Responses;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Application.Exceptions;
using RCBillingEshop.Application.Services;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Enums;
using RCBillingEshop.Core.Repositories.Base;
using Xunit;

namespace RCBillingEshop.Application.Tests.Services;

public class BillingServiceTests
{
    private readonly IRepository<Order> _repository;
    private readonly IPaymentContext _paymentContext;
    private readonly BillingService _targer;
    private readonly CancellationToken _cancellationToken;

    public BillingServiceTests()
    {
        _cancellationToken = CancellationToken.None;
        _repository = Substitute.For<IRepository<Order>>();
        _paymentContext = Substitute.For<IPaymentContext>();
        _targer = new BillingService(_repository, _paymentContext);
    }

    [Fact]
    public async Task ProcessOrderAsync_Should_throw_PaymentFailedException()
    {
        // Arrange 

        var orderId = Guid.NewGuid();
        var paymentGatewayId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var orderDto = new OrderDto()
        {
            Currency = Currency.EUR,
            Price = 10,
            PaymentGatewayId = paymentGatewayId,
            UserId = userId,
        };
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            Currency = Currency.EUR,
            Price = 10,
            PaymentGatewayId = paymentGatewayId,
        };
        var money = new Money() { SelectedCurrency = order.Currency, Amount = order.Price };
        var paymentResponse = new PaymentResponse() { FullPayableAmount = money, IsSuccesed = false };

        _repository.AddAsync(
            Arg.Is<Order>(o =>
                o.Currency == orderDto.Currency && o.PaymentGatewayId == paymentGatewayId && o.Price == orderDto.Price),
            _cancellationToken).Returns(Task.FromResult(order));
        _paymentContext.ExecutePaymentStrategy(order).Returns(paymentResponse);

        var errorMsg = $"Payment failed for Order Id : {order.Id}";

        // Act
        var call = async () => await _targer.ProcessOrderAsync(orderDto, _cancellationToken);

        // Assert
        await call.Should().ThrowExactlyAsync<PaymentFailedException>(errorMsg);
    }

    [Fact]
    public async Task ProcessOrderAsync_Should_create_order_with_Recipe()
    {
        // Arrange 

        var orderId = Guid.NewGuid();
        var paymentGatewayId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var orderDto = new OrderDto()
        {
            Currency = Currency.EUR,
            Price = 10,
            PaymentGatewayId = paymentGatewayId,
            UserId = userId,
        };
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            Currency = Currency.EUR,
            Price = 10,
            PaymentGatewayId = paymentGatewayId,
        };
        var money = new Money() { SelectedCurrency = order.Currency, Amount = order.Price };

        var paymentResponse = new PaymentResponse(){FullPayableAmount = money, IsSuccesed = true};

        _repository.AddAsync(
            Arg.Is<Order>(o =>
                o.Currency == orderDto.Currency && o.PaymentGatewayId == paymentGatewayId && o.Price == orderDto.Price),
            _cancellationToken).Returns(Task.FromResult(order));
        _paymentContext.ExecutePaymentStrategy(order).Returns(paymentResponse);  

        // Act
        var result = await _targer.ProcessOrderAsync(orderDto, _cancellationToken);

        // Assert
        order.Receipt.Should().NotBeNull();
    }


    [Fact]
    public async Task GetAllAsync_Should_return_all_Orders()
    {
        // Arrange
        var list = new List<Order>()
        {
            new Order()
            {
                Currency = Currency.EUR,
                Description = "test",
                OrderNumber = 1,
                PaymentGateway = new PaymentGateway() { Destination = "testDst1" },
                Price = 10
            },
            new Order()
            {
                Currency = Currency.EUR,
                Description = "test2",
                OrderNumber = 2,
                PaymentGateway = new PaymentGateway() { Destination = "testDst2" },
                Price = 20
            }
        };
        var resultList = new List<OrderViewModel>()
        {
            new OrderViewModel()
            {
                Currency = Currency.EUR,
                Description = "test",
                OrderNumber = 1,
                PaymentGateway = new PaymentGatewayViewModel() { Destination = "testDst1" },
                Price = 10
            },
            new OrderViewModel()
            {
                Currency = Currency.EUR,
                Description = "test2",
                OrderNumber = 2,
                PaymentGateway = new PaymentGatewayViewModel() { Destination = "testDst2" },
                Price = 20
            }
        };

        _repository.GetAllAsync(_cancellationToken).Returns(list);
        // Act
        var result =  await _targer.GetAllOrdersAsync(_cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(resultList);

    }
}

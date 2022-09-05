using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using RCBillingEshop.API.Controllers;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.Services.Abstractions;
using RCBillingEshop.Core.Enums;
using Xunit;

namespace RCBillingEshop.Application.Tests.Controllers;

public class OrderControllerTests
{
    private readonly CancellationToken _cancellationToken;
    private readonly IBillingService _billingService;
    private readonly IValidator<OrderDto> _validator;
    private readonly OrderController _target;

    public OrderControllerTests()
    {
        _cancellationToken = CancellationToken.None;
        _billingService = Substitute.For<IBillingService>();
        _validator = Substitute.For<IValidator<OrderDto>>();
        _target = new OrderController(_validator,_billingService);
    }

    [Fact]
    public async Task NewOrder_Should_Return_Id()
    {
        // Arrange 
        var orderId = Guid.NewGuid();
        var orderDto = new OrderDto
        {
            Currency = Currency.EUR,
            Price = 10,
            OrderNumber = 1,
            PaymentGatewayId = Guid.NewGuid()
        };
        _validator.ValidateAsync(orderDto, _cancellationToken).Returns(new ValidationResult());
        _billingService.ProcessOrderAsync(orderDto, _cancellationToken).Returns(orderId);
        
        // Act
        var result = await _target.NewOrder(orderDto, _cancellationToken);
        //
        result.Should().BeEquivalentTo(new OkObjectResult(orderId));
    }

}

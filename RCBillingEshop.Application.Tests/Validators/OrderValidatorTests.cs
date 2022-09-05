using System;
using System.Threading.Tasks;
using FluentAssertions;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.Validators;
using RCBillingEshop.Core.Enums;
using Xunit;

namespace RCBillingEshop.Application.Tests.Validators;

public class OrderValidatorTests
{
    private readonly OrderValidator _target;

    public OrderValidatorTests()
    {
        _target = new OrderValidator();
    }

    [Fact]
    public async Task Should_Validate_Successfully()
    {
        // Arrange
        var orderDto = new OrderDto()
            {
                Currency = Currency.EUR,
                Price = 10,
                PaymentGatewayId = Guid.NewGuid(),
                OrderNumber = 1,
            };
        
        // Act
        var result = await _target.ValidateAsync(orderDto);

        // Assert

        result.IsValid.Should().BeTrue();
    }


    [Fact]
    public async Task Should_Validate_Unsuccessfully()
    {
        // Arrange
        var orderDto = new OrderDto()
        {
            Currency = Currency.EUR,
            Price = -10,
            PaymentGatewayId = Guid.NewGuid(),
            OrderNumber = 0
        };

        // Act
        var result = await _target.ValidateAsync(orderDto);

        // Assert

        result.IsValid.Should().BeFalse();
    }
}

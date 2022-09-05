using FluentValidation;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.Validators;

public class OrderValidator : AbstractValidator<OrderDto>
{
    private readonly List<string> _currencyList = Enum.GetNames(typeof(Currency)).ToList();
    public OrderValidator()
    {
        RuleFor(o => o.Description).Length(0, 300);
        RuleFor(o => o.Price).GreaterThan(0).WithMessage($"{nameof(OrderDto.Price)} should be greater than 0");
        RuleFor(o => o.Currency).IsInEnum().WithMessage($"Currency should be one of : [{_currencyList.Select(q => q + " ").ToString()?.Trim()}");
        RuleFor(o => o.OrderNumber).GreaterThan(0).WithMessage($"{nameof(OrderDto.OrderNumber)} should be greater than 0");
    }
}

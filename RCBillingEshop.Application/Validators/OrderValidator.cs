using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Core.Entities;

namespace RCBillingEshop.Application.Validators;

public class OrderValidator : AbstractValidator<OrderDto>
{
    public OrderValidator()
    {
        RuleFor(o => o.Description).Length(0, 300);
        RuleFor(o => o.Price).GreaterThan(0);
        RuleFor(o => o.Currency).IsInEnum();
        RuleFor(o => o.OrderNumber).GreaterThan(0);
    }
}

using System.ComponentModel.DataAnnotations;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.DataModels.DTO;

public class OrderDto
{
    public int OrderNumber { get; set; }

    public Guid UserId { get; set; }

    public decimal Price { get; set; }

    [EnumDataType(typeof(Currency))]
    public Currency Currency { get; set; }

    public Guid PaymentGatewayId { get; set; }

    public string? Description { get; set; }

}

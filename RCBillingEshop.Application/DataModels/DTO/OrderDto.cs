using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCBillingEshop.Core.Entities;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.DataModels.DTO;

public class OrderDto
{
    public int OrderNumber { get; set; }

    public Guid UserId { get; set; }

    public decimal Price { get; set; }

    public Currency Currency { get; set; }

    public Guid PaymentId { get; set; }

    public string? Description { get; set; }

}

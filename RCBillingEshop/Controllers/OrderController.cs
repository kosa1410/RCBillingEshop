using Microsoft.AspNetCore.Mvc;
using RCBillingEshop.Application.DataModels.DTO;
using RCBillingEshop.Application.DataModels.ViewModels;
using RCBillingEshop.Application.Services.Abstractions;

namespace RCBillingEshop.API.Controllers;
[ApiController]
[Route(Route)]
public class OrderController : ControllerBase
{
    private const string Route = "api/orders";

    private readonly IBillingService _billingService;

    public OrderController(IBillingService billingService)
    {
        _billingService = billingService;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> NewOrder([FromBody] OrderDto order, CancellationToken token)
    {

        var creationResponse = await _billingService.CreateOrderAsync(order, token);
        return Ok(creationResponse);
    }

}

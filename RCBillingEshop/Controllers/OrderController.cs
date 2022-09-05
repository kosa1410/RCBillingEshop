using FluentValidation;
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

    private readonly IValidator<OrderDto> _validator;

    public OrderController(IValidator<OrderDto> validator, IBillingService billingService)
    {
        _validator = validator;
        _billingService = billingService;
    }

    private readonly IBillingService _billingService;
    

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> NewOrder([FromBody] OrderDto order, CancellationToken token)
    {
        var validationResult = await _validator.ValidateAsync(order, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var creationResponse = await _billingService.ProcessOrderAsync(order, token);
        return new OkObjectResult(creationResponse);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderViewModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetList(CancellationToken token)
    {
        var allOrders = await _billingService.GetAllOrdersAsync(token);

        return new OkObjectResult(allOrders);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrder(Guid id, CancellationToken token)
    {
        var allOrders = await _billingService.GetOrdersAsync(id, token);

        return new OkObjectResult(allOrders);
    }
}

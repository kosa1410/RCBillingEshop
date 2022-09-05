using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RCBillingEshop.Application.Exceptions;

namespace RCBillingEshop.Infrastructure.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
        {
            { typeof(CurrencyConflictException), HandleCurrencyConflictException },
            { typeof(PaymentFailedException), HandlePaymentFailedException },
            { typeof(EntityNotFoundException), HandleEntityNotFoundException },
            { typeof(OrderValidationException), HandleOrderValidationException}
        };

    }


    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        ProblemDetails details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
    
    private void HandleOrderValidationException(ExceptionContext context)
    {
        OrderValidationException exception = context.Exception as OrderValidationException;

        ProblemDetails details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "The specified request cannot be process.",
            Detail = exception.Message
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    private void HandleEntityNotFoundException(ExceptionContext context)
    {
        EntityNotFoundException exception = context.Exception as EntityNotFoundException;

        ProblemDetails details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);

        context.ExceptionHandled = true;
    }

    private void HandlePaymentFailedException(ExceptionContext context)
    {
        PaymentFailedException exception = context.Exception as PaymentFailedException;

        ProblemDetails details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified request cannot be process.",
            Detail = exception.Message
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    private void HandleCurrencyConflictException(ExceptionContext context)
    {
        CurrencyConflictException exception = context.Exception as CurrencyConflictException;

        ProblemDetails details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            Title = "The specified cannot be process.",
            Detail = exception.Message
        };

        context.Result = new ConflictObjectResult(details);

        context.ExceptionHandled = true;
    }
}

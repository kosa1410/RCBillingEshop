namespace RCBillingEshop.Application.Exceptions;

public class PaymentFailedException : Exception
{
    public PaymentFailedException(string? message) : base(message)
    {
    }
}

namespace RCBillingEshop.Application.Exceptions;

public class CurrencyConflictException : Exception
{
    public CurrencyConflictException(string message) : base(message)
    {

    }
}

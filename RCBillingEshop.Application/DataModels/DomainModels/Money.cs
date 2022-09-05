using RCBillingEshop.Application.Exceptions;
using RCBillingEshop.Core.Enums;

namespace RCBillingEshop.Application.DataModels.DomainModels;

public class Money
{
    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, (int)SelectedCurrency);
    }

    public decimal Amount { get; set; }

    public Currency SelectedCurrency { get; set; }

    public override string ToString()
    {
        return $"{Amount} {SelectedCurrency.ToString()}";
    }
    public static Money operator +(Money firstValue, Money secondValue)
    {
        CheckCurrencyValid(secondValue, secondValue);
        var result = new Money()
        { Amount = firstValue.Amount + secondValue.Amount, SelectedCurrency = firstValue.SelectedCurrency };
        return result;
    }

    public static Money operator -(Money firstValue, Money secondValue)
    {
        CheckCurrencyValid(secondValue, secondValue);
        var result = new Money()
        { Amount = firstValue.Amount - secondValue.Amount, SelectedCurrency = firstValue.SelectedCurrency };
        return result;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Money)obj);
    }

    protected bool Equals(Money money)
    {
        return Amount == money.Amount && SelectedCurrency == money.SelectedCurrency;
    }

    private static void CheckCurrencyValid(Money firstValue, Money secondValue)
    {
        if (!firstValue.SelectedCurrency.Equals(secondValue.SelectedCurrency))
        {
            throw new CurrencyConflictException($"Currency conflict {firstValue.SelectedCurrency.ToString()} =/= {secondValue.SelectedCurrency.ToString()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCBillingEshop.Application.Exceptions;

public class CurrencyConflictException : Exception
{
    public CurrencyConflictException(string message) : base(message)
    {

    }
}

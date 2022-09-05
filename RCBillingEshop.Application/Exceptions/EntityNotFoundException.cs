namespace RCBillingEshop.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Type type, object id)
        : base($"Entity \"{type.Name}\" ({id}) was not found.")
    {
    }
}

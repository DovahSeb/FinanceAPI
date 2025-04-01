using FinanceAPI.Application.Common.Enums;

namespace FinanceAPI.Application.Common.Exceptions;
public class NotFoundException(string message) : Exception(message)
{
    public static void ThrowIfNull(object argument, EntityType entityType)
    {
        if(argument == null)
        {
            Throw(entityType);
        }

    }

    public static void Throw(EntityType entityType)
    {
        throw new NotFoundException($"The {entityType} with the supplied id was not found");
    }
}

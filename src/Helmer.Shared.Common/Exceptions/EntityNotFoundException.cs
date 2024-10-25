namespace Helmer.Shared.Common.Exceptions;

public class EntityNotFoundException : Exception
{
	public EntityNotFoundException(string entityType, Guid entityId)
	{
		//Log.Error("Cannot find record of entity with type {entityType} and id {entityId}", entityType, entityId);
	}
}

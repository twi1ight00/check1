namespace Enyim.Caching.Memcached.Results.Factories;

public class DefaultRemoveOperationResultFactory : IRemoveOperationResultFactory
{
	public IRemoveOperationResult Create()
	{
		RemoveOperationResult removeOperationResult = new RemoveOperationResult();
		removeOperationResult.Success = false;
		removeOperationResult.Message = string.Empty;
		return removeOperationResult;
	}
}

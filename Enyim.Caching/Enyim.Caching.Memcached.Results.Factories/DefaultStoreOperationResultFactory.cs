namespace Enyim.Caching.Memcached.Results.Factories;

public class DefaultStoreOperationResultFactory : IStoreOperationResultFactory
{
	public IStoreOperationResult Create()
	{
		StoreOperationResult storeOperationResult = new StoreOperationResult();
		storeOperationResult.Message = string.Empty;
		storeOperationResult.Success = false;
		return storeOperationResult;
	}
}

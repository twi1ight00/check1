namespace Enyim.Caching.Memcached.Results.Factories;

public class DefaultGetOperationResultFactory : IGetOperationResultFactory
{
	public IGetOperationResult Create()
	{
		GetOperationResult getOperationResult = new GetOperationResult();
		getOperationResult.Message = string.Empty;
		getOperationResult.Value = null;
		getOperationResult.Success = false;
		return getOperationResult;
	}
}
public class DefaultGetOperationResultFactory<T> : IGetOperationResultFactory<T>
{
	public IGetOperationResult<T> Create()
	{
		GetOperationResult<T> getOperationResult = new GetOperationResult<T>();
		getOperationResult.Message = string.Empty;
		getOperationResult.Value = default(T);
		getOperationResult.Success = false;
		return getOperationResult;
	}
}

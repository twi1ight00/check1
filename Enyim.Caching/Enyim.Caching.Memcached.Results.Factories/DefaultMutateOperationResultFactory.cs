namespace Enyim.Caching.Memcached.Results.Factories;

public class DefaultMutateOperationResultFactory : IMutateOperationResultFactory
{
	public IMutateOperationResult Create()
	{
		MutateOperationResult mutateOperationResult = new MutateOperationResult();
		mutateOperationResult.Message = string.Empty;
		mutateOperationResult.Success = false;
		return mutateOperationResult;
	}
}

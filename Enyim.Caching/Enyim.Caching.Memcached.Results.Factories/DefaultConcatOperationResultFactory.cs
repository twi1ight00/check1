namespace Enyim.Caching.Memcached.Results.Factories;

public class DefaultConcatOperationResultFactory : IConcatOperationResultFactory
{
	public IConcatOperationResult Create()
	{
		ConcatOperationResult concatOperationResult = new ConcatOperationResult();
		concatOperationResult.Message = string.Empty;
		concatOperationResult.Success = false;
		return concatOperationResult;
	}
}

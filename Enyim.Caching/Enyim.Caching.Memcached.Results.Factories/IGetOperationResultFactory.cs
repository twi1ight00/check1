namespace Enyim.Caching.Memcached.Results.Factories;

public interface IGetOperationResultFactory<T>
{
	IGetOperationResult<T> Create();
}
public interface IGetOperationResultFactory
{
	IGetOperationResult Create();
}

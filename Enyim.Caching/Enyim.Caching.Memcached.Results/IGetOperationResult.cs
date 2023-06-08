namespace Enyim.Caching.Memcached.Results;

public interface IGetOperationResult<T> : INullableOperationResult<T>, ICasOperationResult, IOperationResult
{
}
public interface IGetOperationResult : INullableOperationResult<object>, ICasOperationResult, IOperationResult
{
}

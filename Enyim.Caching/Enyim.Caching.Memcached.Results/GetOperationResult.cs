namespace Enyim.Caching.Memcached.Results;

public class GetOperationResult<T> : OperationResultBase, IGetOperationResult<T>, INullableOperationResult<T>, ICasOperationResult, IOperationResult
{
	public bool HasValue => Value != null;

	public T Value { get; set; }

	public ulong Cas { get; set; }
}
public class GetOperationResult : OperationResultBase, IGetOperationResult, INullableOperationResult<object>, ICasOperationResult, IOperationResult
{
	public ulong Cas { get; set; }

	public bool HasValue => Value != null;

	public object Value { get; set; }
}

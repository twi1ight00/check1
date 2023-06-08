namespace Enyim.Caching.Memcached.Results;

public class PooledSocketResult : OperationResultBase, IPooledSocketResult, INullableOperationResult<PooledSocket>, IOperationResult
{
	public bool HasValue => Value != null;

	public PooledSocket Value { get; set; }
}

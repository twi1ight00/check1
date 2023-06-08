namespace Enyim.Caching.Memcached.Results;

public interface INullableOperationResult<T> : IOperationResult
{
	bool HasValue { get; }

	T Value { get; set; }
}

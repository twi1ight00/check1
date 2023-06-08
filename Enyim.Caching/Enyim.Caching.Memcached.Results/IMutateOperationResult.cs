namespace Enyim.Caching.Memcached.Results;

public interface IMutateOperationResult : ICasOperationResult, IOperationResult
{
	ulong Value { get; set; }
}

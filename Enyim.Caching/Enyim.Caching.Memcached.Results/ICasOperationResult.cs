namespace Enyim.Caching.Memcached.Results;

public interface ICasOperationResult : IOperationResult
{
	ulong Cas { get; set; }
}

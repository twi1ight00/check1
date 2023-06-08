namespace Enyim.Caching.Memcached;

public interface INodeFailurePolicy
{
	bool ShouldFail();
}

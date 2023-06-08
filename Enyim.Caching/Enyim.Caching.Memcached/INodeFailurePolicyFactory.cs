namespace Enyim.Caching.Memcached;

public interface INodeFailurePolicyFactory
{
	INodeFailurePolicy Create(IMemcachedNode node);
}

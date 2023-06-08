namespace Enyim.Caching.Memcached;

/// <summary>
/// Creates instances of <see cref="T:FailImmediatelyPolicy" />.
/// </summary>
public class FailImmediatelyPolicyFactory : INodeFailurePolicyFactory
{
	private static readonly INodeFailurePolicy PolicyInstance = new FailImmediatelyPolicy();

	INodeFailurePolicy INodeFailurePolicyFactory.Create(IMemcachedNode node)
	{
		return PolicyInstance;
	}
}

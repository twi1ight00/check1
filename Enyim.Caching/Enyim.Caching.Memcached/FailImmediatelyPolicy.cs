namespace Enyim.Caching.Memcached;

/// <summary>
/// Fails a node immediately when an error occures. This is the default policy.
/// </summary>
public sealed class FailImmediatelyPolicy : INodeFailurePolicy
{
	bool INodeFailurePolicy.ShouldFail()
	{
		return true;
	}
}

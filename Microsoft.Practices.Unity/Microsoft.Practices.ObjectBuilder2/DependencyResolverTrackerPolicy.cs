using System.Collections.Generic;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverTrackerPolicy" />.
/// </summary>
public class DependencyResolverTrackerPolicy : IDependencyResolverTrackerPolicy, IBuilderPolicy
{
	private List<object> keys = new List<object>();

	/// <summary>
	/// Add a new resolver to track by key.
	/// </summary>
	/// <param name="key">Key that was used to add the resolver to the policy set.</param>
	public void AddResolverKey(object key)
	{
		lock (keys)
		{
			keys.Add(key);
		}
	}

	/// <summary>
	/// Remove the currently tracked resolvers from the given policy list.
	/// </summary>
	/// <param name="policies">Policy list to remove the resolvers from.</param>
	public void RemoveResolvers(IPolicyList policies)
	{
		List<object> list = new List<object>();
		lock (keys)
		{
			list.AddRange(keys);
			keys.Clear();
		}
		foreach (object item in list)
		{
			policies.Clear<IDependencyResolverPolicy>(item);
		}
	}

	/// <summary>
	/// Get an instance that implements <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverTrackerPolicy" />,
	/// either the current one in the policy set or creating a new one if it doesn't
	/// exist.
	/// </summary>
	/// <param name="policies">Policy list to look up from.</param>
	/// <param name="buildKey">Build key to track.</param>
	/// <returns>The resolver tracker.</returns>
	public static IDependencyResolverTrackerPolicy GetTracker(IPolicyList policies, object buildKey)
	{
		IDependencyResolverTrackerPolicy dependencyResolverTrackerPolicy = policies.Get<IDependencyResolverTrackerPolicy>(buildKey);
		if (dependencyResolverTrackerPolicy == null)
		{
			dependencyResolverTrackerPolicy = new DependencyResolverTrackerPolicy();
			policies.Set(dependencyResolverTrackerPolicy, buildKey);
		}
		return dependencyResolverTrackerPolicy;
	}

	/// <summary>
	/// Add a key to be tracked to the current tracker.
	/// </summary>
	/// <param name="policies">Policy list containing the resolvers and trackers.</param>
	/// <param name="buildKey">Build key for the resolvers being tracked.</param>
	/// <param name="resolverKey">Key for the resolver.</param>
	public static void TrackKey(IPolicyList policies, object buildKey, object resolverKey)
	{
		IDependencyResolverTrackerPolicy tracker = GetTracker(policies, buildKey);
		tracker.AddResolverKey(resolverKey);
	}

	/// <summary>
	/// Remove the resolvers for the given build key.
	/// </summary>
	/// <param name="policies">Policy list containing the build key.</param>
	/// <param name="buildKey">Build key.</param>
	public static void RemoveResolvers(IPolicyList policies, object buildKey)
	{
		IDependencyResolverTrackerPolicy tracker = GetTracker(policies, buildKey);
		tracker.RemoveResolvers(policies);
	}
}

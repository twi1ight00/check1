using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A custom collection wrapper over <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> objects.
/// </summary>
public class PolicyList : IPolicyList
{
	private class NullPolicyList : IPolicyList
	{
		public void Clear(Type policyInterface, object buildKey)
		{
			throw new NotImplementedException();
		}

		public void ClearAll()
		{
			throw new NotImplementedException();
		}

		public void ClearDefault(Type policyInterface)
		{
			throw new NotImplementedException();
		}

		public IBuilderPolicy Get(Type policyInterface, object buildKey, bool localOnly, out IPolicyList containingPolicyList)
		{
			containingPolicyList = null;
			return null;
		}

		public IBuilderPolicy GetNoDefault(Type policyInterface, object buildKey, bool localOnly, out IPolicyList containingPolicyList)
		{
			containingPolicyList = null;
			return null;
		}

		public void Set(Type policyInterface, IBuilderPolicy policy, object buildKey)
		{
			throw new NotImplementedException();
		}

		public void SetDefault(Type policyInterface, IBuilderPolicy policy)
		{
			throw new NotImplementedException();
		}
	}

	private struct PolicyKey
	{
		public readonly object BuildKey;

		public readonly Type PolicyType;

		public PolicyKey(Type policyType, object buildKey)
		{
			PolicyType = policyType;
			BuildKey = buildKey;
		}

		public override bool Equals(object obj)
		{
			if (obj != null && obj.GetType() == typeof(PolicyKey))
			{
				return this == (PolicyKey)obj;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return SafeGetHashCode(PolicyType) * 37 + SafeGetHashCode(BuildKey);
		}

		public static bool operator ==(PolicyKey left, PolicyKey right)
		{
			if (left.PolicyType == right.PolicyType)
			{
				return object.Equals(left.BuildKey, right.BuildKey);
			}
			return false;
		}

		public static bool operator !=(PolicyKey left, PolicyKey right)
		{
			return !(left == right);
		}

		private static int SafeGetHashCode(object obj)
		{
			return obj?.GetHashCode() ?? 0;
		}
	}

	private readonly IPolicyList innerPolicyList;

	private readonly object lockObject = new object();

	private Dictionary<PolicyKey, IBuilderPolicy> policies = new Dictionary<PolicyKey, IBuilderPolicy>();

	/// <summary>
	/// Gets the number of items in the locator.
	/// </summary>
	/// <value>
	/// The number of items in the locator.
	/// </value>
	public int Count => policies.Count;

	/// <summary>
	/// Initialize a new instance of a <see cref="T:Microsoft.Practices.ObjectBuilder2.PolicyList" /> class.
	/// </summary>
	public PolicyList()
		: this(null)
	{
	}

	/// <summary>
	/// Initialize a new instance of a <see cref="T:Microsoft.Practices.ObjectBuilder2.PolicyList" /> class with another policy list.
	/// </summary>
	/// <param name="innerPolicyList">An inner policy list to search.</param>
	public PolicyList(IPolicyList innerPolicyList)
	{
		this.innerPolicyList = innerPolicyList ?? new NullPolicyList();
	}

	/// <summary>
	/// Removes an individual policy type for a build key.
	/// </summary>
	/// <param name="policyInterface">The type of policy to remove.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	public void Clear(Type policyInterface, object buildKey)
	{
		lock (lockObject)
		{
			Dictionary<PolicyKey, IBuilderPolicy> dictionary = ClonePolicies();
			dictionary.Remove(new PolicyKey(policyInterface, buildKey));
			SwapPolicies(dictionary);
		}
	}

	/// <summary>
	/// Removes all policies from the list.
	/// </summary>
	public void ClearAll()
	{
		lock (lockObject)
		{
			SwapPolicies(new Dictionary<PolicyKey, IBuilderPolicy>());
		}
	}

	/// <summary>
	/// Removes a default policy.
	/// </summary>
	/// <param name="policyInterface">The type the policy was registered as.</param>
	public void ClearDefault(Type policyInterface)
	{
		Clear(policyInterface, null);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <param name="policyInterface">The interface the policy is registered under.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <param name="containingPolicyList">The policy list in the chain that the searched for policy was found in, null if the policy was
	/// not found.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public IBuilderPolicy Get(Type policyInterface, object buildKey, bool localOnly, out IPolicyList containingPolicyList)
	{
		TryGetType(buildKey, out var type);
		return GetPolicyForKey(policyInterface, buildKey, localOnly, out containingPolicyList) ?? GetPolicyForOpenGenericKey(policyInterface, buildKey, type, localOnly, out containingPolicyList) ?? GetPolicyForType(policyInterface, type, localOnly, out containingPolicyList) ?? GetPolicyForOpenGenericType(policyInterface, type, localOnly, out containingPolicyList) ?? GetDefaultForPolicy(policyInterface, localOnly, out containingPolicyList);
	}

	private IBuilderPolicy GetPolicyForKey(Type policyInterface, object buildKey, bool localOnly, out IPolicyList containingPolicyList)
	{
		if (buildKey != null)
		{
			return GetNoDefault(policyInterface, buildKey, localOnly, out containingPolicyList);
		}
		containingPolicyList = null;
		return null;
	}

	private IBuilderPolicy GetPolicyForOpenGenericKey(Type policyInterface, object buildKey, Type buildType, bool localOnly, out IPolicyList containingPolicyList)
	{
		if (buildType != null && buildType.IsGenericType)
		{
			return GetNoDefault(policyInterface, ReplaceType(buildKey, buildType.GetGenericTypeDefinition()), localOnly, out containingPolicyList);
		}
		containingPolicyList = null;
		return null;
	}

	private IBuilderPolicy GetPolicyForType(Type policyInterface, Type buildType, bool localOnly, out IPolicyList containingPolicyList)
	{
		if (buildType != null)
		{
			return GetNoDefault(policyInterface, buildType, localOnly, out containingPolicyList);
		}
		containingPolicyList = null;
		return null;
	}

	private IBuilderPolicy GetPolicyForOpenGenericType(Type policyInterface, Type buildType, bool localOnly, out IPolicyList containingPolicyList)
	{
		if (buildType != null && buildType.IsGenericType)
		{
			return GetNoDefault(policyInterface, buildType.GetGenericTypeDefinition(), localOnly, out containingPolicyList);
		}
		containingPolicyList = null;
		return null;
	}

	private IBuilderPolicy GetDefaultForPolicy(Type policyInterface, bool localOnly, out IPolicyList containingPolicyList)
	{
		return GetNoDefault(policyInterface, null, localOnly, out containingPolicyList);
	}

	/// <summary>
	/// Get the non default policy.
	/// </summary>
	/// <param name="policyInterface">The interface the policy is registered under.</param>
	/// <param name="buildKey">The key the policy applies to.</param>
	/// <param name="localOnly">True if the search should be in the local policy list only; otherwise false to search up the parent chain.</param>
	/// <param name="containingPolicyList">The policy list in the chain that the searched for policy was found in, null if the policy was
	/// not found.</param>
	/// <returns>The policy in the list if present; returns null otherwise.</returns>
	public IBuilderPolicy GetNoDefault(Type policyInterface, object buildKey, bool localOnly, out IPolicyList containingPolicyList)
	{
		containingPolicyList = null;
		if (policies.TryGetValue(new PolicyKey(policyInterface, buildKey), out var value))
		{
			containingPolicyList = this;
			return value;
		}
		if (localOnly)
		{
			return null;
		}
		return innerPolicyList.GetNoDefault(policyInterface, buildKey, localOnly: false, out containingPolicyList);
	}

	/// <summary>
	/// Sets an individual policy.
	/// </summary>
	/// <param name="policyInterface">The <see cref="T:System.Type" /> of the policy.</param>
	/// <param name="policy">The policy to be registered.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	public void Set(Type policyInterface, IBuilderPolicy policy, object buildKey)
	{
		lock (lockObject)
		{
			Dictionary<PolicyKey, IBuilderPolicy> dictionary = ClonePolicies();
			dictionary[new PolicyKey(policyInterface, buildKey)] = policy;
			SwapPolicies(dictionary);
		}
	}

	/// <summary>
	/// Sets a default policy. When checking for a policy, if no specific individual policy
	/// is available, the default will be used.
	/// </summary>
	/// <param name="policyInterface">The interface to register the policy under.</param>
	/// <param name="policy">The default policy to be registered.</param>
	public void SetDefault(Type policyInterface, IBuilderPolicy policy)
	{
		Set(policyInterface, policy, null);
	}

	private Dictionary<PolicyKey, IBuilderPolicy> ClonePolicies()
	{
		return new Dictionary<PolicyKey, IBuilderPolicy>(policies);
	}

	private void SwapPolicies(Dictionary<PolicyKey, IBuilderPolicy> newPolicies)
	{
		policies = newPolicies;
		Thread.MemoryBarrier();
	}

	private static bool TryGetType(object buildKey, out Type type)
	{
		type = buildKey as Type;
		if (type == null)
		{
			NamedTypeBuildKey namedTypeBuildKey = buildKey as NamedTypeBuildKey;
			if (namedTypeBuildKey != null)
			{
				type = namedTypeBuildKey.Type;
			}
		}
		return type != null;
	}

	private static object ReplaceType(object buildKey, Type newType)
	{
		if (buildKey is Type)
		{
			return newType;
		}
		NamedTypeBuildKey namedTypeBuildKey = buildKey as NamedTypeBuildKey;
		if (namedTypeBuildKey != null)
		{
			return new NamedTypeBuildKey(newType, namedTypeBuildKey.Name);
		}
		throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.CannotExtractTypeFromBuildKey, buildKey), "buildKey");
	}
}

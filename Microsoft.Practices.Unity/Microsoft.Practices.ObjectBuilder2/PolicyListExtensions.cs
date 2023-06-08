using System;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Extension methods on <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to provide convenience
/// overloads (generic versions, mostly).
/// </summary>
public static class PolicyListExtensions
{
	/// <summary>
	/// Removes an individual policy type for a build key.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The type the policy was registered as.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to remove the policy from.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	public static void Clear<TPolicyInterface>(this IPolicyList policies, object buildKey) where TPolicyInterface : IBuilderPolicy
	{
		policies.Clear(typeof(TPolicyInterface), buildKey);
	}

	/// <summary>
	/// Removes a default policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The type the policy was registered as.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to remove the policy from.</param>
	public static void ClearDefault<TPolicyInterface>(this IPolicyList policies) where TPolicyInterface : IBuilderPolicy
	{
		policies.ClearDefault(typeof(TPolicyInterface));
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static TPolicyInterface Get<TPolicyInterface>(this IPolicyList policies, object buildKey) where TPolicyInterface : IBuilderPolicy
	{
		return (TPolicyInterface)policies.Get(typeof(TPolicyInterface), buildKey, localOnly: false);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="containingPolicyList">The policy list that actually contains the returned policy.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static TPolicyInterface Get<TPolicyInterface>(this IPolicyList policies, object buildKey, out IPolicyList containingPolicyList) where TPolicyInterface : IBuilderPolicy
	{
		return (TPolicyInterface)policies.Get(typeof(TPolicyInterface), buildKey, localOnly: false, out containingPolicyList);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="policyInterface">The interface the policy is registered under.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static IBuilderPolicy Get(this IPolicyList policies, Type policyInterface, object buildKey)
	{
		return policies.Get(policyInterface, buildKey, localOnly: false);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="policyInterface">The interface the policy is registered under.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="containingPolicyList">The policy list that actually contains the returned policy.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static IBuilderPolicy Get(this IPolicyList policies, Type policyInterface, object buildKey, out IPolicyList containingPolicyList)
	{
		return policies.Get(policyInterface, buildKey, localOnly: false, out containingPolicyList);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static TPolicyInterface Get<TPolicyInterface>(this IPolicyList policies, object buildKey, bool localOnly) where TPolicyInterface : IBuilderPolicy
	{
		return (TPolicyInterface)policies.Get(typeof(TPolicyInterface), buildKey, localOnly);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <param name="containingPolicyList">The policy list that actually contains the returned policy.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static TPolicyInterface Get<TPolicyInterface>(this IPolicyList policies, object buildKey, bool localOnly, out IPolicyList containingPolicyList) where TPolicyInterface : IBuilderPolicy
	{
		return (TPolicyInterface)policies.Get(typeof(TPolicyInterface), buildKey, localOnly, out containingPolicyList);
	}

	/// <summary>
	/// Gets an individual policy.
	/// </summary>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="policyInterface">The interface the policy is registered under.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static IBuilderPolicy Get(this IPolicyList policies, Type policyInterface, object buildKey, bool localOnly)
	{
		IPolicyList containingPolicyList;
		return policies.Get(policyInterface, buildKey, localOnly, out containingPolicyList);
	}

	/// <summary>
	/// Get the non default policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static TPolicyInterface GetNoDefault<TPolicyInterface>(this IPolicyList policies, object buildKey, bool localOnly) where TPolicyInterface : IBuilderPolicy
	{
		return (TPolicyInterface)policies.GetNoDefault(typeof(TPolicyInterface), buildKey, localOnly);
	}

	/// <summary>
	/// Get the non default policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <param name="containingPolicyList">The policy list that actually contains the returned policy.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static TPolicyInterface GetNoDefault<TPolicyInterface>(this IPolicyList policies, object buildKey, bool localOnly, out IPolicyList containingPolicyList) where TPolicyInterface : IBuilderPolicy
	{
		return (TPolicyInterface)policies.GetNoDefault(typeof(TPolicyInterface), buildKey, localOnly, out containingPolicyList);
	}

	/// <summary>
	/// Get the non default policy.
	/// </summary>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to search.</param>
	/// <param name="policyInterface">The interface the policy is registered under.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	/// <param name="localOnly">true if the policy searches local only; otherwise false to seach up the parent chain.</param>
	/// <returns>The policy in the list, if present; returns null otherwise.</returns>
	public static IBuilderPolicy GetNoDefault(this IPolicyList policies, Type policyInterface, object buildKey, bool localOnly)
	{
		IPolicyList containingPolicyList;
		return policies.GetNoDefault(policyInterface, buildKey, localOnly, out containingPolicyList);
	}

	/// <summary>
	/// Sets an individual policy.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface the policy is registered under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add the policy to.</param>
	/// <param name="policy">The policy to be registered.</param>
	/// <param name="buildKey">The key the policy applies.</param>
	public static void Set<TPolicyInterface>(this IPolicyList policies, TPolicyInterface policy, object buildKey) where TPolicyInterface : IBuilderPolicy
	{
		policies.Set(typeof(TPolicyInterface), policy, buildKey);
	}

	/// <summary>
	/// Sets a default policy. When checking for a policy, if no specific individual policy
	/// is available, the default will be used.
	/// </summary>
	/// <typeparam name="TPolicyInterface">The interface to register the policy under.</typeparam>
	/// <param name="policies"><see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add the policy to.</param>
	/// <param name="policy">The default policy to be registered.</param>
	public static void SetDefault<TPolicyInterface>(this IPolicyList policies, TPolicyInterface policy) where TPolicyInterface : IBuilderPolicy
	{
		policies.SetDefault(typeof(TPolicyInterface), policy);
	}
}

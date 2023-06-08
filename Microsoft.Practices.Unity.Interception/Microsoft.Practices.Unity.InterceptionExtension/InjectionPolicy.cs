using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Base class for Policies that specifies which handlers apply to which methods of an object.
/// </summary>
/// <remarks>
/// <para>This base class always enforces the 
/// <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ApplyNoPoliciesMatchingRule" /> before
/// passing the checks onto derived classes. This way, derived classes do not need to
/// worry about implementing this check.</para>
/// <para>It also means that derived classes cannot override this rule. This is considered a feature.</para></remarks>
public abstract class InjectionPolicy
{
	private readonly string name;

	private readonly IMatchingRule doesNotHaveNoPoliciesAttributeRule;

	/// <summary>
	/// Gets the name of this policy.
	/// </summary>
	/// <value>The name of the policy.</value>
	public string Name => name;

	/// <summary>
	/// Creates a new empty Policy.
	/// </summary>
	protected InjectionPolicy()
		: this("Unnamed policy")
	{
	}

	/// <summary>
	/// Creates a new empty policy with the given name.
	/// </summary>
	/// <param name="name">Name of the policy.</param>
	protected InjectionPolicy(string name)
	{
		this.name = name;
		doesNotHaveNoPoliciesAttributeRule = new ApplyNoPoliciesMatchingRule();
	}

	/// <summary>
	/// Checks if the rules in this policy match the given member info.
	/// </summary>
	/// <param name="member">MemberInfo to check against.</param>
	/// <returns>true if ruleset matches, false if it does not.</returns>
	public bool Matches(MethodImplementationInfo member)
	{
		if (DoesNotHaveNoPoliciesAttributeRule(member))
		{
			return DoesMatch(member);
		}
		return false;
	}

	private bool DoesNotHaveNoPoliciesAttributeRule(MethodImplementationInfo method)
	{
		bool flag = true;
		flag &= method.InterfaceMethodInfo == null || doesNotHaveNoPoliciesAttributeRule.Matches(method.InterfaceMethodInfo);
		return flag & doesNotHaveNoPoliciesAttributeRule.Matches(method.ImplementationMethodInfo);
	}

	/// <summary>
	/// Returns ordered collection of handlers in order that apply to the given member.
	/// </summary>
	/// <param name="member">Member that may or may not be assigned handlers by this policy.</param>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to use when creating handlers,
	/// if necessary.</param>
	/// <returns>Collection of handlers (possibly empty) that apply to this member.</returns>
	public virtual IEnumerable<ICallHandler> GetHandlersFor(MethodImplementationInfo member, IUnityContainer container)
	{
		if (!DoesNotHaveNoPoliciesAttributeRule(member))
		{
			yield break;
		}
		List<ICallHandler> handlers = new List<ICallHandler>(DoGetHandlersFor(member, container));
		if (handlers.Count <= 0)
		{
			yield break;
		}
		foreach (ICallHandler item in handlers)
		{
			yield return item;
		}
	}

	/// <summary>
	/// Given a method on an object, return the set of MethodBases for that method,
	/// plus any interface methods that the member implements.
	/// </summary>
	/// <param name="member">Member to get Method Set for.</param>
	/// <returns>The set of methods</returns>
	protected static IEnumerable<MethodBase> GetMethodSet(MethodBase member)
	{
		List<MethodBase> list = new List<MethodBase>(new MethodBase[1] { member });
		if (member.DeclaringType != null && !member.DeclaringType.IsInterface)
		{
			Type[] interfaces = member.DeclaringType.GetInterfaces();
			foreach (Type interfaceType in interfaces)
			{
				InterfaceMapping interfaceMap = member.DeclaringType.GetInterfaceMap(interfaceType);
				for (int j = 0; j < interfaceMap.TargetMethods.Length; j++)
				{
					if (interfaceMap.TargetMethods[j] == member)
					{
						list.Add(interfaceMap.InterfaceMethods[j]);
					}
				}
			}
		}
		return list;
	}

	/// <summary>
	/// Derived classes implement this method to calculate if the policy
	/// will provide any handler to the specified member.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>true if policy applies to this member, false if not.</returns>
	protected abstract bool DoesMatch(MethodImplementationInfo member);

	/// <summary>
	/// Derived classes implement this method to supply the list of handlers for
	/// this specific member.
	/// </summary>
	/// <param name="member">Member to get handlers for.</param>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to use when creating handlers,
	/// if necessary.</param>
	/// <returns>Enumerable collection of handlers for this method.</returns>
	protected abstract IEnumerable<ICallHandler> DoGetHandlersFor(MethodImplementationInfo member, IUnityContainer container);
}

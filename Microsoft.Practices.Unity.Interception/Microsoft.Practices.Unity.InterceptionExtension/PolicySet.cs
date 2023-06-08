using System.Collections.Generic;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A collection of Policy objects. The policies within a PolicySet combine using
/// an "or" operation.
/// </summary>
public class PolicySet : List<InjectionPolicy>
{
	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicySet" /> containing the given policies.
	/// </summary>
	/// <param name="policies">Policies to put into the policy set.</param>
	public PolicySet(params InjectionPolicy[] policies)
	{
		AddRange(policies);
	}

	/// <summary>
	/// Gets the policies that apply to the given member.
	/// </summary>
	/// <param name="member">Member to get policies for.</param>
	/// <returns>Collection of policies that apply to this member.</returns>
	public IEnumerable<InjectionPolicy> GetPoliciesFor(MethodImplementationInfo member)
	{
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			InjectionPolicy policy = enumerator.Current;
			if (policy.Matches(member))
			{
				yield return policy;
			}
		}
	}

	/// <summary>
	/// Gets the policies in the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicySet" /> that do not
	/// apply to the given member.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>Collection of policies that do not apply to <paramref name="member" />.</returns>
	public IEnumerable<InjectionPolicy> GetPoliciesNotFor(MethodImplementationInfo member)
	{
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			InjectionPolicy policy = enumerator.Current;
			if (!policy.Matches(member))
			{
				yield return policy;
			}
		}
	}

	/// <summary>
	/// Gets the handlers that apply to the given member based on all policies in the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicySet" />.
	/// </summary>
	/// <param name="member">Member to get handlers for.</param>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to use when creating handlers,
	/// if necessary.</param>
	/// <returns>Collection of call handlers for <paramref name="member" />.</returns>
	public IEnumerable<ICallHandler> GetHandlersFor(MethodImplementationInfo member, IUnityContainer container)
	{
		return new List<ICallHandler>(CalculateHandlersFor(this, member, container));
	}

	internal static IEnumerable<ICallHandler> CalculateHandlersFor(IEnumerable<InjectionPolicy> policies, MethodImplementationInfo member, IUnityContainer container)
	{
		List<ICallHandler> list = new List<ICallHandler>();
		List<ICallHandler> list2 = new List<ICallHandler>();
		foreach (InjectionPolicy policy in policies)
		{
			foreach (ICallHandler item in policy.GetHandlersFor(member, container))
			{
				if (item.Order != 0)
				{
					bool flag = false;
					for (int num = list.Count - 1; num >= 0; num--)
					{
						if (list[num].Order <= item.Order)
						{
							list.Insert(num + 1, item);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Insert(0, item);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
		}
		list.AddRange(list2);
		return list;
	}
}

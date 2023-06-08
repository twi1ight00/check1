using System.Collections.Generic;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.InjectionPolicy" /> class that reads and constructs handlers
/// based on <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerAttribute" /> on the target.
/// </summary>
public class AttributeDrivenPolicy : InjectionPolicy
{
	private readonly AttributeDrivenPolicyMatchingRule attributeMatchRule;

	/// <summary>
	/// Constructs a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.AttributeDrivenPolicy" />.
	/// </summary>
	public AttributeDrivenPolicy()
		: base("Attribute Driven Policy")
	{
		attributeMatchRule = new AttributeDrivenPolicyMatchingRule();
	}

	/// <summary>
	/// Derived classes implement this method to calculate if the policy
	/// will provide any handler to the specified member.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>true if policy applies to this member, false if not.</returns>
	protected override bool DoesMatch(MethodImplementationInfo member)
	{
		bool flag = member.InterfaceMethodInfo != null && attributeMatchRule.Matches(member.InterfaceMethodInfo);
		bool flag2 = attributeMatchRule.Matches(member.ImplementationMethodInfo);
		return flag || flag2;
	}

	/// <summary>
	/// Derived classes implement this method to supply the list of handlers for
	/// this specific member.
	/// </summary>
	/// <param name="member">Member to get handlers for.</param>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to use when creating handlers,
	/// if necessary.</param>
	/// <returns>Enumerable collection of handlers for this method.</returns>
	protected override IEnumerable<ICallHandler> DoGetHandlersFor(MethodImplementationInfo member, IUnityContainer container)
	{
		if (member.InterfaceMethodInfo != null)
		{
			try
			{
				HandlerAttribute[] allAttributes = ReflectionHelper.GetAllAttributes<HandlerAttribute>(member.InterfaceMethodInfo, inherits: true);
				foreach (HandlerAttribute attr2 in allAttributes)
				{
					yield return attr2.CreateHandler(container);
				}
			}
			finally
			{
			}
		}
		try
		{
			HandlerAttribute[] allAttributes2 = ReflectionHelper.GetAllAttributes<HandlerAttribute>(member.ImplementationMethodInfo, inherits: true);
			foreach (HandlerAttribute attr in allAttributes2)
			{
				yield return attr.CreateHandler(container);
			}
		}
		finally
		{
		}
	}
}

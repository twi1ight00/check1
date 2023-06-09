using System.Collections.Generic;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A policy is a combination of a matching rule set and a set of handlers.
/// If the policy applies to a member, then the handlers will be enabled for
/// that member.
/// </summary>
public class RuleDrivenPolicy : InjectionPolicy
{
	private readonly MatchingRuleSet ruleSet;

	private readonly IEnumerable<string> callHandlerNames;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.RuleDrivenPolicy" /> object with a set of matching rules
	/// and the names to use when resolving handlers.
	/// </summary>
	public RuleDrivenPolicy(IMatchingRule[] matchingRules, string[] callHandlerNames)
		: this("Unnamed policy", matchingRules, callHandlerNames)
	{
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.RuleDrivenPolicy" /> object with a name, a set of matching rules
	/// and the names to use when resolving handlers.
	/// </summary>
	public RuleDrivenPolicy(string name, IMatchingRule[] matchingRules, string[] callHandlerNames)
		: base(name)
	{
		ruleSet = new MatchingRuleSet();
		ruleSet.AddRange(matchingRules);
		this.callHandlerNames = callHandlerNames;
	}

	/// <summary>
	/// Checks if the rules in this policy match the given member info.
	/// </summary>
	/// <param name="member">MemberInfo to check against.</param>
	/// <returns>true if ruleset matches, false if it does not.</returns>
	protected override bool DoesMatch(MethodImplementationInfo member)
	{
		bool flag = member.InterfaceMethodInfo != null && ruleSet.Matches(member.InterfaceMethodInfo);
		bool flag2 = ruleSet.Matches(member.ImplementationMethodInfo);
		return flag || flag2;
	}

	/// <summary>
	/// Return ordered collection of handlers in order that apply to the given member.
	/// </summary>
	/// <param name="member">Member that may or may not be assigned handlers by this policy.</param>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to use when creating handlers,
	/// if necessary.</param>
	/// <returns>Collection of handlers (possibly empty) that apply to this member.</returns>
	protected override IEnumerable<ICallHandler> DoGetHandlersFor(MethodImplementationInfo member, IUnityContainer container)
	{
		if (!Matches(member))
		{
			yield break;
		}
		foreach (string callHandlerName in callHandlerNames)
		{
			yield return container.Resolve<ICallHandler>(callHandlerName, new ResolverOverride[0]);
		}
	}
}

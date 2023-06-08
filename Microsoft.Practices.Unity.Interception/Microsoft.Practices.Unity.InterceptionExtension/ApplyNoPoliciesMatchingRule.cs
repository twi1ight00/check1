using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> implementation that fails to match
/// if the method in question has the ApplyNoPolicies attribute on it.
/// </summary>
internal class ApplyNoPoliciesMatchingRule : IMatchingRule
{
	/// <summary>
	/// Check if the <paramref name="member" /> matches this rule.
	/// </summary>
	/// <remarks>This rule returns true if the member does NOT have the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ApplyNoPoliciesAttribute" />
	/// on it, or a containing type doesn't have the attribute.</remarks>
	/// <param name="member">Member to check.</param>
	/// <returns>True if the rule matches, false if it doesn't.</returns>
	public bool Matches(MethodBase member)
	{
		Guard.ArgumentNotNull(member, "member");
		bool flag = member.GetCustomAttributes(typeof(ApplyNoPoliciesAttribute), inherit: false).Length != 0;
		flag |= member.DeclaringType.GetCustomAttributes(typeof(ApplyNoPoliciesAttribute), inherit: false).Length != 0;
		return !flag;
	}
}

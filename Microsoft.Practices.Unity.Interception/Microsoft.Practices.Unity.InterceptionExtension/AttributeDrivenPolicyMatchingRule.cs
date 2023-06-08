using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that checks to see if the
/// member (or type containing that member) have any <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerAttribute" />s.
/// </summary>
public class AttributeDrivenPolicyMatchingRule : IMatchingRule
{
	/// <summary>
	/// Checks to see if <paramref name="member" /> matches the rule.
	/// </summary>
	/// <remarks>Returns true if any <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerAttribute" />s are present on the method
	/// or the type containing that method.</remarks>
	/// <param name="member">Member to check.</param>
	/// <returns>true if member matches, false if not.</returns>
	public bool Matches(MethodBase member)
	{
		return ReflectionHelper.GetAllAttributes<HandlerAttribute>(member, inherits: true).Length > 0;
	}
}

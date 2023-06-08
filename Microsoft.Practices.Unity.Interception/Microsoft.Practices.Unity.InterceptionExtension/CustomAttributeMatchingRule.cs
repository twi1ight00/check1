using System;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that checks to see if
/// the member tested has an arbitrary attribute applied.
/// </summary>
public class CustomAttributeMatchingRule : IMatchingRule
{
	private readonly Type attributeType;

	private readonly bool inherited;

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.CustomAttributeMatchingRule" />.
	/// </summary>
	/// <param name="attributeType">Attribute to match.</param>
	/// <param name="inherited">If true, checks the base class for attributes as well.</param>
	public CustomAttributeMatchingRule(Type attributeType, bool inherited)
	{
		Guard.ArgumentNotNull(attributeType, "attributeType");
		if (!attributeType.IsSubclassOf(typeof(Attribute)))
		{
			throw new ArgumentException(Resources.ExceptionAttributeNoSubclassOfAttribute, "attributeType");
		}
		this.attributeType = attributeType;
		this.inherited = inherited;
	}

	/// <summary>
	/// Checks to see if the given <paramref name="member" /> matches the rule.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>true if it matches, false if not.</returns>
	public bool Matches(MethodBase member)
	{
		Guard.ArgumentNotNull(member, "member");
		object[] customAttributes = member.GetCustomAttributes(attributeType, inherited);
		if (customAttributes != null)
		{
			return customAttributes.Length > 0;
		}
		return false;
	}
}

using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> implementation that matches properties
/// by name. You can match the getter, setter, or both.
/// </summary>
public class PropertyMatchingRule : IMatchingRule
{
	private readonly List<Glob> patterns = new List<Glob>();

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingRule" /> that matches the
	/// getter or setter of the given property.
	/// </summary>
	/// <param name="propertyName">Name of the property. Name comparison is case sensitive. Wildcards are allowed.</param>
	public PropertyMatchingRule(string propertyName)
		: this(propertyName, PropertyMatchingOption.GetOrSet, ignoreCase: false)
	{
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingRule" /> that matches the
	/// given method of the given property.
	/// </summary>
	/// <param name="propertyName">Name of the property. Name comparison is case sensitive. Wildcards are allowed.</param>
	/// <param name="option">Match the getter, setter, or both.</param>
	public PropertyMatchingRule(string propertyName, PropertyMatchingOption option)
		: this(propertyName, option, ignoreCase: false)
	{
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingRule" /> that matches the
	/// given method of the given property.
	/// </summary>
	/// <param name="propertyName">Name of the property to match. Wildcards are allowed.</param>
	/// <param name="option">Match the getter, setter, or both.</param>
	/// <param name="ignoreCase">If false, name comparison is case sensitive. If true, name comparison is case insensitive.</param>
	public PropertyMatchingRule(string propertyName, PropertyMatchingOption option, bool ignoreCase)
		: this(new PropertyMatchingInfo[1]
		{
			new PropertyMatchingInfo(propertyName, option, ignoreCase)
		})
	{
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingRule" /> that matches any of the
	/// given properties.
	/// </summary>
	/// <param name="matches">Collection of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingInfo" /> defining which
	/// properties to match.</param>
	public PropertyMatchingRule(IEnumerable<PropertyMatchingInfo> matches)
	{
		foreach (PropertyMatchingInfo match in matches)
		{
			if (match.Option != PropertyMatchingOption.Set)
			{
				patterns.Add(new Glob("get_" + match.Match, !match.IgnoreCase));
			}
			if (match.Option != 0)
			{
				patterns.Add(new Glob("set_" + match.Match, !match.IgnoreCase));
			}
		}
	}

	/// <summary>
	/// Checks if the given member matches the rule.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>True if it matches, false if it does not.</returns>
	public bool Matches(MethodBase member)
	{
		if (member.IsSpecialName)
		{
			return patterns.Exists((Glob pattern) => pattern.IsMatch(member.Name));
		}
		return false;
	}
}

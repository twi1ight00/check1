using System;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that checks a member for the presence
/// of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TagAttribute" /> on the method, property, or class, and
/// that the given string matches.
/// </summary>
public class TagAttributeMatchingRule : IMatchingRule
{
	private readonly string tagToMatch;

	private readonly bool ignoreCase;

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TagAttributeMatchingRule" />, looking for
	/// the given string. The comparison is case sensitive.
	/// </summary>
	/// <param name="tagToMatch">tag string to match.</param>
	public TagAttributeMatchingRule(string tagToMatch)
		: this(tagToMatch, ignoreCase: false)
	{
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TagAttributeMatchingRule" />, looking for
	/// the given string. The comparison is case sensitive if <paramref name="ignoreCase" /> is
	/// false, case insensitive if <paramref name="ignoreCase" /> is true.
	/// </summary>
	/// <param name="tagToMatch">tag string to match.</param>
	/// <param name="ignoreCase">if false, case-sensitive comparison. If true, case-insensitive comparison.</param>
	public TagAttributeMatchingRule(string tagToMatch, bool ignoreCase)
	{
		this.tagToMatch = tagToMatch;
		this.ignoreCase = ignoreCase;
	}

	/// <summary>
	/// Check the given member for the presence of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TagAttribute" /> and
	/// match the strings.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>True if tag strings match, false if they don't.</returns>
	public bool Matches(MethodBase member)
	{
		TagAttribute[] allAttributes = ReflectionHelper.GetAllAttributes<TagAttribute>(member, inherits: true);
		foreach (TagAttribute tagAttribute in allAttributes)
		{
			if (string.Compare(tagAttribute.Tag, tagToMatch, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) == 0)
			{
				return true;
			}
		}
		return false;
	}
}

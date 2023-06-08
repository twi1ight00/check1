using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A matching rule that matches when the given member name is
/// the same as the one supplied in the constructor.
/// </summary>
public class MemberNameMatchingRule : IMatchingRule
{
	private readonly List<Glob> patterns;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MemberNameMatchingRule" /> that matches the
	/// given member name. Wildcards are allowed.
	/// </summary>
	/// <param name="nameToMatch">Name to match against. Comparison is case sensitive.</param>
	public MemberNameMatchingRule(string nameToMatch)
		: this(nameToMatch, ignoreCase: false)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MemberNameMatchingRule" /> that matches the
	/// given member name. Wildcards are allowed.
	/// </summary>
	/// <param name="nameToMatch">Name to match against.</param>
	/// <param name="ignoreCase">If false, name comparisons are case sensitive. If true, name comparisons are case insensitive.</param>
	public MemberNameMatchingRule(string nameToMatch, bool ignoreCase)
	{
		patterns = new List<Glob>();
		patterns.Add(new Glob(nameToMatch, !ignoreCase));
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MemberNameMatchingRule" /> that matches the
	/// given member names. Wildcards are allowed.
	/// </summary>
	/// <param name="namesToMatch">collections of names to match. If any of these patterns match, the rule matches. Comparisons are case sensitive.</param>
	public MemberNameMatchingRule(IEnumerable<string> namesToMatch)
		: this(namesToMatch, ignoreCase: false)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MemberNameMatchingRule" /> that matches the
	/// given member names. Wildcards are allowed.
	/// </summary>
	/// <param name="namesToMatch">Collections of names to match. If any of these patterns match, the rule matches. </param>
	/// <param name="ignoreCase">If false, name comparisons are case sensitive. If true, name comparisons are case insensitive.</param>
	public MemberNameMatchingRule(IEnumerable<string> namesToMatch, bool ignoreCase)
	{
		patterns = new List<Glob>();
		foreach (string item in namesToMatch)
		{
			patterns.Add(new Glob(item, !ignoreCase));
		}
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MemberNameMatchingRule" /> that matches
	/// one of the given member names. Wildcards are allowed.
	/// </summary>
	/// <param name="matches">List of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MatchingInfo" /> objects containing
	/// the pattern to match and case sensitivity flag.</param>
	public MemberNameMatchingRule(IEnumerable<MatchingInfo> matches)
	{
		patterns = new List<Glob>();
		foreach (MatchingInfo match in matches)
		{
			patterns.Add(new Glob(match.Match, !match.IgnoreCase));
		}
	}

	/// <summary>
	/// Check if the given <paramref name="member" /> matches one of this
	/// object's matching patterns.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>True if matches, false if not.</returns>
	public bool Matches(MethodBase member)
	{
		return patterns.Exists((Glob pattern) => pattern.IsMatch(member.Name));
	}
}

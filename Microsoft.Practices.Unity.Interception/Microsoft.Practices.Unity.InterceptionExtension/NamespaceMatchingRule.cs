using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that matches members in a given namespace. You can
/// specify either a single namespace (e.g. <c>System.Data</c>) or a namespace root
/// (e.g. <c>System.Data.*</c> to match types in that namespace or below.
/// </summary>
public class NamespaceMatchingRule : IMatchingRule
{
	/// <summary>
	/// A helper class that encapsulates the name to match, case sensitivity flag,
	/// and the wildcard rules for matching namespaces.
	/// </summary>
	private class NamespaceMatchingInfo : MatchingInfo
	{
		private const string wildCardString = ".*";

		private bool wildCard;

		private string NamespaceName
		{
			get
			{
				return base.Match;
			}
			set
			{
				base.Match = value;
			}
		}

		/// <summary>
		/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.NamespaceMatchingRule.NamespaceMatchingInfo" /> that matches the
		/// given namespace name.
		/// </summary>
		/// <param name="match">Namespace name to match.</param>
		/// <param name="ignoreCase">If false, comparison is case sensitive. If true, comparison is case insensitive.</param>
		public NamespaceMatchingInfo(string match, bool ignoreCase)
			: base(match, ignoreCase)
		{
			if (NamespaceName.EndsWith(".*", StringComparison.Ordinal))
			{
				NamespaceName = NamespaceName.Substring(0, NamespaceName.Length - ".*".Length);
				wildCard = true;
			}
		}

		/// <summary>
		/// Check if the given type <paramref name="t" /> is in a matching namespace.
		/// </summary>
		/// <param name="t">Type to check.</param>
		/// <returns>True if type is in a matching namespace, false if not.</returns>
		public bool Matches(Type t)
		{
			if (t == null)
			{
				return string.IsNullOrEmpty(NamespaceName);
			}
			StringComparison comparisonType = (base.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			bool flag = string.Compare(t.Namespace, NamespaceName, comparisonType) == 0;
			if (wildCard)
			{
				if (!flag)
				{
					return t.Namespace.StartsWith(NamespaceName + ".", comparisonType);
				}
				return true;
			}
			return flag;
		}
	}

	private readonly List<NamespaceMatchingInfo> matches;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.NamespaceMatchingRule" /> that matches the given
	/// namespace.
	/// </summary>
	/// <param name="namespaceName">namespace name to match. Comparison is case sensitive.</param>
	public NamespaceMatchingRule(string namespaceName)
		: this(namespaceName, ignoreCase: false)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.NamespaceMatchingRule" /> that matches the given
	/// namespace.
	/// </summary>
	/// <param name="namespaceName">namespace name to match.</param>
	/// <param name="ignoreCase">If false, comparison is case sensitive. If true, comparison is case insensitive.</param>
	public NamespaceMatchingRule(string namespaceName, bool ignoreCase)
		: this(new MatchingInfo[1]
		{
			new MatchingInfo(namespaceName, ignoreCase)
		})
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.NamespaceMatchingRule" /> that matches any of
	/// the given namespace names.
	/// </summary>
	/// <param name="matches">Collection of namespace names to match.</param>
	public NamespaceMatchingRule(IEnumerable<MatchingInfo> matches)
	{
		this.matches = new List<NamespaceMatchingInfo>();
		foreach (MatchingInfo match in matches)
		{
			this.matches.Add(new NamespaceMatchingInfo(match.Match, match.IgnoreCase));
		}
	}

	/// <summary>
	/// Check to see if the given <paramref name="member" /> is in a namespace
	/// matched by any of our given namespace names.
	/// </summary>
	/// <param name="member">member to check.</param>
	/// <returns>True if member is contained in a matching namespace, false if not.</returns>
	public bool Matches(MethodBase member)
	{
		return matches.Exists((NamespaceMatchingInfo match) => match.Matches(member.DeclaringType));
	}
}

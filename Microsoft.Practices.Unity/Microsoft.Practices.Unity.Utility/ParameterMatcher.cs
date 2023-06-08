using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Practices.Unity.Utility;

/// <summary>
/// A utility class that handles the logic of matching parameter
/// lists, so we can find the right constructor and method overloads.
/// </summary>
public class ParameterMatcher
{
	private readonly List<InjectionParameterValue> parametersToMatch;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.Utility.ParameterMatcher" /> that will attempt to
	/// match the given parameter types.
	/// </summary>
	/// <param name="parametersToMatch">Target parameters to match against.</param>
	public ParameterMatcher(IEnumerable<InjectionParameterValue> parametersToMatch)
	{
		this.parametersToMatch = new List<InjectionParameterValue>(parametersToMatch);
	}

	/// <summary>
	/// Tests to see if the given set of types matches the ones
	/// we're looking for.
	/// </summary>
	/// <param name="candidate">parameter list to look for.</param>
	/// <returns>true if they match, false if they don't.</returns>
	public virtual bool Matches(IEnumerable<Type> candidate)
	{
		List<Type> list = new List<Type>(candidate);
		if (parametersToMatch.Count == list.Count)
		{
			for (int i = 0; i < parametersToMatch.Count; i++)
			{
				if (!parametersToMatch[i].MatchesType(list[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// Tests to see if the given set of types matches the ones we're looking for.
	/// </summary>
	/// <param name="candidate">Candidate method signature to look for.</param>
	/// <returns>True if they match, false if they don't.</returns>
	public virtual bool Matches(IEnumerable<ParameterInfo> candidate)
	{
		return Matches(candidate.Select((ParameterInfo pi) => pi.ParameterType));
	}
}

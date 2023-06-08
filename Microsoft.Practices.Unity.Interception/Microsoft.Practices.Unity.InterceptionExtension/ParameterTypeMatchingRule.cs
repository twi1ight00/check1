using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that matches methods that have any parameters
/// of the given types.
/// </summary>
public class ParameterTypeMatchingRule : IMatchingRule
{
	private readonly List<ParameterTypeMatchingInfo> matches;

	/// <summary>
	/// The list of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingInfo" /> describing the parameter types to match.
	/// </summary>
	/// <value>The collection of matches.</value>
	public IEnumerable<ParameterTypeMatchingInfo> ParameterMatches => matches;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingRule" /> that matches if any of
	/// the method parameters match ones in the given collection.
	/// </summary>
	/// <param name="matches">Collection of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingInfo" /> that
	/// describes the types to match.</param>
	public ParameterTypeMatchingRule(IEnumerable<ParameterTypeMatchingInfo> matches)
	{
		this.matches = new List<ParameterTypeMatchingInfo>(matches);
	}

	/// <summary>
	/// Check the given member to see if it has any matching parameters.
	/// </summary>
	/// <param name="member">Member to match.</param>
	/// <returns>true if member matches, false if it doesn't.</returns>
	public bool Matches(MethodBase member)
	{
		ParameterInfo[] parameters = member.GetParameters();
		foreach (ParameterTypeMatchingInfo match in matches)
		{
			TypeMatchingRule typeMatchingRule = new TypeMatchingRule(match.Match, match.IgnoreCase);
			ParameterInfo[] array = parameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				if (!parameterInfo.IsOut && !parameterInfo.IsReturn() && (match.Kind == ParameterKind.Input || match.Kind == ParameterKind.InputOrOutput) && typeMatchingRule.Matches(parameterInfo.ParameterType))
				{
					return true;
				}
				if (parameterInfo.IsOut && (match.Kind == ParameterKind.Output || match.Kind == ParameterKind.InputOrOutput) && typeMatchingRule.Matches(parameterInfo.ParameterType.GetElementType()))
				{
					return true;
				}
				if (parameterInfo.IsReturn() && match.Kind == ParameterKind.ReturnValue && typeMatchingRule.Matches(parameterInfo.ParameterType))
				{
					return true;
				}
			}
			if (match.Kind == ParameterKind.ReturnValue && member is MethodInfo methodInfo && typeMatchingRule.Matches(methodInfo.ReturnType))
			{
				return true;
			}
		}
		return false;
	}
}

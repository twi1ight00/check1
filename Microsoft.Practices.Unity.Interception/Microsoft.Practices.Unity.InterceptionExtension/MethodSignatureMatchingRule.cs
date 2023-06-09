using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Match methods with the given names and method signature.
/// </summary>
public class MethodSignatureMatchingRule : IMatchingRule
{
	private readonly Glob methodNamePattern;

	private readonly List<TypeMatchingRule> parameterRules;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MethodSignatureMatchingRule" /> that matches methods
	/// with the given name, with parameter types matching the given list.
	/// </summary>
	/// <param name="methodName">Method name to match. Wildcards are allowed.</param>
	/// <param name="parameterTypeNames">Parameter type names to match, in order. Wildcards are allowed.</param>
	/// <param name="ignoreCase">If false, name comparisons are case sensitive. If true, name comparisons are case insensitive.</param>
	public MethodSignatureMatchingRule(string methodName, IEnumerable<string> parameterTypeNames, bool ignoreCase)
	{
		methodNamePattern = new Glob(methodName, !ignoreCase);
		parameterRules = new List<TypeMatchingRule>();
		foreach (string parameterTypeName in parameterTypeNames)
		{
			parameterRules.Add(new TypeMatchingRule(parameterTypeName, ignoreCase));
		}
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MethodSignatureMatchingRule" /> that matches methods
	/// with the given name, with parameter types matching the given list.
	/// </summary>
	/// <remarks>Name comparisons are case sensitive.</remarks>
	/// <param name="methodName">Method name to match. Wildcards are allowed.</param>
	/// <param name="parameterTypeNames">Parameter type names to match, in order. Wildcards are allowed.</param>
	public MethodSignatureMatchingRule(string methodName, IEnumerable<string> parameterTypeNames)
		: this(methodName, parameterTypeNames, ignoreCase: false)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MethodSignatureMatchingRule" /> that matches any method
	/// with parameter types matching the given list.
	/// </summary>
	/// <remarks>Name comparisons are case sensitive.</remarks>
	/// <param name="parameterTypeNames">Parameter type names to match, in order. Wildcards are allowed.</param>
	public MethodSignatureMatchingRule(IEnumerable<string> parameterTypeNames)
		: this("*", parameterTypeNames, ignoreCase: false)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MethodSignatureMatchingRule" /> that matches any method
	/// with parameter types matching the given list.
	/// </summary>
	/// <param name="parameterTypeNames">Parameter type names to match, in order. Wildcards are allowed.</param>
	/// <param name="ignoreCase">If false, name comparisons are case sensitive. If true, name comparisons are case insensitive.</param>
	public MethodSignatureMatchingRule(IEnumerable<string> parameterTypeNames, bool ignoreCase)
		: this("*", parameterTypeNames, ignoreCase)
	{
	}

	/// <summary>
	/// Check to see if the given method matches the name and signature.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>True if match, false if not.</returns>
	public bool Matches(MethodBase member)
	{
		if (!methodNamePattern.IsMatch(member.Name))
		{
			return false;
		}
		ParameterInfo[] parameters = member.GetParameters();
		if (parameters.Length != parameterRules.Count)
		{
			return false;
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			if (!parameterRules[i].Matches(parameters[i].ParameterType))
			{
				return false;
			}
		}
		return true;
	}
}

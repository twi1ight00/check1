using System;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that checks to see if a member has a specified
/// type.
/// </summary>
public class ReturnTypeMatchingRule : IMatchingRule
{
	private readonly TypeMatchingRule typeMatchingRule;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ReturnTypeMatchingRule" /> that matches
	/// members with the given return type.
	/// </summary>
	/// <param name="returnType">Type to look for.</param>
	public ReturnTypeMatchingRule(Type returnType)
	{
		if (returnType == null)
		{
			throw new ArgumentNullException("returnType");
		}
		typeMatchingRule = new TypeMatchingRule(returnType.FullName);
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ReturnTypeMatchingRule" /> that matches
	/// the given return type by name.
	/// </summary>
	/// <remarks>See the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TypeMatchingRule" /> class for details on how
	/// type name matches are done.</remarks>
	/// <param name="returnTypeName">Type name to match. Name comparisons are case sensitive.</param>
	public ReturnTypeMatchingRule(string returnTypeName)
	{
		typeMatchingRule = new TypeMatchingRule(returnTypeName);
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ReturnTypeMatchingRule" /> that matches
	/// the given return type by name.
	/// </summary>
	/// <remarks>See the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TypeMatchingRule" /> class for details on how
	/// type name matches are done.</remarks>
	/// <param name="returnTypeName">Type name to match.</param>
	/// <param name="ignoreCase">If false, name comparison is case sensitive. If true, comparison
	/// is case insensitive.</param>
	public ReturnTypeMatchingRule(string returnTypeName, bool ignoreCase)
	{
		typeMatchingRule = new TypeMatchingRule(returnTypeName, ignoreCase);
	}

	/// <summary>
	/// Check to see if the given member has a matching return type.
	/// </summary>
	/// <param name="member">Member to check.</param>
	/// <returns>true if return types match, false if they don't.</returns>
	public bool Matches(MethodBase member)
	{
		if (!(member is MethodInfo methodInfo))
		{
			return false;
		}
		return typeMatchingRule.Matches(methodInfo.ReturnType);
	}
}

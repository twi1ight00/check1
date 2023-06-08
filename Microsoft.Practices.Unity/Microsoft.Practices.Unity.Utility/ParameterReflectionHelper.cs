using System;
using System.Reflection;

namespace Microsoft.Practices.Unity.Utility;

/// <summary>
/// Another reflection helper class that has extra methods
/// for dealing with ParameterInfos.
/// </summary>
public class ParameterReflectionHelper : ReflectionHelper
{
	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.Utility.ParameterReflectionHelper" /> that
	/// lets you query information about the given ParameterInfo object.
	/// </summary>
	/// <param name="parameter">Parameter to query.</param>
	public ParameterReflectionHelper(ParameterInfo parameter)
		: base(TypeFromParameterInfo(parameter))
	{
	}

	private static Type TypeFromParameterInfo(ParameterInfo parameter)
	{
		Guard.ArgumentNotNull(parameter, "parameter");
		return parameter.ParameterType;
	}
}

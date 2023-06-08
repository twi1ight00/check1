using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Practices.Unity.Utility;

/// <summary>
/// Helper class to wrap common reflection stuff dealing with
/// methods.
/// </summary>
public class MethodReflectionHelper
{
	private readonly MethodBase method;

	/// <summary>
	/// Returns true if any of the parameters of this method
	/// are open generics.
	/// </summary>
	public bool MethodHasOpenGenericParameters => GetParameterReflectors().Any((ParameterReflectionHelper r) => r.IsOpenGeneric);

	/// <summary>
	/// Return the <see cref="T:System.Type" /> of each parameter for this
	/// method.
	/// </summary>
	/// <returns>Sequence of <see cref="T:System.Type" /> objects, one for
	/// each parameter in order.</returns>
	public IEnumerable<Type> ParameterTypes
	{
		get
		{
			try
			{
				ParameterInfo[] parameters = method.GetParameters();
				foreach (ParameterInfo param in parameters)
				{
					yield return param.ParameterType;
				}
			}
			finally
			{
			}
		}
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.Utility.MethodReflectionHelper" /> instance that
	/// lets us do more reflection stuff on that method.
	/// </summary>
	/// <param name="method">The method to reflect on.</param>
	public MethodReflectionHelper(MethodBase method)
	{
		this.method = method;
	}

	/// <summary>
	/// Given our set of generic type arguments, 
	/// </summary>
	/// <param name="genericTypeArguments">The generic type arguments.</param>
	/// <returns>An array with closed parameter types. </returns>
	public Type[] GetClosedParameterTypes(Type[] genericTypeArguments)
	{
		return GetClosedParameterTypesSequence(genericTypeArguments).ToArray();
	}

	private IEnumerable<ParameterReflectionHelper> GetParameterReflectors()
	{
		try
		{
			ParameterInfo[] parameters = method.GetParameters();
			foreach (ParameterInfo pi in parameters)
			{
				yield return new ParameterReflectionHelper(pi);
			}
		}
		finally
		{
		}
	}

	private IEnumerable<Type> GetClosedParameterTypesSequence(Type[] genericTypeArguments)
	{
		foreach (ParameterReflectionHelper r in GetParameterReflectors())
		{
			yield return r.GetClosedParameterType(genericTypeArguments);
		}
	}
}

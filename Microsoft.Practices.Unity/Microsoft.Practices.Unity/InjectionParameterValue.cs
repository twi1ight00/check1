using System;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Base type for objects that are used to configure parameters for
/// constructor or method injection, or for getting the value to
/// be injected into a property.
/// </summary>
public abstract class InjectionParameterValue
{
	/// <summary>
	/// Name for the type represented by this <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" />.
	/// This may be an actual type name or a generic argument name.
	/// </summary>
	public abstract string ParameterTypeName { get; }

	/// <summary>
	/// Test to see if this parameter value has a matching type for the given type.
	/// </summary>
	/// <param name="t">Type to check.</param>
	/// <returns>True if this parameter value is compatible with type <paramref name="t" />,
	/// false if not.</returns>
	public abstract bool MatchesType(Type t);

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance that will
	/// return this types value for the parameter.
	/// </summary>
	/// <param name="typeToBuild">Type that contains the member that needs this parameter. Used
	/// to resolve open generic parameters.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />.</returns>
	public abstract IDependencyResolverPolicy GetResolverPolicy(Type typeToBuild);

	/// <summary>
	/// Convert the given set of arbitrary values to a sequence of InjectionParameterValue
	/// objects. The rules are: If it's already an InjectionParameterValue, return it. If
	/// it's a Type, return a ResolvedParameter object for that type. Otherwise return
	/// an InjectionParameter object for that value.
	/// </summary>
	/// <param name="values">The values to build the sequence from.</param>
	/// <returns>The resulting converted sequence.</returns>
	public static IEnumerable<InjectionParameterValue> ToParameters(params object[] values)
	{
		try
		{
			foreach (object value in values)
			{
				yield return ToParameter(value);
			}
		}
		finally
		{
		}
	}

	/// <summary>
	/// Convert an arbitrary value to an InjectionParameterValue object. The rules are: 
	/// If it's already an InjectionParameterValue, return it. If it's a Type, return a
	/// ResolvedParameter object for that type. Otherwise return an InjectionParameter
	/// object for that value.
	/// </summary>
	/// <param name="value">The value to convert.</param>
	/// <returns>The resulting <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" />.</returns>
	public static InjectionParameterValue ToParameter(object value)
	{
		if (value is InjectionParameterValue result)
		{
			return result;
		}
		if (value is Type parameterType)
		{
			return new ResolvedParameter(parameterType);
		}
		return new InjectionParameter(value);
	}
}

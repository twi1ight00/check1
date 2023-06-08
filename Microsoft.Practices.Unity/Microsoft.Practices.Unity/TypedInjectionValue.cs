using System;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A base class for implementing <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> classes
/// that deal in explicit types.
/// </summary>
public abstract class TypedInjectionValue : InjectionParameterValue
{
	private readonly ReflectionHelper parameterReflector;

	/// <summary>
	/// The type of parameter this object represents.
	/// </summary>
	public virtual Type ParameterType => parameterReflector.Type;

	/// <summary>
	/// Name for the type represented by this <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" />.
	/// This may be an actual type name or a generic argument name.
	/// </summary>
	public override string ParameterTypeName => parameterReflector.Type.Name;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.TypedInjectionValue" /> that exposes
	/// information about the given <paramref name="parameterType" />.
	/// </summary>
	/// <param name="parameterType">Type of the parameter.</param>
	protected TypedInjectionValue(Type parameterType)
	{
		parameterReflector = new ReflectionHelper(parameterType);
	}

	/// <summary>
	/// Test to see if this parameter value has a matching type for the given type.
	/// </summary>
	/// <param name="t">Type to check.</param>
	/// <returns>True if this parameter value is compatible with type <paramref name="t" />,
	/// false if not.</returns>
	public override bool MatchesType(Type t)
	{
		Guard.ArgumentNotNull(t, "t");
		ReflectionHelper reflectionHelper = new ReflectionHelper(t);
		if (reflectionHelper.IsOpenGeneric && parameterReflector.IsOpenGeneric)
		{
			return reflectionHelper.Type.GetGenericTypeDefinition() == parameterReflector.Type.GetGenericTypeDefinition();
		}
		return t.IsAssignableFrom(parameterReflector.Type);
	}
}

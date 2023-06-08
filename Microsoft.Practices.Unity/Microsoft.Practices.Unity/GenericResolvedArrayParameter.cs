using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> that lets you specify that
/// an array containing the registered instances of a generic type parameter 
/// should be resolved.
/// </summary>
public class GenericResolvedArrayParameter : InjectionParameterValue
{
	private readonly string genericParameterName;

	private readonly List<InjectionParameterValue> elementValues = new List<InjectionParameterValue>();

	/// <summary>
	/// Name for the type represented by this <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" />.
	/// This may be an actual type name or a generic argument name.
	/// </summary>
	public override string ParameterTypeName => genericParameterName + "[]";

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.GenericResolvedArrayParameter" /> instance that specifies
	/// that the given named generic parameter should be resolved.
	/// </summary>
	/// <param name="genericParameterName">The generic parameter name to resolve.</param>
	/// <param name="elementValues">The values for the elements, that will
	/// be converted to <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> objects.</param>
	public GenericResolvedArrayParameter(string genericParameterName, params object[] elementValues)
	{
		Guard.ArgumentNotNull(genericParameterName, "genericParameterName");
		this.genericParameterName = genericParameterName;
		this.elementValues.AddRange(InjectionParameterValue.ToParameters(elementValues));
	}

	/// <summary>
	/// Test to see if this parameter value has a matching type for the given type.
	/// </summary>
	/// <param name="t">Type to check.</param>
	/// <returns>True if this parameter value is compatible with type <paramref name="t" />,
	/// false if not.</returns>
	/// <remarks>A type is considered compatible if it is an array type of rank one
	/// and its element type is a generic type parameter with a name matching this generic
	/// parameter name configured for the receiver.</remarks>
	public override bool MatchesType(Type t)
	{
		Guard.ArgumentNotNull(t, "t");
		if (!t.IsArray || t.GetArrayRank() != 1)
		{
			return false;
		}
		Type elementType = t.GetElementType();
		if (elementType.IsGenericParameter)
		{
			return elementType.Name == genericParameterName;
		}
		return false;
	}

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance that will
	/// return this types value for the parameter.
	/// </summary>
	/// <param name="typeToBuild">Type that contains the member that needs this parameter. Used
	/// to resolve open generic parameters.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />.</returns>
	public override IDependencyResolverPolicy GetResolverPolicy(Type typeToBuild)
	{
		GuardTypeToBuildIsGeneric(typeToBuild);
		GuardTypeToBuildHasMatchingGenericParameter(typeToBuild);
		Type namedGenericParameter = new ReflectionHelper(typeToBuild).GetNamedGenericParameter(genericParameterName);
		List<IDependencyResolverPolicy> list = new List<IDependencyResolverPolicy>();
		foreach (InjectionParameterValue elementValue in elementValues)
		{
			list.Add(elementValue.GetResolverPolicy(typeToBuild));
		}
		return new ResolvedArrayWithElementsResolverPolicy(namedGenericParameter, list.ToArray());
	}

	private void GuardTypeToBuildIsGeneric(Type typeToBuild)
	{
		if (!typeToBuild.IsGenericType)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NotAGenericType, typeToBuild.Name, genericParameterName));
		}
	}

	private void GuardTypeToBuildHasMatchingGenericParameter(Type typeToBuild)
	{
		Type[] genericArguments = typeToBuild.GetGenericTypeDefinition().GetGenericArguments();
		foreach (Type type in genericArguments)
		{
			if (type.Name == genericParameterName)
			{
				return;
			}
		}
		throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NoMatchingGenericArgument, typeToBuild.Name, genericParameterName));
	}
}

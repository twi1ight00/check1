using System;
using System.Globalization;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Base class for <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> subclasses that let you specify that
/// an instance of a generic type parameter should be resolved.
/// </summary>
public abstract class GenericParameterBase : InjectionParameterValue
{
	private readonly string genericParameterName;

	private readonly bool isArray;

	private readonly string resolutionKey;

	/// <summary>
	/// Name for the type represented by this <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" />.
	/// This may be an actual type name or a generic argument name.
	/// </summary>
	public override string ParameterTypeName => genericParameterName;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.GenericParameter" /> instance that specifies
	/// that the given named generic parameter should be resolved.
	/// </summary>
	/// <param name="genericParameterName">The generic parameter name to resolve.</param>
	protected GenericParameterBase(string genericParameterName)
		: this(genericParameterName, null)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.GenericParameter" /> instance that specifies
	/// that the given named generic parameter should be resolved.
	/// </summary>
	/// <param name="genericParameterName">The generic parameter name to resolve.</param>
	/// <param name="resolutionKey">name to use when looking up in the container.</param>
	protected GenericParameterBase(string genericParameterName, string resolutionKey)
	{
		Guard.ArgumentNotNull(genericParameterName, "genericParameterName");
		if (genericParameterName.EndsWith("[]", StringComparison.Ordinal) || genericParameterName.EndsWith("()", StringComparison.Ordinal))
		{
			this.genericParameterName = genericParameterName.Replace("[]", "").Replace("()", "");
			isArray = true;
		}
		else
		{
			this.genericParameterName = genericParameterName;
			isArray = false;
		}
		this.resolutionKey = resolutionKey;
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
		if (!isArray)
		{
			if (t.IsGenericParameter)
			{
				return t.Name == genericParameterName;
			}
			return false;
		}
		if (t.IsArray && t.GetElementType().IsGenericParameter)
		{
			return t.GetElementType().Name == genericParameterName;
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
		Type type = new ReflectionHelper(typeToBuild).GetNamedGenericParameter(genericParameterName);
		if (isArray)
		{
			type = type.MakeArrayType();
		}
		return DoGetResolverPolicy(type, resolutionKey);
	}

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance that will
	/// return this types value for the parameter.
	/// </summary>
	/// <param name="typeToResolve">The actual type to resolve.</param>
	/// <param name="resolutionKey">The resolution key.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />.</returns>
	protected abstract IDependencyResolverPolicy DoGetResolverPolicy(Type typeToResolve, string resolutionKey);

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

using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A class that stores a name and type, and generates a 
/// resolver object that resolves the parameter via the
/// container.
/// </summary>
public class ResolvedParameter : TypedInjectionValue
{
	private readonly string name;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.ResolvedParameter" /> that
	/// resolves to the given type.
	/// </summary>
	/// <param name="parameterType">Type of this parameter.</param>
	public ResolvedParameter(Type parameterType)
		: this(parameterType, null)
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.ResolvedParameter" /> that
	/// resolves the given type and name.
	/// </summary>
	/// <param name="parameterType">Type of this parameter.</param>
	/// <param name="name">Name to use when resolving parameter.</param>
	public ResolvedParameter(Type parameterType, string name)
		: base(parameterType)
	{
		this.name = name;
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
		Guard.ArgumentNotNull(typeToBuild, "typeToBuild");
		ReflectionHelper reflectionHelper = new ReflectionHelper(ParameterType);
		if (reflectionHelper.IsGenericArray)
		{
			return CreateGenericArrayResolverPolicy(typeToBuild, reflectionHelper);
		}
		if (reflectionHelper.IsOpenGeneric)
		{
			return CreateGenericResolverPolicy(typeToBuild, reflectionHelper);
		}
		return CreateResolverPolicy(reflectionHelper.Type);
	}

	private IDependencyResolverPolicy CreateResolverPolicy(Type typeToResolve)
	{
		return new NamedTypeDependencyResolverPolicy(typeToResolve, name);
	}

	private IDependencyResolverPolicy CreateGenericResolverPolicy(Type typeToBuild, ReflectionHelper parameterReflector)
	{
		return new NamedTypeDependencyResolverPolicy(parameterReflector.GetClosedParameterType(typeToBuild.GetGenericArguments()), name);
	}

	private IDependencyResolverPolicy CreateGenericArrayResolverPolicy(Type typeToBuild, ReflectionHelper parameterReflector)
	{
		Type closedParameterType = parameterReflector.GetClosedParameterType(typeToBuild.GetGenericArguments());
		return new NamedTypeDependencyResolverPolicy(closedParameterType, name);
	}
}
/// <summary>
/// A generic version of <see cref="T:Microsoft.Practices.Unity.ResolvedParameter" /> for convenience
/// when creating them by hand.
/// </summary>
/// <typeparam name="TParameter">Type of the parameter</typeparam>
public class ResolvedParameter<TParameter> : ResolvedParameter
{
	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.ResolvedParameter`1" /> for the given
	/// generic type and the default name.
	/// </summary>
	public ResolvedParameter()
		: base(typeof(TParameter))
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.ResolvedParameter`1" /> for the given
	/// generic type and name.
	/// </summary>
	/// <param name="name">Name to use to resolve this parameter.</param>
	public ResolvedParameter(string name)
		: base(typeof(TParameter), name)
	{
	}
}

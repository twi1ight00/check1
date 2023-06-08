using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> that can be passed to
/// <see cref="M:Microsoft.Practices.Unity.IUnityContainer.RegisterType(System.Type,System.Type,System.String,Microsoft.Practices.Unity.LifetimeManager,Microsoft.Practices.Unity.InjectionMember[])" /> to configure a
/// parameter or property as an optional dependency.
/// </summary>
public class OptionalParameter : TypedInjectionValue
{
	private readonly string name;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.OptionalParameter" /> object that
	/// specifies the given <paramref name="type" />.
	/// </summary>
	/// <param name="type">Type of the dependency.</param>
	public OptionalParameter(Type type)
		: this(type, null)
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.OptionalParameter" /> object that
	/// specifies the given <paramref name="type" /> and <paramref name="name" />.
	/// </summary>
	/// <param name="type">Type of the dependency.</param>
	/// <param name="name">Name for the dependency.</param>
	public OptionalParameter(Type type, string name)
		: base(type)
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
		Type type = reflectionHelper.Type;
		if (reflectionHelper.IsOpenGeneric)
		{
			type = reflectionHelper.GetClosedParameterType(typeToBuild.GetGenericArguments());
		}
		return new OptionalDependencyResolverPolicy(type, name);
	}
}
/// <summary>
/// A generic version of <see cref="T:Microsoft.Practices.Unity.OptionalParameter"></see> that lets you
/// specify the type of the dependency using generics syntax.
/// </summary>
/// <typeparam name="T">Type of the dependency.</typeparam>
public class OptionalParameter<T> : OptionalParameter
{
	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.OptionalParameter`1" />.
	/// </summary>
	public OptionalParameter()
		: base(typeof(T))
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.OptionalParameter`1" /> with the given
	/// <paramref name="name" />.
	/// </summary>
	/// <param name="name">Name of the dependency.</param>
	public OptionalParameter(string name)
		: base(typeof(T), name)
	{
	}
}

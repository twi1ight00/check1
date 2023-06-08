using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> class that overrides
/// the value injected whenever there is a dependency of the
/// given type, regardless of where it appears in the object graph.
/// </summary>
public class DependencyOverride : ResolverOverride
{
	private readonly InjectionParameterValue dependencyValue;

	private readonly Type typeToConstruct;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.DependencyOverride" /> to override
	/// the given type with the given value.
	/// </summary>
	/// <param name="typeToConstruct">Type of the dependency.</param>
	/// <param name="dependencyValue">Value to use.</param>
	public DependencyOverride(Type typeToConstruct, object dependencyValue)
	{
		this.typeToConstruct = typeToConstruct;
		this.dependencyValue = InjectionParameterValue.ToParameter(dependencyValue);
	}

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that can be used to give a value
	/// for the given desired dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="dependencyType">Type of dependency desired.</param>
	/// <returns>a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> object if this override applies, null if not.</returns>
	public override IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
	{
		IDependencyResolverPolicy result = null;
		if (dependencyType == typeToConstruct)
		{
			result = dependencyValue.GetResolverPolicy(dependencyType);
		}
		return result;
	}
}
/// <summary>
/// A convenience version of <see cref="T:Microsoft.Practices.Unity.DependencyOverride" /> that lets you
/// specify the dependency type using generic syntax.
/// </summary>
/// <typeparam name="T">Type of the dependency to override.</typeparam>
public class DependencyOverride<T> : DependencyOverride
{
	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.DependencyOverride`1" /> object that will
	/// override the given dependency, and pass the given value.
	/// </summary>
	public DependencyOverride(object dependencyValue)
		: base(typeof(T), dependencyValue)
	{
	}
}

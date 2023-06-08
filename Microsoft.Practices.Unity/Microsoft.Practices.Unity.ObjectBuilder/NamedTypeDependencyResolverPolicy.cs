using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.ObjectBuilder;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that stores a
/// type and name, and at resolution time puts them together into a
/// <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" />.
/// </summary>
public class NamedTypeDependencyResolverPolicy : IDependencyResolverPolicy, IBuilderPolicy
{
	private Type type;

	private string name;

	/// <summary>
	/// The type that this resolver resolves.
	/// </summary>
	public Type Type => type;

	/// <summary>
	/// The name that this resolver resolves.
	/// </summary>
	public string Name => name;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.ObjectBuilder.NamedTypeDependencyResolverPolicy" />
	/// with the given type and name.
	/// </summary>
	/// <param name="type">The type.</param>
	/// <param name="name">The name (may be null).</param>
	public NamedTypeDependencyResolverPolicy(Type type, string name)
	{
		this.type = type;
		this.name = name;
	}

	/// <summary>
	/// Resolve the value for a dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <returns>The value for the dependency.</returns>
	public object Resolve(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		return context.NewBuildUp(new NamedTypeBuildKey(type, name));
	}
}

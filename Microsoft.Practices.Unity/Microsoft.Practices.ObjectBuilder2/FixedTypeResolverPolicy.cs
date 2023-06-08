using System;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that
/// calls back into the build chain to build up the dependency, passing
/// a type given at compile time as its build key.
/// </summary>
public class FixedTypeResolverPolicy : IDependencyResolverPolicy, IBuilderPolicy
{
	private readonly NamedTypeBuildKey keyToBuild;

	/// <summary>
	/// Create a new instance storing the given type.
	/// </summary>
	/// <param name="typeToBuild">Type to resolve.</param>
	public FixedTypeResolverPolicy(Type typeToBuild)
	{
		keyToBuild = new NamedTypeBuildKey(typeToBuild);
	}

	/// <summary>
	/// Get the value for a dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <returns>The value for the dependency.</returns>
	public object Resolve(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		return context.NewBuildUp(keyToBuild);
	}
}

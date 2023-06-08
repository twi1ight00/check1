using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Base class for all override objects passed in the
/// <see cref="M:Microsoft.Practices.Unity.IUnityContainer.Resolve(System.Type,System.String,Microsoft.Practices.Unity.ResolverOverride[])" /> method.
/// </summary>
public abstract class ResolverOverride
{
	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that can be used to give a value
	/// for the given desired dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="dependencyType">Type of dependency desired.</param>
	/// <returns>a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> object if this override applies, null if not.</returns>
	public abstract IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType);

	/// <summary>
	/// Wrap this resolver in one that verifies the type of the object being built.
	/// This allows you to narrow any override down to a specific type easily.
	/// </summary>
	/// <typeparam name="T">Type to constrain the override to.</typeparam>
	/// <returns>The new override.</returns>
	public ResolverOverride OnType<T>()
	{
		return new TypeBasedOverride<T>(this);
	}

	/// <summary>
	/// Wrap this resolver in one that verifies the type of the object being built.
	/// This allows you to narrow any override down to a specific type easily.
	/// </summary>
	/// <param name="typeToOverride">Type to constrain the override to.</param>
	/// <returns>The new override.</returns>
	public ResolverOverride OnType(Type typeToOverride)
	{
		return new TypeBasedOverride(typeToOverride, this);
	}
}

using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> that
/// acts as a decorator over another <see cref="T:Microsoft.Practices.Unity.ResolverOverride" />.
/// This checks to see if the current type being built is the
/// right one before checking the inner <see cref="T:Microsoft.Practices.Unity.ResolverOverride" />.
/// </summary>
public class TypeBasedOverride : ResolverOverride
{
	private readonly Type targetType;

	private readonly ResolverOverride innerOverride;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.TypeBasedOverride" />
	/// </summary>
	/// <param name="targetType">Type to check for.</param>
	/// <param name="innerOverride">Inner override to check after type matches.</param>
	public TypeBasedOverride(Type targetType, ResolverOverride innerOverride)
	{
		Guard.ArgumentNotNull(targetType, "targetType");
		Guard.ArgumentNotNull(innerOverride, "innerOverride");
		this.targetType = targetType;
		this.innerOverride = innerOverride;
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
		Guard.ArgumentNotNull(context, "context");
		if (context.CurrentOperation is BuildOperation buildOperation && buildOperation.TypeBeingConstructed == targetType)
		{
			return innerOverride.GetResolver(context, dependencyType);
		}
		return null;
	}
}
/// <summary>
/// A convenience version of <see cref="T:Microsoft.Practices.Unity.TypeBasedOverride" /> that lets you
/// specify the type to construct via generics syntax.
/// </summary>
/// <typeparam name="T">Type to check for.</typeparam>
public class TypeBasedOverride<T> : TypeBasedOverride
{
	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.TypeBasedOverride`1" />.
	/// </summary>
	/// <param name="innerOverride">Inner override to check after type matches.</param>
	public TypeBasedOverride(ResolverOverride innerOverride)
		: base(typeof(T), innerOverride)
	{
	}
}

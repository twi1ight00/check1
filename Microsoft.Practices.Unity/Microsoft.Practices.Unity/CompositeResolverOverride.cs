using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> that composites other
/// ResolverOverride objects. The GetResolver operation then
/// returns the resolver from the first child override that
/// matches the current context and request.
/// </summary>
public class CompositeResolverOverride : ResolverOverride, IEnumerable<ResolverOverride>, IEnumerable
{
	private readonly List<ResolverOverride> overrides = new List<ResolverOverride>();

	/// <summary>
	/// Add a new <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> to the collection
	/// that is checked.
	/// </summary>
	/// <param name="newOverride">item to add.</param>
	public void Add(ResolverOverride newOverride)
	{
		overrides.Add(newOverride);
	}

	/// <summary>
	/// Add a setof <see cref="T:Microsoft.Practices.Unity.ResolverOverride" />s to the collection.
	/// </summary>
	/// <param name="newOverrides">items to add.</param>
	public void AddRange(IEnumerable<ResolverOverride> newOverrides)
	{
		overrides.AddRange(newOverrides);
	}

	/// <summary>
	/// Returns an enumerator that iterates through a collection.
	/// </summary>
	/// <returns>
	/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
	/// </returns>
	/// <filterpriority>2</filterpriority>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <summary>
	/// Returns an enumerator that iterates through the collection.
	/// </summary>
	/// <returns>
	/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
	/// </returns>
	/// <filterpriority>1</filterpriority>
	public IEnumerator<ResolverOverride> GetEnumerator()
	{
		return overrides.GetEnumerator();
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
		for (int num = overrides.Count() - 1; num >= 0; num--)
		{
			IDependencyResolverPolicy resolver = overrides[num].GetResolver(context, dependencyType);
			if (resolver != null)
			{
				return resolver;
			}
		}
		return null;
	}
}

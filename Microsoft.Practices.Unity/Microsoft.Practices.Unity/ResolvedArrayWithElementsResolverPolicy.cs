using System;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that resolves to
/// to an array populated with the values that result from resolving other instances
/// of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />.
/// </summary>
public class ResolvedArrayWithElementsResolverPolicy : IDependencyResolverPolicy, IBuilderPolicy
{
	private delegate object Resolver(IBuilderContext context, IDependencyResolverPolicy[] elementPolicies);

	private readonly Resolver resolver;

	private readonly IDependencyResolverPolicy[] elementPolicies;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.ResolvedArrayWithElementsResolverPolicy" />
	/// with the given type and a collection of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />
	/// instances to use when populating the result.
	/// </summary>
	/// <param name="elementType">The type.</param>
	/// <param name="elementPolicies">The resolver policies to use when populating an array.</param>
	public ResolvedArrayWithElementsResolverPolicy(Type elementType, params IDependencyResolverPolicy[] elementPolicies)
	{
		Guard.ArgumentNotNull(elementType, "elementType");
		MethodInfo method = typeof(ResolvedArrayWithElementsResolverPolicy).GetMethod("DoResolve", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(elementType);
		resolver = (Resolver)Delegate.CreateDelegate(typeof(Resolver), method);
		this.elementPolicies = elementPolicies;
	}

	/// <summary>
	/// Resolve the value for a dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <returns>An array pupulated with the results of resolving the resolver policies.</returns>
	public object Resolve(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		return resolver(context, elementPolicies);
	}

	private static object DoResolve<T>(IBuilderContext context, IDependencyResolverPolicy[] elementPolicies)
	{
		T[] array = new T[elementPolicies.Length];
		for (int i = 0; i < elementPolicies.Length; i++)
		{
			array[i] = (T)elementPolicies[i].Resolve(context);
		}
		return array;
	}
}

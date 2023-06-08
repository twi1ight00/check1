using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Base class that provides an implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IMethodSelectorPolicy" />
/// which lets you override how the parameter resolvers are created.
/// </summary>
/// <typeparam name="TMarkerAttribute">Attribute that marks methods that should
/// be called.</typeparam>
public abstract class MethodSelectorPolicyBase<TMarkerAttribute> : IMethodSelectorPolicy, IBuilderPolicy where TMarkerAttribute : Attribute
{
	/// <summary>
	/// Return the sequence of methods to call while building the target object.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>Sequence of methods to call.</returns>
	public virtual IEnumerable<SelectedMethod> SelectMethods(IBuilderContext context, IPolicyList resolverPolicyDestination)
	{
		Type t = context.BuildKey.Type;
		try
		{
			MethodInfo[] methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			foreach (MethodInfo method in methods)
			{
				if (method.IsDefined(typeof(TMarkerAttribute), inherit: false))
				{
					yield return CreateSelectedMethod(context, resolverPolicyDestination, method);
				}
			}
		}
		finally
		{
		}
	}

	private SelectedMethod CreateSelectedMethod(IBuilderContext context, IPolicyList resolverPolicyDestination, MethodInfo method)
	{
		SelectedMethod selectedMethod = new SelectedMethod(method);
		ParameterInfo[] parameters = method.GetParameters();
		foreach (ParameterInfo parameter in parameters)
		{
			string text = Guid.NewGuid().ToString();
			IDependencyResolverPolicy policy = CreateResolver(parameter);
			resolverPolicyDestination.Set(policy, text);
			DependencyResolverTrackerPolicy.TrackKey(context.PersistentPolicies, context.BuildKey, text);
			selectedMethod.AddParameterKey(text);
		}
		return selectedMethod;
	}

	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance for the given
	/// <see cref="T:System.Reflection.ParameterInfo" />.
	/// </summary>
	/// <param name="parameter">Parameter to create the resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected abstract IDependencyResolverPolicy CreateResolver(ParameterInfo parameter);
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Base class that provides an implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IConstructorSelectorPolicy" />
/// which lets you override how the parameter resolvers are created.
/// </summary>
public abstract class ConstructorSelectorPolicyBase<TInjectionConstructorMarkerAttribute> : IConstructorSelectorPolicy, IBuilderPolicy where TInjectionConstructorMarkerAttribute : Attribute
{
	private class ConstructorLengthComparer : IComparer<ConstructorInfo>
	{
		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		/// </summary>
		///
		/// <returns>
		/// Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
		/// </returns>
		///
		/// <param name="y">The second object to compare.</param>
		/// <param name="x">The first object to compare.</param>
		public int Compare(ConstructorInfo x, ConstructorInfo y)
		{
			return y.GetParameters().Length - x.GetParameters().Length;
		}
	}

	/// <summary>
	/// Choose the constructor to call for the given type.
	/// </summary>
	/// <param name="context">Current build context</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>The chosen constructor.</returns>
	public SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination)
	{
		Type type = context.BuildKey.Type;
		ConstructorInfo constructorInfo = FindInjectionConstructor(type) ?? FindLongestConstructor(type);
		if (constructorInfo != null)
		{
			return CreateSelectedConstructor(context, resolverPolicyDestination, constructorInfo);
		}
		return null;
	}

	private SelectedConstructor CreateSelectedConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination, ConstructorInfo ctor)
	{
		SelectedConstructor selectedConstructor = new SelectedConstructor(ctor);
		ParameterInfo[] parameters = ctor.GetParameters();
		foreach (ParameterInfo parameter in parameters)
		{
			string text = Guid.NewGuid().ToString();
			IDependencyResolverPolicy policy = CreateResolver(parameter);
			resolverPolicyDestination.Set(policy, text);
			DependencyResolverTrackerPolicy.TrackKey(resolverPolicyDestination, context.BuildKey, text);
			selectedConstructor.AddParameterKey(text);
		}
		return selectedConstructor;
	}

	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance for the given
	/// <see cref="T:System.Reflection.ParameterInfo" />.
	/// </summary>
	/// <param name="parameter">Parameter to create the resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected abstract IDependencyResolverPolicy CreateResolver(ParameterInfo parameter);

	private static ConstructorInfo FindInjectionConstructor(Type typeToConstruct)
	{
		ConstructorInfo[] array = (from ctor in typeToConstruct.GetConstructors()
			where ctor.IsDefined(typeof(TInjectionConstructorMarkerAttribute), inherit: true)
			select ctor).ToArray();
		return array.Length switch
		{
			0 => null, 
			1 => array[0], 
			_ => throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.MultipleInjectionConstructors, typeToConstruct.Name)), 
		};
	}

	private static ConstructorInfo FindLongestConstructor(Type typeToConstruct)
	{
		ConstructorInfo[] constructors = typeToConstruct.GetConstructors();
		Array.Sort(constructors, new ConstructorLengthComparer());
		switch (constructors.Length)
		{
		case 0:
			return null;
		case 1:
			return constructors[0];
		default:
		{
			int num = constructors[0].GetParameters().Length;
			if (constructors[1].GetParameters().Length == num)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.AmbiguousInjectionConstructor, typeToConstruct.Name, num));
			}
			return constructors[0];
		}
		}
	}
}

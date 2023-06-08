using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A class that holds the collection of information
/// for a constructor, so that the container can
/// be configured to call this constructor.
/// </summary>
public class InjectionConstructor : InjectionMember
{
	private readonly List<InjectionParameterValue> parameterValues;

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.InjectionConstructor" /> that looks
	/// for a constructor with the given set of parameters.
	/// </summary>
	/// <param name="parameterValues">The values for the parameters, that will
	/// be converted to <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> objects.</param>
	public InjectionConstructor(params object[] parameterValues)
	{
		this.parameterValues = InjectionParameterValue.ToParameters(parameterValues).ToList();
	}

	/// <summary>
	/// Add policies to the <paramref name="policies" /> to configure the
	/// container to call this constructor with the appropriate parameter values.
	/// </summary>
	/// <param name="serviceType">Interface registered, ignored in this implementation.</param>
	/// <param name="implementationType">Type to register.</param>
	/// <param name="name">Name used to resolve the type object.</param>
	/// <param name="policies">Policy list to add policies to.</param>
	public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
	{
		ConstructorInfo ctor = FindConstructor(implementationType);
		policies.Set((IConstructorSelectorPolicy)new SpecifiedConstructorSelectorPolicy(ctor, parameterValues.ToArray()), (object)new NamedTypeBuildKey(implementationType, name));
	}

	private ConstructorInfo FindConstructor(Type typeToCreate)
	{
		ParameterMatcher parameterMatcher = new ParameterMatcher(parameterValues);
		ConstructorInfo[] constructors = typeToCreate.GetConstructors();
		foreach (ConstructorInfo constructorInfo in constructors)
		{
			if (parameterMatcher.Matches(constructorInfo.GetParameters()))
			{
				return constructorInfo;
			}
		}
		string text = string.Join(", ", parameterValues.Select((InjectionParameterValue p) => p.ParameterTypeName).ToArray());
		throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NoSuchConstructor, typeToCreate.FullName, text));
	}
}

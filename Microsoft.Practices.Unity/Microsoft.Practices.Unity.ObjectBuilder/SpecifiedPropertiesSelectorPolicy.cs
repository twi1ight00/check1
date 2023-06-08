using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.ObjectBuilder;

/// <summary>
/// An implemnetation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IPropertySelectorPolicy" /> which returns
/// the set of specific properties that the selector was configured with.
/// </summary>
public class SpecifiedPropertiesSelectorPolicy : IPropertySelectorPolicy, IBuilderPolicy
{
	private readonly List<Pair<PropertyInfo, InjectionParameterValue>> propertiesAndValues = new List<Pair<PropertyInfo, InjectionParameterValue>>();

	/// <summary>
	/// Add a property that will be par of the set returned when the 
	/// <see cref="M:Microsoft.Practices.Unity.ObjectBuilder.SpecifiedPropertiesSelectorPolicy.SelectProperties(Microsoft.Practices.ObjectBuilder2.IBuilderContext,Microsoft.Practices.ObjectBuilder2.IPolicyList)" /> is called.
	/// </summary>
	/// <param name="property">The property to set.</param>
	/// <param name="value"><see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> object describing
	/// how to create the value to inject.</param>
	public void AddPropertyAndValue(PropertyInfo property, InjectionParameterValue value)
	{
		propertiesAndValues.Add(Pair.Make(property, value));
	}

	/// <summary>
	/// Returns sequence of properties on the given type that
	/// should be set as part of building that object.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>Sequence of <see cref="T:System.Reflection.PropertyInfo" /> objects
	/// that contain the properties to set.</returns>
	public IEnumerable<SelectedProperty> SelectProperties(IBuilderContext context, IPolicyList resolverPolicyDestination)
	{
		Type typeToBuild = context.BuildKey.Type;
		ReflectionHelper currentTypeReflector = new ReflectionHelper(context.BuildKey.Type);
		foreach (Pair<PropertyInfo, InjectionParameterValue> pair in propertiesAndValues)
		{
			PropertyInfo currentProperty = pair.First;
			if (new ReflectionHelper(pair.First.DeclaringType).IsOpenGeneric)
			{
				currentProperty = currentTypeReflector.Type.GetProperty(currentProperty.Name);
			}
			string key = Guid.NewGuid().ToString();
			resolverPolicyDestination.Set(pair.Second.GetResolverPolicy(typeToBuild), key);
			yield return new SelectedProperty(currentProperty, key);
		}
	}
}

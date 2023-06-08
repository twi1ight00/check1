using System;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// This class stores information about which properties to inject,
/// and will configure the container accordingly.
/// </summary>
public class InjectionProperty : InjectionMember
{
	private readonly string propertyName;

	private InjectionParameterValue parameterValue;

	/// <summary>
	/// Configure the container to inject the given property name,
	/// resolving the value via the container.
	/// </summary>
	/// <param name="propertyName">Name of the property to inject.</param>
	public InjectionProperty(string propertyName)
	{
		this.propertyName = propertyName;
	}

	/// <summary>
	/// Configure the container to inject the given property name,
	/// using the value supplied. This value is converted to an
	/// <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> object using the
	/// rules defined by the <see cref="M:Microsoft.Practices.Unity.InjectionParameterValue.ToParameters(System.Object[])" />
	/// method.
	/// </summary>
	/// <param name="propertyName">Name of property to inject.</param>
	/// <param name="propertyValue">Value for property.</param>
	public InjectionProperty(string propertyName, object propertyValue)
	{
		this.propertyName = propertyName;
		parameterValue = InjectionParameterValue.ToParameter(propertyValue);
	}

	/// <summary>
	/// Add policies to the <paramref name="policies" /> to configure the
	/// container to call this constructor with the appropriate parameter values.
	/// </summary>
	/// <param name="serviceType">Interface being registered, ignored in this implemenation.</param>
	/// <param name="implementationType">Type to register.</param>
	/// <param name="name">Name used to resolve the type object.</param>
	/// <param name="policies">Policy list to add policies to.</param>
	public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
	{
		Guard.ArgumentNotNull(implementationType, "implementationType");
		PropertyInfo property = implementationType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		GuardPropertyExists(property, implementationType, propertyName);
		GuardPropertyIsSettable(property);
		GuardPropertyIsNotIndexer(property);
		InitializeParameterValue(property);
		GuardPropertyValueIsCompatible(property, parameterValue);
		SpecifiedPropertiesSelectorPolicy selectorPolicy = GetSelectorPolicy(policies, implementationType, name);
		selectorPolicy.AddPropertyAndValue(property, parameterValue);
	}

	private InjectionParameterValue InitializeParameterValue(PropertyInfo propInfo)
	{
		if (parameterValue == null)
		{
			parameterValue = new ResolvedParameter(propInfo.PropertyType);
		}
		return parameterValue;
	}

	private static SpecifiedPropertiesSelectorPolicy GetSelectorPolicy(IPolicyList policies, Type typeToInject, string name)
	{
		NamedTypeBuildKey buildKey = new NamedTypeBuildKey(typeToInject, name);
		IPropertySelectorPolicy propertySelectorPolicy = policies.GetNoDefault<IPropertySelectorPolicy>(buildKey, localOnly: false);
		if (propertySelectorPolicy == null || !(propertySelectorPolicy is SpecifiedPropertiesSelectorPolicy))
		{
			propertySelectorPolicy = new SpecifiedPropertiesSelectorPolicy();
			policies.Set(propertySelectorPolicy, buildKey);
		}
		return (SpecifiedPropertiesSelectorPolicy)propertySelectorPolicy;
	}

	private static void GuardPropertyExists(PropertyInfo propInfo, Type typeToCreate, string propertyName)
	{
		if (propInfo == null)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NoSuchProperty, typeToCreate.Name, propertyName));
		}
	}

	private static void GuardPropertyIsSettable(PropertyInfo propInfo)
	{
		if (!propInfo.CanWrite)
		{
			throw new InvalidOperationException(ExceptionMessage(Resources.PropertyNotSettable, propInfo.Name, propInfo.DeclaringType));
		}
	}

	private static void GuardPropertyIsNotIndexer(PropertyInfo property)
	{
		if (property.GetIndexParameters().Length > 0)
		{
			throw new InvalidOperationException(ExceptionMessage(Resources.CannotInjectIndexer, property.Name, property.DeclaringType));
		}
	}

	private static void GuardPropertyValueIsCompatible(PropertyInfo property, InjectionParameterValue value)
	{
		if (!value.MatchesType(property.PropertyType))
		{
			throw new InvalidOperationException(ExceptionMessage(Resources.PropertyTypeMismatch, property.Name, property.DeclaringType, property.PropertyType, value.ParameterTypeName));
		}
	}

	private static string ExceptionMessage(string format, params object[] args)
	{
		for (int i = 0; i < args.Length; i++)
		{
			if (args[i] is Type)
			{
				args[i] = ((Type)args[i]).Name;
			}
		}
		return string.Format(CultureInfo.CurrentCulture, format, args);
	}
}

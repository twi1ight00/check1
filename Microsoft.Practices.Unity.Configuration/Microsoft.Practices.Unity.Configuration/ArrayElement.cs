using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.Configuration.Properties;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A configuration element used to configure injection of
/// a specific set of values into an array.
/// </summary>
public class ArrayElement : ParameterValueElement
{
	private const string TypeNamePropertyName = "type";

	private const string ValuesPropertyName = "";

	/// <summary>
	/// Type of array to inject. This is actually the type of the array elements,
	/// not the array type. Optional, if not specified we take the type from
	/// our containing element.
	/// </summary>
	[ConfigurationProperty("type", IsRequired = false)]
	public string TypeName
	{
		get
		{
			return (string)base["type"];
		}
		set
		{
			base["type"] = value;
		}
	}

	/// <summary>
	/// Values used to calculate the contents of the array.
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public ParameterValueElementCollection Values => (ParameterValueElementCollection)base[""];

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		writer.WriteAttributeIfNotEmpty("type", TypeName);
		foreach (ParameterValueElement value in Values)
		{
			ValueElementHelper.SerializeParameterValueElement(writer, value, elementsOnly: true);
		}
	}

	/// <summary>
	/// Generate an <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> object
	/// that will be used to configure the container for a type registration.
	/// </summary>
	/// <param name="container">Container that is being configured. Supplied in order
	/// to let custom implementations retrieve services; do not configure the container
	/// directly in this method.</param>
	/// <param name="parameterType">Type of the </param>
	/// <returns></returns>
	public override InjectionParameterValue GetInjectionParameterValue(IUnityContainer container, Type parameterType)
	{
		GuardTypeIsAnArray(parameterType);
		Type elementType = GetElementType(parameterType);
		IEnumerable<InjectionParameterValue> source = Values.Select((ParameterValueElement v) => v.GetInjectionParameterValue(container, elementType));
		if (elementType.IsGenericParameter)
		{
			return new GenericResolvedArrayParameter(elementType.Name, source.ToArray());
		}
		return new ResolvedArrayParameter(elementType, source.ToArray());
	}

	private void GuardTypeIsAnArray(Type externalParameterType)
	{
		if (string.IsNullOrEmpty(TypeName) && !externalParameterType.IsArray)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NotAnArray, externalParameterType.Name));
		}
	}

	private Type GetElementType(Type parameterType)
	{
		return TypeResolver.ResolveTypeWithDefault(TypeName, null) ?? parameterType.GetElementType();
	}
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.Properties;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// A helper class that assists in deserializing parameter and property
/// elements. These elements both have a single "value" child element that
/// specify the value to inject for the property or parameter.
/// </summary>
public class ValueElementHelper
{
	private readonly IValueProvidingElement parentElement;

	private static readonly DependencyElement defaultDependency = new DependencyElement();

	private readonly UnknownElementHandlerMap unknownElementHandlerMap;

	private readonly Dictionary<string, string> attributeMap = new Dictionary<string, string>();

	private static readonly Dictionary<Type, string> knownValueElementTags = new Dictionary<Type, string>
	{
		{
			typeof(DependencyElement),
			"dependency"
		},
		{
			typeof(ValueElement),
			"value"
		},
		{
			typeof(ArrayElement),
			"array"
		},
		{
			typeof(OptionalElement),
			"optional"
		}
	};

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.Configuration.ConfigurationHelpers.ValueElementHelper" /> that wraps reading
	/// values and storing them in the given <paramref name="parentElement" />.
	/// </summary>
	/// <param name="parentElement">Element that contains the value elements.</param>
	public ValueElementHelper(IValueProvidingElement parentElement)
	{
		this.parentElement = parentElement;
		UnknownElementHandlerMap unknownElementHandlerMap = new UnknownElementHandlerMap();
		Action<XmlReader> processingAction = delegate(XmlReader xr)
		{
			SetValue<ValueElement>(xr);
		};
		unknownElementHandlerMap.Add("value", processingAction);
		unknownElementHandlerMap.Add("dependency", delegate(XmlReader xr)
		{
			SetValue<DependencyElement>(xr);
		});
		unknownElementHandlerMap.Add("array", delegate(XmlReader xr)
		{
			SetValue<ArrayElement>(xr);
		});
		unknownElementHandlerMap.Add("optional", delegate(XmlReader xr)
		{
			SetValue<OptionalElement>(xr);
		});
		this.unknownElementHandlerMap = unknownElementHandlerMap;
	}

	/// <summary>
	/// Gets a <see cref="T:Microsoft.Practices.Unity.Configuration.ParameterValueElement" />, or if none is present,
	/// returns a default <see cref="T:Microsoft.Practices.Unity.Configuration.DependencyElement" />.
	/// </summary>
	/// <param name="currentValue">The <see cref="T:Microsoft.Practices.Unity.Configuration.ParameterValueElement" />.</param>
	/// <returns>The given <paramref name="currentValue" />, unless
	/// <paramref name="currentValue" /> is null, in which case returns
	/// a <see cref="T:Microsoft.Practices.Unity.Configuration.DependencyElement" />.</returns>
	public static ParameterValueElement GetValue(ParameterValueElement currentValue)
	{
		return currentValue ?? defaultDependency;
	}

	/// <summary>
	/// Helper method used during deserialization to handle
	/// attributes for the dependency and value tags.
	/// </summary>
	/// <param name="name">attribute name.</param>
	/// <param name="value">attribute value.</param>
	/// <returns>true</returns>
	public bool DeserializeUnrecognizedAttribute(string name, string value)
	{
		attributeMap[name] = value;
		return true;
	}

	/// <summary>
	/// Helper method used during deserialization to handle the default
	/// value element tags.
	/// </summary>
	/// <param name="elementName">The element name.</param>
	/// <param name="reader">XML data to read.</param>
	/// <returns>True if deserialization succeeded, false if it failed.</returns>
	public bool DeserializeUnknownElement(string elementName, XmlReader reader)
	{
		if (!unknownElementHandlerMap.ProcessElement(elementName, reader))
		{
			return DeserializeExtensionValueElement(elementName, reader);
		}
		return true;
	}

	/// <summary>
	/// Call this method at the end of deserialization of your element to
	/// set your value element.
	/// </summary>
	public void CompleteValueElement(XmlReader reader)
	{
		if (ShouldConstructValueElementFromAttributes(reader))
		{
			ConstructValueElementFromAttributes();
		}
	}

	/// <summary>
	/// Serialize a <see cref="T:Microsoft.Practices.Unity.Configuration.ParameterValueElement" /> object out to XML.
	/// This method is aware of and implements the shorthand attributes
	/// for dependency and value elements.
	/// </summary>
	/// <param name="writer">Writer to output XML to.</param>
	/// <param name="element">The <see cref="T:Microsoft.Practices.Unity.Configuration.ParameterValueElement" /> to serialize.</param>
	/// <param name="elementsOnly">If true, always output an element. If false, then
	/// dependency and value elements will be serialized as attributes in the parent tag.</param>
	public static void SerializeParameterValueElement(XmlWriter writer, ParameterValueElement element, bool elementsOnly)
	{
		string tagForElement = GetTagForElement(element);
		if (!elementsOnly)
		{
			if (element is IAttributeOnlyElement attributeOnlyElement)
			{
				attributeOnlyElement.SerializeContent(writer);
			}
			else
			{
				writer.WriteElement(tagForElement, element.SerializeContent);
			}
		}
		else
		{
			writer.WriteElement(tagForElement, element.SerializeContent);
		}
	}

	private static string GetTagForElement(ConfigurationElement element)
	{
		Type type = element.GetType();
		return knownValueElementTags.GetOrNull(type) ?? ExtensionElementMap.GetTagForExtensionElement(element);
	}

	private void SetValue<TElement>(XmlReader reader) where TElement : ParameterValueElement, new()
	{
		if (parentElement.Value != null)
		{
			throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.DuplicateParameterValueElement, parentElement.DestinationName), reader);
		}
		TElement value = new TElement();
		value.Deserialize(reader);
		parentElement.Value = value;
	}

	private bool ShouldConstructValueElementFromAttributes(XmlReader reader)
	{
		if (parentElement.Value != null)
		{
			if (attributeMap.Count > 0)
			{
				throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.ElementWithAttributesAndParameterValueElements, parentElement.DestinationName), reader);
			}
			return false;
		}
		return attributeMap.Count > 0;
	}

	private void ConstructValueElementFromAttributes()
	{
		if (attributeMap.ContainsKey("value"))
		{
			parentElement.Value = new ValueElement(attributeMap);
			return;
		}
		if (attributeMap.ContainsKey("dependencyName") || attributeMap.ContainsKey("dependencyType"))
		{
			parentElement.Value = new DependencyElement(attributeMap);
			return;
		}
		throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidValueAttributes, parentElement.DestinationName));
	}

	private bool DeserializeExtensionValueElement(string elementName, XmlReader reader)
	{
		Type parameterValueElementType = ExtensionElementMap.GetParameterValueElementType(elementName);
		if (parameterValueElementType != null)
		{
			ParameterValueElement parameterValueElement = (ParameterValueElement)Activator.CreateInstance(parameterValueElementType);
			parameterValueElement.Deserialize(reader);
			parentElement.Value = parameterValueElement;
		}
		return parameterValueElementType != null;
	}
}

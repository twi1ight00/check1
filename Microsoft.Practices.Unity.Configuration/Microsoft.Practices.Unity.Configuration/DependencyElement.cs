using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.Configuration.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.Configuration.ParameterValueElement" /> derived class that describes
/// a parameter that should be resolved through the container.
/// </summary>
public class DependencyElement : ParameterValueElement, IAttributeOnlyElement
{
	private const string NamePropertyName = "name";

	private const string TypeNamePropertyName = "type";

	/// <summary>
	/// Name to use to when resolving. If empty, resolves the default.
	/// </summary>
	[ConfigurationProperty("name", IsRequired = false)]
	public string Name
	{
		get
		{
			return (string)base["name"];
		}
		set
		{
			base["name"] = value;
		}
	}

	/// <summary>
	/// Name of type this dependency should resolve to. This is optional;
	/// without it the container will resolve the type of whatever
	/// property or parameter this element is contained in.
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
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.Configuration.DependencyElement" />.
	/// </summary>
	public DependencyElement()
	{
	}

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.Configuration.DependencyElement" /> with
	/// properties initialized from the contents of 
	/// <paramref name="attributeValues" />.
	/// </summary>
	/// <param name="attributeValues">Dictionary of name/value pairs to
	/// initialize this object with.</param>
	public DependencyElement(IDictionary<string, string> attributeValues)
	{
		Action<string> setter = delegate(string value)
		{
			Name = value;
		};
		SetIfPresent(attributeValues, "dependencyName", setter);
		SetIfPresent(attributeValues, "dependencyType", delegate(string value)
		{
			TypeName = value;
		});
	}

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	void IAttributeOnlyElement.SerializeContent(XmlWriter writer)
	{
		writer.WriteAttributeIfNotEmpty("dependencyName", Name).WriteAttributeIfNotEmpty("dependencyType", TypeName);
	}

	/// <summary>
	///  Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />. This
	///  method always outputs an explicit &lt;dependency&gt; tag, instead of providing
	///  attributes to the parent method.
	/// </summary>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		writer.WriteAttributeIfNotEmpty("name", Name).WriteAttributeIfNotEmpty("type", TypeName);
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
		Guard.ArgumentNotNull(parameterType, "parameterType");
		string text = Name;
		if (string.IsNullOrEmpty(text))
		{
			text = null;
		}
		if (parameterType.IsGenericParameter)
		{
			if (!string.IsNullOrEmpty(TypeName))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.DependencyForGenericParameterWithTypeSet, parameterType.Name, TypeName));
			}
			return new GenericParameter(parameterType.Name, text);
		}
		return new ResolvedParameter(TypeResolver.ResolveTypeWithDefault(TypeName, parameterType), text);
	}

	private static void SetIfPresent(IDictionary<string, string> attributeValues, string key, Action<string> setter)
	{
		if (attributeValues.ContainsKey(key))
		{
			setter(attributeValues[key]);
		}
	}
}

using System;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A configuration element that represents lifetime managers.
/// </summary>
public class LifetimeElement : DeserializableConfigurationElement
{
	private const string TypeConverterTypeNamePropertyName = "typeConverter";

	private const string TypeNamePropertyName = "type";

	private const string ValuePropertyName = "value";

	/// <summary>
	/// Type of the lifetime manager.
	/// </summary>
	[ConfigurationProperty("type", IsRequired = true, DefaultValue = "")]
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
	/// Extra initialization information used by the type converter for this lifetime manager.
	/// </summary>
	[ConfigurationProperty("value", IsRequired = false)]
	public string Value
	{
		get
		{
			return (string)base["value"];
		}
		set
		{
			base["value"] = value;
		}
	}

	/// <summary>
	/// Type of <see cref="T:System.ComponentModel.TypeConverter" /> to use to create the
	/// lifetime manager.
	/// </summary>
	[ConfigurationProperty("typeConverter", IsRequired = false)]
	public string TypeConverterTypeName
	{
		get
		{
			return (string)base["typeConverter"];
		}
		set
		{
			base["typeConverter"] = value;
		}
	}

	/// <summary>
	/// Create the <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> described by
	/// this element.
	/// </summary>
	/// <returns>A <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> instance.</returns>
	public LifetimeManager CreateLifetimeManager()
	{
		TypeConverter typeConverter = GetTypeConverter();
		if (typeConverter == null)
		{
			return (LifetimeManager)Activator.CreateInstance(GetLifetimeType());
		}
		return (LifetimeManager)typeConverter.ConvertFrom(Value);
	}

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		Guard.ArgumentNotNull(writer, "writer");
		writer.WriteAttributeString("type", TypeName);
		if (!string.IsNullOrEmpty(Value))
		{
			writer.WriteAttributeString("value", Value);
		}
		if (!string.IsNullOrEmpty(TypeConverterTypeName))
		{
			writer.WriteAttributeString("typeConverter", TypeConverterTypeName);
		}
	}

	private Type GetLifetimeType()
	{
		return TypeResolver.ResolveTypeWithDefault(TypeName, typeof(TransientLifetimeManager));
	}

	private TypeConverter GetTypeConverter()
	{
		if (string.IsNullOrEmpty(Value) && string.IsNullOrEmpty(TypeConverterTypeName))
		{
			return null;
		}
		if (!string.IsNullOrEmpty(TypeConverterTypeName))
		{
			Type type = TypeResolver.ResolveType(TypeConverterTypeName);
			return (TypeConverter)Activator.CreateInstance(type);
		}
		return TypeDescriptor.GetConverter(GetLifetimeType());
	}
}

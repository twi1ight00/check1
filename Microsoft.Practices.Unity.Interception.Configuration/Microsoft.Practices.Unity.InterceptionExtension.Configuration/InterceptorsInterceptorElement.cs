using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.InterceptionExtension.Configuration.Properties;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// Configuration element that represents the configuration for
/// a specific interceptor, as presented in the config file inside
/// the &lt;interceptors&gt; element.
/// </summary>
public class InterceptorsInterceptorElement : DeserializableConfigurationElement
{
	private const string TypeNamePropertyName = "type";

	private const string RegistrationsPropertyName = "registrations";

	private const string ValuePropertyName = "value";

	private const string TypeConverterTypeNamePropertyName = "typeConverter";

	private static readonly UnknownElementHandlerMap<InterceptorsInterceptorElement> unknownElementHandlerMap = new UnknownElementHandlerMap<InterceptorsInterceptorElement>
	{
		{
			"default",
			delegate(InterceptorsInterceptorElement iie, XmlReader xr)
			{
				iie.ReadElementByType(xr, typeof(DefaultElement), iie.Registrations);
			}
		},
		{
			"key",
			delegate(InterceptorsInterceptorElement iie, XmlReader xr)
			{
				iie.ReadElementByType(xr, typeof(KeyElement), iie.Registrations);
			}
		}
	};

	/// <summary>
	/// Type of interceptor to configure.
	/// </summary>
	[ConfigurationProperty("type", IsRequired = true, IsKey = true)]
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
	/// The types that this interceptor will be registered against.
	/// </summary>
	[ConfigurationProperty("registrations")]
	public InterceptorRegistrationElementCollection Registrations => (InterceptorRegistrationElementCollection)base["registrations"];

	/// <summary>
	/// Any value passed to the type converter.
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
	/// Type converter to use to create the interceptor, if any.
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
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		writer.WriteAttributeString("type", TypeName);
		writer.WriteAttributeIfNotEmpty("value", Value);
		writer.WriteAttributeIfNotEmpty("typeConverter", TypeConverterTypeName);
		foreach (InterceptorRegistrationElement registration in Registrations)
		{
			writer.WriteElement(registration.ElementName, registration.SerializeContent);
		}
	}

	internal void ConfigureContainer(IUnityContainer container)
	{
		IInterceptor interceptor = CreateInterceptor();
		foreach (InterceptorRegistrationElement registration in Registrations)
		{
			registration.RegisterInterceptor(container, interceptor);
		}
	}

	/// <summary>
	/// Gets a value indicating whether an unknown element is encountered during deserialization.
	/// </summary>
	/// <returns>
	/// true when an unknown element is encountered while deserializing; otherwise, false.
	/// </returns>
	/// <param name="elementName">The name of the unknown subelement.
	///                 </param><param name="reader">The <see cref="T:System.Xml.XmlReader" /> being used for deserialization.
	///                 </param><exception cref="T:System.Configuration.ConfigurationErrorsException">The element identified by <paramref name="elementName" /> is locked.
	///                     - or -
	///                     One or more of the element's attributes is locked.
	///                     - or -
	///                 <paramref name="elementName" /> is unrecognized, or the element has an unrecognized attribute.
	///                     - or -
	///                     The element has a Boolean attribute with an invalid value.
	///                     - or -
	///                     An attempt was made to deserialize a property more than once.
	///                     - or -
	///                     An attempt was made to deserialize a property that is not a valid member of the element.
	///                     - or -
	///                     The element cannot contain a CDATA or text element.
	///                 </exception>
	protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
	{
		if (!unknownElementHandlerMap.ProcessElement(this, elementName, reader))
		{
			return base.OnDeserializeUnrecognizedElement(elementName, reader);
		}
		return true;
	}

	private void GuardIsValidInterceptorType(Type type)
	{
		GuardTypesCompatible<IInterceptor>(type);
	}

	private void GuardIsValidTypeConverterType(Type type)
	{
		GuardTypesCompatible<TypeConverter>(type);
	}

	private void GuardTypesCompatible<TTargetType>(Type type)
	{
		if (!typeof(TTargetType).IsAssignableFrom(type))
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionResolvedTypeNotCompatible, TypeName, type.FullName, typeof(TTargetType).FullName));
		}
	}

	private IInterceptor CreateInterceptor()
	{
		if (!string.IsNullOrEmpty(TypeConverterTypeName))
		{
			return CreateInterceptorWithTypeConverter();
		}
		return CreateInterceptorWithNew();
	}

	private IInterceptor CreateInterceptorWithNew()
	{
		Type type = TypeResolver.ResolveType(TypeName);
		GuardIsValidInterceptorType(type);
		return (IInterceptor)Activator.CreateInstance(type);
	}

	private IInterceptor CreateInterceptorWithTypeConverter()
	{
		Type type = TypeResolver.ResolveType(TypeConverterTypeName);
		GuardIsValidTypeConverterType(type);
		TypeConverter typeConverter = (TypeConverter)Activator.CreateInstance(type);
		return (IInterceptor)typeConverter.ConvertFromInvariantString(Value);
	}
}

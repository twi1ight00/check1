using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Enyim.Caching.Memcached;
using Enyim.Reflection;

namespace Enyim.Caching.Configuration;

/// <summary>
/// This element is used to define locator/transcoder/keyTransformer instances. It also provides custom initializations for them using a factory.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class ProviderElement<T> : ConfigurationElement where T : class
{
	private Dictionary<string, string> parameters = new Dictionary<string, string>();

	private IProviderFactory<T> factoryInstance;

	/// <summary>
	/// Gets or sets the type of the provider.
	/// </summary>
	[TypeConverter(typeof(TypeNameConverter))]
	[ConfigurationProperty("type", IsRequired = false)]
	public Type Type
	{
		get
		{
			return (Type)base["type"];
		}
		set
		{
			ConfigurationHelper.CheckForInterface(value, typeof(T));
			base["type"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the type of the provider factory.
	/// </summary>
	[ConfigurationProperty("factory", IsRequired = false)]
	[TypeConverter(typeof(TypeNameConverter))]
	public Type Factory
	{
		get
		{
			return (Type)base["factory"];
		}
		set
		{
			ConfigurationHelper.CheckForInterface(value, typeof(IProviderFactory<T>));
			base["factory"] = value;
		}
	}

	[ConfigurationProperty("data", IsRequired = false)]
	public TextElement Content
	{
		get
		{
			return (TextElement)base["data"];
		}
		set
		{
			base["data"] = value;
		}
	}

	protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
	{
		ConfigurationProperty property = new ConfigurationProperty(name, typeof(string), value);
		base[property] = value;
		parameters[name] = value;
		return true;
	}

	/// <summary>
	/// Creates the provider by using the factory (if present) or directly instantiating by type name
	/// </summary>
	/// <returns></returns>
	public T CreateInstance()
	{
		if (factoryInstance == null)
		{
			Type type2 = Factory;
			if (type2 != null)
			{
				factoryInstance = (IProviderFactory<T>)FastActivator.Create(type2);
				factoryInstance.Initialize(parameters);
			}
		}
		if (factoryInstance == null)
		{
			Type type = Type;
			if (type == null)
			{
				return null;
			}
			return (T)FastActivator.Create(type);
		}
		return factoryInstance.Create();
	}

	protected override void PostDeserialize()
	{
		base.PostDeserialize();
		TextElement c = Content;
		if (c != null)
		{
			parameters[string.Empty] = c.Content;
		}
	}
}

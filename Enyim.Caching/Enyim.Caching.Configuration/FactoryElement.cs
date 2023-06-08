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
/// <typeparam name="TFactory"></typeparam>
public class FactoryElement<TFactory> : ConfigurationElement where TFactory : class, IProvider
{
	protected readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();

	private TFactory instance;

	protected virtual bool IsOptional => false;

	/// <summary>
	/// Gets or sets the type of the factory.
	/// </summary>
	[TypeConverter(typeof(TypeNameConverter))]
	[ConfigurationProperty("factory")]
	public Type Factory
	{
		get
		{
			return (Type)base["factory"];
		}
		set
		{
			base["factory"] = value;
		}
	}

	protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
	{
		ConfigurationProperty property = new ConfigurationProperty(name, typeof(string), value);
		base[property] = value;
		Parameters[name] = value;
		return true;
	}

	/// <summary>
	/// Creates the provider by using the factory (if present) or directly instantiating by type name
	/// </summary>
	/// <returns></returns>
	public TFactory CreateInstance()
	{
		if (instance == null)
		{
			Type type = Factory;
			if (type == null)
			{
				if (IsOptional || !base.ElementInformation.IsPresent)
				{
					return null;
				}
				throw new ConfigurationErrorsException("factory must be defined");
			}
			instance = (TFactory)FastActivator.Create(type);
			instance.Initialize(Parameters);
		}
		return instance;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Enyim.Caching.Memcached;

namespace Enyim.Caching.Configuration;

/// <summary>
/// Configures the authentication settings for Memcached servers.
/// </summary>
public sealed class AuthenticationElement : ConfigurationElement, IAuthenticationConfiguration
{
	private Dictionary<string, object> parameters = new Dictionary<string, object>();

	/// <summary>
	/// Gets or sets the type of the <see cref="T:Enyim.Caching.Memcached.IAuthenticationProvider" /> which will be used authehticate the connections to the Memcached nodes.
	/// </summary>
	[TypeConverter(typeof(TypeNameConverter))]
	[ConfigurationProperty("type", IsRequired = false)]
	[InterfaceValidator(typeof(ISaslAuthenticationProvider))]
	public Type Type
	{
		get
		{
			return (Type)base["type"];
		}
		set
		{
			base["type"] = value;
		}
	}

	Type IAuthenticationConfiguration.Type
	{
		get
		{
			return Type;
		}
		set
		{
			ConfigurationHelper.CheckForInterface(value, typeof(ISaslAuthenticationProvider));
			Type = value;
		}
	}

	Dictionary<string, object> IAuthenticationConfiguration.Parameters => parameters;

	protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
	{
		ConfigurationProperty property = new ConfigurationProperty(name, typeof(string), value);
		base[property] = value;
		parameters[name] = value;
		return true;
	}
}

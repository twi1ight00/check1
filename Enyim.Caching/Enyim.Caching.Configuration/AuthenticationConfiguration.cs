using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached;

namespace Enyim.Caching.Configuration;

public class AuthenticationConfiguration : IAuthenticationConfiguration
{
	private Type authenticator;

	private Dictionary<string, object> parameters;

	Type IAuthenticationConfiguration.Type
	{
		get
		{
			return authenticator;
		}
		set
		{
			ConfigurationHelper.CheckForInterface(value, typeof(ISaslAuthenticationProvider));
			authenticator = value;
		}
	}

	Dictionary<string, object> IAuthenticationConfiguration.Parameters => parameters ?? (parameters = new Dictionary<string, object>());
}

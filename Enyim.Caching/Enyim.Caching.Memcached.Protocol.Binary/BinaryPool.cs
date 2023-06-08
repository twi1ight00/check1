using System;
using System.Net;
using Enyim.Caching.Configuration;
using Enyim.Reflection;

namespace Enyim.Caching.Memcached.Protocol.Binary;

/// <summary>
/// Server pool implementing the binary protocol.
/// </summary>
public class BinaryPool : DefaultServerPool
{
	private ISaslAuthenticationProvider authenticationProvider;

	private IMemcachedClientConfiguration configuration;

	public BinaryPool(IMemcachedClientConfiguration configuration)
		: base(configuration, new BinaryOperationFactory())
	{
		authenticationProvider = GetProvider(configuration);
		this.configuration = configuration;
	}

	protected override IMemcachedNode CreateNode(IPEndPoint endpoint)
	{
		return new BinaryNode(endpoint, configuration.SocketPool, authenticationProvider);
	}

	private static ISaslAuthenticationProvider GetProvider(IMemcachedClientConfiguration configuration)
	{
		IAuthenticationConfiguration auth = configuration.Authentication;
		if (auth != null)
		{
			Type t = auth.Type;
			ISaslAuthenticationProvider provider = ((t == null) ? null : (FastActivator.Create(t) as ISaslAuthenticationProvider));
			if (provider != null)
			{
				provider.Initialize(auth.Parameters);
				return provider;
			}
		}
		return null;
	}
}

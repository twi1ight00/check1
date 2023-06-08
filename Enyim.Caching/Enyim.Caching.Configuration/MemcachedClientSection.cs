using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Configuration;
using Enyim.Caching.Memcached;
using Enyim.Caching.Memcached.Protocol.Binary;
using Enyim.Caching.Memcached.Protocol.Text;

namespace Enyim.Caching.Configuration;

/// <summary>
/// Configures the <see cref="T:MemcachedClient" />. This class cannot be inherited.
/// </summary>
public sealed class MemcachedClientSection : ConfigurationSection, IMemcachedClientConfiguration
{
	/// <summary>
	/// Returns a collection of Memcached servers which can be used by the client.
	/// </summary>
	[ConfigurationProperty("servers", IsRequired = true)]
	public EndPointElementCollection Servers => (EndPointElementCollection)base["servers"];

	/// <summary>
	/// Gets or sets the configuration of the socket pool.
	/// </summary>
	[ConfigurationProperty("socketPool", IsRequired = false)]
	public SocketPoolElement SocketPool
	{
		get
		{
			return (SocketPoolElement)base["socketPool"];
		}
		set
		{
			base["socketPool"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the configuration of the authenticator.
	/// </summary>
	[ConfigurationProperty("authentication", IsRequired = false)]
	public AuthenticationElement Authentication
	{
		get
		{
			return (AuthenticationElement)base["authentication"];
		}
		set
		{
			base["authentication"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.IMemcachedNodeLocator" /> which will be used to assign items to Memcached nodes.
	/// </summary>
	[ConfigurationProperty("locator", IsRequired = false)]
	public ProviderElement<IMemcachedNodeLocator> NodeLocator
	{
		get
		{
			return (ProviderElement<IMemcachedNodeLocator>)base["locator"];
		}
		set
		{
			base["locator"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.IMemcachedKeyTransformer" /> which will be used to convert item keys for Memcached.
	/// </summary>
	[ConfigurationProperty("keyTransformer", IsRequired = false)]
	public ProviderElement<IMemcachedKeyTransformer> KeyTransformer
	{
		get
		{
			return (ProviderElement<IMemcachedKeyTransformer>)base["keyTransformer"];
		}
		set
		{
			base["keyTransformer"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.ITranscoder" /> which will be used serialzie or deserialize items.
	/// </summary>
	[ConfigurationProperty("transcoder", IsRequired = false)]
	public ProviderElement<ITranscoder> Transcoder
	{
		get
		{
			return (ProviderElement<ITranscoder>)base["transcoder"];
		}
		set
		{
			base["transcoder"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.IPerformanceMonitor" /> which will be used monitor the performance of the client.
	/// </summary>
	[ConfigurationProperty("performanceMonitor", IsRequired = false)]
	public ProviderElement<IPerformanceMonitor> PerformanceMonitor
	{
		get
		{
			return (ProviderElement<IPerformanceMonitor>)base["performanceMonitor"];
		}
		set
		{
			base["performanceMonitor"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the type of the communication between client and server.
	/// </summary>
	[ConfigurationProperty("protocol", IsRequired = false, DefaultValue = MemcachedProtocol.Binary)]
	public MemcachedProtocol Protocol
	{
		get
		{
			return (MemcachedProtocol)base["protocol"];
		}
		set
		{
			base["protocol"] = value;
		}
	}

	IList<IPEndPoint> IMemcachedClientConfiguration.Servers => Servers.ToIPEndPointCollection();

	ISocketPoolConfiguration IMemcachedClientConfiguration.SocketPool => SocketPool;

	IAuthenticationConfiguration IMemcachedClientConfiguration.Authentication => Authentication;

	/// <summary>
	/// Called after deserialization.
	/// </summary>
	protected override void PostDeserialize()
	{
		if (base.EvaluationContext.HostingContext is WebContext hostingContext && hostingContext.ApplicationLevel == WebApplicationLevel.BelowApplication)
		{
			throw new InvalidOperationException("The " + base.SectionInformation.SectionName + " section cannot be defined below the application level.");
		}
	}

	IMemcachedKeyTransformer IMemcachedClientConfiguration.CreateKeyTransformer()
	{
		return KeyTransformer.CreateInstance() ?? new DefaultKeyTransformer();
	}

	IMemcachedNodeLocator IMemcachedClientConfiguration.CreateNodeLocator()
	{
		return NodeLocator.CreateInstance() ?? new DefaultNodeLocator();
	}

	ITranscoder IMemcachedClientConfiguration.CreateTranscoder()
	{
		return Transcoder.CreateInstance() ?? new DefaultTranscoder();
	}

	IServerPool IMemcachedClientConfiguration.CreatePool()
	{
		return Protocol switch
		{
			MemcachedProtocol.Text => new DefaultServerPool(this, new TextOperationFactory()), 
			MemcachedProtocol.Binary => new BinaryPool(this), 
			_ => throw new ArgumentOutOfRangeException("Unknown protocol: " + (int)Protocol), 
		};
	}

	IPerformanceMonitor IMemcachedClientConfiguration.CreatePerformanceMonitor()
	{
		return PerformanceMonitor.CreateInstance();
	}
}

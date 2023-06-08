using System;
using System.Collections.Generic;
using System.Net;
using Enyim.Caching.Memcached;
using Enyim.Caching.Memcached.Protocol.Binary;
using Enyim.Caching.Memcached.Protocol.Text;
using Enyim.Reflection;

namespace Enyim.Caching.Configuration;

/// <summary>
/// Configuration class
/// </summary>
public class MemcachedClientConfiguration : IMemcachedClientConfiguration
{
	private Type nodeLocator;

	private ITranscoder transcoder;

	private IMemcachedKeyTransformer keyTransformer;

	/// <summary>
	/// Gets a list of <see cref="T:IPEndPoint" /> each representing a Memcached server in the pool.
	/// </summary>
	public IList<IPEndPoint> Servers { get; private set; }

	/// <summary>
	/// Gets the configuration of the socket pool.
	/// </summary>
	public ISocketPoolConfiguration SocketPool { get; private set; }

	/// <summary>
	/// Gets the authentication settings.
	/// </summary>
	public IAuthenticationConfiguration Authentication { get; private set; }

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.IMemcachedKeyTransformer" /> which will be used to convert item keys for Memcached.
	/// </summary>
	public IMemcachedKeyTransformer KeyTransformer
	{
		get
		{
			return keyTransformer ?? (keyTransformer = new DefaultKeyTransformer());
		}
		set
		{
			keyTransformer = value;
		}
	}

	/// <summary>
	/// Gets or sets the Type of the <see cref="T:Enyim.Caching.Memcached.IMemcachedNodeLocator" /> which will be used to assign items to Memcached nodes.
	/// </summary>
	/// <remarks>If both <see cref="M:NodeLocator" /> and  <see cref="M:NodeLocatorFactory" /> are assigned then the latter takes precedence.</remarks>
	public Type NodeLocator
	{
		get
		{
			return nodeLocator;
		}
		set
		{
			ConfigurationHelper.CheckForInterface(value, typeof(IMemcachedNodeLocator));
			nodeLocator = value;
		}
	}

	/// <summary>
	/// Gets or sets the NodeLocatorFactory instance which will be used to create a new IMemcachedNodeLocator instances.
	/// </summary>
	/// <remarks>If both <see cref="M:NodeLocator" /> and  <see cref="M:NodeLocatorFactory" /> are assigned then the latter takes precedence.</remarks>
	public IProviderFactory<IMemcachedNodeLocator> NodeLocatorFactory { get; set; }

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.ITranscoder" /> which will be used serialize or deserialize items.
	/// </summary>
	public ITranscoder Transcoder
	{
		get
		{
			return transcoder ?? (transcoder = new DefaultTranscoder());
		}
		set
		{
			transcoder = value;
		}
	}

	/// <summary>
	/// Gets or sets the <see cref="T:Enyim.Caching.Memcached.IPerformanceMonitor" /> instance which will be used monitor the performance of the client.
	/// </summary>
	public IPerformanceMonitor PerformanceMonitor { get; set; }

	/// <summary>
	/// Gets or sets the type of the communication between client and server.
	/// </summary>
	public MemcachedProtocol Protocol { get; set; }

	IList<IPEndPoint> IMemcachedClientConfiguration.Servers => Servers;

	ISocketPoolConfiguration IMemcachedClientConfiguration.SocketPool => SocketPool;

	IAuthenticationConfiguration IMemcachedClientConfiguration.Authentication => Authentication;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:MemcachedClientConfiguration" /> class.
	/// </summary>
	public MemcachedClientConfiguration()
	{
		Servers = new List<IPEndPoint>();
		SocketPool = new SocketPoolConfiguration();
		Authentication = new AuthenticationConfiguration();
		Protocol = MemcachedProtocol.Binary;
	}

	/// <summary>
	/// Adds a new server to the pool.
	/// </summary>
	/// <param name="address">The address and the port of the server in the format 'host:port'.</param>
	public void AddServer(string address)
	{
		Servers.Add(ConfigurationHelper.ResolveToEndPoint(address));
	}

	/// <summary>
	/// Adds a new server to the pool.
	/// </summary>
	/// <param name="address">The host name or IP address of the server.</param>
	/// <param name="port">The port number of the memcached instance.</param>
	public void AddServer(string host, int port)
	{
		Servers.Add(ConfigurationHelper.ResolveToEndPoint(host, port));
	}

	IMemcachedKeyTransformer IMemcachedClientConfiguration.CreateKeyTransformer()
	{
		return KeyTransformer;
	}

	IMemcachedNodeLocator IMemcachedClientConfiguration.CreateNodeLocator()
	{
		IProviderFactory<IMemcachedNodeLocator> f = NodeLocatorFactory;
		if (f != null)
		{
			return f.Create();
		}
		if (NodeLocator != null)
		{
			return (IMemcachedNodeLocator)FastActivator.Create(NodeLocator);
		}
		return new DefaultNodeLocator();
	}

	ITranscoder IMemcachedClientConfiguration.CreateTranscoder()
	{
		return Transcoder;
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
		return PerformanceMonitor;
	}
}

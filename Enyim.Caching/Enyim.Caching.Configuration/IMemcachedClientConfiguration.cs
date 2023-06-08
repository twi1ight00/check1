using System.Collections.Generic;
using System.Net;
using Enyim.Caching.Memcached;

namespace Enyim.Caching.Configuration;

/// <summary>
/// Defines an interface for configuring the <see cref="T:MemcachedClient" />.
/// </summary>
public interface IMemcachedClientConfiguration
{
	/// <summary>
	/// Gets a list of <see cref="T:IPEndPoint" /> each representing a Memcached server in the pool.
	/// </summary>
	IList<IPEndPoint> Servers { get; }

	/// <summary>
	/// Gets the configuration of the socket pool.
	/// </summary>
	ISocketPoolConfiguration SocketPool { get; }

	/// <summary>
	/// Gets the authentication settings.
	/// </summary>
	IAuthenticationConfiguration Authentication { get; }

	/// <summary>
	/// Creates an <see cref="T:Enyim.Caching.Memcached.IMemcachedKeyTransformer" /> instance which will be used to convert item keys for Memcached.
	/// </summary>
	IMemcachedKeyTransformer CreateKeyTransformer();

	/// <summary>
	/// Creates an <see cref="T:Enyim.Caching.Memcached.IMemcachedNodeLocator" /> instance which will be used to assign items to Memcached nodes.
	/// </summary>
	IMemcachedNodeLocator CreateNodeLocator();

	/// <summary>
	/// Creates an <see cref="T:Enyim.Caching.Memcached.ITranscoder" /> instance which will be used to serialize or deserialize items.
	/// </summary>
	ITranscoder CreateTranscoder();

	IServerPool CreatePool();

	IPerformanceMonitor CreatePerformanceMonitor();
}

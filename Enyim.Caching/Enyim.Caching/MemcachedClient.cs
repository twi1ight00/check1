using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;
using Enyim.Caching.Memcached.Results.Factories;

namespace Enyim.Caching;

/// <summary>
/// Memcached client.
/// </summary>
public class MemcachedClient : IMemcachedClient, IDisposable, IMemcachedResultsClient
{
	protected const int MaxSeconds = 2592000;

	/// <summary>
	/// Represents a value which indicates that an item should never expire.
	/// </summary>
	public static readonly TimeSpan Infinite = TimeSpan.Zero;

	internal static readonly MemcachedClientSection DefaultSettings = ConfigurationManager.GetSection("enyim.com/memcached") as MemcachedClientSection;

	private static readonly ILog log = LogManager.GetLogger(typeof(MemcachedClient));

	private IServerPool pool;

	private IMemcachedKeyTransformer keyTransformer;

	private ITranscoder transcoder;

	private IPerformanceMonitor performanceMonitor;

	protected static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);

	public IStoreOperationResultFactory StoreOperationResultFactory { get; set; }

	public IGetOperationResultFactory GetOperationResultFactory { get; set; }

	public IMutateOperationResultFactory MutateOperationResultFactory { get; set; }

	public IConcatOperationResultFactory ConcatOperationResultFactory { get; set; }

	public IRemoveOperationResultFactory RemoveOperationResultFactory { get; set; }

	protected IServerPool Pool => pool;

	protected IMemcachedKeyTransformer KeyTransformer => keyTransformer;

	protected ITranscoder Transcoder => transcoder;

	protected IPerformanceMonitor PerformanceMonitor => performanceMonitor;

	public event Action<IMemcachedNode> NodeFailed;

	/// <summary>
	/// Initializes a new MemcachedClient instance using the default configuration section (enyim/memcached).
	/// </summary>
	public MemcachedClient()
		: this(DefaultSettings)
	{
	}

	/// <summary>
	/// Initializes a new MemcachedClient instance using the specified configuration section. 
	/// This overload allows to create multiple MemcachedClients with different pool configurations.
	/// </summary>
	/// <param name="sectionName">The name of the configuration section to be used for configuring the behavior of the client.</param>
	public MemcachedClient(string sectionName)
		: this(GetSection(sectionName))
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:MemcachedClient" /> using the specified configuration instance.
	/// </summary>
	/// <param name="configuration">The client configuration.</param>
	public MemcachedClient(IMemcachedClientConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		keyTransformer = configuration.CreateKeyTransformer() ?? new DefaultKeyTransformer();
		transcoder = configuration.CreateTranscoder() ?? new DefaultTranscoder();
		performanceMonitor = configuration.CreatePerformanceMonitor();
		pool = configuration.CreatePool();
		pool.NodeFailed += delegate(IMemcachedNode n)
		{
			this.NodeFailed?.Invoke(n);
		};
		StartPool();
		StoreOperationResultFactory = new DefaultStoreOperationResultFactory();
		GetOperationResultFactory = new DefaultGetOperationResultFactory();
		MutateOperationResultFactory = new DefaultMutateOperationResultFactory();
		ConcatOperationResultFactory = new DefaultConcatOperationResultFactory();
		RemoveOperationResultFactory = new DefaultRemoveOperationResultFactory();
	}

	public MemcachedClient(IServerPool pool, IMemcachedKeyTransformer keyTransformer, ITranscoder transcoder)
		: this(pool, keyTransformer, transcoder, null)
	{
	}

	public MemcachedClient(IServerPool pool, IMemcachedKeyTransformer keyTransformer, ITranscoder transcoder, IPerformanceMonitor performanceMonitor)
	{
		if (pool == null)
		{
			throw new ArgumentNullException("pool");
		}
		if (keyTransformer == null)
		{
			throw new ArgumentNullException("keyTransformer");
		}
		if (transcoder == null)
		{
			throw new ArgumentNullException("transcoder");
		}
		this.performanceMonitor = performanceMonitor;
		this.keyTransformer = keyTransformer;
		this.transcoder = transcoder;
		this.pool = pool;
		StartPool();
	}

	private void StartPool()
	{
		pool.NodeFailed += delegate(IMemcachedNode n)
		{
			this.NodeFailed?.Invoke(n);
		};
		pool.Start();
	}

	private static IMemcachedClientConfiguration GetSection(string sectionName)
	{
		MemcachedClientSection section = (MemcachedClientSection)ConfigurationManager.GetSection(sectionName);
		if (section == null)
		{
			throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
		}
		return section;
	}

	/// <summary>
	/// Retrieves the specified item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to retrieve.</param>
	/// <returns>The retrieved item, or <value>null</value> if the key was not found.</returns>
	public object Get(string key)
	{
		if (!TryGet(key, out var tmp))
		{
			return null;
		}
		return tmp;
	}

	/// <summary>
	/// Retrieves the specified item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to retrieve.</param>
	/// <returns>The retrieved item, or <value>default(T)</value> if the key was not found.</returns>
	public T Get<T>(string key)
	{
		if (!TryGet(key, out var tmp))
		{
			return default(T);
		}
		return (T)tmp;
	}

	/// <summary>
	/// Tries to get an item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to retrieve.</param>
	/// <param name="value">The retrieved item or null if not found.</param>
	/// <returns>The <value>true</value> if the item was successfully retrieved.</returns>
	public bool TryGet(string key, out object value)
	{
		ulong cas = 0uL;
		return PerformTryGet(key, out cas, out value).Success;
	}

	public CasResult<object> GetWithCas(string key)
	{
		return GetWithCas<object>(key);
	}

	public CasResult<T> GetWithCas<T>(string key)
	{
		if (!TryGetWithCas(key, out var tmp))
		{
			CasResult<T> result = default(CasResult<T>);
			result.Cas = tmp.Cas;
			result.Result = default(T);
			return result;
		}
		CasResult<T> result2 = default(CasResult<T>);
		result2.Cas = tmp.Cas;
		result2.Result = (T)tmp.Result;
		return result2;
	}

	public bool TryGetWithCas(string key, out CasResult<object> value)
	{
		ulong cas;
		object tmp;
		IGetOperationResult retval = PerformTryGet(key, out cas, out tmp);
		value = new CasResult<object>
		{
			Cas = cas,
			Result = tmp
		};
		return retval.Success;
	}

	protected virtual IGetOperationResult PerformTryGet(string key, out ulong cas, out object value)
	{
		string hashedKey = keyTransformer.Transform(key);
		IMemcachedNode node = pool.Locate(hashedKey);
		IGetOperationResult result = GetOperationResultFactory.Create();
		cas = 0uL;
		value = null;
		if (node != null)
		{
			IGetOperation command = pool.OperationFactory.Get(hashedKey);
			IOperationResult commandResult = node.Execute(command);
			if (commandResult.Success)
			{
				result.Value = (value = transcoder.Deserialize(command.Result));
				result.Cas = (cas = command.CasValue);
				if (performanceMonitor != null)
				{
					performanceMonitor.Get(1, success: true);
				}
				result.Pass();
				return result;
			}
			commandResult.Combine(result);
			return result;
		}
		result.Value = value;
		result.Cas = cas;
		if (performanceMonitor != null)
		{
			performanceMonitor.Get(1, success: false);
		}
		result.Fail("Unable to locate node");
		return result;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <remarks>The item does not expire unless it is removed due memory pressure.</remarks>
	/// <returns>true if the item was successfully stored in the cache; false otherwise.</returns>
	public bool Store(StoreMode mode, string key, object value)
	{
		ulong tmp = 0uL;
		int status;
		return PerformStore(mode, key, value, 0u, ref tmp, out status).Success;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <returns>true if the item was successfully stored in the cache; false otherwise.</returns>
	public bool Store(StoreMode mode, string key, object value, TimeSpan validFor)
	{
		ulong tmp = 0uL;
		int status;
		return PerformStore(mode, key, value, GetExpiration(validFor, null), ref tmp, out status).Success;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <returns>true if the item was successfully stored in the cache; false otherwise.</returns>
	public bool Store(StoreMode mode, string key, object value, DateTime expiresAt)
	{
		ulong tmp = 0uL;
		int status;
		return PerformStore(mode, key, value, GetExpiration(null, expiresAt), ref tmp, out status).Success;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <remarks>The item does not expire unless it is removed due memory pressure.</remarks>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public CasResult<bool> Cas(StoreMode mode, string key, object value, ulong cas)
	{
		IStoreOperationResult result = PerformStore(mode, key, value, 0u, cas);
		CasResult<bool> result2 = default(CasResult<bool>);
		result2.Cas = result.Cas;
		result2.Result = result.Success;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public CasResult<bool> Cas(StoreMode mode, string key, object value, TimeSpan validFor, ulong cas)
	{
		IStoreOperationResult result = PerformStore(mode, key, value, GetExpiration(validFor, null), cas);
		CasResult<bool> result2 = default(CasResult<bool>);
		result2.Cas = result.Cas;
		result2.Result = result.Success;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public CasResult<bool> Cas(StoreMode mode, string key, object value, DateTime expiresAt, ulong cas)
	{
		IStoreOperationResult result = PerformStore(mode, key, value, GetExpiration(null, expiresAt), cas);
		CasResult<bool> result2 = default(CasResult<bool>);
		result2.Cas = result.Cas;
		result2.Result = result.Success;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <remarks>The item does not expire unless it is removed due memory pressure. The text protocol does not support this operation, you need to Store then GetWithCas.</remarks>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public CasResult<bool> Cas(StoreMode mode, string key, object value)
	{
		IStoreOperationResult result = PerformStore(mode, key, value, 0u, 0uL);
		CasResult<bool> result2 = default(CasResult<bool>);
		result2.Cas = result.Cas;
		result2.Result = result.Success;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	private IStoreOperationResult PerformStore(StoreMode mode, string key, object value, uint expires, ulong cas)
	{
		ulong tmp = cas;
		int status;
		IStoreOperationResult retval = PerformStore(mode, key, value, expires, ref tmp, out status);
		retval.StatusCode = status;
		if (retval.Success)
		{
			retval.Cas = tmp;
		}
		return retval;
	}

	protected virtual IStoreOperationResult PerformStore(StoreMode mode, string key, object value, uint expires, ref ulong cas, out int statusCode)
	{
		string hashedKey = keyTransformer.Transform(key);
		IMemcachedNode node = pool.Locate(hashedKey);
		IStoreOperationResult result = StoreOperationResultFactory.Create();
		statusCode = -1;
		if (node != null)
		{
			CacheItem item;
			try
			{
				item = transcoder.Serialize(value);
			}
			catch (Exception e)
			{
				log.Error(e);
				if (performanceMonitor != null)
				{
					performanceMonitor.Store(mode, 1, success: false);
				}
				result.Fail("PerformStore failed", e);
				return result;
			}
			IStoreOperation command = pool.OperationFactory.Store(mode, hashedKey, item, expires, cas);
			IOperationResult commandResult = node.Execute(command);
			result.Cas = (cas = command.CasValue);
			result.StatusCode = (statusCode = command.StatusCode);
			if (commandResult.Success)
			{
				if (performanceMonitor != null)
				{
					performanceMonitor.Store(mode, 1, success: true);
				}
				result.Pass();
				return result;
			}
			commandResult.Combine(result);
			return result;
		}
		if (performanceMonitor != null)
		{
			performanceMonitor.Store(mode, 1, success: false);
		}
		result.Fail("Unable to locate node");
		return result;
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public ulong Increment(string key, ulong defaultValue, ulong delta)
	{
		return PerformMutate(MutationMode.Increment, key, defaultValue, delta, 0u).Value;
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public ulong Increment(string key, ulong defaultValue, ulong delta, TimeSpan validFor)
	{
		return PerformMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(validFor, null)).Value;
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public ulong Increment(string key, ulong defaultValue, ulong delta, DateTime expiresAt)
	{
		return PerformMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(null, expiresAt)).Value;
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public CasResult<ulong> Increment(string key, ulong defaultValue, ulong delta, ulong cas)
	{
		IMutateOperationResult result = CasMutate(MutationMode.Increment, key, defaultValue, delta, 0u, cas);
		CasResult<ulong> result2 = default(CasResult<ulong>);
		result2.Cas = result.Cas;
		result2.Result = result.Value;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public CasResult<ulong> Increment(string key, ulong defaultValue, ulong delta, TimeSpan validFor, ulong cas)
	{
		IMutateOperationResult result = CasMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(validFor, null), cas);
		CasResult<ulong> result2 = default(CasResult<ulong>);
		result2.Cas = result.Cas;
		result2.Result = result.Value;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public CasResult<ulong> Increment(string key, ulong defaultValue, ulong delta, DateTime expiresAt, ulong cas)
	{
		IMutateOperationResult result = CasMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(null, expiresAt), cas);
		CasResult<ulong> result2 = default(CasResult<ulong>);
		result2.Cas = result.Cas;
		result2.Result = result.Value;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public ulong Decrement(string key, ulong defaultValue, ulong delta)
	{
		return PerformMutate(MutationMode.Decrement, key, defaultValue, delta, 0u).Value;
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public ulong Decrement(string key, ulong defaultValue, ulong delta, TimeSpan validFor)
	{
		return PerformMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(validFor, null)).Value;
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public ulong Decrement(string key, ulong defaultValue, ulong delta, DateTime expiresAt)
	{
		return PerformMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(null, expiresAt)).Value;
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public CasResult<ulong> Decrement(string key, ulong defaultValue, ulong delta, ulong cas)
	{
		IMutateOperationResult result = CasMutate(MutationMode.Decrement, key, defaultValue, delta, 0u, cas);
		CasResult<ulong> result2 = default(CasResult<ulong>);
		result2.Cas = result.Cas;
		result2.Result = result.Value;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public CasResult<ulong> Decrement(string key, ulong defaultValue, ulong delta, TimeSpan validFor, ulong cas)
	{
		IMutateOperationResult result = CasMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(validFor, null), cas);
		CasResult<ulong> result2 = default(CasResult<ulong>);
		result2.Cas = result.Cas;
		result2.Result = result.Value;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public CasResult<ulong> Decrement(string key, ulong defaultValue, ulong delta, DateTime expiresAt, ulong cas)
	{
		IMutateOperationResult result = CasMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(null, expiresAt), cas);
		CasResult<ulong> result2 = default(CasResult<ulong>);
		result2.Cas = result.Cas;
		result2.Result = result.Value;
		result2.StatusCode = result.StatusCode.Value;
		return result2;
	}

	private IMutateOperationResult PerformMutate(MutationMode mode, string key, ulong defaultValue, ulong delta, uint expires)
	{
		ulong tmp = 0uL;
		return PerformMutate(mode, key, defaultValue, delta, expires, ref tmp);
	}

	private IMutateOperationResult CasMutate(MutationMode mode, string key, ulong defaultValue, ulong delta, uint expires, ulong cas)
	{
		ulong tmp = cas;
		IMutateOperationResult retval = PerformMutate(mode, key, defaultValue, delta, expires, ref tmp);
		retval.Cas = tmp;
		return retval;
	}

	protected virtual IMutateOperationResult PerformMutate(MutationMode mode, string key, ulong defaultValue, ulong delta, uint expires, ref ulong cas)
	{
		string hashedKey = keyTransformer.Transform(key);
		IMemcachedNode node = pool.Locate(hashedKey);
		IMutateOperationResult result = MutateOperationResultFactory.Create();
		if (node != null)
		{
			IMutatorOperation command = pool.OperationFactory.Mutate(mode, hashedKey, defaultValue, delta, expires, cas);
			IOperationResult commandResult = node.Execute(command);
			result.Cas = (cas = command.CasValue);
			result.StatusCode = command.StatusCode;
			if (commandResult.Success)
			{
				if (performanceMonitor != null)
				{
					performanceMonitor.Mutate(mode, 1, commandResult.Success);
				}
				result.Value = command.Result;
				result.Pass();
				return result;
			}
			if (performanceMonitor != null)
			{
				performanceMonitor.Mutate(mode, 1, success: false);
			}
			result.InnerResult = commandResult;
			result.Fail("Mutate operation failed, see InnerResult or StatusCode for more details");
		}
		if (performanceMonitor != null)
		{
			performanceMonitor.Mutate(mode, 1, success: false);
		}
		result.Fail("Unable to locate node");
		return result;
	}

	/// <summary>
	/// Appends the data to the end of the specified item's data on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="data">The data to be appended to the item.</param>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public bool Append(string key, ArraySegment<byte> data)
	{
		ulong cas = 0uL;
		return PerformConcatenate(ConcatenationMode.Append, key, ref cas, data).Success;
	}

	/// <summary>
	/// Inserts the data before the specified item's data on the server.
	/// </summary>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public bool Prepend(string key, ArraySegment<byte> data)
	{
		ulong cas = 0uL;
		return PerformConcatenate(ConcatenationMode.Prepend, key, ref cas, data).Success;
	}

	/// <summary>
	/// Appends the data to the end of the specified item's data on the server, but only if the item's version matches the CAS value provided.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <param name="data">The data to be prepended to the item.</param>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public CasResult<bool> Append(string key, ulong cas, ArraySegment<byte> data)
	{
		ulong tmp = cas;
		IConcatOperationResult success = PerformConcatenate(ConcatenationMode.Append, key, ref tmp, data);
		CasResult<bool> result = default(CasResult<bool>);
		result.Cas = tmp;
		result.Result = success.Success;
		return result;
	}

	/// <summary>
	/// Inserts the data before the specified item's data on the server, but only if the item's version matches the CAS value provided.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <param name="data">The data to be prepended to the item.</param>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public CasResult<bool> Prepend(string key, ulong cas, ArraySegment<byte> data)
	{
		ulong tmp = cas;
		IConcatOperationResult success = PerformConcatenate(ConcatenationMode.Prepend, key, ref tmp, data);
		CasResult<bool> result = default(CasResult<bool>);
		result.Cas = tmp;
		result.Result = success.Success;
		return result;
	}

	protected virtual IConcatOperationResult PerformConcatenate(ConcatenationMode mode, string key, ref ulong cas, ArraySegment<byte> data)
	{
		string hashedKey = keyTransformer.Transform(key);
		IMemcachedNode node = pool.Locate(hashedKey);
		IConcatOperationResult result = ConcatOperationResultFactory.Create();
		if (node != null)
		{
			IConcatOperation command = pool.OperationFactory.Concat(mode, hashedKey, cas, data);
			IOperationResult commandResult = node.Execute(command);
			if (commandResult.Success)
			{
				result.Cas = (cas = command.CasValue);
				result.StatusCode = command.StatusCode;
				if (performanceMonitor != null)
				{
					performanceMonitor.Concatenate(mode, 1, success: true);
				}
				result.Pass();
			}
			else
			{
				result.InnerResult = commandResult;
				result.Fail("Concat operation failed, see InnerResult or StatusCode for details");
			}
			return result;
		}
		if (performanceMonitor != null)
		{
			performanceMonitor.Concatenate(mode, 1, success: false);
		}
		result.Fail("Unable to locate node");
		return result;
	}

	/// <summary>
	/// Removes all data from the cache. Note: this will invalidate all data on all servers in the pool.
	/// </summary>
	public void FlushAll()
	{
		foreach (IMemcachedNode node in pool.GetWorkingNodes())
		{
			IFlushOperation command = pool.OperationFactory.Flush();
			node.Execute(command);
		}
	}

	/// <summary>
	/// Returns statistics about the servers.
	/// </summary>
	/// <returns></returns>
	public ServerStats Stats()
	{
		return Stats(null);
	}

	public ServerStats Stats(string type)
	{
		Dictionary<IPEndPoint, Dictionary<string, string>> results = new Dictionary<IPEndPoint, Dictionary<string, string>>();
		List<WaitHandle> handles = new List<WaitHandle>();
		foreach (IMemcachedNode node in pool.GetWorkingNodes())
		{
			IStatsOperation cmd = pool.OperationFactory.Stats(type);
			Func<IOperation, IOperationResult> action = node.Execute;
			ManualResetEvent mre = new ManualResetEvent(initialState: false);
			handles.Add(mre);
			action.BeginInvoke(cmd, delegate(IAsyncResult iar)
			{
				using (iar.AsyncWaitHandle)
				{
					action.EndInvoke(iar);
					lock (results)
					{
						results[((IMemcachedNode)iar.AsyncState).EndPoint] = cmd.Result;
					}
					mre.Set();
				}
			}, node);
		}
		if (handles.Count > 0)
		{
			SafeWaitAllAndDispose(handles.ToArray());
		}
		return new ServerStats(results);
	}

	/// <summary>
	/// Removes the specified item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to delete.</param>
	/// <returns>true if the item was successfully removed from the cache; false otherwise.</returns>
	public bool Remove(string key)
	{
		return ExecuteRemove(key).Success;
	}

	/// <summary>
	/// Retrieves multiple items from the cache.
	/// </summary>
	/// <param name="keys">The list of identifiers for the items to retrieve.</param>
	/// <returns>a Dictionary holding all items indexed by their key.</returns>
	public IDictionary<string, object> Get(IEnumerable<string> keys)
	{
		return PerformMultiGet(keys, (IMultiGetOperation mget, KeyValuePair<string, CacheItem> kvp) => transcoder.Deserialize(kvp.Value));
	}

	public IDictionary<string, CasResult<object>> GetWithCas(IEnumerable<string> keys)
	{
		return PerformMultiGet(keys, delegate(IMultiGetOperation mget, KeyValuePair<string, CacheItem> kvp)
		{
			CasResult<object> result = default(CasResult<object>);
			result.Result = transcoder.Deserialize(kvp.Value);
			result.Cas = mget.Cas[kvp.Key];
			return result;
		});
	}

	protected virtual IDictionary<string, T> PerformMultiGet<T>(IEnumerable<string> keys, Func<IMultiGetOperation, KeyValuePair<string, CacheItem>, T> collector)
	{
		Dictionary<string, string> hashed = new Dictionary<string, string>();
		foreach (string key in keys)
		{
			hashed[keyTransformer.Transform(key)] = key;
		}
		Dictionary<IMemcachedNode, IList<string>> byServer = GroupByServer(hashed.Keys);
		Dictionary<string, T> retval = new Dictionary<string, T>(hashed.Count);
		List<WaitHandle> handles = new List<WaitHandle>();
		foreach (KeyValuePair<IMemcachedNode, IList<string>> slice in byServer)
		{
			IMemcachedNode node = slice.Key;
			IList<string> nodeKeys = slice.Value;
			IMultiGetOperation mget = pool.OperationFactory.MultiGet(nodeKeys);
			Func<IOperation, IOperationResult> action = node.Execute;
			ManualResetEvent mre = new ManualResetEvent(initialState: false);
			handles.Add(mre);
			action.BeginInvoke(mget, delegate(IAsyncResult iar)
			{
				try
				{
					using (iar.AsyncWaitHandle)
					{
						if (action.EndInvoke(iar).Success)
						{
							if (performanceMonitor != null)
							{
								string[] array = (string[])iar.AsyncState;
								int num = array.Length;
								int count = mget.Result.Count;
								performanceMonitor.Get(count, success: true);
								if (count != num)
								{
									performanceMonitor.Get(num - count, success: true);
								}
							}
							{
								foreach (KeyValuePair<string, CacheItem> current in mget.Result)
								{
									if (hashed.TryGetValue(current.Key, out var value))
									{
										T value2 = collector(mget, current);
										lock (retval)
										{
											retval[value] = value2;
										}
									}
								}
								return;
							}
						}
					}
				}
				catch (Exception message)
				{
					log.Error(message);
				}
				finally
				{
					mre.Set();
				}
			}, nodeKeys);
		}
		if (handles.Count > 0)
		{
			SafeWaitAllAndDispose(handles.ToArray());
		}
		return retval;
	}

	protected Dictionary<IMemcachedNode, IList<string>> GroupByServer(IEnumerable<string> keys)
	{
		Dictionary<IMemcachedNode, IList<string>> retval = new Dictionary<IMemcachedNode, IList<string>>();
		foreach (string i in keys)
		{
			IMemcachedNode node = pool.Locate(i);
			if (node != null)
			{
				if (!retval.TryGetValue(node, out var list))
				{
					list = (retval[node] = new List<string>(4));
				}
				list.Add(i);
			}
		}
		return retval;
	}

	/// <summary>
	/// Waits for all WaitHandles and works in both STA and MTA mode.
	/// </summary>
	/// <param name="waitHandles"></param>
	private static void SafeWaitAllAndDispose(WaitHandle[] waitHandles)
	{
		try
		{
			if (Thread.CurrentThread.GetApartmentState() == ApartmentState.MTA)
			{
				WaitHandle.WaitAll(waitHandles);
				return;
			}
			for (int j = 0; j < waitHandles.Length; j++)
			{
				waitHandles[j].WaitOne();
			}
		}
		finally
		{
			for (int i = 0; i < waitHandles.Length; i++)
			{
				waitHandles[i].Close();
			}
		}
	}

	protected static uint GetExpiration(TimeSpan? validFor, DateTime? expiresAt)
	{
		if (validFor.HasValue && expiresAt.HasValue)
		{
			throw new ArgumentException("You cannot specify both validFor and expiresAt.");
		}
		if (validFor.HasValue)
		{
			if (validFor == TimeSpan.Zero || validFor == TimeSpan.MaxValue)
			{
				return 0u;
			}
			expiresAt = DateTime.Now.Add(validFor.Value);
		}
		DateTime dt = expiresAt.Value;
		if (dt < UnixEpoch)
		{
			throw new ArgumentOutOfRangeException("expiresAt", "expiresAt must be >= 1970/1/1");
		}
		if (dt == DateTime.MaxValue)
		{
			return 0u;
		}
		return (uint)(dt.ToUniversalTime() - UnixEpoch).TotalSeconds;
	}

	~MemcachedClient()
	{
		try
		{
			((IDisposable)this).Dispose();
		}
		catch
		{
		}
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	/// <summary>
	/// Releases all resources allocated by this instance
	/// </summary>
	/// <remarks>You should only call this when you are not using static instances of the client, so it can close all conections and release the sockets.</remarks>
	public void Dispose()
	{
		GC.SuppressFinalize(this);
		if (pool != null)
		{
			try
			{
				pool.Dispose();
			}
			finally
			{
				pool = null;
			}
		}
		if (performanceMonitor != null)
		{
			try
			{
				performanceMonitor.Dispose();
			}
			finally
			{
				performanceMonitor = null;
			}
		}
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <remarks>The item does not expire unless it is removed due memory pressure.</remarks>
	/// <returns>true if the item was successfully stored in the cache; false otherwise.</returns>
	public IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value)
	{
		ulong tmp = 0uL;
		int status;
		return PerformStore(mode, key, value, 0u, ref tmp, out status);
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <returns>true if the item was successfully stored in the cache; false otherwise.</returns>
	public IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, TimeSpan validFor)
	{
		ulong tmp = 0uL;
		int status;
		return PerformStore(mode, key, value, GetExpiration(validFor, null), ref tmp, out status);
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <returns>true if the item was successfully stored in the cache; false otherwise.</returns>
	public IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, DateTime expiresAt)
	{
		ulong tmp = 0uL;
		int status;
		return PerformStore(mode, key, value, GetExpiration(null, expiresAt), ref tmp, out status);
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <remarks>The item does not expire unless it is removed due memory pressure. The text protocol does not support this operation, you need to Store then GetWithCas.</remarks>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public IStoreOperationResult ExecuteCas(StoreMode mode, string key, object value)
	{
		return PerformStore(mode, key, value, 0u, 0uL);
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <remarks>The item does not expire unless it is removed due memory pressure.</remarks>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public IStoreOperationResult ExecuteCas(StoreMode mode, string key, object value, ulong cas)
	{
		return PerformStore(mode, key, value, 0u, cas);
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public IStoreOperationResult ExecuteCas(StoreMode mode, string key, object value, TimeSpan validFor, ulong cas)
	{
		return PerformStore(mode, key, value, GetExpiration(validFor, null), cas);
	}

	/// <summary>
	/// Inserts an item into the cache with a cache key to reference its location and returns its version.
	/// </summary>
	/// <param name="mode">Defines how the item is stored in the cache.</param>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="value">The object to be inserted into the cache.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>A CasResult object containing the version of the item and the result of the operation (true if the item was successfully stored in the cache; false otherwise).</returns>
	public IStoreOperationResult ExecuteCas(StoreMode mode, string key, object value, DateTime expiresAt, ulong cas)
	{
		return PerformStore(mode, key, value, GetExpiration(null, expiresAt), cas);
	}

	/// <summary>
	/// Retrieves the specified item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to retrieve.</param>
	/// <returns>The retrieved item, or <value>null</value> if the key was not found.</returns>
	public IGetOperationResult ExecuteGet(string key)
	{
		object tmp;
		return ExecuteTryGet(key, out tmp);
	}

	/// <summary>
	/// Tries to get an item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to retrieve.</param>
	/// <param name="value">The retrieved item or null if not found.</param>
	/// <returns>The <value>true</value> if the item was successfully retrieved.</returns>
	public IGetOperationResult ExecuteTryGet(string key, out object value)
	{
		ulong cas = 0uL;
		return PerformTryGet(key, out cas, out value);
	}

	/// <summary>
	/// Retrieves the specified item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to retrieve.</param>
	/// <returns>The retrieved item, or <value>default(T)</value> if the key was not found.</returns>
	public IGetOperationResult<T> ExecuteGet<T>(string key)
	{
		IGetOperationResult<T> result = new DefaultGetOperationResultFactory<T>().Create();
		object tmp;
		IGetOperationResult tryGetResult = ExecuteTryGet(key, out tmp);
		if (tryGetResult.Success)
		{
			if (tryGetResult.Value is T)
			{
				tryGetResult.Copy(result);
				result.Value = (T)tmp;
				result.Cas = tryGetResult.Cas;
			}
			else
			{
				result.Value = default(T);
				result.Fail("Type mismatch", new InvalidCastException());
			}
			return result;
		}
		tryGetResult.Combine(result);
		return result;
	}

	/// <summary>
	/// Retrieves multiple items from the cache.
	/// </summary>
	/// <param name="keys">The list of identifiers for the items to retrieve.</param>
	/// <returns>a Dictionary holding all items indexed by their key.</returns>
	public IDictionary<string, IGetOperationResult> ExecuteGet(IEnumerable<string> keys)
	{
		return PerformMultiGet(keys, delegate(IMultiGetOperation mget, KeyValuePair<string, CacheItem> kvp)
		{
			IGetOperationResult getOperationResult = GetOperationResultFactory.Create();
			getOperationResult.Value = transcoder.Deserialize(kvp.Value);
			getOperationResult.Cas = mget.Cas[kvp.Key];
			getOperationResult.Success = true;
			return getOperationResult;
		});
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteIncrement(string key, ulong defaultValue, ulong delta)
	{
		return PerformMutate(MutationMode.Increment, key, defaultValue, delta, 0u);
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteIncrement(string key, ulong defaultValue, ulong delta, TimeSpan validFor)
	{
		return PerformMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(validFor, null));
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteIncrement(string key, ulong defaultValue, ulong delta, DateTime expiresAt)
	{
		return PerformMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(null, expiresAt));
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteIncrement(string key, ulong defaultValue, ulong delta, ulong cas)
	{
		return CasMutate(MutationMode.Increment, key, defaultValue, delta, 0u, cas);
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteIncrement(string key, ulong defaultValue, ulong delta, TimeSpan validFor, ulong cas)
	{
		return CasMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(validFor, null), cas);
	}

	/// <summary>
	/// Increments the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to increase the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteIncrement(string key, ulong defaultValue, ulong delta, DateTime expiresAt, ulong cas)
	{
		return CasMutate(MutationMode.Increment, key, defaultValue, delta, GetExpiration(null, expiresAt), cas);
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteDecrement(string key, ulong defaultValue, ulong delta)
	{
		return PerformMutate(MutationMode.Decrement, key, defaultValue, delta, 0u);
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteDecrement(string key, ulong defaultValue, ulong delta, TimeSpan validFor)
	{
		return PerformMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(validFor, null));
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteDecrement(string key, ulong defaultValue, ulong delta, DateTime expiresAt)
	{
		return PerformMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(null, expiresAt));
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteDecrement(string key, ulong defaultValue, ulong delta, ulong cas)
	{
		return CasMutate(MutationMode.Decrement, key, defaultValue, delta, 0u, cas);
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="validFor">The interval after the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteDecrement(string key, ulong defaultValue, ulong delta, TimeSpan validFor, ulong cas)
	{
		return CasMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(validFor, null), cas);
	}

	/// <summary>
	/// Decrements the value of the specified key by the given amount, but only if the item's version matches the CAS value provided. The operation is atomic and happens on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="defaultValue">The value which will be stored by the server if the specified item was not found.</param>
	/// <param name="delta">The amount by which the client wants to decrease the item.</param>
	/// <param name="expiresAt">The time when the item is invalidated in the cache.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <returns>The new value of the item or defaultValue if the key was not found.</returns>
	/// <remarks>If the client uses the Text protocol, the item must be inserted into the cache before it can be changed. It must be inserted as a <see cref="T:System.String" />. Moreover the Text protocol only works with <see cref="T:System.UInt32" /> values, so return value -1 always indicates that the item was not found.</remarks>
	public IMutateOperationResult ExecuteDecrement(string key, ulong defaultValue, ulong delta, DateTime expiresAt, ulong cas)
	{
		return CasMutate(MutationMode.Decrement, key, defaultValue, delta, GetExpiration(null, expiresAt), cas);
	}

	/// <summary>
	/// Appends the data to the end of the specified item's data on the server.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="data">The data to be appended to the item.</param>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public IConcatOperationResult ExecuteAppend(string key, ArraySegment<byte> data)
	{
		ulong cas = 0uL;
		return PerformConcatenate(ConcatenationMode.Append, key, ref cas, data);
	}

	/// <summary>
	/// Appends the data to the end of the specified item's data on the server, but only if the item's version matches the CAS value provided.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <param name="data">The data to be prepended to the item.</param>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public IConcatOperationResult ExecuteAppend(string key, ulong cas, ArraySegment<byte> data)
	{
		ulong tmp = cas;
		IConcatOperationResult result = PerformConcatenate(ConcatenationMode.Append, key, ref tmp, data);
		if (result.Success)
		{
			result.Cas = tmp;
		}
		return result;
	}

	/// <summary>
	/// Inserts the data before the specified item's data on the server.
	/// </summary>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public IConcatOperationResult ExecutePrepend(string key, ArraySegment<byte> data)
	{
		ulong cas = 0uL;
		return PerformConcatenate(ConcatenationMode.Prepend, key, ref cas, data);
	}

	/// <summary>
	/// Inserts the data before the specified item's data on the server, but only if the item's version matches the CAS value provided.
	/// </summary>
	/// <param name="key">The key used to reference the item.</param>
	/// <param name="cas">The cas value which must match the item's version.</param>
	/// <param name="data">The data to be prepended to the item.</param>
	/// <returns>true if the data was successfully stored; false otherwise.</returns>
	public IConcatOperationResult ExecutePrepend(string key, ulong cas, ArraySegment<byte> data)
	{
		ulong tmp = cas;
		IConcatOperationResult result = PerformConcatenate(ConcatenationMode.Prepend, key, ref tmp, data);
		if (result.Success)
		{
			result.Cas = tmp;
		}
		return result;
	}

	/// <summary>
	/// Removes the specified item from the cache.
	/// </summary>
	/// <param name="key">The identifier for the item to delete.</param>
	/// <returns>true if the item was successfully removed from the cache; false otherwise.</returns>
	public IRemoveOperationResult ExecuteRemove(string key)
	{
		string hashedKey = keyTransformer.Transform(key);
		IMemcachedNode node = pool.Locate(hashedKey);
		IRemoveOperationResult result = RemoveOperationResultFactory.Create();
		if (node != null)
		{
			IDeleteOperation command = pool.OperationFactory.Delete(hashedKey, 0uL);
			IOperationResult commandResult = node.Execute(command);
			if (commandResult.Success)
			{
				result.Pass();
			}
			else
			{
				result.InnerResult = commandResult;
				result.Fail("Failed to remove item, see InnerResult or StatusCode for details");
			}
			return result;
		}
		result.Fail("Unable to locate node");
		return result;
	}
}

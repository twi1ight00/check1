using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;
using Enyim.Collections;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Represents a Memcached node in the pool.
/// </summary>
[DebuggerDisplay("{{MemcachedNode [ Address: {EndPoint}, IsAlive = {IsAlive} ]}}")]
public class MemcachedNode : IMemcachedNode, IDisposable
{
	private class InternalPoolImpl : IDisposable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(InternalPoolImpl).FullName.Replace("+", "."));

		/// <summary>
		/// A list of already connected but free to use sockets
		/// </summary>
		private InterlockedStack<PooledSocket> freeItems;

		private bool isDisposed;

		private bool isAlive;

		private DateTime markedAsDeadUtc;

		private int minItems;

		private int maxItems;

		private MemcachedNode ownerNode;

		private IPEndPoint endPoint;

		private TimeSpan queueTimeout;

		private Semaphore semaphore;

		private object initLock = new object();

		public bool IsAlive => isAlive;

		public DateTime MarkedAsDeadUtc => markedAsDeadUtc;

		internal InternalPoolImpl(MemcachedNode ownerNode, ISocketPoolConfiguration config)
		{
			if (config.MinPoolSize < 0)
			{
				throw new InvalidOperationException("minItems must be larger >= 0", null);
			}
			if (config.MaxPoolSize < config.MinPoolSize)
			{
				throw new InvalidOperationException("maxItems must be larger than minItems", null);
			}
			if (config.QueueTimeout < TimeSpan.Zero)
			{
				throw new InvalidOperationException("queueTimeout must be >= TimeSpan.Zero", null);
			}
			this.ownerNode = ownerNode;
			isAlive = true;
			endPoint = ownerNode.EndPoint;
			queueTimeout = config.QueueTimeout;
			minItems = config.MinPoolSize;
			maxItems = config.MaxPoolSize;
			semaphore = new Semaphore(maxItems, maxItems);
			freeItems = new InterlockedStack<PooledSocket>();
		}

		internal void InitPool()
		{
			try
			{
				if (minItems > 0)
				{
					for (int i = 0; i < minItems; i++)
					{
						freeItems.Push(CreateSocket());
						if (!isAlive)
						{
							break;
						}
					}
				}
				if (log.IsDebugEnabled)
				{
					log.DebugFormat("Pool has been inited for {0} with {1} sockets", endPoint, minItems);
				}
			}
			catch (Exception e)
			{
				log.Error("Could not init pool.", e);
				MarkAsDead();
			}
		}

		private PooledSocket CreateSocket()
		{
			PooledSocket ps = ownerNode.CreateSocket();
			ps.CleanupCallback = ReleaseSocket;
			return ps;
		}

		/// <summary>
		/// Acquires a new item from the pool
		/// </summary>
		/// <returns>An <see cref="T:PooledSocket" /> instance which is connected to the memcached server, or <value>null</value> if the pool is dead.</returns>
		public IPooledSocketResult Acquire()
		{
			PooledSocketResult result = new PooledSocketResult();
			string message = string.Empty;
			bool hasDebug = log.IsDebugEnabled;
			if (hasDebug)
			{
				log.Debug("Acquiring stream from pool. " + endPoint);
			}
			if (!isAlive || isDisposed)
			{
				message = "Pool is dead or disposed, returning null. " + endPoint;
				result.Fail(message);
				if (hasDebug)
				{
					log.Debug(message);
				}
				return result;
			}
			PooledSocket retval = null;
			if (!semaphore.WaitOne(queueTimeout))
			{
				message = "Pool is full, timeouting. " + endPoint;
				if (hasDebug)
				{
					log.Debug(message);
				}
				result.Fail(message, new TimeoutException());
				return result;
			}
			if (!isAlive)
			{
				message = "Pool is dead, returning null. " + endPoint;
				if (hasDebug)
				{
					log.Debug(message);
				}
				result.Fail(message);
				return result;
			}
			if (freeItems.TryPop(out retval))
			{
				try
				{
					retval.Reset();
					message = "Socket was reset. " + retval.InstanceId;
					if (hasDebug)
					{
						log.Debug(message);
					}
					result.Pass(message);
					result.Value = retval;
					return result;
				}
				catch (Exception e2)
				{
					message = "Failed to reset an acquired socket.";
					log.Error(message, e2);
					MarkAsDead();
					result.Fail(message, e2);
					return result;
				}
			}
			message = "Could not get a socket from the pool, Creating a new item. " + endPoint;
			if (hasDebug)
			{
				log.Debug(message);
			}
			try
			{
				retval = CreateSocket();
				result.Value = retval;
				result.Pass();
			}
			catch (Exception e)
			{
				message = "Failed to create socket. " + endPoint;
				log.Error(message, e);
				semaphore.Release();
				MarkAsDead();
				result.Fail(message);
				return result;
			}
			if (hasDebug)
			{
				log.Debug("Done.");
			}
			return result;
		}

		private void MarkAsDead()
		{
			if (log.IsDebugEnabled)
			{
				log.DebugFormat("Mark as dead was requested for {0}", endPoint);
			}
			bool shouldFail = ownerNode.FailurePolicy.ShouldFail();
			if (log.IsDebugEnabled)
			{
				log.Debug("FailurePolicy.ShouldFail(): " + shouldFail);
			}
			if (shouldFail)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Marking node {0} as dead", endPoint);
				}
				isAlive = false;
				markedAsDeadUtc = DateTime.UtcNow;
				ownerNode.Failed?.Invoke(ownerNode);
			}
		}

		/// <summary>
		/// Releases an item back into the pool
		/// </summary>
		/// <param name="socket"></param>
		private void ReleaseSocket(PooledSocket socket)
		{
			if (log.IsDebugEnabled)
			{
				log.Debug("Releasing socket " + socket.InstanceId);
				log.Debug("Are we alive? " + isAlive);
			}
			if (isAlive)
			{
				if (socket.IsAlive)
				{
					freeItems.Push(socket);
					semaphore.Release();
				}
				else
				{
					socket.Destroy();
					MarkAsDead();
					semaphore.Release();
				}
			}
			else
			{
				socket.Destroy();
			}
		}

		~InternalPoolImpl()
		{
			try
			{
				((IDisposable)this).Dispose();
			}
			catch
			{
			}
		}

		/// <summary>
		/// Releases all resources allocated by this instance
		/// </summary>
		public void Dispose()
		{
			if (isDisposed)
			{
				return;
			}
			isAlive = false;
			isDisposed = true;
			PooledSocket ps;
			while (freeItems.TryPop(out ps))
			{
				try
				{
					ps.Destroy();
				}
				catch
				{
				}
			}
			ownerNode = null;
			semaphore.Close();
			semaphore = null;
			freeItems = null;
		}

		void IDisposable.Dispose()
		{
			Dispose();
		}
	}

	internal sealed class Comparer : IEqualityComparer<IMemcachedNode>
	{
		public static readonly Comparer Instance = new Comparer();

		bool IEqualityComparer<IMemcachedNode>.Equals(IMemcachedNode x, IMemcachedNode y)
		{
			return x.EndPoint.Equals(y.EndPoint);
		}

		int IEqualityComparer<IMemcachedNode>.GetHashCode(IMemcachedNode obj)
		{
			return obj.EndPoint.GetHashCode();
		}
	}

	private static readonly ILog log = LogManager.GetLogger(typeof(MemcachedNode));

	private static readonly object SyncRoot = new object();

	private bool isDisposed;

	private IPEndPoint endPoint;

	private ISocketPoolConfiguration config;

	private InternalPoolImpl internalPoolImpl;

	private bool isInitialized;

	private INodeFailurePolicy failurePolicy;

	protected INodeFailurePolicy FailurePolicy => failurePolicy ?? (failurePolicy = config.FailurePolicyFactory.Create(this));

	/// <summary>
	/// Gets the <see cref="T:IPEndPoint" /> of this instance
	/// </summary>
	public IPEndPoint EndPoint => endPoint;

	/// <summary>
	/// <para>Gets a value indicating whether the server is working or not. Returns a <b>cached</b> state.</para>
	/// <para>To get real-time information and update the cached state, use the <see cref="M:Ping" /> method.</para>
	/// </summary>
	/// <remarks>Used by the <see cref="T:ServerPool" /> to quickly check if the server's state is valid.</remarks>
	public bool IsAlive => internalPoolImpl.IsAlive;

	IPEndPoint IMemcachedNode.EndPoint => EndPoint;

	bool IMemcachedNode.IsAlive => IsAlive;

	public event Action<IMemcachedNode> Failed;

	event Action<IMemcachedNode> IMemcachedNode.Failed
	{
		add
		{
			Failed += value;
		}
		remove
		{
			Failed -= value;
		}
	}

	public MemcachedNode(IPEndPoint endpoint, ISocketPoolConfiguration socketPoolConfig)
	{
		endPoint = endpoint;
		config = socketPoolConfig;
		if (socketPoolConfig.ConnectionTimeout.TotalMilliseconds >= 2147483647.0)
		{
			throw new InvalidOperationException("ConnectionTimeout must be < Int32.MaxValue");
		}
		internalPoolImpl = new InternalPoolImpl(this, socketPoolConfig);
	}

	/// <summary>
	/// Gets a value indicating whether the server is working or not.
	///
	/// If the server is back online, we'll ercreate the internal socket pool and mark the server as alive so operations can target it.
	/// </summary>
	/// <returns>true if the server is alive; false otherwise.</returns>
	public bool Ping()
	{
		if (internalPoolImpl.IsAlive)
		{
			return true;
		}
		try
		{
			lock (SyncRoot)
			{
				if (isDisposed)
				{
					return false;
				}
				using (CreateSocket())
				{
				}
				if (internalPoolImpl.IsAlive)
				{
					return true;
				}
				InternalPoolImpl oldPool = internalPoolImpl;
				InternalPoolImpl newPool = new InternalPoolImpl(this, config);
				Interlocked.Exchange(ref internalPoolImpl, newPool);
				try
				{
					oldPool.Dispose();
				}
				catch
				{
				}
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	/// <summary>
	/// Acquires a new item from the pool
	/// </summary>
	/// <returns>An <see cref="T:PooledSocket" /> instance which is connected to the memcached server, or <value>null</value> if the pool is dead.</returns>
	public IPooledSocketResult Acquire()
	{
		if (!isInitialized)
		{
			lock (internalPoolImpl)
			{
				if (!isInitialized)
				{
					internalPoolImpl.InitPool();
					isInitialized = true;
				}
			}
		}
		try
		{
			return internalPoolImpl.Acquire();
		}
		catch (Exception e)
		{
			string message = "Acquire failed. Maybe we're already disposed?";
			log.Error(message, e);
			PooledSocketResult result = new PooledSocketResult();
			result.Fail(message, e);
			return result;
		}
	}

	~MemcachedNode()
	{
		try
		{
			((IDisposable)this).Dispose();
		}
		catch
		{
		}
	}

	/// <summary>
	/// Releases all resources allocated by this instance
	/// </summary>
	public void Dispose()
	{
		if (isDisposed)
		{
			return;
		}
		GC.SuppressFinalize(this);
		lock (SyncRoot)
		{
			if (!isDisposed)
			{
				isDisposed = true;
				internalPoolImpl.Dispose();
			}
		}
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	protected internal virtual PooledSocket CreateSocket()
	{
		return new PooledSocket(endPoint, config.ConnectionTimeout, config.ReceiveTimeout);
	}

	protected virtual IPooledSocketResult ExecuteOperation(IOperation op)
	{
		IPooledSocketResult result = Acquire();
		if (result.Success && result.HasValue)
		{
			try
			{
				PooledSocket socket = result.Value;
				IList<ArraySegment<byte>> b = op.GetBuffer();
				socket.Write(b);
				IOperationResult readResult = op.ReadResponse(socket);
				if (readResult.Success)
				{
					result.Pass();
				}
				else
				{
					readResult.Combine(result);
				}
				return result;
			}
			catch (IOException e)
			{
				log.Error(e);
				result.Fail("Exception reading response", e);
				return result;
			}
			finally
			{
				((IDisposable)result.Value).Dispose();
			}
		}
		result.Fail("Failed to obtain socket from pool");
		return result;
	}

	protected virtual bool ExecuteOperationAsync(IOperation op, Action<bool> next)
	{
		PooledSocket socket = Acquire().Value;
		if (socket == null)
		{
			return false;
		}
		IList<ArraySegment<byte>> b = op.GetBuffer();
		try
		{
			socket.Write(b);
			return op.ReadResponseAsync(socket, delegate(bool readSuccess)
			{
				((IDisposable)socket).Dispose();
				next(readSuccess);
			});
		}
		catch (IOException e)
		{
			log.Error(e);
			((IDisposable)socket).Dispose();
			return false;
		}
	}

	bool IMemcachedNode.Ping()
	{
		return Ping();
	}

	IOperationResult IMemcachedNode.Execute(IOperation op)
	{
		return ExecuteOperation(op);
	}

	bool IMemcachedNode.ExecuteAsync(IOperation op, Action<bool> next)
	{
		return ExecuteOperationAsync(op, next);
	}
}

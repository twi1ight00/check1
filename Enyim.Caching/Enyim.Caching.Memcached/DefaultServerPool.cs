using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Enyim.Caching.Configuration;

namespace Enyim.Caching.Memcached;

public class DefaultServerPool : IServerPool, IDisposable
{
	private static readonly ILog log = LogManager.GetLogger(typeof(DefaultServerPool));

	private IMemcachedNode[] allNodes;

	private IMemcachedClientConfiguration configuration;

	private IOperationFactory factory;

	private IMemcachedNodeLocator nodeLocator;

	private object DeadSync = new object();

	private Timer resurrectTimer;

	private bool isTimerActive;

	private long deadTimeoutMsec;

	private bool isDisposed;

	IOperationFactory IServerPool.OperationFactory => factory;

	private event Action<IMemcachedNode> nodeFailed;

	event Action<IMemcachedNode> IServerPool.NodeFailed
	{
		add
		{
			nodeFailed += value;
		}
		remove
		{
			nodeFailed -= value;
		}
	}

	public DefaultServerPool(IMemcachedClientConfiguration configuration, IOperationFactory opFactory)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("socketConfig");
		}
		if (opFactory == null)
		{
			throw new ArgumentNullException("opFactory");
		}
		this.configuration = configuration;
		factory = opFactory;
		deadTimeoutMsec = (long)this.configuration.SocketPool.DeadTimeout.TotalMilliseconds;
	}

	~DefaultServerPool()
	{
		try
		{
			((IDisposable)this).Dispose();
		}
		catch
		{
		}
	}

	protected virtual IMemcachedNode CreateNode(IPEndPoint endpoint)
	{
		return new MemcachedNode(endpoint, configuration.SocketPool);
	}

	private void rezCallback(object state)
	{
		bool isDebug = log.IsDebugEnabled;
		if (isDebug)
		{
			log.Debug("Checking the dead servers.");
		}
		lock (DeadSync)
		{
			if (isDisposed)
			{
				if (log.IsWarnEnabled)
				{
					log.Warn("IsAlive timer was triggered but the pool is already disposed. Ignoring.");
				}
				return;
			}
			IMemcachedNode[] nodes = allNodes;
			List<IMemcachedNode> aliveList = new List<IMemcachedNode>(nodes.Length);
			bool changed = false;
			int deadCount = 0;
			foreach (IMemcachedNode j in nodes)
			{
				if (j.IsAlive)
				{
					if (isDebug)
					{
						log.DebugFormat("Alive: {0}", j.EndPoint);
					}
					aliveList.Add(j);
					continue;
				}
				if (isDebug)
				{
					log.DebugFormat("Dead: {0}", j.EndPoint);
				}
				if (j.Ping())
				{
					changed = true;
					aliveList.Add(j);
					if (isDebug)
					{
						log.Debug("Ping ok.");
					}
				}
				else
				{
					if (isDebug)
					{
						log.Debug("Still dead.");
					}
					deadCount++;
				}
			}
			if (changed)
			{
				if (isDebug)
				{
					log.Debug("Reinitializing the locator.");
				}
				nodeLocator.Initialize(aliveList);
			}
			if (deadCount == 0)
			{
				if (isDebug)
				{
					log.Debug("deadCount == 0, stopping the timer.");
				}
				isTimerActive = false;
			}
			else
			{
				if (isDebug)
				{
					log.DebugFormat("deadCount == {0}, starting the timer.", deadCount);
				}
				resurrectTimer.Change(deadTimeoutMsec, -1L);
			}
		}
	}

	private void NodeFail(IMemcachedNode node)
	{
		bool isDebug = log.IsDebugEnabled;
		if (isDebug)
		{
			log.DebugFormat("Node {0} is dead.", node.EndPoint);
		}
		lock (DeadSync)
		{
			if (isDisposed)
			{
				if (log.IsWarnEnabled)
				{
					log.Warn("Got a node fail but the pool is already disposed. Ignoring.");
				}
				return;
			}
			this.nodeFailed?.Invoke(node);
			IMemcachedNodeLocator newLocator = configuration.CreateNodeLocator();
			newLocator.Initialize(allNodes.Where((IMemcachedNode n) => n.IsAlive).ToArray());
			Interlocked.Exchange(ref nodeLocator, newLocator);
			if (!isTimerActive)
			{
				if (isDebug)
				{
					log.Debug("Starting the recovery timer.");
				}
				if (resurrectTimer == null)
				{
					resurrectTimer = new Timer(rezCallback, null, deadTimeoutMsec, -1L);
				}
				else
				{
					resurrectTimer.Change(deadTimeoutMsec, -1L);
				}
				isTimerActive = true;
				if (isDebug)
				{
					log.Debug("Timer started.");
				}
			}
		}
	}

	IMemcachedNode IServerPool.Locate(string key)
	{
		return nodeLocator.Locate(key);
	}

	IEnumerable<IMemcachedNode> IServerPool.GetWorkingNodes()
	{
		return nodeLocator.GetWorkingNodes();
	}

	void IServerPool.Start()
	{
		allNodes = configuration.Servers.Select(delegate(IPEndPoint ip)
		{
			IMemcachedNode memcachedNode = CreateNode(ip);
			memcachedNode.Failed += NodeFail;
			return memcachedNode;
		}).ToArray();
		IMemcachedNodeLocator locator = configuration.CreateNodeLocator();
		locator.Initialize(allNodes);
		nodeLocator = locator;
	}

	void IDisposable.Dispose()
	{
		GC.SuppressFinalize(this);
		lock (DeadSync)
		{
			if (isDisposed)
			{
				return;
			}
			isDisposed = true;
			if (nodeLocator is IDisposable nd)
			{
				try
				{
					nd.Dispose();
				}
				catch (Exception e2)
				{
					if (log.IsErrorEnabled)
					{
						log.Error(e2);
					}
				}
			}
			nodeLocator = null;
			for (int i = 0; i < allNodes.Length; i++)
			{
				try
				{
					allNodes[i].Dispose();
				}
				catch (Exception e)
				{
					if (log.IsErrorEnabled)
					{
						log.Error(e);
					}
				}
			}
			if (resurrectTimer != null)
			{
				using (resurrectTimer)
				{
					resurrectTimer.Change(-1, -1);
				}
			}
			allNodes = null;
			resurrectTimer = null;
		}
	}
}

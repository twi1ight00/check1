using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Enyim.Caching.Memcached;

/// <summary>
/// This is a ketama-like consistent hashing based node locator. Used when no other <see cref="T:IMemcachedNodeLocator" /> is specified for the pool.
/// </summary>
public sealed class DefaultNodeLocator : IMemcachedNodeLocator, IDisposable
{
	private const int ServerAddressMutations = 100;

	private uint[] keys;

	private Dictionary<uint, IMemcachedNode> servers;

	private Dictionary<IMemcachedNode, bool> deadServers;

	private List<IMemcachedNode> allServers;

	private ReaderWriterLockSlim serverAccessLock;

	public DefaultNodeLocator()
	{
		servers = new Dictionary<uint, IMemcachedNode>(new UIntEqualityComparer());
		deadServers = new Dictionary<IMemcachedNode, bool>();
		allServers = new List<IMemcachedNode>();
		serverAccessLock = new ReaderWriterLockSlim();
	}

	private void BuildIndex(List<IMemcachedNode> nodes)
	{
		uint[] keys = new uint[nodes.Count * 100];
		int nodeIdx = 0;
		foreach (IMemcachedNode node in nodes)
		{
			uint[] tmpKeys = GenerateKeys(node, 100);
			for (int i = 0; i < tmpKeys.Length; i++)
			{
				servers[tmpKeys[i]] = node;
			}
			tmpKeys.CopyTo(keys, nodeIdx);
			nodeIdx += 100;
		}
		Array.Sort(keys);
		Interlocked.Exchange(ref this.keys, keys);
	}

	void IMemcachedNodeLocator.Initialize(IList<IMemcachedNode> nodes)
	{
		serverAccessLock.EnterWriteLock();
		try
		{
			allServers = nodes.ToList();
			BuildIndex(allServers);
		}
		finally
		{
			serverAccessLock.ExitWriteLock();
		}
	}

	IMemcachedNode IMemcachedNodeLocator.Locate(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		serverAccessLock.EnterUpgradeableReadLock();
		try
		{
			return Locate(key);
		}
		finally
		{
			serverAccessLock.ExitUpgradeableReadLock();
		}
	}

	IEnumerable<IMemcachedNode> IMemcachedNodeLocator.GetWorkingNodes()
	{
		serverAccessLock.EnterReadLock();
		try
		{
			return allServers.Except(deadServers.Keys).ToArray();
		}
		finally
		{
			serverAccessLock.ExitReadLock();
		}
	}

	private IMemcachedNode Locate(string key)
	{
		IMemcachedNode node = FindNode(key);
		if (node == null || node.IsAlive)
		{
			return node;
		}
		serverAccessLock.EnterWriteLock();
		try
		{
			if (!node.IsAlive)
			{
				deadServers[node] = true;
			}
			BuildIndex(allServers.Except(deadServers.Keys).ToList());
		}
		finally
		{
			serverAccessLock.ExitWriteLock();
		}
		return Locate(key);
	}

	/// <summary>
	/// locates a node by its key
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	private IMemcachedNode FindNode(string key)
	{
		if (keys.Length == 0)
		{
			return null;
		}
		uint itemKeyHash = BitConverter.ToUInt32(new FNV1a().ComputeHash(Encoding.UTF8.GetBytes(key)), 0);
		int foundIndex = Array.BinarySearch(keys, itemKeyHash);
		if (foundIndex < 0)
		{
			foundIndex = ~foundIndex;
			if (foundIndex == 0)
			{
				foundIndex = keys.Length - 1;
			}
			else if (foundIndex >= keys.Length)
			{
				foundIndex = 0;
			}
		}
		if (foundIndex < 0 || foundIndex > keys.Length)
		{
			return null;
		}
		return servers[keys[foundIndex]];
	}

	private static uint[] GenerateKeys(IMemcachedNode node, int numberOfKeys)
	{
		uint[] j = new uint[numberOfKeys];
		string address = node.EndPoint.ToString();
		FNV1a fnv = new FNV1a();
		for (int i = 0; i < numberOfKeys; i++)
		{
			byte[] data = fnv.ComputeHash(Encoding.ASCII.GetBytes(address + "-" + i));
			for (int h = 0; h < 1; h++)
			{
				j[i + h] = BitConverter.ToUInt32(data, h * 4);
			}
		}
		return j;
	}

	void IDisposable.Dispose()
	{
		using (serverAccessLock)
		{
			serverAccessLock.EnterWriteLock();
			try
			{
				allServers = null;
				servers = null;
				keys = null;
				deadServers = null;
			}
			finally
			{
				serverAccessLock.ExitWriteLock();
			}
		}
		serverAccessLock = null;
	}
}

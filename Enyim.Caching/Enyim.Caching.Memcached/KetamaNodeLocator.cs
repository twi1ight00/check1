using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Implements Ketama cosistent hashing, compatible with the "spymemcached" Java client
/// </summary>
public sealed class KetamaNodeLocator : IMemcachedNodeLocator
{
	/// <summary>
	/// this will encapsulate all the indexes we need for lookup
	/// so the instance can be reinitialized without locking
	/// in case an IMemcachedConfig implementation returns the same instance form the CreateLocator()
	/// </summary>
	private class LookupData
	{
		public IMemcachedNode[] Servers;

		public uint[] keys;

		public Dictionary<uint, IMemcachedNode> KeyToServer;
	}

	private const string DefaultHashName = "System.Security.Cryptography.MD5";

	private const int ServerAddressMutations = 160;

	private LookupData lookupData;

	private string hashName;

	private Func<HashAlgorithm> factory;

	private static readonly Dictionary<string, Func<HashAlgorithm>> hashFactory = new Dictionary<string, Func<HashAlgorithm>>(StringComparer.OrdinalIgnoreCase)
	{
		{
			string.Empty,
			() => MD5.Create()
		},
		{
			"default",
			() => MD5.Create()
		},
		{
			"md5",
			() => MD5.Create()
		},
		{
			"sha1",
			() => SHA1.Create()
		},
		{
			"tiger",
			() => new TigerHash()
		},
		{
			"crc",
			() => new HashkitCrc32()
		},
		{
			"fnv1_32",
			() => new FNV1()
		},
		{
			"fnv1_64",
			() => new FNV1a()
		},
		{
			"fnv1a_32",
			() => new FNV64()
		},
		{
			"fnv1a_64",
			() => new FNV64a()
		},
		{
			"murmur",
			() => new HashkitMurmur()
		},
		{
			"oneatatime",
			() => new HashkitOneAtATime()
		}
	};

	/// <summary>
	/// Initialized a new instance of the <see cref="T:Enyim.Caching.Memcached.KetamaNodeLocator" /> using the default hash algorithm.
	/// </summary>
	public KetamaNodeLocator()
		: this("System.Security.Cryptography.MD5")
	{
	}

	/// <summary>
	/// Initialized a new instance of the <see cref="T:Enyim.Caching.Memcached.KetamaNodeLocator" /> using a custom hash algorithm.
	/// </summary>
	/// <param name="hashName">The name of the hash algorithm to use.
	/// <list type="table">
	/// <listheader><term>Name</term><description>Description</description></listheader>
	/// <item><term>md5</term><description>Equivalent of System.Security.Cryptography.MD5</description></item>
	/// <item><term>sha1</term><description>Equivalent of System.Security.Cryptography.SHA1</description></item>
	/// <item><term>tiger</term><description>Tiger Hash</description></item>
	/// <item><term>crc</term><description>CRC32</description></item>
	/// <item><term>fnv1_32</term><description>FNV Hash 32bit</description></item>
	/// <item><term>fnv1_64</term><description>FNV Hash 64bit</description></item>
	/// <item><term>fnv1a_32</term><description>Modified FNV Hash 32bit</description></item>
	/// <item><term>fnv1a_64</term><description>Modified FNV Hash 64bit</description></item>
	/// <item><term>murmur</term><description>Murmur Hash</description></item>
	/// <item><term>oneatatime</term><description>Jenkin's "One at A time Hash"</description></item>
	/// </list>
	/// </param>
	/// <remarks>If the hashName does not match any of the item on the list it will be passed to HashAlgorithm.Create.</remarks>
	public KetamaNodeLocator(string hashName)
	{
		this.hashName = hashName ?? "System.Security.Cryptography.MD5";
		if (!hashFactory.TryGetValue(this.hashName, out factory))
		{
			factory = () => HashAlgorithm.Create(this.hashName);
		}
	}

	void IMemcachedNodeLocator.Initialize(IList<IMemcachedNode> nodes)
	{
		if (this.lookupData != null)
		{
			return;
		}
		HashAlgorithm hashAlgo = factory();
		int PartCount = hashAlgo.HashSize / 8 / 4;
		if (PartCount < 1)
		{
			throw new ArgumentOutOfRangeException("The hash algorithm must provide at least 32 bits long hashes");
		}
		List<uint> keys = new List<uint>(nodes.Count * 160);
		Dictionary<uint, IMemcachedNode> keyToServer = new Dictionary<uint, IMemcachedNode>(keys.Count, new UIntEqualityComparer());
		for (int nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
		{
			IMemcachedNode currentNode = nodes[nodeIndex];
			string address = currentNode.EndPoint.ToString();
			for (int mutation = 0; mutation < 160 / PartCount; mutation++)
			{
				byte[] data = hashAlgo.ComputeHash(Encoding.ASCII.GetBytes(address + "-" + mutation));
				for (int p = 0; p < PartCount; p++)
				{
					int tmp = p * 4;
					uint key = (uint)((data[tmp + 3] << 24) | (data[tmp + 2] << 16) | (data[tmp + 1] << 8) | data[tmp]);
					keys.Add(key);
					keyToServer[key] = currentNode;
				}
			}
		}
		keys.Sort();
		LookupData lookupData2 = new LookupData();
		lookupData2.keys = keys.ToArray();
		lookupData2.KeyToServer = keyToServer;
		lookupData2.Servers = nodes.ToArray();
		LookupData lookupData = lookupData2;
		Interlocked.Exchange(ref this.lookupData, lookupData);
	}

	private uint GetKeyHash(string key)
	{
		HashAlgorithm hashAlgo = factory();
		IUIntHashAlgorithm uintHash = hashAlgo as IUIntHashAlgorithm;
		byte[] keyData = Encoding.UTF8.GetBytes(key);
		if (uintHash == null)
		{
			byte[] data = hashAlgo.ComputeHash(keyData);
			return (uint)((data[3] << 24) | (data[2] << 16) | (data[1] << 8) | data[0]);
		}
		return uintHash.ComputeHash(keyData);
	}

	IMemcachedNode IMemcachedNodeLocator.Locate(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		LookupData ld = lookupData;
		switch (ld.Servers.Length)
		{
		case 0:
			return null;
		case 1:
		{
			IMemcachedNode tmp = ld.Servers[0];
			if (!tmp.IsAlive)
			{
				return null;
			}
			return tmp;
		}
		default:
		{
			IMemcachedNode retval = LocateNode(ld, GetKeyHash(key));
			if (!retval.IsAlive)
			{
				for (int i = 0; i < ld.Servers.Length; i++)
				{
					ulong tmpKey = GetKeyHash(i + key);
					tmpKey += (uint)(tmpKey ^ (tmpKey >> 32));
					tmpKey &= 0xFFFFFFFFu;
					retval = LocateNode(ld, (uint)tmpKey);
					if (retval.IsAlive)
					{
						return retval;
					}
				}
			}
			if (!retval.IsAlive)
			{
				return null;
			}
			return retval;
		}
		}
	}

	IEnumerable<IMemcachedNode> IMemcachedNodeLocator.GetWorkingNodes()
	{
		LookupData ld = lookupData;
		if (ld.Servers == null || ld.Servers.Length == 0)
		{
			return Enumerable.Empty<IMemcachedNode>();
		}
		IMemcachedNode[] retval = new IMemcachedNode[ld.Servers.Length];
		Array.Copy(ld.Servers, retval, retval.Length);
		return retval;
	}

	private static IMemcachedNode LocateNode(LookupData ld, uint itemKeyHash)
	{
		int foundIndex = Array.BinarySearch(ld.keys, itemKeyHash);
		if (foundIndex < 0)
		{
			foundIndex = ~foundIndex;
			if (foundIndex == 0)
			{
				foundIndex = ld.keys.Length - 1;
			}
			else if (foundIndex >= ld.keys.Length)
			{
				foundIndex = 0;
			}
		}
		if (foundIndex < 0 || foundIndex > ld.keys.Length)
		{
			return null;
		}
		return ld.KeyToServer[ld.keys[foundIndex]];
	}
}

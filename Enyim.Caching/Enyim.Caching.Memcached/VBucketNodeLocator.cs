using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Enyim.Caching.Configuration;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Implements a vbucket based node locator.
/// </summary>
public class VBucketNodeLocator : IMemcachedNodeLocator
{
	private VBucket[] buckets;

	private int mask;

	private Func<HashAlgorithm> factory;

	[ThreadStatic]
	private static HashAlgorithm currentAlgo;

	private IMemcachedNode[] nodes;

	private static readonly Dictionary<string, Func<HashAlgorithm>> hashFactory = new Dictionary<string, Func<HashAlgorithm>>(StringComparer.OrdinalIgnoreCase)
	{
		{
			string.Empty,
			() => new HashkitOneAtATime()
		},
		{
			"default",
			() => new HashkitOneAtATime()
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
		}
	};

	private VBucketNodeLocator()
	{
		throw new InvalidOperationException("You must use the VBucketNodeLocatorFactory in the configuration file to use this locator!");
	}

	public VBucketNodeLocator(string hashAlgorithm, VBucket[] buckets)
	{
		double log = Math.Log(buckets.Length, 2.0);
		if (log != (double)(int)log)
		{
			throw new ArgumentException("bucket count must be a power of 2!");
		}
		this.buckets = buckets;
		mask = buckets.Length - 1;
		if (!hashFactory.TryGetValue(hashAlgorithm, out factory))
		{
			throw new ArgumentException("Unknown hash algorithm: " + hashAlgorithm, "hashAlgorithm");
		}
	}

	void IMemcachedNodeLocator.Initialize(IList<IMemcachedNode> nodes)
	{
		if (this.nodes == null)
		{
			this.nodes = nodes.ToArray();
		}
	}

	IMemcachedNode IMemcachedNodeLocator.Locate(string key)
	{
		VBucket bucket = GetVBucket(key);
		return nodes[bucket.Master];
	}

	public int GetIndex(string key)
	{
		HashAlgorithm ha = factory();
		IUIntHashAlgorithm iuha = ha as IUIntHashAlgorithm;
		byte[] keyBytes = Encoding.UTF8.GetBytes(key);
		uint keyHash = iuha?.ComputeHash(keyBytes) ?? BitConverter.ToUInt32(ha.ComputeHash(keyBytes), 0);
		return (int)(keyHash & mask);
	}

	public VBucket GetVBucket(string key)
	{
		int index = GetIndex(key);
		return buckets[index];
	}

	IEnumerable<IMemcachedNode> IMemcachedNodeLocator.GetWorkingNodes()
	{
		IMemcachedNode[] nodes = this.nodes;
		IMemcachedNode[] retval = new IMemcachedNode[nodes.Length];
		Array.Copy(nodes, retval, retval.Length);
		return retval;
	}
}

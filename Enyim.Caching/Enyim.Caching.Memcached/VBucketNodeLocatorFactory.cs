using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Enyim.Caching.Configuration;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Factory for the vbucket based locator.
/// </summary>
/// <remarks>You need to use this in the configuration file because this is the only way pass parameters to the VBucketNodeLocator.
///
/// 	<locator factory="Enyim.Caching.Memcached.VBucketNodeLocatorFactory" configFile="vbucket.json" />
///
/// </remarks>
public class VBucketNodeLocatorFactory : IProviderFactory<IMemcachedNodeLocator>, IProvider
{
	private string hashAlgo;

	private VBucket[] buckets;

	void IProvider.Initialize(Dictionary<string, string> parameters)
	{
		ConfigurationHelper.TryGetAndRemove(parameters, "hashAlgorithm", out hashAlgo, required: true);
		ConfigurationHelper.TryGetAndRemove(parameters, string.Empty, out string json, required: true);
		ConfigurationHelper.CheckForUnknownAttributes(parameters);
		int[][] tmp = new JavaScriptSerializer().Deserialize<int[][]>(json);
		buckets = tmp.Select((int[] entry) => new VBucket(entry[0], entry.Skip(1).ToArray())).ToArray();
	}

	IMemcachedNodeLocator IProviderFactory<IMemcachedNodeLocator>.Create()
	{
		return new VBucketNodeLocator(hashAlgo, buckets);
	}
}

using System.Collections.Generic;
using Enyim.Caching.Configuration;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Implements Ketama cosistent hashing, compatible with the "spymemcached" Java client
/// </summary>
public class KetamaNodeLocatorFactory : IProviderFactory<IMemcachedNodeLocator>, IProvider
{
	private string hashName;

	void IProvider.Initialize(Dictionary<string, string> parameters)
	{
		ConfigurationHelper.TryGetAndRemove(parameters, "hashName", out hashName, required: false);
	}

	IMemcachedNodeLocator IProviderFactory<IMemcachedNodeLocator>.Create()
	{
		return new KetamaNodeLocator(hashName);
	}
}

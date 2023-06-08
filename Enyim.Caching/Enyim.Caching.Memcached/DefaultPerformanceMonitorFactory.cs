using System;
using System.Collections.Generic;

namespace Enyim.Caching.Memcached;

public class DefaultPerformanceMonitorFactory : IProviderFactory<IPerformanceMonitor>, IProvider
{
	private string name;

	internal DefaultPerformanceMonitorFactory()
	{
	}

	public DefaultPerformanceMonitorFactory(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException("Name must be specified.", "name");
		}
		this.name = name;
	}

	void IProvider.Initialize(Dictionary<string, string> parameters)
	{
		if ((parameters != null && (!parameters.TryGetValue("name", out name) || string.IsNullOrEmpty(name))) || (parameters == null && string.IsNullOrEmpty(name)))
		{
			throw new ArgumentException("The DefaultPerformanceMonitor must have a name assigned. Use the name attribute in the configuration file.");
		}
	}

	IPerformanceMonitor IProviderFactory<IPerformanceMonitor>.Create()
	{
		return new DefaultPerformanceMonitor(name);
	}
}

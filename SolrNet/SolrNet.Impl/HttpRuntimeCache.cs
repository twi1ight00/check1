using System;
using System.Web;
using System.Web.Caching;

namespace SolrNet.Impl;

/// <summary>
/// Uses the HttpRuntime (ASP.NET) cache
/// </summary>
public class HttpRuntimeCache : ISolrCache
{
	private readonly string id = Guid.NewGuid().ToString();

	/// <summary>
	/// Cache sliding minutes. By default 10 minutes
	/// </summary>
	public int SlidingMinutes { get; set; }

	public SolrCacheEntity this[string url] => HttpRuntime.Cache[CacheKey(url)] as SolrCacheEntity;

	public HttpRuntimeCache()
	{
		SlidingMinutes = 10;
	}

	public string CacheKey(string url)
	{
		return "solr" + id + url;
	}

	public void Add(SolrCacheEntity e)
	{
		HttpRuntime.Cache.Insert(CacheKey(e.Url), e, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, SlidingMinutes, 0));
	}
}

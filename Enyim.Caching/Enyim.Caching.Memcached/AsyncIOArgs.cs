using System;

namespace Enyim.Caching.Memcached;

public class AsyncIOArgs
{
	public Action<AsyncIOArgs> Next { get; set; }

	public int Count { get; set; }

	public byte[] Result { get; internal set; }

	public bool Fail { get; internal set; }
}

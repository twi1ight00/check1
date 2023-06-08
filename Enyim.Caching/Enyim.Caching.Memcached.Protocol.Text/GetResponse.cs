using System;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class GetResponse
{
	public readonly string Key;

	public readonly ulong CasValue;

	public readonly CacheItem Item;

	private GetResponse()
	{
	}

	public GetResponse(string key, ushort flags, ulong casValue, byte[] data)
		: this(key, flags, casValue, data, 0, data.Length)
	{
	}

	public GetResponse(string key, ushort flags, ulong casValue, byte[] data, int offset, int count)
	{
		Key = key;
		CasValue = casValue;
		Item = new CacheItem(flags, new ArraySegment<byte>(data, offset, count));
	}
}

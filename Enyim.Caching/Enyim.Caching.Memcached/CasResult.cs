namespace Enyim.Caching.Memcached;

public struct CasResult<T>
{
	public T Result { get; set; }

	public ulong Cas { get; set; }

	public int StatusCode { get; set; }
}

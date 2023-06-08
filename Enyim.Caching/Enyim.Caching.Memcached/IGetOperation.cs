namespace Enyim.Caching.Memcached;

public interface IGetOperation : ISingleItemOperation, IOperation
{
	CacheItem Result { get; }
}

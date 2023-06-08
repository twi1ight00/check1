namespace Enyim.Caching.Memcached;

public interface IStoreOperation : ISingleItemOperation, IOperation
{
	StoreMode Mode { get; }
}

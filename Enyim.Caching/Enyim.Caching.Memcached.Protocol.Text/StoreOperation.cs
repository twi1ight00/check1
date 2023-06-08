namespace Enyim.Caching.Memcached.Protocol.Text;

public class StoreOperation : StoreOperationBase, IStoreOperation, ISingleItemOperation, IOperation
{
	private StoreMode mode;

	StoreMode IStoreOperation.Mode => mode;

	internal StoreOperation(StoreMode mode, string key, CacheItem value, uint expires)
		: base((StoreCommand)mode, key, value, expires, 0uL)
	{
		this.mode = mode;
	}
}

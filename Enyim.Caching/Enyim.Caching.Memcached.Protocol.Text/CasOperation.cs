using System;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class CasOperation : StoreOperationBase, IStoreOperation, ISingleItemOperation, IOperation
{
	StoreMode IStoreOperation.Mode => StoreMode.Set;

	internal CasOperation(string key, CacheItem value, uint expires, ulong cas)
		: base(StoreCommand.CheckAndSet, key, value, expires, cas)
	{
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

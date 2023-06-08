using System;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class ConcateOperation : StoreOperationBase, IConcatOperation, ISingleItemOperation, IOperation
{
	private ConcatenationMode mode;

	ConcatenationMode IConcatOperation.Mode => mode;

	internal ConcateOperation(ConcatenationMode mode, string key, ArraySegment<byte> data)
		: base((mode == ConcatenationMode.Append) ? StoreCommand.Append : StoreCommand.Prepend, key, new CacheItem
		{
			Data = data,
			Flags = 0u
		}, 0u, 0uL)
	{
		this.mode = mode;
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

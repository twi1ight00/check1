using System;
using System.Collections.Generic;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public abstract class BinaryOperation : Operation
{
	protected abstract BinaryRequest Build();

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		return Build().CreateBuffer();
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

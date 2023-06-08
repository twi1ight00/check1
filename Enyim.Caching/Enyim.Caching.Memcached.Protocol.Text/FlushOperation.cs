using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class FlushOperation : Operation, IFlushOperation, IOperation
{
	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		return TextSocketHelper.GetCommandBuffer("flush_all\r\n");
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		TextSocketHelper.ReadResponse(socket);
		return new TextOperationResult().Pass();
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

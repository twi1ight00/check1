using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class GetOperation : SingleItemOperation, IGetOperation, ISingleItemOperation, IOperation
{
	private CacheItem result;

	CacheItem IGetOperation.Result => result;

	internal GetOperation(string key)
		: base(key)
	{
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		string command = "gets " + base.Key + "\r\n";
		return TextSocketHelper.GetCommandBuffer(command);
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		GetResponse r = GetHelper.ReadItem(socket);
		TextOperationResult result = new TextOperationResult();
		if (r == null)
		{
			return result.Fail("Failed to read response");
		}
		this.result = r.Item;
		base.Cas = r.CasValue;
		GetHelper.FinishCurrent(socket);
		return result.Pass();
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

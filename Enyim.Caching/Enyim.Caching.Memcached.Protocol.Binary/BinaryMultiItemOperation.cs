using System;
using System.Collections.Generic;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public abstract class BinaryMultiItemOperation : MultiItemOperation
{
	public BinaryMultiItemOperation(IList<string> keys)
		: base(keys)
	{
	}

	protected abstract BinaryRequest Build(string key);

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		IList<string> keys = base.Keys;
		List<ArraySegment<byte>> retval = new List<ArraySegment<byte>>(keys.Count * 2);
		foreach (string i in keys)
		{
			Build(i).CreateBuffer(retval);
		}
		return retval;
	}
}

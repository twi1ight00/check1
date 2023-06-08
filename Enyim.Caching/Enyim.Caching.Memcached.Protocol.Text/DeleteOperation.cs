using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class DeleteOperation : SingleItemOperation, IDeleteOperation, ISingleItemOperation, IOperation
{
	internal DeleteOperation(string key)
		: base(key)
	{
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		string command = "delete " + base.Key + "\r\n";
		return TextSocketHelper.GetCommandBuffer(command);
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		TextOperationResult textOperationResult = new TextOperationResult();
		textOperationResult.Success = string.Compare(TextSocketHelper.ReadResponse(socket), "DELETED", StringComparison.Ordinal) == 0;
		return textOperationResult;
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

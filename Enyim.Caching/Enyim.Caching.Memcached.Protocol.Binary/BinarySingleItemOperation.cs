using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public abstract class BinarySingleItemOperation : SingleItemOperation
{
	protected BinarySingleItemOperation(string key)
		: base(key)
	{
	}

	protected abstract BinaryRequest Build();

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		return Build().CreateBuffer();
	}

	protected abstract IOperationResult ProcessResponse(BinaryResponse response);

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		BinaryResponse response = new BinaryResponse();
		bool retval = response.Read(socket);
		base.Cas = response.CAS;
		base.StatusCode = response.StatusCode;
		BinaryOperationResult binaryOperationResult = new BinaryOperationResult();
		binaryOperationResult.Success = retval;
		binaryOperationResult.Cas = base.Cas;
		binaryOperationResult.StatusCode = base.StatusCode;
		BinaryOperationResult result = binaryOperationResult;
		IOperationResult responseResult;
		if (!(responseResult = ProcessResponse(response)).Success)
		{
			result.InnerResult = responseResult;
			responseResult.Combine(result);
		}
		return result;
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotImplementedException();
	}
}

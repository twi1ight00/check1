using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class FlushOperation : BinaryOperation, IFlushOperation, IOperation
{
	protected override BinaryRequest Build()
	{
		return new BinaryRequest(OpCode.Flush);
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		BinaryResponse response = new BinaryResponse();
		bool retval = response.Read(socket);
		base.StatusCode = base.StatusCode;
		BinaryOperationResult binaryOperationResult = new BinaryOperationResult();
		binaryOperationResult.Success = retval;
		binaryOperationResult.StatusCode = base.StatusCode;
		BinaryOperationResult result = binaryOperationResult;
		result.PassOrFail(retval, "Failed to read response");
		return result;
	}
}

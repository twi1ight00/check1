using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public abstract class SaslStep : BinaryOperation
{
	protected ISaslAuthenticationProvider Provider { get; private set; }

	public byte[] Data { get; private set; }

	protected SaslStep(ISaslAuthenticationProvider provider)
	{
		Provider = provider;
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		BinaryResponse response = new BinaryResponse();
		bool retval = response.Read(socket);
		base.StatusCode = response.StatusCode;
		Data = response.Data.Array;
		BinaryOperationResult binaryOperationResult = new BinaryOperationResult();
		binaryOperationResult.StatusCode = base.StatusCode;
		BinaryOperationResult result = binaryOperationResult;
		result.PassOrFail(retval, "Failed to read response");
		return result;
	}
}

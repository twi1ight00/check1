using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;
using Enyim.Caching.Memcached.Results.Helpers;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class DeleteOperation : BinarySingleItemOperation, IDeleteOperation, ISingleItemOperation, IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(DeleteOperation));

	public DeleteOperation(string key)
		: base(key)
	{
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest binaryRequest = new BinaryRequest(OpCode.Delete);
		binaryRequest.Key = base.Key;
		binaryRequest.Cas = base.Cas;
		return binaryRequest;
	}

	protected override IOperationResult ProcessResponse(BinaryResponse response)
	{
		BinaryOperationResult result = new BinaryOperationResult();
		if (response.StatusCode == 0)
		{
			return result.Pass();
		}
		string message = ResultHelper.ProcessResponseData(response.Data);
		return result.Fail(message);
	}
}

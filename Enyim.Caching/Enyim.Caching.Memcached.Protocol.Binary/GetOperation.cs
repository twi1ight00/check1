using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;
using Enyim.Caching.Memcached.Results.Helpers;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class GetOperation : BinarySingleItemOperation, IGetOperation, ISingleItemOperation, IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(GetOperation));

	private CacheItem result;

	CacheItem IGetOperation.Result => result;

	public GetOperation(string key)
		: base(key)
	{
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest binaryRequest = new BinaryRequest(OpCode.Get);
		binaryRequest.Key = base.Key;
		binaryRequest.Cas = base.Cas;
		return binaryRequest;
	}

	protected override IOperationResult ProcessResponse(BinaryResponse response)
	{
		int status = response.StatusCode;
		BinaryOperationResult result = new BinaryOperationResult();
		base.StatusCode = status;
		if (status == 0)
		{
			int flags = BinaryConverter.DecodeInt32(response.Extra, 0);
			this.result = new CacheItem((ushort)flags, response.Data);
			base.Cas = response.CAS;
			return result.Pass();
		}
		base.Cas = 0uL;
		string message = ResultHelper.ProcessResponseData(response.Data);
		return result.Fail(message);
	}
}

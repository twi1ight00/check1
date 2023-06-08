using System;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;
using Enyim.Caching.Memcached.Results.Helpers;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class StoreOperation : BinarySingleItemOperation, IStoreOperation, ISingleItemOperation, IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(StoreOperation));

	private StoreMode mode;

	private CacheItem value;

	private uint expires;

	StoreMode IStoreOperation.Mode => mode;

	public StoreOperation(StoreMode mode, string key, CacheItem value, uint expires)
		: base(key)
	{
		this.mode = mode;
		this.value = value;
		this.expires = expires;
	}

	protected override BinaryRequest Build()
	{
		OpCode op = mode switch
		{
			StoreMode.Add => OpCode.Add, 
			StoreMode.Set => OpCode.Set, 
			StoreMode.Replace => OpCode.Replace, 
			_ => throw new ArgumentOutOfRangeException("mode", string.Concat(mode, " is not supported")), 
		};
		byte[] extra = new byte[8];
		BinaryConverter.EncodeUInt32(value.Flags, extra, 0);
		BinaryConverter.EncodeUInt32(expires, extra, 4);
		BinaryRequest binaryRequest = new BinaryRequest(op);
		binaryRequest.Key = base.Key;
		binaryRequest.Cas = base.Cas;
		binaryRequest.Extra = new ArraySegment<byte>(extra);
		binaryRequest.Data = value.Data;
		return binaryRequest;
	}

	protected override IOperationResult ProcessResponse(BinaryResponse response)
	{
		BinaryOperationResult result = new BinaryOperationResult();
		base.StatusCode = response.StatusCode;
		if (response.StatusCode == 0)
		{
			return result.Pass();
		}
		string message = ResultHelper.ProcessResponseData(response.Data);
		return result.Fail(message);
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

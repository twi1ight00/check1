using System;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;
using Enyim.Caching.Memcached.Results.Helpers;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class MutatorOperation : BinarySingleItemOperation, IMutatorOperation, ISingleItemOperation, IOperation
{
	private ulong defaultValue;

	private ulong delta;

	private uint expires;

	private MutationMode mode;

	private ulong result;

	MutationMode IMutatorOperation.Mode => mode;

	ulong IMutatorOperation.Result => result;

	public MutatorOperation(MutationMode mode, string key, ulong defaultValue, ulong delta, uint expires)
		: base(key)
	{
		if (delta < 0)
		{
			throw new ArgumentOutOfRangeException("delta", "delta must be >= 0");
		}
		this.defaultValue = defaultValue;
		this.delta = delta;
		this.expires = expires;
		this.mode = mode;
	}

	protected unsafe void UpdateExtra(BinaryRequest request)
	{
		byte[] extra = new byte[20];
		fixed (byte* buffer = extra)
		{
			BinaryConverter.EncodeUInt64(delta, buffer, 0);
			BinaryConverter.EncodeUInt64(defaultValue, buffer, 8);
			BinaryConverter.EncodeUInt32(expires, buffer, 16);
		}
		request.Extra = new ArraySegment<byte>(extra);
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest binaryRequest = new BinaryRequest((OpCode)mode);
		binaryRequest.Key = base.Key;
		binaryRequest.Cas = base.Cas;
		BinaryRequest request = binaryRequest;
		UpdateExtra(request);
		return request;
	}

	protected override IOperationResult ProcessResponse(BinaryResponse response)
	{
		BinaryOperationResult result = new BinaryOperationResult();
		if ((base.StatusCode = response.StatusCode) == 0)
		{
			ArraySegment<byte> data = response.Data;
			if (data.Count != 8)
			{
				return result.Fail("Result must be 8 bytes long, received: " + data.Count, new InvalidOperationException());
			}
			this.result = BinaryConverter.DecodeUInt64(data.Array, data.Offset);
			return result.Pass();
		}
		string message = ResultHelper.ProcessResponseData(response.Data);
		return result.Fail(message);
	}
}

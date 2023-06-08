using System;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached.Protocol.Binary;

/// <summary>
/// Implements append/prepend.
/// </summary>
public class ConcatOperation : BinarySingleItemOperation, IConcatOperation, ISingleItemOperation, IOperation
{
	private ArraySegment<byte> data;

	private ConcatenationMode mode;

	ConcatenationMode IConcatOperation.Mode => mode;

	public ConcatOperation(ConcatenationMode mode, string key, ArraySegment<byte> data)
		: base(key)
	{
		this.data = data;
		this.mode = mode;
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest binaryRequest = new BinaryRequest((OpCode)mode);
		binaryRequest.Key = base.Key;
		binaryRequest.Cas = base.Cas;
		binaryRequest.Data = data;
		return binaryRequest;
	}

	protected override IOperationResult ProcessResponse(BinaryResponse response)
	{
		BinaryOperationResult binaryOperationResult = new BinaryOperationResult();
		binaryOperationResult.Success = true;
		return binaryOperationResult;
	}
}

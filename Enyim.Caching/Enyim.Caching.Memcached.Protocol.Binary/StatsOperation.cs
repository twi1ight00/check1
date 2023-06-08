using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class StatsOperation : BinaryOperation, IStatsOperation, IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(StatsOperation));

	private string type;

	private Dictionary<string, string> result;

	Dictionary<string, string> IStatsOperation.Result => result;

	public StatsOperation(string type)
	{
		this.type = type;
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest request = new BinaryRequest(OpCode.Stat);
		if (!string.IsNullOrEmpty(type))
		{
			request.Key = type;
		}
		return request;
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		BinaryResponse response = new BinaryResponse();
		Dictionary<string, string> serverData = new Dictionary<string, string>();
		bool retval = false;
		while (response.Read(socket) && response.KeyLength > 0)
		{
			retval = true;
			ArraySegment<byte> data = response.Data;
			string key = BinaryConverter.DecodeKey(data.Array, data.Offset, response.KeyLength);
			string value = BinaryConverter.DecodeKey(data.Array, data.Offset + response.KeyLength, data.Count - response.KeyLength);
			serverData[key] = value;
		}
		this.result = serverData;
		base.StatusCode = response.StatusCode;
		BinaryOperationResult binaryOperationResult = new BinaryOperationResult();
		binaryOperationResult.StatusCode = base.StatusCode;
		BinaryOperationResult result = binaryOperationResult;
		result.PassOrFail(retval, "Failed to read response");
		return result;
	}
}

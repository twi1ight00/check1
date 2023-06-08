using System;
using System.Collections.Generic;
using System.Globalization;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class MutatorOperation : SingleItemOperation, IMutatorOperation, ISingleItemOperation, IOperation
{
	private MutationMode mode;

	private ulong delta;

	private ulong result;

	public ulong Result => result;

	MutationMode IMutatorOperation.Mode => mode;

	ulong IMutatorOperation.Result => result;

	internal MutatorOperation(MutationMode mode, string key, ulong delta)
		: base(key)
	{
		this.delta = delta;
		this.mode = mode;
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		string command = ((mode == MutationMode.Increment) ? "incr " : "decr ") + base.Key + " " + delta.ToString(CultureInfo.InvariantCulture) + "\r\n";
		return TextSocketHelper.GetCommandBuffer(command);
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		string response = TextSocketHelper.ReadResponse(socket);
		TextOperationResult result = new TextOperationResult();
		if (string.Compare(response, "NOT_FOUND", StringComparison.Ordinal) == 0)
		{
			return result.Fail("Failed to read response.  Item not found");
		}
		result.Success = ulong.TryParse(response, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, CultureInfo.InvariantCulture, out this.result);
		return result;
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

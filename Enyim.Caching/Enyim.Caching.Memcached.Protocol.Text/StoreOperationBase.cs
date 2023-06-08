using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class StoreOperationBase : SingleItemOperation
{
	private static readonly ArraySegment<byte> DataTerminator = new ArraySegment<byte>(new byte[2] { 13, 10 });

	private StoreCommand command;

	private CacheItem value;

	private uint expires;

	private ulong cas;

	internal StoreOperationBase(StoreCommand mode, string key, CacheItem value, uint expires, ulong cas)
		: base(key)
	{
		command = mode;
		this.value = value;
		this.expires = expires;
		this.cas = cas;
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		StringBuilder sb = new StringBuilder(128);
		List<ArraySegment<byte>> buffers = new List<ArraySegment<byte>>(3);
		switch (command)
		{
		case StoreCommand.Add:
			sb.Append("add ");
			break;
		case StoreCommand.Replace:
			sb.Append("replace ");
			break;
		case StoreCommand.Set:
			sb.Append("set ");
			break;
		case StoreCommand.Append:
			sb.Append("append ");
			break;
		case StoreCommand.Prepend:
			sb.Append("prepend ");
			break;
		case StoreCommand.CheckAndSet:
			sb.Append("cas ");
			break;
		default:
			throw new MemcachedClientException(string.Concat(command, " is not supported."));
		}
		sb.Append(base.Key);
		sb.Append(" ");
		sb.Append(value.Flags.ToString(CultureInfo.InvariantCulture));
		sb.Append(" ");
		sb.Append(expires.ToString(CultureInfo.InvariantCulture));
		sb.Append(" ");
		ArraySegment<byte> data = value.Data;
		sb.Append(Convert.ToString(data.Count, CultureInfo.InvariantCulture));
		if (command == StoreCommand.CheckAndSet)
		{
			sb.Append(" ");
			sb.Append(Convert.ToString(cas, CultureInfo.InvariantCulture));
		}
		sb.Append("\r\n");
		TextSocketHelper.GetCommandBuffer(sb.ToString(), buffers);
		buffers.Add(data);
		buffers.Add(DataTerminator);
		return buffers;
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		TextOperationResult textOperationResult = new TextOperationResult();
		textOperationResult.Success = string.Compare(TextSocketHelper.ReadResponse(socket), "STORED", StringComparison.Ordinal) == 0;
		return textOperationResult;
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

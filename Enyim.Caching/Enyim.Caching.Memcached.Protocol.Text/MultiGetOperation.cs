using System;
using System.Collections.Generic;
using System.Linq;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class MultiGetOperation : MultiItemOperation, IMultiGetOperation, IMultiItemOperation, IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(MultiGetOperation));

	private Dictionary<string, CacheItem> result;

	Dictionary<string, CacheItem> IMultiGetOperation.Result => result;

	public MultiGetOperation(IList<string> keys)
		: base(keys)
	{
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		string command = "gets " + string.Join(" ", base.Keys.ToArray()) + "\r\n";
		return TextSocketHelper.GetCommandBuffer(command);
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		Dictionary<string, CacheItem> retval = new Dictionary<string, CacheItem>();
		Dictionary<string, ulong> cas = new Dictionary<string, ulong>();
		try
		{
			GetResponse r;
			while ((r = GetHelper.ReadItem(socket)) != null)
			{
				string key = r.Key;
				retval[key] = r.Item;
				cas[key] = r.CasValue;
			}
		}
		catch (NotSupportedException)
		{
			throw;
		}
		catch (Exception e)
		{
			log.Error(e);
		}
		result = retval;
		base.Cas = cas;
		return new TextOperationResult().Pass();
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}

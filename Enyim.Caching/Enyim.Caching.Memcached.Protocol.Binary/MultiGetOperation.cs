using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class MultiGetOperation : BinaryMultiItemOperation, IMultiGetOperation, IMultiItemOperation, IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(MultiGetOperation));

	private Dictionary<string, CacheItem> result;

	private Dictionary<int, string> idToKey;

	private int noopId;

	private PooledSocket currentSocket;

	private BinaryResponse asyncReader;

	private bool? asyncLoopState;

	private Action<bool> afterAsyncRead;

	public Dictionary<string, CacheItem> Result => result;

	Dictionary<string, CacheItem> IMultiGetOperation.Result => result;

	public MultiGetOperation(IList<string> keys)
		: base(keys)
	{
	}

	protected override BinaryRequest Build(string key)
	{
		BinaryRequest binaryRequest = new BinaryRequest(OpCode.GetQ);
		binaryRequest.Key = key;
		return binaryRequest;
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		IList<string> keys = base.Keys;
		if (keys == null || keys.Count == 0)
		{
			if (log.IsWarnEnabled)
			{
				log.Warn("Empty multiget!");
			}
			return new ArraySegment<byte>[0];
		}
		if (log.IsDebugEnabled)
		{
			log.DebugFormat("Building multi-get for {0} keys", keys.Count);
		}
		idToKey = new Dictionary<int, string>();
		List<ArraySegment<byte>> buffers = new List<ArraySegment<byte>>(keys.Count * 2);
		foreach (string key in keys)
		{
			BinaryRequest request = Build(key);
			request.CreateBuffer(buffers);
			idToKey[request.CorrelationId] = key;
		}
		BinaryRequest noop = new BinaryRequest(OpCode.NoOp);
		noopId = noop.CorrelationId;
		noop.CreateBuffer(buffers);
		return buffers;
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		result = new Dictionary<string, CacheItem>();
		base.Cas = new Dictionary<string, ulong>();
		currentSocket = socket;
		asyncReader = new BinaryResponse();
		asyncLoopState = null;
		afterAsyncRead = next;
		return DoReadAsync();
	}

	private bool DoReadAsync()
	{
		BinaryResponse reader = asyncReader;
		while (!asyncLoopState.HasValue)
		{
			bool ioPending;
			bool readSuccess = reader.ReadAsync(currentSocket, EndReadAsync, out ioPending);
			base.StatusCode = reader.StatusCode;
			if (ioPending)
			{
				return readSuccess;
			}
			if (!readSuccess)
			{
				asyncLoopState = false;
			}
			else if (reader.CorrelationId == noopId)
			{
				asyncLoopState = true;
			}
			else
			{
				StoreResult(reader);
			}
		}
		afterAsyncRead(asyncLoopState.Value);
		return true;
	}

	private void EndReadAsync(bool readSuccess)
	{
		if (!readSuccess)
		{
			asyncLoopState = false;
		}
		else if (asyncReader.CorrelationId == noopId)
		{
			asyncLoopState = true;
		}
		else
		{
			StoreResult(asyncReader);
		}
		DoReadAsync();
	}

	private void StoreResult(BinaryResponse reader)
	{
		if (!idToKey.TryGetValue(reader.CorrelationId, out var key))
		{
			log.WarnFormat("Found response with CorrelationId {0}, but no key is matching it.", reader.CorrelationId);
			return;
		}
		if (log.IsDebugEnabled)
		{
			log.DebugFormat("Reading item {0}", key);
		}
		ushort flags = (ushort)BinaryConverter.DecodeInt32(reader.Extra, 0);
		result[key] = new CacheItem(flags, reader.Data);
		base.Cas[key] = reader.CAS;
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		this.result = new Dictionary<string, CacheItem>();
		base.Cas = new Dictionary<string, ulong>();
		TextOperationResult result = new TextOperationResult();
		BinaryResponse response = new BinaryResponse();
		while (response.Read(socket))
		{
			base.StatusCode = response.StatusCode;
			if (response.CorrelationId == noopId)
			{
				return result.Pass();
			}
			if (!idToKey.TryGetValue(response.CorrelationId, out var key))
			{
				log.WarnFormat("Found response with CorrelationId {0}, but no key is matching it.", response.CorrelationId);
				continue;
			}
			if (log.IsDebugEnabled)
			{
				log.DebugFormat("Reading item {0}", key);
			}
			int flags = BinaryConverter.DecodeInt32(response.Extra, 0);
			this.result[key] = new CacheItem((ushort)flags, response.Data);
			base.Cas[key] = response.CAS;
		}
		return result.Fail("Found response with CorrelationId {0}, but no key is matching it.");
	}
}

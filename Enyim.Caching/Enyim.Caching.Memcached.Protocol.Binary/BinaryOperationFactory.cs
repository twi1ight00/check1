using System;
using System.Collections.Generic;

namespace Enyim.Caching.Memcached.Protocol.Binary;

/// <summary>
/// Memcached client.
/// </summary>
public class BinaryOperationFactory : IOperationFactory
{
	IGetOperation IOperationFactory.Get(string key)
	{
		return new GetOperation(key);
	}

	IMultiGetOperation IOperationFactory.MultiGet(IList<string> keys)
	{
		return new MultiGetOperation(keys);
	}

	IStoreOperation IOperationFactory.Store(StoreMode mode, string key, CacheItem value, uint expires, ulong cas)
	{
		StoreOperation storeOperation = new StoreOperation(mode, key, value, expires);
		storeOperation.Cas = cas;
		return storeOperation;
	}

	IDeleteOperation IOperationFactory.Delete(string key, ulong cas)
	{
		DeleteOperation deleteOperation = new DeleteOperation(key);
		deleteOperation.Cas = cas;
		return deleteOperation;
	}

	IMutatorOperation IOperationFactory.Mutate(MutationMode mode, string key, ulong defaultValue, ulong delta, uint expires, ulong cas)
	{
		MutatorOperation mutatorOperation = new MutatorOperation(mode, key, defaultValue, delta, expires);
		mutatorOperation.Cas = cas;
		return mutatorOperation;
	}

	IConcatOperation IOperationFactory.Concat(ConcatenationMode mode, string key, ulong cas, ArraySegment<byte> data)
	{
		ConcatOperation concatOperation = new ConcatOperation(mode, key, data);
		concatOperation.Cas = cas;
		return concatOperation;
	}

	IStatsOperation IOperationFactory.Stats(string type)
	{
		return new StatsOperation(type);
	}

	IFlushOperation IOperationFactory.Flush()
	{
		return new FlushOperation();
	}
}

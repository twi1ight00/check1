using System.Collections.Generic;

namespace Enyim.Caching.Memcached.Protocol;

/// <summary>
/// Base class for implementing operations working with multiple items.
/// </summary>
public abstract class MultiItemOperation : Operation, IMultiItemOperation, IOperation
{
	public IList<string> Keys { get; private set; }

	public Dictionary<string, ulong> Cas { get; protected set; }

	IList<string> IMultiItemOperation.Keys => Keys;

	Dictionary<string, ulong> IMultiItemOperation.Cas => Cas;

	public MultiItemOperation(IList<string> keys)
	{
		Keys = keys;
	}
}

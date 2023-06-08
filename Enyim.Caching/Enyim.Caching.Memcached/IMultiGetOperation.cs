using System.Collections.Generic;

namespace Enyim.Caching.Memcached;

public interface IMultiGetOperation : IMultiItemOperation, IOperation
{
	Dictionary<string, CacheItem> Result { get; }
}

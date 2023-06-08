using System.Collections.Generic;

namespace Enyim.Caching.Memcached;

public interface IMultiItemOperation : IOperation
{
	IList<string> Keys { get; }

	Dictionary<string, ulong> Cas { get; }
}

using System.Collections.Generic;

namespace Enyim.Caching.Memcached;

public interface IStatsOperation : IOperation
{
	Dictionary<string, string> Result { get; }
}

using System.Collections.Generic;

namespace Enyim.Caching.Memcached;

public interface IProvider
{
	void Initialize(Dictionary<string, string> parameters);
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache.Provider;

namespace Richfit.Garnet.Module.Attachment.Cache;

public class MemoryCacheProviderEx : MemoryCacheProvider, IProvider, ICacheProvider, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	public IList<string> GetAllKeys()
	{
		return base.Cache.Select((KeyValuePair<string, object> kvp) => kvp.Key).ToList();
	}

	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		return ((IEnumerable<KeyValuePair<string, object>>)base.Cache).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<KeyValuePair<string, object>>)base.Cache).GetEnumerator();
	}
}

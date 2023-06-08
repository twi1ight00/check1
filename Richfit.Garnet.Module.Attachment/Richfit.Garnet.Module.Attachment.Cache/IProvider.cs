using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Cache.Provider;

namespace Richfit.Garnet.Module.Attachment.Cache;

public interface IProvider : ICacheProvider, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	/// <summary>
	/// 获得所有缓存键值
	/// </summary>
	/// <returns></returns>
	IList<string> GetAllKeys();
}

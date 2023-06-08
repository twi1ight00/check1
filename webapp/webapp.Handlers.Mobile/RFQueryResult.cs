using System;
using System.Collections.Generic;

namespace webapp.Handlers.Mobile;

[Serializable]
public class RFQueryResult<T>
{
	public int count { get; set; }

	public IList<T> list { get; set; }
}

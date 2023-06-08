using System;

namespace SolrNet.Impl;

public interface ISolrQuerySerializer
{
	bool CanHandleType(Type t);

	string Serialize(object q);
}

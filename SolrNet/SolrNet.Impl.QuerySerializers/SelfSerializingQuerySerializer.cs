using System;

namespace SolrNet.Impl.QuerySerializers;

public class SelfSerializingQuerySerializer : ISolrQuerySerializer
{
	public bool CanHandleType(Type t)
	{
		return typeof(ISelfSerializingQuery).IsAssignableFrom(t);
	}

	public string Serialize(object q)
	{
		ISelfSerializingQuery sq = (ISelfSerializingQuery)q;
		return sq.Query;
	}
}

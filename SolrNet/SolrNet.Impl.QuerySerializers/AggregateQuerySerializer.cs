using System;
using System.Linq;
using SolrNet.Exceptions;

namespace SolrNet.Impl.QuerySerializers;

public class AggregateQuerySerializer : ISolrQuerySerializer
{
	private readonly ISolrQuerySerializer[] serializers;

	public AggregateQuerySerializer(ISolrQuerySerializer[] serializers)
	{
		this.serializers = serializers;
	}

	public bool CanHandleType(Type t)
	{
		return serializers.Any((ISolrQuerySerializer s) => s.CanHandleType(t));
	}

	public string Serialize(object q)
	{
		if (q == null)
		{
			return string.Empty;
		}
		Type t = q.GetType();
		ISolrQuerySerializer[] array = serializers;
		foreach (ISolrQuerySerializer s in array)
		{
			if (s.CanHandleType(t))
			{
				return s.Serialize(q);
			}
		}
		throw new SolrNetException($"Couldn't serialize query '{q}' of type '{t}'");
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using SolrNet.Exceptions;

namespace SolrNet.Impl.FacetQuerySerializers;

public class AggregateFacetQuerySerializer : ISolrFacetQuerySerializer
{
	private readonly ISolrFacetQuerySerializer[] serializers;

	public AggregateFacetQuerySerializer(ISolrFacetQuerySerializer[] serializers)
	{
		this.serializers = serializers;
	}

	public bool CanHandleType(Type t)
	{
		return serializers.Any((ISolrFacetQuerySerializer s) => s.CanHandleType(t));
	}

	public IEnumerable<KeyValuePair<string, string>> Serialize(object q)
	{
		if (q == null)
		{
			yield break;
		}
		Type t = q.GetType();
		try
		{
			ISolrFacetQuerySerializer[] array = serializers;
			foreach (ISolrFacetQuerySerializer s in array)
			{
				if (!s.CanHandleType(t))
				{
					continue;
				}
				{
					foreach (KeyValuePair<string, string> item in s.Serialize(q))
					{
						yield return item;
					}
					yield break;
				}
			}
		}
		finally
		{
		}
		throw new SolrNetException($"Couldn't serialize facet query '{q}' of type '{t}'");
	}
}

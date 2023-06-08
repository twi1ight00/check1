using System;
using System.Collections;
using System.Collections.Generic;
using SolrNet.Utils;

namespace SolrNet.Impl.FieldSerializers;

/// <summary>
///   Serializes 1-dimensional collections
/// </summary>
public class CollectionFieldSerializer : ISolrFieldSerializer
{
	private readonly ISolrFieldSerializer valueSerializer;

	public CollectionFieldSerializer(ISolrFieldSerializer valueSerializer)
	{
		this.valueSerializer = valueSerializer;
	}

	public bool CanHandleType(Type t)
	{
		return t != typeof(string) && typeof(IEnumerable).IsAssignableFrom(t) && !typeof(IDictionary).IsAssignableFrom(t) && !TypeHelper.IsGenericAssignableFrom(typeof(IDictionary<, >), t);
	}

	public IEnumerable<PropertyNode> Serialize(object obj)
	{
		if (obj == null)
		{
			yield break;
		}
		foreach (object o in (IEnumerable)obj)
		{
			IEnumerable<PropertyNode> e = valueSerializer.Serialize(o);
			if (e == null)
			{
				yield return new PropertyNode();
				continue;
			}
			foreach (PropertyNode item in e)
			{
				yield return item;
			}
		}
	}
}

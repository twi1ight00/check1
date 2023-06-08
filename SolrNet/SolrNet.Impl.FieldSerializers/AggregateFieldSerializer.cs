using System;
using System.Collections.Generic;
using System.Linq;
using SolrNet.Exceptions;

namespace SolrNet.Impl.FieldSerializers;

/// <summary>
/// Aggregates <see cref="T:SolrNet.Impl.ISolrFieldSerializer" />s
/// </summary>
public class AggregateFieldSerializer : ISolrFieldSerializer
{
	private readonly IEnumerable<ISolrFieldSerializer> serializers;

	public AggregateFieldSerializer(IEnumerable<ISolrFieldSerializer> serializers)
	{
		this.serializers = serializers;
	}

	public bool CanHandleType(Type t)
	{
		return serializers.Any((ISolrFieldSerializer s) => s.CanHandleType(t));
	}

	public IEnumerable<PropertyNode> Serialize(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		Type type = obj.GetType();
		foreach (ISolrFieldSerializer s in serializers)
		{
			if (s.CanHandleType(type))
			{
				return s.Serialize(obj);
			}
		}
		throw new TypeNotSupportedException($"Couldn't serialize type '{type}'");
	}
}

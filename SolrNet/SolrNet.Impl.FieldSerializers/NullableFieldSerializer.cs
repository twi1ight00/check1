using System;
using System.Collections.Generic;
using SolrNet.Utils;

namespace SolrNet.Impl.FieldSerializers;

/// <summary>
/// Wraps a <see cref="T:SolrNet.Impl.ISolrFieldSerializer" /> making it support the corresponding <see cref="T:System.Nullable`1" /> type
/// </summary>
public class NullableFieldSerializer : ISolrFieldSerializer
{
	private readonly ISolrFieldSerializer serializer;

	public NullableFieldSerializer(ISolrFieldSerializer serializer)
	{
		this.serializer = serializer;
	}

	public bool CanHandleType(Type t)
	{
		return serializer.CanHandleType(t) || serializer.CanHandleType(TypeHelper.GetUnderlyingNullableType(t));
	}

	public IEnumerable<PropertyNode> Serialize(object obj)
	{
		if (obj == null)
		{
			yield break;
		}
		foreach (PropertyNode item in serializer.Serialize(obj))
		{
			yield return item;
		}
	}
}

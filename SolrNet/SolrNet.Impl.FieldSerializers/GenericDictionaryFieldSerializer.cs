using System;
using System.Collections;
using System.Collections.Generic;
using SolrNet.Utils;

namespace SolrNet.Impl.FieldSerializers;

/// <summary>
/// Serializes <see cref="T:System.Collections.Generic.IDictionary`2" /> properties
/// </summary>
public class GenericDictionaryFieldSerializer : ISolrFieldSerializer
{
	private readonly ISolrFieldSerializer serializer;

	public GenericDictionaryFieldSerializer(ISolrFieldSerializer serializer)
	{
		this.serializer = serializer;
	}

	public bool CanHandleType(Type t)
	{
		return TypeHelper.IsGenericAssignableFrom(typeof(IDictionary<, >), t);
	}

	/// <summary>
	/// Gets the key from a <see cref="T:System.Collections.Generic.KeyValuePair`2" />
	/// </summary>
	/// <param name="kv"></param>
	/// <returns></returns>
	public string KVKey(object kv)
	{
		return kv.GetType().GetProperty("Key").GetValue(kv, null)
			.ToString();
	}

	/// <summary>
	/// Gets the value from a <see cref="T:System.Collections.Generic.KeyValuePair`2" />
	/// </summary>
	/// <param name="kv"></param>
	/// <returns></returns>
	public object KVValue(object kv)
	{
		return kv.GetType().GetProperty("Value").GetValue(kv, null);
	}

	public IEnumerable<PropertyNode> Serialize(object obj)
	{
		if (obj == null)
		{
			yield break;
		}
		foreach (object de in (IEnumerable)obj)
		{
			string name = KVKey(de);
			IEnumerable<PropertyNode> value = serializer.Serialize(KVValue(de));
			if (value == null)
			{
				yield return new PropertyNode
				{
					FieldNameSuffix = name
				};
				continue;
			}
			foreach (PropertyNode v in value)
			{
				yield return new PropertyNode
				{
					FieldValue = v.FieldValue,
					FieldNameSuffix = name
				};
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SolrNet.Impl.FieldSerializers;

/// <summary>
/// Serializes using <see cref="T:System.ComponentModel.TypeConverter" />s
/// </summary>
public class TypeConvertingFieldSerializer : ISolrFieldSerializer
{
	public bool CanHandleType(Type t)
	{
		TypeConverter converter = TypeDescriptor.GetConverter(t);
		return converter.CanConvertTo(typeof(string));
	}

	public IEnumerable<PropertyNode> Serialize(object obj)
	{
		if (obj != null)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(obj.GetType());
			yield return new PropertyNode
			{
				FieldValue = converter.ConvertToInvariantString(obj)
			};
		}
	}
}

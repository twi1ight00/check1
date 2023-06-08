using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace SolrNet.Impl;

/// <summary>
/// Serializes a dictionary document
/// </summary>
public class SolrDictionarySerializer : ISolrDocumentSerializer<Dictionary<string, object>>
{
	private readonly ISolrFieldSerializer serializer;

	public SolrDictionarySerializer(ISolrFieldSerializer serializer)
	{
		this.serializer = serializer;
	}

	public XElement Serialize(Dictionary<string, object> doc, double? boost)
	{
		if (doc == null)
		{
			throw new ArgumentNullException("doc");
		}
		XElement docNode = new XElement("doc");
		if (boost.HasValue)
		{
			XAttribute boostAttr = new XAttribute("boost", boost.Value.ToString(CultureInfo.InvariantCulture.NumberFormat));
			docNode.Add(boostAttr);
		}
		foreach (KeyValuePair<string, object> kv in doc)
		{
			IEnumerable<PropertyNode> nodes = serializer.Serialize(kv.Value);
			foreach (PropertyNode i in nodes)
			{
				string value = SolrDocumentSerializer<object>.RemoveControlCharacters(i.FieldValue);
				if (value != null)
				{
					XElement fieldNode = new XElement("field", new XAttribute("name", kv.Key), value);
					docNode.Add(fieldNode);
				}
			}
		}
		return docNode;
	}
}

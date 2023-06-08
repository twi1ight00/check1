using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SolrNet.Impl;

/// <summary>
/// Serializes a Solr document to xml
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class SolrDocumentSerializer<T> : ISolrDocumentSerializer<T>
{
	private readonly IReadOnlyMappingManager mappingManager;

	private readonly ISolrFieldSerializer fieldSerializer;

	private static readonly Regex ControlCharacters = new Regex("[^\\x09\\x0A\\x0D\\x20-\\uD7FF\\uE000-\\uFFFD\\u10000-u10FFFF]", RegexOptions.Compiled);

	public SolrDocumentSerializer(IReadOnlyMappingManager mappingManager, ISolrFieldSerializer fieldSerializer)
	{
		this.mappingManager = mappingManager;
		this.fieldSerializer = fieldSerializer;
	}

	public static string RemoveControlCharacters(string xml)
	{
		if (xml == null)
		{
			return null;
		}
		return ControlCharacters.Replace(xml, "");
	}

	public XElement Serialize(T doc, double? boost)
	{
		XElement docNode = new XElement("doc");
		if (boost.HasValue)
		{
			XAttribute boostAttr = new XAttribute("boost", boost.Value.ToString(CultureInfo.InvariantCulture.NumberFormat));
			docNode.Add(boostAttr);
		}
		IDictionary<string, SolrFieldModel> fields = mappingManager.GetFields(doc.GetType());
		foreach (SolrFieldModel field in fields.Values)
		{
			PropertyInfo p = field.Property;
			if (!p.CanRead)
			{
				continue;
			}
			object value = p.GetValue(doc, null);
			if (value == null)
			{
				continue;
			}
			IEnumerable<PropertyNode> nodes = fieldSerializer.Serialize(value);
			foreach (PropertyNode i in nodes)
			{
				XElement fieldNode = new XElement("field");
				XAttribute nameAtt = new XAttribute("name", ((field.FieldName == "*") ? "" : field.FieldName) + i.FieldNameSuffix);
				fieldNode.Add(nameAtt);
				if (field.Boost.HasValue && field.Boost > 0f)
				{
					XAttribute boostAtt = new XAttribute("boost", field.Boost.Value.ToString(CultureInfo.InvariantCulture.NumberFormat));
					fieldNode.Add(boostAtt);
				}
				string v = RemoveControlCharacters(i.FieldValue);
				if (v != null)
				{
					fieldNode.Value = v;
					docNode.Add(fieldNode);
				}
			}
		}
		return docNode;
	}
}

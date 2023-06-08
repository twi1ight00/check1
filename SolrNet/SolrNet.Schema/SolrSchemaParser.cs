using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Exceptions;

namespace SolrNet.Schema;

/// <summary>
/// Parses a Solr schema xml document into a strongly typed
/// <see cref="T:SolrNet.Schema.SolrSchema" /> object.
/// </summary>
public class SolrSchemaParser : ISolrSchemaParser
{
	/// <summary>
	/// Parses the specified Solr schema xml.
	/// </summary>
	/// <param name="solrSchemaXml">The Solr schema xml to parse.</param>
	/// <returns>A strongly styped representation of the Solr schema xml.</returns>
	public SolrSchema Parse(XDocument solrSchemaXml)
	{
		SolrSchema result = new SolrSchema();
		XElement schemaElem = solrSchemaXml.Element("schema");
		foreach (XElement fieldNode in schemaElem.XPathSelectElements("types/fieldType|types/fieldtype"))
		{
			SolrFieldType field2 = new SolrFieldType(fieldNode.Attribute("name").Value, fieldNode.Attribute("class").Value);
			result.SolrFieldTypes.Add(field2);
		}
		XElement fieldsElem = schemaElem.Element("fields");
		foreach (XElement fieldNode in fieldsElem.Elements("field"))
		{
			string fieldTypeName = fieldNode.Attribute("type").Value;
			SolrFieldType fieldType = result.FindSolrFieldTypeByName(fieldTypeName);
			if (fieldType == null)
			{
				throw new SolrNetException($"Field type '{fieldTypeName}' not found");
			}
			SolrField field = new SolrField(fieldNode.Attribute("name").Value, fieldType);
			field.IsRequired = fieldNode.Attribute("required") != null && fieldNode.Attribute("required").Value.ToLower().Equals(bool.TrueString.ToLower());
			field.IsMultiValued = fieldNode.Attribute("multiValued") != null && fieldNode.Attribute("multiValued").Value.ToLower().Equals(bool.TrueString.ToLower());
			field.IsStored = fieldNode.Attribute("stored") != null && fieldNode.Attribute("stored").Value.ToLower().Equals(bool.TrueString.ToLower());
			field.IsIndexed = fieldNode.Attribute("indexed") != null && fieldNode.Attribute("indexed").Value.ToLower().Equals(bool.TrueString.ToLower());
			field.IsDocValues = fieldNode.Attribute("docValues") != null && fieldNode.Attribute("docValues").Value.ToLower().Equals(bool.TrueString.ToLower());
			result.SolrFields.Add(field);
		}
		foreach (XElement dynamicFieldNode in fieldsElem.Elements("dynamicField"))
		{
			SolrDynamicField dynamicField = new SolrDynamicField(dynamicFieldNode.Attribute("name").Value);
			result.SolrDynamicFields.Add(dynamicField);
		}
		foreach (XElement copyFieldNode in schemaElem.Elements("copyField"))
		{
			SolrCopyField copyField = new SolrCopyField(copyFieldNode.Attribute("source").Value, copyFieldNode.Attribute("dest").Value);
			result.SolrCopyFields.Add(copyField);
		}
		XElement uniqueKeyNode = schemaElem.Element("uniqueKey");
		if (uniqueKeyNode != null && !string.IsNullOrEmpty(uniqueKeyNode.Value))
		{
			result.UniqueKey = uniqueKeyNode.Value;
		}
		return result;
	}
}

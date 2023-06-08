using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SolrNet.Impl.DocumentPropertyVisitors;

/// <summary>
/// Pass-through document visitor
/// </summary>
public class RegularDocumentVisitor : ISolrDocumentPropertyVisitor
{
	private readonly ISolrFieldParser parser;

	private readonly IReadOnlyMappingManager mapper;

	/// <summary>
	/// Pass-through document visitor
	/// </summary>
	/// <param name="parser"></param>
	/// <param name="mapper"></param>
	public RegularDocumentVisitor(ISolrFieldParser parser, IReadOnlyMappingManager mapper)
	{
		this.parser = parser;
		this.mapper = mapper;
	}

	public void Visit(object doc, string fieldName, XElement field)
	{
		IDictionary<string, SolrFieldModel> allFields = mapper.GetFields(doc.GetType());
		if (!allFields.TryGetValue(fieldName, out var thisField) || !thisField.Property.CanWrite || !parser.CanHandleSolrType(field.Name.LocalName) || !parser.CanHandleType(thisField.Property.PropertyType))
		{
			return;
		}
		object v = parser.Parse(field, thisField.Property.PropertyType);
		try
		{
			thisField.Property.SetValue(doc, v, null);
		}
		catch (ArgumentException e)
		{
			throw new ArgumentException($"Could not convert value '{v}' to property '{thisField.Property.Name}' of document type {thisField.Property.DeclaringType}", e);
		}
	}
}

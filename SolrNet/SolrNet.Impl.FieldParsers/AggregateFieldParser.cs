using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SolrNet.Impl.FieldParsers;

/// <summary>
/// Aggregates <see cref="T:SolrNet.Impl.ISolrFieldParser" />s
/// </summary>
public class AggregateFieldParser : ISolrFieldParser
{
	private readonly IEnumerable<ISolrFieldParser> parsers;

	/// <summary>
	/// Aggregates <see cref="T:SolrNet.Impl.ISolrFieldParser" />s
	/// </summary>
	/// <param name="parsers"></param>
	public AggregateFieldParser(IEnumerable<ISolrFieldParser> parsers)
	{
		this.parsers = parsers;
	}

	public bool CanHandleSolrType(string solrType)
	{
		return parsers.Any((ISolrFieldParser p) => p.CanHandleSolrType(solrType));
	}

	public bool CanHandleType(Type t)
	{
		return parsers.Any((ISolrFieldParser p) => p.CanHandleType(t));
	}

	public object Parse(XElement field, Type t)
	{
		return (from p in parsers
			where p.CanHandleType(t) && p.CanHandleSolrType(field.Name.LocalName)
			select p.Parse(field, t)).FirstOrDefault();
	}
}

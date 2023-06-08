using System;
using System.Globalization;
using System.Xml.Linq;

namespace SolrNet.Impl.FieldParsers;

/// <summary>
/// Parses <see cref="T:System.Decimal" /> fields
/// </summary>
public class DecimalFieldParser : ISolrFieldParser
{
	public bool CanHandleSolrType(string solrType)
	{
		return true;
	}

	public bool CanHandleType(Type t)
	{
		return t == typeof(decimal);
	}

	public object Parse(XElement field, Type t)
	{
		return decimal.Parse(field.Value, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat);
	}
}

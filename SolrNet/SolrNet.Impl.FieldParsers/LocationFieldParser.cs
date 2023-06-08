using System;
using System.Globalization;
using System.Xml.Linq;
using SolrNet.Exceptions;

namespace SolrNet.Impl.FieldParsers;

public class LocationFieldParser : ISolrFieldParser
{
	public bool CanHandleSolrType(string solrType)
	{
		return solrType == "str";
	}

	public bool CanHandleType(Type t)
	{
		return t == typeof(Location);
	}

	public static Location Parse(string v)
	{
		if (string.IsNullOrEmpty(v))
		{
			return null;
		}
		string[] i = v.Split(',');
		if (i.Length != 2)
		{
			throw new SolrNetException($"Invalid Location '{v}'");
		}
		if (!double.TryParse(i[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var latitude))
		{
			throw new SolrNetException($"Invalid Location '{v}'");
		}
		if (!double.TryParse(i[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var longitude))
		{
			throw new SolrNetException($"Invalid Location '{v}'");
		}
		return new Location(latitude, longitude);
	}

	public object Parse(XElement field, Type t)
	{
		return Parse(field.Value);
	}
}

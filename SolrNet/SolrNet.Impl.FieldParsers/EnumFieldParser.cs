using System;
using System.Xml.Linq;

namespace SolrNet.Impl.FieldParsers;

public class EnumFieldParser : ISolrFieldParser
{
	public bool CanHandleSolrType(string solrType)
	{
		return solrType == "str" || solrType == "int";
	}

	public bool CanHandleType(Type t)
	{
		return t.IsEnum;
	}

	public object Parse(XElement field, Type t)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		if (t == null)
		{
			throw new ArgumentNullException("t");
		}
		string value = field.Value;
		try
		{
			return Enum.Parse(t, field.Value);
		}
		catch (Exception e)
		{
			throw new Exception($"Invalid value '{value}' for enum type '{t}'", e);
		}
	}
}

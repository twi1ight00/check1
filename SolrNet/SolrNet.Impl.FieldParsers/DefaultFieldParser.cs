using System;
using System.Xml.Linq;

namespace SolrNet.Impl.FieldParsers;

/// <summary>
/// Default field parser
/// </summary>
public class DefaultFieldParser : ISolrFieldParser
{
	private readonly AggregateFieldParser parser;

	/// <summary>
	/// Default field parser
	/// </summary>
	public DefaultFieldParser()
	{
		parser = new AggregateFieldParser(new ISolrFieldParser[14]
		{
			new NullableFieldParser(new IntFieldParser()),
			new NullableFieldParser(new FloatFieldParser()),
			new NullableFieldParser(new DoubleFieldParser()),
			new NullableFieldParser(new DateTimeFieldParser()),
			new NullableFieldParser(new DateTimeOffsetFieldParser()),
			new NullableFieldParser(new DecimalFieldParser()),
			new NullableFieldParser(new LongFieldParser()),
			new NullableFieldParser(new EnumFieldParser()),
			new NullableFieldParser(new GuidFieldParser()),
			new CollectionFieldParser(this),
			new MoneyFieldParser(),
			new LocationFieldParser(),
			new TypeConvertingFieldParser(),
			new InferringFieldParser(this)
		});
	}

	public bool CanHandleSolrType(string solrType)
	{
		return parser.CanHandleSolrType(solrType);
	}

	public bool CanHandleType(Type t)
	{
		return parser.CanHandleType(t);
	}

	public object Parse(XElement field, Type t)
	{
		return parser.Parse(field, t);
	}
}

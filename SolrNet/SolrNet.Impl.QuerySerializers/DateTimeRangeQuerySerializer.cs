using System;
using System.Linq;

namespace SolrNet.Impl.QuerySerializers;

public class DateTimeRangeQuerySerializer : SingleTypeQuerySerializer<SolrQueryByRange<DateTime>>
{
	private readonly ISolrFieldSerializer fieldSerializer;

	public DateTimeRangeQuerySerializer(ISolrFieldSerializer fieldSerializer)
	{
		this.fieldSerializer = fieldSerializer;
	}

	public string SerializeSingle(object o)
	{
		return fieldSerializer.Serialize(o).First().FieldValue;
	}

	public override string Serialize(SolrQueryByRange<DateTime> q)
	{
		return RangeQuerySerializer.BuildRange(q.FieldName, SerializeSingle(q.From), SerializeSingle(q.To), q.InclusiveFrom, q.InclusiveTo);
	}
}

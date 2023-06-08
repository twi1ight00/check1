using System.Linq;

namespace SolrNet.Impl.QuerySerializers;

public class QueryInListSerializer : SingleTypeQuerySerializer<SolrQueryInList>
{
	private readonly ISolrQuerySerializer serializer;

	public QueryInListSerializer(ISolrQuerySerializer serializer)
	{
		this.serializer = serializer;
	}

	public override string Serialize(SolrQueryInList q)
	{
		if (string.IsNullOrEmpty(q.FieldName) || q.List == null || !q.List.Any())
		{
			return null;
		}
		string[] array = q.List.Select((string x) => "(" + QueryByFieldSerializer.Quote(x) + ")").ToArray();
		return "(" + serializer.Serialize(new SolrQueryByField(QueryByFieldSerializer.EscapeSpaces(q.FieldName), string.Join(" OR ", array))
		{
			Quoted = false
		}) + ")";
	}
}

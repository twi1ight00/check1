namespace SolrNet.Impl.QuerySerializers;

/// <summary>
/// Serializes a SolrQueryByFieldRegex query.
/// </summary>
public class QueryByFieldRegexSerializer : SingleTypeQuerySerializer<SolrQueryByFieldRegex>
{
	/// <summary>
	/// Serializes a SolrQueryByFieldRegex query.
	/// </summary>
	/// <param name="q">The query.</param>
	/// <returns></returns>
	public override string Serialize(SolrQueryByFieldRegex q)
	{
		if (q == null || q.FieldName == null || q.Expression == null)
		{
			return null;
		}
		string expression = q.Expression;
		if (expression.StartsWith("/") && expression.EndsWith("/"))
		{
			expression = expression.Substring(1, expression.Length - 2);
		}
		return $"{QueryByFieldSerializer.EscapeSpaces(q.FieldName)}:/{expression}/";
	}
}

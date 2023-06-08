using System.Text;

namespace SolrNet.Impl.QuerySerializers;

public class MultipleCriteriaQuerySerializer : SingleTypeQuerySerializer<SolrMultipleCriteriaQuery>
{
	private readonly ISolrQuerySerializer serializer;

	public MultipleCriteriaQuerySerializer(ISolrQuerySerializer serializer)
	{
		this.serializer = serializer;
	}

	public override string Serialize(SolrMultipleCriteriaQuery q)
	{
		StringBuilder queryBuilder = new StringBuilder();
		foreach (ISolrQuery query in q.Queries)
		{
			if (query == null)
			{
				continue;
			}
			string sq = serializer.Serialize(query);
			if (!string.IsNullOrEmpty(sq))
			{
				if (queryBuilder.Length > 0)
				{
					queryBuilder.AppendFormat(" {0} ", q.Oper);
				}
				queryBuilder.Append(sq);
			}
		}
		string queryString = queryBuilder.ToString();
		if (!string.IsNullOrEmpty(queryString))
		{
			queryString = "(" + queryString + ")";
		}
		return queryString;
	}
}

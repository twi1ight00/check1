using System;

namespace SolrNet;

/// <summary>
/// Standard MoreLikeThisHandlerQuery
/// </summary>
public class SolrMoreLikeThisHandlerQuery : SolrMLTQuery
{
	private readonly ISolrQuery query;

	public ISolrQuery Query => query;

	public SolrMoreLikeThisHandlerQuery(ISolrQuery query)
	{
		this.query = query;
	}

	public override T Switch<T>(Func<ISolrQuery, T> q, Func<string, T> streamBody, Func<Uri, T> streamUrl)
	{
		return q(query);
	}
}

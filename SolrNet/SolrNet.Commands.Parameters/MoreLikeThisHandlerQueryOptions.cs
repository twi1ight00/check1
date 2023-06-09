namespace SolrNet.Commands.Parameters;

/// <summary>
/// Query options for MoreLikeThis handler
/// See http://wiki.apache.org/solr/MoreLikeThisHandler
/// </summary>
public class MoreLikeThisHandlerQueryOptions : CommonQueryOptions
{
	/// <summary>
	/// Parameters for MoreLikeThis handler
	/// </summary>
	public MoreLikeThisHandlerParameters Parameters { get; set; }

	/// <summary>
	/// Query options for MoreLikeThis handler
	/// See http://wiki.apache.org/solr/MoreLikeThisHandler
	/// </summary>
	public MoreLikeThisHandlerQueryOptions(MoreLikeThisHandlerParameters parameters)
	{
		Parameters = parameters;
	}
}

namespace SolrNet.Impl;

public interface ISelfSerializingQuery : ISolrQuery
{
	string Query { get; }
}

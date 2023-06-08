namespace SolrNet;

/// <summary>
/// Contains parameters than can be specified when deleting a document from the index.
/// </summary>
/// <remarks>
/// CommitWithin works in SOLR 3.6+ - see https://issues.apache.org/jira/browse/SOLR-2280
/// </remarks>
public class DeleteParameters : UpdateParameters
{
}

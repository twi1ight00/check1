namespace SolrNet.Impl;

public interface ISolrQueryByRange
{
	string FieldName { get; }

	object From { get; }

	object To { get; }

	/// <summary>
	/// Is lower and upper bound inclusive
	/// </summary>
	bool Inclusive { get; }

	/// <summary>
	/// Is lower bound <see cref="P:SolrNet.Impl.ISolrQueryByRange.From" /> inclusive
	/// ONLY available in Solr 4.0+
	/// </summary>
	bool InclusiveFrom { get; }

	/// <summary>
	/// Is upper bound <see cref="P:SolrNet.Impl.ISolrQueryByRange.To" /> inclusive
	/// ONLY available in Solr 4.0+
	/// </summary>
	bool InclusiveTo { get; }
}

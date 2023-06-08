using System;
using System.Collections.Generic;
using SolrNet.Impl;

namespace SolrNet;

/// <summary>
/// Query results
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class SolrQueryResults<T> : AbstractSolrQueryResults<T>
{
	/// <summary>
	/// Highlight results
	/// </summary>
	public IDictionary<string, HighlightedSnippets> Highlights { get; set; }

	/// <summary>
	/// Spellchecking results
	/// </summary>
	public SpellCheckResults SpellChecking { get; set; }

	/// <summary>
	/// More-like-this component results
	/// </summary>
	public IDictionary<string, IList<T>> SimilarResults { get; set; }

	/// <summary>
	/// Stats component results
	/// </summary>
	public IDictionary<string, StatsResult> Stats { get; set; }

	/// <summary>
	/// Collapse results
	/// </summary>
	[Obsolete("Use result grouping instead")]
	public CollapseResults Collapsing { get; set; }

	/// <summary>
	/// CollapseExpand results
	/// </summary>
	public CollapseExpandResults<T> CollapseExpand { get; set; }

	/// <summary>
	/// Clustering results
	/// </summary>
	public ClusterResults Clusters { get; set; }

	/// <summary>
	/// TermsComponent results
	/// </summary>
	public TermsResults Terms { get; set; }

	/// <summary>
	/// TermVectorComponent results
	/// </summary>
	public ICollection<TermVectorDocumentResult> TermVectorResults { get; set; }

	/// <summary>
	/// Grouping results
	/// </summary>
	public IDictionary<string, GroupedResults<T>> Grouping { get; set; }

	/// <summary>
	/// Debug results
	/// </summary>
	public DebugResults Debug { get; set; }

	public SolrQueryResults()
	{
		SpellChecking = new SpellCheckResults();
		SimilarResults = new Dictionary<string, IList<T>>();
		Stats = new Dictionary<string, StatsResult>();
		Collapsing = new CollapseResults();
		Grouping = new Dictionary<string, GroupedResults<T>>();
		Terms = new TermsResults();
	}

	public override R Switch<R>(Func<SolrQueryResults<T>, R> query, Func<SolrMoreLikeThisHandlerResults<T>, R> moreLikeThis)
	{
		return query(this);
	}
}

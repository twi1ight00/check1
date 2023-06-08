using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Commands.Parameters;
using SolrNet.Exceptions;
using SolrNet.Utils;

namespace SolrNet.Impl;

/// <summary>
/// Executes queries
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class SolrQueryExecuter<T> : ISolrQueryExecuter<T>
{
	private readonly ISolrAbstractResponseParser<T> resultParser;

	private readonly ISolrMoreLikeThisHandlerQueryResultsParser<T> mlthResultParser;

	private readonly ISolrConnection connection;

	private readonly ISolrQuerySerializer querySerializer;

	private readonly ISolrFacetQuerySerializer facetQuerySerializer;

	/// <summary>
	/// When row limit is not defined, this value is used
	/// </summary>
	public static readonly int ConstDefaultRows = 100000000;

	/// <summary>
	/// Default Solr query handler
	/// </summary>
	public static readonly string DefaultHandler = "/select";

	/// <summary>
	/// Default Solr handler for More Like This queries
	/// </summary>
	public static readonly string DefaultMoreLikeThisHandler = "/mlt";

	/// <summary>
	/// When the row count is not defined, use this row count by default
	/// </summary>
	public int DefaultRows { get; set; }

	/// <summary>
	/// Solr query request handler to use. By default "/select"
	/// </summary>
	public string Handler { get; set; }

	/// <summary>
	/// Solr request handler to use for MoreLikeThis-handler queries. By default "/mlt"
	/// </summary>
	public string MoreLikeThisHandler { get; set; }

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="resultParser"></param>
	/// <param name="connection"></param>
	/// <param name="querySerializer"></param>
	/// <param name="facetQuerySerializer"></param>
	/// <param name="mlthResultParser"></param>
	public SolrQueryExecuter(ISolrAbstractResponseParser<T> resultParser, ISolrConnection connection, ISolrQuerySerializer querySerializer, ISolrFacetQuerySerializer facetQuerySerializer, ISolrMoreLikeThisHandlerQueryResultsParser<T> mlthResultParser)
	{
		this.resultParser = resultParser;
		this.mlthResultParser = mlthResultParser;
		this.connection = connection;
		this.querySerializer = querySerializer;
		this.facetQuerySerializer = facetQuerySerializer;
		DefaultRows = ConstDefaultRows;
		Handler = DefaultHandler;
		MoreLikeThisHandler = DefaultMoreLikeThisHandler;
	}

	/// <summary>
	/// Serializes common query parameters
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetCommonParameters(CommonQueryOptions options)
	{
		if (options == null)
		{
			yield break;
		}
		if (options.StartOrCursor != null)
		{
			yield return options.StartOrCursor.Switch((StartOrCursor.Start start) => KV.Create("start", start.Row.ToString()), (StartOrCursor.Cursor cursor) => KV.Create("cursorMark", cursor.ToString()));
		}
		else if (options.Start.HasValue)
		{
			yield return KV.Create("start", options.Start.ToString());
		}
		yield return KV.Create("rows", (options.Rows.HasValue ? options.Rows.Value : DefaultRows).ToString());
		if (options.Fields != null && options.Fields.Count > 0)
		{
			yield return KV.Create("fl", string.Join(",", options.Fields.ToArray()));
		}
		foreach (KeyValuePair<string, string> filterQuery in GetFilterQueries(options.FilterQueries))
		{
			yield return filterQuery;
		}
		foreach (KeyValuePair<string, string> facetFieldOption in GetFacetFieldOptions(options.Facet))
		{
			yield return facetFieldOption;
		}
		if (options.ExtraParams != null)
		{
			foreach (KeyValuePair<string, string> extraParam in options.ExtraParams)
			{
				yield return extraParam;
			}
		}
		if (options.Debug)
		{
			yield return KV.Create("debugQuery", "true");
		}
	}

	/// <summary>
	/// Gets Solr parameters for all defined query options
	/// </summary>
	/// <param name="Query"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetAllParameters(ISolrQuery Query, QueryOptions options)
	{
		yield return KV.Create("q", querySerializer.Serialize(Query));
		if (options == null)
		{
			yield break;
		}
		foreach (KeyValuePair<string, string> commonParameter in GetCommonParameters(options))
		{
			yield return commonParameter;
		}
		if (options.OrderBy != null && options.OrderBy.Count > 0)
		{
			yield return KV.Create("sort", string.Join(",", options.OrderBy.Select((SortOrder x) => x.ToString()).ToArray()));
		}
		foreach (KeyValuePair<string, string> highlightingParameter in GetHighlightingParameters(options))
		{
			yield return highlightingParameter;
		}
		foreach (KeyValuePair<string, string> spellCheckingParameter in GetSpellCheckingParameters(options))
		{
			yield return spellCheckingParameter;
		}
		foreach (KeyValuePair<string, string> termsParameter in GetTermsParameters(options))
		{
			yield return termsParameter;
		}
		if (options.MoreLikeThis != null)
		{
			foreach (KeyValuePair<string, string> moreLikeThisParameter in GetMoreLikeThisParameters(options.MoreLikeThis))
			{
				yield return moreLikeThisParameter;
			}
		}
		foreach (KeyValuePair<string, string> statsQueryOption in GetStatsQueryOptions(options))
		{
			yield return statsQueryOption;
		}
		foreach (KeyValuePair<string, string> collapseQueryOption in GetCollapseQueryOptions(options))
		{
			yield return collapseQueryOption;
		}
		foreach (KeyValuePair<string, string> termVectorQueryOption in GetTermVectorQueryOptions(options))
		{
			yield return termVectorQueryOption;
		}
		foreach (KeyValuePair<string, string> groupingQueryOption in GetGroupingQueryOptions(options))
		{
			yield return groupingQueryOption;
		}
		foreach (KeyValuePair<string, string> collapseExpandOption in GetCollapseExpandOptions(options.CollapseExpand, querySerializer.Serialize))
		{
			yield return collapseExpandOption;
		}
		foreach (KeyValuePair<string, string> clusteringParameter in GetClusteringParameters(options))
		{
			yield return clusteringParameter;
		}
	}

	/// <summary>
	/// Serializes all More Like This handler parameters
	/// </summary>
	/// <param name="query"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetAllMoreLikeThisHandlerParameters(SolrMLTQuery query, MoreLikeThisHandlerQueryOptions options)
	{
		yield return query.Switch((ISolrQuery q) => KV.Create("q", querySerializer.Serialize(q)), (string body) => KV.Create("stream.body", body), (Uri url) => KV.Create("stream.url", url.ToString()));
		if (options == null)
		{
			yield break;
		}
		foreach (KeyValuePair<string, string> commonParameter in GetCommonParameters(options))
		{
			yield return commonParameter;
		}
		foreach (KeyValuePair<string, string> moreLikeThisHandlerParameter in GetMoreLikeThisHandlerParameters(options.Parameters))
		{
			yield return moreLikeThisHandlerParameter;
		}
	}

	/// <summary>
	/// Gets Solr parameters for facet queries
	/// </summary>
	/// <param name="fp"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetFacetFieldOptions(FacetParameters fp)
	{
		if (fp == null || fp.Queries == null || fp.Queries.Count == 0)
		{
			yield break;
		}
		yield return KV.Create("facet", "true");
		foreach (ISolrFacetQuery fq in fp.Queries)
		{
			foreach (KeyValuePair<string, string> item in facetQuerySerializer.Serialize(fq))
			{
				yield return item;
			}
		}
		if (fp.Prefix != null)
		{
			yield return KV.Create("facet.prefix", fp.Prefix);
		}
		if (fp.EnumCacheMinDf.HasValue)
		{
			yield return KV.Create("facet.enum.cache.minDf", fp.EnumCacheMinDf.ToString());
		}
		if (fp.Limit.HasValue)
		{
			yield return KV.Create("facet.limit", fp.Limit.ToString());
		}
		if (fp.MinCount.HasValue)
		{
			yield return KV.Create("facet.mincount", fp.MinCount.ToString());
		}
		if (fp.Missing.HasValue)
		{
			yield return KV.Create("facet.missing", fp.Missing.ToString().ToLowerInvariant());
		}
		if (fp.Offset.HasValue)
		{
			yield return KV.Create("facet.offset", fp.Offset.ToString());
		}
		if (fp.Sort.HasValue)
		{
			yield return KV.Create("facet.sort", fp.Sort.ToString().ToLowerInvariant());
		}
		if (fp.Threads.HasValue)
		{
			yield return KV.Create("facet.threads", fp.Threads.ToString().ToLowerInvariant());
		}
	}

	/// <summary>
	/// Serializes More Like This handler specific parameters
	/// </summary>
	/// <param name="mlt"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetMoreLikeThisHandlerParameters(MoreLikeThisHandlerParameters mlt)
	{
		if (mlt.MatchInclude.HasValue)
		{
			yield return KV.Create("mlt.match.include", mlt.MatchInclude.Value.ToString().ToLowerInvariant());
		}
		if (mlt.MatchOffset.HasValue)
		{
			yield return KV.Create("mlt.match.offset", mlt.MatchOffset.Value.ToString());
		}
		if (mlt.ShowTerms.HasValue)
		{
			yield return KV.Create("mlt.interestingTerms", mlt.ShowTerms.ToString().ToLowerInvariant());
		}
		foreach (KeyValuePair<string, string> moreLikeThisParameter in GetMoreLikeThisParameters(mlt))
		{
			yield return moreLikeThisParameter;
		}
	}

	/// <summary>
	/// Gets Solr parameters for defined more-like-this options
	/// </summary>
	/// <param name="mlt"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetMoreLikeThisParameters(MoreLikeThisParameters mlt)
	{
		yield return KV.Create("mlt", "true");
		if (mlt.Fields != null)
		{
			yield return KV.Create("mlt.fl", string.Join(",", mlt.Fields.ToArray()));
		}
		if (mlt.Boost.HasValue)
		{
			yield return KV.Create("mlt.boost", mlt.Boost.ToString().ToLowerInvariant());
		}
		if (mlt.Count.HasValue)
		{
			yield return KV.Create("mlt.count", mlt.Count.ToString());
		}
		if (mlt.MaxQueryTerms.HasValue)
		{
			yield return KV.Create("mlt.maxqt", mlt.MaxQueryTerms.ToString());
		}
		if (mlt.MaxTokens.HasValue)
		{
			yield return KV.Create("mlt.maxntp", mlt.MaxTokens.ToString());
		}
		if (mlt.MaxWordLength.HasValue)
		{
			yield return KV.Create("mlt.maxwl", mlt.MaxWordLength.ToString());
		}
		if (mlt.MinDocFreq.HasValue)
		{
			yield return KV.Create("mlt.mindf", mlt.MinDocFreq.ToString());
		}
		if (mlt.MinTermFreq.HasValue)
		{
			yield return KV.Create("mlt.mintf", mlt.MinTermFreq.ToString());
		}
		if (mlt.MinWordLength.HasValue)
		{
			yield return KV.Create("mlt.minwl", mlt.MinWordLength.ToString());
		}
		if (mlt.QueryFields != null && mlt.QueryFields.Count > 0)
		{
			yield return KV.Create("mlt.qf", string.Join(",", mlt.QueryFields.ToArray()));
		}
	}

	/// <summary>
	/// Gets Solr parameters for defined filter queries
	/// </summary>
	public IEnumerable<KeyValuePair<string, string>> GetFilterQueries(ICollection<ISolrQuery> filterQueries)
	{
		if (filterQueries == null || filterQueries.Count == 0)
		{
			yield break;
		}
		foreach (ISolrQuery fq in filterQueries)
		{
			yield return new KeyValuePair<string, string>("fq", querySerializer.Serialize(fq));
		}
	}

	/// <summary>
	/// Gets Solr parameters for defined highlightings
	/// </summary>
	public IDictionary<string, string> GetHighlightingParameters(QueryOptions Options)
	{
		Dictionary<string, string> param = new Dictionary<string, string>();
		if (Options.Highlight != null)
		{
			HighlightingParameters h = Options.Highlight;
			param["hl"] = "true";
			if (h.Fields != null)
			{
				param["hl.fl"] = string.Join(",", h.Fields.ToArray());
			}
			if (h.Snippets.HasValue)
			{
				param["hl.snippets"] = h.Snippets.Value.ToString();
			}
			if (h.Fragsize.HasValue)
			{
				param["hl.fragsize"] = h.Fragsize.Value.ToString();
			}
			if (h.RequireFieldMatch.HasValue)
			{
				param["hl.requireFieldMatch"] = h.RequireFieldMatch.Value.ToString().ToLowerInvariant();
			}
			if (h.AlternateField != null)
			{
				param["hl.alternateField"] = h.AlternateField;
			}
			if (h.BeforeTerm != null)
			{
				param[(h.UseFastVectorHighlighter == true) ? "hl.tag.pre" : "hl.simple.pre"] = h.BeforeTerm;
			}
			if (h.AfterTerm != null)
			{
				param[(h.UseFastVectorHighlighter == true) ? "hl.tag.post" : "hl.simple.post"] = h.AfterTerm;
			}
			if (h.Query != null)
			{
				param["hl.q"] = querySerializer.Serialize(h.Query);
			}
			if (h.RegexSlop.HasValue)
			{
				param["hl.regex.slop"] = Convert.ToString(h.RegexSlop.Value, CultureInfo.InvariantCulture);
			}
			if (h.RegexPattern != null)
			{
				param["hl.regex.pattern"] = h.RegexPattern;
			}
			if (h.RegexMaxAnalyzedChars.HasValue)
			{
				param["hl.regex.maxAnalyzedChars"] = h.RegexMaxAnalyzedChars.Value.ToString();
			}
			if (h.UsePhraseHighlighter.HasValue)
			{
				param["hl.usePhraseHighlighter"] = h.UsePhraseHighlighter.Value.ToString().ToLowerInvariant();
			}
			if (h.UseFastVectorHighlighter.HasValue)
			{
				param["hl.useFastVectorHighlighter"] = h.UseFastVectorHighlighter.Value.ToString().ToLowerInvariant();
			}
			if (h.HighlightMultiTerm.HasValue)
			{
				param["hl.highlightMultiTerm"] = h.HighlightMultiTerm.Value.ToString().ToLowerInvariant();
			}
			if (h.MergeContiguous.HasValue)
			{
				param["hl.mergeContiguous"] = h.MergeContiguous.Value.ToString().ToLowerInvariant();
			}
			if (h.MaxAnalyzedChars.HasValue)
			{
				param["hl.maxAnalyzedChars"] = h.MaxAnalyzedChars.Value.ToString();
			}
			if (h.MaxAlternateFieldLength.HasValue)
			{
				param["hl.maxAlternateFieldLength"] = h.MaxAlternateFieldLength.Value.ToString();
			}
			if (h.Fragmenter.HasValue)
			{
				param["hl.fragmenter"] = ((h.Fragmenter.Value == SolrHighlightFragmenter.Regex) ? "regex" : "gap");
			}
		}
		return param;
	}

	/// <summary>
	/// Gets solr parameters for defined spell-checking
	/// </summary>
	public IEnumerable<KeyValuePair<string, string>> GetSpellCheckingParameters(QueryOptions Options)
	{
		SpellCheckingParameters spellCheck = Options.SpellCheck;
		if (spellCheck != null)
		{
			yield return KV.Create("spellcheck", "true");
			if (!string.IsNullOrEmpty(spellCheck.Query))
			{
				yield return KV.Create("spellcheck.q", spellCheck.Query);
			}
			if (spellCheck.Build.HasValue)
			{
				yield return KV.Create("spellcheck.build", spellCheck.Build.ToString().ToLowerInvariant());
			}
			if (spellCheck.Collate.HasValue)
			{
				yield return KV.Create("spellcheck.collate", spellCheck.Collate.ToString().ToLowerInvariant());
			}
			if (spellCheck.Count.HasValue)
			{
				yield return KV.Create("spellcheck.count", spellCheck.Count.ToString());
			}
			if (!string.IsNullOrEmpty(spellCheck.Dictionary))
			{
				yield return KV.Create("spellcheck.dictionary", spellCheck.Dictionary);
			}
			if (spellCheck.OnlyMorePopular.HasValue)
			{
				yield return KV.Create("spellcheck.onlyMorePopular", spellCheck.OnlyMorePopular.ToString().ToLowerInvariant());
			}
			if (spellCheck.Reload.HasValue)
			{
				yield return KV.Create("spellcheck.reload", spellCheck.Reload.ToString().ToLowerInvariant());
			}
		}
	}

	/// <summary>
	/// Gets the Solr parameters for stats queries
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetStatsQueryOptions(QueryOptions options)
	{
		if (options.Stats == null || options.Stats.FieldsWithFacets.Count == 0)
		{
			yield break;
		}
		yield return KV.Create("stats", "true");
		foreach (KeyValuePair<string, ICollection<string>> fieldAndFacet in options.Stats.FieldsWithFacets)
		{
			KeyValuePair<string, ICollection<string>> keyValuePair = fieldAndFacet;
			string field = keyValuePair.Key;
			if (string.IsNullOrEmpty(field))
			{
				continue;
			}
			keyValuePair = fieldAndFacet;
			ICollection<string> facets = keyValuePair.Value;
			yield return KV.Create("stats.field", field);
			if (facets == null || facets.Count <= 0)
			{
				continue;
			}
			foreach (string facet2 in facets)
			{
				if (!string.IsNullOrEmpty(facet2))
				{
					yield return KV.Create($"f.{field}.stats.facet", facet2);
				}
			}
		}
		if (options.Stats.Facets == null || options.Stats.Facets.Count == 0)
		{
			yield break;
		}
		foreach (string facet in options.Stats.Facets)
		{
			if (!string.IsNullOrEmpty(facet))
			{
				yield return KV.Create("stats.facet", facet);
			}
		}
	}

	/// <summary>
	/// Gets the Solr parameters for collapse queries
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetCollapseQueryOptions(QueryOptions options)
	{
		if (options.Collapse != null && !string.IsNullOrEmpty(options.Collapse.Field))
		{
			yield return KV.Create("collapse.field", options.Collapse.Field);
			if (options.Collapse.Threshold.HasValue)
			{
				yield return KV.Create("collapse.threshold", options.Collapse.Threshold.ToString());
			}
			yield return KV.Create("collapse.type", options.Collapse.Type.ToString());
			yield return KV.Create("collapse.facet", options.Collapse.FacetMode.ToString().ToLowerInvariant());
			if (options.Collapse.MaxDocs.HasValue)
			{
				yield return KV.Create("collapse.maxdocs", options.Collapse.MaxDocs.ToString());
			}
		}
	}

	public static IEnumerable<string> GetTermVectorParameterOptions(TermVectorParameterOptions o)
	{
		if ((o & TermVectorParameterOptions.All) == TermVectorParameterOptions.All)
		{
			yield return "tv.all";
			yield break;
		}
		if ((o & TermVectorParameterOptions.TermFrequency_InverseDocumentFrequency) == TermVectorParameterOptions.TermFrequency_InverseDocumentFrequency)
		{
			yield return "tv.tf";
			yield return "tv.df";
			yield return "tv.tf_idf";
		}
		if ((o & TermVectorParameterOptions.Offsets) == TermVectorParameterOptions.Offsets)
		{
			yield return "tv.offsets";
		}
		if ((o & TermVectorParameterOptions.Positions) == TermVectorParameterOptions.Positions)
		{
			yield return "tv.positions";
		}
		if ((o & TermVectorParameterOptions.DocumentFrequency) == TermVectorParameterOptions.DocumentFrequency)
		{
			yield return "tv.df";
		}
		if ((o & TermVectorParameterOptions.TermFrequency) == TermVectorParameterOptions.TermFrequency)
		{
			yield return "tv.tf";
		}
	}

	/// <summary>
	/// Gets the Solr parameters for collapse queries
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public static IEnumerable<KeyValuePair<string, string>> GetTermVectorQueryOptions(QueryOptions options)
	{
		if (options.TermVector == null || !options.TermVector.Fields.Any())
		{
			yield break;
		}
		yield return KV.Create("tv", "true");
		if (options.TermVector.Fields != null)
		{
			string fields = string.Join(",", options.TermVector.Fields.ToArray());
			if (!string.IsNullOrEmpty(fields))
			{
				yield return KV.Create("tv.fl", fields);
			}
		}
		foreach (string o in GetTermVectorParameterOptions(options.TermVector.Options).Distinct())
		{
			yield return KV.Create(o, "true");
		}
	}

	/// <summary>
	/// Gets the Solr parameters for collapse queries
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetGroupingQueryOptions(QueryOptions options)
	{
		if (options.Grouping == null)
		{
			yield break;
		}
		yield return KV.Create("group", true.ToString().ToLowerInvariant());
		if (options.Grouping.Fields != null)
		{
			foreach (string groupfield in options.Grouping.Fields)
			{
				if (!string.IsNullOrEmpty(groupfield))
				{
					yield return KV.Create("group.field", groupfield);
				}
			}
		}
		if (options.Grouping.Limit.HasValue)
		{
			yield return KV.Create("group.limit", options.Grouping.Limit.ToString());
		}
		if (options.Grouping.Offset.HasValue)
		{
			yield return KV.Create("group.offset", options.Grouping.Offset.ToString());
		}
		if (options.Grouping.Main.HasValue)
		{
			yield return KV.Create("group.main", options.Grouping.Main.ToString().ToLowerInvariant());
		}
		if (options.Grouping.Query != null)
		{
			foreach (ISolrQuery query2 in options.Grouping.Query.Where((ISolrQuery query) => query != null))
			{
				yield return KV.Create("group.query", querySerializer.Serialize(query2));
			}
		}
		if (!string.IsNullOrEmpty(options.Grouping.Func))
		{
			yield return KV.Create("group.func", options.Grouping.Func);
		}
		if (options.Grouping.OrderBy != null && options.Grouping.OrderBy.Count > 0)
		{
			yield return KV.Create("group.sort", string.Join(",", options.Grouping.OrderBy.Select((SortOrder x) => x.ToString()).ToArray()));
		}
		if (options.Grouping.Ngroups.HasValue)
		{
			yield return KV.Create("group.ngroups", options.Grouping.Ngroups.ToString().ToLowerInvariant());
		}
		if (options.Grouping.Truncate.HasValue)
		{
			yield return KV.Create("group.truncate", options.Grouping.Truncate.ToString().ToLowerInvariant());
		}
		if (options.Grouping.CachePercent.HasValue)
		{
			yield return KV.Create("group.cache.percent", options.Grouping.CachePercent.ToString());
		}
		yield return KV.Create("group.format", options.Grouping.Format.ToString().ToLowerInvariant());
	}

	public static IEnumerable<KeyValuePair<string, string>> GetCollapseOptions(CollapseExpandParameters options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		yield return KV.Create("field", options.Field);
		if (options.NullPolicy != null)
		{
			yield return KV.Create("nullPolicy", options.NullPolicy.Policy);
		}
		if (options.MinOrMaxField != null)
		{
			yield return options.MinOrMaxField.Switch((CollapseExpandParameters.MinOrMax.Min x) => KV.Create("min", x.Field), (CollapseExpandParameters.MinOrMax.Max x) => KV.Create("max", x.Field));
		}
	}

	public static IEnumerable<KeyValuePair<string, string>> GetExpandOptions(ExpandParameters parameters, Func<ISolrQuery, string> serializer)
	{
		if (parameters != null)
		{
			yield return KV.Create("expand", "true");
			if (parameters.Rows.HasValue)
			{
				yield return KV.Create("expand.rows", parameters.Rows.Value.ToString());
			}
			if (parameters.Sort != null)
			{
				yield return KV.Create("expand.sort", parameters.Sort.ToString());
			}
			if (serializer == null)
			{
				throw new ArgumentNullException("serializer");
			}
			if (parameters.Query != null)
			{
				yield return KV.Create("expand.q", serializer(parameters.Query));
			}
			if (parameters.FilterQuery != null)
			{
				yield return KV.Create("expand.fq", serializer(parameters.FilterQuery));
			}
		}
	}

	/// <summary>
	/// Gets the solr parameters for collapse-expand queries
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public static IEnumerable<KeyValuePair<string, string>> GetCollapseExpandOptions(CollapseExpandParameters options, Func<ISolrQuery, string> serializer)
	{
		if (options == null)
		{
			yield break;
		}
		string[] collapseValues = (from x in GetCollapseOptions(options)
			select x.Key + "=" + x.Value).ToArray();
		yield return KV.Create("fq", "{!collapse " + string.Join(" ", collapseValues) + "}");
		foreach (KeyValuePair<string, string> expandOption in GetExpandOptions(options.Expand, serializer))
		{
			yield return expandOption;
		}
	}

	/// <summary>
	/// Get the solr parameters for clustering
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public IEnumerable<KeyValuePair<string, string>> GetClusteringParameters(QueryOptions options)
	{
		if (options.Clustering != null)
		{
			ClusteringParameters clst = options.Clustering;
			yield return KV.Create("clustering", true.ToString().ToLowerInvariant());
			if (clst.Engine != null)
			{
				yield return KV.Create("clustering.engine", clst.Engine);
			}
			if (clst.Results.HasValue)
			{
				yield return KV.Create("clustering.results", clst.Results.ToString().ToLowerInvariant());
			}
			if (clst.Collection.HasValue)
			{
				yield return KV.Create("clustering.collection", clst.Collection.ToString().ToLowerInvariant());
			}
			if (clst.Algorithm != null)
			{
				yield return KV.Create("carrot.algorithm", clst.Algorithm);
			}
			if (clst.Title != null)
			{
				yield return KV.Create("carrot.title", clst.Title);
			}
			if (clst.Snippet != null)
			{
				yield return KV.Create("carrot.snippet", clst.Snippet);
			}
			if (clst.Url != null)
			{
				yield return KV.Create("carrot.url", clst.Url);
			}
			if (clst.ProduceSummary.HasValue)
			{
				yield return KV.Create("carrot.produceSummary", clst.ProduceSummary.ToString().ToLowerInvariant());
			}
			if (clst.FragSize.HasValue)
			{
				yield return KV.Create("carrot.fragSize", clst.FragSize.ToString());
			}
			if (clst.NumDescriptions.HasValue)
			{
				yield return KV.Create("carrot.numDescriptions", clst.NumDescriptions.ToString());
			}
			if (clst.SubClusters.HasValue)
			{
				yield return KV.Create("carrot.outputSubClusters", clst.SubClusters.ToString().ToLowerInvariant());
			}
			if (clst.LexicalResources != null)
			{
				yield return KV.Create("carrot.lexicalResourcesDir", clst.LexicalResources);
			}
		}
	}

	/// <summary>
	/// Gets solr parameters for terms component
	/// </summary>
	/// <param name="Options"></param>
	/// <returns></returns>
	public static IEnumerable<KeyValuePair<string, string>> GetTermsParameters(QueryOptions Options)
	{
		TermsParameters terms = Options.Terms;
		if (terms == null)
		{
			yield break;
		}
		if (terms.Fields == null || !terms.Fields.Any())
		{
			throw new SolrNetException("Terms field can't be empty or null");
		}
		yield return KV.Create("terms", "true");
		foreach (string field in terms.Fields)
		{
			yield return KV.Create("terms.fl", field);
		}
		if (!string.IsNullOrEmpty(terms.Prefix))
		{
			yield return KV.Create("terms.prefix", terms.Prefix);
		}
		if (terms.Sort != null)
		{
			yield return KV.Create("terms.sort", terms.Sort.ToString());
		}
		if (terms.Limit.HasValue)
		{
			yield return KV.Create("terms.limit", terms.Limit.ToString());
		}
		if (!string.IsNullOrEmpty(terms.Lower))
		{
			yield return KV.Create("terms.lower", terms.Lower);
		}
		if (terms.LowerInclude.HasValue)
		{
			yield return KV.Create("terms.lower.incl", terms.LowerInclude.ToString().ToLowerInvariant());
		}
		if (!string.IsNullOrEmpty(terms.Upper))
		{
			yield return KV.Create("terms.upper", terms.Upper);
		}
		if (terms.UpperInclude.HasValue)
		{
			yield return KV.Create("terms.upper.incl", terms.UpperInclude.ToString().ToLowerInvariant());
		}
		if (terms.MaxCount.HasValue)
		{
			yield return KV.Create("terms.maxcount", terms.MaxCount.ToString());
		}
		if (terms.MinCount.HasValue)
		{
			yield return KV.Create("terms.mincount", terms.MinCount.ToString());
		}
		if (terms.Raw.HasValue)
		{
			yield return KV.Create("terms.raw", terms.Raw.ToString().ToLowerInvariant());
		}
		if (!string.IsNullOrEmpty(terms.Regex))
		{
			yield return KV.Create("terms.regex", terms.Regex);
		}
		if (terms.RegexFlag == null)
		{
			yield break;
		}
		foreach (RegexFlag flag in terms.RegexFlag)
		{
			yield return KV.Create("terms.regex.flag", flag.ToString());
		}
	}

	/// <summary>
	/// Executes the query and returns results
	/// </summary>
	/// <returns>query results</returns>
	public SolrQueryResults<T> Execute(ISolrQuery q, QueryOptions options)
	{
		IEnumerable<KeyValuePair<string, string>> param = GetAllParameters(q, options);
		SolrQueryResults<T> results = new SolrQueryResults<T>();
		string r = connection.Get(Handler, param);
		XDocument xml = XDocument.Parse(r);
		resultParser.Parse(xml, results);
		return results;
	}

	/// <summary>
	/// Executes a MoreLikeThis handler query
	/// </summary>
	/// <param name="q"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public SolrMoreLikeThisHandlerResults<T> Execute(SolrMLTQuery q, MoreLikeThisHandlerQueryOptions options)
	{
		List<KeyValuePair<string, string>> param = GetAllMoreLikeThisHandlerParameters(q, options).ToList();
		string r = connection.Get(MoreLikeThisHandler, param);
		return mlthResultParser.Parse(r);
	}
}

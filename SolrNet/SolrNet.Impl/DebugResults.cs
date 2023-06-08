using System.Collections.Generic;
using System.Linq;

namespace SolrNet.Impl;

/// <summary>
/// Debug results model
/// </summary>
public abstract class DebugResults
{
	/// <summary>
	/// Plain debug results model
	/// </summary>
	public sealed class PlainDebugResults : DebugResults
	{
		/// <summary>
		/// Plain debug results initializer
		/// </summary>
		public PlainDebugResults(TimingResults timing, string parsedQuery, string parsedQueryString, IDictionary<string, string> explanation)
			: base(timing, parsedQuery, parsedQueryString, explanation)
		{
		}
	}

	/// <summary>
	/// Structured debug results model
	/// </summary>
	public sealed class StructuredDebugResults : DebugResults
	{
		private readonly IDictionary<string, ExplanationModel> structuredExplanation;

		/// <summary>
		/// Structured explanation
		/// </summary>
		public IDictionary<string, ExplanationModel> ExplanationStructured => structuredExplanation;

		/// <summary>
		/// Structured debug results initializer
		/// </summary>
		public StructuredDebugResults(TimingResults timing, string parsedQuery, string parsedQueryString, IDictionary<string, ExplanationModel> structuredExplanation)
			: base(timing, parsedQuery, parsedQueryString, structuredExplanation.ToDictionary((KeyValuePair<string, ExplanationModel> x) => x.Key, (KeyValuePair<string, ExplanationModel> y) => y.Value.ToString()))
		{
			this.structuredExplanation = structuredExplanation;
		}
	}

	private readonly TimingResults timing;

	private readonly string parsedQuery;

	private readonly string parsedQueryString;

	private readonly IDictionary<string, string> explanation;

	/// <summary>
	/// Timing results
	/// </summary>
	public TimingResults Timing => timing;

	/// <summary>
	/// Explanation results (plain or structured)
	/// </summary>
	public IDictionary<string, string> Explanation => explanation;

	/// <summary>
	/// Parsed query
	/// </summary>
	public string ParsedQuery => parsedQuery;

	/// <summary>
	/// Parsed query string
	/// </summary>
	public string ParsedQueryString => parsedQueryString;

	private DebugResults(TimingResults timing, string parsedQuery, string parsedQueryString, IDictionary<string, string> explanation)
	{
		this.timing = timing;
		this.parsedQuery = parsedQuery;
		this.parsedQueryString = parsedQueryString;
		this.explanation = explanation;
	}
}

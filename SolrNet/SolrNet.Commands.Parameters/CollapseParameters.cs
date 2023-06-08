using System;

namespace SolrNet.Commands.Parameters;

/// <summary>
/// Parameters to query collapse
/// <see cref="!:https://issues.apache.org/jira/browse/SOLR-236" />
/// </summary>
[Obsolete("Use result grouping instead")]
public class CollapseParameters
{
	/// <summary>
	/// Field to group results by
	/// </summary>
	public string Field { get; set; }

	/// <summary>
	/// Number of continuous results allowed before collapsing
	/// </summary>
	public int? Threshold { get; set; }

	/// <summary>
	/// limits the number of documents that CollapseFilter will process to create the filter DocSet. 
	/// The intention of this is to be able to limit the time collapsing will take for very large result sets 
	/// (obviously at the expense of accurate collapsing in those cases).
	/// </summary>
	public int? MaxDocs { get; set; }

	/// <summary>
	/// Number of continuous results allowed before collapsing
	/// </summary>
	public CollapseFacetMode FacetMode { get; set; }

	/// <summary>
	/// Collapse type: Adjacent or Normal
	/// </summary>
	public CollapseType Type { get; set; }

	public CollapseParameters(string field)
	{
		Field = field;
		Type = CollapseType.Normal;
		FacetMode = CollapseFacetMode.Before;
	}
}

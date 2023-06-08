using System;
using System.Collections.Generic;

namespace SolrNet.Commands.Parameters;

/// <summary>
/// Parameters to query stats
/// <see href="http://wiki.apache.org/solr/StatsComponent" />
/// </summary>
public class StatsParameters
{
	/// <summary>
	/// Dictionary of fields to get stats, and their associated facets (if any)
	/// </summary>
	public IDictionary<string, ICollection<string>> FieldsWithFacets { get; set; }

	/// <summary>
	/// Global facets: get these facets' stats for all fields requested in <see cref="P:SolrNet.Commands.Parameters.StatsParameters.FieldsWithFacets" />
	/// </summary>
	public ICollection<string> Facets { get; set; }

	/// <summary>
	/// Adds a facet to the <see cref="P:SolrNet.Commands.Parameters.StatsParameters.Facets" /> collection
	/// </summary>
	/// <param name="facet"></param>
	/// <returns></returns>
	public StatsParameters AddFacet(string facet)
	{
		Facets.Add(facet);
		return this;
	}

	/// <summary>
	/// Adds a field (without facets) to the <see cref="P:SolrNet.Commands.Parameters.StatsParameters.FieldsWithFacets" /> collection
	/// </summary>
	/// <param name="field"></param>
	/// <returns></returns>
	public StatsParameters AddField(string field)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		FieldsWithFacets[field] = new List<string>();
		return this;
	}

	/// <summary>
	/// Adds a field with a related facet to the <see cref="P:SolrNet.Commands.Parameters.StatsParameters.FieldsWithFacets" /> collection
	/// </summary>
	/// <param name="field"></param>
	/// <param name="facet"></param>
	/// <returns></returns>
	public StatsParameters AddFieldWithFacet(string field, string facet)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		FieldsWithFacets[field] = new List<string> { facet };
		return this;
	}

	/// <summary>
	/// Adds a field with related facets to the <see cref="P:SolrNet.Commands.Parameters.StatsParameters.FieldsWithFacets" /> collection
	/// </summary>
	/// <param name="field"></param>
	/// <param name="facets"></param>
	/// <returns></returns>
	public StatsParameters AddFieldWithFacets(string field, IEnumerable<string> facets)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		if (facets == null)
		{
			throw new ArgumentNullException("facets");
		}
		FieldsWithFacets[field] = new List<string>(facets);
		return this;
	}

	/// <summary>
	/// Adds a field with related facets to the <see cref="P:SolrNet.Commands.Parameters.StatsParameters.FieldsWithFacets" /> collection
	/// </summary>
	/// <param name="field"></param>
	/// <param name="facets"></param>
	/// <returns></returns>
	public StatsParameters AddFieldWithFacets(string field, params string[] facets)
	{
		return AddFieldWithFacets(field, (IEnumerable<string>)facets);
	}

	/// <summary>
	/// Parameters to query stats
	/// </summary>
	public StatsParameters()
	{
		FieldsWithFacets = new Dictionary<string, ICollection<string>>();
		Facets = new List<string>();
	}
}

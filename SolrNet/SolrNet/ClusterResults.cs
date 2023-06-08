using System;
using System.Collections.Generic;

namespace SolrNet;

/// <summary>
/// Cluster results
/// </summary>
[Serializable]
public class ClusterResults
{
	/// <summary>
	/// List of the clusters returned
	/// </summary>
	public ICollection<Cluster> Clusters { get; set; }

	/// <summary>
	/// Cluster results
	/// </summary>
	public ClusterResults()
	{
		Clusters = new List<Cluster>();
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

public class ClusterResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(delegate(SolrQueryResults<T> r)
		{
			Parse(xml, r);
		}, F.DoNothing);
	}

	/// <summary>
	/// Parse the xml document returned by solr 
	/// </summary>
	/// <param name="xml"></param>
	/// <param name="results"></param>
	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		XElement clusterNode = xml.Element("response").Elements("arr").FirstOrDefault(X.AttrEq("name", "clusters"));
		if (clusterNode != null)
		{
			results.Clusters = ParseClusterNode(clusterNode);
		}
	}

	/// <summary>
	/// Grab a list of the documents from a cluster 
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	private static ICollection<string> GetDocumentList(XElement node)
	{
		return (from d in node.Elements()
			select d.Value).ToList();
	}

	/// <summary>
	/// Assign Title, Score, and documents to a cluster. Adds each cluster
	/// to and returns a ClusterResults 
	/// </summary>
	/// <param name="n"> Node to parse into a Cluster </param>
	/// <returns></returns>
	public ClusterResults ParseClusterNode(XElement n)
	{
		ClusterResults c = new ClusterResults();
		foreach (XElement v in n.Elements())
		{
			Cluster cluster = new Cluster();
			foreach (XElement x in v.Elements())
			{
				switch (x.Attribute("name").Value)
				{
				case "labels":
					cluster.Label = Convert.ToString(x.Value, CultureInfo.InvariantCulture);
					break;
				case "score":
					cluster.Score = Convert.ToDouble(x.Value, CultureInfo.InvariantCulture);
					break;
				case "docs":
					cluster.Documents = GetDocumentList(x);
					break;
				}
			}
			c.Clusters.Add(cluster);
		}
		return c;
	}
}

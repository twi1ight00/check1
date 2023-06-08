namespace SolrNet.Commands.Parameters;

/// <summary>
/// Clustering algorithms.
/// See details in:
/// <list>
/// <bullet>http://project.carrot2.org/algorithms.html</bullet>
/// <bullet>http://download.carrot2.org/stable/manual/#section.advanced-topics.fine-tuning.choosing-algorithm</bullet>
/// </list>
/// </summary>
public class Algorithms
{
	/// <summary>
	/// Diversity: High , many small (outlier) clusters highlighted.
	/// Labels: Longer, often more descriptive.
	/// Scalability: Low. For more than about 1000 documents, Lingo clustering will take a long time and large memory
	/// </summary>
	public const string Lingo = "org.carrot2.clustering.lingo.LingoClusteringAlgorithm";

	/// <summary>
	/// Diversity: Low, small (outlier) clusters rarely highlighted.
	/// Labels: Shorter, but still appropriate.
	/// Scalability: High
	/// </summary>
	public const string STC = "org.carrot2.clustering.stc.STCClusteringAlgorithm";

	/// <summary>
	/// Diversity: Low, small (outlier) clusters rarely highlighted.
	/// Labels: One-word only, may not always describe all documents in the cluster.
	/// Scalability: Low, based on similar data structures as Lingo.
	/// </summary>
	public const string KMeans = "org.carrot2.clustering.kmeans.BisectingKMeansClusteringAlgorithm";
}

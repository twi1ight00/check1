namespace SolrNet;

/// <summary>
///  Defines the level of accuracy applied for distance calculations.
///  Requires Solr 3.4+
/// </summary>
public enum CalculationAccuracy
{
	/// <summary>
	///  Highest accuracy but can have a performance hit.
	/// </summary>
	Radius,
	/// <summary>
	///  Less accurany (as it draws a bounding box around the points) but faster.
	/// </summary>
	BoundingBox
}

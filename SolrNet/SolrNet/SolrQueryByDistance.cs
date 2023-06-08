using System;
using System.Globalization;
using SolrNet.Impl;

namespace SolrNet;

/// <summary>
///  Retrieves entries from the index based on distance from a point.
///  Requires Solr 3.4+
/// </summary>
public class SolrQueryByDistance : ISelfSerializingQuery, ISolrQuery
{
	/// <summary>
	/// Coords Solr field name
	/// </summary>
	public string FieldName { get; private set; }

	public Location Location { get; private set; }

	[Obsolete("Use the Location property instead")]
	public double PointLatitude => Location.Latitude;

	[Obsolete("Use the Location property instead")]
	public double PointLongitude => Location.Longitude;

	public double DistanceFromPoint { get; private set; }

	/// <summary>
	/// Calculation accuracy
	/// </summary>
	public CalculationAccuracy Accuracy { get; private set; }

	public string Query
	{
		get
		{
			string prefix = ((Accuracy == CalculationAccuracy.Radius) ? "{!geofilt" : "{!bbox");
			return prefix + " pt=" + Location.ToString() + " sfield=" + FieldName + " d=" + DistanceFromPoint.ToString(CultureInfo.InvariantCulture) + "}";
		}
	}

	/// <summary>
	/// New query by distance using <see cref="F:SolrNet.CalculationAccuracy.Radius" />
	/// </summary>
	/// <param name="fieldName"></param>
	/// <param name="pointLatitude"></param>
	/// <param name="pointLongitude"></param>
	/// <param name="distance"></param>
	[Obsolete("Use the constructor with the Location parameter")]
	public SolrQueryByDistance(string fieldName, double pointLatitude, double pointLongitude, double distance)
		: this(fieldName, pointLatitude, pointLongitude, distance, CalculationAccuracy.Radius)
	{
	}

	/// <summary>
	/// Query by distance using <see cref="F:SolrNet.CalculationAccuracy.Radius" />
	/// </summary>
	/// <param name="fieldName"></param>
	/// <param name="location"></param>
	/// <param name="distance"></param>
	public SolrQueryByDistance(string fieldName, Location location, double distance)
		: this(fieldName, location, distance, CalculationAccuracy.Radius)
	{
	}

	public SolrQueryByDistance(string fieldName, Location location, double distance, CalculationAccuracy accuracy)
	{
		if (string.IsNullOrEmpty(fieldName))
		{
			throw new ArgumentNullException("fieldName");
		}
		if (location == null)
		{
			throw new ArgumentNullException("location");
		}
		if (distance <= 0.0)
		{
			throw new ArgumentOutOfRangeException("distance", "Distance must be greater than zero.");
		}
		FieldName = fieldName;
		Location = location;
		DistanceFromPoint = distance;
		Accuracy = accuracy;
	}

	/// <summary>
	/// New query by distance
	/// </summary>
	/// <param name="fieldName"></param>
	/// <param name="pointLatitude"></param>
	/// <param name="pointLongitude"></param>
	/// <param name="distance"></param>
	/// <param name="accuracy"></param>
	[Obsolete("Use the constructor with the Location parameter")]
	public SolrQueryByDistance(string fieldName, double pointLatitude, double pointLongitude, double distance, CalculationAccuracy accuracy)
		: this(fieldName, new Location(pointLatitude, pointLongitude), distance, accuracy)
	{
	}
}

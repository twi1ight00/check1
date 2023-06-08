using System;

namespace SolrNet;

/// <summary>
/// Random sorting of results
/// Requires Solr 1.3+
/// </summary>
public class RandomSortOrder : SortOrder
{
	private const string separator = "_";

	private static readonly Random rnd = new Random();

	/// <summary>
	/// Random sorting with random seed
	/// </summary>
	/// <param name="fieldName">Random sorting field as defined in schema.xml</param>
	public RandomSortOrder(string fieldName)
		: base(fieldName + "_" + rnd.Next())
	{
	}

	/// <summary>
	/// Random sorting with random seed, with specified order
	/// </summary>
	/// <param name="fieldName">Random sorting field as defined in schema.xml</param>
	/// <param name="order">Sort order (asc/desc)</param>
	public RandomSortOrder(string fieldName, Order order)
		: base(fieldName + "_" + rnd.Next(), order)
	{
	}

	/// <summary>
	/// Random sorting with specified seed
	/// </summary>
	/// <param name="fieldName">Random sorting field as defined in schema.xml</param>
	/// <param name="seed">Random seed</param>
	public RandomSortOrder(string fieldName, string seed)
		: base(fieldName + "_" + seed)
	{
	}

	/// <summary>
	/// Random sorting with specified seed, with specified order
	/// </summary>
	/// <param name="fieldName">Random sorting field as defined in schema.xml</param>
	/// <param name="seed">Random seed</param>
	/// <param name="order">Sort order (asc/desc)</param>
	public RandomSortOrder(string fieldName, string seed, Order order)
		: base(fieldName + "_" + seed, order)
	{
	}
}

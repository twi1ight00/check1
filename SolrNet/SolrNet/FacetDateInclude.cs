namespace SolrNet;

/// <summary>
/// By default, the ranges used to compute date faceting between facet.date.start and facet.date.end are all inclusive of both endpoints, 
/// while the the "before" and "after" ranges are not inclusive. This behavior can be modified by the facet.date.include param, which can be any combination of the following options...
/// </summary>
public class FacetDateInclude
{
	protected readonly string value;

	/// <summary>
	/// all gap based ranges include their lower bound
	/// </summary>
	public static FacetDateInclude Lower => new FacetDateInclude("lower");

	/// <summary>
	/// all gap based ranges include their upper bound
	/// </summary>
	public static FacetDateInclude Upper => new FacetDateInclude("upper");

	/// <summary>
	///  the first and last gap ranges include their edge bounds (ie: lower for the first one, upper for the last one) 
	///  even if the corresponding upper/lower option is not specified
	/// </summary>
	public static FacetDateInclude Edge => new FacetDateInclude("edge");

	/// <summary>
	/// the "before" and "after" ranges will be inclusive of their bounds, 
	/// even if the first or last ranges already include those boundaries.
	/// </summary>
	public static FacetDateInclude Outer => new FacetDateInclude("outer");

	/// <summary>
	/// shorthand for lower, upper, edge, outer
	/// </summary>
	public static FacetDateInclude All => new FacetDateInclude("all");

	protected FacetDateInclude(string value)
	{
		this.value = value;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FacetDateInclude o))
		{
			return false;
		}
		return o.value == value;
	}

	public override int GetHashCode()
	{
		return value.GetHashCode();
	}

	public override string ToString()
	{
		return value;
	}
}

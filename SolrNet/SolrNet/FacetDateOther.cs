namespace SolrNet;

/// <summary>
/// Indicates that in addition to the counts for each date range constraint between facet.date.start and facet.date.end, 
/// counts should also be computed for other
/// </summary>
public class FacetDateOther
{
	protected readonly string value;

	/// <summary>
	/// All records with field values lower then lower bound of the first range
	/// </summary>
	public static FacetDateOther Before => new FacetDateOther("before");

	/// <summary>
	/// All records with field values greater then the upper bound of the last range
	/// </summary>
	public static FacetDateOther After => new FacetDateOther("after");

	/// <summary>
	/// All records with field values between the start and end bounds of all ranges
	/// </summary>
	public static FacetDateOther Between => new FacetDateOther("between");

	/// <summary>
	/// Compute none of this information. Overrides all other options.
	/// </summary>
	public static FacetDateOther None => new FacetDateOther("none");

	/// <summary>
	/// Shortcut for before, between, and after
	/// </summary>
	public static FacetDateOther All => new FacetDateOther("all");

	protected FacetDateOther(string value)
	{
		this.value = value;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FacetDateOther o))
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

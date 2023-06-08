namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Information about a property match.
/// </summary>
public class PropertyMatchingInfo : MatchingInfo
{
	private PropertyMatchingOption option;

	/// <summary>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingOption" /> to use when doing name comparisons on this property.
	/// </summary>
	/// <value>Specifies which methods of the property to match.</value>
	public PropertyMatchingOption Option
	{
		get
		{
			return option;
		}
		set
		{
			option = value;
		}
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingInfo" /> that matches the get or set methods
	/// of the given property name, and does a case-sensitive comparison.
	/// </summary>
	/// <param name="match">Property name to match.</param>
	public PropertyMatchingInfo(string match)
		: this(match, PropertyMatchingOption.GetOrSet, ignoreCase: false)
	{
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingInfo" /> that matches the given methods of
	/// the given property name, doing a case-sensitive comparison.
	/// </summary>
	/// <param name="match">Property name to match.</param>
	/// <param name="option"><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingOption" /> specifying which methods of the property to match.</param>
	public PropertyMatchingInfo(string match, PropertyMatchingOption option)
		: this(match, option, ignoreCase: false)
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingInfo" /> that matches the given methods of
	/// the given property name.
	/// </summary>
	/// <param name="match">Property name to match.</param>
	/// <param name="option"><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingOption" /> specifying which methods of the property to match.</param>
	/// <param name="ignoreCase">If false, name comparison is case sensitive. If true, name comparison is case insensitive.</param>
	public PropertyMatchingInfo(string match, PropertyMatchingOption option, bool ignoreCase)
		: base(match, ignoreCase)
	{
		this.option = option;
	}
}

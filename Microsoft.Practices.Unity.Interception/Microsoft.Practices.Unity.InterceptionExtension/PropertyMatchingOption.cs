namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Specifies which methods of a property should be matches by
/// the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PropertyMatchingRule" />.
/// </summary>
public enum PropertyMatchingOption
{
	/// <summary>
	/// Match the property getter method.
	/// </summary>
	Get,
	/// <summary>
	/// Match the property setter method.
	/// </summary>
	Set,
	/// <summary>
	/// Match either the getter or setter method.
	/// </summary>
	GetOrSet
}

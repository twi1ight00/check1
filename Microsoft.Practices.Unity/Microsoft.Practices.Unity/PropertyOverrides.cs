namespace Microsoft.Practices.Unity;

/// <summary>
/// A convenience form of <see cref="T:Microsoft.Practices.Unity.PropertyOverride" /> that lets you
/// specify multiple property overrides in one shot rather than having
/// to construct multiple objects.
/// </summary>
public class PropertyOverrides : OverrideCollection<PropertyOverride, string, object>
{
	/// <summary>
	/// When implemented in derived classes, this method is called from the <see cref="M:Microsoft.Practices.Unity.OverrideCollection`3.Add(`1,`2)" />
	/// method to create the actual <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> objects.
	/// </summary>
	/// <param name="key">Key value to create the resolver.</param>
	/// <param name="value">Value to store in the resolver.</param>
	/// <returns>The created <see cref="T:Microsoft.Practices.Unity.ResolverOverride" />.</returns>
	protected override PropertyOverride MakeOverride(string key, object value)
	{
		return new PropertyOverride(key, value);
	}
}

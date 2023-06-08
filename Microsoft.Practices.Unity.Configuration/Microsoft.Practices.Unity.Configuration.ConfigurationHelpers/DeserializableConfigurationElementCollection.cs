using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// Specialization of <see cref="T:Microsoft.Practices.Unity.Configuration.ConfigurationHelpers.DeserializableConfigurationElementCollectionBase`1" />
/// that provides a canned implmentation of <see cref="M:System.Configuration.ConfigurationElementCollection.CreateNewElement" />.
/// </summary>
/// <typeparam name="TElement">Type of configuration element in the collection.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Deserializable", Justification = "It is spelled correctly.")]
public abstract class DeserializableConfigurationElementCollection<TElement> : DeserializableConfigurationElementCollectionBase<TElement> where TElement : DeserializableConfigurationElement, new()
{
	/// <summary>
	/// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement" />.
	/// </summary>
	/// <returns>
	/// A new <see cref="T:System.Configuration.ConfigurationElement" />.
	/// </returns>
	protected override ConfigurationElement CreateNewElement()
	{
		return new TElement();
	}
}

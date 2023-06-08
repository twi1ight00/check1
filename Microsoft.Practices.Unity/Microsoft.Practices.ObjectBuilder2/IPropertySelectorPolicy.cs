using System.Collections.Generic;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that returns a sequence
/// of properties that should be injected for the given type.
/// </summary>
public interface IPropertySelectorPolicy : IBuilderPolicy
{
	/// <summary>
	/// Returns sequence of properties on the given type that
	/// should be set as part of building that object.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>Sequence of <see cref="T:System.Reflection.PropertyInfo" /> objects
	/// that contain the properties to set.</returns>
	IEnumerable<SelectedProperty> SelectProperties(IBuilderContext context, IPolicyList resolverPolicyDestination);
}

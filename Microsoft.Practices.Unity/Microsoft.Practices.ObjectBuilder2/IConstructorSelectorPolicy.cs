namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that, when implemented,
/// will determine which constructor to call from the build plan.
/// </summary>
public interface IConstructorSelectorPolicy : IBuilderPolicy
{
	/// <summary>
	/// Choose the constructor to call for the given type.
	/// </summary>
	/// <param name="context">Current build context</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>The chosen constructor.</returns>
	SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination);
}

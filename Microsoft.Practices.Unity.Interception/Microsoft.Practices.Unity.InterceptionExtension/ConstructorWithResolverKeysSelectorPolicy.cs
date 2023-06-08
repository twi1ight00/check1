using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
///  A small implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IConstructorSelectorPolicy" /> that returns the
///  given <see cref="T:Microsoft.Practices.ObjectBuilder2.SelectedConstructor" /> object.
/// </summary>
public class ConstructorWithResolverKeysSelectorPolicy : IConstructorSelectorPolicy, IBuilderPolicy
{
	private readonly SelectedConstructor selectedConstructor;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ConstructorWithResolverKeysSelectorPolicy" /> instance.
	/// </summary>
	/// <param name="selectedConstructor">Information about which constructor to select.</param>
	public ConstructorWithResolverKeysSelectorPolicy(SelectedConstructor selectedConstructor)
	{
		this.selectedConstructor = selectedConstructor;
	}

	/// <summary>
	/// Choose the constructor to call for the given type.
	/// </summary>
	/// <param name="context">Current build context</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>The chosen constructor.</returns>
	public SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination)
	{
		return selectedConstructor;
	}
}

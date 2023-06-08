using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.ObjectBuilder;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> implementation that returns
/// the value set in the constructor.
/// </summary>
public class LiteralValueDependencyResolverPolicy : IDependencyResolverPolicy, IBuilderPolicy
{
	private object dependencyValue;

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.ObjectBuilder.LiteralValueDependencyResolverPolicy" />
	/// which will return the given value when resolved.
	/// </summary>
	/// <param name="dependencyValue">The value to return.</param>
	public LiteralValueDependencyResolverPolicy(object dependencyValue)
	{
		this.dependencyValue = dependencyValue;
	}

	/// <summary>
	/// Get the value for a dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <returns>The value for the dependency.</returns>
	public object Resolve(IBuilderContext context)
	{
		return dependencyValue;
	}
}

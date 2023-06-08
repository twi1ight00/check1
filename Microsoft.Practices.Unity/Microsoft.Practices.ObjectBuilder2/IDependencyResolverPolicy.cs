namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that is used at build plan execution time
/// to resolve a dependent value.
/// </summary>
public interface IDependencyResolverPolicy : IBuilderPolicy
{
	/// <summary>
	/// Get the value for a dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <returns>The value for the dependency.</returns>
	object Resolve(IBuilderContext context);
}

using Microsoft.Practices.Unity;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Extension methods to provide convenience overloads over the
/// <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderContext" /> interface.
/// </summary>
public static class BuilderContextExtensions
{
	/// <summary>
	/// Start a recursive build up operation to retrieve the default
	/// value for the given <typeparamref name="TResult" /> type.
	/// </summary>
	/// <typeparam name="TResult">Type of object to build.</typeparam>
	/// <param name="context">Parent context.</param>
	/// <returns>Resulting object.</returns>
	public static TResult NewBuildUp<TResult>(this IBuilderContext context)
	{
		return context.NewBuildUp<TResult>(null);
	}

	/// <summary>
	/// Start a recursive build up operation to retrieve the named
	/// implementation for the given <typeparamref name="TResult" /> type.
	/// </summary>
	/// <typeparam name="TResult">Type to resolve.</typeparam>
	/// <param name="context">Parent context.</param>
	/// <param name="name">Name to resolve with.</param>
	/// <returns>The resulting object.</returns>
	public static TResult NewBuildUp<TResult>(this IBuilderContext context, string name)
	{
		return (TResult)context.NewBuildUp(NamedTypeBuildKey.Make<TResult>(name));
	}

	/// <summary>
	/// Add a set of <see cref="T:Microsoft.Practices.Unity.ResolverOverride" />s to the context, specified as a 
	/// variable argument list.
	/// </summary>
	/// <param name="context">Context to add overrides to.</param>
	/// <param name="overrides">The overrides.</param>
	public static void AddResolverOverrides(this IBuilderContext context, params ResolverOverride[] overrides)
	{
		context.AddResolverOverrides(overrides);
	}
}

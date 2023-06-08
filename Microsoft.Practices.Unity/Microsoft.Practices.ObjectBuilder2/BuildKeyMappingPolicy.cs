namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Represents a builder policy for mapping build keys.
/// </summary>
public class BuildKeyMappingPolicy : IBuildKeyMappingPolicy, IBuilderPolicy
{
	private readonly NamedTypeBuildKey newBuildKey;

	/// <summary>
	/// Initialize a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.BuildKeyMappingPolicy" /> with the new build key.
	/// </summary>
	/// <param name="newBuildKey">The new build key.</param>
	public BuildKeyMappingPolicy(NamedTypeBuildKey newBuildKey)
	{
		this.newBuildKey = newBuildKey;
	}

	/// <summary>
	/// Maps the build key.
	/// </summary>
	/// <param name="buildKey">The build key to map.</param>
	/// <param name="context">Current build context. Used for contextual information
	/// if writing a more sophisticated mapping, unused in this implementation.</param>
	/// <returns>The new build key.</returns>
	public NamedTypeBuildKey Map(NamedTypeBuildKey buildKey, IBuilderContext context)
	{
		return newBuildKey;
	}
}

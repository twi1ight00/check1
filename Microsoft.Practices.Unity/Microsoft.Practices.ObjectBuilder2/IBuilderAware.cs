namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Implemented on a class when it wants to receive notifications
/// about the build process.
/// </summary>
public interface IBuilderAware
{
	/// <summary>
	/// Called by the <see cref="T:Microsoft.Practices.ObjectBuilder2.BuilderAwareStrategy" /> when the object is being built up.
	/// </summary>
	/// <param name="buildKey">The key of the object that was just built up.</param>
	void OnBuiltUp(NamedTypeBuildKey buildKey);

	/// <summary>
	/// Called by the <see cref="T:Microsoft.Practices.ObjectBuilder2.BuilderAwareStrategy" /> when the object is being torn down.
	/// </summary>
	void OnTearingDown();
}

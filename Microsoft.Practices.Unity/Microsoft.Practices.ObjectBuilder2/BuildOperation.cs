using System;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Base class for the current operation stored in the build context.
/// </summary>
public abstract class BuildOperation
{
	/// <summary>
	///  The type that's currently being built.
	/// </summary>
	public Type TypeBeingConstructed { get; private set; }

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.ObjectBuilder2.BuildOperation" />.
	/// </summary>
	/// <param name="typeBeingConstructed">Type currently being built.</param>
	protected BuildOperation(Type typeBeingConstructed)
	{
		TypeBeingConstructed = typeBeingConstructed;
	}
}

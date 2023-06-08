using System;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Event argument class for the <see cref="E:Microsoft.Practices.Unity.ExtensionContext.ChildContainerCreated" /> event.
/// </summary>
public class ChildContainerCreatedEventArgs : EventArgs
{
	/// <summary>
	/// The newly created child container.
	/// </summary>
	public IUnityContainer ChildContainer => ChildContext.Container;

	/// <summary>
	/// An extension context for the created child container.
	/// </summary>
	public ExtensionContext ChildContext { get; private set; }

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.ChildContainerCreatedEventArgs" /> object with the
	/// given child container object.
	/// </summary>
	/// <param name="childContext">An <see cref="T:Microsoft.Practices.Unity.ExtensionContext" /> for the newly created child
	/// container.</param>
	public ChildContainerCreatedEventArgs(ExtensionContext childContext)
	{
		ChildContext = childContext;
	}
}

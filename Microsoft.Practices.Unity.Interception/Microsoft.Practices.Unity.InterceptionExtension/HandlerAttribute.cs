using System;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Base class for handler attributes used in the attribute-driven
/// interception policy.
/// </summary>
public abstract class HandlerAttribute : Attribute
{
	private int order;

	/// <summary>
	/// Gets or sets the order in which the handler will be executed.
	/// </summary>
	public int Order
	{
		get
		{
			return order;
		}
		set
		{
			order = value;
		}
	}

	/// <summary>
	/// Derived classes implement this method. When called, it
	/// creates a new call handler as specified in the attribute
	/// configuration.
	/// </summary>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to use when creating handlers,
	/// if necessary.</param>
	/// <returns>A new call handler object.</returns>
	public abstract ICallHandler CreateHandler(IUnityContainer container);
}

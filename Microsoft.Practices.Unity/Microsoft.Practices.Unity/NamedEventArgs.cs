using System;

namespace Microsoft.Practices.Unity;

/// <summary>
/// An EventArgs class that holds a string Name.
/// </summary>
public abstract class NamedEventArgs : EventArgs
{
	private string name;

	/// <summary>
	/// The name.
	/// </summary>
	/// <value>Name used for this event arg object.</value>
	public virtual string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.NamedEventArgs" /> with a null name.
	/// </summary>
	protected NamedEventArgs()
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.NamedEventArgs" /> with the given name.
	/// </summary>
	/// <param name="name">Name to store.</param>
	protected NamedEventArgs(string name)
	{
		this.name = name;
	}
}

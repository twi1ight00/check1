using System;
using System.Globalization;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A base class that holds the information shared by all operations
/// performed by the container while setting properties.
/// </summary>
public abstract class PropertyOperation : BuildOperation
{
	private readonly string propertyName;

	/// <summary>
	/// The property value currently being resolved.
	/// </summary>
	public string PropertyName => propertyName;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:System.Object" /> class.
	/// </summary>
	protected PropertyOperation(Type typeBeingConstructed, string propertyName)
		: base(typeBeingConstructed)
	{
		this.propertyName = propertyName;
	}

	/// <summary>
	/// Generate the description of this operation.
	/// </summary>
	/// <returns>The string.</returns>
	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, GetDescriptionFormat(), base.TypeBeingConstructed.Name, propertyName);
	}

	/// <summary>
	/// Get a format string used to create the description. Called by
	/// the base <see cref="M:Microsoft.Practices.ObjectBuilder2.PropertyOperation.ToString" /> method.
	/// </summary>
	/// <returns>The format string.</returns>
	protected abstract string GetDescriptionFormat();
}

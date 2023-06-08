using System.ComponentModel;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Configures a relationship that can support cascade on delete functionality.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cascadable")]
public abstract class CascadableNavigationPropertyConfiguration
{
	private readonly NavigationPropertyConfiguration _navigationPropertyConfiguration;

	internal NavigationPropertyConfiguration NavigationPropertyConfiguration => _navigationPropertyConfiguration;

	internal CascadableNavigationPropertyConfiguration(NavigationPropertyConfiguration navigationPropertyConfiguration)
	{
		_navigationPropertyConfiguration = navigationPropertyConfiguration;
	}

	/// <summary>
	///     Configures cascade delete to be on for the relationship.
	/// </summary>
	public void WillCascadeOnDelete()
	{
		WillCascadeOnDelete(value: true);
	}

	/// <summary>
	///     Configures whether or not cascade delete is on for the relationship.
	/// </summary>
	/// <param name="value">Value indicating if cascade delete is on or not.</param>
	public void WillCascadeOnDelete(bool value)
	{
		_navigationPropertyConfiguration.DeleteAction = (value ? EdmOperationAction.Cascade : EdmOperationAction.None);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}

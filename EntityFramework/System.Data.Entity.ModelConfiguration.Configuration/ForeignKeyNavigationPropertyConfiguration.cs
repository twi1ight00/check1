using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Configures a relationship that can only support foreign key properties that are not exposed in the object model.
///     This configuration functionality is available via the Code First Fluent API, see <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
public class ForeignKeyNavigationPropertyConfiguration : CascadableNavigationPropertyConfiguration
{
	internal ForeignKeyNavigationPropertyConfiguration(NavigationPropertyConfiguration navigationPropertyConfiguration)
		: base(navigationPropertyConfiguration)
	{
	}

	/// <summary>
	///     Configures the relationship to use foreign key property(s) that are not exposed in the object model.
	///     The column(s) and table can be customized by specifying a configuration action.
	///     If an empty configuration action is specified then column name(s) will be generated by convention.
	///     If foreign key properties are exposed in the object model then use the HasForeignKey method.
	///     Not all relationships support exposing foreign key properties in the object model.
	/// </summary>
	/// <param name="configurationAction">Action that configures the foreign key column(s) and table.</param>
	/// <returns>
	///     A configuration object that can be used to further configure the relationship.
	/// </returns>
	public CascadableNavigationPropertyConfiguration Map(Action<ForeignKeyAssociationMappingConfiguration> configurationAction)
	{
		RuntimeFailureMethods.Requires(configurationAction != null, null, "configurationAction != null");
		base.NavigationPropertyConfiguration.Constraint = IndependentConstraintConfiguration.Instance;
		ForeignKeyAssociationMappingConfiguration foreignKeyAssociationMappingConfiguration = new ForeignKeyAssociationMappingConfiguration();
		configurationAction(foreignKeyAssociationMappingConfiguration);
		base.NavigationPropertyConfiguration.AssociationMappingConfiguration = foreignKeyAssociationMappingConfiguration;
		return this;
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
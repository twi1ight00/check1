using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Configures a many:many relationship.
///     This configuration functionality is available via the Code First Fluent API, see <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
public class ManyToManyNavigationPropertyConfiguration
{
	private readonly NavigationPropertyConfiguration _navigationPropertyConfiguration;

	internal ManyToManyNavigationPropertyConfiguration(NavigationPropertyConfiguration navigationPropertyConfiguration)
	{
		_navigationPropertyConfiguration = navigationPropertyConfiguration;
	}

	/// <summary>
	///     Configures the foreign key column(s) and table used to store the relationship.
	/// </summary>
	/// <param name="configurationAction">Action that configures the foreign key column(s) and table.</param>
	public void Map(Action<ManyToManyAssociationMappingConfiguration> configurationAction)
	{
		RuntimeFailureMethods.Requires(configurationAction != null, null, "configurationAction != null");
		ManyToManyAssociationMappingConfiguration manyToManyAssociationMappingConfiguration = new ManyToManyAssociationMappingConfiguration();
		configurationAction(manyToManyAssociationMappingConfiguration);
		_navigationPropertyConfiguration.AssociationMappingConfiguration = manyToManyAssociationMappingConfiguration;
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

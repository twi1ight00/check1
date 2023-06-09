using System.Data.Entity.Edm;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to discover foreign key properties whose names match the principal type primary key property name(s).
/// </summary>
public sealed class PrimaryKeyNameForeignKeyDiscoveryConvention : IEdmConvention<EdmAssociationType>, IConvention
{
	private sealed class PrimaryKeyNameForeignKeyDiscoveryConventionImpl : ForeignKeyDiscoveryConvention
	{
		protected override bool MatchDependentKeyProperty(EdmAssociationType associationType, EdmAssociationEnd dependentAssociationEnd, EdmProperty dependentProperty, EdmEntityType principalEntityType, EdmProperty principalKeyProperty)
		{
			return string.Equals(dependentProperty.Name, principalKeyProperty.Name, StringComparison.OrdinalIgnoreCase);
		}
	}

	private readonly IEdmConvention<EdmAssociationType> _impl = new PrimaryKeyNameForeignKeyDiscoveryConventionImpl();

	internal PrimaryKeyNameForeignKeyDiscoveryConvention()
	{
	}

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		_impl.Apply(associationType, model);
	}
}

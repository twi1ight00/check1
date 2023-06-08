using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to discover foreign key properties whose names are a combination
///     of the dependent navigation property name and the principal type primary key property name(s).
/// </summary>
public sealed class NavigationPropertyNameForeignKeyDiscoveryConvention : IEdmConvention<EdmAssociationType>, IConvention
{
	private sealed class NavigationPropertyNameForeignKeyDiscoveryConventionImpl : ForeignKeyDiscoveryConvention
	{
		protected override bool SupportsMultipleAssociations => true;

		protected override bool MatchDependentKeyProperty(EdmAssociationType associationType, EdmAssociationEnd dependentAssociationEnd, EdmProperty dependentProperty, EdmEntityType principalEntityType, EdmProperty principalKeyProperty)
		{
			EdmAssociationEnd otherEnd = associationType.GetOtherEnd(dependentAssociationEnd);
			EdmNavigationProperty edmNavigationProperty = dependentAssociationEnd.EntityType.NavigationProperties.SingleOrDefault((EdmNavigationProperty n) => n.ResultEnd == otherEnd);
			if (edmNavigationProperty == null)
			{
				return false;
			}
			return string.Equals(dependentProperty.Name, edmNavigationProperty.Name + principalKeyProperty.Name, StringComparison.OrdinalIgnoreCase);
		}
	}

	private readonly IEdmConvention<EdmAssociationType> _impl = new NavigationPropertyNameForeignKeyDiscoveryConventionImpl();

	internal NavigationPropertyNameForeignKeyDiscoveryConvention()
	{
	}

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		_impl.Apply(associationType, model);
	}
}

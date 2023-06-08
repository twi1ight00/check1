using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to distinguish between optional and required relationships based on CLR nullability of the foreign key property.
/// </summary>
public sealed class ForeignKeyAssociationMultiplicityConvention : IEdmConvention<EdmAssociationType>, IConvention
{
	internal ForeignKeyAssociationMultiplicityConvention()
	{
	}

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		EdmAssociationConstraint constraint = associationType.Constraint;
		if (constraint == null)
		{
			return;
		}
		NavigationPropertyConfiguration navigationPropertyConfiguration = associationType.Annotations.GetConfiguration() as NavigationPropertyConfiguration;
		if (constraint.DependentProperties.All((EdmProperty p) => p.PropertyType.IsNullable.HasValue && !p.PropertyType.IsNullable.Value))
		{
			EdmAssociationEnd principalEnd = associationType.GetOtherEnd(constraint.DependentEnd);
			EdmNavigationProperty edmNavigationProperty = (from np in model.Namespaces.SelectMany((EdmNamespace ns) => ns.EntityTypes).SelectMany((EdmEntityType et) => et.DeclaredNavigationProperties)
				where np.ResultEnd == principalEnd
				select np).SingleOrDefault();
			PropertyInfo clrPropertyInfo;
			if (navigationPropertyConfiguration == null || edmNavigationProperty == null || !((clrPropertyInfo = edmNavigationProperty.Annotations.GetClrPropertyInfo()) != null) || ((!(clrPropertyInfo == navigationPropertyConfiguration.NavigationProperty) || !navigationPropertyConfiguration.EndKind.HasValue) && (!(clrPropertyInfo == navigationPropertyConfiguration.InverseNavigationProperty) || !navigationPropertyConfiguration.InverseEndKind.HasValue)))
			{
				principalEnd.EndKind = EdmAssociationEndKind.Required;
			}
		}
	}
}

using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to detect navigation properties to be inverses of each other when only one pair 
///     of navigation properties exists between the related types.
/// </summary>
public sealed class AssociationInverseDiscoveryConvention : IEdmConvention, IConvention
{
	internal AssociationInverseDiscoveryConvention()
	{
	}

	void IEdmConvention.Apply(EdmModel model)
	{
		var enumerable = from g in (from a1 in model.GetAssociationTypes()
				from a2 in model.GetAssociationTypes()
				where a1 != a2
				where a1.SourceEnd.EntityType == a2.TargetEnd.EntityType && a1.TargetEnd.EntityType == a2.SourceEnd.EntityType
				let a1Configuration = a1.GetConfiguration() as NavigationPropertyConfiguration
				let a2Configuration = a2.GetConfiguration() as NavigationPropertyConfiguration
				where (a1Configuration == null || (!a1Configuration.InverseEndKind.HasValue && a1Configuration.InverseNavigationProperty == null)) && (a2Configuration == null || (!a2Configuration.InverseEndKind.HasValue && a2Configuration.InverseNavigationProperty == null))
				select new { a1, a2 }).Distinct((a, b) => a.a1 == b.a2 && a.a2 == b.a1).GroupBy((a, b) => a.a1.SourceEnd.EntityType == b.a2.TargetEnd.EntityType && a.a1.TargetEnd.EntityType == b.a2.SourceEnd.EntityType)
			where g.Count() == 1
			select g.Single();
		foreach (var item in enumerable)
		{
			EdmAssociationType edmAssociationType = ((item.a2.GetConfiguration() != null) ? item.a2 : item.a1);
			EdmAssociationType edmAssociationType2 = ((edmAssociationType == item.a1) ? item.a2 : item.a1);
			edmAssociationType.SourceEnd.EndKind = edmAssociationType2.TargetEnd.EndKind;
			if (edmAssociationType2.Constraint != null)
			{
				edmAssociationType.Constraint = edmAssociationType2.Constraint;
				edmAssociationType.Constraint.DependentEnd = ((edmAssociationType.Constraint.DependentEnd.EntityType == edmAssociationType.SourceEnd.EntityType) ? edmAssociationType.SourceEnd : edmAssociationType.TargetEnd);
			}
			FixNavigationProperties(model, edmAssociationType, edmAssociationType2);
			model.RemoveAssociationType(edmAssociationType2);
		}
	}

	private static void FixNavigationProperties(EdmModel model, EdmAssociationType unifiedAssociation, EdmAssociationType redundantAssociation)
	{
		foreach (EdmNavigationProperty item in from np in model.GetEntityTypes().SelectMany((EdmEntityType e) => e.NavigationProperties)
			where np.Association == redundantAssociation
			select np)
		{
			item.Association = unifiedAssociation;
			item.ResultEnd = unifiedAssociation.SourceEnd;
		}
	}
}

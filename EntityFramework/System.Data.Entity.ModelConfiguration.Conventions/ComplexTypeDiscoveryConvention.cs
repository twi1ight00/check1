using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to configure a type as a complex type if it has no primary key, no mapped base type and no navigation properties.
/// </summary>
public sealed class ComplexTypeDiscoveryConvention : IEdmConvention, IConvention
{
	internal ComplexTypeDiscoveryConvention()
	{
	}

	void IEdmConvention.Apply(EdmModel model)
	{
		var source = from entityType in model.GetEntityTypes()
			where entityType.DeclaredKeyProperties.Count == 0 && entityType.BaseType == null
			let entityTypeConfiguration = entityType.GetConfiguration() as EntityTypeConfiguration
			where (entityTypeConfiguration == null || (!entityTypeConfiguration.IsExplicitEntity && entityTypeConfiguration.IsStructuralConfigurationOnly)) && entityType.NavigationProperties.Count() == 0
			let matchingAssociations = from associationType in model.GetAssociationTypes()
				where associationType.SourceEnd.EntityType == entityType || associationType.TargetEnd.EntityType == entityType
				let declaringEnd = (associationType.SourceEnd.EntityType == entityType) ? associationType.SourceEnd : associationType.TargetEnd
				let declaringEntity = associationType.GetOtherEnd(declaringEnd).EntityType
				let navigationProperties = declaringEntity.NavigationProperties.Where((EdmNavigationProperty n) => n.ResultEnd.EntityType == entityType)
				select new
				{
					DeclaringEnd = declaringEnd,
					AssociationType = associationType,
					DeclaringEntityType = declaringEntity,
					NavigationProperties = navigationProperties.ToList()
				}
			where matchingAssociations.All(a => a.AssociationType.Constraint == null && a.AssociationType.GetConfiguration() == null && !a.AssociationType.IsSelfReferencing() && a.DeclaringEnd.IsOptional() && a.NavigationProperties.All((EdmNavigationProperty n) => n.GetConfiguration() == null))
			select new
			{
				EntityType = entityType,
				MatchingAssociations = matchingAssociations.ToList()
			};
		foreach (var item in source.ToList())
		{
			EdmComplexType edmComplexType = model.AddComplexType(item.EntityType.Name);
			foreach (EdmProperty declaredProperty in item.EntityType.DeclaredProperties)
			{
				edmComplexType.DeclaredProperties.Add(declaredProperty);
			}
			foreach (DataModelAnnotation annotation in item.EntityType.Annotations)
			{
				edmComplexType.Annotations.Add(annotation);
			}
			foreach (var matchingAssociation in item.MatchingAssociations)
			{
				foreach (EdmNavigationProperty navigationProperty in matchingAssociation.NavigationProperties)
				{
					if (!matchingAssociation.DeclaringEntityType.NavigationProperties.Contains(navigationProperty))
					{
						continue;
					}
					matchingAssociation.DeclaringEntityType.DeclaredNavigationProperties.Remove(navigationProperty);
					EdmProperty edmProperty = matchingAssociation.DeclaringEntityType.AddComplexProperty(navigationProperty.Name, edmComplexType);
					foreach (DataModelAnnotation annotation2 in navigationProperty.Annotations)
					{
						edmProperty.Annotations.Add(annotation2);
					}
				}
				model.RemoveAssociationType(matchingAssociation.AssociationType);
			}
			model.RemoveEntityType(item.EntityType);
		}
	}
}

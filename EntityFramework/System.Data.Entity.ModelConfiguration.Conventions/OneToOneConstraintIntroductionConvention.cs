using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to configure the primary key(s) of the dependent entity type as foreign key(s) in a one:one relationship.
/// </summary>
public sealed class OneToOneConstraintIntroductionConvention : IEdmConvention<EdmAssociationType>, IConvention
{
	internal OneToOneConstraintIntroductionConvention()
	{
	}

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		if (associationType.IsOneToOne() && !associationType.IsSelfReferencing() && !associationType.IsIndependent() && associationType.Constraint == null)
		{
			IEnumerable<EdmProperty> source = associationType.SourceEnd.EntityType.KeyProperties();
			IEnumerable<EdmProperty> source2 = associationType.TargetEnd.EntityType.KeyProperties();
			if (source.Count() == source2.Count() && source.Select((EdmProperty p) => p.PropertyType.PrimitiveType).SequenceEqual(source2.Select((EdmProperty p) => p.PropertyType.PrimitiveType)) && (associationType.TryGuessPrincipalAndDependentEnds(out var _, out var dependentEnd) || associationType.IsPrincipalConfigured()))
			{
				dependentEnd = dependentEnd ?? associationType.TargetEnd;
				EdmAssociationConstraint edmAssociationConstraint = new EdmAssociationConstraint();
				edmAssociationConstraint.DependentEnd = dependentEnd;
				edmAssociationConstraint.DependentProperties = dependentEnd.EntityType.KeyProperties().ToList();
				EdmAssociationConstraint constraint = edmAssociationConstraint;
				associationType.Constraint = constraint;
			}
		}
	}
}

using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

internal abstract class ForeignKeyDiscoveryConvention : IEdmConvention<EdmAssociationType>, IConvention
{
	protected virtual bool SupportsMultipleAssociations => false;

	protected abstract bool MatchDependentKeyProperty(EdmAssociationType associationType, EdmAssociationEnd dependentAssociationEnd, EdmProperty dependentProperty, EdmEntityType principalEntityType, EdmProperty principalKeyProperty);

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		if (associationType.Constraint != null || associationType.IsIndependent() || (associationType.IsOneToOne() && associationType.IsSelfReferencing()) || !associationType.TryGuessPrincipalAndDependentEnds(out var principalEnd, out var dependentEnd))
		{
			return;
		}
		IEnumerable<EdmProperty> source = principalEnd.EntityType.KeyProperties();
		if (source.Count() == 0 || (!SupportsMultipleAssociations && model.GetAssociationTypesBetween(principalEnd.EntityType, dependentEnd.EntityType).Count() > 1))
		{
			return;
		}
		IEnumerable<EdmProperty> foreignKeyProperties = from p in source
			from d in dependentEnd.EntityType.DeclaredProperties
			where MatchDependentKeyProperty(associationType, dependentEnd, d, principalEnd.EntityType, p) && p.PropertyType.PrimitiveType == d.PropertyType.PrimitiveType
			select d;
		if (!foreignKeyProperties.Any() || foreignKeyProperties.Count() != source.Count())
		{
			return;
		}
		IEnumerable<EdmProperty> source2 = dependentEnd.EntityType.KeyProperties();
		bool flag = source2.Count() == foreignKeyProperties.Count() && source2.All((EdmProperty kp) => foreignKeyProperties.Contains(kp));
		if (((dependentEnd.IsMany() || associationType.IsSelfReferencing()) && flag) || (!dependentEnd.IsMany() && !flag))
		{
			return;
		}
		EdmAssociationConstraint edmAssociationConstraint = new EdmAssociationConstraint();
		edmAssociationConstraint.DependentEnd = dependentEnd;
		edmAssociationConstraint.DependentProperties = foreignKeyProperties.ToList();
		EdmAssociationConstraint edmAssociationConstraint2 = edmAssociationConstraint;
		associationType.Constraint = edmAssociationConstraint2;
		if (principalEnd.IsRequired())
		{
			edmAssociationConstraint2.DependentProperties.Each((EdmProperty p) => p.PropertyType.IsNullable = false);
		}
	}
}

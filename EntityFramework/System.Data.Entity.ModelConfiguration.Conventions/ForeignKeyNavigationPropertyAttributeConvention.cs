using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.ForeignKeyAttribute" /> found on navigation properties in the model.
/// </summary>
public sealed class ForeignKeyNavigationPropertyAttributeConvention : IEdmConvention<EdmNavigationProperty>, IConvention
{
	internal ForeignKeyNavigationPropertyAttributeConvention()
	{
	}

	void IEdmConvention<EdmNavigationProperty>.Apply(EdmNavigationProperty navigationProperty, EdmModel model)
	{
		EdmAssociationType association = navigationProperty.Association;
		if (association.Constraint != null)
		{
			return;
		}
		ForeignKeyAttribute foreignKeyAttribute = navigationProperty.GetClrAttributes<ForeignKeyAttribute>().SingleOrDefault();
		if (foreignKeyAttribute != null && (association.TryGuessPrincipalAndDependentEnds(out var _, out var dependentEnd) || association.IsPrincipalConfigured()))
		{
			dependentEnd = dependentEnd ?? association.TargetEnd;
			IEnumerable<string> dependentPropertyNames = from p in foreignKeyAttribute.Name.Split(',')
				select p.Trim();
			EdmEntityType declaringEntityType = (from e in model.GetEntityTypes()
				where e.DeclaredNavigationProperties.Contains(navigationProperty)
				select e).Single();
			EdmAssociationConstraint edmAssociationConstraint = new EdmAssociationConstraint();
			edmAssociationConstraint.DependentEnd = dependentEnd;
			edmAssociationConstraint.DependentProperties = GetDependentProperties(dependentEnd.EntityType, dependentPropertyNames, declaringEntityType, navigationProperty).ToList();
			EdmAssociationConstraint constraint = edmAssociationConstraint;
			association.Constraint = constraint;
		}
	}

	private static IEnumerable<EdmProperty> GetDependentProperties(EdmEntityType dependentType, IEnumerable<string> dependentPropertyNames, EdmEntityType declaringEntityType, EdmNavigationProperty navigationProperty)
	{
		string dependentPropertyName;
		foreach (string dependentPropertyName2 in dependentPropertyNames)
		{
			dependentPropertyName = dependentPropertyName2;
			if (string.IsNullOrWhiteSpace(dependentPropertyName))
			{
				throw Error.ForeignKeyAttributeConvention_EmptyKey(navigationProperty.Name, declaringEntityType.GetClrType());
			}
			EdmProperty dependentProperty = dependentType.Properties.SingleOrDefault((EdmProperty p) => p.Name.Equals(dependentPropertyName, StringComparison.Ordinal));
			if (dependentProperty == null)
			{
				throw Error.ForeignKeyAttributeConvention_InvalidKey(navigationProperty.Name, declaringEntityType.GetClrType(), dependentPropertyName, dependentType.GetClrType());
			}
			yield return dependentProperty;
		}
	}
}

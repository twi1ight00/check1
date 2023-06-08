using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.Edm.Validation.Internal.EdmModel;

internal static class EdmModelSemanticValidationRules
{
	internal static readonly EdmModelValidationRule<System.Data.Entity.Edm.EdmModel> EdmModel_SystemNamespaceEncountered = new EdmModelValidationRule<System.Data.Entity.Edm.EdmModel>(delegate(EdmModelValidationContext context, System.Data.Entity.Edm.EdmModel edmModel)
	{
		foreach (EdmNamespace @namespace in edmModel.Namespaces)
		{
			if (DataModelValidationHelper.IsEdmSystemNamespace(@namespace.Name))
			{
				context.AddError(@namespace, null, Strings.EdmModel_Validator_Semantic_SystemNamespaceEncountered(@namespace.Name), 161);
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityContainer> EdmEntityContainer_SimilarRelationshipEnd = new EdmModelValidationRule<EdmEntityContainer>(delegate(EdmModelValidationContext context, EdmEntityContainer edmEntityContainer)
	{
		List<KeyValuePair<EdmAssociationSet, EdmEntitySet>> list7 = new List<KeyValuePair<EdmAssociationSet, EdmEntitySet>>();
		List<KeyValuePair<EdmAssociationSet, EdmEntitySet>> list8 = new List<KeyValuePair<EdmAssociationSet, EdmEntitySet>>();
		KeyValuePair<EdmAssociationSet, EdmEntitySet> sourceEnd = default(KeyValuePair<EdmAssociationSet, EdmEntitySet>);
		KeyValuePair<EdmAssociationSet, EdmEntitySet> targetEnd = default(KeyValuePair<EdmAssociationSet, EdmEntitySet>);
		foreach (EdmAssociationSet associationSet in edmEntityContainer.AssociationSets)
		{
			ref KeyValuePair<EdmAssociationSet, EdmEntitySet> reference = ref sourceEnd;
			reference = new KeyValuePair<EdmAssociationSet, EdmEntitySet>(associationSet, associationSet.SourceSet);
			ref KeyValuePair<EdmAssociationSet, EdmEntitySet> reference2 = ref targetEnd;
			reference2 = new KeyValuePair<EdmAssociationSet, EdmEntitySet>(associationSet, associationSet.TargetSet);
			KeyValuePair<EdmAssociationSet, EdmEntitySet> keyValuePair = list7.FirstOrDefault((KeyValuePair<EdmAssociationSet, EdmEntitySet> e) => DataModelValidationHelper.AreRelationshipEndsEqual(e, sourceEnd));
			KeyValuePair<EdmAssociationSet, EdmEntitySet> keyValuePair2 = list8.FirstOrDefault((KeyValuePair<EdmAssociationSet, EdmEntitySet> e) => DataModelValidationHelper.AreRelationshipEndsEqual(e, targetEnd));
			if (!keyValuePair.Equals(default(KeyValuePair<EdmAssociationSet, EdmEntitySet>)))
			{
				context.AddError(edmEntityContainer, null, Strings.EdmModel_Validator_Semantic_SimilarRelationshipEnd(keyValuePair.Key.ElementType.SourceEnd.Name, keyValuePair.Key.Name, associationSet.Name, keyValuePair.Value.Name, edmEntityContainer.Name), 153);
			}
			else
			{
				list7.Add(sourceEnd);
			}
			if (!keyValuePair2.Equals(default(KeyValuePair<EdmAssociationSet, EdmEntitySet>)))
			{
				context.AddError(edmEntityContainer, null, Strings.EdmModel_Validator_Semantic_SimilarRelationshipEnd(keyValuePair2.Key.ElementType.TargetEnd.Name, keyValuePair2.Key.Name, associationSet.Name, keyValuePair2.Value.Name, edmEntityContainer.Name), 153);
			}
			else
			{
				list8.Add(targetEnd);
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityContainer> EdmEntityContainer_InvalidEntitySetNameReference = new EdmModelValidationRule<EdmEntityContainer>(delegate(EdmModelValidationContext context, EdmEntityContainer edmEntityContainer)
	{
		if (edmEntityContainer.AssociationSets != null)
		{
			foreach (EdmAssociationSet associationSet2 in edmEntityContainer.AssociationSets)
			{
				if (associationSet2.SourceSet != null && associationSet2.ElementType != null && associationSet2.ElementType.SourceEnd != null && !edmEntityContainer.EntitySets.Contains(associationSet2.SourceSet))
				{
					context.AddError(associationSet2.SourceSet, null, Strings.EdmModel_Validator_Semantic_InvalidEntitySetNameReference(associationSet2.SourceSet.Name, associationSet2.ElementType.SourceEnd.Name), 100);
				}
				if (associationSet2.TargetSet != null && associationSet2.ElementType != null && associationSet2.ElementType.TargetEnd != null && !edmEntityContainer.EntitySets.Contains(associationSet2.TargetSet))
				{
					context.AddError(associationSet2.TargetSet, null, Strings.EdmModel_Validator_Semantic_InvalidEntitySetNameReference(associationSet2.TargetSet.Name, associationSet2.ElementType.TargetEnd.Name), 100);
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityContainer> EdmEntityContainer_ConcurrencyRedefinedOnSubTypeOfEntitySetType = new EdmModelValidationRule<EdmEntityContainer>(delegate(EdmModelValidationContext context, EdmEntityContainer edmEntityContainer)
	{
		Dictionary<EdmEntityType, EdmEntitySet> dictionary = new Dictionary<EdmEntityType, EdmEntitySet>();
		foreach (EdmEntitySet entitySet in edmEntityContainer.EntitySets)
		{
			if (entitySet != null && entitySet.ElementType != null && !dictionary.ContainsKey(entitySet.ElementType))
			{
				dictionary.Add(entitySet.ElementType, entitySet);
			}
		}
		foreach (EdmEntityType item in context.ModelParentMap.NamespaceItems.OfType<EdmEntityType>())
		{
			if (DataModelValidationHelper.TypeIsSubTypeOf(item, dictionary, out var set) && DataModelValidationHelper.IsTypeDefinesNewConcurrencyProperties(item))
			{
				context.AddError(item, null, Strings.EdmModel_Validator_Semantic_ConcurrencyRedefinedOnSubTypeOfEntitySetType(item.GetQualifiedName(context.GetQualifiedPrefix(item)), set.ElementType.GetQualifiedName(context.GetQualifiedPrefix(set.ElementType)), set.GetQualifiedName(context.GetQualifiedPrefix(set))), 145);
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityContainer> EdmEntityContainer_DuplicateEntityContainerMemberName = new EdmModelValidationRule<EdmEntityContainer>(delegate(EdmModelValidationContext context, EdmEntityContainer edmEntityContainer)
	{
		HashSet<string> memberNameList5 = new HashSet<string>();
		foreach (EdmEntityContainerItem containerItem in edmEntityContainer.ContainerItems)
		{
			DataModelValidationHelper.AddMemberNameToHashSet(containerItem, memberNameList5, context, Strings.EdmModel_Validator_Semantic_DuplicateEntityContainerMemberName);
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntitySet> EdmEntitySet_EntitySetTypeHasNoKeys = new EdmModelValidationRule<EdmEntitySet>(delegate(EdmModelValidationContext context, EdmEntitySet edmEntitySet)
	{
		if (edmEntitySet.ElementType != null && edmEntitySet.ElementType.GetValidKey().Count() == 0)
		{
			context.AddError(edmEntitySet, "EntityType", Strings.EdmModel_Validator_Semantic_EntitySetTypeHasNoKeys(edmEntitySet.Name, edmEntitySet.ElementType.Name), 133);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationSet> EdmAssociationSet_DuplicateEndName = new EdmModelValidationRule<EdmAssociationSet>(delegate(EdmModelValidationContext context, EdmAssociationSet edmAssociationSet)
	{
		if (edmAssociationSet.ElementType != null && edmAssociationSet.ElementType.SourceEnd != null && edmAssociationSet.ElementType.TargetEnd != null && edmAssociationSet.ElementType.SourceEnd.Name == edmAssociationSet.ElementType.TargetEnd.Name)
		{
			context.AddError(edmAssociationSet.SourceSet, "Name", Strings.EdmModel_Validator_Semantic_DuplicateEndName(edmAssociationSet.ElementType.SourceEnd.Name), 17);
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_DuplicatePropertyNameSpecifiedInEntityKey = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		List<EdmProperty> list5 = edmEntityType.GetKeyProperties().ToList();
		if (list5.Count > 0)
		{
			List<EdmProperty> list6 = new List<EdmProperty>();
			EdmProperty key;
			foreach (EdmProperty item2 in list5)
			{
				key = item2;
				if (key != null && !list6.Contains(key))
				{
					if (list5.Count((EdmProperty p) => key.Equals(p)) > 1)
					{
						context.AddError(key, null, Strings.EdmModel_Validator_Semantic_DuplicatePropertyNameSpecifiedInEntityKey(edmEntityType.Name, key.Name), 154);
					}
					list6.Add(key);
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_InvalidKeyNullablePart = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		foreach (EdmProperty item3 in edmEntityType.GetValidKey())
		{
			if (item3.PropertyType.IsPrimitiveType && item3.PropertyType.IsNullable.HasValue && item3.PropertyType.IsNullable.Value)
			{
				context.AddError(item3, "Nullable", Strings.EdmModel_Validator_Semantic_InvalidKeyNullablePart(item3.Name, edmEntityType.Name), 75);
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_EntityKeyMustBeScalar = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		foreach (EdmProperty item4 in edmEntityType.GetValidKey())
		{
			if (!item4.PropertyType.IsPrimitiveType)
			{
				context.AddError(item4, null, Strings.EdmModel_Validator_Semantic_EntityKeyMustBeScalar(edmEntityType.Name, item4.Name), 128);
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_InvalidKeyKeyDefinedInBaseClass = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		if (edmEntityType.BaseType != null && edmEntityType.DeclaredKeyProperties != null && edmEntityType.DeclaredKeyProperties.Count() > 0)
		{
			context.AddError(edmEntityType.BaseType, null, Strings.EdmModel_Validator_Semantic_InvalidKeyKeyDefinedInBaseClass(edmEntityType.Name, edmEntityType.BaseType.Name), 75);
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_KeyMissingOnEntityType = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		if (edmEntityType.BaseType == null && edmEntityType.DeclaredKeyProperties.Count() == 0)
		{
			context.AddError(edmEntityType, null, Strings.EdmModel_Validator_Semantic_KeyMissingOnEntityType(edmEntityType.Name), 159);
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_InvalidMemberNameMatchesTypeName = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		List<EdmProperty> list4 = edmEntityType.Properties.ToList();
		if (edmEntityType.Name.HasContent() && list4.Count > 0)
		{
			foreach (EdmProperty item5 in list4)
			{
				if (item5 != null && item5.Name.EqualsOrdinal(edmEntityType.Name))
				{
					context.AddError(item5, "Name", Strings.EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName(item5.Name, edmEntityType.GetQualifiedName(context.GetQualifiedPrefix(edmEntityType))), 42);
				}
			}
			if (edmEntityType.HasDeclaredNavigationProperties)
			{
				foreach (EdmNavigationProperty declaredNavigationProperty in edmEntityType.DeclaredNavigationProperties)
				{
					if (declaredNavigationProperty != null && declaredNavigationProperty.Name.EqualsOrdinal(edmEntityType.Name))
					{
						context.AddError(declaredNavigationProperty, "Name", Strings.EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName(declaredNavigationProperty.Name, edmEntityType.GetQualifiedName(context.GetQualifiedPrefix(edmEntityType))), 42);
					}
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_PropertyNameAlreadyDefinedDuplicate = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		HashSet<string> memberNameList4 = new HashSet<string>();
		foreach (EdmProperty property in edmEntityType.Properties)
		{
			if (property != null && property.Name.HasContent())
			{
				DataModelValidationHelper.AddMemberNameToHashSet(property, memberNameList4, context, (string name) => Strings.EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate(name));
			}
		}
		if (edmEntityType.HasDeclaredNavigationProperties)
		{
			foreach (EdmNavigationProperty declaredNavigationProperty2 in edmEntityType.DeclaredNavigationProperties)
			{
				if (declaredNavigationProperty2 != null && declaredNavigationProperty2.Name.HasContent())
				{
					DataModelValidationHelper.AddMemberNameToHashSet(declaredNavigationProperty2, memberNameList4, context, (string name) => Strings.EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate(name));
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntityType> EdmEntityType_CycleInTypeHierarchy = new EdmModelValidationRule<EdmEntityType>(delegate(EdmModelValidationContext context, EdmEntityType edmEntityType)
	{
		if (DataModelValidationHelper.CheckForInheritanceCycle(edmEntityType, (EdmEntityType et) => et.BaseType))
		{
			context.AddError(edmEntityType, "BaseType", Strings.EdmModel_Validator_Semantic_CycleInTypeHierarchy(edmEntityType.GetQualifiedName(context.GetQualifiedPrefix(edmEntityType))), 24);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNavigationProperty> EdmNavigationProperty_BadNavigationPropertyUndefinedRole = new EdmModelValidationRule<EdmNavigationProperty>(delegate(EdmModelValidationContext context, EdmNavigationProperty edmNavigationProperty)
	{
		if (edmNavigationProperty.Association != null && edmNavigationProperty.Association.SourceEnd != null && edmNavigationProperty.Association.TargetEnd != null && edmNavigationProperty.Association.SourceEnd.Name != null && edmNavigationProperty.Association.TargetEnd.Name != null && edmNavigationProperty.ResultEnd != edmNavigationProperty.Association.SourceEnd && edmNavigationProperty.ResultEnd != edmNavigationProperty.Association.TargetEnd)
		{
			context.AddError(edmNavigationProperty, null, Strings.EdmModel_Validator_Semantic_BadNavigationPropertyUndefinedRole(edmNavigationProperty.Association.SourceEnd.Name, edmNavigationProperty.Association.TargetEnd.Name, edmNavigationProperty.Association.Name), 74);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNavigationProperty> EdmNavigationProperty_BadNavigationPropertyRolesCannotBeTheSame = new EdmModelValidationRule<EdmNavigationProperty>(delegate(EdmModelValidationContext context, EdmNavigationProperty edmNavigationProperty)
	{
		if (edmNavigationProperty.Association != null && edmNavigationProperty.Association.SourceEnd != null && edmNavigationProperty.Association.TargetEnd != null && edmNavigationProperty.ResultEnd == edmNavigationProperty.GetFromEnd())
		{
			context.AddError(edmNavigationProperty, "ToRole", Strings.EdmModel_Validator_Semantic_BadNavigationPropertyRolesCannotBeTheSame, 74);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_InvalidOperationMultipleEndsInAssociation = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (edmAssociationType.SourceEnd != null && edmAssociationType.SourceEnd.DeleteAction.HasValue && edmAssociationType.SourceEnd.DeleteAction.Value != 0 && edmAssociationType.TargetEnd != null && edmAssociationType.TargetEnd.DeleteAction.HasValue && edmAssociationType.TargetEnd.DeleteAction.Value != 0)
		{
			context.AddError(edmAssociationType, null, Strings.EdmModel_Validator_Semantic_InvalidOperationMultipleEndsInAssociation, 97);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_EndWithManyMultiplicityCannotHaveOperationsSpecified = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (edmAssociationType.SourceEnd != null && edmAssociationType.SourceEnd.EndKind == EdmAssociationEndKind.Many && edmAssociationType.SourceEnd.DeleteAction.HasValue && edmAssociationType.SourceEnd.DeleteAction.Value != 0)
		{
			context.AddError(edmAssociationType.SourceEnd, "OnDelete", Strings.EdmModel_Validator_Semantic_EndWithManyMultiplicityCannotHaveOperationsSpecified(edmAssociationType.SourceEnd.Name, edmAssociationType.Name), 132);
		}
		if (edmAssociationType.TargetEnd != null && edmAssociationType.TargetEnd.EndKind == EdmAssociationEndKind.Many && edmAssociationType.TargetEnd.DeleteAction.HasValue && edmAssociationType.TargetEnd.DeleteAction.Value != 0)
		{
			context.AddError(edmAssociationType.TargetEnd, "OnDelete", Strings.EdmModel_Validator_Semantic_EndWithManyMultiplicityCannotHaveOperationsSpecified(edmAssociationType.TargetEnd.Name, edmAssociationType.Name), 132);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_EndNameAlreadyDefinedDuplicate = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (edmAssociationType.SourceEnd != null && edmAssociationType.TargetEnd != null && edmAssociationType.SourceEnd.Name == edmAssociationType.TargetEnd.Name)
		{
			context.AddError(edmAssociationType.SourceEnd, "Name", Strings.EdmModel_Validator_Semantic_EndNameAlreadyDefinedDuplicate(edmAssociationType.SourceEnd.Name), 19);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_SameRoleReferredInReferentialConstraint = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (DataModelValidationHelper.IsReferentialConstraintReadyForValidation(edmAssociationType) && edmAssociationType.Constraint.PrincipalEnd(edmAssociationType).Name == edmAssociationType.Constraint.DependentEnd.Name)
		{
			context.AddError(edmAssociationType.Constraint.DependentEnd, null, Strings.EdmModel_Validator_Semantic_SameRoleReferredInReferentialConstraint(edmAssociationType.Name), 119);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_ValidateReferentialConstraint = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (DataModelValidationHelper.IsReferentialConstraintReadyForValidation(edmAssociationType))
		{
			EdmAssociationConstraint constraint = edmAssociationType.Constraint;
			EdmAssociationEnd edmAssociationEnd = constraint.PrincipalEnd(edmAssociationType);
			EdmAssociationEnd dependentEnd = constraint.DependentEnd;
			DataModelValidationHelper.IsKeyProperty(constraint.DependentProperties.ToList(), dependentEnd, out var isKeyProperty, out var areAllPropertiesNullable, out var isAnyPropertyNullable, out var isSubsetOfKeyProperties);
			DataModelValidationHelper.IsKeyProperty(constraint.PrincipalEnd(edmAssociationType).EntityType.GetValidKey().ToList(), edmAssociationEnd, out var _, out var _, out var _, out var _);
			bool flag = context.ValidationContextVersion <= DataModelVersions.Version1_1;
			if (edmAssociationEnd.EndKind == EdmAssociationEndKind.Many)
			{
				context.AddError(edmAssociationEnd, null, Strings.EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleUpperBoundMustBeOne(edmAssociationEnd.Name, edmAssociationType.Name), 113);
			}
			else if (areAllPropertiesNullable && edmAssociationEnd.EndKind == EdmAssociationEndKind.Required)
			{
				string errorMessage = Strings.EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNullableV1(edmAssociationEnd.Name, edmAssociationType.Name);
				context.AddError(edmAssociationType, null, errorMessage, 113);
			}
			else if (((flag && !areAllPropertiesNullable) || (!flag && !isAnyPropertyNullable)) && edmAssociationEnd.EndKind != EdmAssociationEndKind.Required)
			{
				string errorMessage2 = ((!flag) ? Strings.EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV2(edmAssociationEnd.Name, edmAssociationType.Name) : Strings.EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV1(edmAssociationEnd.Name, edmAssociationType.Name));
				context.AddError(edmAssociationType, null, errorMessage2, 113);
			}
			if (!isSubsetOfKeyProperties && !edmAssociationType.IsForeignKey(context.ValidationContextVersion))
			{
				context.AddError(dependentEnd, null, Strings.EdmModel_Validator_Semantic_InvalidToPropertyInRelationshipConstraint(dependentEnd.Name, dependentEnd.EntityType.GetQualifiedName(context.GetQualifiedPrefix(dependentEnd.EntityType)), edmAssociationType.GetQualifiedName(context.GetQualifiedPrefix(edmAssociationType))), 111);
			}
			if (isKeyProperty)
			{
				if (dependentEnd.EndKind == EdmAssociationEndKind.Many)
				{
					context.AddError(dependentEnd, null, Strings.EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeOne(dependentEnd.Name, edmAssociationType.Name), 113);
				}
			}
			else if (dependentEnd.EndKind != EdmAssociationEndKind.Many)
			{
				context.AddError(dependentEnd, null, Strings.EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeMany(dependentEnd.Name, edmAssociationType.Name), 113);
			}
			List<EdmProperty> list2 = edmAssociationEnd.EntityType.GetValidKey().ToList();
			List<EdmProperty> list3 = constraint.DependentProperties.ToList();
			if (list3.Count != list2.Count)
			{
				context.AddError(constraint, null, Strings.EdmModel_Validator_Semantic_MismatchNumberOfPropertiesinRelationshipConstraint, 114);
			}
			else
			{
				int count = list3.Count;
				for (int i = 0; i < count; i++)
				{
					EdmProperty edmProperty2 = list2[i];
					EdmProperty edmProperty3 = list3[i];
					if (edmProperty2 != null && edmProperty3 != null && edmProperty2.PropertyType != null && edmProperty3.PropertyType != null && edmProperty2.PropertyType.IsPrimitiveType && edmProperty3.PropertyType.IsPrimitiveType && !DataModelValidationHelper.IsPrimitiveTypesEqual(edmProperty3.PropertyType, edmProperty2.PropertyType))
					{
						context.AddError(constraint, null, Strings.EdmModel_Validator_Semantic_TypeMismatchRelationshipConstraint(constraint.DependentProperties.ToList()[i].Name, dependentEnd.EntityType.Name, list2[i].Name, edmAssociationEnd.EntityType.Name, edmAssociationType.Name), 112);
					}
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_InvalidPropertyInRelationshipConstraint = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (edmAssociationType.Constraint != null && edmAssociationType.Constraint.DependentEnd != null && edmAssociationType.Constraint.DependentEnd.EntityType != null)
		{
			List<EdmProperty> list = edmAssociationType.Constraint.DependentEnd.EntityType.Properties.ToList();
			foreach (EdmProperty dependentProperty in edmAssociationType.Constraint.DependentProperties)
			{
				if (dependentProperty != null && !list.Contains(dependentProperty))
				{
					context.AddError(dependentProperty, null, Strings.EdmModel_Validator_Semantic_InvalidPropertyInRelationshipConstraint(dependentProperty.Name, edmAssociationType.Constraint.DependentEnd.Name), 111);
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmComplexType> EdmComplexType_InvalidIsAbstract = new EdmModelValidationRule<EdmComplexType>(delegate(EdmModelValidationContext context, EdmComplexType edmComplexType)
	{
		if (edmComplexType.IsAbstract)
		{
			context.AddError(edmComplexType, "IsAbstract", Strings.EdmModel_Validator_Semantic_InvalidComplexTypeAbstract(edmComplexType.GetQualifiedName(context.GetQualifiedPrefix(edmComplexType))), 220);
		}
	});

	internal static readonly EdmModelValidationRule<EdmComplexType> EdmComplexType_InvalidIsPolymorphic = new EdmModelValidationRule<EdmComplexType>(delegate(EdmModelValidationContext context, EdmComplexType edmComplexType)
	{
		if (edmComplexType.BaseType != null)
		{
			context.AddError(edmComplexType, "BaseType", Strings.EdmModel_Validator_Semantic_InvalidComplexTypePolymorphic(edmComplexType.GetQualifiedName(context.GetQualifiedPrefix(edmComplexType))), 221);
		}
	});

	internal static readonly EdmModelValidationRule<EdmComplexType> EdmComplexType_InvalidMemberNameMatchesTypeName = new EdmModelValidationRule<EdmComplexType>(delegate(EdmModelValidationContext context, EdmComplexType edmComplexType)
	{
		if (edmComplexType.Name.HasContent() && edmComplexType.HasDeclaredProperties)
		{
			foreach (EdmProperty declaredProperty in edmComplexType.DeclaredProperties)
			{
				if (declaredProperty != null && declaredProperty.Name.EqualsOrdinal(edmComplexType.Name))
				{
					context.AddError(declaredProperty, "Name", Strings.EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName(declaredProperty.Name, edmComplexType.GetQualifiedName(context.GetQualifiedPrefix(edmComplexType))), 42);
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmComplexType> EdmComplexType_PropertyNameAlreadyDefinedDuplicate = new EdmModelValidationRule<EdmComplexType>(delegate(EdmModelValidationContext context, EdmComplexType edmComplexType)
	{
		if (edmComplexType.HasDeclaredProperties)
		{
			HashSet<string> memberNameList3 = new HashSet<string>();
			foreach (EdmProperty declaredProperty2 in edmComplexType.DeclaredProperties)
			{
				if (declaredProperty2.Name.HasContent())
				{
					DataModelValidationHelper.AddMemberNameToHashSet(declaredProperty2, memberNameList3, context, (string name) => Strings.EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate(name));
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmComplexType> EdmComplexType_PropertyNameAlreadyDefinedDuplicate_V1_1 = new EdmModelValidationRule<EdmComplexType>(delegate(EdmModelValidationContext context, EdmComplexType edmComplexType)
	{
		if (edmComplexType.HasDeclaredProperties)
		{
			HashSet<string> memberNameList2 = new HashSet<string>();
			foreach (EdmProperty property2 in edmComplexType.Properties)
			{
				if (property2 != null && property2.Name.HasContent())
				{
					DataModelValidationHelper.AddMemberNameToHashSet(property2, memberNameList2, context, (string name) => Strings.EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate(name));
				}
			}
		}
	});

	internal static readonly EdmModelValidationRule<EdmComplexType> EdmComplexType_CycleInTypeHierarchy_V1_1 = new EdmModelValidationRule<EdmComplexType>(delegate(EdmModelValidationContext context, EdmComplexType edmComplexType)
	{
		if (DataModelValidationHelper.CheckForInheritanceCycle(edmComplexType, (EdmComplexType ct) => ct.BaseType))
		{
			context.AddError(edmComplexType, "BaseType", Strings.EdmModel_Validator_Semantic_CycleInTypeHierarchy(edmComplexType.GetQualifiedName(context.GetQualifiedPrefix(edmComplexType))), 24);
		}
	});

	internal static readonly EdmModelValidationRule<EdmProperty> EdmProperty_InvalidCollectionKind = new EdmModelValidationRule<EdmProperty>(delegate(EdmModelValidationContext context, EdmProperty edmProperty)
	{
		if (edmProperty.CollectionKind != 0)
		{
			context.AddError(edmProperty, "CollectionKind", Strings.EdmModel_Validator_Semantic_InvalidCollectionKindNotV1_1(edmProperty.Name), 165);
		}
	});

	internal static readonly EdmModelValidationRule<EdmProperty> EdmProperty_InvalidCollectionKind_V1_1 = new EdmModelValidationRule<EdmProperty>(delegate(EdmModelValidationContext context, EdmProperty edmProperty)
	{
		if (edmProperty.CollectionKind != 0 && edmProperty.PropertyType != null && !edmProperty.PropertyType.IsCollectionType)
		{
			context.AddError(edmProperty, "CollectionKind", Strings.EdmModel_Validator_Semantic_InvalidCollectionKindNotCollection(edmProperty.Name), 165);
		}
	});

	internal static readonly EdmModelValidationRule<EdmProperty> EdmProperty_NullableComplexType = new EdmModelValidationRule<EdmProperty>(delegate(EdmModelValidationContext context, EdmProperty edmProperty)
	{
		if (edmProperty.PropertyType != null && edmProperty.PropertyType.ComplexType != null && edmProperty.PropertyType.IsNullable.HasValue && edmProperty.PropertyType.IsNullable.Value)
		{
			context.AddError(edmProperty, "Nullable", Strings.EdmModel_Validator_Semantic_NullableComplexType(edmProperty.Name), 157);
		}
	});

	internal static readonly EdmModelValidationRule<EdmProperty> EdmProperty_InvalidPropertyType = new EdmModelValidationRule<EdmProperty>(delegate(EdmModelValidationContext context, EdmProperty edmProperty)
	{
		if (edmProperty.PropertyType != null && edmProperty.PropertyType.EdmType != null && !edmProperty.PropertyType.IsPrimitiveType && !edmProperty.PropertyType.IsComplexType)
		{
			context.AddError(edmProperty, "Type", Strings.EdmModel_Validator_Semantic_InvalidPropertyType(edmProperty.PropertyType.IsCollectionType ? "CollectionType" : edmProperty.PropertyType.EdmType.ItemKind.ToString()), 44);
		}
	});

	internal static readonly EdmModelValidationRule<EdmProperty> EdmProperty_InvalidPropertyType_V1_1 = new EdmModelValidationRule<EdmProperty>(delegate(EdmModelValidationContext context, EdmProperty edmProperty)
	{
		if (edmProperty.PropertyType != null && edmProperty.PropertyType.EdmType != null && !edmProperty.PropertyType.IsPrimitiveType && !edmProperty.PropertyType.IsComplexType && !edmProperty.PropertyType.IsCollectionType)
		{
			context.AddError(edmProperty, "Type", Strings.EdmModel_Validator_Semantic_InvalidPropertyType_V1_1(edmProperty.PropertyType.EdmType.ItemKind.ToString()), 44);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNamespace> EdmNamespace_TypeNameAlreadyDefinedDuplicate = new EdmModelValidationRule<EdmNamespace>(delegate(EdmModelValidationContext context, EdmNamespace edmNamespace)
	{
		HashSet<string> memberNameList = new HashSet<string>();
		foreach (EdmNamespaceItem namespaceItem in edmNamespace.NamespaceItems)
		{
			DataModelValidationHelper.AddMemberNameToHashSet(namespaceItem, memberNameList, context, Strings.EdmModel_Validator_Semantic_TypeNameAlreadyDefinedDuplicate);
		}
	});
}

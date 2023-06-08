using System.Data.Entity.Edm.Internal;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.Edm.Validation.Internal.EdmModel;

internal static class EdmModelSyntacticValidationRules
{
	internal static readonly EdmModelValidationRule<EdmNamedMetadataItem> EdmModel_NameMustNotBeEmptyOrWhiteSpace = new EdmModelValidationRule<EdmNamedMetadataItem>(delegate(EdmModelValidationContext context, EdmNamedMetadataItem item)
	{
		if (!item.Name.HasContent())
		{
			context.AddError(item, "Name", Strings.EdmModel_Validator_Syntactic_MissingName, 17);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNamedMetadataItem> EdmModel_NameIsTooLong = new EdmModelValidationRule<EdmNamedMetadataItem>(delegate(EdmModelValidationContext context, EdmNamedMetadataItem item)
	{
		if (item.Name.HasContent() && item.Name.Length > 480)
		{
			context.AddError(item, "Name", Strings.EdmModel_Validator_Syntactic_EdmModel_NameIsTooLong(item.Name), 17);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNamedMetadataItem> EdmModel_NameIsNotAllowed = new EdmModelValidationRule<EdmNamedMetadataItem>(delegate(EdmModelValidationContext context, EdmNamedMetadataItem item)
	{
		if (item.Name.HasContent() && item.Name.Length < 480 && !((item is EdmQualifiedNameMetadataItem) ? EdmUtil.IsValidQualifiedItemName(item.Name) : EdmUtil.IsValidDataModelItemName(item.Name)))
		{
			context.AddError(item, "Name", Strings.EdmModel_Validator_Syntactic_EdmModel_NameIsNotAllowed(item.Name), 17);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationType> EdmAssociationType_AssocationEndMustNotBeNull = new EdmModelValidationRule<EdmAssociationType>(delegate(EdmModelValidationContext context, EdmAssociationType edmAssociationType)
	{
		if (edmAssociationType.SourceEnd == null || edmAssociationType.TargetEnd == null)
		{
			context.AddError(edmAssociationType, "End", Strings.EdmModel_Validator_Syntactic_EdmAssociationType_AssocationEndMustNotBeNull, 200);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationConstraint> EdmAssociationConstraint_DependentEndMustNotBeNull = new EdmModelValidationRule<EdmAssociationConstraint>(delegate(EdmModelValidationContext context, EdmAssociationConstraint edmAssociationConstraint)
	{
		if (edmAssociationConstraint.DependentEnd == null)
		{
			context.AddError(edmAssociationConstraint, "Dependent", Strings.EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentEndMustNotBeNull, 201);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationConstraint> EdmAssociationConstraint_DependentPropertiesMustNotBeEmpty = new EdmModelValidationRule<EdmAssociationConstraint>(delegate(EdmModelValidationContext context, EdmAssociationConstraint edmAssociationConstraint)
	{
		if (edmAssociationConstraint.DependentProperties == null || edmAssociationConstraint.DependentProperties.Count() == 0)
		{
			context.AddError(edmAssociationConstraint, "Dependent", Strings.EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentPropertiesMustNotBeEmpty, 202);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNavigationProperty> EdmNavigationProperty_AssocationMustNotBeNull = new EdmModelValidationRule<EdmNavigationProperty>(delegate(EdmModelValidationContext context, EdmNavigationProperty edmNavigationProperty)
	{
		if (edmNavigationProperty.Association == null)
		{
			context.AddError(edmNavigationProperty, "Relationship", Strings.EdmModel_Validator_Syntactic_EdmNavigationProperty_AssocationMustNotBeNull, 203);
		}
	});

	internal static readonly EdmModelValidationRule<EdmNavigationProperty> EdmNavigationProperty_ResultEndMustNotBeNull = new EdmModelValidationRule<EdmNavigationProperty>(delegate(EdmModelValidationContext context, EdmNavigationProperty edmNavigationProperty)
	{
		if (edmNavigationProperty.ResultEnd == null)
		{
			context.AddError(edmNavigationProperty, "ResultEnd", Strings.EdmModel_Validator_Syntactic_EdmNavigationProperty_ResultEndMustNotBeNull, 204);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationEnd> EdmAssociationEnd_EntityTypeMustNotBeNull = new EdmModelValidationRule<EdmAssociationEnd>(delegate(EdmModelValidationContext context, EdmAssociationEnd edmAssociationEnd)
	{
		if (edmAssociationEnd.EntityType == null)
		{
			context.AddError(edmAssociationEnd, "Type", Strings.EdmModel_Validator_Syntactic_EdmAssociationEnd_EntityTypeMustNotBeNull, 205);
		}
	});

	internal static readonly EdmModelValidationRule<EdmEntitySet> EdmEntitySet_ElementTypeMustNotBeNull = new EdmModelValidationRule<EdmEntitySet>(delegate(EdmModelValidationContext context, EdmEntitySet edmEntitySet)
	{
		if (edmEntitySet.ElementType == null)
		{
			context.AddError(edmEntitySet, "ElementType", Strings.EdmModel_Validator_Syntactic_EdmEntitySet_ElementTypeMustNotBeNull, 206);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationSet> EdmAssociationSet_ElementTypeMustNotBeNull = new EdmModelValidationRule<EdmAssociationSet>(delegate(EdmModelValidationContext context, EdmAssociationSet edmAssociationSet)
	{
		if (edmAssociationSet.ElementType == null)
		{
			context.AddError(edmAssociationSet, "ElementType", Strings.EdmModel_Validator_Syntactic_EdmAssociationSet_ElementTypeMustNotBeNull, 207);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationSet> EdmAssociationSet_SourceSetMustNotBeNull = new EdmModelValidationRule<EdmAssociationSet>(delegate(EdmModelValidationContext context, EdmAssociationSet edmAssociationSet)
	{
		if (edmAssociationSet.SourceSet == null)
		{
			context.AddError(edmAssociationSet, "SourceSet", Strings.EdmModel_Validator_Syntactic_EdmAssociationSet_SourceSetMustNotBeNull, 208);
		}
	});

	internal static readonly EdmModelValidationRule<EdmAssociationSet> EdmAssociationSet_TargetSetMustNotBeNull = new EdmModelValidationRule<EdmAssociationSet>(delegate(EdmModelValidationContext context, EdmAssociationSet edmAssociationSet)
	{
		if (edmAssociationSet.TargetSet == null)
		{
			context.AddError(edmAssociationSet, "TargetSet", Strings.EdmModel_Validator_Syntactic_EdmAssociationSet_TargetSetMustNotBeNull, 209);
		}
	});

	internal static readonly EdmModelValidationRule<EdmTypeReference> EdmTypeReference_TypeNotValid = new EdmModelValidationRule<EdmTypeReference>(delegate(EdmModelValidationContext context, EdmTypeReference edmTypeReference)
	{
		if (!DataModelValidationHelper.IsEdmTypeReferenceValid(edmTypeReference))
		{
			context.AddError(edmTypeReference, null, Strings.EdmModel_Validator_Syntactic_EdmTypeReferenceNotValid, 212);
		}
	});
}

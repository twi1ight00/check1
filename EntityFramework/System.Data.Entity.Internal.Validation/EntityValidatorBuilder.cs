using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Builds validators based on <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute" />s specified on entity CLR types and properties
///     as well as based on presence of <see cref="T:System.ComponentModel.DataAnnotations.IValidatableObject" /> implementation on entity and complex
///     type CLR types. It's not sealed and not static for mocking purposes.
/// </summary>
internal class EntityValidatorBuilder
{
	private readonly AttributeProvider _attributeProvider;

	public EntityValidatorBuilder(AttributeProvider attributeProvider)
	{
		_attributeProvider = attributeProvider;
	}

	/// <summary>
	///     Builds an <see cref="T:System.Data.Entity.Internal.Validation.EntityValidator" /> for the given <paramref name="entityEntry" />.
	/// </summary>
	/// <param name="entityType">The entity entry to build the validator for.</param>
	/// <param name="targetType">Whether the currently processed type is the target type or one of the ancestor types.
	/// </param>
	/// <returns>
	///     <see cref="T:System.Data.Entity.Internal.Validation.EntityValidator" /> for the given <paramref name="entityEntry" />. Possibly null 
	///     if no validation has been specified for this entity type.
	/// </returns>
	public virtual EntityValidator BuildEntityValidator(InternalEntityEntry entityEntry)
	{
		return BuildTypeValidator(entityEntry.EntityType, entityEntry.EdmEntityType.Properties, entityEntry.EdmEntityType.NavigationProperties, (IEnumerable<PropertyValidator> propertyValidators, IEnumerable<IValidator> typeLevelValidators) => new EntityValidator(propertyValidators, typeLevelValidators));
	}

	/// <summary>
	///     Builds the validator for a given <paramref name="complexType" /> and the corresponding
	///     <paramref name="clrType" />.
	/// </summary>
	/// <param name="clrType">The CLR type that corresponds to the EDM complex type.</param>
	/// <param name="complexType">The EDM complex type that type level validation is built for.</param>
	/// <returns>A <see cref="T:System.Data.Entity.Internal.Validation.ComplexTypeValidator" /> for the given complex type. May be null if no validation specified.</returns>
	protected virtual ComplexTypeValidator BuildComplexTypeValidator(Type clrType, ComplexType complexType)
	{
		return BuildTypeValidator(clrType, complexType.Properties, Enumerable.Empty<NavigationProperty>(), (IEnumerable<PropertyValidator> propertyValidators, IEnumerable<IValidator> typeLevelValidators) => new ComplexTypeValidator(propertyValidators, typeLevelValidators));
	}

	/// <summary>
	///     Extracted method from BuildEntityValidator and BuildComplexTypeValidator
	/// </summary>
	private T BuildTypeValidator<T>(Type clrType, IEnumerable<EdmProperty> edmProperties, IEnumerable<NavigationProperty> navigationProperties, Func<IEnumerable<PropertyValidator>, IEnumerable<IValidator>, T> validatorFactoryFunc) where T : TypeValidator
	{
		IList<PropertyValidator> list = BuildValidatorsForProperties(GetPublicInstanceProperties(clrType), edmProperties, navigationProperties);
		IEnumerable<Attribute> attributes = _attributeProvider.GetAttributes(clrType);
		IList<IValidator> list2 = BuildValidationAttributeValidators(attributes);
		if (typeof(IValidatableObject).IsAssignableFrom(clrType))
		{
			list2.Add(new ValidatableObjectValidator(attributes.OfType<DisplayAttribute>().SingleOrDefault()));
		}
		if (!list.Any() && !list2.Any())
		{
			return null;
		}
		return validatorFactoryFunc(list, list2);
	}

	/// <summary>
	///     Build validators for the <paramref name="clrProperties" /> and the corresponding <paramref name="edmProperties" />
	///     or <paramref name="navigationProperties" />.
	/// </summary>
	/// <param name="clrProperties">Properties to build validators for.</param>
	/// <param name="edmProperties">Non-navigation EDM properties.</param>
	/// <param name="navigationProperties">Navigation EDM properties.</param>
	/// <returns>A list of validators. Possibly empty, never null.</returns>
	protected virtual IList<PropertyValidator> BuildValidatorsForProperties(IEnumerable<PropertyInfo> clrProperties, IEnumerable<EdmProperty> edmProperties, IEnumerable<NavigationProperty> navigationProperties)
	{
		List<PropertyValidator> list = new List<PropertyValidator>();
		PropertyInfo property;
		foreach (PropertyInfo clrProperty in clrProperties)
		{
			property = clrProperty;
			PropertyValidator propertyValidator = null;
			EdmProperty edmProperty = edmProperties.Where((EdmProperty p) => p.Name == property.Name).SingleOrDefault();
			if (edmProperty != null)
			{
				IEnumerable<ReferentialConstraint> source = from navigationProperty in navigationProperties
					let associationType = navigationProperty.RelationshipType as AssociationType
					where associationType != null
					from constraint in associationType.ReferentialConstraints
					where constraint.ToProperties.Contains(edmProperty)
					select constraint;
				propertyValidator = BuildPropertyValidator(buildFacetValidators: !source.Any(), clrProperty: property, edmProperty: edmProperty);
			}
			else
			{
				propertyValidator = BuildPropertyValidator(property);
			}
			if (propertyValidator != null)
			{
				list.Add(propertyValidator);
			}
		}
		return list;
	}

	/// <summary>
	///     Builds a <see cref="T:System.Data.Entity.Internal.Validation.PropertyValidator" /> for the given <paramref name="edmProperty" /> and the corresponding
	///     <paramref name="clrProperty" />. If the property is a complex type, type level validators will be built here as
	///     well.
	/// </summary>
	/// <param name="clrProperty">The CLR property to build the validator for.</param>
	/// <param name="edmProperty">The EDM property to build the validator for.</param>
	/// <returns>
	///     <see cref="T:System.Data.Entity.Internal.Validation.PropertyValidator" /> for the given <paramref name="edmProperty" />. Possibly null
	///     if no validation has been specified for this property.
	/// </returns>
	protected virtual PropertyValidator BuildPropertyValidator(PropertyInfo clrProperty, EdmProperty edmProperty, bool buildFacetValidators)
	{
		List<IValidator> list = new List<IValidator>();
		IEnumerable<Attribute> attributes = _attributeProvider.GetAttributes(clrProperty);
		list.AddRange(BuildValidationAttributeValidators(attributes));
		if (edmProperty.TypeUsage.EdmType.BuiltInTypeKind == BuiltInTypeKind.ComplexType)
		{
			ComplexType complexType = (ComplexType)edmProperty.TypeUsage.EdmType;
			ComplexTypeValidator complexTypeValidator = BuildComplexTypeValidator(clrProperty.PropertyType, complexType);
			if (!list.Any() && complexTypeValidator == null)
			{
				return null;
			}
			return new ComplexPropertyValidator(clrProperty.Name, list, complexTypeValidator);
		}
		if (buildFacetValidators)
		{
			list.AddRange(BuildFacetValidators(clrProperty, edmProperty, attributes));
		}
		if (!list.Any())
		{
			return null;
		}
		return new PropertyValidator(clrProperty.Name, list);
	}

	/// <summary>
	///     Builds a <see cref="T:System.Data.Entity.Internal.Validation.PropertyValidator" /> for the given transient <paramref name="clrProperty" />.
	/// </summary>
	/// <param name="clrProperty">The CLR property to build the validator for.</param>
	/// <returns>
	///     <see cref="T:System.Data.Entity.Internal.Validation.PropertyValidator" /> for the given <paramref name="clrProperty" />. Possibly null
	///     if no validation has been specified for this property.
	/// </returns>
	protected virtual PropertyValidator BuildPropertyValidator(PropertyInfo clrProperty)
	{
		IList<IValidator> list = BuildValidationAttributeValidators(_attributeProvider.GetAttributes(clrProperty));
		if (list.Count <= 0)
		{
			return null;
		}
		return new PropertyValidator(clrProperty.Name, list);
	}

	/// <summary>
	///     Builds <see cref="T:System.Data.Entity.Internal.Validation.ValidationAttributeValidator" />s for given <paramref name="attributes" /> that derive from
	///     <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute" />.
	/// </summary>
	/// <param name="attributes">Attributes used to build validators.</param>
	/// <returns>
	///     A list of <see cref="T:System.Data.Entity.Internal.Validation.ValidationAttributeValidator" />s built from <paramref name="attributes" />. 
	///     Possibly empty, never null. 
	/// </returns>
	protected virtual IList<IValidator> BuildValidationAttributeValidators(IEnumerable<Attribute> attributes)
	{
		return ((IEnumerable<IValidator>)(from validationAttribute in attributes
			where validationAttribute is ValidationAttribute
			select new ValidationAttributeValidator((ValidationAttribute)validationAttribute, attributes.OfType<DisplayAttribute>().SingleOrDefault()))).ToList();
	}

	/// <summary>
	///     Returns all non-static non-indexed CLR properties from the <paramref name="type" />.
	/// </summary>
	/// <param name="type">The CLR <see cref="T:System.Type" /> to get the properties from.</param>
	/// <returns>
	///     A collection of CLR properties. Possibly empty, never null.
	/// </returns>
	protected virtual IEnumerable<PropertyInfo> GetPublicInstanceProperties(Type type)
	{
		return from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where p.GetIndexParameters().Length == 0 && p.GetGetMethod() != null
			select p;
	}

	/// <summary>
	///     Builds validators based on the facets of <paramref name="edmProperty" />:
	///     * If .Nullable facet set to false adds a validator equivalent to the RequiredAttribute
	///     * If the .MaxLength facet is specified adds a validator equivalent to the MaxLengthAttribute.
	///     However the validator isn't added if .IsMaxLength has been set to true.
	/// </summary>
	/// <param name="clrProperty">The CLR property to build the facet validators for.</param>
	/// <param name="edmProperty">The property for which facet validators will be created</param>
	/// <returns>A collection of validators.</returns>
	protected virtual IEnumerable<IValidator> BuildFacetValidators(PropertyInfo clrProperty, EdmMember edmProperty, IEnumerable<Attribute> existingAttributes)
	{
		List<ValidationAttribute> list = new List<ValidationAttribute>();
		edmProperty.MetadataProperties.TryGetValue("http://schemas.microsoft.com/ado/2009/02/edm/annotation:StoreGeneratedPattern", ignoreCase: false, out var item);
		bool flag = item != null && item.Value != null;
		edmProperty.TypeUsage.Facets.TryGetValue("Nullable", ignoreCase: false, out var item2);
		if (item2 != null && item2.Value != null && !(bool)item2.Value && !flag && clrProperty.PropertyType.IsNullable() && !existingAttributes.Any((Attribute a) => a is RequiredAttribute))
		{
			list.Add(new RequiredAttribute
			{
				AllowEmptyStrings = true
			});
		}
		edmProperty.TypeUsage.Facets.TryGetValue("MaxLength", ignoreCase: false, out var item3);
		if (item3 != null && item3.Value != null && item3.Value is int && !existingAttributes.Any((Attribute a) => a is MaxLengthAttribute) && !existingAttributes.Any((Attribute a) => a is StringLengthAttribute))
		{
			list.Add(new MaxLengthAttribute((int)item3.Value));
		}
		return list.Select((ValidationAttribute attribute) => new ValidationAttributeValidator(attribute, existingAttributes.OfType<DisplayAttribute>().SingleOrDefault()));
	}
}

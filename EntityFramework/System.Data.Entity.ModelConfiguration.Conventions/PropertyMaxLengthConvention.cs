using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to set a default maximum length of 128 for properties whose type supports length facets.
/// </summary>
public sealed class PropertyMaxLengthConvention : IEdmConvention<EdmEntityType>, IEdmConvention<EdmComplexType>, IEdmConvention<EdmAssociationType>, IConvention
{
	private const int DefaultLength = 128;

	internal PropertyMaxLengthConvention()
	{
	}

	void IEdmConvention<EdmEntityType>.Apply(EdmEntityType entityType, EdmModel model)
	{
		SetLength(entityType.DeclaredProperties, entityType.DeclaredKeyProperties);
	}

	void IEdmConvention<EdmComplexType>.Apply(EdmComplexType complexType, EdmModel model)
	{
		SetLength(complexType.DeclaredProperties, new List<EdmProperty>());
	}

	private static void SetLength(IEnumerable<EdmProperty> properties, ICollection<EdmProperty> keyProperties)
	{
		foreach (EdmProperty property in properties)
		{
			if (property.PropertyType.IsPrimitiveType)
			{
				if (property.PropertyType.PrimitiveType == EdmPrimitiveType.String)
				{
					SetStringDefaults(property, keyProperties.Contains(property));
				}
				if (property.PropertyType.PrimitiveType == EdmPrimitiveType.Binary)
				{
					SetBinaryDefaults(property, keyProperties.Contains(property));
				}
			}
		}
	}

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		if (associationType.Constraint == null)
		{
			return;
		}
		IEnumerable<EdmProperty> source = associationType.GetOtherEnd(associationType.Constraint.DependentEnd).EntityType.KeyProperties();
		if (source.Count() != associationType.Constraint.DependentProperties.Count)
		{
			return;
		}
		for (int i = 0; i < associationType.Constraint.DependentProperties.Count; i++)
		{
			EdmProperty edmProperty = associationType.Constraint.DependentProperties[i];
			EdmProperty edmProperty2 = source.ElementAt(i);
			if (edmProperty.PropertyType.PrimitiveType == EdmPrimitiveType.String || edmProperty.PropertyType.PrimitiveType == EdmPrimitiveType.Binary)
			{
				EdmPrimitiveTypeFacets primitiveTypeFacets = edmProperty.PropertyType.PrimitiveTypeFacets;
				EdmPrimitiveTypeFacets primitiveTypeFacets2 = edmProperty2.PropertyType.PrimitiveTypeFacets;
				primitiveTypeFacets.IsUnicode = primitiveTypeFacets2.IsUnicode;
				primitiveTypeFacets.IsFixedLength = primitiveTypeFacets2.IsFixedLength;
				primitiveTypeFacets.MaxLength = primitiveTypeFacets2.MaxLength;
				primitiveTypeFacets.IsMaxLength = primitiveTypeFacets2.IsMaxLength;
			}
		}
	}

	private static void SetStringDefaults(EdmProperty property, bool isKey)
	{
		EdmPrimitiveTypeFacets primitiveTypeFacets = property.PropertyType.PrimitiveTypeFacets;
		if (!primitiveTypeFacets.IsUnicode.HasValue)
		{
			primitiveTypeFacets.IsUnicode = true;
		}
		SetBinaryDefaults(property, isKey);
	}

	private static void SetBinaryDefaults(EdmProperty property, bool isKey)
	{
		EdmPrimitiveTypeFacets primitiveTypeFacets = property.PropertyType.PrimitiveTypeFacets;
		if (!primitiveTypeFacets.IsFixedLength.HasValue)
		{
			primitiveTypeFacets.IsFixedLength = false;
		}
		if (!primitiveTypeFacets.MaxLength.HasValue && !primitiveTypeFacets.IsMaxLength.HasValue)
		{
			if (isKey || primitiveTypeFacets.IsFixedLength == true)
			{
				primitiveTypeFacets.MaxLength = 128;
			}
			else
			{
				primitiveTypeFacets.IsMaxLength = true;
			}
		}
	}
}

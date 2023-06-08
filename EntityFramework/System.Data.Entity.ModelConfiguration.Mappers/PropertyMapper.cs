using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Mappers;

internal sealed class PropertyMapper
{
	private readonly TypeMapper _typeMapper;

	public PropertyMapper(TypeMapper typeMapper)
	{
		_typeMapper = typeMapper;
	}

	public void Map(PropertyInfo propertyInfo, EdmComplexType complexType, Func<ComplexTypeConfiguration> complexTypeConfiguration)
	{
		bool discoverComplexTypes = true;
		EdmProperty edmProperty = MapPrimitiveOrComplexProperty(propertyInfo, complexTypeConfiguration, discoverComplexTypes);
		if (edmProperty != null)
		{
			complexType.DeclaredProperties.Add(edmProperty);
		}
	}

	public void Map(PropertyInfo propertyInfo, EdmEntityType entityType, Func<EntityTypeConfiguration> entityTypeConfiguration, Type sourceType)
	{
		EdmProperty edmProperty = MapPrimitiveOrComplexProperty(propertyInfo, entityTypeConfiguration);
		if (edmProperty != null)
		{
			entityType.DeclaredProperties.Add(edmProperty);
		}
		else
		{
			new NavigationPropertyMapper(_typeMapper).Map(propertyInfo, entityType, entityTypeConfiguration, sourceType);
		}
	}

	private EdmProperty MapPrimitiveOrComplexProperty(PropertyInfo propertyInfo, Func<StructuralTypeConfiguration> structuralTypeConfiguration, bool discoverComplexTypes = false)
	{
		Type propertyType = propertyInfo.PropertyType;
		EdmProperty edmProperty = propertyInfo.AsEdmPrimitiveProperty();
		if (edmProperty == null)
		{
			EdmComplexType edmComplexType = _typeMapper.MapComplexType(propertyType, discoverComplexTypes);
			if (edmComplexType != null)
			{
				EdmProperty edmProperty2 = new EdmProperty();
				edmProperty2.Name = propertyInfo.Name;
				edmProperty = edmProperty2.AsComplex(edmComplexType);
			}
		}
		if (edmProperty != null)
		{
			edmProperty.SetClrPropertyInfo(propertyInfo);
			new AttributeMapper(_typeMapper.MappingContext.AttributeProvider).Map(propertyInfo, edmProperty.Annotations);
			if (!edmProperty.PropertyType.IsComplexType)
			{
				_typeMapper.MappingContext.ConventionsConfiguration.ApplyPropertyConfiguration(propertyInfo, () => structuralTypeConfiguration().Property(new PropertyPath(propertyInfo)));
			}
		}
		return edmProperty;
	}
}

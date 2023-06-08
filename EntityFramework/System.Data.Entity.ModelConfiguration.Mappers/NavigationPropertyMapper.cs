using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Mappers;

/// <summary>
///     Handles mapping from a CLR property to an EDM assocation and nav. prop.
/// </summary>
internal sealed class NavigationPropertyMapper
{
	private readonly TypeMapper _typeMapper;

	public NavigationPropertyMapper(TypeMapper typeMapper)
	{
		_typeMapper = typeMapper;
	}

	public void Map(PropertyInfo propertyInfo, EdmEntityType entityType, Func<EntityTypeConfiguration> entityTypeConfiguration, Type sourceType)
	{
		Type elementType = propertyInfo.PropertyType;
		EdmAssociationEndKind edmAssociationEndKind = EdmAssociationEndKind.Optional;
		if (elementType.IsCollection(out elementType))
		{
			edmAssociationEndKind = EdmAssociationEndKind.Many;
		}
		EdmEntityType edmEntityType = _typeMapper.MapEntityType(elementType);
		if (edmEntityType != null)
		{
			EdmAssociationEndKind sourceAssociationEndKind = ((!edmAssociationEndKind.IsMany()) ? EdmAssociationEndKind.Many : EdmAssociationEndKind.Optional);
			EdmAssociationType edmAssociationType = _typeMapper.MappingContext.Model.AddAssociationType(entityType.Name + "_" + propertyInfo.Name, entityType, sourceAssociationEndKind, edmEntityType, edmAssociationEndKind);
			_typeMapper.MappingContext.Model.AddAssociationSet(edmAssociationType.Name, edmAssociationType);
			EdmNavigationProperty edmNavigationProperty = entityType.AddNavigationProperty(propertyInfo.Name, edmAssociationType);
			edmNavigationProperty.SetClrPropertyInfo(propertyInfo);
			_typeMapper.MappingContext.ConventionsConfiguration.ApplyPropertyConfiguration(propertyInfo, () => entityTypeConfiguration().Navigation(propertyInfo));
			new AttributeMapper(_typeMapper.MappingContext.AttributeProvider).Map(propertyInfo, edmNavigationProperty.Annotations);
		}
	}
}

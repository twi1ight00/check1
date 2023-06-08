using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Mappers;

internal sealed class TypeMapper
{
	private readonly MappingContext _mappingContext;

	private readonly List<Type> _knownTypes = new List<Type>();

	public MappingContext MappingContext => _mappingContext;

	public TypeMapper(MappingContext mappingContext)
	{
		_mappingContext = mappingContext;
		_knownTypes.AddRange(mappingContext.ModelConfiguration.ConfiguredTypes.Select((Type t) => t.Assembly).Distinct().SelectMany((Assembly a) => from type in a.GetTypes()
			where type.IsValidStructuralType()
			select type));
	}

	public EdmComplexType MapComplexType(Type type, bool discoverNested = false)
	{
		if (!type.IsValidStructuralType())
		{
			return null;
		}
		_mappingContext.ConventionsConfiguration.ApplyModelConfiguration(type, _mappingContext.ModelConfiguration);
		if (_mappingContext.ModelConfiguration.IsIgnoredType(type) || (!discoverNested && !_mappingContext.ModelConfiguration.IsComplexType(type)))
		{
			return null;
		}
		EdmComplexType complexType = _mappingContext.Model.GetComplexType(type.Name);
		if (complexType == null)
		{
			complexType = _mappingContext.Model.AddComplexType(type.Name);
			Func<ComplexTypeConfiguration> complexTypeConfiguration = () => _mappingContext.ModelConfiguration.ComplexType(type);
			_mappingContext.ConventionsConfiguration.ApplyTypeConfiguration(type, complexTypeConfiguration);
			MapStructuralElements(type, complexType.Annotations, delegate(PropertyMapper m, PropertyInfo p)
			{
				m.Map(p, complexType, complexTypeConfiguration);
			}, mapDeclaredPropertiesOnly: false, complexTypeConfiguration);
		}
		else if (type != complexType.GetClrType())
		{
			return null;
		}
		return complexType;
	}

	public EdmEntityType MapEntityType(Type type)
	{
		if (!type.IsValidStructuralType())
		{
			return null;
		}
		_mappingContext.ConventionsConfiguration.ApplyModelConfiguration(type, _mappingContext.ModelConfiguration);
		if (_mappingContext.ModelConfiguration.IsIgnoredType(type) || _mappingContext.ModelConfiguration.IsComplexType(type))
		{
			return null;
		}
		EdmEntityType entityType = _mappingContext.Model.GetEntityType(type.Name);
		if (entityType == null)
		{
			entityType = _mappingContext.Model.AddEntityType(type.Name);
			entityType.IsAbstract = type.IsAbstract;
			entityType.BaseType = _mappingContext.Model.GetEntityType(type.BaseType.Name);
			if (entityType.BaseType == null)
			{
				_mappingContext.Model.AddEntitySet(entityType.Name, entityType);
			}
			Func<EntityTypeConfiguration> entityTypeConfiguration = () => _mappingContext.ModelConfiguration.Entity(type);
			_mappingContext.ConventionsConfiguration.ApplyTypeConfiguration(type, entityTypeConfiguration);
			MapStructuralElements(type, entityType.Annotations, delegate(PropertyMapper m, PropertyInfo p)
			{
				m.Map(p, entityType, entityTypeConfiguration, type);
			}, entityType.BaseType != null, entityTypeConfiguration);
			if (entityType.BaseType != null)
			{
				LiftDeclaredProperties(type, entityType);
			}
			MapDerivedTypes(type, entityType);
		}
		else if (type != entityType.GetClrType())
		{
			return null;
		}
		return entityType;
	}

	private void MapStructuralElements<TStructuralTypeConfiguration>(Type type, ICollection<DataModelAnnotation> annotations, Action<PropertyMapper, PropertyInfo> propertyMappingAction, bool mapDeclaredPropertiesOnly, Func<TStructuralTypeConfiguration> structuralTypeConfiguration) where TStructuralTypeConfiguration : StructuralTypeConfiguration
	{
		annotations.SetClrType(type);
		new AttributeMapper(_mappingContext.AttributeProvider).Map(type, annotations);
		PropertyMapper arg = new PropertyMapper(this);
		foreach (PropertyInfo property in new PropertyFilter().GetProperties(type, mapDeclaredPropertiesOnly, _mappingContext.ModelConfiguration.GetConfiguredProperties(type), _mappingContext.ModelConfiguration.StructuralTypes))
		{
			_mappingContext.ConventionsConfiguration.ApplyPropertyConfiguration(property, _mappingContext.ModelConfiguration);
			_mappingContext.ConventionsConfiguration.ApplyPropertyTypeConfiguration(property, structuralTypeConfiguration);
			if (!_mappingContext.ModelConfiguration.IsIgnoredProperty(type, property))
			{
				propertyMappingAction(arg, property);
			}
		}
	}

	private void MapDerivedTypes(Type type, EdmEntityType entityType)
	{
		if (type.IsSealed)
		{
			return;
		}
		if (!_knownTypes.Contains(type))
		{
			_knownTypes.AddRange(from t in type.Assembly.GetTypes()
				where t.IsValidStructuralType()
				select t);
		}
		foreach (Type item in _knownTypes.Where((Type t) => t.BaseType == type).ToList())
		{
			EdmEntityType edmEntityType = MapEntityType(item);
			if (edmEntityType != null)
			{
				edmEntityType.BaseType = entityType;
				LiftDerivedType(item, edmEntityType, entityType);
			}
		}
	}

	private void LiftDerivedType(Type derivedType, EdmEntityType derivedEntityType, EdmEntityType entityType)
	{
		_mappingContext.Model.ReplaceEntitySet(derivedEntityType, _mappingContext.Model.GetEntitySet(entityType));
		LiftDeclaredProperties(derivedType, derivedEntityType);
	}

	private void LiftDeclaredProperties(Type type, EdmEntityType entityType)
	{
		EntityTypeConfiguration entityTypeConfiguration = _mappingContext.ModelConfiguration.GetStructuralTypeConfiguration(type) as EntityTypeConfiguration;
		entityTypeConfiguration?.ClearKey();
		LiftDeclaredProperties(type, entityType.DeclaredKeyProperties, entityTypeConfiguration);
		LiftDeclaredProperties(type, entityType.DeclaredProperties, entityTypeConfiguration);
		LiftDeclaredProperties(type, entityType.DeclaredNavigationProperties, entityTypeConfiguration);
	}

	private void LiftDeclaredProperties<TProperty>(Type type, IList<TProperty> properties, EntityTypeConfiguration entityTypeConfiguration) where TProperty : EdmStructuralMember
	{
		for (int num = properties.Count - 1; num >= 0; num--)
		{
			TProperty val = properties[num];
			PropertyInfo clrPropertyInfo = val.GetClrPropertyInfo();
			Type declaringType = clrPropertyInfo.DeclaringType;
			if (declaringType != type)
			{
				if (val is EdmNavigationProperty edmNavigationProperty)
				{
					_mappingContext.Model.RemoveAssociationType(edmNavigationProperty.Association);
				}
				properties.RemoveAt(num);
				entityTypeConfiguration?.RemoveProperty(new PropertyPath(clrPropertyInfo));
			}
		}
	}
}

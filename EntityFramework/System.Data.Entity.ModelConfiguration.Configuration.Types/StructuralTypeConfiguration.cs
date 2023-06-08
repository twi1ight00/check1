using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration.Types;

internal abstract class StructuralTypeConfiguration : ConfigurationBase
{
	private readonly Dictionary<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration> _primitivePropertyConfigurations = new Dictionary<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>();

	private readonly HashSet<PropertyInfo> _ignoredProperties = new HashSet<PropertyInfo>();

	private readonly Type _clrType;

	internal virtual IEnumerable<PropertyInfo> ConfiguredProperties => _primitivePropertyConfigurations.Keys.Select((PropertyPath p) => p.Last());

	internal IEnumerable<PropertyInfo> IgnoredProperties => _ignoredProperties;

	internal Type ClrType => _clrType;

	internal IEnumerable<KeyValuePair<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>> PrimitivePropertyConfigurations => _primitivePropertyConfigurations;

	internal static Type GetPropertyConfigurationType(Type propertyType)
	{
		propertyType.TryUnwrapNullableType(out propertyType);
		if (propertyType == typeof(string))
		{
			return typeof(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.StringPropertyConfiguration);
		}
		if (propertyType == typeof(decimal))
		{
			return typeof(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DecimalPropertyConfiguration);
		}
		if (propertyType == typeof(DateTime) || propertyType == typeof(TimeSpan) || propertyType == typeof(DateTimeOffset))
		{
			return typeof(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration);
		}
		if (propertyType == typeof(byte[]))
		{
			return typeof(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.BinaryPropertyConfiguration);
		}
		if (!propertyType.IsValueType)
		{
			return typeof(NavigationPropertyConfiguration);
		}
		return typeof(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration);
	}

	internal StructuralTypeConfiguration()
	{
	}

	internal StructuralTypeConfiguration(Type clrType)
	{
		_clrType = clrType;
	}

	internal StructuralTypeConfiguration(StructuralTypeConfiguration source)
	{
		Dictionary<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration> primitivePropertyConfigurations = source._primitivePropertyConfigurations;
		Action<KeyValuePair<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>> action = delegate(KeyValuePair<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration> c)
		{
			_primitivePropertyConfigurations.Add(c.Key, c.Value.Clone());
		};
		primitivePropertyConfigurations.Each(action);
		_ignoredProperties.AddRange(source._ignoredProperties);
		_clrType = source._clrType;
	}

	public void Ignore(PropertyInfo propertyInfo)
	{
		_ignoredProperties.Add(propertyInfo);
	}

	internal System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration Property(PropertyPath propertyPath, OverridableConfigurationParts? overridableConfigurationParts = null)
	{
		return Property(propertyPath, delegate
		{
			System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration primitivePropertyConfiguration = (System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration)Activator.CreateInstance(GetPropertyConfigurationType(propertyPath.Last().PropertyType));
			if (overridableConfigurationParts.HasValue)
			{
				primitivePropertyConfiguration.OverridableConfigurationParts = overridableConfigurationParts.Value;
			}
			return primitivePropertyConfiguration;
		});
	}

	internal virtual void RemoveProperty(PropertyPath propertyPath)
	{
		_primitivePropertyConfigurations.Remove(propertyPath);
	}

	internal TPrimitivePropertyConfiguration Property<TPrimitivePropertyConfiguration>(PropertyPath propertyPath, Func<TPrimitivePropertyConfiguration> primitivePropertyConfigurationCreator) where TPrimitivePropertyConfiguration : System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration
	{
		if (!_primitivePropertyConfigurations.TryGetValue(propertyPath, out var value))
		{
			_primitivePropertyConfigurations.Add(propertyPath, value = primitivePropertyConfigurationCreator());
		}
		return (TPrimitivePropertyConfiguration)value;
	}

	internal void Configure(IEnumerable<Tuple<DbEdmPropertyMapping, DbTableMetadata>> propertyMappings, DbProviderManifest providerManifest, bool allowOverride = false)
	{
		foreach (KeyValuePair<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration> primitivePropertyConfiguration in PrimitivePropertyConfigurations)
		{
			PropertyPath propertyPath = primitivePropertyConfiguration.Key;
			System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration value = primitivePropertyConfiguration.Value;
			value.Configure(propertyMappings.Where((Tuple<DbEdmPropertyMapping, DbTableMetadata> pm) => propertyPath == new PropertyPath(from p in pm.Item1.PropertyPath.Skip(pm.Item1.PropertyPath.Count - propertyPath.Count)
				select p.GetClrPropertyInfo())), providerManifest, allowOverride);
		}
	}

	internal void Configure(string structuralTypeName, IEnumerable<EdmProperty> properties, ICollection<DataModelAnnotation> dataModelAnnotations)
	{
		dataModelAnnotations.SetConfiguration(this);
		foreach (KeyValuePair<PropertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration> primitivePropertyConfiguration in _primitivePropertyConfigurations)
		{
			PropertyPath key = primitivePropertyConfiguration.Key;
			System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration value = primitivePropertyConfiguration.Value;
			Configure(structuralTypeName, properties, key, value);
		}
	}

	private static void Configure(string structuralTypeName, IEnumerable<EdmProperty> properties, IEnumerable<PropertyInfo> propertyPath, System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration propertyConfiguration)
	{
		EdmProperty edmProperty = properties.SingleOrDefault((EdmProperty p) => p.GetClrPropertyInfo().IsSameAs(propertyPath.First()));
		if (edmProperty == null)
		{
			throw Error.PropertyNotFound(propertyPath.First().Name, structuralTypeName);
		}
		if (edmProperty.PropertyType.IsPrimitiveType)
		{
			propertyConfiguration.Configure(edmProperty);
		}
		else
		{
			Configure(edmProperty.PropertyType.ComplexType.Name, edmProperty.PropertyType.ComplexType.DeclaredProperties, new PropertyPath(propertyPath.Skip(1)), propertyConfiguration);
		}
	}
}

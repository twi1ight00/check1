using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Services;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Diagnostics;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Configures a discriminator column used to differentiate between types in an inheritance hierarchy.
///     This configuration functionality is available via the Code First Fluent API, see <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
[DebuggerDisplay("{Discriminator}")]
public class ValueConditionConfiguration
{
	private readonly EntityMappingConfiguration _entityMappingConfiguration;

	private System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration _configuration;

	internal string Discriminator { get; set; }

	internal object Value { get; set; }

	internal ValueConditionConfiguration(EntityMappingConfiguration entityMapConfiguration, string discriminator)
	{
		_entityMappingConfiguration = entityMapConfiguration;
		Discriminator = discriminator;
	}

	private ValueConditionConfiguration(EntityMappingConfiguration owner, ValueConditionConfiguration source)
	{
		_entityMappingConfiguration = owner;
		Discriminator = source.Discriminator;
		Value = source.Value;
		_configuration = ((source._configuration == null) ? null : source._configuration.Clone());
	}

	internal virtual ValueConditionConfiguration Clone(EntityMappingConfiguration owner)
	{
		return new ValueConditionConfiguration(owner, this);
	}

	private T GetOrCreateConfiguration<T>() where T : System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration, new()
	{
		if (_configuration == null)
		{
			_configuration = new T();
		}
		else if (!typeof(T).IsAssignableFrom(_configuration.GetType()))
		{
			T configuration = new T();
			configuration.CopyFrom(_configuration);
			_configuration = configuration;
		}
		_configuration.OverridableConfigurationParts = OverridableConfigurationParts.None;
		return (T)_configuration;
	}

	/// <summary>
	///     Configures the discriminator value used to identify the entity type being 
	///     configured from other types in the inheritance hierarchy.
	/// </summary>
	/// <typeparam name="T">Type of the discriminator value.</typeparam>
	/// <param name="value">The value to be used to identify the entity type.</param>
	/// <returns>A configuration object to configure the column used to store discriminator values.</returns>
	public PrimitiveColumnConfiguration HasValue<T>(T value) where T : struct
	{
		ValidateValueType(value);
		Value = value;
		_entityMappingConfiguration.AddValueCondition(this);
		return new PrimitiveColumnConfiguration(GetOrCreateConfiguration<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>());
	}

	/// <summary>
	///     Configures the discriminator value used to identify the entity type being 
	///     configured from other types in the inheritance hierarchy.
	/// </summary>
	/// <typeparam name="T">Type of the discriminator value.</typeparam>
	/// <param name="value">The value to be used to identify the entity type.</param>
	/// <returns>A configuration object to configure the column used to store discriminator values.</returns>
	public PrimitiveColumnConfiguration HasValue<T>(T? value) where T : struct
	{
		ValidateValueType(value);
		Value = value;
		_entityMappingConfiguration.AddValueCondition(this);
		return new PrimitiveColumnConfiguration(GetOrCreateConfiguration<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>());
	}

	/// <summary>
	///     Configures the discriminator value used to identify the entity type being 
	///     configured from other types in the inheritance hierarchy.
	/// </summary>
	/// <param name="value">The value to be used to identify the entity type.</param>
	/// <returns>A configuration object to configure the column used to store discriminator values.</returns>
	public StringColumnConfiguration HasValue(string value)
	{
		Value = value;
		_entityMappingConfiguration.AddValueCondition(this);
		return new StringColumnConfiguration(GetOrCreateConfiguration<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.StringPropertyConfiguration>());
	}

	private void ValidateValueType(object value)
	{
		if (value != null && !value.GetType().IsPrimitiveType(out var _))
		{
			throw Error.InvalidDiscriminatorType(value.GetType().Name);
		}
	}

	internal static bool AnyBaseTypeToTableWithoutColumnCondition(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata table, DbTableColumnMetadata column)
	{
		for (EdmEntityType baseType = entityType.BaseType; baseType != null; baseType = baseType.BaseType)
		{
			IEnumerable<DbEntityTypeMappingFragment> source = from tmf in databaseMapping.GetEntityTypeMappings(baseType).SelectMany((DbEntityTypeMapping etm) => etm.TypeMappingFragments)
				where tmf.Table == table
				select tmf;
			if (source.Any() && !source.SelectMany((DbEntityTypeMappingFragment etmf) => etmf.ColumnConditions).Any((DbColumnCondition cc) => cc.Column == column))
			{
				return true;
			}
		}
		return false;
	}

	internal void Configure(DbDatabaseMapping databaseMapping, DbEntityTypeMappingFragment fragment, EdmEntityType entityType, DbProviderManifest providerManifest)
	{
		DbTableColumnMetadata dbTableColumnMetadata = TablePrimitiveOperations.IncludeColumn(fragment.Table, Discriminator, useExisting: true);
		if (dbTableColumnMetadata.TypeName == null)
		{
			_ = 1;
		}
		else
			_ = !string.IsNullOrWhiteSpace(dbTableColumnMetadata.TypeName);
		if (AnyBaseTypeToTableWithoutColumnCondition(databaseMapping, entityType, fragment.Table, dbTableColumnMetadata))
		{
			dbTableColumnMetadata.IsNullable = true;
		}
		System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration primitivePropertyConfiguration = dbTableColumnMetadata.GetConfiguration() as System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration;
		if (Value != null)
		{
			if ((primitivePropertyConfiguration == null || primitivePropertyConfiguration.ColumnType == null) && (_configuration == null || _configuration.ColumnType == null))
			{
				Value.GetType().IsPrimitiveType(out var primitiveType);
				string text;
				if (primitiveType == EdmPrimitiveType.String)
				{
					bool isUnicode = true;
					bool isFixedLength = false;
					int maxLength = 128;
					text = providerManifest.GetStoreType(TypeUsage.CreateStringTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.String), isUnicode, isFixedLength, maxLength)).EdmType.Name;
					dbTableColumnMetadata.Facets.MaxLength = 128;
				}
				else
				{
					text = providerManifest.GetStoreTypeName((PrimitiveTypeKind)primitiveType.PrimitiveTypeKind);
				}
				if (!string.IsNullOrWhiteSpace(dbTableColumnMetadata.TypeName) && !dbTableColumnMetadata.TypeName.Equals(text, StringComparison.OrdinalIgnoreCase))
				{
					throw Error.ConflictingInferredColumnType(dbTableColumnMetadata.Name, dbTableColumnMetadata.TypeName, text);
				}
				dbTableColumnMetadata.TypeName = text;
			}
			fragment.AddDiscriminatorCondition(dbTableColumnMetadata, Value);
		}
		else
		{
			if (string.IsNullOrWhiteSpace(dbTableColumnMetadata.TypeName))
			{
				new DatabaseMappingGenerator(providerManifest).InitializeDefaultDiscriminatorColumn(dbTableColumnMetadata);
			}
			GetOrCreateConfiguration<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>().IsNullable = true;
			fragment.AddNullabilityCondition(dbTableColumnMetadata, isNull: true);
		}
		if (_configuration == null)
		{
			return;
		}
		if (primitivePropertyConfiguration != null && (primitivePropertyConfiguration.OverridableConfigurationParts & OverridableConfigurationParts.OverridableInCSpace) != OverridableConfigurationParts.OverridableInCSpace)
		{
			bool inCSpace = true;
			if (!primitivePropertyConfiguration.IsCompatible(_configuration, inCSpace, out var errorMessage))
			{
				throw Error.ConflictingColumnConfiguration(dbTableColumnMetadata, fragment.Table, errorMessage);
			}
		}
		if (_configuration.IsNullable.HasValue)
		{
			dbTableColumnMetadata.IsNullable = _configuration.IsNullable.Value;
		}
		_configuration.Configure(dbTableColumnMetadata, fragment.Table, providerManifest);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}

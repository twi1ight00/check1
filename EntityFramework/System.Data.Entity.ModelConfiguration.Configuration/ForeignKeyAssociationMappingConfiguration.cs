using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Configures the table and column mapping of a relationship that does not expose foreign key properties in the object model.
///     This configuration functionality is available via the Code First Fluent API, see <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
public sealed class ForeignKeyAssociationMappingConfiguration : AssociationMappingConfiguration
{
	private readonly List<string> _keyColumnNames = new List<string>();

	private DatabaseName _tableName;

	internal ForeignKeyAssociationMappingConfiguration()
	{
	}

	private ForeignKeyAssociationMappingConfiguration(ForeignKeyAssociationMappingConfiguration source)
	{
		_keyColumnNames.AddRange(source._keyColumnNames);
		_tableName = source._tableName;
	}

	internal override AssociationMappingConfiguration Clone()
	{
		return new ForeignKeyAssociationMappingConfiguration(this);
	}

	/// <summary>
	///     Configures the name of the column(s) for the foreign key.
	/// </summary>
	/// <param name="keyColumnNames">
	///     The foreign key column names.
	///     When using multiple foreign key properties, the properties must be specified in the same order that the
	///     the primary key properties were configured for the target entity type.
	/// </param>
	/// <returns>The same ForeignKeyAssociationMappingConfiguration instance so that multiple calls can be chained.</returns>
	public ForeignKeyAssociationMappingConfiguration MapKey(params string[] keyColumnNames)
	{
		RuntimeFailureMethods.Requires(keyColumnNames != null, null, "keyColumnNames != null");
		_keyColumnNames.Clear();
		_keyColumnNames.AddRange(keyColumnNames);
		return this;
	}

	/// <summary>
	///     Configures the table name that the foreign key column(s) reside in.
	///     The table that is specified must already be mapped for the entity type.
	///
	///     If you want the foreign key(s) to reside in their own table then use the Map method
	///     on <see cref="T:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration" /> to perform 
	///     entity splitting to create the table with just the primary key property. Foreign keys can 
	///     then be added to the table via this method.
	/// </summary>
	/// <param name="tableName">Name of the table.</param>
	/// <returns>The same ForeignKeyAssociationMappingConfiguration instance so that multiple calls can be chained.</returns>
	public ForeignKeyAssociationMappingConfiguration ToTable(string tableName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(tableName), null, "!string.IsNullOrWhiteSpace(tableName)");
		return ToTable(tableName, null);
	}

	/// <summary>
	///     Configures the table name and schema that the foreign key column(s) reside in.
	///     The table that is specified must already be mapped for the entity type.
	///
	///     If you want the foreign key(s) to reside in their own table then use the Map method
	///     on <see cref="T:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration" /> to perform 
	///     entity splitting to create the table with just the primary key property. Foreign keys can 
	///     then be added to the table via this method.
	/// </summary>
	/// <param name="tableName">Name of the table.</param>
	/// <param name="schemaName">Schema of the table.</param>
	/// <returns>The same ForeignKeyAssociationMappingConfiguration instance so that multiple calls can be chained.</returns>
	public ForeignKeyAssociationMappingConfiguration ToTable(string tableName, string schemaName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(tableName), null, "!string.IsNullOrWhiteSpace(tableName)");
		_tableName = new DatabaseName(tableName, schemaName);
		return this;
	}

	internal override void Configure(DbAssociationSetMapping associationSetMapping, DbDatabaseMetadata database)
	{
		IList<DbEdmPropertyMapping> propertyMappings = associationSetMapping.SourceEndMapping.PropertyMappings;
		if (_tableName != null)
		{
			DbTableMetadata targetTable = (from t in database.Schemas.Single().Tables
				let n = t.GetTableName()
				where n != null && n.Equals(_tableName)
				select t).SingleOrDefault() ?? database.Schemas.Single().Tables.SingleOrDefault((DbTableMetadata t) => string.Equals(t.DatabaseIdentifier, _tableName.Name, StringComparison.Ordinal));
			if (targetTable == null)
			{
				throw Error.TableNotFound(_tableName);
			}
			DbTableMetadata sourceTable = associationSetMapping.Table;
			if (sourceTable != targetTable)
			{
				DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata = sourceTable.ForeignKeyConstraints.Single((DbForeignKeyConstraintMetadata fk) => fk.DependentColumns.SequenceEqual(propertyMappings.Select((DbEdmPropertyMapping pm) => pm.Column)));
				sourceTable.ForeignKeyConstraints.Remove(dbForeignKeyConstraintMetadata);
				targetTable.ForeignKeyConstraints.Add(dbForeignKeyConstraintMetadata);
				dbForeignKeyConstraintMetadata.DependentColumns.Each(delegate(DbTableColumnMetadata c)
				{
					sourceTable.Columns.Remove(c);
					targetTable.Columns.Add(c);
				});
				associationSetMapping.Table = targetTable;
			}
		}
		if (_keyColumnNames.Count > 0 && _keyColumnNames.Count != propertyMappings.Count)
		{
			throw Error.IncorrectColumnCount(string.Join(", ", _keyColumnNames));
		}
		_keyColumnNames.Each(delegate(string n, int i)
		{
			propertyMappings[i].Column.Name = n;
		});
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool Equals(ForeignKeyAssociationMappingConfiguration other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (!object.Equals(other._tableName, _tableName))
		{
			return false;
		}
		return other._keyColumnNames.SequenceEqual(_keyColumnNames);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(ForeignKeyAssociationMappingConfiguration))
		{
			return false;
		}
		return Equals((ForeignKeyAssociationMappingConfiguration)obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return (((_tableName != null) ? _tableName.GetHashCode() : 0) * 397) ^ _keyColumnNames.Aggregate(0, (int t, string n) => t + n.GetHashCode());
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}

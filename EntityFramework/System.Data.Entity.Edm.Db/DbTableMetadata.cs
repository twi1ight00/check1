using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Diagnostics;
using System.Linq;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Allows the construction and modification a table in a <see cref="T:System.Data.Entity.Edm.Db.DbSchemaMetadata" /> database schema.
/// </summary>
[DebuggerDisplay("{Name}")]
internal class DbTableMetadata : DbSchemaMetadataItem
{
	private readonly BackingList<DbTableColumnMetadata> columnsList = new BackingList<DbTableColumnMetadata>();

	private readonly BackingList<DbForeignKeyConstraintMetadata> fkConstraintsList = new BackingList<DbForeignKeyConstraintMetadata>();

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.DbTableColumnMetadata" /> instances that specifies the columns present within the table.
	/// </summary>
	public virtual IList<DbTableColumnMetadata> Columns
	{
		get
		{
			return columnsList.EnsureValue();
		}
		set
		{
			columnsList.SetValue(value);
		}
	}

	internal bool HasColumns => columnsList.HasValue;

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.DbTableColumnMetadata" /> instances from the <see cref="P:System.Data.Entity.Edm.Db.DbTableMetadata.Columns" /> collection of the table that are part of the primary key.
	/// </summary>
	public IEnumerable<DbTableColumnMetadata> KeyColumns => Columns.Where((DbTableColumnMetadata c) => c?.IsPrimaryKeyColumn ?? false);

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.DbForeignKeyConstraintMetadata" /> instances that defines the foreign key constraints sourced from the table.
	/// </summary>
	public virtual IList<DbForeignKeyConstraintMetadata> ForeignKeyConstraints
	{
		get
		{
			return fkConstraintsList.EnsureValue();
		}
		set
		{
			fkConstraintsList.SetValue(value);
		}
	}

	internal bool HasForeignKeyConstraints => fkConstraintsList.HasValue;

	internal override DbItemKind GetMetadataKind()
	{
		return DbItemKind.Table;
	}
}

using System.Diagnostics;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Allows the construction and modification of a column in a <see cref="T:System.Data.Entity.Edm.Db.DbTableMetadata" /> table.
/// </summary>
[DebuggerDisplay("{Name}")]
internal class DbTableColumnMetadata : DbColumnMetadata
{
	/// <summary>
	///     Gets or sets a value indicating whether the column is part of the table's primary key.
	/// </summary>
	public virtual bool IsPrimaryKeyColumn { get; set; }

	/// <summary>
	///     Gets or sets a <see cref="T:System.Data.Entity.Edm.Db.DbStoreGeneratedPattern" /> value indicating if and how the value of the column is automatically generated.
	/// </summary>
	public virtual DbStoreGeneratedPattern StoreGeneratedPattern { get; set; }

	/// <summary>
	///     Gets or sets an optional value indicating the collation specific to this table column.
	/// </summary>
	public virtual string Collation { get; set; }

	/// <summary>
	///     Gets or sets an optional value that specifies the default value for the column.
	/// </summary>
	public virtual object DefaultValue { get; set; }

	internal override DbItemKind GetMetadataKind()
	{
		return DbItemKind.TableColumn;
	}
}

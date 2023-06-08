using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Allows the construction and modification of a foreign key constraint sourced by a <see cref="T:System.Data.Entity.Edm.Db.DbTableMetadata" /> instance.
/// </summary>
internal class DbForeignKeyConstraintMetadata : DbConstraintMetadata
{
	private readonly BackingList<DbTableColumnMetadata> dependentColumnsList = new BackingList<DbTableColumnMetadata>();

	public virtual DbTableMetadata PrincipalTable { get; set; }

	public virtual IList<DbTableColumnMetadata> DependentColumns
	{
		get
		{
			return dependentColumnsList.EnsureValue();
		}
		set
		{
			dependentColumnsList.SetValue(value);
		}
	}

	internal bool HasDependentColumns => dependentColumnsList.HasValue;

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.Db.DbOperationAction" /> to take when a delete operation is attempted.
	/// </summary>
	public virtual DbOperationAction DeleteAction { get; set; }

	internal override DbItemKind GetMetadataKind()
	{
		return DbItemKind.ForeignKeyConstraint;
	}
}

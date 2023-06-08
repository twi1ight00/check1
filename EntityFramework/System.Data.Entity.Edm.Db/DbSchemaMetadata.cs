using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Allows the construction and modification of a database schema in a <see cref="T:System.Data.Entity.Edm.Db.DbDatabaseMetadata" /> database model.
/// </summary>
internal class DbSchemaMetadata : DbAliasedMetadataItem
{
	private readonly BackingList<DbTableMetadata> tablesList = new BackingList<DbTableMetadata>();

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.DbTableMetadata" /> instances that specifies the tables declared within the schema.
	/// </summary>
	public virtual IList<DbTableMetadata> Tables
	{
		get
		{
			return tablesList.EnsureValue();
		}
		set
		{
			tablesList.SetValue(value);
		}
	}

	internal bool HasTables => tablesList.HasValue;

	internal override DbItemKind GetMetadataKind()
	{
		return DbItemKind.Schema;
	}
}

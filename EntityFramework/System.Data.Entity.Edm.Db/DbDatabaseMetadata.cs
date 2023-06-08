using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Allows the construction and modification of a database in a Database Metadata model.
/// </summary>
internal class DbDatabaseMetadata : DbAliasedMetadataItem
{
	private readonly BackingList<DbSchemaMetadata> schemasList = new BackingList<DbSchemaMetadata>();

	/// <summary>
	///     Gets or sets an optional value that indicates the database model version.
	/// </summary>
	public virtual double Version { get; set; }

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.DbSchemaMetadata" /> instances that specifies the schemas within the database.
	/// </summary>
	public virtual IList<DbSchemaMetadata> Schemas
	{
		get
		{
			return schemasList.EnsureValue();
		}
		set
		{
			schemasList.SetValue(value);
		}
	}

	internal bool HasSchemas => schemasList.HasValue;

	internal override DbItemKind GetMetadataKind()
	{
		return DbItemKind.Database;
	}
}

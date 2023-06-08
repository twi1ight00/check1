namespace System.Data.Entity.Edm.Db;

/// <summary>
///     DbAliasedMetadataItem provides the base type for all Database Metadata types that can have an optional <see cref="P:System.Data.Entity.Edm.Db.DbAliasedMetadataItem.DatabaseIdentifier" /> that should be used instead of the item's <see cref="P:System.Data.Entity.Edm.Db.DbNamedMetadataItem.Name" /> when referring to the item in the database.
/// </summary>
internal abstract class DbAliasedMetadataItem : DbNamedMetadataItem
{
	/// <summary>
	///     Gets an optional alternative identifier that should be used when referring to this item in the database.
	/// </summary>
	public virtual string DatabaseIdentifier { get; set; }
}

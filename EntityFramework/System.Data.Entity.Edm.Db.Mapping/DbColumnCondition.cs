namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     Allows the construction and modification of a condition for a column in a database table.
/// </summary>
internal class DbColumnCondition : DbMappingMetadataItem
{
	/// <summary>
	///     Gets or sets a <see cref="T:System.Data.Entity.Edm.Db.DbTableColumnMetadata" /> value representing the table column which must contain <see cref="P:System.Data.Entity.Edm.Db.Mapping.DbColumnCondition.Value" /> for this condition to hold.
	/// </summary>
	public virtual DbTableColumnMetadata Column { get; set; }

	/// <summary>
	///     Gets or sets the value that <see cref="P:System.Data.Entity.Edm.Db.Mapping.DbColumnCondition.Column" /> must contain for this condition to hold.
	/// </summary>
	public virtual object Value { get; set; }

	public virtual bool? IsNull { get; set; }

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.ColumnCondition;
	}
}

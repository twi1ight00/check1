using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     NamedDbItem is the base for all types in the Database Metadata construction and modification API with a <see cref="P:System.Data.Entity.Edm.Db.DbNamedMetadataItem.Name" /> property.
/// </summary>
internal abstract class DbNamedMetadataItem : DbMetadataItem, INamedDataModelItem
{
	/// <summary>
	///     Gets or sets the currently assigned name.
	/// </summary>
	public virtual string Name { get; set; }
}

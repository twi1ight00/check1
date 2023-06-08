using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     Allows the construction and modification of the mapping of an EDM entity set ( <see cref="T:System.Data.Entity.Edm.EdmEntitySet" /> ) to a database ( <see cref="T:System.Data.Entity.Edm.Db.DbDatabaseMetadata" /> ).
/// </summary>
internal class DbEntitySetMapping : DbMappingMetadataItem
{
	private readonly BackingList<DbEntityTypeMapping> entityTypeMappingsList = new BackingList<DbEntityTypeMapping>();

	/// <summary>
	///     Gets or sets an <see cref="T:System.Data.Entity.Edm.EdmEntitySet" /> value representing the entity set that is being mapped.
	/// </summary>
	public virtual EdmEntitySet EntitySet { get; set; }

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.Mapping.DbEntityTypeMapping" /> s that specifies how the set's entity types are mapped to the database.
	/// </summary>
	public virtual IList<DbEntityTypeMapping> EntityTypeMappings
	{
		get
		{
			return entityTypeMappingsList.EnsureValue();
		}
		set
		{
			entityTypeMappingsList.SetValue(value);
		}
	}

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.EntitySetMapping;
	}
}

using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

internal class DbDatabaseMapping : DbMappingMetadataItem
{
	private readonly BackingList<DbEntityContainerMapping> entityContainerMappingsList = new BackingList<DbEntityContainerMapping>();

	/// <summary>
	///     Gets or sets an <see cref="T:System.Data.Entity.Edm.EdmModel" /> value representing the model that is being mapped.
	/// </summary>
	internal virtual EdmModel Model { get; set; }

	/// <summary>
	///     Gets or sets a <see cref="T:System.Data.Entity.Edm.Db.DbDatabaseMetadata" /> value representing the database that is the target of the mapping.
	/// </summary>
	internal virtual DbDatabaseMetadata Database { get; set; }

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.Db.Mapping.DbEntityContainerMapping" /> s that specifies how the model's entity containers are mapped to the database.
	/// </summary>
	internal virtual IList<DbEntityContainerMapping> EntityContainerMappings
	{
		get
		{
			return entityContainerMappingsList.EnsureValue();
		}
		set
		{
			entityContainerMappingsList.SetValue(value);
		}
	}

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.DatabaseMapping;
	}
}

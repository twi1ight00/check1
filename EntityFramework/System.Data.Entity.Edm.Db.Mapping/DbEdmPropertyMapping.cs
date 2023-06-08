using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     Represents the mapping of an entity property to a column in a database table.
/// </summary>
internal class DbEdmPropertyMapping : DbMappingMetadataItem
{
	private readonly BackingList<EdmProperty> propertyPathList = new BackingList<EdmProperty>();

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmProperty" /> instances that defines the mapped property, beginning from a property declared by the mapped entity type and optionally proceeding through properties of complex property result types.
	/// </summary>
	public virtual IList<EdmProperty> PropertyPath
	{
		get
		{
			return propertyPathList.EnsureValue();
		}
		set
		{
			propertyPathList.SetValue(value);
		}
	}

	/// <summary>
	///     Gets or sets a <see cref="T:System.Data.Entity.Edm.Db.DbTableColumnMetadata" /> value representing the table column to which the entity property is being mapped.
	/// </summary>
	public virtual DbTableColumnMetadata Column { get; set; }

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.EdmPropertyMapping;
	}
}

using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     Represents the mapping of an EDM association end ( <see cref="T:System.Data.Entity.Edm.EdmAssociationEnd" /> ) as a collection of property mappings ( <see cref="T:System.Data.Entity.Edm.Db.Mapping.DbEdmPropertyMapping" /> ).
/// </summary>
internal class DbAssociationEndMapping : DbMappingMetadataItem
{
	private readonly BackingList<DbEdmPropertyMapping> propertyMappings = new BackingList<DbEdmPropertyMapping>();

	/// <summary>
	///     Gets an <see cref="T:System.Data.Entity.Edm.EdmAssociationEnd" /> value representing the association end that is being mapped.
	/// </summary>
	public virtual EdmAssociationEnd AssociationEnd { get; set; }

	/// <summary>
	///     Gets the collection of <see cref="T:System.Data.Entity.Edm.Db.Mapping.DbEdmPropertyMapping" /> s that specifies how the association end key properties are mapped to the table.
	/// </summary>
	public virtual IList<DbEdmPropertyMapping> PropertyMappings
	{
		get
		{
			return propertyMappings.EnsureValue();
		}
		set
		{
			propertyMappings.SetValue(value);
		}
	}

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.AssociationEndMapping;
	}
}

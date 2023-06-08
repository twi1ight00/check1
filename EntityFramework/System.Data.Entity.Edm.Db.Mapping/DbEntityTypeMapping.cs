using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     Allows the construction and modification of a complete or partial mapping of an EDM entity type ( <see cref="T:System.Data.Entity.Edm.EdmEntityType" /> ) or type hierarchy to a specific database table ( <see cref="T:System.Data.Entity.Edm.Db.DbTableMetadata" /> ).
/// </summary>
internal class DbEntityTypeMapping : DbMappingMetadataItem
{
	private readonly BackingList<DbEntityTypeMappingFragment> typeMappingFragments = new BackingList<DbEntityTypeMappingFragment>();

	/// <summary>
	///     Gets or sets an <see cref="T:System.Data.Entity.Edm.EdmEntityType" /> value representing the entity type or hierarchy that is being mapped.
	/// </summary>
	public virtual EdmEntityType EntityType { get; set; }

	/// <summary>
	///     Gets or sets a value indicating whether this type mapping applies to <see cref="P:System.Data.Entity.Edm.Db.Mapping.DbEntityTypeMapping.EntityType" /> and all its direct or indirect subtypes ( <code>true</code> ), or only to <see cref="P:System.Data.Entity.Edm.Db.Mapping.DbEntityTypeMapping.EntityType" /> ( <code>false</code> ).
	/// </summary>
	public virtual bool IsHierarchyMapping { get; set; }

	public virtual IList<DbEntityTypeMappingFragment> TypeMappingFragments
	{
		get
		{
			return typeMappingFragments.EnsureValue();
		}
		set
		{
			typeMappingFragments.SetValue(value);
		}
	}

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.EntityTypeMapping;
	}
}

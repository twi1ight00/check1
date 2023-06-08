using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

internal class DbAssociationSetMapping : DbMappingMetadataItem
{
	private readonly BackingList<DbColumnCondition> columnConditions = new BackingList<DbColumnCondition>();

	/// <summary>
	///     Gets an <see cref="T:System.Data.Entity.Edm.EdmAssociationSet" /> value representing the association set that is being mapped.
	/// </summary>
	public virtual EdmAssociationSet AssociationSet { get; set; }

	/// <summary>
	///     Gets a <see cref="T:System.Data.Entity.Edm.Db.DbTableMetadata" /> value representing the table to which the entity type's properties are being mapped.
	/// </summary>
	public virtual DbTableMetadata Table { get; set; }

	public virtual DbAssociationEndMapping SourceEndMapping { get; set; }

	public virtual DbAssociationEndMapping TargetEndMapping { get; set; }

	/// <summary>
	///     Gets the collection of <see cref="T:System.Data.Entity.Edm.Db.Mapping.DbColumnCondition" /> s that specifies the constant or null values that columns in <see cref="P:System.Data.Entity.Edm.Db.Mapping.DbAssociationSetMapping.Table" /> must have for this type mapping to apply.
	/// </summary>
	public virtual IList<DbColumnCondition> ColumnConditions
	{
		get
		{
			return columnConditions.EnsureValue();
		}
		set
		{
			columnConditions.SetValue(value);
		}
	}

	internal override DbMappingItemKind GetItemKind()
	{
		return DbMappingItemKind.AssociationSetMapping;
	}
}

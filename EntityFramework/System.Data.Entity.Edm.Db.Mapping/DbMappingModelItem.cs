using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     DbMappingModelItem is the base for all types in the EDM-to-Database Mapping construction and modification API.
/// </summary>
internal abstract class DbMappingModelItem : DataModelItem
{
	internal abstract DbMappingItemKind GetItemKind();
}

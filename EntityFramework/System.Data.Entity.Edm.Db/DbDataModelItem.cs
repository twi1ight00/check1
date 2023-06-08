using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     DbDataModelItem is the base for all types in the Database Metadata construction and modification API.
/// </summary>
internal abstract class DbDataModelItem : DataModelItem
{
	internal abstract DbItemKind GetMetadataKind();
}

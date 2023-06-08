using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm;

/// <summary>
///     EdmDataModelItem is the base for all types in the Entity Data Model (EDM) metadata construction and modification API.
/// </summary>
internal abstract class EdmDataModelItem : DataModelItem
{
	/// <summary>
	///     Gets an <see cref="T:System.Data.Entity.Edm.EdmItemKind" /> value indicating which Entity Data Model (EDM) concept is represented by this item.
	/// </summary>
	public EdmItemKind ItemKind => GetItemKind();

	internal abstract EdmItemKind GetItemKind();
}

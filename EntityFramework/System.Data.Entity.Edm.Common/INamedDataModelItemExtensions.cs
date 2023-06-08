using System.Collections.Generic;

namespace System.Data.Entity.Edm.Common;

internal static class INamedDataModelItemExtensions
{
	public static bool TryGetByName<TNamedItem>(this IEnumerable<TNamedItem> list, string itemName, out TNamedItem result) where TNamedItem : INamedDataModelItem
	{
		foreach (TNamedItem item in list)
		{
			if (item != null && string.Equals(item.Name, itemName, StringComparison.Ordinal))
			{
				result = item;
				return true;
			}
		}
		result = default(TNamedItem);
		return false;
	}
}

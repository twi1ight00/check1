using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Common;

internal static class INamedDataModelItemExtensions
{
	public static string UniquifyName(this IEnumerable<INamedDataModelItem> namedDataModelItems, string name)
	{
		string uniqueName = name;
		int num = 0;
		while (namedDataModelItems.Any((INamedDataModelItem n) => string.Equals(n.Name, uniqueName, StringComparison.Ordinal)))
		{
			uniqueName = name + ++num;
		}
		return uniqueName;
	}
}

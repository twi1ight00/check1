using System.Collections.Generic;
using System.Data.Entity.Edm.Db;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Db;

internal static class DbAliasedMetadataItemExtensions
{
	public static string UniquifyIdentifier(this IEnumerable<DbAliasedMetadataItem> aliasedMetadataItems, string identifier)
	{
		string uniqueIdentifier = identifier;
		int num = 0;
		while (aliasedMetadataItems.Any((DbAliasedMetadataItem n) => string.Equals(n.DatabaseIdentifier, uniqueIdentifier, StringComparison.Ordinal)))
		{
			uniqueIdentifier = identifier + ++num;
		}
		return uniqueIdentifier;
	}
}

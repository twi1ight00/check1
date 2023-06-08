using System.Collections.Generic;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class ObjectExtensions
{
	public static IEnumerable<T> AsEnumerable<T>(this T t) where T : class
	{
		if (t == null)
		{
			return Enumerable.Empty<T>();
		}
		return new T[1] { t };
	}

	public static void ParseQualifiedTableName(string qualifiedName, out string schemaName, out string tableName)
	{
		qualifiedName = qualifiedName.Trim();
		int num = qualifiedName.LastIndexOf('.');
		schemaName = null;
		tableName = qualifiedName;
		switch (num)
		{
		case 0:
			throw Error.ToTable_InvalidSchemaName(qualifiedName);
		default:
			if (num == tableName.Length - 1)
			{
				throw Error.ToTable_InvalidTableName(qualifiedName);
			}
			schemaName = qualifiedName.Substring(0, num);
			tableName = qualifiedName.Substring(num + 1);
			break;
		case -1:
			break;
		}
		if (string.IsNullOrWhiteSpace(schemaName))
		{
			schemaName = null;
		}
	}
}

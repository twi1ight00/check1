using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Model;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Infrastructure;

internal abstract class ModelDiffer
{
	public abstract IEnumerable<MigrationOperation> Diff(XDocument sourceModel, XDocument targetModel, string connectionString);

	internal static string GetQualifiedTableName(string table, string schema)
	{
		if (GetStandardizedSchemaName(schema) == null)
		{
			return table;
		}
		return schema + "." + table;
	}

	internal static string GetStandardizedSchemaName(string schema)
	{
		if (schema.EqualsIgnoreCase("dbo"))
		{
			return null;
		}
		return schema;
	}
}

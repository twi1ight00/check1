using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Design.PluralizationServices;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Globalization;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to set the table name to be a pluralized version of the entity type name.
/// </summary>
public sealed class PluralizingTableNameConvention : IDbConvention<DbTableMetadata>, IConvention
{
	private static readonly PluralizationService _pluralizationService = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));

	internal PluralizingTableNameConvention()
	{
	}

	void IDbConvention<DbTableMetadata>.Apply(DbTableMetadata table, DbDatabaseMetadata database)
	{
		if (table.GetTableName() == null)
		{
			DbSchemaMetadata dbSchemaMetadata = database.Schemas.Where((DbSchemaMetadata s) => s.Tables.Contains(table)).Single();
			table.DatabaseIdentifier = dbSchemaMetadata.Tables.Except(new DbTableMetadata[1] { table }).UniquifyIdentifier(_pluralizationService.Pluralize(table.DatabaseIdentifier));
		}
	}
}

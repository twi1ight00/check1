using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;

namespace System.Data.Entity.Migrations.Sql;

/// <summary>
/// Common base class for providers that convert provider agnostic migration 
/// operations into database provider specific SQL commands.
/// </summary>
public abstract class MigrationSqlGenerator
{
	/// <summary>
	/// Converts a set of migration operations into database provider specific SQL.
	/// </summary>
	/// <param name="migrationOperations">The operations to be converted.</param>
	/// <param name="providerManifestToken">Token representing the version of the database being targeted.</param>
	/// <returns>A list of SQL statements to be executed to perform the migration operations.</returns>
	public abstract IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken);
}

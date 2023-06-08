using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Objects;

namespace System.Data.Entity.Internal;

/// <summary>
/// Handles creating databases either using the core provider or the Migrations pipeline.
/// </summary>
internal class DatabaseCreator
{
	/// <summary>
	/// Creates a database using the core provider (i.e. ObjectContext.CreateDatabase) or
	/// by using Code First Migrations <see cref="T:System.Data.Entity.Migrations.DbMigrator" /> to create an empty database
	/// and the perform an automatic migration to the current model.
	/// Migrations is used if Code First is being used and the EF provider is for SQL Server
	/// or SQL Compact. The core is used for non-Code First models and for other providers even
	/// when using Code First.
	/// </summary>
	public void CreateDatabase(InternalContext internalContext, Func<DbMigrationsConfiguration, DbContext, DbMigrator> createMigrator, ObjectContext objectContext)
	{
		if (internalContext.CodeFirstModel != null && (internalContext.ProviderName == "System.Data.SqlClient" || internalContext.ProviderName == "System.Data.SqlServerCe.4.0"))
		{
			Type type = internalContext.Owner.GetType();
			DbMigrator dbMigrator = createMigrator(new DbMigrationsConfiguration
			{
				ContextType = type,
				AutomaticMigrationsEnabled = true,
				MigrationsAssembly = type.Assembly,
				MigrationsNamespace = type.Namespace,
				TargetDatabase = new DbConnectionInfo(internalContext.OriginalConnectionString, internalContext.ProviderName)
			}, internalContext.Owner);
			dbMigrator.Update();
		}
		else
		{
			internalContext.DatabaseOperations.Create(objectContext);
			internalContext.SaveMetadataToDatabase();
		}
		internalContext.MarkDatabaseInitialized();
	}
}

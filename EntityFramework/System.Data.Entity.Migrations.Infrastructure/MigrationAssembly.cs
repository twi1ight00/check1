using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Migrations.Infrastructure;

internal class MigrationAssembly
{
	private readonly IList<IMigrationMetadata> _migrations;

	public virtual IEnumerable<string> MigrationIds => _migrations.Select((IMigrationMetadata t) => t.Id).ToList();

	public static string CreateMigrationId(string migrationName)
	{
		return DateTime.UtcNow.ToString("yyyyMMddHHmmssf") + "_" + migrationName;
	}

	public static string CreateBootstrapMigrationId()
	{
		return new string('0', 15) + "_" + Strings.BootstrapMigration;
	}

	protected MigrationAssembly()
	{
	}

	public MigrationAssembly(Assembly migrationsAssembly, string migrationsNamespace)
	{
		Type[] types = migrationsAssembly.GetTypes();
		Func<Type, bool> predicate = (Type t) => t.IsSubclassOf(typeof(DbMigration)) && typeof(IMigrationMetadata).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null && !t.IsAbstract && !t.IsGenericType && t.Namespace == migrationsNamespace;
		_migrations = (from t in types.Where(predicate)
			select (IMigrationMetadata)Activator.CreateInstance(t) into mm
			where !string.IsNullOrWhiteSpace(mm.Id) && mm.Id.IsValidMigrationId()
			orderby mm.Id
			select mm).ToList();
	}

	public virtual string UniquifyName(string migrationName)
	{
		string uniqueName = migrationName;
		int num = 1;
		while (_migrations.Any((IMigrationMetadata m) => string.Equals(m.GetType().Name, uniqueName, StringComparison.Ordinal)))
		{
			uniqueName = migrationName + num++;
		}
		return uniqueName;
	}

	public virtual DbMigration GetMigration(string migrationId)
	{
		DbMigration dbMigration = (DbMigration)_migrations.SingleOrDefault((IMigrationMetadata m) => string.Equals(m.Id, migrationId, StringComparison.Ordinal));
		dbMigration?.Reset();
		return dbMigration;
	}
}

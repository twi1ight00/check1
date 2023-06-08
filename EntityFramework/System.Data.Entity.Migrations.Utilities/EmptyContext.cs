using System.Data.Common;

namespace System.Data.Entity.Migrations.Utilities;

internal class EmptyContext : DbContext
{
	static EmptyContext()
	{
		Database.SetInitializer<EmptyContext>(null);
	}

	public EmptyContext(DbConnection existingConnection)
		: base(existingConnection, contextOwnsConnection: false)
	{
	}
}

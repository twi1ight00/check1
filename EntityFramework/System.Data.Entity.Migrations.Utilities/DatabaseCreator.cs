using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace System.Data.Entity.Migrations.Utilities;

internal class DatabaseCreator
{
	public void Create(DbConnection connection)
	{
		using EmptyContext emptyContext = new EmptyContext(connection);
		((IObjectContextAdapter)emptyContext).ObjectContext.CreateDatabase();
	}
}

using System.Data.Common;

namespace System.Data.Entity.Internal;

internal abstract class RepositoryBase
{
	private readonly string _connectionString;

	private readonly DbProviderFactory _providerFactory;

	protected RepositoryBase(string connectionString, DbProviderFactory providerFactory)
	{
		_connectionString = connectionString;
		_providerFactory = providerFactory;
	}

	protected DbConnection CreateConnection()
	{
		DbConnection dbConnection = _providerFactory.CreateConnection();
		dbConnection.ConnectionString = _connectionString;
		return dbConnection;
	}
}

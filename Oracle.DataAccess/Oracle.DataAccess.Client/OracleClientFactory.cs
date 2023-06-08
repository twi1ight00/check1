using System;
using System.Data.Common;
using System.Security;
using System.Security.Permissions;

namespace Oracle.DataAccess.Client;

public sealed class OracleClientFactory : DbProviderFactory, IServiceProvider
{
	public static OracleClientFactory Instance;

	public override bool CanCreateDataSourceEnumerator => true;

	static OracleClientFactory()
	{
		Instance = new OracleClientFactory();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public override DbCommand CreateCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateCommand()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateCommand()\n");
		}
		return new OracleCommand();
	}

	public override DbCommandBuilder CreateCommandBuilder()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateCommandBuilder()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateCommandBuilder()\n");
		}
		return new OracleCommandBuilder();
	}

	public override DbConnection CreateConnection()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateConnection()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateConnection()\n");
		}
		return new OracleConnection();
	}

	public override DbConnectionStringBuilder CreateConnectionStringBuilder()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateConnectionStringBuilder()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateConnectionStringBuilder()\n");
		}
		return new OracleConnectionStringBuilder();
	}

	public override DbDataAdapter CreateDataAdapter()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateDataAdapter()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateDataAdapter()\n");
		}
		return new OracleDataAdapter();
	}

	public override DbDataSourceEnumerator CreateDataSourceEnumerator()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateDataSourceEnumerator()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateDataSourceEnumerator()\n");
		}
		return new OracleDataSourceEnumerator();
	}

	public override DbParameter CreateParameter()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreateParameter()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreateParameter()\n");
		}
		return new OracleParameter();
	}

	public override CodeAccessPermission CreatePermission(PermissionState state)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::CreatePermission()\n");
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClientFactory::CreatePermission()\n");
		}
		return new OraclePermission(state);
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClientFactory::GetService()\n");
		}
		if (serviceType == typeof(DbProviderServices))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleClientFactory::GetService()\n");
			}
			return EFOracleProviderServices.Instance;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleClientFactory::GetService()\n");
		}
		return null;
	}
}

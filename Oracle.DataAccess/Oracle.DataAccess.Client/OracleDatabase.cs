using System;
using System.Security.Permissions;

namespace Oracle.DataAccess.Client;

[SecurityPermission(SecurityAction.Assert, ControlThread = true)]
public sealed class OracleDatabase : IDisposable
{
	private OracleConnection m_con;

	private OracleCommand m_cmd;

	private EncryptedPassword m_encryptedConString;

	private bool m_disposed;

	private bool m_bCloseDismountAndFinalize;

	public string ServerVersion => m_con.ServerVersion;

	internal void Open()
	{
		try
		{
			m_con.m_bPrelimAuthSession = false;
			m_con.Open();
		}
		catch
		{
			m_con.m_bPrelimAuthSession = true;
			m_con.Open();
		}
	}

	public OracleDatabase(string connectionString)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDatabase()\n");
		}
		try
		{
			m_con = new OracleConnection(connectionString);
			m_con.m_bStartupShutdown = true;
			m_cmd = new OracleCommand("", m_con);
			m_encryptedConString = new EncryptedPassword(connectionString);
			Open();
		}
		finally
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDatabase()\n");
			}
		}
	}

	public void Startup()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDatabase::StartupDB(1)\n");
		}
		try
		{
			Startup(OracleDBStartupMode.NoRestriction, null, bMountAndOpen: true);
		}
		finally
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDatabase::StartupDB(1)\n");
			}
		}
	}

	public unsafe void Startup(OracleDBStartupMode startupMode, string pfile, bool bMountAndOpen)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDatabase::StartupDB(4)\n");
		}
		try
		{
			int num = 0;
			int errorNumber = 0;
			if (pfile == null || pfile == "")
			{
				pfile = null;
			}
			m_con.m_opoConCtx.pOpoConValCtx->OracleDBStartupMode = (int)startupMode;
			try
			{
				num = OpsCon.StartupDB(m_con.m_opoConCtx.opsConCtx, m_con.m_opoConCtx.opsErrCtx, m_con.m_opoConCtx.pOpoConValCtx, pfile, out errorNumber);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num == -1)
			{
				try
				{
					m_con.Dispose();
					m_con = new OracleConnection(m_encryptedConString.Password);
					m_con.m_bStartupShutdown = true;
					Open();
					try
					{
						m_con.m_opoConCtx.pOpoConValCtx->OracleDBStartupMode = (int)startupMode;
						num = OpsCon.StartupDB(m_con.m_opoConCtx.opsConCtx, m_con.m_opoConCtx.opsErrCtx, m_con.m_opoConCtx.pOpoConValCtx, pfile, out errorNumber);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
						throw;
					}
				}
				finally
				{
					if (num == -1)
					{
						if (!bMountAndOpen)
						{
							OracleException.HandleError(num, m_con, m_con.m_opoConCtx.opsErrCtx, m_con);
						}
						if (errorNumber != 1081)
						{
							OracleException.HandleError(num, m_con, m_con.m_opoConCtx.opsErrCtx, m_con);
						}
					}
				}
			}
			m_con.Dispose();
			m_con = new OracleConnection(m_encryptedConString.Password);
			m_con.m_bStartupShutdown = true;
			Open();
			if ((errorNumber != 1081 && num != 0) || !bMountAndOpen)
			{
				return;
			}
			try
			{
				ExecuteNonQuery("ALTER DATABASE MOUNT");
			}
			catch (OracleException ex3)
			{
				if (ex3.Number != 1100)
				{
					throw;
				}
			}
			try
			{
				ExecuteNonQuery("ALTER DATABASE OPEN");
			}
			catch (OracleException ex4)
			{
				if (ex4.Number != 1531)
				{
					throw;
				}
			}
		}
		finally
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDatabase::StartupDB(4)\n");
			}
		}
	}

	public void Shutdown()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDatabase::Shutdown(1)\n");
		}
		try
		{
			Shutdown(OracleDBShutdownMode.Default, bCloseDismountAndFinalize: true);
		}
		finally
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDatabase::Shutdown(1)\n");
			}
		}
	}

	public unsafe void Shutdown(OracleDBShutdownMode shutdownMode, bool bCloseDismountAndFinalize)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDatabase::Shutdown(3)\n");
		}
		try
		{
			int num = 0;
			int errorNumber = 0;
			m_bCloseDismountAndFinalize = bCloseDismountAndFinalize;
			m_con.m_opoConCtx.pOpoConValCtx->OracleDBShutdownMode = (int)shutdownMode;
			try
			{
				num = OpsCon.ShutdownDB(m_con.m_opoConCtx.opsConCtx, m_con.m_opoConCtx.opsErrCtx, m_con.m_opoConCtx.pOpoConValCtx, out errorNumber);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num == 0 && bCloseDismountAndFinalize && shutdownMode != OracleDBShutdownMode.Final && shutdownMode != OracleDBShutdownMode.Abort)
			{
				try
				{
					ExecuteNonQuery("ALTER DATABASE CLOSE NORMAL");
				}
				catch (OracleException ex2)
				{
					if (ex2.Number != 1109 && ex2.Number != 1507)
					{
						throw;
					}
				}
				try
				{
					ExecuteNonQuery("ALTER DATABASE DISMOUNT");
				}
				catch (OracleException ex3)
				{
					if (ex3.Number != 1507)
					{
						throw;
					}
				}
				Shutdown(OracleDBShutdownMode.Final, bCloseDismountAndFinalize);
			}
			else if (num != 0 && !bCloseDismountAndFinalize)
			{
				OracleException.HandleError(num, m_con, m_con.m_opoConCtx.opsErrCtx, m_con);
			}
			if (errorNumber != 1012 && num != 0)
			{
				OracleException.HandleError(num, m_con, m_con.m_opoConCtx.opsErrCtx, m_con);
			}
		}
		finally
		{
			m_bCloseDismountAndFinalize = false;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDatabase::Shutdown(3)\n");
			}
		}
	}

	public void ExecuteNonQuery(string sql)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDatabase::ExecuteNonQuery()\n");
		}
		try
		{
			m_cmd.CommandText = sql;
			m_cmd.Connection = m_con;
			try
			{
				m_cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				if (!m_bCloseDismountAndFinalize)
				{
					m_con.Dispose();
					m_con = new OracleConnection(m_encryptedConString.Password);
					m_con.m_bStartupShutdown = true;
					Open();
					m_cmd.Connection = m_con;
					m_cmd.ExecuteNonQuery();
					return;
				}
				throw;
			}
		}
		finally
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDatabase::ExecuteNonQuery()\n");
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~OracleDatabase()
	{
		Dispose();
	}

	protected void Dispose(bool disposing)
	{
		if (m_disposed)
		{
			return;
		}
		try
		{
			if (disposing)
			{
				if (m_encryptedConString != null)
				{
					m_encryptedConString.Dispose();
				}
				if (m_cmd != null)
				{
					m_cmd.Dispose();
				}
				if (m_con != null)
				{
					m_con.Dispose();
				}
			}
		}
		finally
		{
			m_encryptedConString = null;
			m_cmd = null;
			m_con = null;
			m_disposed = true;
		}
	}
}

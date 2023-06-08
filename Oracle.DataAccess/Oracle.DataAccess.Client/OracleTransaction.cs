using System;
using System.Data;
using System.Data.Common;

namespace Oracle.DataAccess.Client;

public sealed class OracleTransaction : DbTransaction
{
	private OracleConnection m_connection;

	private IsolationLevel m_isolationLevel;

	private OracleCommand m_command;

	private bool m_completed;

	private bool m_disposed;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsErrCtx;

	private bool m_disabled;

	private unsafe OpoTxnValCtx* m_pOpoTxnValCtx;

	private int m_conSignature;

	protected override DbConnection DbConnection => m_connection;

	public new OracleConnection Connection => m_connection;

	public override IsolationLevel IsolationLevel
	{
		get
		{
			if (m_completed)
			{
				throw new InvalidOperationException();
			}
			return m_isolationLevel;
		}
	}

	internal bool Completed
	{
		get
		{
			return m_completed;
		}
		set
		{
			m_completed = value;
		}
	}

	static OracleTransaction()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public unsafe override void Commit()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTransaction::Commit()\n");
		}
		if (m_completed)
		{
			throw new InvalidOperationException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		try
		{
			m_pOpoTxnValCtx->ErrHndAllocated = 1;
			num = OpsTxn.Commit(m_opsConCtx, m_opsErrCtx, m_pOpoTxnValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_completed = true;
		Dispose();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTransaction::Commit()\n");
		}
	}

	public void Save(string savepointName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTransaction::Save()\n");
		}
		if (m_completed)
		{
			throw new InvalidOperationException();
		}
		if (m_command == null)
		{
			m_command = new OracleCommand("", m_connection);
		}
		m_command.CommandText = "SAVEPOINT " + savepointName;
		m_command.CommandTimeout = 0;
		m_command.ExecuteNonQuery();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTransaction::Save()\n");
		}
	}

	public unsafe override void Rollback()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTransaction::Rollback(1)\n");
		}
		if (m_completed)
		{
			throw new InvalidOperationException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		try
		{
			m_pOpoTxnValCtx->ErrHndAllocated = 1;
			m_pOpoTxnValCtx->ForceDispose = 0;
			num = OpsTxn.Rollback(m_opsConCtx, m_opsErrCtx, m_pOpoTxnValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_completed = true;
		Dispose();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTransaction::Rollback(1)\n");
		}
	}

	public void Rollback(string savepointName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTransaction::Rollback(2)\n");
		}
		if (m_completed)
		{
			throw new InvalidOperationException();
		}
		if (m_command == null)
		{
			m_command = new OracleCommand("", m_connection);
		}
		m_command.CommandText = "ROLLBACK TO SAVEPOINT " + savepointName;
		m_command.CommandTimeout = 0;
		m_command.ExecuteNonQuery();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTransaction::Rollback(2)\n");
		}
	}

	public new void Dispose()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTransaction::Dispose()\n");
		}
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTransaction::Dispose()\n");
		}
	}

	protected unsafe override void Dispose(bool disposing)
	{
		if (m_disposed)
		{
			return;
		}
		if (!m_completed)
		{
			try
			{
				if (m_pOpoTxnValCtx != null)
				{
					m_pOpoTxnValCtx->ErrHndAllocated = 1;
					m_pOpoTxnValCtx->ForceDispose = 1;
				}
				if (m_connection.m_opoConCtx.opsConCtx != IntPtr.Zero && m_opsErrCtx != IntPtr.Zero && m_pOpoTxnValCtx != null)
				{
					OpsTxn.Rollback(m_opsConCtx, m_opsErrCtx, m_pOpoTxnValCtx);
				}
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			m_completed = true;
		}
		try
		{
			if (m_pOpoTxnValCtx != null)
			{
				m_pOpoTxnValCtx->ErrHndAllocated = 1;
			}
			OpsTxn.Dispose(m_opsErrCtx, m_pOpoTxnValCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
		}
		try
		{
			if (m_opsConCtx != IntPtr.Zero)
			{
				OpsCon.RelRef(ref m_opsConCtx);
			}
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
		}
		m_pOpoTxnValCtx = null;
		m_opsConCtx = IntPtr.Zero;
		m_opsErrCtx = IntPtr.Zero;
		if (!m_disabled)
		{
			try
			{
				m_connection.EndTransaction();
			}
			catch
			{
			}
			m_disabled = true;
		}
		if (disposing)
		{
			m_connection = null;
			if (m_command != null)
			{
				try
				{
					m_command.Dispose();
				}
				catch
				{
				}
				m_command = null;
			}
		}
		m_disposed = true;
	}

	internal unsafe OracleTransaction(OracleConnection connection, IsolationLevel isolationLevel, int txnHndAllocated)
	{
		int num = 0;
		m_connection = connection;
		m_isolationLevel = isolationLevel;
		m_conSignature = m_connection.m_conSignature;
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		int num2 = 0;
		try
		{
			num2 = OpsCon.AddRef(m_opsConCtx);
			if (num2 <= 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			GC.SuppressFinalize(this);
			throw;
		}
		try
		{
			num = OpsTxn.AllocValCtx(ref m_pOpoTxnValCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			num = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num != 0)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				if (num != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
		m_pOpoTxnValCtx->TxnHndAllocated = txnHndAllocated;
		if (m_isolationLevel == IsolationLevel.Serializable)
		{
			m_pOpoTxnValCtx->Serializable = 1;
		}
		else
		{
			m_pOpoTxnValCtx->Serializable = 0;
		}
		if (m_opsErrCtx == IntPtr.Zero)
		{
			m_pOpoTxnValCtx->ErrHndAllocated = 0;
		}
		try
		{
			num = OpsTxn.Begin(m_opsConCtx, out m_opsErrCtx, m_pOpoTxnValCtx);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			num = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			m_connection.TxnHndAllocated = m_pOpoTxnValCtx->TxnHndAllocated;
			if (num != 0)
			{
				try
				{
					OpsTxn.FreeValCtx(m_pOpoTxnValCtx);
					m_pOpoTxnValCtx = null;
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
				}
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex6)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex6);
					}
				}
				if (num != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
	}

	~OracleTransaction()
	{
		Dispose(disposing: false);
	}
}

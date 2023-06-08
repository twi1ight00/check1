using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleRefCursor : MarshalByRefObject, IDisposable, INullable
{
	private int m_freeOpsSqlCtx;

	private IntPtr m_opsSqlCtx;

	private unsafe OpoSqlValCtx* m_pOpoSqlValCtx;

	internal OracleConnection m_connection;

	internal OraRefCursorState m_state;

	private bool m_doneDispose;

	internal int m_conSignature;

	private OracleDataReader m_cachedReader;

	private IntPtr m_opsConCtx;

	private bool m_bNotNull = true;

	private long m_rowSize;

	private long m_fetchSize;

	private bool m_RowSizeGetInvoked;

	private bool m_bFetchSizePropertySet;

	internal RefCursorInfo m_refCursorInfo;

	public static readonly OracleRefCursor Null;

	public bool IsNull => !m_bNotNull;

	public OracleConnection Connection
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				return null;
			}
			if (m_connection.m_internalUse)
			{
				throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_INTERNAL_CONN));
			}
			return m_connection;
		}
	}

	public long FetchSize
	{
		get
		{
			if (m_doneDispose)
			{
				throw new InvalidOperationException();
			}
			return m_fetchSize;
		}
		set
		{
			if (m_doneDispose)
			{
				throw new InvalidOperationException();
			}
			if (value <= 0)
			{
				throw new ArgumentException();
			}
			if (m_cachedReader != null)
			{
				m_cachedReader.FetchSize = value;
			}
			m_fetchSize = value;
			m_bFetchSizePropertySet = true;
		}
	}

	public long RowSize
	{
		get
		{
			if (m_rowSize == 0)
			{
				m_RowSizeGetInvoked = true;
				GetDataReader(fillRequest: true);
				m_rowSize = m_cachedReader.RowSize;
				m_RowSizeGetInvoked = false;
			}
			return m_rowSize;
		}
	}

	internal IntPtr SqlCtx
	{
		get
		{
			return m_opsSqlCtx;
		}
		set
		{
			m_opsSqlCtx = value;
		}
	}

	internal int FreeSqlCtx
	{
		get
		{
			return m_freeOpsSqlCtx;
		}
		set
		{
			m_freeOpsSqlCtx = value;
		}
	}

	static OracleRefCursor()
	{
		Null = new OracleRefCursor();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	private OracleRefCursor()
	{
		m_bNotNull = false;
	}

	internal unsafe OracleRefCursor(OracleConnection con, IntPtr opsSqlCtx, OpoSqlValCtx* pOpoSqlValCtx, string cmdText, string posOrName)
		: this(con, opsSqlCtx, pOpoSqlValCtx, cmdText, posOrName, 1)
	{
	}

	internal unsafe OracleRefCursor(OracleConnection con, IntPtr opsSqlCtx, OpoSqlValCtx* pOpoSqlValCtx, string cmdText, string posOrName, int freeOpsSqlCtx)
	{
		m_connection = con;
		m_conSignature = con.m_conSignature;
		m_state = OraRefCursorState.Open;
		m_opsSqlCtx = opsSqlCtx;
		m_pOpoSqlValCtx = pOpoSqlValCtx;
		m_freeOpsSqlCtx = freeOpsSqlCtx;
		m_fetchSize = pOpoSqlValCtx->FetchSize;
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		int num = 0;
		try
		{
			num = OpsCon.AddRef(m_opsConCtx);
			if (num <= 1)
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
		bool flag = false;
		int result = -1;
		if (int.TryParse(posOrName, out result))
		{
			flag = true;
		}
		StoredProcedureInfo storedProcInfo = RegAndConfigRdr.GetStoredProcInfo(cmdText);
		if (storedProcInfo == null)
		{
			return;
		}
		foreach (RefCursorInfo refCursor in storedProcInfo.refCursors)
		{
			if (flag)
			{
				if (refCursor.position == result)
				{
					m_refCursorInfo = refCursor;
				}
			}
			else if (refCursor.name == posOrName)
			{
				m_refCursorInfo = refCursor;
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public OracleDataReader GetDataReader()
	{
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		return GetDataReader(fillRequest: false);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	internal unsafe OracleDataReader GetDataReader(bool fillRequest)
	{
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (m_opsSqlCtx == IntPtr.Zero)
		{
			if ((fillRequest && m_cachedReader != null) || m_RowSizeGetInvoked)
			{
				if (m_state != 0)
				{
					if (m_cachedReader != null && !m_cachedReader.IsClosed)
					{
						m_cachedReader.Close();
					}
					m_cachedReader = null;
					throw new InvalidOperationException();
				}
				return m_cachedReader;
			}
			throw new InvalidOperationException();
		}
		OracleDataReader oracleDataReader = new OracleDataReader(opsSqlCtx: new IntPtr[1] { m_opsSqlCtx }, connection: m_connection, opsDacCtx: IntPtr.Zero, opsErrCtx: IntPtr.Zero, pOpoSqlValCtx: m_pOpoSqlValCtx, pOpoDacValCtx: null, metaData: null, resultCount: 1, commandBehavior: CommandBehavior.Default, safeMapping: null, commandText: null, freeOpsSqlCtx: m_freeOpsSqlCtx, bFetchSizePropertySet: m_bFetchSizePropertySet);
		oracleDataReader.RefCursor = this;
		oracleDataReader.m_fetchSize = m_fetchSize;
		if (fillRequest)
		{
			m_cachedReader = oracleDataReader;
		}
		else
		{
			m_cachedReader = null;
		}
		m_opsSqlCtx = IntPtr.Zero;
		m_pOpoSqlValCtx = null;
		if (m_rowSize == 0)
		{
			m_rowSize = oracleDataReader.RowSize;
		}
		return oracleDataReader;
	}

	private unsafe void Dispose(bool disposing)
	{
		bool flag = true;
		if (!m_bNotNull || m_doneDispose)
		{
			return;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRefCursor::Dispose()\n");
		}
		try
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Enter(m_connection.m_extProcEnv);
				flag = m_connection.m_extProcEnv.m_status;
			}
			if (m_freeOpsSqlCtx == 1 && m_opsSqlCtx != IntPtr.Zero)
			{
				try
				{
					if (flag)
					{
						OpsSql.FreeCtx(ref m_opsSqlCtx, m_connection.m_opoConCtx.opsErrCtx, 0);
					}
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_opsSqlCtx = IntPtr.Zero;
			}
			if (m_pOpoSqlValCtx != null)
			{
				try
				{
					OpsSql.FreeValCtx(m_pOpoSqlValCtx, flag ? 1 : 0);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_pOpoSqlValCtx = null;
			}
		}
		finally
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Exit(m_connection.m_extProcEnv);
			}
		}
		if (disposing)
		{
			try
			{
				if (m_cachedReader != null && !m_cachedReader.IsClosed)
				{
					try
					{
						m_cachedReader.Close();
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			m_cachedReader = null;
			m_connection = null;
			m_state = OraRefCursorState.Closed;
		}
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
		m_doneDispose = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRefCursor::Dispose()\n");
		}
	}

	~OracleRefCursor()
	{
		Dispose(disposing: false);
	}
}

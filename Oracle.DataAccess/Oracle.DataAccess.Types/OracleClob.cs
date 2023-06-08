using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleClob : Stream, ICloneable, INullable
{
	public const long MaxSize = 4294967295L;

	internal int m_allocOciLobLoc = 1;

	private IntPtr m_opsLobCtx;

	private IntPtr m_opsErrCtx;

	private IntPtr m_opsConCtx;

	private unsafe OpoLobValCtx* m_popoLobValCtx;

	internal OracleConnection m_connection;

	private bool m_doneDispose;

	internal bool m_isEmpty;

	private bool m_isNClob;

	internal bool m_isTemporaryLob;

	internal bool m_doneTempLobCreate;

	private long m_length;

	private long m_position;

	private bool m_caching;

	private bool m_isInChunkWriteMode;

	internal int m_conSignature;

	private int m_optimumChunkSize;

	private OracleCommand m_cmd;

	private bool m_bNotNull = true;

	public new static readonly OracleClob Null;

	internal IntPtr LobCtx => m_opsLobCtx;

	public bool IsNull => !m_bNotNull;

	public override bool CanRead
	{
		get
		{
			if (!m_bNotNull)
			{
				return true;
			}
			if (m_doneDispose || m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero || m_connection.m_conSignature != m_conSignature)
			{
				return false;
			}
			return true;
		}
	}

	public override bool CanSeek
	{
		get
		{
			if (!m_bNotNull)
			{
				return true;
			}
			if (m_doneDispose || m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero || m_connection.m_conSignature != m_conSignature)
			{
				return false;
			}
			return true;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (!m_bNotNull)
			{
				return false;
			}
			if (m_doneDispose || m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero || m_connection.m_conSignature != m_conSignature)
			{
				return false;
			}
			return true;
		}
	}

	public int OptimumChunkSize
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				return 0;
			}
			if (m_optimumChunkSize != 0)
			{
				return m_optimumChunkSize;
			}
			return GetOptimumChunkSize();
		}
	}

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

	public bool IsEmpty
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				throw new OracleNullValueException();
			}
			if (Length != 0)
			{
				return m_isEmpty = false;
			}
			return m_isEmpty = true;
		}
	}

	public bool IsNClob => m_isNClob;

	public bool IsInChunkWriteMode
	{
		get
		{
			if (!m_bNotNull)
			{
				return false;
			}
			return m_isInChunkWriteMode;
		}
	}

	public unsafe bool IsTemporary
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				return false;
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_connection.m_conSignature != m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			if (m_isTemporaryLob)
			{
				return true;
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_connection.m_conSignature != m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			int num = 0;
			try
			{
				num = OpsLob.IsTemporary(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
			if (m_popoLobValCtx->pLobProperties->isTemporaryLob == 1)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe override long Length
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				return 0L;
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_connection.m_conSignature != m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			if (m_isTemporaryLob && !m_doneTempLobCreate)
			{
				return m_length = 0L;
			}
			int num = 0;
			try
			{
				num = OpsLob.GetLength(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
			m_length = m_popoLobValCtx->lobDataLength * 2;
			return m_length;
		}
	}

	public string Value
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				throw new OracleNullValueException();
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_connection.m_conSignature != m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			if (m_isTemporaryLob && !m_doneTempLobCreate)
			{
				return string.Empty;
			}
			int num = 0;
			long num2 = 0L;
			num2 = m_position;
			m_position = 0L;
			long num3 = Length / 2;
			num = (int)((num3 < int.MaxValue) ? num3 : int.MaxValue);
			char[] array = new char[num];
			Read(array, 0, num);
			string result = new string(array);
			m_position = num2;
			return result;
		}
	}

	public override long Position
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				return 0L;
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_connection.m_conSignature != m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			return m_position;
		}
		set
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (m_bNotNull)
			{
				if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
				}
				if (m_connection.m_conSignature != m_conSignature)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException((string)null, (string)null);
				}
				m_position = value;
			}
		}
	}

	static OracleClob()
	{
		Null = new OracleClob();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleClob(OracleConnection con)
		: this(con, bCaching: false, bNClob: false)
	{
	}

	public unsafe OracleClob(OracleConnection con, bool bCaching, bool bNClob)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::OracleClob(2)\n");
		}
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
		m_connection = con;
		m_conSignature = m_connection.m_conSignature;
		m_allocOciLobLoc = 1;
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
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
		int num2 = 0;
		try
		{
			num2 = OpsLob.AllocAllLobCtx(m_opsConCtx, ref m_opsErrCtx, ref m_popoLobValCtx, ref m_opsLobCtx, 0, IntPtr.Zero, m_allocOciLobLoc);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			num2 = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num2 != 0)
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
				if (num2 != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num2, m_connection, IntPtr.Zero, this);
				}
			}
		}
		if (bNClob)
		{
			m_popoLobValCtx->pLobProperties->lobType = 4;
			m_isNClob = true;
		}
		else
		{
			m_popoLobValCtx->pLobProperties->lobType = 3;
		}
		if (bCaching)
		{
			m_popoLobValCtx->pLobProperties->isCached = 1;
			m_caching = true;
		}
		else
		{
			m_popoLobValCtx->pLobProperties->isCached = 0;
		}
		m_isTemporaryLob = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::OracleClob(2) created: " + m_opsLobCtx + "\n");
		}
	}

	internal OracleClob(bool bCaching, bool bNClob)
		: this(OracleConnection.GetInternalConnection(), bCaching, bNClob)
	{
	}

	private OracleClob()
	{
		m_bNotNull = false;
	}

	internal unsafe OracleClob(OracleConnection con, IntPtr opsLobCtx, bool bCaching, bool bNClob, bool bTempLob)
	{
		m_connection = con;
		m_conSignature = m_connection.m_conSignature;
		m_allocOciLobLoc = 1;
		m_opsLobCtx = opsLobCtx;
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
		int num2 = 0;
		try
		{
			num2 = OpsLob.AllocAllLobCtx(m_opsConCtx, ref m_opsErrCtx, ref m_popoLobValCtx, ref m_opsLobCtx, 0, IntPtr.Zero, m_allocOciLobLoc);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			num2 = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num2 != 0)
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
				if (num2 != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num2, m_connection, IntPtr.Zero, this);
				}
			}
		}
		m_popoLobValCtx->pLobProperties->lobType = 0;
		try
		{
			num2 = OpsLob.LobCheckNClob(m_opsLobCtx, m_popoLobValCtx);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			num2 = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num2 != 0)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
				}
				if (num2 != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num2, m_connection, m_opsErrCtx, this);
				}
			}
		}
		if (m_popoLobValCtx->pLobProperties->lobType == 4)
		{
			m_isNClob = true;
		}
		if (bCaching)
		{
			m_popoLobValCtx->pLobProperties->isCached = 1;
			m_caching = true;
		}
		else
		{
			m_popoLobValCtx->pLobProperties->isCached = 0;
		}
		if (bTempLob)
		{
			m_isTemporaryLob = true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::OracleClob(3) created: " + m_opsLobCtx + "\n");
		}
	}

	internal unsafe OracleClob(OracleConnection con, IntPtr opsLobLoc, bool bCaching, bool bNClob, bool bTempLob, int allocOciLobLoc)
	{
		m_connection = con;
		m_conSignature = m_connection.m_conSignature;
		m_allocOciLobLoc = allocOciLobLoc;
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
		int num2 = 0;
		m_popoLobValCtx = null;
		try
		{
			num2 = OpsLob.AllocAllLobCtx(m_opsConCtx, ref m_opsErrCtx, ref m_popoLobValCtx, ref m_opsLobCtx, 0, opsLobLoc, m_allocOciLobLoc);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			num2 = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num2 != 0)
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
				if (num2 != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num2, m_connection, IntPtr.Zero, this);
				}
			}
		}
		m_popoLobValCtx->pLobProperties->lobType = 0;
		try
		{
			num2 = OpsLob.LobCheckNClob(m_opsLobCtx, m_popoLobValCtx);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			num2 = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num2 != 0)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
				}
				if (num2 != ErrRes.INT_ERR)
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num2, m_connection, m_opsErrCtx, this);
				}
			}
		}
		if (m_popoLobValCtx->pLobProperties->lobType == 4)
		{
			m_isNClob = true;
		}
		if (bCaching)
		{
			m_popoLobValCtx->pLobProperties->isCached = 1;
			m_caching = true;
		}
		else
		{
			m_popoLobValCtx->pLobProperties->isCached = 0;
		}
		if (bTempLob)
		{
			m_isTemporaryLob = true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::OracleClob(3) created: " + m_opsLobCtx + "\n");
		}
	}

	internal OracleClob(IntPtr opsLobLoc, bool bCaching, bool bNClob, bool bTempLob, int allocOciLobLoc)
		: this(OracleConnection.GetInternalConnection(), opsLobLoc, bCaching, bNClob, bTempLob, allocOciLobLoc)
	{
	}

	~OracleClob()
	{
		Dispose(disposing: false);
	}

	internal void KeepOciLobLoc()
	{
		m_allocOciLobLoc = 0;
	}

	internal int GetLobLocator(out IntPtr opsLobCtx)
	{
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		int num = 0;
		opsLobCtx = IntPtr.Zero;
		return OpsLob.GetLobLocator(LobCtx, ref opsLobCtx);
	}

	public void Append(OracleClob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Append(1)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (obj.m_connection != m_connection && (!obj.m_connection.m_contextConnection || !m_connection.m_contextConnection))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
		}
		if (obj.m_isTemporaryLob && !obj.m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Append(1)\n");
			}
			return;
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		int num = 0;
		try
		{
			num = OpsLob.Append(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, obj.m_opsLobCtx);
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
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Append(1)\n");
		}
	}

	public void Append(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Append(2)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (buffer.Length == 0 || count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Append(2)\n");
			}
			return;
		}
		if (offset % 2 != 0 || count % 2 != 0)
		{
			throw new ArgumentOutOfRangeException("", OpoErrResManager.GetErrorMesg(ErrRes.EVEN_VALUE_PARAM_REQUIRED));
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		long position = m_position;
		Seek(0L, SeekOrigin.End);
		Write(buffer, offset, count);
		m_position = position;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Append(2)\n");
		}
	}

	public void Append(char[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Append(3)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (buffer.Length == 0 || count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Append(3)\n");
			}
			return;
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		long position = m_position;
		Seek(0L, SeekOrigin.End);
		Write(buffer, offset, count);
		m_position = position;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Append(3)\n");
		}
	}

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Clone()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Clone()\n");
			}
			return Null;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		int num = 0;
		IntPtr zero = IntPtr.Zero;
		OracleClob oracleClob = ((!m_isTemporaryLob) ? new OracleClob(m_connection, zero, m_caching, m_isNClob, bTempLob: false) : new OracleClob(m_connection, m_caching, IsNClob));
		if (oracleClob.m_isTemporaryLob)
		{
			oracleClob.CreateTempLob();
		}
		try
		{
			num = OpsLob.LocatorAssign(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, oracleClob.LobCtx);
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
		oracleClob.m_position = m_position;
		oracleClob.m_bNotNull = m_bNotNull;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Clone()\n");
		}
		return oracleClob;
	}

	public override void Close()
	{
		Dispose();
	}

	public int Compare(long src_offset, OracleClob obj, long dst_offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Compare()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::IsEqual()\n");
			}
			if (!m_bNotNull && obj.IsNull)
			{
				return 0;
			}
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (obj.m_connection != m_connection && (!obj.m_connection.m_contextConnection || !m_connection.m_contextConnection))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
		}
		if (src_offset < 0 || dst_offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (obj.m_isTemporaryLob && !obj.m_doneTempLobCreate && m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Compare()\n");
			}
			return 0;
		}
		if (obj.m_isTemporaryLob && !obj.m_doneTempLobCreate)
		{
			obj.CreateTempLob();
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		int num = -1;
		src_offset++;
		dst_offset++;
		if (m_cmd == null)
		{
			m_cmd = new OracleCommand();
		}
		m_cmd.Connection = m_connection;
		m_cmd.CommandText = "BEGIN :1 := DBMS_LOB.COMPARE(:LOB_1, :LOB_2, :AMOUNT, :OFFSET_1, :OFFSET_2); END;";
		m_cmd.CommandType = CommandType.Text;
		try
		{
			OracleParameter oracleParameter = new OracleParameter("return_value", OracleDbType.Int32, num, ParameterDirection.ReturnValue);
			oracleParameter.DbType = DbType.Int32;
			m_cmd.Parameters.Add(oracleParameter);
			OracleDbType dbType = ((!obj.IsNClob) ? OracleDbType.Clob : OracleDbType.NClob);
			m_cmd.Parameters.Add("provided_clob", dbType, obj, ParameterDirection.Input);
			OracleDbType dbType2 = ((!IsNClob) ? OracleDbType.Clob : OracleDbType.NClob);
			m_cmd.Parameters.Add("current_clob", dbType2, this, ParameterDirection.Input);
			m_cmd.Parameters.Add("compare_amount", OracleDbType.Int64, amount, ParameterDirection.Input);
			m_cmd.Parameters.Add("src_offset", OracleDbType.Int64, src_offset, ParameterDirection.Input);
			m_cmd.Parameters.Add("dst_offset", OracleDbType.Int64, dst_offset, ParameterDirection.Input);
			m_cmd.ExecuteNonQuery();
			return (int)m_cmd.Parameters[0].Value;
		}
		finally
		{
			m_cmd.Parameters.Clear();
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Compare()\n");
			}
		}
	}

	public long CopyTo(OracleClob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::CopyTo(1)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			throw new OracleNullValueException();
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::CopyTo(1)\n");
			}
			return 0L;
		}
		long result = CopyTo(0L, obj, 0L, Length / 2);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::CopyTo(1)\n");
		}
		return result;
	}

	public long CopyTo(OracleClob obj, long dst_offset)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::CopyTo(2)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			throw new OracleNullValueException();
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::CopyTo(2)\n");
			}
			return 0L;
		}
		long result = CopyTo(0L, obj, dst_offset, Length / 2);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::CopyTo(2)\n");
		}
		return result;
	}

	public unsafe long CopyTo(long src_offset, OracleClob obj, long dst_offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::CopyTo(3)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (obj.m_connection != m_connection && (!obj.m_connection.m_contextConnection || !m_connection.m_contextConnection))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
		}
		if (src_offset < 0 || dst_offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::CopyTo(3)\n");
			}
			return 0L;
		}
		if (obj.m_isTemporaryLob && !obj.m_doneTempLobCreate)
		{
			obj.CreateTempLob();
		}
		int num = 0;
		m_popoLobValCtx->inAmount = (int)amount;
		m_popoLobValCtx->src_offset = (int)src_offset + 1;
		m_popoLobValCtx->dst_offset = (int)dst_offset + 1;
		try
		{
			num = OpsLob.Copy(m_opsConCtx, m_opsErrCtx, obj.m_opsLobCtx, m_opsLobCtx, m_popoLobValCtx);
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
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::CopyTo(3)\n");
		}
		return m_popoLobValCtx->inAmount;
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void EndChunkWrite()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::EndChunkWrite()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (!m_isInChunkWriteMode)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::EndChunkWrite()\n");
			}
			return;
		}
		int num = 0;
		try
		{
			num = OpsLob.Close(m_opsConCtx, m_opsErrCtx, m_opsLobCtx);
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
		m_isInChunkWriteMode = false;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::EndChunkWrite()\n");
		}
	}

	public long Erase()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Erase(1)\n");
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		long result = Erase(0L, Length / 2);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Erase(1)\n");
		}
		return result;
	}

	public unsafe long Erase(long offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Erase(2)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Erase(2)\n");
			}
			return 0L;
		}
		if (offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		int num = 0;
		m_popoLobValCtx->dst_offset = (int)offset + 1;
		m_popoLobValCtx->inAmount = (int)amount;
		try
		{
			num = OpsLob.Erase(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Erase(2)\n");
		}
		return m_popoLobValCtx->outAmount;
	}

	public override void Flush()
	{
	}

	public unsafe bool IsEqual(OracleClob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::IsEqual()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::IsEqual()\n");
			}
			if (!m_bNotNull && obj.IsNull)
			{
				return true;
			}
			return false;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (obj.m_connection != m_connection && (!obj.m_connection.m_contextConnection || !m_connection.m_contextConnection))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
		}
		if ((obj.m_isTemporaryLob && !obj.m_doneTempLobCreate) || (m_isTemporaryLob && !m_doneTempLobCreate))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::IsEqual()\n");
			}
			return false;
		}
		int num = 0;
		try
		{
			num = OpsLob.IsEqual(m_opsConCtx, m_opsLobCtx, obj.LobCtx, m_popoLobValCtx);
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
		if (m_popoLobValCtx->pLobProperties->isEqual == 1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::IsEqual()\n");
			}
			return true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::IsEqual()\n");
		}
		return false;
	}

	public unsafe void BeginChunkWrite()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::BeginChunkWrite()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (m_isInChunkWriteMode)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::BeginChunkWrite()\n");
			}
			return;
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		int num = 0;
		try
		{
			num = OpsLob.Open(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
		m_isInChunkWriteMode = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::BeginChunkWrite()\n");
		}
	}

	public unsafe override int Read(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Read(1)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Read(1)\n");
			}
			return 0;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (offset < 0 || count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (count == 0 || (m_isTemporaryLob && !m_doneTempLobCreate))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Read(1)\n");
			}
			return 0;
		}
		int num = 0;
		if (m_position <= 0)
		{
			m_popoLobValCtx->src_offset = 1L;
		}
		else
		{
			m_popoLobValCtx->src_offset = m_position / 2 + 1;
		}
		if (m_popoLobValCtx->src_offset > uint.MaxValue)
		{
			throw new OracleTypeException(OpoErrResManager.GetErrorMesg(ErrRes.TYP_OFFSET_NOT_SUPPORTED, 4294967294u.ToString()));
		}
		m_popoLobValCtx->dst_offset = offset / 2;
		if (count + offset <= buffer.Length)
		{
			m_popoLobValCtx->inAmount = count / 2;
			m_popoLobValCtx->count = count;
		}
		else
		{
			m_popoLobValCtx->inAmount = buffer.Length / 2 - m_popoLobValCtx->dst_offset;
			m_popoLobValCtx->count = count - offset;
		}
		m_popoLobValCtx->pLobProperties->isUnicode = 1;
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr opoLobRefCtx = gCHandle.AddrOfPinnedObject();
		m_popoLobValCtx->offset = offset;
		m_popoLobValCtx->position = m_position;
		try
		{
			num = OpsLob.Read(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx, opoLobRefCtx);
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
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_position += m_popoLobValCtx->outAmount;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Read(1)\n");
		}
		return (int)m_popoLobValCtx->outAmount;
	}

	public unsafe int Read(char[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Read(2)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Read(2)\n");
			}
			return 0;
		}
		if (m_position % 2 != 0)
		{
			throw new ArgumentOutOfRangeException(null, OpoErrResManager.GetErrorMesg(ErrRes.EVEN_VALUE_PARAM_REQUIRED));
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (offset < 0 || count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (count == 0 || (m_isTemporaryLob && !m_doneTempLobCreate))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Read(2)\n");
			}
			return 0;
		}
		int num = 0;
		if (m_position <= 0)
		{
			m_popoLobValCtx->src_offset = 1L;
		}
		else
		{
			m_popoLobValCtx->src_offset = m_position / 2 + 1;
		}
		if (m_popoLobValCtx->src_offset > uint.MaxValue)
		{
			throw new OracleTypeException(OpoErrResManager.GetErrorMesg(ErrRes.TYP_OFFSET_NOT_SUPPORTED, 4294967294u.ToString()));
		}
		m_popoLobValCtx->dst_offset = offset;
		if (count + offset <= buffer.Length)
		{
			m_popoLobValCtx->inAmount = count;
		}
		else
		{
			m_popoLobValCtx->inAmount = buffer.Length - offset;
		}
		m_popoLobValCtx->pLobProperties->isUnicode = 1;
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr opoLobRefCtx = gCHandle.AddrOfPinnedObject();
		m_popoLobValCtx->offset = -1L;
		m_popoLobValCtx->count = -1L;
		m_popoLobValCtx->position = -1L;
		try
		{
			num = OpsLob.Read(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx, opoLobRefCtx);
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
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_position += m_popoLobValCtx->outAmount * 2;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Read(2)\n");
		}
		return (int)m_popoLobValCtx->outAmount;
	}

	public long Search(byte[] val, long offset, long nth)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Search(1)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Search(1)\n");
			}
			return 0L;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (offset < 0 || nth <= 0 || nth >= uint.MaxValue || offset >= uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Search(1)\n");
			}
			return 0L;
		}
		OracleString oracleString = new OracleString(val, isUnicode: true);
		int num = ((oracleString.Length <= 0) ? 1 : oracleString.Length);
		char[] array = new char[num];
		oracleString.IsCaseIgnored = false;
		if (oracleString.Length > 0)
		{
			oracleString.Value.CopyTo(0, array, 0, oracleString.Length);
		}
		if (array.Length * 2 > 16383)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		long num2 = 0L;
		offset++;
		if (m_cmd == null)
		{
			m_cmd = new OracleCommand();
		}
		m_cmd.Connection = m_connection;
		m_cmd.CommandText = "BEGIN :1 := DBMS_LOB.INSTR(:LOB_LOC, :PATTERN, :OFFSET, :NTH); END;";
		m_cmd.CommandType = CommandType.Text;
		try
		{
			OracleParameter oracleParameter = new OracleParameter("return_value", OracleDbType.Int64, num2, ParameterDirection.ReturnValue);
			oracleParameter.DbType = DbType.Int64;
			m_cmd.Parameters.Add(oracleParameter);
			OracleDbType dbType = ((!IsNClob) ? OracleDbType.Clob : OracleDbType.NClob);
			m_cmd.Parameters.Add("this_clob_or_nclob", dbType, this, ParameterDirection.Input);
			m_cmd.Parameters.Add("pattern", OracleDbType.Varchar2, array, ParameterDirection.Input);
			m_cmd.Parameters.Add("this_offset", OracleDbType.Int64, offset, ParameterDirection.Input);
			m_cmd.Parameters.Add("occurrence", OracleDbType.Int64, nth, ParameterDirection.Input);
			m_cmd.ExecuteNonQuery();
			return (long)m_cmd.Parameters[0].Value;
		}
		finally
		{
			m_cmd.Parameters.Clear();
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Search(1)\n");
			}
		}
	}

	public long Search(char[] val, long offset, long nth)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Search(2)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Search(2)\n");
			}
			return 0L;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (offset < 0 || nth <= 0 || val.Length * 2 > 16383 || nth >= uint.MaxValue || offset >= uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Search(2)\n");
			}
			return 0L;
		}
		long num = 0L;
		offset++;
		if (m_cmd == null)
		{
			m_cmd = new OracleCommand();
		}
		m_cmd.Connection = m_connection;
		m_cmd.CommandText = "BEGIN :1 := DBMS_LOB.INSTR(:LOB_LOC, :PATTERN, :OFFSET, :NTH); END;";
		m_cmd.CommandType = CommandType.Text;
		try
		{
			OracleParameter oracleParameter = new OracleParameter("return_value", OracleDbType.Int64, num, ParameterDirection.ReturnValue);
			oracleParameter.DbType = DbType.Int64;
			m_cmd.Parameters.Add(oracleParameter);
			OracleDbType dbType = ((!IsNClob) ? OracleDbType.Clob : OracleDbType.NClob);
			m_cmd.Parameters.Add("this_clob_or_nclob", dbType, this, ParameterDirection.Input);
			OracleDbType dbType2 = ((!IsNClob) ? OracleDbType.Varchar2 : OracleDbType.NVarchar2);
			m_cmd.Parameters.Add("pattern", dbType2, val, ParameterDirection.Input);
			m_cmd.Parameters.Add("this_offset", OracleDbType.Int64, offset, ParameterDirection.Input);
			m_cmd.Parameters.Add("occurrence", OracleDbType.Int64, nth, ParameterDirection.Input);
			m_cmd.ExecuteNonQuery();
			return (long)m_cmd.Parameters[0].Value;
		}
		finally
		{
			m_cmd.Parameters.Clear();
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Search(2)\n");
			}
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Seek()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Seek()\n");
			}
			return 0L;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Seek()\n");
			}
			return 0L;
		}
		if (origin == SeekOrigin.Begin)
		{
			m_position = offset;
		}
		if (origin == SeekOrigin.Current)
		{
			m_position += offset;
		}
		if (origin == SeekOrigin.End)
		{
			m_position = Length + offset;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Seek()\n");
		}
		return m_position;
	}

	public unsafe override void SetLength(long newLength)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::SetLength()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (newLength < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::SetLength()\n");
			}
			return;
		}
		int num = 0;
		m_popoLobValCtx->inAmount = (int)newLength;
		m_popoLobValCtx->pLobProperties->isUnicode = 1;
		try
		{
			num = OpsLob.Trim(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
		if (m_position > newLength * 2)
		{
			Seek(0L, SeekOrigin.End);
		}
		if (newLength == 0)
		{
			m_isEmpty = true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::SetLength()\n");
		}
	}

	public unsafe override void Write(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Write(1)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (offset < 0 || count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (offset % 2 != 0 || count % 2 != 0 || m_position % 2 != 0)
		{
			throw new ArgumentOutOfRangeException(null, OpoErrResManager.GetErrorMesg(ErrRes.EVEN_VALUE_PARAM_REQUIRED));
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		if (count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Write(1)\n");
			}
			return;
		}
		int num = 0;
		m_popoLobValCtx->src_offset = offset / 2;
		if (m_position <= 0)
		{
			m_popoLobValCtx->dst_offset = 1L;
		}
		else
		{
			m_popoLobValCtx->dst_offset = m_position / 2 + 1;
		}
		if (m_popoLobValCtx->dst_offset > uint.MaxValue)
		{
			throw new OracleTypeException(OpoErrResManager.GetErrorMesg(ErrRes.TYP_OFFSET_NOT_SUPPORTED, 4294967294u.ToString()));
		}
		if (count + offset <= buffer.Length)
		{
			m_popoLobValCtx->inAmount = count / 2;
		}
		else
		{
			m_popoLobValCtx->inAmount = buffer.Length / 2 - m_popoLobValCtx->src_offset;
		}
		m_popoLobValCtx->pLobProperties->isUnicode = 1;
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr opoLobRefCtx = gCHandle.AddrOfPinnedObject();
		try
		{
			num = OpsLob.Write(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx, opoLobRefCtx);
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
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_position += m_popoLobValCtx->inAmount * 2;
		if (m_popoLobValCtx->inAmount != 0)
		{
			m_isEmpty = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Write(1)\n");
		}
	}

	public void Write(char[] buffer, int offset, int count)
	{
		Write(buffer, offset, count, bIsFromEF: false);
	}

	public unsafe void Write(char[] buffer, int offset, int count, bool bIsFromEF)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Write(2)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (m_position % 2 != 0)
		{
			throw new ArgumentOutOfRangeException(null, OpoErrResManager.GetErrorMesg(ErrRes.EVEN_VALUE_PARAM_REQUIRED));
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (offset < 0 || count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		if (count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleClob::Write(2)\n");
			}
			return;
		}
		int num = 0;
		m_popoLobValCtx->src_offset = offset;
		if (m_position <= 0)
		{
			m_popoLobValCtx->dst_offset = 1L;
		}
		else
		{
			m_popoLobValCtx->dst_offset = m_position / 2 + 1;
		}
		if (m_popoLobValCtx->dst_offset > uint.MaxValue)
		{
			throw new OracleTypeException(OpoErrResManager.GetErrorMesg(ErrRes.TYP_OFFSET_NOT_SUPPORTED, 4294967294u.ToString()));
		}
		if (count + offset <= buffer.Length)
		{
			m_popoLobValCtx->inAmount = count;
		}
		else
		{
			m_popoLobValCtx->inAmount = buffer.Length - m_popoLobValCtx->src_offset;
		}
		m_popoLobValCtx->isFromEF = (bIsFromEF ? 1 : 0);
		m_popoLobValCtx->pLobProperties->isUnicode = 1;
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr opoLobRefCtx = gCHandle.AddrOfPinnedObject();
		try
		{
			num = OpsLob.Write(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx, opoLobRefCtx);
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
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_position += m_popoLobValCtx->inAmount * 2;
		if (m_popoLobValCtx->inAmount != 0)
		{
			m_isEmpty = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Write(2)\n");
		}
	}

	internal unsafe void CreateTempLob()
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
		if (!m_isTemporaryLob || m_doneTempLobCreate)
		{
			return;
		}
		int num = 0;
		try
		{
			num = OpsLob.CreateTemporary(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
		m_doneTempLobCreate = true;
		m_popoLobValCtx->pLobProperties->isTemporaryLob = 1;
	}

	internal unsafe int GetOptimumChunkSize()
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
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		int num = 0;
		try
		{
			num = OpsLob.GetOptimumChunkSize(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
		m_optimumChunkSize = (int)m_popoLobValCtx->outAmount * 2;
		return m_optimumChunkSize;
	}

	protected unsafe override void Dispose(bool disposing)
	{
		bool flag = true;
		if (!m_bNotNull || m_doneDispose)
		{
			return;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleClob::Dispose()\n");
			OraTrace.Trace(1u, " (LOB) Disposing Clob object: " + m_opsLobCtx + "\n");
		}
		if (m_cmd != null)
		{
			try
			{
				m_cmd.Dispose();
			}
			catch
			{
			}
			m_cmd = null;
		}
		if (m_isInChunkWriteMode)
		{
			try
			{
				EndChunkWrite();
			}
			catch
			{
			}
		}
		try
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Enter(m_connection.m_extProcEnv);
				flag = m_connection.m_extProcEnv.m_status;
			}
			if (m_allocOciLobLoc == 1)
			{
				try
				{
					if (flag)
					{
						OpsLob.FreeTemporary(m_opsConCtx, m_opsErrCtx, m_opsLobCtx);
					}
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_doneTempLobCreate = false;
			}
			try
			{
				OpsLob.FreeAllLobCtx(m_opsErrCtx, m_popoLobValCtx, m_opsLobCtx, 0, flag ? m_allocOciLobLoc : 0, flag ? 1 : 0);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
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
			m_popoLobValCtx = null;
			m_opsLobCtx = IntPtr.Zero;
			m_opsErrCtx = IntPtr.Zero;
			m_connection = null;
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
			OraTrace.Trace(1u, " (EXIT)  OracleClob::Dispose()\n");
		}
	}
}

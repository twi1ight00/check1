using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleBlob : Stream, ICloneable, INullable
{
	public const long MaxSize = 4294967295L;

	internal int m_allocOciLobLoc;

	private IntPtr m_opsLobCtx;

	private IntPtr m_opsErrCtx;

	private IntPtr m_opsConCtx;

	private unsafe OpoLobValCtx* m_popoLobValCtx;

	internal OracleConnection m_connection;

	private bool m_doneDispose;

	internal bool m_isEmpty;

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

	public new static readonly OracleBlob Null;

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
			m_length = m_popoLobValCtx->lobDataLength;
			return m_length;
		}
	}

	public byte[] Value
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
				return null;
			}
			int num = 0;
			long num2 = 0L;
			num2 = m_position;
			m_position = 0L;
			long length = Length;
			num = (int)((length < int.MaxValue) ? length : int.MaxValue);
			byte[] array = new byte[num];
			Read(array, 0, num);
			m_position = num2;
			return array;
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

	static OracleBlob()
	{
		Null = new OracleBlob('x');
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleBlob(OracleConnection con)
		: this(con, IntPtr.Zero, bCaching: false, bTempLob: true)
	{
	}

	internal OracleBlob()
		: this(OracleConnection.GetInternalConnection(), IntPtr.Zero, bCaching: false, bTempLob: true)
	{
	}

	public OracleBlob(OracleConnection con, bool bCaching)
		: this(con, IntPtr.Zero, bCaching, bTempLob: true)
	{
	}

	private OracleBlob(char dummy)
	{
		m_bNotNull = false;
	}

	internal unsafe OracleBlob(OracleConnection con, IntPtr opsLobCtx, bool bCaching, bool bTempLob)
	{
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
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
		m_popoLobValCtx = null;
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
		m_popoLobValCtx->pLobProperties->lobType = 2;
		m_popoLobValCtx->pLobProperties->isTemporaryLob = 0;
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
			OraTrace.Trace(1u, " (LOB) OracleBlob object created: " + m_opsLobCtx + "\n");
		}
	}

	internal unsafe OracleBlob(OracleConnection con, IntPtr opsLobLoc, bool bCaching, bool bTempLob, int allocOciLobLoc)
	{
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
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
		m_popoLobValCtx->pLobProperties->lobType = 2;
		m_popoLobValCtx->pLobProperties->isTemporaryLob = 0;
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
			OraTrace.Trace(1u, " (LOB) OracleBlob object created: " + m_opsLobCtx + "\n");
		}
	}

	internal OracleBlob(IntPtr opsLobLoc, bool bCaching, bool bTempLob, int allocOciLobLoc)
		: this(OracleConnection.GetInternalConnection(), opsLobLoc, bCaching, bTempLob, allocOciLobLoc)
	{
	}

	~OracleBlob()
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

	public void Append(OracleBlob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Append(1)\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Append(1)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Append(1)\n");
		}
	}

	public void Append(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Append(2)\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Append(2)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Append(2)\n");
		}
	}

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Clone()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Clone()\n");
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
		OracleBlob oracleBlob = new OracleBlob(m_connection, zero, m_caching, m_isTemporaryLob);
		if (oracleBlob.m_isTemporaryLob)
		{
			oracleBlob.CreateTempLob();
		}
		try
		{
			num = OpsLob.LocatorAssign(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, oracleBlob.LobCtx);
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
		oracleBlob.m_position = m_position;
		oracleBlob.m_bNotNull = m_bNotNull;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Clone()\n");
		}
		return oracleBlob;
	}

	public override void Close()
	{
		Dispose();
	}

	public int Compare(long src_offset, OracleBlob obj, long dst_offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Compare()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Compare()\n");
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
			m_cmd.Parameters.Add("provided_blob", OracleDbType.Blob, obj, ParameterDirection.Input);
			m_cmd.Parameters.Add("current_blob", OracleDbType.Blob, this, ParameterDirection.Input);
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Compare()\n");
			}
		}
	}

	public long CopyTo(OracleBlob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::CopyTo(1)\n");
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			throw new OracleNullValueException();
		}
		long result = CopyTo(0L, obj, 0L, Length);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::CopyTo(1)\n");
		}
		return result;
	}

	public long CopyTo(OracleBlob obj, long dst_offset)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::CopyTo(2)\n");
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || obj.IsNull)
		{
			throw new OracleNullValueException();
		}
		long result = CopyTo(0L, obj, dst_offset, Length);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::CopyTo(2)\n");
		}
		return result;
	}

	public unsafe long CopyTo(long src_offset, OracleBlob obj, long dst_offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::CopyTo(3)\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::CopyTo(3)\n");
			}
			return 0L;
		}
		if (obj.m_isTemporaryLob && !obj.m_doneTempLobCreate)
		{
			obj.CreateTempLob();
		}
		int num = 0;
		m_popoLobValCtx->inAmount = amount;
		m_popoLobValCtx->src_offset = src_offset + 1;
		m_popoLobValCtx->dst_offset = dst_offset + 1;
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::CopyTo(3)\n");
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
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::EndChunkWrite()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::EndChunkWrite()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::EndChunkWrite()\n");
		}
	}

	public long Erase()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Erase(1)\n");
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		long result = Erase(0L, Length);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Erase(1)\n");
		}
		return result;
	}

	public unsafe long Erase(long offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Erase(2)\n");
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
		if (offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Erase(2)\n");
			}
			return 0L;
		}
		int num = 0;
		m_popoLobValCtx->dst_offset = offset + 1;
		m_popoLobValCtx->inAmount = amount;
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Erase(2)\n");
		}
		return m_popoLobValCtx->outAmount;
	}

	public override void Flush()
	{
	}

	public unsafe bool IsEqual(OracleBlob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::IsEqual()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::IsEqual()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::IsEqual()\n");
			}
			return true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::IsEqual()\n");
		}
		return false;
	}

	public unsafe void BeginChunkWrite()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::BeginChunkWrite()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::BeginChunkWrite()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::BeginChunkWrite()\n");
		}
	}

	public unsafe override int Read(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Read()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Read()\n");
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
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (count == 0 || (m_isTemporaryLob && !m_doneTempLobCreate))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Read()\n");
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
			m_popoLobValCtx->src_offset = m_position + 1;
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
		m_popoLobValCtx->pLobProperties->isUnicode = 0;
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr opoLobRefCtx = gCHandle.AddrOfPinnedObject();
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Read()\n");
		}
		return (int)m_popoLobValCtx->outAmount;
	}

	public long Search(byte[] val, long offset, long nth)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Search()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Search()\n");
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
		if (offset < 0 || nth <= 0 || val.Length > 16383 || nth >= uint.MaxValue || offset >= uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Search()\n");
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
			m_cmd.Parameters.Add("current_blob", OracleDbType.Blob, this, ParameterDirection.Input);
			m_cmd.Parameters.Add("pattern", OracleDbType.Raw, val, ParameterDirection.Input);
			m_cmd.Parameters.Add("current_offset", OracleDbType.Int64, offset, ParameterDirection.Input);
			m_cmd.Parameters.Add("occurence", OracleDbType.Int64, nth, ParameterDirection.Input);
			m_cmd.ExecuteNonQuery();
			return (long)m_cmd.Parameters[0].Value;
		}
		finally
		{
			m_cmd.Parameters.Clear();
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Search()\n");
			}
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Seek()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Seek()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Seek()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Seek()\n");
		}
		return m_position;
	}

	public unsafe override void SetLength(long newLength)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::SetLength()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::SetLength()\n");
			}
			return;
		}
		int num = 0;
		m_popoLobValCtx->inAmount = newLength;
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
		if (m_position > newLength)
		{
			Seek(0L, SeekOrigin.End);
		}
		if (newLength == 0)
		{
			m_isEmpty = true;
			m_length = 0L;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::SetLength()\n");
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Write(buffer, offset, count, bIsFromEF: false);
	}

	public unsafe void Write(byte[] buffer, int offset, int count, bool bIsFromEF)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Write()\n");
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
		if (m_isTemporaryLob && !m_doneTempLobCreate)
		{
			CreateTempLob();
		}
		if (count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBlob::Write()\n");
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
			m_popoLobValCtx->dst_offset = m_position + 1;
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
			m_popoLobValCtx->inAmount = buffer.Length - offset;
		}
		m_popoLobValCtx->isFromEF = (bIsFromEF ? 1 : 0);
		m_popoLobValCtx->pLobProperties->isUnicode = 0;
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
		m_position += m_popoLobValCtx->inAmount;
		if (m_popoLobValCtx->inAmount != 0)
		{
			m_isEmpty = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Write()\n");
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
		return m_optimumChunkSize = (int)m_popoLobValCtx->outAmount;
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
			OraTrace.Trace(1u, " (ENTRY) OracleBlob::Dispose()\n");
			OraTrace.Trace(1u, " (LOB) Disposing OracleBlob object: " + m_opsLobCtx + "\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBlob::Dispose()\n");
		}
	}
}

using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleBFile : Stream, ICloneable, INullable
{
	public const long MaxSize = 4294967295L;

	internal int m_allocOciLobLoc;

	private IntPtr m_opsLobCtx;

	private IntPtr m_opsErrCtx;

	private IntPtr m_opsConCtx;

	private unsafe OpoLobValCtx* m_popoLobValCtx;

	private OracleCommand m_cmd;

	internal OracleConnection m_connection;

	private string m_directoryName;

	private bool m_doneDispose;

	private bool m_fileExists;

	private string m_fileName;

	private long m_length;

	private long m_position;

	internal bool m_isEmpty;

	private bool m_isOpen;

	internal int m_conSignature;

	private bool m_bNotNull = true;

	public new static readonly OracleBFile Null;

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

	public override bool CanWrite => false;

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

	public string DirectoryName
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleBFile::DirectoryName: get\n");
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
			if (m_directoryName == null)
			{
				GetDFNames();
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::DirectoryName: get\n");
			}
			return m_directoryName;
		}
		set
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				throw new OracleNullValueException();
			}
			if (IsOpen)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.LOB_BFILE_ALREADY_OPEN));
			}
			m_directoryName = value;
		}
	}

	public unsafe bool FileExists
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleBFile::FileExists: get\n");
			}
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBFile::FileExists: get\n");
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
			int num = 0;
			try
			{
				num = OpsLob.FileExists(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
			if (m_popoLobValCtx->pLobProperties->exists == 1)
			{
				m_fileExists = true;
			}
			else
			{
				m_fileExists = false;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::FileExists: get\n");
			}
			return m_fileExists;
		}
	}

	public string FileName
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleBFile::FileName: get\n");
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
			if (m_fileName == null)
			{
				GetDFNames();
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::FileName: get\n");
			}
			return m_fileName;
		}
		set
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				throw new OracleNullValueException();
			}
			if (IsOpen)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.LOB_BFILE_ALREADY_OPEN));
			}
			m_fileName = value;
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

	public bool IsOpen
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
			return m_isOpen;
		}
	}

	public unsafe override long Length
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleBFile::Length: get\n");
			}
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBFile::Length: get\n");
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
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Length: get\n");
			}
			return m_length;
		}
	}

	public byte[] Value
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleBFile::Value: get\n");
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
			int num = 0;
			long num2 = 0L;
			num2 = m_position;
			m_position = 0L;
			long length = Length;
			num = (int)((length < int.MaxValue) ? length : int.MaxValue);
			byte[] array = new byte[num];
			bool flag = false;
			if (!m_isOpen)
			{
				OpenFile();
				flag = true;
			}
			Read(array, 0, num);
			if (flag)
			{
				CloseFile();
			}
			m_position = num2;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Value: get\n");
			}
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

	static OracleBFile()
	{
		Null = new OracleBFile();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleBFile(OracleConnection con)
		: this(con, string.Empty, string.Empty)
	{
	}

	public unsafe OracleBFile(OracleConnection con, string directoryName, string fileName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::OracleBFile(2)\n");
		}
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
		m_connection = con;
		m_conSignature = con.m_conSignature;
		m_directoryName = directoryName;
		m_fileName = fileName;
		m_allocOciLobLoc = 1;
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
			num2 = OpsLob.AllocAllLobCtx(m_opsConCtx, ref m_opsErrCtx, ref m_popoLobValCtx, ref m_opsLobCtx, 1, IntPtr.Zero, m_allocOciLobLoc);
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
		m_popoLobValCtx->pLobProperties->lobType = 1;
		m_popoLobValCtx->pLobProperties->isTemporaryLob = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::OracleBFile(2)\n");
		}
	}

	private OracleBFile()
	{
		m_bNotNull = false;
	}

	internal unsafe OracleBFile(OracleConnection con, IntPtr opsLobCtx)
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
		m_popoLobValCtx = null;
		try
		{
			num2 = OpsLob.AllocAllLobCtx(m_opsConCtx, ref m_opsErrCtx, ref m_popoLobValCtx, ref m_opsLobCtx, 1, IntPtr.Zero, m_allocOciLobLoc);
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
		m_popoLobValCtx->pLobProperties->lobType = 1;
		m_popoLobValCtx->pLobProperties->isTemporaryLob = 0;
	}

	internal unsafe OracleBFile(OracleConnection con, IntPtr opsLobLoc, int allocOciLobLoc)
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
			num2 = OpsLob.AllocAllLobCtx(m_opsConCtx, ref m_opsErrCtx, ref m_popoLobValCtx, ref m_opsLobCtx, 1, opsLobLoc, m_allocOciLobLoc);
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
		m_popoLobValCtx->pLobProperties->lobType = 1;
		m_popoLobValCtx->pLobProperties->isTemporaryLob = 0;
	}

	internal OracleBFile(IntPtr opsLobLoc, int allocOciLobLoc)
		: this(OracleConnection.GetInternalConnection(), opsLobLoc, allocOciLobLoc)
	{
	}

	~OracleBFile()
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

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::Clone()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Clone()\n");
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
		OracleBFile oracleBFile = new OracleBFile(m_connection);
		int num = 0;
		try
		{
			num = OpsLob.LocatorAssign(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, oracleBFile.LobCtx);
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
		oracleBFile.Position = m_position;
		oracleBFile.m_directoryName = m_directoryName;
		oracleBFile.m_fileName = m_fileName;
		oracleBFile.m_bNotNull = m_bNotNull;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::Clone()\n");
		}
		return oracleBFile;
	}

	public override void Close()
	{
		Dispose();
	}

	public void CloseFile()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CloseFile()\n");
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
		if (m_isOpen)
		{
			int num = 0;
			try
			{
				num = OpsLob.CloseFile(m_opsConCtx, m_opsErrCtx, m_opsLobCtx);
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
			m_isOpen = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CloseFile()\n");
		}
	}

	public int Compare(long src_offset, OracleBFile obj, long dst_offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::Compare()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::IsEqual()\n");
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
		if (obj.m_connection != m_connection)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
		}
		if (src_offset < 0 || dst_offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
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
			m_cmd.Parameters.Add("provided_bfile", OracleDbType.BFile, obj, ParameterDirection.Input);
			m_cmd.Parameters.Add("current_bfile", OracleDbType.BFile, this, ParameterDirection.Input);
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
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Compare()\n");
			}
		}
	}

	public long CopyTo(OracleBlob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CopyTo(1)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CopyTo(1)\n");
		}
		return result;
	}

	public long CopyTo(OracleBlob obj, long dst_offset)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CopyTo(2)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CopyTo(2)\n");
		}
		return result;
	}

	public long CopyTo(OracleClob obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CopyTo(3)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CopyTo(3)\n");
		}
		return result;
	}

	public long CopyTo(OracleClob obj, long dst_offset)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CopyTo(4)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CopyTo(4)\n");
		}
		return result;
	}

	public unsafe long CopyTo(long src_offset, OracleBlob obj, long dst_offset, long amount)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CopyTo(5)\n");
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
		if (src_offset < 0 || dst_offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (obj.m_connection != m_connection && (!obj.m_connection.m_contextConnection || !m_connection.m_contextConnection))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
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
			num = OpsLob.LoadFromFile(m_opsConCtx, m_opsErrCtx, obj.LobCtx, m_opsLobCtx, m_popoLobValCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CopyTo(5)\n");
		}
		return m_popoLobValCtx->inAmount;
	}

	public unsafe long CopyTo(long src_offset, OracleClob obj, long amount, long dst_offset)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::CopyTo(6)\n");
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
		if (src_offset < 0 || dst_offset < 0 || amount < 0)
		{
			throw new ArgumentOutOfRangeException((string)null, (string)null);
		}
		if (obj.m_connection != m_connection && (!obj.m_connection.m_contextConnection || !m_connection.m_contextConnection))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
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
			num = OpsLob.LoadFromFile(m_opsConCtx, m_opsErrCtx, obj.LobCtx, m_opsLobCtx, m_popoLobValCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::CopyTo(6)\n");
		}
		return m_popoLobValCtx->inAmount;
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public override void Flush()
	{
	}

	public unsafe bool IsEqual(OracleBFile obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::IsEqual()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::IsEqual()\n");
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
		int num = 0;
		SetDFNames();
		obj.SetDFNames();
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
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::IsEqual()\n");
			}
			return true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::IsEqual()\n");
		}
		return false;
	}

	public unsafe void OpenFile()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::OpenFile()\n");
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
		if (IsOpen)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::OpenFile()\n");
			}
			return;
		}
		int num = 0;
		SetDFNames();
		num = 0;
		try
		{
			num = OpsLob.OpenFile(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_popoLobValCtx);
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
		m_isOpen = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::OpenFile()\n");
		}
	}

	public unsafe override int Read(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::Read()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Read()\n");
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
		if (count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Read()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::Read()\n");
		}
		return (int)m_popoLobValCtx->outAmount;
	}

	public long Search(byte[] val, long offset, long nth)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::Search()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Search()\n");
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
			m_cmd.Parameters.Add("current_bfile", OracleDbType.BFile, this, ParameterDirection.Input);
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
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Search()\n");
			}
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::Seek()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBFile::Seek()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::Seek()\n");
		}
		return m_position;
	}

	public override void SetLength(long newLength)
	{
		throw new NotSupportedException(null, null);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException(null, null);
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
			OraTrace.Trace(1u, " (ENTRY) OracleBFile::Dispose()\n");
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
		try
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Enter(m_connection.m_extProcEnv);
				flag = m_connection.m_extProcEnv.m_status;
			}
			if (m_allocOciLobLoc == 1 && m_isOpen)
			{
				try
				{
					if (flag)
					{
						OpsLob.CloseFile(m_opsConCtx, m_opsErrCtx, m_opsLobCtx);
					}
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_isOpen = false;
			}
			try
			{
				OpsLob.FreeAllLobCtx(m_opsErrCtx, m_popoLobValCtx, m_opsLobCtx, 1, flag ? m_allocOciLobLoc : 0, flag ? 1 : 0);
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
			OraTrace.Trace(1u, " (EXIT)  OracleBFile::Dispose()\n");
		}
	}

	internal unsafe void GetDFNames()
	{
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		char[] value = new char[31];
		IntPtr zero = IntPtr.Zero;
		int length = 0;
		char[] value2 = new char[256];
		IntPtr zero2 = IntPtr.Zero;
		int length2 = 0;
		GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
		GCHandle gCHandle2 = GCHandle.Alloc(value2, GCHandleType.Pinned);
		zero = gCHandle.AddrOfPinnedObject();
		zero2 = gCHandle2.AddrOfPinnedObject();
		int num = 0;
		try
		{
			num = OpsLob.FileGetName(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, zero, &length, zero2, &length2);
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
			if (gCHandle2.IsAllocated)
			{
				gCHandle2.Free();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_directoryName = new string(value, 0, length);
		m_fileName = new string(value2, 0, length2);
	}

	internal void SetDFNames()
	{
		int num = 0;
		if (m_directoryName == null || m_fileName == null)
		{
			GetDFNames();
		}
		if (m_directoryName == null || m_directoryName.Length == 0 || m_fileName == null || m_fileName.Length == 0)
		{
			return;
		}
		try
		{
			num = OpsLob.FileSetName(m_opsConCtx, m_opsErrCtx, m_opsLobCtx, m_directoryName, 0, m_fileName, 0);
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
		m_fileExists = true;
	}
}

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleXmlStream : Stream, ICloneable
{
	private int m_bFreeOciXmlType;

	private IntPtr m_opsXmlStreamCtx;

	private IntPtr m_opsErrCtx;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsXmlTypeCtx;

	private bool m_doneDispose;

	private int m_conSignature;

	private long m_length;

	private long m_position;

	private OracleConnection m_connection;

	private unsafe OpoXmlStreamReadParamList* m_popoXmlStreamReadParamList;

	public override bool CanRead
	{
		get
		{
			if (m_doneDispose)
			{
				return false;
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				return false;
			}
			if (m_conSignature != m_connection.m_conSignature)
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
			if (m_doneDispose)
			{
				return false;
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				return false;
			}
			if (m_conSignature != m_connection.m_conSignature)
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
			return m_connection;
		}
	}

	public override long Length
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_conSignature != m_connection.m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			int num = 0;
			int lengthInChars = 0;
			try
			{
				num = OpsXmlStream.GetLength(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, ref lengthInChars);
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
			m_length = lengthInChars * 2;
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
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_conSignature != m_connection.m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			IntPtr opsXmlStreamValueBuffer = IntPtr.Zero;
			string result = null;
			int numCharsInBuffer = 0;
			int num = 0;
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
				num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, ref opsXmlStreamValueBuffer, ref numCharsInBuffer);
				if (num == 0)
				{
					if (numCharsInBuffer > 0 && opsXmlStreamValueBuffer != IntPtr.Zero)
					{
						result = Marshal.PtrToStringUni(opsXmlStreamValueBuffer, numCharsInBuffer);
						num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer);
					}
					else
					{
						result = string.Empty;
					}
				}
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
					OracleException.HandleError(num, m_connection, IntPtr.Zero, this);
				}
			}
			return result;
		}
	}

	public unsafe override long Position
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_conSignature != m_connection.m_conSignature)
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
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_conSignature != m_connection.m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Position");
			}
			if (m_position != value)
			{
				m_popoXmlStreamReadParamList->bOverflow = 0;
			}
			m_position = value;
		}
	}

	static OracleXmlStream()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public unsafe OracleXmlStream(OracleXmlType xmlType)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::OracleXmlType(xmlType)\n");
		}
		OracleConnection connection = xmlType.m_connection;
		if (connection == null)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException();
		}
		m_bFreeOciXmlType = xmlType.m_bFreeOciXmlType;
		m_opsConCtx = connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		int num = 0;
		try
		{
			m_opsXmlStreamCtx = IntPtr.Zero;
			m_opsErrCtx = IntPtr.Zero;
			num = OpsXmlStream.AllocCtx(m_opsConCtx, xmlType.OpsXmlTypeCtx, ref m_opsErrCtx, ref m_opsXmlStreamCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "xmlType");
			}
		}
		m_opsXmlTypeCtx = xmlType.OpsXmlTypeCtx;
		m_popoXmlStreamReadParamList = null;
		try
		{
			num = OpsXmlStream.AllocReadParamList(ref m_popoXmlStreamReadParamList);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			GC.SuppressFinalize(this);
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0)
			{
				try
				{
					OpsXmlStream.FreeCtx(ref m_opsConCtx, ref m_opsErrCtx, ref m_opsXmlTypeCtx, ref m_opsXmlStreamCtx, m_bFreeOciXmlType, 1);
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
					throw new OracleTypeException(num, "xmlType");
				}
			}
		}
		m_connection = connection;
		m_conSignature = connection.m_conSignature;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlStream::OracleXmlStream(xmlType)\n");
		}
	}

	internal unsafe OracleXmlStream(OracleConnection con, IntPtr opsXmlTypeCtx)
	{
		m_bFreeOciXmlType = 1;
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException();
		}
		m_opsConCtx = con.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		int num = 0;
		try
		{
			m_opsXmlStreamCtx = IntPtr.Zero;
			m_opsErrCtx = IntPtr.Zero;
			num = OpsXmlStream.AllocCtx(m_opsConCtx, opsXmlTypeCtx, ref m_opsErrCtx, ref m_opsXmlStreamCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "con");
			}
		}
		m_opsXmlTypeCtx = opsXmlTypeCtx;
		m_popoXmlStreamReadParamList = null;
		try
		{
			OpsXmlStream.AllocReadParamList(ref m_popoXmlStreamReadParamList);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			GC.SuppressFinalize(this);
			throw;
		}
		m_connection = con;
		m_conSignature = con.m_conSignature;
	}

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Clone\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_conSignature != m_connection.m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		OracleXmlStream result = new OracleXmlStream(m_connection, m_opsXmlTypeCtx);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlStream::Clone\n");
		}
		return result;
	}

	public override void Close()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Close()\n");
		}
		Dispose();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlStream::Close()\n");
		}
	}

	public new unsafe void Dispose()
	{
		bool flag = true;
		if (m_doneDispose)
		{
			return;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Dispose()\n");
		}
		try
		{
			try
			{
				OpsXmlStream.FreeReadParamList(ref m_popoXmlStreamReadParamList);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			try
			{
				if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
				{
					Monitor.Enter(m_connection.m_extProcEnv);
					flag = m_connection.m_extProcEnv.m_status;
				}
				try
				{
					OpsXmlStream.FreeCtx(ref m_opsConCtx, ref m_opsErrCtx, ref m_opsXmlTypeCtx, ref m_opsXmlStreamCtx, flag ? m_bFreeOciXmlType : 0, flag ? 1 : 0);
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
		}
		catch
		{
		}
		m_popoXmlStreamReadParamList = null;
		m_position = 0L;
		m_length = 0L;
		m_connection = null;
		m_conSignature = 0;
		m_doneDispose = true;
		try
		{
			GC.SuppressFinalize(this);
		}
		catch
		{
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleXmlStream::Dispose()\n");
		}
	}

	public override void Flush()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Flush()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		throw new NotSupportedException(null, null);
	}

	public unsafe override int Read(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Read(byte[], ...)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_conSignature != m_connection.m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleXmlStream::Read(byte[], ...)\n");
			}
			return 0;
		}
		if (offset < 0 || count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = 0;
		m_popoXmlStreamReadParamList->newPosition = m_position;
		m_popoXmlStreamReadParamList->dst_offset = offset;
		if (count + offset <= buffer.Length)
		{
			m_popoXmlStreamReadParamList->inAmount = count / 2;
			m_popoXmlStreamReadParamList->numBytes = count;
		}
		else
		{
			m_popoXmlStreamReadParamList->inAmount = (buffer.Length - offset) / 2;
			m_popoXmlStreamReadParamList->numBytes = buffer.Length - count;
		}
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr pBuffer = gCHandle.AddrOfPinnedObject();
		try
		{
			num = OpsXmlStream.ReadBytes(m_opsConCtx, m_opsErrCtx, m_opsXmlStreamCtx, m_opsXmlTypeCtx, pBuffer, ref m_popoXmlStreamReadParamList);
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
		m_position += m_popoXmlStreamReadParamList->outAmount;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleXmlStream::Read(byte[], ...)\n");
		}
		return (int)m_popoXmlStreamReadParamList->outAmount;
	}

	public unsafe int Read(char[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Read(char[], ...)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_conSignature != m_connection.m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (count == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleXmlStream::Read(char[], ...)\n");
			}
			return 0;
		}
		if (offset < 0 || count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_position % 2 != 0)
		{
			throw new ArgumentOutOfRangeException(null, OpoErrResManager.GetErrorMesg(ErrRes.EVEN_VALUE_PARAM_REQUIRED));
		}
		int num = 0;
		m_popoXmlStreamReadParamList->newPosition = m_position;
		m_popoXmlStreamReadParamList->dst_offset = offset;
		if (count + offset <= buffer.Length)
		{
			m_popoXmlStreamReadParamList->inAmount = count;
		}
		else
		{
			m_popoXmlStreamReadParamList->inAmount = buffer.Length - offset;
		}
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		IntPtr pBuffer = gCHandle.AddrOfPinnedObject();
		try
		{
			num = OpsXmlStream.ReadChars(m_opsConCtx, m_opsErrCtx, m_opsXmlStreamCtx, m_opsXmlTypeCtx, pBuffer, ref m_popoXmlStreamReadParamList);
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
		m_position += m_popoXmlStreamReadParamList->outAmount * 2;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleXmlStream::Read(char[], ...)\n");
		}
		return (int)m_popoXmlStreamReadParamList->outAmount;
	}

	public unsafe override long Seek(long offset, SeekOrigin origin)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Seek()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_conSignature != m_connection.m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		long position = m_position;
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
		if (m_position < 0)
		{
			m_position = 0L;
			throw new ArgumentOutOfRangeException("offset");
		}
		if (m_position != position)
		{
			m_popoXmlStreamReadParamList->bOverflow = 0;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleXmlStream::Seek()\n");
		}
		return m_position;
	}

	public override void SetLength(long newLength)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::SetLength()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		throw new NotSupportedException(null, null);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlStream::Write()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		throw new NotSupportedException(null, null);
	}

	~OracleXmlStream()
	{
		Dispose();
	}
}

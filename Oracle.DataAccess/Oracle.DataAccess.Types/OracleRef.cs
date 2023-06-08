using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleRef : MarshalByRefObject, IDisposable, ICloneable, INullable
{
	internal IntPtr m_opsConCtx;

	internal IntPtr m_opsErrCtx;

	internal OpoUdtCtx m_opoUdtCtx;

	internal OracleConnection m_connection;

	private OracleUdtDescriptor m_oracleUdtDesc;

	internal OpoObjRefCtx m_opoObjRefCtx;

	internal unsafe OpoObjValCtx* m_pOpoObjValCtx;

	internal unsafe OpoUdtValCtx* m_pOpoUdtValCtx;

	internal bool m_disposed;

	internal int m_conSignature;

	private bool m_bNotNull = true;

	private IntPtr m_complexObjCtx;

	private int m_objectPinCount;

	internal bool m_bNotRefByApp;

	public static readonly OracleRef Null;

	public OracleConnection Connection
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_connection;
		}
	}

	internal unsafe OracleUdtDescriptor UdtDescriptor
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (m_oracleUdtDesc == null)
			{
				int num = 0;
				if (m_opsConCtx == IntPtr.Zero)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
				}
				if (m_connection.m_conSignature != m_conSignature)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
				}
				OpoDscRefCtx opoDscRefCtx = new OpoDscRefCtx();
				try
				{
					num = OpsRef.GetTypeName(m_opsConCtx, m_opsErrCtx, ref m_pOpoObjValCtx, ref opoDscRefCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pinLatest);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
				m_oracleUdtDesc = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, opoDscRefCtx.SchemaName, opoDscRefCtx.TypeName);
				m_oracleUdtDesc.GetMetaDataTable();
			}
			return m_oracleUdtDesc;
		}
	}

	public bool IsNull => !m_bNotNull;

	public string Value
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				throw new OracleNullValueException();
			}
			if (m_opoUdtCtx.m_pOCIRef == IntPtr.Zero)
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
			if (m_opoObjRefCtx.hexStr == null)
			{
				int num = 0;
				try
				{
					num = OpsRef.ToHex(m_opsConCtx, m_opsErrCtx, m_opoUdtCtx.m_pOCIRef, ref m_opoObjRefCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
			return m_opoObjRefCtx.hexStr;
		}
	}

	public unsafe bool IsLocked
	{
		get
		{
			int isLocked = 0;
			int num = 0;
			if (m_disposed)
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
			try
			{
				num = OpsRef.IsLocked(m_opsConCtx, m_opsErrCtx, ref m_pOpoObjValCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref isLocked, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pinLatest);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num != 0 && num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			if (isLocked == 1)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe string ObjectTableName
	{
		get
		{
			if (m_disposed)
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
			if (m_oracleUdtDesc == null)
			{
				m_oracleUdtDesc = UdtDescriptor;
			}
			if (m_opoObjRefCtx.objTableName == null)
			{
				int num = 0;
				try
				{
					num = OpsRef.GetTableName(m_opsConCtx, m_opsErrCtx, ref m_pOpoObjValCtx, ref m_opoObjRefCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pinLatest);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
				m_opoObjRefCtx.objTableName = m_oracleUdtDesc.SchemaName + "." + m_opoObjRefCtx.objTableName;
			}
			return m_opoObjRefCtx.objTableName;
		}
	}

	internal OpoUdtCtx OpoUdtCtx
	{
		set
		{
			if ((m_opoUdtCtx != null || value != null) && m_opoUdtCtx != value)
			{
				if (m_opoUdtCtx != null)
				{
					m_opoUdtCtx.RelRefCount();
				}
				if (value != null)
				{
					m_opoUdtCtx = value;
					m_opoUdtCtx.AddRefCount();
				}
			}
		}
	}

	public bool HasChanges
	{
		get
		{
			int num = 0;
			if (m_disposed)
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
			bool isDirty = false;
			bool flag = false;
			if (m_opoUdtCtx.m_IsPinned == 0)
			{
				flag = true;
			}
			try
			{
				num = OpsRef.IsDirty(m_opsConCtx, m_opsErrCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_IsPinned, ref isDirty);
				return isDirty;
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (flag && m_opoUdtCtx.m_IsPinned == 1)
				{
					m_objectPinCount++;
				}
				if (num != 0 && num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
	}

	static OracleRef()
	{
		Null = new OracleRef();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleRef(OracleConnection con, string udtTypeName, string objTabName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::OracleRef(1)\n");
		}
		InitRef(OracleUdtDescriptor.GetOracleUdtDescriptor(con, udtTypeName), objTabName);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::OracleRef(1)\n");
		}
	}

	internal unsafe void InitRef(OracleUdtDescriptor oraUdtDesc, string objTabName)
	{
		if (oraUdtDesc == null || objTabName == null)
		{
			throw new ArgumentNullException((string)null, (string)null);
		}
		if (oraUdtDesc.m_connection.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		if (objTabName == "")
		{
			throw new ArgumentException();
		}
		Initialize();
		if (oraUdtDesc.GetUdtTypeCode() == OciTypeCode.OBJECT)
		{
			m_pOpoObjValCtx->TypeCode = 108;
			oraUdtDesc.GetMetaDataTable();
			m_oracleUdtDesc = oraUdtDesc;
			int num = objTabName.LastIndexOf('.');
			if (num != -1)
			{
				m_opoObjRefCtx.schemaName = objTabName.Substring(0, num);
				m_opoObjRefCtx.objTableName = objTabName.Substring(num + 1);
			}
			else
			{
				m_opoObjRefCtx.objTableName = objTabName;
			}
			m_connection = m_oracleUdtDesc.m_connection;
			m_conSignature = m_connection.m_conSignature;
			m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
			if (m_opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			int num2 = 0;
			try
			{
				num2 = OpsCon.AddRef(m_opsConCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				m_opsConCtx = IntPtr.Zero;
				throw;
			}
			if (num2 <= 1)
			{
				m_opsConCtx = IntPtr.Zero;
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			try
			{
				OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			OpoUdtCtx = new OpoUdtCtx(m_opsConCtx, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			int num3 = 0;
			try
			{
				num3 = OpsObj.New(m_opsConCtx, m_opsErrCtx, m_oracleUdtDesc.m_opsDscCtx, ref m_pOpoObjValCtx, m_opoObjRefCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				num3 = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num3 != 0 && num3 != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num3, m_connection, m_opsErrCtx, this);
				}
			}
			m_opoObjRefCtx.objTableName = m_oracleUdtDesc.SchemaName + "." + objTabName;
			return;
		}
		throw new ArgumentException();
	}

	public unsafe OracleRef(OracleConnection con, string hexStr)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::OracleRef(2)\n");
		}
		if (con == null || hexStr == null)
		{
			throw new ArgumentNullException((string)null, (string)null);
		}
		if (con.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		if (hexStr == "")
		{
			throw new ArgumentException();
		}
		Initialize();
		m_connection = con;
		m_conSignature = m_connection.m_conSignature;
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		m_opoObjRefCtx.hexStr = hexStr;
		int num = 0;
		try
		{
			num = OpsCon.AddRef(m_opsConCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			m_opsConCtx = IntPtr.Zero;
			throw;
		}
		if (num <= 1)
		{
			m_opsConCtx = IntPtr.Zero;
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		OpoUdtCtx = new OpoUdtCtx(m_opsConCtx, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
		try
		{
			OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		int num2 = 0;
		try
		{
			num2 = OpsObj.New(m_opsConCtx, m_opsErrCtx, IntPtr.Zero, ref m_pOpoObjValCtx, m_opoObjRefCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			num2 = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num2 != 0 && num2 != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num2, m_connection, m_opsErrCtx, this);
			}
		}
		OpoDscRefCtx opoDscRefCtx = new OpoDscRefCtx();
		try
		{
			num2 = OpsRef.GetTypeName(m_opsConCtx, m_opsErrCtx, ref m_pOpoObjValCtx, ref opoDscRefCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pinLatest);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			num2 = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num2 != 0 && num2 != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num2, m_connection, m_opsErrCtx, this);
			}
		}
		m_oracleUdtDesc = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, opoDscRefCtx.SchemaName, opoDscRefCtx.TypeName);
		m_oracleUdtDesc.GetMetaDataTable();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::OracleRef(2)\n");
		}
	}

	private OracleRef()
	{
		m_bNotNull = false;
	}

	internal unsafe OracleRef(OracleUdtDescriptor oraUdtDsc, OpoUdtCtx opoUdtCtx)
	{
		if (oraUdtDsc == null || opoUdtCtx == null)
		{
			throw new ArgumentNullException((string)null, (string)null);
		}
		if (oraUdtDsc.m_connection.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		Initialize();
		if (oraUdtDsc.GetUdtTypeCode() == OciTypeCode.OBJECT)
		{
			m_pOpoObjValCtx->TypeCode = 108;
			m_oracleUdtDesc = oraUdtDsc;
			m_connection = oraUdtDsc.m_connection;
			m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
			m_conSignature = m_connection.m_conSignature;
			if (m_opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			OpoUdtCtx = opoUdtCtx;
			int num = 0;
			try
			{
				num = OpsCon.AddRef(m_opsConCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				m_opsConCtx = IntPtr.Zero;
				throw;
			}
			if (num <= 1)
			{
				m_opsConCtx = IntPtr.Zero;
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			try
			{
				OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
				return;
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
		throw new ArgumentException();
	}

	internal OracleRef(OracleConnection con, OpoUdtCtx opoUdtCtx)
	{
		if (con == null || opoUdtCtx == null)
		{
			throw new ArgumentNullException((string)null, (string)null);
		}
		if (con.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		Initialize();
		m_connection = con;
		m_conSignature = m_connection.m_conSignature;
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		OpoUdtCtx = opoUdtCtx;
		int num = 0;
		try
		{
			num = OpsCon.AddRef(m_opsConCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			m_opsConCtx = IntPtr.Zero;
			throw;
		}
		if (num <= 1)
		{
			m_opsConCtx = IntPtr.Zero;
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		try
		{
			OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
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

	~OracleRef()
	{
		Dispose(disposing: false);
	}

	public bool IsEqual(OracleRef oraRef)
	{
		int isEqual = 0;
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::IsEqual()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (oraRef == null)
		{
			throw new ArgumentNullException();
		}
		if (!m_bNotNull || oraRef.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleRef::IsEqual()\n");
			}
			if (!m_bNotNull && oraRef.IsNull)
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
		try
		{
			num = OpsRef.IsEqual(m_opsConCtx, m_opoUdtCtx.m_pOCIRef, oraRef.m_opoUdtCtx.m_pOCIRef, ref isEqual);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::IsEqual()\n");
		}
		if (isEqual == 1)
		{
			return true;
		}
		return false;
	}

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::Clone()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleRef::Clone()\n");
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
		if (m_oracleUdtDesc == null)
		{
			m_oracleUdtDesc = UdtDescriptor;
		}
		OracleRef oracleRef = new OracleRef(m_oracleUdtDesc, m_opoUdtCtx);
		oracleRef.m_bNotNull = m_bNotNull;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::Clone()\n");
		}
		return oracleRef;
	}

	public unsafe void Delete(bool bFlush)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::Delete()\n");
		}
		if (m_disposed)
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
		try
		{
			bool flag = false;
			if (m_opoUdtCtx.m_IsPinned == 0)
			{
				flag = true;
			}
			num = OpsRef.MarkDelete(m_opsConCtx, m_opsErrCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pOCIRef);
			if (num == 0 && flag && m_opoUdtCtx.m_IsPinned == 1)
			{
				m_objectPinCount++;
			}
			if (num == 0 && bFlush)
			{
				m_pOpoObjValCtx->deleteOnFlush = 1;
				bool flag2 = false;
				if (m_opoUdtCtx.m_IsPinned == 1)
				{
					flag2 = true;
				}
				num = OpsRef.Flush(m_opsConCtx, m_opsErrCtx, ref m_pOpoObjValCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pinLatest);
				if (num == 0 && flag2)
				{
					m_objectPinCount--;
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::Delete()\n");
		}
	}

	public unsafe void Flush()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::Flush()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			return;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		bool flag = false;
		if (m_opoUdtCtx.m_IsPinned == 1)
		{
			flag = true;
		}
		try
		{
			num = OpsRef.Flush(m_opsConCtx, m_opsErrCtx, ref m_pOpoObjValCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_IsPinned, ref m_opoUdtCtx.m_pinLatest);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			else if (num == 0 && flag)
			{
				m_objectPinCount--;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::Flush()\n");
		}
	}

	public bool Lock(bool wait)
	{
		int num = 0;
		int isLocked = 1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::Lock(0)\n");
		}
		if (m_disposed)
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
		bool flag = false;
		if (m_opoUdtCtx.m_IsPinned == 0)
		{
			flag = true;
		}
		try
		{
			num = OpsRef.Lock(m_opsConCtx, m_opsErrCtx, wait, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pObjInd, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_IsPinned, ref isLocked);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (flag && m_opoUdtCtx.m_IsPinned == 1)
			{
				m_objectPinCount++;
			}
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::Lock(0)\n");
		}
		if (isLocked == 1)
		{
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::Dispose()\n");
		}
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::Dispose()\n");
		}
	}

	private unsafe object CreateCustomObject()
	{
		int num = 0;
		if (m_oracleUdtDesc.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(m_oracleUdtDesc);
			m_oracleUdtDesc.DescribeCustomType(factory);
		}
		if ((IntPtr)m_pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out m_pOpoUdtValCtx, 1);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, null);
			}
		}
		m_pOpoUdtValCtx->pUDT = m_opoUdtCtx.m_pUDT;
		m_pOpoUdtValCtx->pNullStruct = m_opoUdtCtx.m_pObjInd;
		m_pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
		m_pOpoUdtValCtx->pTDO = m_oracleUdtDesc.m_opsDscCtx;
		m_pOpoUdtValCtx->pOpoDscValCtx = m_oracleUdtDesc.m_pOpoDscValCtx;
		try
		{
			num = OpsUdt.GetObj(m_connection.m_opoConCtx.opsConCtx, m_pOpoUdtValCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		if (num != 0)
		{
			OracleException.HandleError(num, m_connection, m_pOpoUdtValCtx->pOpsErrCtx, null);
		}
		object obj = ((IOracleCustomTypeFactory)m_oracleUdtDesc.m_customTypeFactory).CreateObject();
		if (obj != null)
		{
			((IOracleCustomType)obj).ToCustomObject(m_connection, (IntPtr)m_pOpoUdtValCtx);
		}
		return obj;
	}

	private void UnPinObj()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::UnPinObj()\n");
		}
		try
		{
			if (m_opoUdtCtx.m_IsPinned == 1)
			{
				num = OpsRef.UnPinObj(m_opsConCtx, m_opsErrCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_IsPinned);
				if (num == 0)
				{
					m_objectPinCount--;
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleRef::UnPinObj()\n");
		}
	}

	private void PinObj(OracleUdtFetchOption fetchOption, int nDepthLevel)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::GetCustomObject()\n");
		}
		if (m_disposed)
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
		if (m_oracleUdtDesc == null)
		{
			m_oracleUdtDesc = UdtDescriptor;
		}
		try
		{
			int m_pinLatest = (int)fetchOption;
			num = OpsRef.PinObjCOR(m_opsConCtx, m_opsErrCtx, m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pObjInd, ref m_complexObjCtx, nDepthLevel, ref m_pinLatest);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			else if (num == 0)
			{
				m_objectPinCount++;
			}
		}
		if (fetchOption == OracleUdtFetchOption.Server)
		{
			m_opoUdtCtx.m_pinLatest = 1;
		}
		m_opoUdtCtx.m_IsPinned = 1;
	}

	public object GetCustomObject(OracleUdtFetchOption fetchOption)
	{
		return GetCustomObject(fetchOption, 0);
	}

	public object GetCustomObject(OracleUdtFetchOption fetchOption, int depthLevel)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::GetCustomObject()\n");
		}
		if (fetchOption == OracleUdtFetchOption.Server)
		{
			try
			{
				OpsRef.UnMarkObjectByRef(m_opsConCtx, m_opsErrCtx, m_opoUdtCtx.m_pOCIRef);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
		}
		PinObj(fetchOption, depthLevel);
		object result = CreateCustomObject();
		UnPinObj();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::GetCustomObject(1)\n");
		}
		return result;
	}

	public object GetCustomObjectForUpdate(bool bWait)
	{
		return GetCustomObjectForUpdate(bWait, 0);
	}

	public object GetCustomObjectForUpdate(bool bWait, int depthLevel)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::GetCustomObjectForUpdate()\n");
		}
		m_opoUdtCtx.m_pinLatest = 1;
		if (1 == m_opoUdtCtx.m_IsPinned && HasChanges)
		{
			try
			{
				OpsRef.UnMarkObjectByRef(m_opsConCtx, m_opsErrCtx, m_opoUdtCtx.m_pOCIRef);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
		}
		if (!PinAndLock(bWait, depthLevel))
		{
			throw new OracleException(54, m_connection.DataSource, string.Empty, OracleTypeException.GetTypeMsg(54));
		}
		object result = CreateCustomObject();
		UnPinObj();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::GetCustomObjectForUpdate(1)\n");
		}
		return result;
	}

	public void Update(object customObject, bool bFlush)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleRef::Update()\n");
		}
		if (customObject == null || (customObject as INullable).IsNull)
		{
			throw new InvalidOperationException();
		}
		if (m_opoUdtCtx.m_IsPinned == 0)
		{
			PinObj(OracleUdtFetchOption.Cache, 0);
		}
		UpdateFromCustomObject((IOracleCustomType)customObject);
		if (bFlush)
		{
			Flush();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleRef::Update()\n");
		}
	}

	private unsafe void UpdateFromCustomObject(IOracleCustomType customObj)
	{
		int num = 0;
		OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor2(m_connection, (OpoDscRefCtx)OracleUdt.GetUdtName(customObj.GetType().FullName, m_connection.DataSource));
		if (oracleUdtDescriptor == null)
		{
			throw new InvalidOperationException();
		}
		if (oracleUdtDescriptor.UdtTypeName.CompareTo(m_oracleUdtDesc.UdtTypeName) != 0)
		{
			throw new ArgumentException();
		}
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		if ((IntPtr)m_pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out m_pOpoUdtValCtx, 1);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, null);
			}
		}
		if ((IntPtr)m_pOpoUdtValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out m_pOpoUdtValCtx->pOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			if (num == 0)
			{
				m_pOpoUdtValCtx->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
			}
		}
		else if (m_pOpoUdtValCtx->NumOpoUdtValCtx < oracleUdtDescriptor.AttributeCount)
		{
			try
			{
				num = OpsUdt.ReAllocValCtx(ref m_pOpoUdtValCtx->pOpoUdtValCtx, m_pOpoUdtValCtx->NumOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			if (num == 0)
			{
				m_pOpoUdtValCtx->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
			}
		}
		if (num != 0)
		{
			OracleException.HandleError(num, m_connection, m_pOpoUdtValCtx->pOpsErrCtx, null);
		}
		m_pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
		m_pOpoUdtValCtx->pTDO = oracleUdtDescriptor.m_opsDscCtx;
		m_pOpoUdtValCtx->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		for (int i = 0; i < oracleUdtDescriptor.AttributeCount; i++)
		{
			m_pOpoUdtValCtx->pOpoUdtValCtx[i].bIsNull = 1;
		}
		customObj.FromCustomObject(m_connection, (IntPtr)m_pOpoUdtValCtx);
		try
		{
			num = OpsUdt.SetData(m_connection.m_opoConCtx.opsConCtx, m_pOpoUdtValCtx);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			throw;
		}
		if (num != 0)
		{
			OracleException.HandleError(num, m_connection, m_pOpoUdtValCtx->pOpsErrCtx, null);
		}
		try
		{
			num = OpsUdt.Copy(m_connection.m_opoConCtx.opsConCtx, m_pOpoUdtValCtx, m_opoUdtCtx.m_pUDT, m_opoUdtCtx.m_pObjInd);
		}
		catch (Exception ex5)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex5);
			}
			throw;
		}
		if (num != 0)
		{
			OracleException.HandleError(num, m_connection, m_pOpoUdtValCtx->pOpsErrCtx, null);
		}
		GC.KeepAlive(oracleUdtDescriptor);
	}

	private bool PinAndLock(bool wait, int depthlevel)
	{
		int num = 0;
		int isLocked = 1;
		if (m_disposed)
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
		if (m_oracleUdtDesc == null)
		{
			m_oracleUdtDesc = UdtDescriptor;
		}
		try
		{
			num = OpsRef.PinAndLock(m_opsConCtx, m_opsErrCtx, wait, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_pOCIRef, ref m_opoUdtCtx.m_pObjInd, ref isLocked, ref m_complexObjCtx, depthlevel, ref m_opoUdtCtx.m_pinLatest);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			else if (num == 0)
			{
				m_objectPinCount++;
			}
		}
		m_opoUdtCtx.m_IsPinned = 1;
		if (isLocked == 1)
		{
			return true;
		}
		return false;
	}

	internal unsafe void Initialize()
	{
		try
		{
			OpsObj.AllocObjValCtx(ref m_pOpoObjValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		m_opoObjRefCtx = new OpoObjRefCtx();
	}

	private unsafe void Dispose(bool disposing)
	{
		if (!m_bNotNull || m_disposed)
		{
			return;
		}
		if (m_pOpoObjValCtx != null)
		{
			try
			{
				OpsObj.FreeValCtx(m_opsConCtx, m_opsErrCtx, m_complexObjCtx, m_pOpoObjValCtx);
				m_pOpoObjValCtx = null;
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
		}
		if (m_opoUdtCtx != null && m_opoUdtCtx.m_pUDT != IntPtr.Zero)
		{
			try
			{
				for (int i = 0; i < m_objectPinCount; i++)
				{
					if (OpsRef.UnPinObj(m_opsConCtx, m_opsErrCtx, ref m_opoUdtCtx.m_pUDT, ref m_opoUdtCtx.m_IsPinned) != 0)
					{
						break;
					}
				}
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
			finally
			{
				m_opoUdtCtx.m_pUDT = IntPtr.Zero;
			}
		}
		if (m_pOpoUdtValCtx != null)
		{
			try
			{
				OpsUdt.FreeValCtx(m_pOpoUdtValCtx, bFreeOuter: true);
				m_pOpoUdtValCtx = null;
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
			}
		}
		if (m_opsErrCtx != IntPtr.Zero)
		{
			try
			{
				OpsErr.FreeCtx(ref m_opsErrCtx);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
			}
		}
		if (m_opsConCtx != IntPtr.Zero)
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
		}
		if (disposing)
		{
			if (m_opoUdtCtx.m_refCount >= 1)
			{
				m_opoUdtCtx.RelRefCount();
			}
			m_connection = null;
			m_oracleUdtDesc = null;
			m_opoObjRefCtx = null;
		}
		m_disposed = true;
	}
}

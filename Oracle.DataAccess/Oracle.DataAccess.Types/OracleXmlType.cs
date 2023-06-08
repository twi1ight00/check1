using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleXmlType : IDisposable, INullable
{
	private const int FALSE = 0;

	private const int TRUE = 1;

	private const int UNKNOWN = 2;

	internal int m_bFreeOciXmlType = 1;

	private IntPtr m_opsErrCtx;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsXmlTypeCtx;

	internal OracleConnection m_connection;

	internal int m_conSignature;

	private OpoXmlTypeRefCtx m_opoXmlTypeRefCtx;

	private unsafe OpoXmlTypeValCtx* m_pOpoXmlTypeValCtx;

	private bool m_doneGetSchema;

	private bool m_doneDispose;

	private string m_value;

	private bool m_bNotNull = true;

	public static readonly OracleXmlType Null;

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

	public unsafe bool IsEmpty
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
			if (1 == m_pOpoXmlTypeValCtx->isEmpty)
			{
				return true;
			}
			if (m_pOpoXmlTypeValCtx->isEmpty == 0)
			{
				return false;
			}
			string value = Value;
			if (value == null)
			{
				HandleError(-1, m_connection, m_opsErrCtx, this);
			}
			if (value.Length == 0)
			{
				m_pOpoXmlTypeValCtx->isEmpty = 1;
				return true;
			}
			m_pOpoXmlTypeValCtx->isEmpty = 0;
			return false;
		}
	}

	public unsafe bool IsSchemaBased
	{
		get
		{
			int num = 0;
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!m_bNotNull)
			{
				throw new OracleNullValueException();
			}
			if (1 == m_pOpoXmlTypeValCtx->isSchemaBased)
			{
				return true;
			}
			if (m_pOpoXmlTypeValCtx->isSchemaBased == 0)
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
				num = OpsXmlType.IsSchemaBased(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, ref m_pOpoXmlTypeValCtx);
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
					HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			if (1 == m_pOpoXmlTypeValCtx->isSchemaBased)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe bool IsFragment
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
			try
			{
				OpsXmlType.IsFragment(m_opsXmlTypeCtx, ref m_pOpoXmlTypeValCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (m_pOpoXmlTypeValCtx->isFragment == 1)
			{
				return true;
			}
			return false;
		}
	}

	public string RootElement
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
			if (!m_doneGetSchema)
			{
				GetSchemaFromOPS();
			}
			return m_opoXmlTypeRefCtx.rootElement;
		}
	}

	public OracleXmlType Schema
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
			if (!m_doneGetSchema)
			{
				GetSchemaFromOPS();
				if (m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx == IntPtr.Zero)
				{
					return new OracleXmlType(m_connection);
				}
				return new OracleXmlType(m_connection, m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx, flag: true);
			}
			if (m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx == IntPtr.Zero)
			{
				return new OracleXmlType(m_connection);
			}
			return new OracleXmlType(m_connection, m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx, flag: true);
		}
	}

	public string SchemaUrl
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
			if (!m_doneGetSchema)
			{
				GetSchemaFromOPS();
			}
			return m_opoXmlTypeRefCtx.schemaUrl;
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
			if (m_value == null)
			{
				IntPtr opsXmlStreamValueBuffer = IntPtr.Zero;
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
							m_value = Marshal.PtrToStringUni(opsXmlStreamValueBuffer, numCharsInBuffer);
							num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer);
						}
						else
						{
							m_value = string.Empty;
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
						HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
			return m_value;
		}
	}

	internal IntPtr OpsXmlTypeCtx
	{
		get
		{
			if (m_doneDispose)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_opsXmlTypeCtx;
		}
	}

	static OracleXmlType()
	{
		Null = new OracleXmlType();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleXmlType(OracleConnection con)
		: this(con, string.Empty, string.Empty)
	{
	}

	internal unsafe OracleXmlType(OracleConnection con, string rootElement, string schemaUrl)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::OracleXmlType(con, string, schemaUrl)\n");
		}
		int num = 0;
		m_bFreeOciXmlType = 1;
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
		m_opsConCtx = con.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		m_opoXmlTypeRefCtx = new OpoXmlTypeRefCtx();
		m_opoXmlTypeRefCtx.rootElement = rootElement;
		m_opoXmlTypeRefCtx.schemaUrl = schemaUrl;
		try
		{
			num = OpsXmlType.AllocXmlTypeCtxEmpty(m_opsConCtx, ref m_opsXmlTypeCtx, ref m_opsErrCtx, ref m_pOpoXmlTypeValCtx, m_opoXmlTypeRefCtx);
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
			if (num != 0)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "schemaurl");
			}
		}
		m_pOpoXmlTypeValCtx->isFragment = 2;
		m_pOpoXmlTypeValCtx->isSchemaBased = 2;
		m_pOpoXmlTypeValCtx->isEmpty = 2;
		m_connection = con;
		m_conSignature = con.m_conSignature;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::OracleXmlType(con, string, schemaUrl)\n");
		}
	}

	public OracleXmlType(OracleClob clob)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::OracleXmlType(clob)\n");
		}
		if (clob == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("clob", (string)null);
		}
		if (clob.m_connection == null)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException();
		}
		m_bFreeOciXmlType = 1;
		Initialize(clob.m_connection, null, clob, 2);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::OracleXmlType(clob)\n");
		}
	}

	public OracleXmlType(OracleConnection con, string xmlData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::OracleXmlType(con, string)\n");
		}
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
		if (xmlData == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("xmlData", (string)null);
		}
		if (xmlData.Length == 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentException(string.Empty, "xmlData");
		}
		m_bFreeOciXmlType = 1;
		Initialize(con, xmlData, null, 1);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::OracleXmlType(con, string)\n");
		}
	}

	internal OracleXmlType(string xmlData)
		: this(OracleConnection.GetInternalConnection(), xmlData)
	{
	}

	public OracleXmlType(OracleConnection con, XmlReader reader)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::OracleXmlType(con, xmlreader)\n");
		}
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
		if (reader == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("reader", (string)null);
		}
		m_bFreeOciXmlType = 1;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.Load(reader);
		string outerXml = xmlDocument.OuterXml;
		if (outerXml == null || outerXml.Length == 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentException(string.Empty, "reader");
		}
		Initialize(con, outerXml, null, 1);
		outerXml = null;
		xmlDocument = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::OracleXmlType(con, xmlreader)\n");
		}
	}

	public OracleXmlType(OracleConnection con, XmlDocument domDoc)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::OracleXmlType(con, xmldocument)\n");
		}
		if (con == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("con", (string)null);
		}
		if (domDoc == null)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentNullException("domDoc", (string)null);
		}
		string outerXml = domDoc.OuterXml;
		if (outerXml == null || outerXml.Length == 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentException(string.Empty, "domDoc");
		}
		m_bFreeOciXmlType = 1;
		Initialize(con, outerXml, null, 1);
		outerXml = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::OracleXmlType(con, xmldocument)\n");
		}
	}

	internal unsafe OracleXmlType(OracleConnection con, IntPtr pOpsXmlTypeCtx, bool flag)
	{
		int num = 0;
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
		m_bFreeOciXmlType = 1;
		m_opoXmlTypeRefCtx = new OpoXmlTypeRefCtx();
		try
		{
			num = OpsXmlType.AllocCtx(m_opsConCtx, ref m_opsErrCtx, ref m_pOpoXmlTypeValCtx);
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
			if (num != 0)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "xml");
			}
		}
		m_pOpoXmlTypeValCtx->isFragment = 2;
		m_pOpoXmlTypeValCtx->isSchemaBased = 2;
		m_pOpoXmlTypeValCtx->isEmpty = 2;
		m_opsXmlTypeCtx = pOpsXmlTypeCtx;
		if (flag)
		{
			try
			{
				OpsXmlType.AddRef(pOpsXmlTypeCtx);
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
		}
		m_connection = con;
		m_conSignature = con.m_conSignature;
	}

	internal OracleXmlType(IntPtr pOciXmlType, bool addRef, int allocOciXmlType)
		: this(OracleConnection.GetInternalConnection(), pOciXmlType, addRef, allocOciXmlType)
	{
	}

	private OracleXmlType()
	{
		m_bNotNull = false;
	}

	internal unsafe OracleXmlType(OracleConnection con, IntPtr pOciXmlType, bool addRef, int allocOciXmlType)
	{
		int num = 0;
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
		m_bFreeOciXmlType = allocOciXmlType;
		m_opoXmlTypeRefCtx = new OpoXmlTypeRefCtx();
		try
		{
			num = OpsXmlType.AllocCtx(m_opsConCtx, ref m_opsErrCtx, ref m_pOpoXmlTypeValCtx);
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
			if (num != 0)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "xml");
			}
		}
		m_pOpoXmlTypeValCtx->isFragment = 2;
		m_pOpoXmlTypeValCtx->isSchemaBased = 2;
		m_pOpoXmlTypeValCtx->isEmpty = 2;
		try
		{
			num = OpsXmlType.AllocNewCtx(m_opsConCtx, ref m_opsXmlTypeCtx, pOciXmlType, allocOciXmlType);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "xml");
			}
		}
		if (addRef)
		{
			try
			{
				OpsXmlType.AddRef(m_opsXmlTypeCtx);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				GC.SuppressFinalize(this);
				throw;
			}
		}
		m_connection = con;
		m_conSignature = con.m_conSignature;
	}

	public unsafe void Dispose()
	{
		bool flag = true;
		if (!m_bNotNull || m_doneDispose)
		{
			return;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Dispose()\n");
		}
		try
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Enter(m_connection.m_extProcEnv);
				flag = m_connection.m_extProcEnv.m_status;
			}
			if (m_opoXmlTypeRefCtx != null && m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx != IntPtr.Zero)
			{
				try
				{
					OpsXmlType.RelRef(m_opsConCtx, m_opsErrCtx, ref m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx, flag ? m_bFreeOciXmlType : 0);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_opoXmlTypeRefCtx.schema_opsXmlTypeCtx = IntPtr.Zero;
			}
			try
			{
				if (m_opoXmlTypeRefCtx != null)
				{
					m_opoXmlTypeRefCtx.rootElement = null;
					m_opoXmlTypeRefCtx.schemaUrl = null;
				}
			}
			catch
			{
			}
			m_value = null;
			try
			{
				OpsXmlType.RelRef(m_opsConCtx, m_opsErrCtx, ref m_opsXmlTypeCtx, flag ? m_bFreeOciXmlType : 0);
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
				OpsXmlType.FreeCtx(ref m_opsConCtx, ref m_opsErrCtx, ref m_pOpoXmlTypeValCtx, flag ? 1 : 0);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
			}
		}
		catch
		{
		}
		finally
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Exit(m_connection.m_extProcEnv);
			}
		}
		m_connection = null;
		m_opsErrCtx = IntPtr.Zero;
		m_opsXmlTypeCtx = IntPtr.Zero;
		m_pOpoXmlTypeValCtx = null;
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
			OraTrace.Trace(1u, " (EXIT)  OracleXmlType::Dispose()\n");
		}
	}

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Clone()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleXmlType::Clone()\n");
			}
			return Null;
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_conSignature != m_connection.m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		OracleXmlType result = new OracleXmlType(m_connection, m_opsXmlTypeCtx, flag: true);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Clone()\n");
		}
		return result;
	}

	internal void KeepOciXmlType()
	{
		m_bFreeOciXmlType = 0;
	}

	internal int GetOCIXMLType(out IntPtr ociXMLType)
	{
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		int num = 0;
		ociXMLType = IntPtr.Zero;
		try
		{
			return OpsXmlType.GetOCIXMLType(OpsXmlTypeCtx, ref ociXMLType);
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

	public OracleXmlType Extract(string xpathExpr, string nsMap)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Extract(xpath, nsmap)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleXmlType::Extract(xpath, nsmap)\n");
			}
			return null;
		}
		int num = 0;
		IntPtr ppOpsXmlTypeCtx_result = IntPtr.Zero;
		if (xpathExpr == null || xpathExpr.Length == 0)
		{
			throw new ArgumentNullException("xpathExpr", (string)null);
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
			num = OpsXmlType.Extract(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, xpathExpr, nsMap, ref ppOpsXmlTypeCtx_result);
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
				HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (IntPtr.Zero != ppOpsXmlTypeCtx_result)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleXmlType::Extract(xpath, nsmap)\n");
			}
			return new OracleXmlType(m_connection, ppOpsXmlTypeCtx_result, flag: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Extract(xpath, nsmap)\n");
		}
		return new OracleXmlType(m_connection);
	}

	public OracleXmlType Extract(string xpathExpr, XmlNamespaceManager nsMgr)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Extract(xpath, nsmgr)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleXmlType::Extract(xpath, nsmgr)\n");
			}
			return null;
		}
		string nsMap = NsMgrToString(nsMgr);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Extract(xpath, nsmgr)\n");
		}
		return Extract(xpathExpr, nsMap);
	}

	public OracleXmlStream GetStream()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::GetStream()\n");
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
		if (m_conSignature != m_connection.m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::GetStream()\n");
		}
		return new OracleXmlStream(m_connection, m_opsXmlTypeCtx);
	}

	public XmlDocument GetXmlDocument()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::GetXmlDocument()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		string value = Value;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.LoadXml(value);
		value = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::GetXmlDocument()\n");
		}
		return xmlDocument;
	}

	public XmlReader GetXmlReader()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::GetXmlReader()\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		string value = Value;
		TextReader input = new StringReader(value);
		XmlReader result = new XmlTextReader(input);
		value = null;
		input = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::GetXmlReader()\n");
		}
		return result;
	}

	public bool IsExists(string xpathExpr, string nsMap)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::IsExists(xpath, nsmap)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleXmlType::IsExists(xpath, nsmap)\n");
			}
			return false;
		}
		if (xpathExpr == null || xpathExpr.Length == 0)
		{
			throw new ArgumentNullException("xpathExpr", (string)null);
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
		int pResult = 0;
		try
		{
			num = OpsXmlType.Exists(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, xpathExpr, nsMap, ref pResult);
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
				HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::IsExists(xpath, nsmap)\n");
		}
		if (pResult == 1)
		{
			return true;
		}
		return false;
	}

	public bool IsExists(string xpathExpr, XmlNamespaceManager nsMgr)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::IsExists(xpath, nsmgr)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleXmlType::IsExists(xpath, nsmgr)\n");
			}
			return false;
		}
		string nsMap = NsMgrToString(nsMgr);
		bool result = IsExists(xpathExpr, nsMap);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::IsExists(xpath, nsmgr)\n");
		}
		return result;
	}

	public OracleXmlType Transform(OracleXmlType xsldoc, string paramMap)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Transform(xmltypexsldoc, paramMap)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (xsldoc == null)
		{
			throw new ArgumentNullException("xsldoc", (string)null);
		}
		int num = 0;
		IntPtr zero = IntPtr.Zero;
		IntPtr ppOpsXmlTypeCtx_result = IntPtr.Zero;
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		zero = xsldoc.OpsXmlTypeCtx;
		try
		{
			num = OpsXmlType.Transform(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, zero, 4, paramMap, ref ppOpsXmlTypeCtx_result);
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
				HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Transform(xmltypexsldoc, paramMap)\n");
		}
		if (IntPtr.Zero == ppOpsXmlTypeCtx_result)
		{
			return new OracleXmlType(m_connection);
		}
		return new OracleXmlType(m_connection, ppOpsXmlTypeCtx_result, flag: false);
	}

	public OracleXmlType Transform(string xsldoc, string paramMap)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Transform(stringxsldoc, paramMap)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (xsldoc == null || xsldoc.Length == 0)
		{
			throw new ArgumentNullException("xsldoc", (string)null);
		}
		int num = 0;
		IntPtr ppOpsXmlTypeCtx_result = IntPtr.Zero;
		GCHandle gCHandle = GCHandle.Alloc(xsldoc, GCHandleType.Pinned);
		IntPtr pBuffer = gCHandle.AddrOfPinnedObject();
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
			num = OpsXmlType.Transform(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, pBuffer, 1, paramMap, ref ppOpsXmlTypeCtx_result);
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
				HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Transform(stringxsldoc, paramMap)\n");
		}
		if (IntPtr.Zero == ppOpsXmlTypeCtx_result)
		{
			return new OracleXmlType(m_connection);
		}
		return new OracleXmlType(m_connection, ppOpsXmlTypeCtx_result, flag: false);
	}

	public unsafe void Update(string xpathExpr, string nsMap, OracleXmlType val)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Update(xpathexpr, nsmap, xmltypeval)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (xpathExpr == null || xpathExpr.Length == 0 || val == null)
		{
			throw new ArgumentNullException("xpathExpr or val", (string)null);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (nsMap != null && nsMap.Length == 0)
		{
			nsMap = null;
		}
		int num = 0;
		IntPtr ppNewOpsXmlTypeCtx = IntPtr.Zero;
		try
		{
			num = OpsXmlType.Copy(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, ref ppNewOpsXmlTypeCtx);
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
			HandleError(num, m_connection, m_opsErrCtx, this);
		}
		try
		{
			OpsXmlType.RelRef(m_opsConCtx, m_opsErrCtx, ref m_opsXmlTypeCtx, m_bFreeOciXmlType);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
		}
		m_opsXmlTypeCtx = ppNewOpsXmlTypeCtx;
		m_value = null;
		try
		{
			num = OpsXmlType.UpdateFromXmlType(m_opsConCtx, m_opsErrCtx, ppNewOpsXmlTypeCtx, xpathExpr, nsMap, val.OpsXmlTypeCtx);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		if (num != 0)
		{
			HandleError(num, m_connection, m_opsErrCtx, this);
		}
		m_pOpoXmlTypeValCtx->isFragment = 2;
		m_pOpoXmlTypeValCtx->isSchemaBased = 2;
		m_pOpoXmlTypeValCtx->isEmpty = 2;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Update(xpathexpr, nsmap, xmltypeval)\n");
		}
	}

	public void Update(string xpathExpr, XmlNamespaceManager nsMgr, OracleXmlType val)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Update(xpathexpr, nsmgr, xmltypeval)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		string nsMap = NsMgrToString(nsMgr);
		Update(xpathExpr, nsMap, val);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Update(xpathexpr, nsmgr, xmltypeval)\n");
		}
	}

	public unsafe void Update(string xpathExpr, string nsMap, string val)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Update(xpathexpr, nsmap, stringval)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (xpathExpr == null || xpathExpr.Length == 0)
		{
			throw new ArgumentNullException("xpathExpr", (string)null);
		}
		if (nsMap != null && nsMap.Length == 0)
		{
			nsMap = null;
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
		IntPtr ppNewOpsXmlTypeCtx = IntPtr.Zero;
		try
		{
			num = OpsXmlType.Copy(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, ref ppNewOpsXmlTypeCtx);
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
			HandleError(num, m_connection, m_opsErrCtx, this);
		}
		try
		{
			OpsXmlType.RelRef(m_opsConCtx, m_opsErrCtx, ref m_opsXmlTypeCtx, m_bFreeOciXmlType);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
		}
		m_opsXmlTypeCtx = ppNewOpsXmlTypeCtx;
		m_value = null;
		try
		{
			num = OpsXmlType.UpdateFromString(m_opsConCtx, m_opsErrCtx, ppNewOpsXmlTypeCtx, xpathExpr, nsMap, val);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		if (num != 0)
		{
			HandleError(num, m_connection, m_opsErrCtx, this);
		}
		m_pOpoXmlTypeValCtx->isFragment = 2;
		m_pOpoXmlTypeValCtx->isSchemaBased = 2;
		m_pOpoXmlTypeValCtx->isEmpty = 2;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Update(xpathexpr, nsmap, stringval)\n");
		}
	}

	public void Update(string xpathExpr, XmlNamespaceManager nsMgr, string val)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Update(xpathexpr, nsmgr, stringval)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		string nsMap = NsMgrToString(nsMgr);
		Update(xpathExpr, nsMap, val);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Update(xpathexpr, nsmgr, stringval)\n");
		}
	}

	public bool Validate(string schemaUrl)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleXmlType::Validate(schemaurl)\n");
		}
		if (m_doneDispose)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (!m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		if (schemaUrl == null || schemaUrl.Length == 0)
		{
			throw new ArgumentNullException("schemaUrl", (string)null);
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
		int pResult = 0;
		try
		{
			num = OpsXmlType.Validate(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, schemaUrl, ref pResult);
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
				HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleXmlType::Validate(schemaurl)\n");
		}
		if (1 == pResult)
		{
			return true;
		}
		return false;
	}

	~OracleXmlType()
	{
		Dispose();
	}

	private unsafe void Initialize(OracleConnection con, string xmlData, OracleClob clob, int flag)
	{
		int num = 0;
		IntPtr zero = IntPtr.Zero;
		GCHandle gCHandle = default(GCHandle);
		m_opsConCtx = con.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (1 == flag)
		{
			gCHandle = GCHandle.Alloc(xmlData, GCHandleType.Pinned);
			zero = gCHandle.AddrOfPinnedObject();
		}
		else
		{
			if (con.m_conSignature != clob.m_connection.m_conSignature)
			{
				GC.SuppressFinalize(this);
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			zero = clob.LobCtx;
		}
		m_opoXmlTypeRefCtx = new OpoXmlTypeRefCtx();
		try
		{
			num = OpsXmlType.AllocXmlTypeCtx(m_opsConCtx, ref m_opsXmlTypeCtx, ref m_opsErrCtx, ref m_pOpoXmlTypeValCtx, zero, flag);
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
		finally
		{
			if (1 == flag && gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
			if (num != 0)
			{
				GC.SuppressFinalize(this);
				throw new OracleTypeException(num, "xml");
			}
		}
		m_pOpoXmlTypeValCtx->isFragment = 2;
		m_pOpoXmlTypeValCtx->isSchemaBased = 2;
		m_pOpoXmlTypeValCtx->isEmpty = 2;
		m_connection = con;
		m_conSignature = con.m_conSignature;
	}

	private void GetSchemaFromOPS()
	{
		if (m_doneGetSchema)
		{
			return;
		}
		m_doneGetSchema = true;
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
			num = OpsXmlType.GetSchema(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx, ref m_opoXmlTypeRefCtx);
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
				HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (m_opoXmlTypeRefCtx.rootElement == null)
		{
			m_opoXmlTypeRefCtx.rootElement = string.Empty;
		}
		if (m_opoXmlTypeRefCtx.schemaUrl == null)
		{
			m_opoXmlTypeRefCtx.schemaUrl = string.Empty;
		}
	}

	private void HandleError(int errCode, OracleConnection conn, IntPtr opsErrCtx, object src)
	{
		if (IntPtr.Zero == opsErrCtx)
		{
			string dataSrc = ((conn != null) ? conn.DataSource : string.Empty);
			throw new OracleException(errCode, dataSrc, string.Empty, string.Empty);
		}
		OracleException.HandleError(errCode, conn, opsErrCtx, src);
	}

	private string NsMgrToString(XmlNamespaceManager nsMgr)
	{
		string text = null;
		if (nsMgr != null)
		{
			text = string.Empty;
			foreach (string item in nsMgr)
			{
				string text3 = nsMgr.LookupNamespace(item);
				if ((item != null && item.Length != 0) || (text3 != null && text3.Length != 0))
				{
					StringBuilder stringBuilder = new StringBuilder(text, 1024);
					if (text != null && text.Length != 0)
					{
						stringBuilder.Append(' ');
					}
					stringBuilder.Append("xmlns:");
					stringBuilder.Append(item);
					stringBuilder.Append('=');
					stringBuilder.Append(text3);
					text = stringBuilder.ToString();
					stringBuilder = null;
				}
			}
		}
		return text;
	}
}

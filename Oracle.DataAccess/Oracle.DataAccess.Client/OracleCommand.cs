using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.Metadata.Edm;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Xml;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

[Designer("Oracle.VsDevTools.OracleVSGCommandDesigner, Oracle.VsDevTools, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342, processorArchitecture=X86", typeof(IDesigner))]
[ToolboxBitmap(typeof(resfinder), "Oracle.DataAccess.src.Client.Icons.OracleCommandToolBox_hc.bmp")]
[SecurityPermission(SecurityAction.Assert, ControlThread = true)]
public sealed class OracleCommand : DbCommand, ICloneable
{
	internal const int m_rowsToFetch = 1024;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsSqlCtx;

	private IntPtr m_opsDacCtx;

	internal unsafe OpoSqlValCtx* m_pOpoSqlValCtx;

	private IntPtr m_opsErrCtx;

	private MetaData m_metaData;

	private UTF8CommandText m_utf8CmdText;

	private OracleConnection m_connection;

	private OracleParameterCollection m_parameters;

	private UpdateRowSource m_updatedRowSource;

	private string m_commandText;

	private string m_pooledCmdText;

	private CommandType m_commandType;

	internal bool m_disposed;

	private bool m_addRowid;

	private int m_rowsAffected;

	private long m_fetchSize;

	private bool m_bFetchSizePropertySet;

	internal int m_initialLongFS;

	internal int m_initialLobFS;

	private bool m_executeScalar;

	private bool m_bindByName;

	private int m_arrayBindCount;

	private bool m_parsed;

	private bool m_addParam;

	private OracleDataReader m_cachedReader;

	internal Hashtable m_safeMapping;

	internal bool m_modified;

	private int m_conSignature;

	private bool m_selectStmt;

	private bool m_cmdTxtModified;

	private OracleXmlCommandType m_xmlCommandType;

	private OracleXmlQueryProperties m_xmlQueryProperties;

	private OracleXmlSaveProperties m_xmlSaveProperties;

	internal bool m_addToStatementCache;

	private int m_commandTimeout;

	internal OracleNotificationRequest m_NTFNReq;

	internal bool m_NTFNAutoEnlist;

	internal bool m_designTimeVisible;

	internal bool m_localParse;

	private bool m_addToStmtCache;

	private unsafe OpoPrmCtx* m_pOpoPrmCtx;

	internal bool m_returnPSTypes;

	private PrimitiveType[] m_expectedColumnTypes;

	internal bool m_isFromEF;

	protected override DbConnection DbConnection
	{
		get
		{
			return m_connection;
		}
		set
		{
			Connection = (OracleConnection)value;
		}
	}

	[DefaultValue(null)]
	[Category("Behavior")]
	[Description("")]
	public new OracleConnection Connection
	{
		get
		{
			return m_connection;
		}
		set
		{
			if (m_connection == value && (value == null || m_conSignature == value.m_conSignature))
			{
				return;
			}
			if (m_metaData != null)
			{
				m_metaData = null;
			}
			if (m_opsSqlCtx != IntPtr.Zero)
			{
				try
				{
					if (!m_addToStmtCache)
					{
						OpsSql.FreeCtx(ref m_opsSqlCtx, m_opsErrCtx, 0);
					}
					else
					{
						OpsSql.FreeCtx(ref m_opsSqlCtx, m_opsErrCtx, 1);
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
			if (m_opsErrCtx != IntPtr.Zero)
			{
				try
				{
					OpsErr.FreeCtx(ref m_opsErrCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_opsErrCtx = IntPtr.Zero;
			}
			m_connection = value;
			if (m_connection != null)
			{
				m_conSignature = m_connection.m_conSignature;
			}
			else
			{
				m_conSignature = 0;
			}
		}
	}

	[Description("")]
	[DefaultValue("")]
	[Category("Data")]
	public override string CommandText
	{
		get
		{
			if (m_commandText != null)
			{
				return m_commandText;
			}
			return string.Empty;
		}
		set
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleCommand::CommandText(): set\n");
			}
			if (m_commandText != value)
			{
				m_commandText = value;
				m_parsed = false;
				m_addParam = true;
				m_selectStmt = false;
				m_cmdTxtModified = true;
				m_metaData = null;
				m_utf8CmdText = null;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleCommand::CommandText(): set\n");
			}
		}
	}

	[DefaultValue(true)]
	[Description("")]
	[Category("Behavior")]
	public bool AddToStatementCache
	{
		get
		{
			return m_addToStatementCache;
		}
		set
		{
			if (m_addToStatementCache != value)
			{
				m_addToStatementCache = value;
			}
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	[Description("")]
	public bool AddRowid
	{
		get
		{
			return m_addRowid;
		}
		set
		{
			if (m_addRowid != value)
			{
				m_addRowid = value;
				if (m_addRowid)
				{
					m_localParse = true;
				}
				m_modified = true;
			}
		}
	}

	protected override DbTransaction DbTransaction
	{
		get
		{
			if (OracleConnection.IsAvailable)
			{
				return null;
			}
			if (m_connection == null)
			{
				return null;
			}
			if (m_connection.m_oraTransaction == null)
			{
				return null;
			}
			return m_connection.m_oraTransaction;
		}
		set
		{
		}
	}

	[Browsable(false)]
	public new OracleTransaction Transaction
	{
		get
		{
			if (OracleConnection.IsAvailable)
			{
				return null;
			}
			if (m_connection == null)
			{
				return null;
			}
			if (m_connection.m_oraTransaction == null)
			{
				return null;
			}
			return m_connection.m_oraTransaction;
		}
		set
		{
		}
	}

	protected override DbParameterCollection DbParameterCollection
	{
		get
		{
			if (m_parameters == null)
			{
				m_parameters = new OracleParameterCollection();
			}
			return m_parameters;
		}
	}

	[Description("")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Data")]
	public new OracleParameterCollection Parameters
	{
		get
		{
			if (m_parameters == null)
			{
				m_parameters = new OracleParameterCollection();
			}
			return m_parameters;
		}
	}

	[Category("Data")]
	[DefaultValue(CommandType.Text)]
	[Description("")]
	public override CommandType CommandType
	{
		get
		{
			return m_commandType;
		}
		set
		{
			if (m_commandType != value)
			{
				if (value != CommandType.Text && value != CommandType.StoredProcedure && value != CommandType.TableDirect)
				{
					throw new ArgumentException();
				}
				m_commandType = value;
				m_parsed = false;
				m_addParam = true;
				m_modified = true;
				m_selectStmt = false;
				m_cmdTxtModified = true;
			}
		}
	}

	[DefaultValue(OracleXmlCommandType.None)]
	[Category("Data")]
	[Description("")]
	public OracleXmlCommandType XmlCommandType
	{
		get
		{
			return m_xmlCommandType;
		}
		set
		{
			if (m_xmlCommandType != value)
			{
				m_xmlCommandType = value;
				m_parsed = false;
				m_addParam = true;
				m_modified = true;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public OracleXmlQueryProperties XmlQueryProperties
	{
		get
		{
			if (m_xmlQueryProperties == null)
			{
				m_xmlQueryProperties = new OracleXmlQueryProperties();
			}
			return m_xmlQueryProperties;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			m_xmlQueryProperties = (OracleXmlQueryProperties)value.Clone();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public OracleXmlSaveProperties XmlSaveProperties
	{
		get
		{
			if (m_xmlSaveProperties == null)
			{
				m_xmlSaveProperties = new OracleXmlSaveProperties();
			}
			return m_xmlSaveProperties;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			m_xmlSaveProperties = (OracleXmlSaveProperties)value.Clone();
		}
	}

	[DefaultValue(UpdateRowSource.Both)]
	[Description("")]
	[Category("Behavior")]
	public override UpdateRowSource UpdatedRowSource
	{
		get
		{
			return m_updatedRowSource;
		}
		set
		{
			if (m_updatedRowSource != value)
			{
				if (value != UpdateRowSource.Both && value != UpdateRowSource.FirstReturnedRecord && value != 0 && value != UpdateRowSource.OutputParameters)
				{
					throw new ArgumentException();
				}
				m_updatedRowSource = value;
				m_modified = true;
			}
		}
	}

	[DefaultValue(0)]
	[Browsable(false)]
	public override int CommandTimeout
	{
		get
		{
			return m_commandTimeout;
		}
		set
		{
			if (value < 0 || value > int.MaxValue)
			{
				throw new ArgumentException();
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleCommand::CommandTimeout(): set\n");
			}
			m_commandTimeout = value;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleCommand::CommandTimeout(): set\n");
			}
		}
	}

	[DefaultValue(131072L)]
	[Description("")]
	public long FetchSize
	{
		get
		{
			return m_fetchSize;
		}
		set
		{
			if (m_fetchSize != value)
			{
				if (value <= 0)
				{
					throw new ArgumentException();
				}
				m_fetchSize = value;
				m_modified = true;
			}
			m_bFetchSizePropertySet = true;
		}
	}

	[DefaultValue(0)]
	[Browsable(false)]
	public unsafe long RowSize
	{
		get
		{
			if (m_metaData != null)
			{
				if (m_addRowid && m_metaData.m_pOpoMetValCtxWRowid != null)
				{
					return m_metaData.m_pOpoMetValCtxWRowid->pColMetaVal[m_metaData.m_pOpoMetValCtxWRowid->NoOfCols - 1].Offset;
				}
				if (!m_addRowid && m_metaData.m_pOpoMetValCtx != null)
				{
					return m_metaData.m_pOpoMetValCtx->pColMetaVal[m_metaData.m_pOpoMetValCtx->NoOfCols - 1].Offset;
				}
			}
			return 0L;
		}
	}

	[Description("")]
	[DefaultValue(0)]
	public int InitialLONGFetchSize
	{
		get
		{
			return m_initialLongFS;
		}
		set
		{
			if (m_initialLongFS != value)
			{
				if (value < -1)
				{
					throw new ArgumentException();
				}
				m_initialLongFS = value;
				if (m_initialLongFS > 32767)
				{
					m_initialLongFS = 32767;
				}
				if (m_metaData != null)
				{
					m_metaData = null;
				}
				m_modified = true;
			}
		}
	}

	[DefaultValue(0)]
	[Description("")]
	public int InitialLOBFetchSize
	{
		get
		{
			return m_initialLobFS;
		}
		set
		{
			if (m_initialLobFS != value)
			{
				if (value < -1)
				{
					throw new ArgumentException();
				}
				m_initialLobFS = value;
				if (m_metaData != null)
				{
					m_metaData = null;
				}
				m_modified = true;
			}
		}
	}

	[Description("")]
	[DefaultValue(false)]
	[Category("Behavior")]
	public bool BindByName
	{
		get
		{
			return m_bindByName;
		}
		set
		{
			if (m_bindByName != value)
			{
				m_bindByName = value;
				m_modified = true;
			}
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	public int ArrayBindCount
	{
		get
		{
			return m_arrayBindCount;
		}
		set
		{
			if (m_arrayBindCount != value)
			{
				if (value < 0)
				{
					throw new ArgumentException();
				}
				m_arrayBindCount = value;
				m_modified = true;
			}
		}
	}

	[Browsable(false)]
	[DefaultValue(null)]
	public OracleNotificationRequest Notification
	{
		get
		{
			return m_NTFNReq;
		}
		set
		{
			m_NTFNReq = value;
		}
	}

	[DefaultValue(true)]
	[Browsable(false)]
	public bool NotificationAutoEnlist
	{
		get
		{
			return m_NTFNAutoEnlist;
		}
		set
		{
			m_NTFNAutoEnlist = value;
		}
	}

	[DesignOnly(true)]
	[Browsable(false)]
	[DefaultValue(true)]
	public override bool DesignTimeVisible
	{
		get
		{
			return m_designTimeVisible;
		}
		set
		{
			m_designTimeVisible = value;
		}
	}

	internal PrimitiveType[] ExpectedColumnTypes
	{
		get
		{
			return m_expectedColumnTypes;
		}
		set
		{
			m_expectedColumnTypes = value;
		}
	}

	static OracleCommand()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::OracleCommand(1)\n");
		}
		Initialize();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::OracleCommand(1)\n");
		}
	}

	public OracleCommand(string cmdText)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::OracleCommand(2)\n");
		}
		Initialize();
		m_commandText = cmdText;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::OracleCommand(2)\n");
		}
	}

	public OracleCommand(string cmdText, OracleConnection conn)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::OracleCommand(3)\n");
		}
		Initialize();
		m_commandText = cmdText;
		if (conn != null)
		{
			m_connection = conn;
			m_conSignature = m_connection.m_conSignature;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::OracleCommand(3)\n");
		}
	}

	public object Clone()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::Clone()\n");
		}
		OracleCommand oracleCommand = new OracleCommand();
		oracleCommand.m_connection = m_connection;
		oracleCommand.m_conSignature = m_conSignature;
		oracleCommand.m_updatedRowSource = m_updatedRowSource;
		oracleCommand.m_commandText = m_commandText;
		oracleCommand.m_pooledCmdText = m_pooledCmdText;
		oracleCommand.m_commandType = m_commandType;
		oracleCommand.m_addRowid = m_addRowid;
		oracleCommand.m_localParse = m_localParse;
		oracleCommand.m_rowsAffected = m_rowsAffected;
		oracleCommand.m_fetchSize = m_fetchSize;
		oracleCommand.m_initialLongFS = m_initialLongFS;
		oracleCommand.m_initialLobFS = m_initialLobFS;
		oracleCommand.m_bindByName = m_bindByName;
		oracleCommand.m_arrayBindCount = m_arrayBindCount;
		oracleCommand.m_parsed = m_parsed;
		oracleCommand.m_addParam = m_addParam;
		oracleCommand.m_safeMapping = m_safeMapping;
		oracleCommand.m_modified = m_modified;
		oracleCommand.m_selectStmt = m_selectStmt;
		oracleCommand.m_cmdTxtModified = m_cmdTxtModified;
		oracleCommand.CommandTimeout = m_commandTimeout;
		oracleCommand.m_bFetchSizePropertySet = m_bFetchSizePropertySet;
		if (m_expectedColumnTypes != null)
		{
			oracleCommand.m_expectedColumnTypes = m_expectedColumnTypes;
		}
		oracleCommand.m_isFromEF = m_isFromEF;
		if (m_parameters != null)
		{
			oracleCommand.m_parameters = new OracleParameterCollection();
			foreach (OracleParameter parameter in m_parameters)
			{
				oracleCommand.m_parameters.Add(parameter.Clone());
			}
		}
		else
		{
			oracleCommand.m_parameters = null;
		}
		oracleCommand.m_cachedReader = m_cachedReader;
		if (m_xmlQueryProperties != null)
		{
			oracleCommand.m_xmlQueryProperties = (OracleXmlQueryProperties)m_xmlQueryProperties.Clone();
		}
		if (m_xmlSaveProperties != null)
		{
			oracleCommand.m_xmlSaveProperties = (OracleXmlSaveProperties)m_xmlSaveProperties.Clone();
		}
		oracleCommand.m_xmlCommandType = m_xmlCommandType;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::Clone()\n");
		}
		return oracleCommand;
	}

	public override void Prepare()
	{
	}

	internal unsafe MetaData InternalPrepare(bool openCon)
	{
		OpoMetValCtx* pOpoMetValCtx = null;
		int num = 0;
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		CheckConStatus();
		if (m_cmdTxtModified)
		{
			if (m_commandText == null || m_commandText.Length == 0)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "CommandText"));
			}
			if (m_commandType == CommandType.Text)
			{
				m_selectStmt = isSelectStatement(m_commandText);
				m_pooledCmdText = m_commandText;
			}
			else if (m_commandType == CommandType.TableDirect)
			{
				m_selectStmt = true;
				m_pooledCmdText = "Select * from " + m_commandText;
			}
			else
			{
				m_selectStmt = false;
				m_pooledCmdText = m_commandText;
			}
			m_cmdTxtModified = false;
		}
		if (!m_selectStmt)
		{
			return null;
		}
		int metaPool = m_connection.m_opoConCtx.metaPool;
		if (m_metaData != null && metaPool == 0)
		{
			m_metaData = null;
		}
		if (m_metaData != null && ((!m_addRowid && m_metaData.m_pOpoMetValCtx != null) || (m_addRowid && m_metaData.m_pOpoMetValCtxWRowid != null)))
		{
			return m_metaData;
		}
		if (metaPool == 1 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)) && m_connection.m_opoConCtx.m_conPooler.Get(m_pooledCmdText) is MetaData metaData && ((!m_addRowid && metaData.m_pOpoMetValCtx != null) || (m_addRowid && metaData.m_pOpoMetValCtxWRowid != null)))
		{
			m_metaData = metaData;
			return m_metaData;
		}
		SetSqlValCtx(bXmlQuerySave: false);
		m_pOpoSqlValCtx->LocalParse = 1;
		try
		{
			m_pOpoSqlValCtx->pOpoPrmCtx = null;
			m_opsDacCtx = IntPtr.Zero;
			num = OpsSql.Prepare(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, ref m_pOpoSqlValCtx, m_pooledCmdText, ref pOpoMetValCtx);
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
			if (!m_localParse)
			{
				m_pOpoSqlValCtx->LocalParse = 0;
			}
			if (num != 0)
			{
				OracleException.HandleError(procedure: (m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText, errCode: num, conn: m_connection, opsErrCtx: m_opsErrCtx, pOpoSqlValCtx: m_pOpoSqlValCtx, src: this);
			}
		}
		if (pOpoMetValCtx != null)
		{
			MetaData metaData2 = null;
			if (metaPool == 1 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)))
			{
				metaData2 = m_connection.m_opoConCtx.m_conPooler.Get(m_pooledCmdText) as MetaData;
			}
			if (metaData2 == null || (!m_addRowid && metaData2.m_pOpoMetValCtx == null) || (m_addRowid && metaData2.m_pOpoMetValCtxWRowid == null))
			{
				pOpoMetValCtx->bPooled = 1;
				if (metaData2 == null)
				{
					if (m_metaData == null)
					{
						m_metaData = new MetaData();
					}
					m_metaData.m_addParam = m_addParam;
					m_metaData.m_parsed = m_parsed;
				}
				else
				{
					m_metaData = metaData2;
				}
				if (!m_addRowid && m_metaData.m_pOpoMetValCtx == null)
				{
					m_metaData.m_pOpoMetValCtx = pOpoMetValCtx;
				}
				else if (m_addRowid && m_metaData.m_pOpoMetValCtxWRowid == null)
				{
					m_metaData.m_pOpoMetValCtxWRowid = pOpoMetValCtx;
				}
				if (metaPool == 1 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)))
				{
					m_connection.m_opoConCtx.m_conPooler.Put(m_pooledCmdText, m_metaData);
				}
			}
			else if (m_metaData == null)
			{
				m_metaData = metaData2;
				if (pOpoMetValCtx->bPooled == 0)
				{
					OpsMet.FreeValCtx(pOpoMetValCtx);
				}
			}
			return m_metaData;
		}
		return null;
	}

	internal unsafe void GetPrimaryKey(MetaData metadata, bool openCon)
	{
		int num = 0;
		OpoMetValCtx* ptr = null;
		ptr = (m_addRowid ? metadata.m_pOpoMetValCtxWRowid : metadata.m_pOpoMetValCtx);
		if (m_cmdTxtModified)
		{
			if (m_commandText == null || m_commandText.Length == 0)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "CommandText"));
			}
			if (m_commandType == CommandType.Text)
			{
				m_selectStmt = isSelectStatement(m_commandText);
				m_pooledCmdText = m_commandText;
			}
			else if (m_commandType == CommandType.TableDirect)
			{
				m_selectStmt = true;
				m_pooledCmdText = "Select * from " + m_commandText;
			}
			else
			{
				m_selectStmt = false;
				m_pooledCmdText = m_commandText;
			}
			m_cmdTxtModified = false;
		}
		if (!m_selectStmt)
		{
			return;
		}
		CheckConStatus();
		if (m_opsErrCtx == IntPtr.Zero)
		{
			try
			{
				OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
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
		if (m_pOpoSqlValCtx == null)
		{
			try
			{
				OpsSql.AllocSqlValCtx(ref m_pOpoSqlValCtx);
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
		try
		{
			num = OpsMet.GetPrimaryKey(m_opsConCtx, m_opsErrCtx, ptr, 1, m_pOpoSqlValCtx->AddRowid, m_pOpoSqlValCtx->AddToStmtCache);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
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
		MetaData metaData = null;
		int metaPool = m_connection.m_opoConCtx.metaPool;
		if (metaPool == 1 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)))
		{
			metaData = m_connection.m_opoConCtx.m_conPooler.Get(m_pooledCmdText) as MetaData;
		}
		if (metaData == null || (!m_addRowid && (metaData.m_pOpoMetValCtx == null || metaData.m_pOpoMetValCtx->bPkFetched == 0)) || (m_addRowid && (metaData.m_pOpoMetValCtxWRowid == null || metaData.m_pOpoMetValCtxWRowid->bPkFetched == 0)))
		{
			ptr->bPooled = 1;
			if (metaData != null)
			{
				m_metaData = metaData;
			}
			if (m_metaData == null || (!m_addRowid && m_metaData.m_pOpoMetValCtx == null) || (m_addRowid && m_metaData.m_pOpoMetValCtxWRowid == null))
			{
				m_metaData = metadata;
			}
			if (metaPool == 1 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)))
			{
				m_connection.m_opoConCtx.m_conPooler.Put(m_pooledCmdText, m_metaData);
			}
		}
		else if (m_metaData == null)
		{
			m_metaData = metaData;
		}
	}

	public new OracleDataReader ExecuteReader()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::ExecuteReader()\n");
		}
		OracleDataReader result = ExecuteReader(requery: true, fillRequest: false, CommandBehavior.Default);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::ExecuteReader()\n");
		}
		return result;
	}

	internal unsafe OracleDataReader ExecuteReader(bool requery, bool fillRequest, CommandBehavior behavior)
	{
		OracleDataReader oracleDataReader = null;
		IntPtr[] array = null;
		string[] array2 = null;
		IntPtr[] array3 = null;
		IntPtr opsSubscrCtx = IntPtr.Zero;
		int isSubscrRegistered = 0;
		OracleDependency dep = null;
		int num = 0;
		int bchgNTFNExcludeRowidInfo = 0;
		long query_id = 0L;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		MetaData metaData = null;
		OracleParameter oracleParameter = null;
		IntPtr opsReaderErrCtx = IntPtr.Zero;
		OpoDacValCtx* pOpoDacValCtx = null;
		bool flag = false;
		bool flag2 = false;
		CmdTimeoutCtx cmdTimeoutCtx = null;
		Timer timer = null;
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		if (m_cmdTxtModified && (m_commandText == null || m_commandText.Length == 0))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
		}
		if (m_xmlCommandType != 0)
		{
			throw new InvalidOperationException();
		}
		if (!requery && m_cachedReader != null)
		{
			return m_cachedReader;
		}
		if (fillRequest && requery)
		{
			if (m_cachedReader != null)
			{
				if (!m_cachedReader.IsClosed)
				{
					m_cachedReader.Close();
				}
				m_cachedReader = null;
			}
			if (m_connection.m_state == ConnectionState.Closed)
			{
				m_connection.Open();
				behavior |= CommandBehavior.CloseConnection;
			}
		}
		CheckConStatus();
		int metaPool = m_connection.m_opoConCtx.metaPool;
		if (m_cmdTxtModified || m_commandType == CommandType.StoredProcedure)
		{
			if (m_commandType == CommandType.Text)
			{
				m_selectStmt = isSelectStatement(m_commandText);
				m_pooledCmdText = m_commandText;
			}
			else if (m_commandType == CommandType.TableDirect)
			{
				m_selectStmt = true;
				m_pooledCmdText = "Select * from " + m_commandText;
			}
			else if (m_commandType == CommandType.StoredProcedure)
			{
				BuildCommandText();
				m_selectStmt = false;
				m_utf8CmdText = null;
				m_addParam = true;
			}
			if (m_metaData == null && m_selectStmt && metaPool == 1 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)) && m_connection.m_opoConCtx.m_conPooler.Get(m_pooledCmdText) is MetaData metaData2)
			{
				m_metaData = metaData2;
				flag2 = true;
			}
			if (m_metaData != null)
			{
				m_addParam = m_metaData.m_addParam;
				m_parsed = m_metaData.m_parsed;
			}
			if (!m_parsed && m_commandType == CommandType.Text)
			{
				ParseCommandText();
			}
			m_cmdTxtModified = false;
		}
		if (m_NTFNReq != null && m_NTFNAutoEnlist && !m_connection.m_contextConnection && OracleNotificationRequest.s_idTable[m_NTFNReq.Id] != null)
		{
			opsSubscrCtx = OracleNotificationRequest.PopulateChgNTFNSubscrCtx(this, m_addRowid, out dep);
			if (dep != null && dep.m_bIsRegistered)
			{
				isSubscrRegistered = 1;
			}
			if (dep != null)
			{
				if (dep.m_OracleRowidInfo == OracleRowidInfo.Exclude)
				{
					bchgNTFNExcludeRowidInfo = 1;
				}
				if (dep.QueryBasedNotification && m_connection.IsDBVer11gR1OrHigher)
				{
					num = 1;
				}
			}
		}
		if (m_bindByName && m_commandType != CommandType.StoredProcedure)
		{
			flag = true;
		}
		if (m_metaData != null && metaPool == 0)
		{
			m_metaData = null;
		}
		OpoMetValCtx* pOpoMetValCtx = null;
		if (m_metaData != null)
		{
			pOpoMetValCtx = (m_addRowid ? m_metaData.m_pOpoMetValCtxWRowid : m_metaData.m_pOpoMetValCtx);
		}
		SetSqlValCtx(bXmlQuerySave: false);
		if ((behavior & CommandBehavior.SchemaOnly) == CommandBehavior.SchemaOnly && m_selectStmt)
		{
			m_pOpoSqlValCtx->mode = 16u;
		}
		if (m_executeScalar)
		{
			m_pOpoSqlValCtx->FetchSize = 1L;
		}
		m_opsDacCtx = IntPtr.Zero;
		if (m_addParam && m_parameters != null)
		{
			num3 = m_parameters.Count;
			if (num3 > 0 && (m_addToStmtCache || m_pOpoPrmCtx == null || m_pOpoPrmCtx->NumValCtxElems < num3))
			{
				IntPtr pUTF8CommandText = IntPtr.Zero;
				try
				{
					bool flag3 = pOpoMetValCtx != null && pOpoMetValCtx->pNewCommandText != IntPtr.Zero;
					num2 = OpsSql.Prepare2(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, ref m_pOpoSqlValCtx, flag3 ? null : m_pooledCmdText, ref pUTF8CommandText, ref pOpoMetValCtx, num3);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num2 = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					m_executeScalar = false;
					if (pUTF8CommandText != IntPtr.Zero)
					{
						try
						{
							Marshal.FreeCoTaskMem(pUTF8CommandText);
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
					}
					if (num2 != 0)
					{
						if (!m_addToStmtCache && m_pOpoSqlValCtx->pOpoPrmCtx == null)
						{
							m_pOpoPrmCtx = null;
						}
						if (num2 != ErrRes.INT_ERR)
						{
							OracleException.HandleError(procedure: (m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText, errCode: num2, conn: m_connection, opsErrCtx: m_opsErrCtx, pOpoSqlValCtx: m_pOpoSqlValCtx, src: this);
						}
					}
				}
				if (!m_addToStmtCache && m_pOpoPrmCtx == null)
				{
					m_pOpoPrmCtx = m_pOpoSqlValCtx->pOpoPrmCtx;
				}
			}
			if (flag)
			{
				array2 = new string[num3];
			}
			array3 = new IntPtr[num3];
			for (int i = 0; i < num3; i++)
			{
				oracleParameter = m_parameters[i];
				oracleParameter.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + i;
				try
				{
					oracleParameter.PreBind(m_connection, m_opsErrCtx, m_arrayBindCount, m_isFromEF, m_selectStmt);
				}
				catch (Exception)
				{
					for (int j = 0; j < i; j++)
					{
						oracleParameter = m_parameters[j];
						oracleParameter.PreBindFree(m_connection, m_arrayBindCount);
					}
					FreeNonCachedOpoPrmCtx();
					throw;
				}
				if (flag)
				{
					array2[i] = oracleParameter.m_paramName;
				}
				ref IntPtr reference = ref array3[i];
				reference = (IntPtr)oracleParameter.m_pOpoPrmValCtx;
			}
		}
		try
		{
			if (m_commandTimeout > 0)
			{
				cmdTimeoutCtx = new CmdTimeoutCtx(m_opsConCtx, m_commandTimeout);
				TimerCallback callback = cmdTimeoutCtx.TimeoutNew;
				long num5 = (long)m_commandTimeout * 1000L;
				if (num5 > 4147200000u)
				{
					num5 = 4147200000L;
				}
				timer = new Timer(callback, cmdTimeoutCtx, num5, -1L);
				if (cmdTimeoutCtx.m_bDoneOCIBreak)
				{
					string text = null;
					text = ((m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText);
					num2 = 1013;
					OracleException.HandleError(num2, m_connection, text, m_opsErrCtx, m_pOpoSqlValCtx, this);
				}
			}
			num2 = 0;
			if (m_connection.m_opoConCtx.m_bSelfTuning && m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
			{
				m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
				num2 = OpsCon.SetStatementCacheSize(m_opsConCtx, ref m_opsErrCtx, m_connection.m_opoConCtx.pOpoConValCtx);
				if (m_connection.m_opoConCtx.m_conPooler != null)
				{
					m_connection.m_opoConCtx.m_conPooler.ModifyConPoolerSize(m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize);
				}
			}
			if (num2 == 0)
			{
				num2 = ((pOpoMetValCtx == null || !(pOpoMetValCtx->pNewCommandText != IntPtr.Zero)) ? OpsSql.ExecuteReader(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, out opsReaderErrCtx, opsSubscrCtx, ref isSubscrRegistered, bchgNTFNExcludeRowidInfo, num, ref query_id, ref m_pOpoSqlValCtx, m_pooledCmdText, ref pOpoDacValCtx, array3, array2, ref pOpoMetValCtx, num3) : OpsSql.ExecuteReader(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, out opsReaderErrCtx, opsSubscrCtx, ref isSubscrRegistered, bchgNTFNExcludeRowidInfo, num, ref query_id, ref m_pOpoSqlValCtx, null, ref pOpoDacValCtx, array3, array2, ref pOpoMetValCtx, num3));
			}
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
			if (m_commandTimeout > 0 && cmdTimeoutCtx != null)
			{
				cmdTimeoutCtx.m_bDoneExecution = true;
				if (!cmdTimeoutCtx.m_hWaitForOciBreakEvent.WaitOne(5000, exitContext: false) && OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (WARN)  OracleCommand::ExecuteReader() WaitOne() timed out \n");
				}
				timer.Dispose();
				cmdTimeoutCtx.Dispose();
			}
			m_executeScalar = false;
			if (dep != null && isSubscrRegistered == 1 && !m_connection.m_contextConnection)
			{
				dep.SetRegisterInfo(m_connection.m_opoConCtx.opoConRefCtx.userID, m_connection.DataSource, m_NTFNReq.IsNotifiedOnce, m_NTFNReq.IsPersistent, m_NTFNReq.Timeout);
			}
			if (m_connection.m_contextConnection && pOpoMetValCtx != null && pOpoMetValCtx->bHasUdtType == 1)
			{
				num2 = ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN;
			}
			if (num2 != 0)
			{
				for (int i = 0; i < num3; i++)
				{
					oracleParameter = m_parameters[i];
					oracleParameter.PreBindFree(m_connection, m_arrayBindCount);
				}
				FreeNonCachedOpoPrmCtx();
				if (num2 != ErrRes.INT_ERR)
				{
					string procedure2 = ((m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText);
					if (m_isFromEF && m_connection.m_majorVersion < 12 && m_commandText.Contains(" APPLY "))
					{
						Exception innerException = new Exception(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle " + m_connection.ServerVersion.ToString(), "APPLY"));
						OracleException.HandleError(num2, m_connection, procedure2, m_opsErrCtx, m_pOpoSqlValCtx, this, bCheck: true, innerException);
					}
					else
					{
						OracleException.HandleError(num2, m_connection, procedure2, m_opsErrCtx, m_pOpoSqlValCtx, this, bCheck: true);
					}
				}
			}
		}
		if (dep != null && !m_connection.m_contextConnection)
		{
			dep.m_bIsEnabled = true;
			if (!dep.m_regList.Contains(m_commandText))
			{
				dep.m_regList.Add(m_commandText);
			}
			if (num == 1 && !dep.m_queryIDList.Contains(query_id))
			{
				dep.m_queryIDList.Add(query_id);
			}
		}
		if (pOpoMetValCtx != null && m_selectStmt)
		{
			metaData = null;
			if (metaPool == 1 && !flag2 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)))
			{
				metaData = m_connection.m_opoConCtx.m_conPooler.Get(m_pooledCmdText) as MetaData;
			}
			if (metaData == null || (!m_addRowid && metaData.m_pOpoMetValCtx == null) || (m_addRowid && metaData.m_pOpoMetValCtxWRowid == null))
			{
				pOpoMetValCtx->bPooled = 1;
				if (metaData == null)
				{
					if (m_metaData == null)
					{
						m_metaData = new MetaData();
					}
					m_metaData.m_addParam = m_addParam;
					m_metaData.m_parsed = m_parsed;
				}
				else
				{
					m_metaData = metaData;
				}
				if (!m_addRowid && m_metaData.m_pOpoMetValCtx == null)
				{
					m_metaData.m_pOpoMetValCtx = pOpoMetValCtx;
				}
				else if (m_addRowid && m_metaData.m_pOpoMetValCtxWRowid == null)
				{
					m_metaData.m_pOpoMetValCtxWRowid = pOpoMetValCtx;
				}
				if (metaPool == 1 && !flag2 && ((m_initialLongFS == 0 && m_initialLobFS == 0) || (m_isFromEF && m_initialLongFS <= 0 && m_initialLobFS <= 0)))
				{
					m_connection.m_opoConCtx.m_conPooler.Put(m_pooledCmdText, m_metaData);
				}
			}
			else if (m_metaData == null)
			{
				m_metaData = metaData;
				if (pOpoMetValCtx->bPooled == 0)
				{
					OpsMet.FreeValCtx(pOpoMetValCtx);
				}
			}
		}
		else if (!m_selectStmt && pOpoMetValCtx != null && m_pOpoSqlValCtx->CommandType == 1)
		{
			if (m_metaData == null)
			{
				m_metaData = new MetaData();
			}
			m_metaData.m_addParam = m_addParam;
			m_metaData.m_parsed = m_parsed;
			if (!m_addRowid && m_metaData.m_pOpoMetValCtx == null)
			{
				m_metaData.m_pOpoMetValCtx = pOpoMetValCtx;
			}
			else if (m_addRowid && m_metaData.m_pOpoMetValCtxWRowid == null)
			{
				m_metaData.m_pOpoMetValCtxWRowid = pOpoMetValCtx;
			}
		}
		if (m_pOpoSqlValCtx->CommandType == 1)
		{
			m_rowsAffected = -1;
		}
		else if (m_pOpoSqlValCtx->CommandType == 4 || m_pOpoSqlValCtx->CommandType == 2 || m_pOpoSqlValCtx->CommandType == 3)
		{
			m_rowsAffected = m_pOpoSqlValCtx->RowsAffected;
		}
		else
		{
			m_rowsAffected = -1;
		}
		for (int i = 0; i < num3; i++)
		{
			oracleParameter = m_parameters[i];
			if (oracleParameter.m_bOracleDbTypeExSet)
			{
				oracleParameter.m_enumType = PrmEnumType.DBTYPE;
			}
			if (oracleParameter.m_oraDbType == OracleDbType.RefCursor)
			{
				oracleParameter.m_commandText = m_commandText;
				if (m_bindByName)
				{
					oracleParameter.m_paramPosOrName = oracleParameter.ParameterName;
				}
				else
				{
					oracleParameter.m_paramPosOrName = i.ToString();
				}
			}
			oracleParameter.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array3[i];
			try
			{
				if (oracleParameter.m_direction == ParameterDirection.Input)
				{
					switch (oracleParameter.m_oraDbType)
					{
					case OracleDbType.Varchar2:
						oracleParameter.FreeDataBuffer();
						break;
					case OracleDbType.Date:
						oracleParameter.m_saveValue = null;
						break;
					default:
						oracleParameter.PostBind(m_connection, m_pOpoSqlValCtx, m_arrayBindCount);
						break;
					case OracleDbType.Decimal:
						break;
					}
				}
				else
				{
					oracleParameter.PostBind(m_connection, m_pOpoSqlValCtx, m_arrayBindCount);
				}
			}
			catch (Exception)
			{
				for (int j = i + 1; j < num3; j++)
				{
					oracleParameter = m_parameters[j];
					oracleParameter.PreBindFree(m_connection, m_arrayBindCount);
				}
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			if (oracleParameter.OracleDbType == OracleDbType.RefCursor)
			{
				num4++;
			}
			if (oracleParameter.m_bOracleDbTypeExSet)
			{
				oracleParameter.m_enumType = PrmEnumType.ORADBTYPE;
			}
		}
		if (m_pOpoSqlValCtx->CommandType == 1)
		{
			num4 = 1;
			array = new IntPtr[num4];
			ref IntPtr reference2 = ref array[0];
			reference2 = m_opsSqlCtx;
			m_opsSqlCtx = IntPtr.Zero;
		}
		else if (num4 != 0)
		{
			if (m_pOpoSqlValCtx->pOpoPrmCtx != null && m_pOpoSqlValCtx->pOpoPrmCtx->bInStmtCache == 1)
			{
				m_pOpoSqlValCtx->pOpoPrmCtx = null;
			}
			array = new IntPtr[num4];
			int i = 0;
			int j = 0;
			for (; i < num3; i++)
			{
				oracleParameter = m_parameters[i];
				if (oracleParameter.OracleDbType != OracleDbType.RefCursor)
				{
					continue;
				}
				if (oracleParameter.Value == DBNull.Value)
				{
					ref IntPtr reference3 = ref array[j++];
					reference3 = IntPtr.Zero;
					continue;
				}
				if (oracleParameter.m_bOracleDbTypeExSet)
				{
					ref IntPtr reference4 = ref array[j++];
					reference4 = ((OracleDataReader)oracleParameter.Value).SqlCtx;
					((OracleDataReader)oracleParameter.Value).SqlCtx = IntPtr.Zero;
					((OracleDataReader)oracleParameter.Value).Dispose();
				}
				else
				{
					ref IntPtr reference5 = ref array[j++];
					reference5 = ((OracleRefCursor)oracleParameter.Value).SqlCtx;
					((OracleRefCursor)oracleParameter.Value).SqlCtx = IntPtr.Zero;
					((OracleRefCursor)oracleParameter.Value).Dispose();
				}
				oracleParameter.Value = DBNull.Value;
			}
		}
		if (!m_addToStmtCache)
		{
			m_pOpoSqlValCtx->pOpoPrmCtx = null;
		}
		oracleDataReader = new OracleDataReader(m_connection, array, m_opsDacCtx, opsReaderErrCtx, m_pOpoSqlValCtx, pOpoDacValCtx, m_metaData, num4, behavior, m_safeMapping, m_pooledCmdText, 1, m_bFetchSizePropertySet);
		if (m_commandType == CommandType.StoredProcedure)
		{
			oracleDataReader.m_storedProcName = m_commandText;
		}
		m_safeMapping = null;
		m_pOpoSqlValCtx = null;
		if (m_isFromEF)
		{
			oracleDataReader.m_isFromEF = true;
			if (m_expectedColumnTypes != null)
			{
				oracleDataReader.m_expectedColumnTypes = m_expectedColumnTypes;
			}
		}
		if (!requery)
		{
			m_cachedReader = oracleDataReader;
		}
		return oracleDataReader;
	}

	public new OracleDataReader ExecuteReader(CommandBehavior behavior)
	{
		return ExecuteReader(requery: true, fillRequest: false, behavior);
	}

	public override object ExecuteScalar()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::ExecuteScalar()\n");
		}
		object result = null;
		m_executeScalar = true;
		OracleDataReader oracleDataReader = ExecuteReader();
		m_executeScalar = false;
		if (!oracleDataReader.Read())
		{
			oracleDataReader.Dispose();
			oracleDataReader = null;
			return result;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::ExecuteScalar()\n");
		}
		result = oracleDataReader.GetValue(0);
		oracleDataReader.Dispose();
		oracleDataReader = null;
		return result;
	}

	public unsafe override int ExecuteNonQuery()
	{
		string[] array = null;
		IntPtr[] array2 = null;
		IntPtr pUTF8CommandText = IntPtr.Zero;
		IntPtr opsSubscrCtx = IntPtr.Zero;
		int isSubscrRegistered = 0;
		OracleDependency dep = null;
		int num = 0;
		int bchgNTFNExcludeRowidInfo = 0;
		long query_id = 0L;
		int num2 = 0;
		int num3 = 0;
		bool flag = false;
		int bFromPool = 0;
		CmdTimeoutCtx cmdTimeoutCtx = null;
		Timer timer = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::ExecuteNonQuery()\n");
		}
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		if (m_cmdTxtModified && (m_commandText == null || m_commandText.Length == 0))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
		}
		if (m_xmlCommandType != 0)
		{
			if (OracleXmlCommandType.Query == m_xmlCommandType)
			{
				ExecuteXmlQuery(wantResult: false);
				return -1;
			}
			return ExecuteXmlSave();
		}
		CheckConStatus();
		if (m_cmdTxtModified || m_commandType == CommandType.StoredProcedure)
		{
			if (m_commandType == CommandType.Text)
			{
				m_selectStmt = isSelectStatement(m_commandText);
				m_pooledCmdText = m_commandText;
			}
			else if (m_commandType == CommandType.TableDirect)
			{
				m_selectStmt = true;
				m_pooledCmdText = "Select * from " + m_commandText;
			}
			else if (m_commandType == CommandType.StoredProcedure)
			{
				BuildCommandText();
				m_selectStmt = false;
				m_utf8CmdText = null;
				m_addParam = true;
			}
			if (UTF8CommandText.m_pooler.Get(m_connection.m_internalConStr, m_pooledCmdText) is UTF8CommandText uTF8CommandText && uTF8CommandText.m_utf8CmdText != IntPtr.Zero)
			{
				m_utf8CmdText = uTF8CommandText;
				m_addParam = m_utf8CmdText.m_addParam;
				m_parsed = m_utf8CmdText.m_parsed;
				bFromPool = 1;
			}
			if (!m_parsed && m_commandType == CommandType.Text)
			{
				ParseCommandText();
			}
			m_cmdTxtModified = false;
		}
		if (m_bindByName && m_commandType != CommandType.StoredProcedure)
		{
			flag = true;
		}
		if (m_NTFNReq != null && m_NTFNAutoEnlist && !m_connection.m_contextConnection && OracleNotificationRequest.s_idTable[m_NTFNReq.Id] != null)
		{
			opsSubscrCtx = OracleNotificationRequest.PopulateChgNTFNSubscrCtx(this, m_addRowid, out dep);
			if (dep != null && dep.m_bIsRegistered)
			{
				isSubscrRegistered = 1;
			}
			if (dep != null)
			{
				if (dep.m_OracleRowidInfo == OracleRowidInfo.Exclude)
				{
					bchgNTFNExcludeRowidInfo = 1;
				}
				if (dep.QueryBasedNotification && m_connection.IsDBVer11gR1OrHigher)
				{
					num = 1;
				}
			}
		}
		SetSqlValCtx(bXmlQuerySave: false);
		if (m_connection.m_opoConCtx.m_bSelfTuning && !OracleTuningAgent.bHighMemoryAlertFlag && 1 == m_pOpoSqlValCtx->AddToStmtCache)
		{
			m_connection.AcceptStatementData(m_pooledCmdText);
		}
		OpoMetValCtx* pOpoMetValCtx = null;
		try
		{
			if (m_utf8CmdText != null)
			{
				pUTF8CommandText = m_utf8CmdText.m_utf8CmdText;
				if (pUTF8CommandText != IntPtr.Zero)
				{
					bFromPool = 1;
				}
			}
			if (m_parameters != null && m_addParam)
			{
				num3 = m_parameters.Count;
				if (num3 > 0 && (m_addToStmtCache || m_pOpoPrmCtx == null || m_pOpoPrmCtx->NumValCtxElems < num3))
				{
					try
					{
						num2 = OpsSql.Prepare2(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, ref m_pOpoSqlValCtx, (pUTF8CommandText == IntPtr.Zero) ? m_pooledCmdText : null, ref pUTF8CommandText, ref pOpoMetValCtx, num3);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						num2 = ErrRes.INT_ERR;
						throw;
					}
					finally
					{
						if (num2 != 0)
						{
							if (!m_addToStmtCache && m_pOpoSqlValCtx->pOpoPrmCtx == null)
							{
								m_pOpoPrmCtx = null;
							}
							if (num2 != ErrRes.INT_ERR)
							{
								OracleException.HandleError(procedure: (m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText, errCode: num2, conn: m_connection, opsErrCtx: m_opsErrCtx, pOpoSqlValCtx: m_pOpoSqlValCtx, src: this);
							}
						}
					}
					if (!m_addToStmtCache && m_pOpoPrmCtx == null)
					{
						m_pOpoPrmCtx = m_pOpoSqlValCtx->pOpoPrmCtx;
					}
				}
				if (flag)
				{
					array = new string[num3];
				}
				array2 = new IntPtr[num3];
				for (int i = 0; i < num3; i++)
				{
					OracleParameter oracleParameter = m_parameters[i];
					oracleParameter.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + i;
					try
					{
						oracleParameter.PreBind(m_connection, m_opsErrCtx, m_arrayBindCount, m_isFromEF, m_selectStmt);
					}
					catch (Exception)
					{
						for (int j = 0; j < i; j++)
						{
							oracleParameter = m_parameters[j];
							oracleParameter.PreBindFree(m_connection, m_arrayBindCount);
						}
						throw;
					}
					if (flag)
					{
						array[i] = oracleParameter.m_paramName;
					}
					ref IntPtr reference = ref array2[i];
					reference = (IntPtr)oracleParameter.m_pOpoPrmValCtx;
				}
			}
			try
			{
				if (m_commandTimeout > 0)
				{
					cmdTimeoutCtx = new CmdTimeoutCtx(m_opsConCtx, m_commandTimeout);
					TimerCallback callback = cmdTimeoutCtx.TimeoutNew;
					long num4 = (long)m_commandTimeout * 1000L;
					if (num4 > 4147200000u)
					{
						num4 = 4147200000L;
					}
					timer = new Timer(callback, cmdTimeoutCtx, num4, -1L);
					if (cmdTimeoutCtx.m_bDoneOCIBreak)
					{
						string text = null;
						text = ((m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText);
						num2 = 1013;
						OracleException.HandleError(num2, m_connection, text, m_opsErrCtx, m_pOpoSqlValCtx, this);
					}
				}
				num2 = 0;
				if (m_connection.m_opoConCtx.m_bSelfTuning && m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
				{
					m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
					num2 = OpsCon.SetStatementCacheSize(m_opsConCtx, ref m_opsErrCtx, m_connection.m_opoConCtx.pOpoConValCtx);
					if (m_connection.m_opoConCtx.m_conPooler != null)
					{
						m_connection.m_opoConCtx.m_conPooler.ModifyConPoolerSize(m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize);
					}
				}
				if (num2 == 0)
				{
					m_opsDacCtx = IntPtr.Zero;
					num2 = OpsSql.ExecuteNonQuery(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, opsSubscrCtx, ref isSubscrRegistered, bchgNTFNExcludeRowidInfo, num, ref query_id, ref m_pOpoSqlValCtx, (pUTF8CommandText == IntPtr.Zero || m_selectStmt) ? m_pooledCmdText : null, ref pUTF8CommandText, array2, array, ref pOpoMetValCtx, num3, bFromPool);
				}
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
		}
		finally
		{
			if (m_commandTimeout > 0 && cmdTimeoutCtx != null)
			{
				cmdTimeoutCtx.m_bDoneExecution = true;
				if (!cmdTimeoutCtx.m_hWaitForOciBreakEvent.WaitOne(5000, exitContext: false) && OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (WARN)  OracleCommand::ExecuteNonQuery() WaitOne() timed out \n");
				}
				timer.Dispose();
				cmdTimeoutCtx.Dispose();
			}
			if (dep != null && isSubscrRegistered == 1 && !m_connection.m_contextConnection)
			{
				dep.SetRegisterInfo(m_connection.m_opoConCtx.opoConRefCtx.userID, m_connection.DataSource, m_NTFNReq.IsNotifiedOnce, m_NTFNReq.IsPersistent, m_NTFNReq.Timeout);
			}
			if (m_connection.m_contextConnection && pOpoMetValCtx != null && pOpoMetValCtx->bHasUdtType == 1)
			{
				num2 = ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN;
			}
			if (pUTF8CommandText != IntPtr.Zero)
			{
				if (!(UTF8CommandText.m_pooler.Get(m_connection.m_internalConStr, m_pooledCmdText) is UTF8CommandText))
				{
					if (m_utf8CmdText == null)
					{
						m_utf8CmdText = new UTF8CommandText(pUTF8CommandText);
					}
					m_utf8CmdText.m_parsed = m_parsed;
					m_utf8CmdText.m_addParam = m_addParam;
					UTF8CommandText.m_pooler.Put(m_connection.m_internalConStr, m_pooledCmdText, m_utf8CmdText);
				}
				else if (m_utf8CmdText == null)
				{
					m_utf8CmdText = new UTF8CommandText(pUTF8CommandText);
				}
			}
			if (num2 != 0)
			{
				for (int i = 0; i < num3; i++)
				{
					OracleParameter oracleParameter = m_parameters[i];
					oracleParameter.PreBindFree(m_connection, m_arrayBindCount);
				}
				FreeNonCachedOpoPrmCtx();
				if (num2 != ErrRes.INT_ERR)
				{
					OracleException.HandleError(procedure: (m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText, errCode: num2, conn: m_connection, opsErrCtx: m_opsErrCtx, pOpoSqlValCtx: m_pOpoSqlValCtx, src: this, bCheck: true);
				}
			}
		}
		if (dep != null && !m_connection.m_contextConnection)
		{
			dep.m_bIsEnabled = true;
			if (!dep.m_regList.Contains(m_commandText))
			{
				dep.m_regList.Add(m_commandText);
			}
			if (num == 1 && !dep.m_queryIDList.Contains(query_id))
			{
				dep.m_queryIDList.Add(query_id);
			}
		}
		if (m_pOpoSqlValCtx->CommandType == 4 || m_pOpoSqlValCtx->CommandType == 2 || m_pOpoSqlValCtx->CommandType == 3)
		{
			m_rowsAffected = m_pOpoSqlValCtx->RowsAffected;
		}
		else
		{
			m_rowsAffected = -1;
		}
		for (int i = 0; i < num3; i++)
		{
			OracleParameter oracleParameter = m_parameters[i];
			if (oracleParameter.m_bOracleDbTypeExSet)
			{
				oracleParameter.m_enumType = PrmEnumType.DBTYPE;
			}
			if (oracleParameter.m_oraDbType == OracleDbType.RefCursor)
			{
				oracleParameter.m_commandText = m_commandText;
				if (m_bindByName)
				{
					oracleParameter.m_paramPosOrName = oracleParameter.ParameterName;
				}
				else
				{
					oracleParameter.m_paramPosOrName = i.ToString();
				}
			}
			oracleParameter.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[i];
			try
			{
				if (oracleParameter.m_direction == ParameterDirection.Input)
				{
					switch (oracleParameter.m_oraDbType)
					{
					case OracleDbType.Varchar2:
						oracleParameter.FreeDataBuffer();
						break;
					case OracleDbType.Date:
						oracleParameter.m_saveValue = null;
						break;
					default:
						oracleParameter.PostBind(m_connection, m_pOpoSqlValCtx, m_arrayBindCount);
						break;
					case OracleDbType.Decimal:
						break;
					}
				}
				else
				{
					oracleParameter.PostBind(m_connection, m_pOpoSqlValCtx, m_arrayBindCount);
				}
			}
			catch (Exception)
			{
				for (int j = i + 1; j < num3; j++)
				{
					oracleParameter = m_parameters[j];
					oracleParameter.PreBindFree(m_connection, m_arrayBindCount);
				}
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			if (oracleParameter.m_bOracleDbTypeExSet)
			{
				oracleParameter.m_enumType = PrmEnumType.ORADBTYPE;
			}
		}
		FreeNonCachedOpoPrmCtx();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::ExecuteNonQuery()\n");
		}
		return m_rowsAffected;
	}

	public XmlReader ExecuteXmlReader()
	{
		XmlReader xmlReader = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::ExecuteXmlReader()\n");
		}
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		if (m_cmdTxtModified && (m_commandText == null || m_commandText.Length == 0))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
		}
		if (m_xmlCommandType == OracleXmlCommandType.None)
		{
			throw new InvalidOperationException();
		}
		if (OracleXmlCommandType.Query == m_xmlCommandType)
		{
			OracleClob oracleClob = ExecuteXmlQuery(wantResult: true);
			long length = oracleClob.Length;
			int num = 65536;
			if (length < 65536)
			{
				num = (int)length;
			}
			num /= 2;
			StreamReader input = new StreamReader(oracleClob, Encoding.Unicode, detectEncodingFromByteOrderMarks: false, num);
			xmlReader = new XmlTextReader(input);
		}
		else
		{
			ExecuteXmlSave();
			xmlReader = new XmlTextReader(new StringReader(string.Empty));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::ExecuteXmlReader()\n");
		}
		return xmlReader;
	}

	public Stream ExecuteStream()
	{
		Stream stream = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::ExecuteStream()\n");
		}
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		if (m_cmdTxtModified && (m_commandText == null || m_commandText.Length == 0))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
		}
		if (m_xmlCommandType == OracleXmlCommandType.None)
		{
			throw new InvalidOperationException();
		}
		if (OracleXmlCommandType.Query == m_xmlCommandType)
		{
			OracleClob oracleClob = ExecuteXmlQuery(wantResult: true);
			stream = oracleClob;
		}
		else
		{
			ExecuteXmlSave();
			stream = new OracleClob(m_connection);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::ExecuteStream()\n");
		}
		return stream;
	}

	public void ExecuteToStream(Stream outputStream)
	{
		int num = 0;
		int num2 = 0;
		byte[] array = null;
		long num3 = 0L;
		int num4 = 0;
		int num5 = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::ExecuteToStream()\n");
		}
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		if (m_cmdTxtModified && (m_commandText == null || m_commandText.Length == 0))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
		}
		if (m_xmlCommandType == OracleXmlCommandType.None)
		{
			throw new InvalidOperationException();
		}
		if (outputStream == null)
		{
			throw new ArgumentNullException();
		}
		if (!outputStream.CanWrite)
		{
			throw new ArgumentException();
		}
		if (OracleXmlCommandType.Query == m_xmlCommandType)
		{
			OracleClob oracleClob = ExecuteXmlQuery(wantResult: true);
			num3 = oracleClob.Length;
			string fullName = outputStream.GetType().FullName;
			if (fullName.Equals("Oracle.DataAccess.Types.OracleClob") && num3 % 2 == 0)
			{
				OracleClob oracleClob2 = (OracleClob)outputStream;
				oracleClob.CopyTo(oracleClob2, oracleClob2.Position / 2);
			}
			else
			{
				if (num3 < 65536)
				{
					num2 = (int)num3;
				}
				else
				{
					num = 2 * oracleClob.OptimumChunkSize;
					num2 = num * (65536 / num);
					if (num2 == 0)
					{
						num2 = num;
					}
				}
				array = new byte[num2];
				while (num3 > 0)
				{
					if (num3 < num2)
					{
						num4 = (int)num3;
						num3 = 0L;
					}
					else
					{
						num4 = num2;
						num3 -= num2;
					}
					num5 = oracleClob.Read(array, 0, num4);
					if (num5 != num4)
					{
						throw new IOException();
					}
					outputStream.Write(array, 0, num5);
				}
			}
			oracleClob.Close();
		}
		else
		{
			ExecuteXmlSave();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::ExecuteToStream()\n");
		}
	}

	public new OracleParameter CreateParameter()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::CreateParameter()\n");
		}
		OracleParameter result = new OracleParameter();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::CreateParameter()\n");
		}
		return result;
	}

	public override void Cancel()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::Cancel()\n");
		}
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		CheckConStatus();
		try
		{
			num = OpsSql.BreakExecution(m_opsConCtx, ref m_opsErrCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::Cancel()\n");
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::Dispose()\n");
		}
		if (!m_disposed)
		{
			try
			{
				FreeAllCtx();
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
						m_cachedReader = null;
						m_safeMapping = null;
					}
					catch
					{
					}
				}
				m_metaData = null;
				m_utf8CmdText = null;
				m_modified = true;
				m_disposed = true;
			}
			catch
			{
			}
			finally
			{
				try
				{
					base.Dispose(disposing);
				}
				catch
				{
				}
			}
			try
			{
				OpsCon.RelRef(ref m_opsConCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::Dispose()\n");
		}
	}

	private OracleParameter GetReturnValueParam()
	{
		if (m_commandType != CommandType.StoredProcedure)
		{
			return null;
		}
		for (int i = 0; i < m_parameters.Count; i++)
		{
			if (m_parameters[i].Direction == ParameterDirection.ReturnValue)
			{
				return m_parameters[i];
			}
		}
		return null;
	}

	private void ParseCommandText()
	{
		int i = 0;
		int length = m_commandText.Length;
		while (i < length)
		{
			char c = m_commandText[i];
			if (c == '\'')
			{
				for (i++; i < length && m_commandText[i] != '\''; i++)
				{
				}
				if (i >= length)
				{
					break;
				}
				c = m_commandText[i];
			}
			if (c == '"')
			{
				for (i++; i < length && m_commandText[i] != '"'; i++)
				{
				}
				if (i >= length)
				{
					break;
				}
				c = m_commandText[i];
			}
			int num = length - 1;
			if (i < num && c == '/' && m_commandText[i + 1] == '*')
			{
				for (i += 2; i < length; i++)
				{
					if (i >= num || m_commandText[i] == '*' || m_commandText[i + 1] == '/')
					{
						i += 2;
						break;
					}
				}
				if (i >= length)
				{
					break;
				}
				c = m_commandText[i];
			}
			if (c == ':')
			{
				for (i++; i < length && m_commandText[i] == ' '; i++)
				{
				}
				if (i >= length)
				{
					break;
				}
				c = m_commandText[i];
				if (i + 3 < length && m_commandText[i + 3] == '.' && (((c == 'N' || c == 'n') && (c == 'E' || c == 'e') && (c == 'W' || c == 'w')) || ((c == 'O' || c == 'o') && (c == 'L' || c == 'l') && (c == 'D' || c == 'd'))))
				{
					continue;
				}
				if (c != '=')
				{
					m_addParam = true;
					m_parsed = true;
					return;
				}
			}
			i++;
		}
		m_addParam = false;
		m_parsed = true;
	}

	private unsafe string BuildCommandText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		OracleParameter oracleParameter = null;
		if (m_pOpoSqlValCtx == null)
		{
			try
			{
				OpsSql.AllocSqlValCtx(ref m_pOpoSqlValCtx);
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
		m_pOpoSqlValCtx->RetIdxForSP = -1;
		if (m_cmdTxtModified)
		{
			StoredProcedureInfo storedProcInfo = RegAndConfigRdr.GetStoredProcInfo(m_commandText);
			if (storedProcInfo != null && storedProcInfo.refCursors.Count > 0)
			{
				for (int i = 0; i < storedProcInfo.refCursors.Count; i++)
				{
					AddRefCursorParamToParamColl((RefCursorInfo)storedProcInfo.refCursors[i]);
				}
			}
		}
		if (m_parameters == null || m_parameters.Count == 0)
		{
			stringBuilder.Append("Begin " + m_commandText + "(); End;");
			m_pooledCmdText = stringBuilder.ToString();
		}
		else
		{
			int count = Parameters.Count;
			if (!m_bindByName)
			{
				if ((oracleParameter = GetReturnValueParam()) == null)
				{
					stringBuilder.Append("Begin " + m_commandText + "(:v0");
					for (int j = 1; j < count; j++)
					{
						stringBuilder.Append(", :v" + j);
					}
					stringBuilder.Append("); End;");
					m_pooledCmdText = stringBuilder.ToString();
				}
				else
				{
					int j;
					if (m_parameters[0] == oracleParameter)
					{
						if (count > 1)
						{
							stringBuilder.Append("Begin :ret := " + m_commandText + "(:v1");
							j = 2;
						}
						else
						{
							stringBuilder.Append("Begin :ret := " + m_commandText + "(");
							j = 1;
						}
					}
					else
					{
						stringBuilder.Append("Begin :ret := " + m_commandText + "(:v0");
						j = 1;
					}
					for (; j < count; j++)
					{
						if (m_parameters[j] != oracleParameter)
						{
							stringBuilder.Append(", :v" + j);
						}
					}
					stringBuilder.Append("); End;");
					m_pooledCmdText = stringBuilder.ToString();
				}
			}
			else if ((oracleParameter = GetReturnValueParam()) == null)
			{
				stringBuilder.Append("Begin " + m_commandText + "(" + m_parameters[0].ParameterName + "=>:v0");
				for (int j = 1; j < count; j++)
				{
					stringBuilder.Append(", " + m_parameters[j].ParameterName + "=>:v" + j);
				}
				stringBuilder.Append("); End;");
				m_pooledCmdText = stringBuilder.ToString();
			}
			else
			{
				int j;
				if (m_parameters[0] == oracleParameter)
				{
					if (count > 1)
					{
						stringBuilder.Append("Begin :ret := " + m_commandText + "(" + m_parameters[1].ParameterName + "=>:v1");
						j = 2;
					}
					else
					{
						stringBuilder.Append("Begin :ret := " + m_commandText + "(");
						j = 1;
					}
				}
				else
				{
					m_pOpoSqlValCtx->RetIdxForSP = m_parameters.IndexOf(oracleParameter);
					stringBuilder.Append("Begin :ret := " + m_commandText + "(" + m_parameters[0].ParameterName + "=>:v0");
					j = 1;
				}
				for (; j < count; j++)
				{
					if (m_parameters[j] != oracleParameter)
					{
						stringBuilder.Append(", " + m_parameters[j].ParameterName + "=>:v" + j);
					}
				}
				stringBuilder.Append("); End;");
				m_pooledCmdText = stringBuilder.ToString();
			}
		}
		return m_pooledCmdText;
	}

	private void Initialize()
	{
		m_updatedRowSource = UpdateRowSource.Both;
		m_commandType = CommandType.Text;
		m_rowsAffected = -1;
		m_fetchSize = OraTrace.m_FetchSize;
		m_addParam = true;
		m_cmdTxtModified = true;
		m_xmlCommandType = OracleXmlCommandType.None;
		m_addToStatementCache = true;
		m_NTFNAutoEnlist = true;
		m_designTimeVisible = true;
		m_expectedColumnTypes = null;
		m_isFromEF = false;
	}

	private unsafe void FreeAllCtx()
	{
		bool flag = true;
		m_metaData = null;
		m_utf8CmdText = null;
		m_parameters = null;
		try
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Enter(m_connection.m_extProcEnv);
				flag = m_connection.m_extProcEnv.m_status;
			}
			if (m_opsSqlCtx != IntPtr.Zero)
			{
				try
				{
					if (flag)
					{
						if (!m_addToStmtCache)
						{
							OpsSql.FreeCtx(ref m_opsSqlCtx, m_opsErrCtx, 0);
						}
						else
						{
							OpsSql.FreeCtx(ref m_opsSqlCtx, m_opsErrCtx, 1);
						}
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
				if (m_pOpoPrmCtx != null && m_pOpoPrmCtx == m_pOpoSqlValCtx->pOpoPrmCtx)
				{
					m_pOpoPrmCtx = null;
				}
				else
				{
					m_pOpoSqlValCtx->pOpoPrmCtx = null;
				}
				try
				{
					if (flag)
					{
						OpsSql.FreeValCtx(m_pOpoSqlValCtx, 1);
					}
					else
					{
						OpsSql.FreeValCtx(m_pOpoSqlValCtx, 0);
					}
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
			if (m_pOpoPrmCtx != null)
			{
				try
				{
					OpsPrm.FreeOpoPrmCtx(m_pOpoPrmCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				m_pOpoPrmCtx = null;
			}
			if (!(m_opsErrCtx != IntPtr.Zero))
			{
				return;
			}
			try
			{
				if (flag)
				{
					OpsErr.FreeCtx(ref m_opsErrCtx);
				}
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
			}
			m_opsErrCtx = IntPtr.Zero;
		}
		finally
		{
			if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
			{
				Monitor.Exit(m_connection.m_extProcEnv);
			}
		}
	}

	private unsafe void FreeNonCachedOpoPrmCtx()
	{
		if (!m_addToStmtCache || m_pOpoSqlValCtx->pOpoPrmCtx == null || m_pOpoSqlValCtx->pOpoPrmCtx->bInStmtCache != 0)
		{
			return;
		}
		try
		{
			OpsPrm.FreeOpoPrmCtx(m_pOpoSqlValCtx->pOpoPrmCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		m_pOpoSqlValCtx->pOpoPrmCtx = null;
	}

	private unsafe OracleClob ExecuteXmlQuery(bool wantResult)
	{
		bool flag = false;
		string[] array = null;
		IntPtr[] array2 = null;
		IntPtr pUTF8CommandText = IntPtr.Zero;
		IntPtr opsSubscrCtx = IntPtr.Zero;
		int isSubscrRegistered = 0;
		OracleDependency dep = null;
		int num = 0;
		int bchgNTFNExcludeRowidInfo = 0;
		long query_id = 0L;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		OracleParameter oracleParameter = null;
		OracleParameter oracleParameter2 = null;
		OracleClob oracleClob = null;
		OracleParameter oracleParameter3 = null;
		OracleClob oracleClob2 = null;
		bool flag2 = false;
		int bFromPool = 0;
		CmdTimeoutCtx cmdTimeoutCtx = null;
		Timer timer = null;
		CheckConStatus();
		int majorVersion = m_connection.m_majorVersion;
		int minorVersion = m_connection.m_minorVersion;
		if ((majorVersion == 8 && minorVersion == 1) || (majorVersion == 9 && minorVersion == 0))
		{
			flag = true;
		}
		if (m_xmlQueryProperties == null)
		{
			m_xmlQueryProperties = new OracleXmlQueryProperties();
		}
		if (m_xmlQueryProperties.Xslt != null && m_xmlQueryProperties.Xslt.Length != 0)
		{
			flag2 = true;
		}
		string text = ":OracleResult$";
		string parameterName = ":OracleXslDoc$";
		string parameterName2 = ":OracleSqlQuery$";
		if (m_cmdTxtModified && !m_parsed && m_commandType == CommandType.Text)
		{
			ParseCommandText();
		}
		if (m_NTFNReq != null && m_NTFNAutoEnlist && !m_connection.m_contextConnection && OracleNotificationRequest.s_idTable[m_NTFNReq.Id] != null)
		{
			opsSubscrCtx = OracleNotificationRequest.PopulateChgNTFNSubscrCtx(this, m_addRowid, out dep);
			if (dep != null && dep.m_bIsRegistered)
			{
				isSubscrRegistered = 1;
			}
			if (dep != null)
			{
				if (dep.m_OracleRowidInfo == OracleRowidInfo.Exclude)
				{
					bchgNTFNExcludeRowidInfo = 1;
				}
				if (dep.QueryBasedNotification && m_connection.IsDBVer11gR1OrHigher)
				{
					num = 1;
				}
			}
		}
		if (m_parameters != null && m_addParam)
		{
			num4 = m_parameters.Count;
			if (num4 > 0 && !m_bindByName)
			{
				throw new InvalidOperationException();
			}
		}
		num5 = num4;
		if (wantResult)
		{
			num5++;
		}
		if (flag2)
		{
			num5++;
		}
		if (flag)
		{
			num5++;
		}
		BuildXmlQueryCommandText(wantResult, text);
		m_utf8CmdText = null;
		if (UTF8CommandText.m_pooler.Get(m_connection.m_internalConStr, m_pooledCmdText) is UTF8CommandText uTF8CommandText && uTF8CommandText.m_utf8CmdText != IntPtr.Zero)
		{
			m_utf8CmdText = uTF8CommandText;
			m_addParam = m_utf8CmdText.m_addParam;
			m_parsed = m_utf8CmdText.m_parsed;
			bFromPool = 1;
		}
		OpoMetValCtx* pOpoMetValCtx = null;
		m_selectStmt = false;
		SetSqlValCtx(bXmlQuerySave: true);
		try
		{
			if (num5 > 0 && (m_addToStmtCache || m_pOpoPrmCtx == null || m_pOpoPrmCtx->NumValCtxElems < num5))
			{
				try
				{
					if (m_utf8CmdText != null)
					{
						pUTF8CommandText = m_utf8CmdText.m_utf8CmdText;
					}
					num3 = OpsSql.Prepare2(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, ref m_pOpoSqlValCtx, (pUTF8CommandText == IntPtr.Zero) ? m_pooledCmdText : null, ref pUTF8CommandText, ref pOpoMetValCtx, num5);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num3 = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num3 != 0)
					{
						if (!m_addToStmtCache && m_pOpoSqlValCtx->pOpoPrmCtx == null)
						{
							m_pOpoPrmCtx = null;
						}
						if (num3 != ErrRes.INT_ERR)
						{
							OracleException.HandleError(num3, m_connection, string.Empty, m_opsErrCtx, m_pOpoSqlValCtx, this);
						}
					}
				}
				if (!m_addToStmtCache && m_pOpoPrmCtx == null)
				{
					m_pOpoPrmCtx = m_pOpoSqlValCtx->pOpoPrmCtx;
				}
			}
			array = new string[num5];
			array2 = new IntPtr[num5];
			for (int i = 0; i < num4; i++)
			{
				OracleParameter oracleParameter4 = m_parameters[i];
				oracleParameter4.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + i;
				try
				{
					oracleParameter4.PreBind(m_connection, m_opsErrCtx, 0);
				}
				catch (Exception)
				{
					for (int j = 0; j < i; j++)
					{
						oracleParameter4 = m_parameters[j];
						oracleParameter4.PreBindFree(m_connection, 0);
					}
					FreeNonCachedOpoPrmCtx();
					throw;
				}
				array[i] = oracleParameter4.m_paramName;
				ref IntPtr reference = ref array2[i];
				reference = (IntPtr)oracleParameter4.m_pOpoPrmValCtx;
			}
			num2 = num4;
			if (wantResult)
			{
				oracleParameter = new OracleParameter(text, OracleDbType.Clob);
				oracleParameter.Direction = ParameterDirection.Output;
				oracleParameter.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + num2;
				try
				{
					oracleParameter.PreBind(m_connection, m_opsErrCtx, 0);
				}
				catch (Exception)
				{
					for (int j = 0; j < num4; j++)
					{
						OracleParameter oracleParameter4 = m_parameters[j];
						oracleParameter4.PreBindFree(m_connection, 0);
					}
					FreeNonCachedOpoPrmCtx();
					throw;
				}
				array[num2] = oracleParameter.m_paramName;
				ref IntPtr reference2 = ref array2[num2];
				reference2 = (IntPtr)oracleParameter.m_pOpoPrmValCtx;
				num2++;
			}
			if (flag2)
			{
				if (m_xmlQueryProperties.Xslt.Length > 32512 || flag)
				{
					oracleParameter2 = new OracleParameter(parameterName, OracleDbType.Clob);
					oracleParameter2.Direction = ParameterDirection.Input;
					oracleClob = new OracleClob(m_connection);
					oracleClob.Append(m_xmlQueryProperties.Xslt.ToCharArray(), 0, m_xmlQueryProperties.Xslt.Length);
					oracleParameter2.Value = oracleClob;
				}
				else
				{
					oracleParameter2 = new OracleParameter(parameterName, OracleDbType.Varchar2);
					oracleParameter2.Direction = ParameterDirection.Input;
					oracleParameter2.Value = m_xmlQueryProperties.Xslt;
				}
				oracleParameter2.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + num2;
				try
				{
					oracleParameter2.PreBind(m_connection, m_opsErrCtx, 0);
				}
				catch (Exception)
				{
					for (int j = 0; j < num4; j++)
					{
						OracleParameter oracleParameter4 = m_parameters[j];
						oracleParameter4.PreBindFree(m_connection, 0);
					}
					if (wantResult)
					{
						oracleParameter.PreBindFree(m_connection, 0);
					}
					oracleClob?.Close();
					FreeNonCachedOpoPrmCtx();
					throw;
				}
				array[num2] = oracleParameter2.m_paramName;
				ref IntPtr reference3 = ref array2[num2];
				reference3 = (IntPtr)oracleParameter2.m_pOpoPrmValCtx;
				num2++;
			}
			if (flag)
			{
				if (m_commandText.Length > 32512)
				{
					oracleParameter3 = new OracleParameter(parameterName2, OracleDbType.Clob);
					oracleParameter3.Direction = ParameterDirection.Input;
					oracleClob2 = new OracleClob(m_connection);
					oracleClob2.Append(m_commandText.ToCharArray(), 0, m_commandText.Length);
					oracleParameter3.Value = oracleClob2;
				}
				else
				{
					oracleParameter3 = new OracleParameter(parameterName2, OracleDbType.Varchar2);
					oracleParameter3.Direction = ParameterDirection.Input;
					oracleParameter3.Value = m_commandText;
				}
				oracleParameter3.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + num2;
				try
				{
					oracleParameter3.PreBind(m_connection, m_opsErrCtx, 0);
				}
				catch (Exception)
				{
					for (int j = 0; j < num4; j++)
					{
						OracleParameter oracleParameter4 = m_parameters[j];
						oracleParameter4.PreBindFree(m_connection, 0);
					}
					if (wantResult)
					{
						oracleParameter.PreBindFree(m_connection, 0);
					}
					if (flag2)
					{
						oracleParameter2.PreBindFree(m_connection, 0);
					}
					oracleClob?.Close();
					oracleClob2?.Close();
					FreeNonCachedOpoPrmCtx();
					throw;
				}
				array[num2] = oracleParameter3.m_paramName;
				ref IntPtr reference4 = ref array2[num2];
				reference4 = (IntPtr)oracleParameter3.m_pOpoPrmValCtx;
				num2++;
			}
			try
			{
				if (m_utf8CmdText != null)
				{
					pUTF8CommandText = m_utf8CmdText.m_utf8CmdText;
				}
				if (m_commandTimeout > 0)
				{
					cmdTimeoutCtx = new CmdTimeoutCtx(m_opsConCtx, m_commandTimeout);
					TimerCallback callback = cmdTimeoutCtx.TimeoutNew;
					long num6 = (long)m_commandTimeout * 1000L;
					if (num6 > 4147200000u)
					{
						num6 = 4147200000L;
					}
					timer = new Timer(callback, cmdTimeoutCtx, num6, -1L);
					if (cmdTimeoutCtx.m_bDoneOCIBreak)
					{
						string text2 = null;
						text2 = ((m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText);
						num3 = 1013;
						OracleException.HandleError(num3, m_connection, text2, m_opsErrCtx, m_pOpoSqlValCtx, this);
					}
				}
				num3 = 0;
				if (m_connection.m_opoConCtx.m_bSelfTuning && m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
				{
					m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
					num3 = OpsCon.SetStatementCacheSize(m_opsConCtx, ref m_opsErrCtx, m_connection.m_opoConCtx.pOpoConValCtx);
					if (m_connection.m_opoConCtx.m_conPooler != null)
					{
						m_connection.m_opoConCtx.m_conPooler.ModifyConPoolerSize(m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize);
					}
				}
				if (num3 == 0)
				{
					m_opsDacCtx = IntPtr.Zero;
					num3 = OpsSql.ExecuteNonQuery(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, opsSubscrCtx, ref isSubscrRegistered, bchgNTFNExcludeRowidInfo, num, ref query_id, ref m_pOpoSqlValCtx, (pUTF8CommandText == IntPtr.Zero || m_selectStmt) ? m_pooledCmdText : null, ref pUTF8CommandText, array2, array, ref pOpoMetValCtx, num5, bFromPool);
				}
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
				num3 = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (m_commandTimeout > 0 && cmdTimeoutCtx != null)
				{
					cmdTimeoutCtx.m_bDoneExecution = true;
					if (!cmdTimeoutCtx.m_hWaitForOciBreakEvent.WaitOne(5000, exitContext: false) && OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (WARN)  OracleCommand::ExecuteXmlQuery() WaitOne() timed out \n");
					}
					timer.Dispose();
					cmdTimeoutCtx.Dispose();
				}
				if (dep != null && isSubscrRegistered == 1 && !m_connection.m_contextConnection)
				{
					dep.SetRegisterInfo(m_connection.m_opoConCtx.opoConRefCtx.userID, m_connection.DataSource, m_NTFNReq.IsNotifiedOnce, m_NTFNReq.IsPersistent, m_NTFNReq.Timeout);
				}
				if (num3 != 0)
				{
					for (int i = 0; i < num4; i++)
					{
						OracleParameter oracleParameter4 = m_parameters[i];
						oracleParameter4.PreBindFree(m_connection, 0);
					}
					if (wantResult)
					{
						oracleParameter.PreBindFree(m_connection, 0);
					}
					if (flag2)
					{
						oracleParameter2.PreBindFree(m_connection, 0);
						oracleClob?.Close();
					}
					if (flag)
					{
						oracleParameter3.PreBindFree(m_connection, 0);
						oracleClob2?.Close();
					}
					FreeNonCachedOpoPrmCtx();
					if (num3 != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num3, m_connection, string.Empty, m_opsErrCtx, m_pOpoSqlValCtx, this, bCheck: true);
					}
				}
			}
		}
		finally
		{
			if (pUTF8CommandText != IntPtr.Zero)
			{
				UTF8CommandText uTF8CommandText2 = UTF8CommandText.m_pooler.Get(m_connection.m_internalConStr, m_pooledCmdText) as UTF8CommandText;
				if (uTF8CommandText2 == null)
				{
					if (uTF8CommandText2 == null && m_utf8CmdText == null)
					{
						m_utf8CmdText = new UTF8CommandText(pUTF8CommandText);
					}
					m_utf8CmdText.m_parsed = m_parsed;
					m_utf8CmdText.m_addParam = m_addParam;
					UTF8CommandText.m_pooler.Put(m_connection.m_internalConStr, m_pooledCmdText, m_utf8CmdText);
				}
				else if (m_utf8CmdText == null)
				{
					m_utf8CmdText = new UTF8CommandText(pUTF8CommandText);
				}
			}
		}
		m_rowsAffected = -1;
		if (dep != null && !m_connection.m_contextConnection)
		{
			dep.m_bIsEnabled = true;
			if (!dep.m_regList.Contains(m_commandText))
			{
				dep.m_regList.Add(m_commandText);
			}
			if (num == 1 && !dep.m_queryIDList.Contains(query_id))
			{
				dep.m_queryIDList.Add(query_id);
			}
		}
		for (int i = 0; i < num4; i++)
		{
			OracleParameter oracleParameter4 = m_parameters[i];
			if (oracleParameter4.m_bOracleDbTypeExSet)
			{
				oracleParameter4.m_enumType = PrmEnumType.DBTYPE;
			}
			if (oracleParameter4.m_oraDbType == OracleDbType.RefCursor)
			{
				oracleParameter4.m_commandText = m_commandText;
				if (m_bindByName)
				{
					oracleParameter4.m_paramPosOrName = oracleParameter4.ParameterName;
				}
				else
				{
					oracleParameter4.m_paramPosOrName = i.ToString();
				}
			}
			oracleParameter4.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[i];
			try
			{
				oracleParameter4.PostBind(m_connection, m_pOpoSqlValCtx, 0);
			}
			catch (Exception)
			{
				for (int j = i + 1; j < num4; j++)
				{
					oracleParameter4 = m_parameters[j];
					oracleParameter4.PreBindFree(m_connection, 0);
				}
				if (wantResult)
				{
					oracleParameter.PreBindFree(m_connection, 0);
				}
				if (flag2)
				{
					oracleParameter2.PreBindFree(m_connection, 0);
					oracleClob?.Close();
				}
				if (flag)
				{
					oracleParameter3.PreBindFree(m_connection, 0);
					oracleClob2?.Close();
				}
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			if (oracleParameter4.m_bOracleDbTypeExSet)
			{
				oracleParameter4.m_enumType = PrmEnumType.ORADBTYPE;
			}
			if (oracleParameter4.m_oraDbType == OracleDbType.RefCursor)
			{
				oracleParameter4.m_commandText = m_commandText;
				if (m_bindByName)
				{
					oracleParameter4.m_paramPosOrName = oracleParameter4.ParameterName;
				}
				else
				{
					oracleParameter4.m_paramPosOrName = i.ToString();
				}
			}
		}
		num2 = num4;
		if (wantResult)
		{
			oracleParameter.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[num2];
			try
			{
				oracleParameter.PostBind(m_connection, m_pOpoSqlValCtx, 0);
			}
			catch (Exception)
			{
				if (flag2)
				{
					oracleParameter2.PreBindFree(m_connection, 0);
					oracleClob?.Close();
				}
				if (flag)
				{
					oracleParameter3.PreBindFree(m_connection, 0);
					oracleClob2?.Close();
				}
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			num2++;
		}
		if (flag2)
		{
			oracleParameter2.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[num2];
			try
			{
				oracleParameter2.PostBind(m_connection, m_pOpoSqlValCtx, 0);
			}
			catch (Exception)
			{
				oracleClob?.Close();
				if (flag)
				{
					oracleParameter3.PreBindFree(m_connection, 0);
					oracleClob2?.Close();
				}
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			num2++;
		}
		oracleClob?.Close();
		if (flag)
		{
			oracleParameter3.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[num2];
			try
			{
				oracleParameter3.PostBind(m_connection, m_pOpoSqlValCtx, 0);
			}
			catch (Exception)
			{
				oracleClob2?.Close();
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			num2++;
		}
		oracleClob2?.Close();
		FreeNonCachedOpoPrmCtx();
		if (wantResult)
		{
			string fullName = oracleParameter.Value.GetType().FullName;
			if (fullName.Equals("Oracle.DataAccess.Types.OracleClob") && !((OracleClob)oracleParameter.Value).IsNull)
			{
				OracleClob oracleClob3 = (OracleClob)oracleParameter.Value;
				oracleClob3.m_doneTempLobCreate = true;
				oracleClob3.m_isTemporaryLob = true;
				return oracleClob3;
			}
			string text3 = null;
			text3 = ((!flag) ? "<?xml version = \"1.0\"?>\n" : "<?xml version = '1.0'?>\n");
			if (m_xmlQueryProperties.RootTag != null && m_xmlQueryProperties.RootTag.Length != 0)
			{
				text3 = text3 + "<" + m_xmlQueryProperties.RootTag + "/>\n";
			}
			OracleClob oracleClob4 = new OracleClob(m_connection);
			oracleClob4.Append(text3.ToCharArray(), 0, text3.Length);
			return oracleClob4;
		}
		return null;
	}

	private unsafe int ExecuteXmlSave()
	{
		string[] array = null;
		IntPtr[] array2 = null;
		IntPtr pUTF8CommandText = IntPtr.Zero;
		IntPtr opsSubscrCtx = IntPtr.Zero;
		int isSubscrRegistered = 0;
		OracleDependency dep = null;
		int num = 0;
		int bchgNTFNExcludeRowidInfo = 0;
		long query_id = 0L;
		int num2 = 0;
		int num3 = 0;
		OracleParameter oracleParameter = null;
		OracleParameter oracleParameter2 = null;
		OracleClob oracleClob = null;
		OracleParameter oracleParameter3 = null;
		OracleParameter oracleParameter4 = null;
		OracleClob oracleClob2 = null;
		bool flag = false;
		int bFromPool = 0;
		CmdTimeoutCtx cmdTimeoutCtx = null;
		Timer timer = null;
		CheckConStatus();
		if (m_xmlSaveProperties == null)
		{
			m_xmlSaveProperties = new OracleXmlSaveProperties();
		}
		if (m_xmlSaveProperties.Xslt != null && m_xmlSaveProperties.Xslt.Length != 0)
		{
			flag = true;
		}
		if (m_NTFNReq != null && m_NTFNAutoEnlist && !m_connection.m_contextConnection && OracleNotificationRequest.s_idTable[m_NTFNReq.Id] != null)
		{
			opsSubscrCtx = OracleNotificationRequest.PopulateChgNTFNSubscrCtx(this, m_addRowid, out dep);
			if (dep != null && dep.m_bIsRegistered)
			{
				isSubscrRegistered = 1;
			}
			if (dep != null)
			{
				if (dep.m_OracleRowidInfo == OracleRowidInfo.Exclude)
				{
					bchgNTFNExcludeRowidInfo = 1;
				}
				if (dep.QueryBasedNotification && m_connection.IsDBVer11gR1OrHigher)
				{
					num = 1;
				}
			}
		}
		string parameterName = ":OracleXmlDoc$";
		string parameterName2 = ":OracleResult$";
		string parameterName3 = ":OracleTableName$";
		string parameterName4 = ":OracleXslDoc$";
		num3 = 3;
		if (flag)
		{
			num3++;
		}
		BuildXmlSaveCommandText();
		m_utf8CmdText = null;
		if (UTF8CommandText.m_pooler.Get(m_connection.m_internalConStr, m_pooledCmdText) is UTF8CommandText uTF8CommandText && uTF8CommandText.m_utf8CmdText != IntPtr.Zero)
		{
			m_utf8CmdText = uTF8CommandText;
			m_addParam = m_utf8CmdText.m_addParam;
			m_parsed = m_utf8CmdText.m_parsed;
			bFromPool = 1;
		}
		OpoMetValCtx* pOpoMetValCtx = null;
		m_selectStmt = false;
		SetSqlValCtx(bXmlQuerySave: true);
		try
		{
			if (m_addToStmtCache || m_pOpoPrmCtx == null || m_pOpoPrmCtx->NumValCtxElems < num3)
			{
				try
				{
					if (m_utf8CmdText != null)
					{
						pUTF8CommandText = m_utf8CmdText.m_utf8CmdText;
					}
					num2 = OpsSql.Prepare2(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, ref m_pOpoSqlValCtx, (pUTF8CommandText == IntPtr.Zero) ? m_pooledCmdText : null, ref pUTF8CommandText, ref pOpoMetValCtx, num3);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num2 = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num2 != 0)
					{
						if (!m_addToStmtCache && m_pOpoSqlValCtx->pOpoPrmCtx == null)
						{
							m_pOpoPrmCtx = null;
						}
						if (num2 != ErrRes.INT_ERR)
						{
							OracleException.HandleError(num2, m_connection, string.Empty, m_opsErrCtx, m_pOpoSqlValCtx, this);
						}
					}
				}
				if (!m_addToStmtCache && m_pOpoPrmCtx == null)
				{
					m_pOpoPrmCtx = m_pOpoSqlValCtx->pOpoPrmCtx;
				}
			}
			array = new string[num3];
			array2 = new IntPtr[num3];
			if (m_commandText.Length > 32512)
			{
				oracleParameter2 = new OracleParameter(parameterName, OracleDbType.Clob);
				oracleParameter2.Direction = ParameterDirection.Input;
				oracleClob = new OracleClob(m_connection);
				oracleClob.Append(m_commandText.ToCharArray(), 0, m_commandText.Length);
				oracleParameter2.Value = oracleClob;
			}
			else
			{
				oracleParameter2 = new OracleParameter(parameterName, OracleDbType.Varchar2);
				oracleParameter2.Direction = ParameterDirection.Input;
				oracleParameter2.Value = m_commandText;
			}
			oracleParameter = new OracleParameter();
			oracleParameter.ParameterName = parameterName2;
			oracleParameter.DbType = DbType.Int32;
			oracleParameter.Direction = ParameterDirection.Output;
			oracleParameter3 = new OracleParameter(parameterName3, OracleDbType.Varchar2);
			oracleParameter3.Direction = ParameterDirection.Input;
			if (m_xmlSaveProperties.Table == null)
			{
				oracleParameter3.Value = string.Empty;
			}
			else
			{
				oracleParameter3.Value = m_xmlSaveProperties.Table;
			}
			if (flag)
			{
				if (m_connection.m_majorVersion == 8 && m_connection.m_minorVersion == 1 && m_xmlSaveProperties.Xslt.Length <= 32512)
				{
					oracleParameter4 = new OracleParameter(parameterName4, OracleDbType.Varchar2);
					oracleParameter4.Direction = ParameterDirection.Input;
					oracleParameter4.Value = m_xmlSaveProperties.Xslt;
				}
				else
				{
					oracleParameter4 = new OracleParameter(parameterName4, OracleDbType.Clob);
					oracleParameter4.Direction = ParameterDirection.Input;
					oracleClob2 = new OracleClob(m_connection);
					oracleClob2.Append(m_xmlSaveProperties.Xslt.ToCharArray(), 0, m_xmlSaveProperties.Xslt.Length);
					oracleParameter4.Value = oracleClob2;
				}
			}
			oracleParameter2.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx;
			try
			{
				oracleParameter2.PreBind(m_connection, m_opsErrCtx, 0);
			}
			catch (Exception)
			{
				oracleClob?.Close();
				oracleClob2?.Close();
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			oracleParameter.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + 1;
			try
			{
				oracleParameter.PreBind(m_connection, m_opsErrCtx, 0);
			}
			catch (Exception)
			{
				oracleParameter2.PreBindFree(m_connection, 0);
				oracleClob?.Close();
				oracleClob2?.Close();
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			oracleParameter3.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + 2;
			try
			{
				oracleParameter3.PreBind(m_connection, m_opsErrCtx, 0);
			}
			catch (Exception)
			{
				oracleParameter.PreBindFree(m_connection, 0);
				oracleParameter2.PreBindFree(m_connection, 0);
				oracleClob?.Close();
				oracleClob2?.Close();
				FreeNonCachedOpoPrmCtx();
				throw;
			}
			if (flag)
			{
				oracleParameter4.m_pOpoPrmValCtx = m_pOpoSqlValCtx->pOpoPrmCtx->pOpoPrmValCtx + 3;
				try
				{
					oracleParameter4.PreBind(m_connection, m_opsErrCtx, 0);
				}
				catch (Exception)
				{
					oracleParameter3.PreBindFree(m_connection, 0);
					oracleParameter.PreBindFree(m_connection, 0);
					oracleParameter2.PreBindFree(m_connection, 0);
					oracleClob?.Close();
					oracleClob2?.Close();
					FreeNonCachedOpoPrmCtx();
					throw;
				}
			}
			array[0] = oracleParameter2.m_paramName;
			array[1] = oracleParameter.m_paramName;
			array[2] = oracleParameter3.m_paramName;
			if (flag)
			{
				array[3] = oracleParameter4.m_paramName;
			}
			ref IntPtr reference = ref array2[0];
			reference = (IntPtr)oracleParameter2.m_pOpoPrmValCtx;
			ref IntPtr reference2 = ref array2[1];
			reference2 = (IntPtr)oracleParameter.m_pOpoPrmValCtx;
			ref IntPtr reference3 = ref array2[2];
			reference3 = (IntPtr)oracleParameter3.m_pOpoPrmValCtx;
			if (flag)
			{
				ref IntPtr reference4 = ref array2[3];
				reference4 = (IntPtr)oracleParameter4.m_pOpoPrmValCtx;
			}
			try
			{
				if (m_utf8CmdText != null)
				{
					pUTF8CommandText = m_utf8CmdText.m_utf8CmdText;
				}
				if (m_commandTimeout > 0)
				{
					cmdTimeoutCtx = new CmdTimeoutCtx(m_opsConCtx, m_commandTimeout);
					TimerCallback callback = cmdTimeoutCtx.TimeoutNew;
					long num4 = (long)m_commandTimeout * 1000L;
					if (num4 > 4147200000u)
					{
						num4 = 4147200000L;
					}
					timer = new Timer(callback, cmdTimeoutCtx, num4, -1L);
					if (cmdTimeoutCtx.m_bDoneOCIBreak)
					{
						string text = null;
						text = ((m_commandType != CommandType.StoredProcedure) ? string.Empty : m_commandText);
						num2 = 1013;
						OracleException.HandleError(num2, m_connection, text, m_opsErrCtx, m_pOpoSqlValCtx, this);
					}
				}
				num2 = 0;
				if (m_connection.m_opoConCtx.m_bSelfTuning && m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
				{
					m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
					num2 = OpsCon.SetStatementCacheSize(m_opsConCtx, ref m_opsErrCtx, m_connection.m_opoConCtx.pOpoConValCtx);
					if (m_connection.m_opoConCtx.m_conPooler != null)
					{
						m_connection.m_opoConCtx.m_conPooler.ModifyConPoolerSize(m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize);
					}
				}
				if (num2 == 0)
				{
					m_opsDacCtx = IntPtr.Zero;
					num2 = OpsSql.ExecuteNonQuery(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, ref m_opsDacCtx, opsSubscrCtx, ref isSubscrRegistered, bchgNTFNExcludeRowidInfo, num, ref query_id, ref m_pOpoSqlValCtx, (pUTF8CommandText == IntPtr.Zero || m_selectStmt) ? m_pooledCmdText : null, ref pUTF8CommandText, array2, array, ref pOpoMetValCtx, num3, bFromPool);
				}
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
				num2 = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (m_commandTimeout > 0 && cmdTimeoutCtx != null)
				{
					cmdTimeoutCtx.m_bDoneExecution = true;
					if (!cmdTimeoutCtx.m_hWaitForOciBreakEvent.WaitOne(5000, exitContext: false) && OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (WARN)  OracleCommand::ExecuteXmlSave() WaitOne() timed out \n");
					}
					timer.Dispose();
					cmdTimeoutCtx.Dispose();
				}
				if (dep != null && isSubscrRegistered == 1 && !m_connection.m_contextConnection)
				{
					dep.SetRegisterInfo(m_connection.m_opoConCtx.opoConRefCtx.userID, m_connection.DataSource, m_NTFNReq.IsNotifiedOnce, m_NTFNReq.IsPersistent, m_NTFNReq.Timeout);
				}
				if (num2 != 0)
				{
					oracleParameter2.PreBindFree(m_connection, 0);
					oracleClob?.Close();
					oracleParameter.PreBindFree(m_connection, 0);
					oracleParameter3.PreBindFree(m_connection, 0);
					if (flag)
					{
						oracleParameter4.PreBindFree(m_connection, 0);
						oracleClob2?.Close();
					}
					FreeNonCachedOpoPrmCtx();
					if (num2 != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num2, m_connection, string.Empty, m_opsErrCtx, m_pOpoSqlValCtx, this, bCheck: true);
					}
				}
			}
		}
		finally
		{
			if (pUTF8CommandText != IntPtr.Zero)
			{
				UTF8CommandText uTF8CommandText2 = UTF8CommandText.m_pooler.Get(m_connection.m_internalConStr, m_pooledCmdText) as UTF8CommandText;
				if (uTF8CommandText2 == null)
				{
					if (uTF8CommandText2 == null && m_utf8CmdText == null)
					{
						m_utf8CmdText = new UTF8CommandText(pUTF8CommandText);
					}
					m_utf8CmdText.m_parsed = m_parsed;
					m_utf8CmdText.m_addParam = m_addParam;
					UTF8CommandText.m_pooler.Put(m_connection.m_internalConStr, m_pooledCmdText, m_utf8CmdText);
				}
				else if (m_utf8CmdText == null)
				{
					m_utf8CmdText = new UTF8CommandText(pUTF8CommandText);
				}
			}
		}
		if (dep != null && !m_connection.m_contextConnection)
		{
			dep.m_bIsEnabled = true;
			if (!dep.m_regList.Contains(m_commandText))
			{
				dep.m_regList.Add(m_commandText);
			}
			if (num == 1 && !dep.m_queryIDList.Contains(query_id))
			{
				dep.m_queryIDList.Add(query_id);
			}
		}
		oracleParameter2.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[0];
		oracleParameter.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[1];
		oracleParameter3.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[2];
		try
		{
			if (oracleParameter2.m_bOracleDbTypeExSet)
			{
				oracleParameter2.m_enumType = PrmEnumType.DBTYPE;
			}
			oracleParameter2.PostBind(m_connection, m_pOpoSqlValCtx, 0);
		}
		catch (Exception)
		{
			oracleClob?.Close();
			oracleParameter.PreBindFree(m_connection, 0);
			oracleParameter3.PreBindFree(m_connection, 0);
			if (flag)
			{
				oracleParameter4.PreBindFree(m_connection, 0);
				oracleClob2?.Close();
			}
			FreeNonCachedOpoPrmCtx();
			throw;
		}
		try
		{
			oracleParameter.PostBind(m_connection, m_pOpoSqlValCtx, 0);
		}
		catch (Exception)
		{
			oracleClob?.Close();
			oracleParameter3.PreBindFree(m_connection, 0);
			if (flag)
			{
				oracleParameter4.PreBindFree(m_connection, 0);
				oracleClob2?.Close();
			}
			FreeNonCachedOpoPrmCtx();
			throw;
		}
		try
		{
			oracleParameter3.PostBind(m_connection, m_pOpoSqlValCtx, 0);
		}
		catch (Exception)
		{
			oracleClob?.Close();
			if (flag)
			{
				oracleParameter4.PreBindFree(m_connection, 0);
				oracleClob2?.Close();
			}
			FreeNonCachedOpoPrmCtx();
			throw;
		}
		if (flag)
		{
			oracleParameter4.m_pOpoPrmValCtx = (OpoPrmValCtx*)(void*)array2[3];
			try
			{
				oracleParameter4.PostBind(m_connection, m_pOpoSqlValCtx, 0);
			}
			catch (Exception)
			{
				oracleClob?.Close();
				oracleClob2?.Close();
				FreeNonCachedOpoPrmCtx();
				throw;
			}
		}
		oracleClob?.Close();
		oracleClob2?.Close();
		FreeNonCachedOpoPrmCtx();
		m_rowsAffected = (int)oracleParameter.Value;
		return m_rowsAffected;
	}

	private void BuildXmlQueryCommandText(bool wantResult, string resultParamName)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		bool flag2 = false;
		string text = string.Empty;
		string text2 = string.Empty;
		int majorVersion = m_connection.m_majorVersion;
		int minorVersion = m_connection.m_minorVersion;
		if ((majorVersion == 8 && minorVersion == 1) || (majorVersion == 9 && minorVersion == 0))
		{
			flag = true;
		}
		m_pooledCmdText = m_commandText;
		StringBuilder stringBuilder = new StringBuilder(4096);
		if (m_xmlQueryProperties == null)
		{
			m_xmlQueryProperties = new OracleXmlQueryProperties();
		}
		if (m_xmlQueryProperties.Xslt != null && m_xmlQueryProperties.Xslt.Length != 0)
		{
			flag2 = true;
		}
		if (m_xmlQueryProperties.RootTag != null && m_xmlQueryProperties.RootTag.Length != 0)
		{
			text = m_xmlQueryProperties.RootTag;
		}
		if (m_xmlQueryProperties.RowTag != null && m_xmlQueryProperties.RowTag.Length != 0)
		{
			text2 = m_xmlQueryProperties.RowTag;
		}
		if (flag)
		{
			stringBuilder.Append("declare ");
			stringBuilder.Append("ctx DBMS_XMLQUERY.ctxType; ");
			if (!wantResult)
			{
				stringBuilder.Append("OracleResult CLOB; ");
			}
			stringBuilder.Append("begin ");
			stringBuilder.Append("ctx := DBMS_XMLQUERY.newContext(:OracleSqlQuery$); ");
			stringBuilder.Append("DBMS_XMLQUERY.setRaiseException(ctx, true); ");
			stringBuilder.Append("DBMS_XMLQUERY.setRowIdAttrName(ctx, ''); ");
			stringBuilder.Append("DBMS_XMLQUERY.setDateFormat(ctx, 'yyyy-MM-dd''T''HH:mm:ss.SSS'); ");
			stringBuilder.Append("DBMS_XMLQUERY.useTypeForCollElemTag(ctx); ");
			if (!text.Equals("ROWSET"))
			{
				stringBuilder.Append("DBMS_XMLQUERY.setRowsetTag(ctx, '");
				stringBuilder.Append(text);
				stringBuilder.Append("'); ");
			}
			if (!text2.Equals("ROW"))
			{
				stringBuilder.Append("DBMS_XMLQUERY.setRowTag(ctx, '");
				stringBuilder.Append(text2);
				stringBuilder.Append("'); ");
			}
			if (m_xmlQueryProperties.MaxRows > -1)
			{
				stringBuilder.Append("DBMS_XMLQUERY.setMaxRows(ctx, '");
				stringBuilder.Append(m_xmlQueryProperties.MaxRows.ToString());
				stringBuilder.Append("'); ");
			}
			if (m_parameters != null && m_addParam)
			{
				num = m_parameters.Count;
			}
			for (num2 = 0; num2 < num; num2++)
			{
				string text3 = m_parameters[num2].ParameterName.Trim();
				stringBuilder.Append("DBMS_XMLQUERY.setBindValue(ctx, '");
				stringBuilder.Append(text3.Substring(1));
				stringBuilder.Append("', ");
				stringBuilder.Append(text3);
				stringBuilder.Append("); ");
			}
			if (flag2)
			{
				stringBuilder.Append("DBMS_XMLQUERY.setXSLT(ctx, :OracleXslDoc$, ''); ");
			}
			if (wantResult)
			{
				stringBuilder.Append(resultParamName);
			}
			else
			{
				stringBuilder.Append("OracleResult");
			}
			stringBuilder.Append(" := DBMS_XMLQUERY.getXML(ctx); ");
			stringBuilder.Append("DBMS_XMLQUERY.closeContext(ctx); ");
			stringBuilder.Append("end;");
		}
		else
		{
			stringBuilder.Append("declare ");
			stringBuilder.Append("ctx DBMS_XMLGEN.ctxHandle; ");
			stringBuilder.Append("refcur SYS_REFCURSOR; ");
			if (!wantResult)
			{
				stringBuilder.Append("OracleResult CLOB; ");
			}
			if (flag2)
			{
				stringBuilder.Append("xmlClob CLOB; ");
				stringBuilder.Append("tmpClob CLOB; ");
				stringBuilder.Append("p DBMS_XMLPARSER.Parser; ");
				stringBuilder.Append("xmldoc DBMS_XMLDOM.DOMDocument; ");
				stringBuilder.Append("xsldoc DBMS_XMLDOM.DOMDocument; ");
				stringBuilder.Append("ss DBMS_XSLPROCESSOR.Stylesheet; ");
				stringBuilder.Append("proc DBMS_XSLPROCESSOR.Processor; ");
			}
			stringBuilder.Append("begin ");
			m_pooledCmdText = m_pooledCmdText.Trim();
			stringBuilder.Append("OPEN refcur FOR ");
			stringBuilder.Append(m_pooledCmdText);
			if (m_pooledCmdText.EndsWith(";"))
			{
				stringBuilder.Append(" ");
			}
			else
			{
				stringBuilder.Append("; ");
			}
			stringBuilder.Append("ctx := DBMS_XMLGEN.newContext(refcur); ");
			if (!text.Equals("ROWSET"))
			{
				stringBuilder.Append("DBMS_XMLGEN.setRowSetTag(ctx, '");
				stringBuilder.Append(text);
				stringBuilder.Append("'); ");
			}
			if (!text2.Equals("ROW"))
			{
				stringBuilder.Append("DBMS_XMLGEN.setRowTag(ctx, '");
				stringBuilder.Append(text2);
				stringBuilder.Append("'); ");
			}
			if (m_xmlQueryProperties.MaxRows > -1)
			{
				stringBuilder.Append("DBMS_XMLGEN.setMaxRows(ctx, '");
				stringBuilder.Append(m_xmlQueryProperties.MaxRows.ToString());
				stringBuilder.Append("'); ");
			}
			if (flag2)
			{
				stringBuilder.Append("xmlClob");
			}
			else if (wantResult)
			{
				stringBuilder.Append(resultParamName);
			}
			else
			{
				stringBuilder.Append("OracleResult");
			}
			stringBuilder.Append(" := DBMS_XMLGEN.getXML(ctx); ");
			stringBuilder.Append("DBMS_XMLGEN.closeContext(ctx); ");
			stringBuilder.Append("CLOSE refcur; ");
			if (flag2)
			{
				Build9iXslCommandTextForXmlGen(stringBuilder, wantResult, m_xmlQueryProperties.XsltParams);
			}
			stringBuilder.Append("end;");
		}
		m_pooledCmdText = stringBuilder.ToString();
	}

	private void BuildXmlSaveCommandText()
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		int num2 = 0;
		string[] xsltParamNames = null;
		string[] xsltParamValues = null;
		string text = string.Empty;
		int majorVersion = m_connection.m_majorVersion;
		int minorVersion = m_connection.m_minorVersion;
		if ((majorVersion == 8 && minorVersion == 1) || (majorVersion == 9 && minorVersion == 0))
		{
			flag = true;
		}
		StringBuilder stringBuilder = new StringBuilder(4096);
		if (m_xmlSaveProperties == null)
		{
			m_xmlSaveProperties = new OracleXmlSaveProperties();
		}
		if (m_xmlSaveProperties.Xslt != null && m_xmlSaveProperties.Xslt.Length != 0)
		{
			flag2 = true;
		}
		if (m_xmlSaveProperties.RowTag != null && m_xmlSaveProperties.RowTag.Length != 0)
		{
			text = m_xmlSaveProperties.RowTag;
		}
		stringBuilder.Append("declare ");
		stringBuilder.Append("ctx DBMS_XMLSAVE.ctxType; ");
		if (flag && flag2)
		{
			stringBuilder.Append("xmlClob CLOB; ");
			stringBuilder.Append("tmpClob CLOB; ");
			stringBuilder.Append("p XMLPARSER.Parser; ");
			stringBuilder.Append("xmldoc XMLDOM.DOMDocument; ");
			stringBuilder.Append("xsldoc XMLDOM.DOMDocument; ");
			stringBuilder.Append("ss XSLPROCESSOR.Stylesheet; ");
			stringBuilder.Append("proc XSLPROCESSOR.Processor; ");
		}
		stringBuilder.Append("begin ");
		if (flag && flag2)
		{
			Build8iXslCommandTextForXmlSave(stringBuilder, m_xmlSaveProperties.XsltParams);
		}
		stringBuilder.Append("ctx := DBMS_XMLSAVE.newContext(:OracleTableName$); ");
		if (!text.Equals("ROW"))
		{
			stringBuilder.Append("DBMS_XMLSAVE.setRowTag(ctx, '");
			stringBuilder.Append(text);
			stringBuilder.Append("'); ");
		}
		stringBuilder.Append("DBMS_XMLSAVE.setIgnoreCase(ctx, DBMS_XMLSAVE.MATCH_CASE); ");
		if (!flag)
		{
			stringBuilder.Append("DBMS_XMLSAVE.setSQLToXMLNameEscaping(ctx, true); ");
		}
		stringBuilder.Append("DBMS_XMLSAVE.setDateFormat(ctx, 'yyyy-MM-dd''T''HH:mm:ss.SSS'); ");
		if (m_xmlSaveProperties.KeyColumnsList != null)
		{
			for (num = 0; num < m_xmlSaveProperties.KeyColumnsList.Length && m_xmlSaveProperties.KeyColumnsList[num] != null; num++)
			{
				stringBuilder.Append("DBMS_XMLSAVE.setKeyColumn(ctx, '");
				stringBuilder.Append(m_xmlSaveProperties.KeyColumnsList[num]);
				stringBuilder.Append("'); ");
			}
		}
		if (m_xmlSaveProperties.UpdateColumnsList != null)
		{
			for (num = 0; num < m_xmlSaveProperties.UpdateColumnsList.Length && m_xmlSaveProperties.UpdateColumnsList[num] != null; num++)
			{
				stringBuilder.Append("DBMS_XMLSAVE.setUpdateColumn(ctx, '");
				stringBuilder.Append(m_xmlSaveProperties.UpdateColumnsList[num]);
				stringBuilder.Append("'); ");
			}
		}
		if (!flag && flag2)
		{
			stringBuilder.Append("DBMS_XMLSAVE.setXSLT(ctx, :OracleXslDoc$, ''); ");
			num2 = ParseXsltParams(m_xmlSaveProperties.XsltParams, out xsltParamNames, out xsltParamValues);
			for (num = 0; num < num2; num++)
			{
				stringBuilder.Append("DBMS_XMLSAVE.setXSLTParam(ctx, '");
				stringBuilder.Append(xsltParamNames[num]);
				stringBuilder.Append("', '");
				stringBuilder.Append(xsltParamValues[num]);
				stringBuilder.Append("'); ");
			}
		}
		stringBuilder.Append(":OracleResult$");
		if (flag && flag2)
		{
			if (OracleXmlCommandType.Insert == m_xmlCommandType)
			{
				stringBuilder.Append(" := DBMS_XMLSAVE.insertXML(ctx, xmlClob); ");
			}
			else if (OracleXmlCommandType.Update == m_xmlCommandType)
			{
				stringBuilder.Append(" := DBMS_XMLSAVE.updateXML(ctx, xmlClob); ");
			}
			else if (OracleXmlCommandType.Delete == m_xmlCommandType)
			{
				stringBuilder.Append(" := DBMS_XMLSAVE.deleteXML(ctx, xmlClob); ");
			}
		}
		else if (OracleXmlCommandType.Insert == m_xmlCommandType)
		{
			stringBuilder.Append(" := DBMS_XMLSAVE.insertXML(ctx, :OracleXmlDoc$); ");
		}
		else if (OracleXmlCommandType.Update == m_xmlCommandType)
		{
			stringBuilder.Append(" := DBMS_XMLSAVE.updateXML(ctx, :OracleXmlDoc$); ");
		}
		else if (OracleXmlCommandType.Delete == m_xmlCommandType)
		{
			stringBuilder.Append(" := DBMS_XMLSAVE.deleteXML(ctx, :OracleXmlDoc$); ");
		}
		stringBuilder.Append("DBMS_XMLSAVE.closeContext(ctx); ");
		if (flag && flag2)
		{
			stringBuilder.Append("dbms_lob.freetemporary(xmlClob); ");
		}
		stringBuilder.Append("end;");
		m_pooledCmdText = stringBuilder.ToString();
	}

	private void Build8iXslCommandTextForXmlSave(StringBuilder strBldr, string xsltParams)
	{
		int num = 0;
		string[] xsltParamNames = null;
		string[] xsltParamValues = null;
		int num2 = 0;
		string value = ":OracleXmlDoc$";
		string value2 = "xmlClob";
		strBldr.Append("dbms_lob.createtemporary(tmpClob, TRUE); ");
		strBldr.Append("p := XMLPARSER.newParser; ");
		strBldr.Append("XMLPARSER.setValidationMode(p, FALSE); ");
		strBldr.Append("XMLPARSER.setPreserveWhiteSpace(p, TRUE); ");
		if (m_commandText.Length > 32512)
		{
			strBldr.Append("XMLPARSER.parseClob(p, ");
		}
		else
		{
			strBldr.Append("XMLPARSER.parseBuffer(p, ");
		}
		strBldr.Append(value);
		strBldr.Append("); ");
		strBldr.Append("xmldoc := XMLPARSER.getDocument(p); ");
		if (m_xmlSaveProperties == null)
		{
			m_xmlSaveProperties = new OracleXmlSaveProperties();
		}
		if (m_xmlSaveProperties.Xslt.Length > 32512)
		{
			strBldr.Append("XMLPARSER.parseClob(p, :OracleXslDoc$); ");
		}
		else
		{
			strBldr.Append("XMLPARSER.parseBuffer(p, :OracleXslDoc$); ");
		}
		strBldr.Append("xsldoc := XMLPARSER.getDocument(p); ");
		strBldr.Append("ss := XSLPROCESSOR.newStylesheet(xsldoc, ''); ");
		num = ParseXsltParams(xsltParams, out xsltParamNames, out xsltParamValues);
		for (num2 = 0; num2 < num; num2++)
		{
			strBldr.Append("XSLPROCESSOR.setParam(ss, '");
			strBldr.Append(xsltParamNames[num2]);
			strBldr.Append("', '");
			strBldr.Append(xsltParamValues[num2]);
			strBldr.Append("'); ");
		}
		strBldr.Append("proc := XSLPROCESSOR.newProcessor; ");
		strBldr.Append("XSLPROCESSOR.processXSL(proc, ss, xmldoc, tmpClob); ");
		strBldr.Append(value2);
		strBldr.Append(" := tmpClob; ");
		strBldr.Append("XMLDOM.freeDocument(xmldoc); ");
		strBldr.Append("XMLDOM.freeDocument(xsldoc); ");
		strBldr.Append("XSLPROCESSOR.freeProcessor(proc); ");
		strBldr.Append("XSLPROCESSOR.freeStylesheet(ss); ");
		strBldr.Append("XMLPARSER.freeParser(p); ");
	}

	private void Build9iXslCommandTextForXmlGen(StringBuilder strBldr, bool wantResult, string xsltParams)
	{
		int num = 0;
		string[] xsltParamNames = null;
		string[] xsltParamValues = null;
		int num2 = 0;
		string text = null;
		string text2 = null;
		if (OracleXmlCommandType.Query == m_xmlCommandType)
		{
			text = "xmlClob";
			text2 = ((!wantResult) ? "OracleResult" : ":OracleResult$");
		}
		else
		{
			text = ":OracleXmlDoc$";
			text2 = "xmlClob";
		}
		strBldr.Append("dbms_lob.createtemporary(tmpClob, TRUE); ");
		strBldr.Append("p := DBMS_XMLPARSER.newParser; ");
		strBldr.Append("DBMS_XMLPARSER.setValidationMode(p, FALSE); ");
		strBldr.Append("DBMS_XMLPARSER.setPreserveWhiteSpace(p, TRUE); ");
		if (OracleXmlCommandType.Query == m_xmlCommandType || m_commandText.Length > 32512)
		{
			strBldr.Append("DBMS_XMLPARSER.parseClob(p, ");
		}
		else
		{
			strBldr.Append("DBMS_XMLPARSER.parseBuffer(p, ");
		}
		strBldr.Append(text);
		strBldr.Append("); ");
		strBldr.Append("xmldoc := DBMS_XMLPARSER.getDocument(p); ");
		if (m_xmlQueryProperties == null)
		{
			m_xmlQueryProperties = new OracleXmlQueryProperties();
		}
		if (m_xmlSaveProperties == null)
		{
			m_xmlSaveProperties = new OracleXmlSaveProperties();
		}
		if ((OracleXmlCommandType.Query == m_xmlCommandType && m_xmlQueryProperties.Xslt.Length > 32512) || (OracleXmlCommandType.Query != m_xmlCommandType && m_xmlSaveProperties.Xslt.Length > 32512))
		{
			strBldr.Append("DBMS_XMLPARSER.parseClob(p, :OracleXslDoc$); ");
		}
		else
		{
			strBldr.Append("DBMS_XMLPARSER.parseBuffer(p, :OracleXslDoc$); ");
		}
		strBldr.Append("xsldoc := DBMS_XMLPARSER.getDocument(p); ");
		strBldr.Append("ss := DBMS_XSLPROCESSOR.newStylesheet(xsldoc, ''); ");
		num = ParseXsltParams(xsltParams, out xsltParamNames, out xsltParamValues);
		for (num2 = 0; num2 < num; num2++)
		{
			strBldr.Append("DBMS_XSLPROCESSOR.setParam(ss, '");
			strBldr.Append(xsltParamNames[num2]);
			strBldr.Append("', '");
			strBldr.Append(xsltParamValues[num2]);
			strBldr.Append("'); ");
		}
		strBldr.Append("proc := DBMS_XSLPROCESSOR.newProcessor; ");
		strBldr.Append("DBMS_XSLPROCESSOR.processXSL(proc, ss, xmldoc, tmpClob); ");
		strBldr.Append(text2);
		strBldr.Append(" := tmpClob; ");
		strBldr.Append("DBMS_XMLDOM.freeDocument(xmldoc); ");
		strBldr.Append("DBMS_XMLDOM.freeDocument(xsldoc); ");
		strBldr.Append("DBMS_XSLPROCESSOR.freeProcessor(proc); ");
		strBldr.Append("DBMS_XSLPROCESSOR.freeStylesheet(ss); ");
		strBldr.Append("DBMS_XMLPARSER.freeParser(p); ");
		strBldr.Append("dbms_lob.freetemporary(tmpClob); ");
	}

	private int ParseXsltParams(string xsltParams, out string[] xsltParamNames, out string[] xsltParamValues)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string text = null;
		string text2 = null;
		string text3 = null;
		int num5 = 1;
		int num6 = 0;
		int num7 = 0;
		xsltParamNames = null;
		xsltParamValues = null;
		if (xsltParams == null || xsltParams.Length == 0)
		{
			return num6;
		}
		num = 0;
		while (-1 != (num3 = xsltParams.IndexOf(";", num)))
		{
			num5++;
			num = num3 + 1;
		}
		xsltParamNames = new string[num5];
		xsltParamValues = new string[num5];
		num = 0;
		for (num7 = 0; num7 < num5; num7++)
		{
			num3 = xsltParams.IndexOf(";", num);
			num2 = ((-1 != num3) ? num3 : xsltParams.Length);
			text = xsltParams.Substring(num, num2 - num);
			if (text != null && text.Length != 0 && -1 != (num4 = text.IndexOf("=")))
			{
				text2 = text.Substring(0, num4).Trim();
				if (text2 != null && text2.Length != 0)
				{
					text3 = text.Substring(num4 + 1).Trim();
					xsltParamNames[num6] = text2;
					xsltParamValues[num6] = text3;
					num6++;
				}
			}
			num = num2 + 1;
		}
		return num6;
	}

	private string[] GetPlsqlOutput()
	{
		int rowsToFetch = 1024;
		string[] array = null;
		if (m_connection == null)
		{
			throw new InvalidOperationException();
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_opsConCtx != m_connection.m_opoConCtx.opsConCtx)
		{
			if (m_opsConCtx != IntPtr.Zero)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
			int num = 0;
			if (m_opsConCtx != IntPtr.Zero)
			{
				try
				{
					num = OpsCon.AddRef(m_opsConCtx);
					if (num <= 1)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
					}
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
		}
		ArrayList arrayList = new ArrayList(32);
		while (rowsToFetch == 1024)
		{
			array = new string[rowsToFetch];
			try
			{
				OpsDac.GetPlsqlOutput(m_opsConCtx, m_opsErrCtx, array, ref rowsToFetch);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			arrayList.Add(array);
		}
		int num2 = rowsToFetch + (arrayList.Count - 1) * 1024;
		string[] array2 = new string[num2];
		int num3 = 0;
		int i = 0;
		int num4 = 0;
		for (; i < arrayList.Count; i++)
		{
			string[] array3 = (string[])arrayList[i];
			num3 = ((i != arrayList.Count - 1) ? 1024 : rowsToFetch);
			int num5 = 0;
			while (num5 < num3)
			{
				array2[num4] = array3[num5];
				num5++;
				num4++;
			}
		}
		return array2;
	}

	private static bool isSelectStatement(string text)
	{
		char c = ' ';
		int length = text.Length;
		int i = 0;
		if (length >= 6)
		{
			for (; i < length; i++)
			{
				c = text[i];
				switch (c)
				{
				case '\t':
				case '\n':
				case '\v':
				case '\f':
				case '\r':
				case ' ':
					continue;
				}
				break;
			}
			if (length - i >= 6 && (c == 's' || c == 'S'))
			{
				c = text[++i];
				if (c == 'e' || c == 'E')
				{
					c = text[++i];
					if (c == 'l' || c == 'L')
					{
						c = text[++i];
						if (c == 'e' || c == 'E')
						{
							c = text[++i];
							if (c == 'c' || c == 'C')
							{
								c = text[++i];
								if (c == 't' || c == 'T')
								{
									return true;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	private unsafe void CheckConStatus()
	{
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_conSignature != m_connection.m_conSignature)
		{
			if (m_metaData != null)
			{
				m_metaData = null;
			}
			if ((m_pOpoSqlValCtx != null && m_pOpoSqlValCtx->pSnapShot != IntPtr.Zero) || (m_pOpoPrmCtx != null && m_pOpoPrmCtx->m_pAttrRefTdo != IntPtr.Zero))
			{
				try
				{
					OpsSql.FreeRefTDOandOCISnapShot(m_pOpoPrmCtx, m_pOpoSqlValCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			if (m_opsSqlCtx != IntPtr.Zero)
			{
				try
				{
					if (!m_addToStmtCache)
					{
						OpsSql.FreeCtx(ref m_opsSqlCtx, m_opsErrCtx, 0);
					}
					else
					{
						OpsSql.FreeCtx(ref m_opsSqlCtx, m_opsErrCtx, 1);
					}
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_opsSqlCtx = IntPtr.Zero;
			}
			if (m_opsErrCtx != IntPtr.Zero)
			{
				try
				{
					OpsErr.FreeCtx(ref m_opsErrCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				m_opsErrCtx = IntPtr.Zero;
			}
			m_conSignature = m_connection.m_conSignature;
		}
		if (!(m_opsConCtx != m_connection.m_opoConCtx.opsConCtx))
		{
			return;
		}
		if (m_opsConCtx != IntPtr.Zero)
		{
			try
			{
				OpsCon.RelRef(ref m_opsConCtx);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
			}
		}
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		try
		{
			int num = OpsCon.AddRef(m_opsConCtx);
			if (num <= 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
		}
		catch (Exception ex5)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex5);
			}
			throw;
		}
	}

	private unsafe void SetSqlValCtx(bool bXmlQuerySave)
	{
		if (m_pOpoSqlValCtx == null)
		{
			try
			{
				OpsSql.AllocSqlValCtx(ref m_pOpoSqlValCtx);
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
		if (m_selectStmt || (m_connection.m_oraTransaction != null && !m_connection.m_oraTransaction.Completed))
		{
			m_pOpoSqlValCtx->mode = 0u;
		}
		else if (m_connection.m_opoConCtx.pOpoConValCtx != null && m_connection.m_opoConCtx.pOpoConValCtx->InMtsTxn == 1)
		{
			m_pOpoSqlValCtx->mode = 0u;
		}
		else if (m_connection.m_contextConnection)
		{
			m_pOpoSqlValCtx->mode = 0u;
		}
		else
		{
			m_pOpoSqlValCtx->mode = 32u;
		}
		if (m_arrayBindCount > 1)
		{
			m_pOpoSqlValCtx->mode |= 128u;
		}
		if (m_connection.m_opoConCtx.pOpoConValCtx->OSAuthent.Equals(OSAuthent.ProxyUser) || (m_connection.m_opoConCtx.opoConRefCtx.proxyUserId != null && m_connection.m_opoConCtx.opoConRefCtx.proxyUserId.Length > 0))
		{
			m_addToStmtCache = false;
			m_pOpoSqlValCtx->AddToStmtCache = 0;
			m_pOpoSqlValCtx->pOpoPrmCtx = m_pOpoPrmCtx;
		}
		else if (m_connection.m_opoConCtx.pOpoConValCtx->StmtCacheSize > 0 && !m_addToStatementCache)
		{
			m_addToStmtCache = false;
			m_pOpoSqlValCtx->AddToStmtCache = 0;
			m_pOpoSqlValCtx->pOpoPrmCtx = m_pOpoPrmCtx;
		}
		else
		{
			m_addToStmtCache = true;
			m_pOpoSqlValCtx->AddToStmtCache = 1;
			m_pOpoSqlValCtx->pOpoPrmCtx = null;
		}
		m_pOpoSqlValCtx->RowsAffected = m_rowsAffected;
		m_pOpoSqlValCtx->StmtPrepared = 0;
		if (m_isFromEF)
		{
			m_pOpoSqlValCtx->bIsFromEF = 1;
		}
		else
		{
			m_pOpoSqlValCtx->bIsFromEF = 0;
		}
		if (!bXmlQuerySave)
		{
			if (m_bindByName && m_commandType != CommandType.StoredProcedure)
			{
				m_pOpoSqlValCtx->BindByName = 1;
			}
			else
			{
				m_pOpoSqlValCtx->BindByName = 0;
			}
			if (m_localParse)
			{
				m_pOpoSqlValCtx->LocalParse = 1;
			}
			else
			{
				m_pOpoSqlValCtx->LocalParse = 0;
			}
			if (!m_addRowid)
			{
				m_pOpoSqlValCtx->AddRowid = 0;
			}
			else
			{
				m_pOpoSqlValCtx->AddRowid = 1;
			}
			if (m_arrayBindCount == 0)
			{
				m_pOpoSqlValCtx->ArraySize = 1;
			}
			else
			{
				m_pOpoSqlValCtx->ArraySize = m_arrayBindCount;
			}
			m_pOpoSqlValCtx->FetchSize = m_fetchSize;
			m_pOpoSqlValCtx->InitialLongFS = m_initialLongFS;
			if (m_connection.m_majorVersion == 8)
			{
				m_pOpoSqlValCtx->InitialLobFS = 0;
			}
			else
			{
				m_pOpoSqlValCtx->InitialLobFS = m_initialLobFS;
			}
		}
		else
		{
			m_pOpoSqlValCtx->BindByName = 1;
			m_pOpoSqlValCtx->LocalParse = 0;
			m_pOpoSqlValCtx->AddRowid = 0;
			m_pOpoSqlValCtx->ArraySize = 1;
			m_pOpoSqlValCtx->FetchSize = 0L;
			m_pOpoSqlValCtx->InitialLongFS = 65536;
		}
	}

	private void AddRefCursorParamToParamColl(RefCursorInfo cursorInfo)
	{
		OracleParameter oracleParameter = new OracleParameter();
		oracleParameter.ParameterName = cursorInfo.name;
		oracleParameter.OracleDbType = OracleDbType.RefCursor;
		oracleParameter.Direction = cursorInfo.mode;
		if (m_parameters == null)
		{
			m_parameters = new OracleParameterCollection();
		}
		if (cursorInfo.position >= 0 && m_parameters.Count > cursorInfo.position)
		{
			m_parameters.Insert(cursorInfo.position, oracleParameter);
		}
		else
		{
			m_parameters.Add(oracleParameter);
		}
	}

	protected override DbParameter CreateDbParameter()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommand::CreateDbParameter()\n");
		}
		OracleParameter result = new OracleParameter();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommand::CreateDbParameter()\n");
		}
		return result;
	}

	protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
	{
		OracleDataReader oracleDataReader = ExecuteReader(requery: true, fillRequest: false, behavior);
		oracleDataReader.m_returnPSTypes = m_returnPSTypes;
		return oracleDataReader;
	}
}

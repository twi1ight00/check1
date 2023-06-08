using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.EnterpriseServices;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Xml;

namespace Oracle.DataAccess.Client;

[DefaultEvent("InfoMessage")]
[ToolboxBitmap(typeof(resfinder), "Oracle.DataAccess.src.Client.Icons.OracleConnectionToolBox_hc.bmp")]
[SecurityPermission(SecurityAction.Assert, ControlThread = true)]
public sealed class OracleConnection : DbConnection, ICloneable
{
	internal class ExtProcEnv
	{
		internal bool m_status = true;
	}

	private class ThreadData
	{
		internal OracleConnection m_externalExtprocConn;

		internal OracleConnection m_internalExtprocConn;

		internal IntPtr m_ociExtProcContext;

		internal ExtProcEnv m_extProcEnv;

		internal ThreadData(IntPtr ociExtProcContext)
		{
			m_ociExtProcContext = ociExtProcContext;
			m_extProcEnv = new ExtProcEnv();
		}
	}

	private class PSPEPrimaryConnectionInfo
	{
		internal bool m_dbSupportPromotion;

		internal int m_pspeAttributeValue;

		internal PSPEPrimaryConnectionInfo(bool bSupportPromotion, int pspeAttrVal)
		{
			m_dbSupportPromotion = bSupportPromotion;
			m_pspeAttributeValue = pspeAttrVal;
		}
	}

	private const string METADATA_COLLECTION = "METADATACOLLECTIONS";

	private const string DATA_TYPES = "DATATYPES";

	private const string RESTRICTIONS = "RESTRICTIONS";

	private const string RESERVED_WORDS = "RESERVEDWORDS";

	private const string DATA_SOURCE_INFORMATION = "DATASOURCEINFORMATION";

	private const string ORCL_COMMAND = "ORACLECOMMAND";

	private const string DATA_TABLE = "DATATABLE";

	internal const string m_sDynamic = "dynamic";

	internal const string m_sSysdba = "sysdba";

	internal const string m_sSysoper = "sysoper";

	internal const string m_sLocal = "local";

	internal const string m_sPromotable = "promotable";

	private static LocalDataStoreSlot m_oraThreadDataSlot;

	private static bool m_extproc;

	private static bool m_extprocFlagRead;

	internal bool m_bPrelimAuthSession;

	internal bool m_bStartupShutdown;

	private static object s_lockObj;

	private static char[] trimSpaces;

	private static char[] doubleQuotes;

	private static char[] semiColon;

	private static char[] equalSign;

	private DataSet m_metaDataCollectionDS;

	internal string m_conString;

	private string m_dataSource;

	private string m_serverVersion;

	private int m_conTimeout;

	internal ConnectionState m_state;

	private object[] m_conStrVals;

	private string m_tmpConString;

	private static Hashtable m_boolMapping;

	private static SortedList m_AttribToIndex;

	internal OpoConCtx m_opoConCtx;

	internal bool m_disposed;

	internal OracleTransaction m_oraTransaction;

	private bool m_validConString;

	internal int m_conSignature;

	private bool m_openWithNewPwd;

	private string m_pwdLessString;

	private string m_pwdOSLessString;

	private bool m_pwdValidated;

	internal string m_internalConStr;

	internal bool m_conStrValsFromPool;

	internal bool m_persist;

	internal bool m_contextConnection;

	internal bool m_internalUse;

	internal ExtProcEnv m_extProcEnv;

	internal int m_majorVersion;

	internal int m_minorVersion;

	internal int m_PatchSetVersion;

	internal static char[] delim;

	internal static char[] delim1;

	internal static char[] delim2;

	internal string m_password;

	internal string m_proxyPassword;

	internal int m_stmtCacheSize = OraTrace.m_StmtCacheSize;

	internal OraFailoverCallback_FPtr cb;

	internal OracleInfoMessageEventHandler m_infoMessageEventHandler;

	internal StateChangeEventHandler m_stateChangeEventHandler;

	internal OracleFailoverEventHandler m_failoverEventHandler;

	internal static OracleHAEventHandler m_haEventHandler;

	internal int m_enlist;

	internal static Hashtable m_pspePrimaryResourceEntry;

	internal bool m_bLocalTxnStartedForSysTxn;

	internal PromotableTxnMgr m_promoteTxnMgr;

	internal object m_syncTxnComplete = new object();

	internal static string ConStrAtrribs;

	internal static int IndexUserID;

	internal static int IndexPasswd;

	internal static int IndexDataSrc;

	internal static int IndexProxyUsr;

	internal static int IndexProxyPwd;

	internal static int IndexDBAPriv;

	internal static int IndexPSPE;

	internal static int IndexAppEdition;

	internal static int IndexStrAttribMax;

	internal static int IndexLifetime;

	internal static int IndexPoolInc;

	internal static int IndexPoolDec;

	internal static int IndexTimeout;

	internal static int IndexMaxPool;

	internal static int IndexMinPool;

	internal static int IndexPoolReg;

	internal static int IndexStmtCache;

	internal static int IndexIntAttribMax;

	internal static int IndexEnlist;

	internal static int IndexPersist;

	internal static int IndexPooling;

	internal static int IndexValidCon;

	internal static int IndexMetaPool;

	internal static int IndexStmtCachePurge;

	internal static int IndexGridCR;

	internal static int IndexGridRLB;

	internal static int IndexCtxConn;

	internal static int IndexSelfTuning;

	internal static int IndexBoolAttribMax;

	internal static int IndexInternalConStr;

	internal static int IndexConStrHashCode;

	private OraclePermission m_orclPermission;

	internal string m_databaseName;

	internal string m_databaseDomainName;

	internal string m_serviceName;

	internal string m_instanceName;

	internal string m_hostName;

	internal ArrayList m_DataReaderList;

	internal static bool s_bIsOdtConnection;

	internal object m_tuningLock = new object();

	[DefaultValue("")]
	[Category("Data")]
	[System.ComponentModel.Description("")]
	public string ClientId
	{
		set
		{
			int num = 0;
			if (State == ConnectionState.Closed)
			{
				OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
			}
			m_opoConCtx.opoConRefCtx.clientID = value;
			if (m_opoConCtx.opoConRefCtx.clientID == null)
			{
				m_opoConCtx.opoConRefCtx.clientID = "";
			}
			try
			{
				num = OpsCon.SetClientId(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, m_opoConCtx.opoConRefCtx);
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
					OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
				}
			}
		}
	}

	[DefaultValue("")]
	[System.ComponentModel.Description("")]
	[Category("Data")]
	public string ModuleName
	{
		set
		{
			int num = 0;
			if (State == ConnectionState.Closed)
			{
				OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
			}
			m_opoConCtx.opoConRefCtx.moduleName = value;
			if (m_opoConCtx.opoConRefCtx.moduleName == null)
			{
				m_opoConCtx.opoConRefCtx.moduleName = "";
			}
			try
			{
				num = OpsCon.SetModuleName(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, m_opoConCtx.opoConRefCtx);
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
					OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
				}
			}
		}
	}

	[Category("Data")]
	[DefaultValue("")]
	[System.ComponentModel.Description("")]
	public string ActionName
	{
		set
		{
			int num = 0;
			if (State == ConnectionState.Closed)
			{
				OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
			}
			m_opoConCtx.opoConRefCtx.actionName = value;
			if (m_opoConCtx.opoConRefCtx.actionName == null)
			{
				m_opoConCtx.opoConRefCtx.actionName = "";
			}
			try
			{
				num = OpsCon.SetActionName(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, m_opoConCtx.opoConRefCtx);
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
					OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
				}
			}
		}
	}

	[DefaultValue("")]
	[Category("Data")]
	[System.ComponentModel.Description("")]
	public string ServiceName => m_serviceName;

	[Category("Data")]
	[DefaultValue("")]
	[System.ComponentModel.Description("")]
	public string DatabaseName => m_databaseName;

	[System.ComponentModel.Description("")]
	[DefaultValue("")]
	[Category("Data")]
	public string DatabaseDomainName => m_databaseDomainName;

	[System.ComponentModel.Description("")]
	[Category("Data")]
	[DefaultValue("")]
	public string HostName => m_hostName;

	[System.ComponentModel.Description("")]
	[DefaultValue("")]
	[Category("Data")]
	public string InstanceName => m_instanceName;

	[DefaultValue(0)]
	[System.ComponentModel.Description("")]
	[Browsable(false)]
	public int StatementCacheSize => m_stmtCacheSize;

	[DefaultValue("")]
	[System.ComponentModel.Description("")]
	[Category("Data")]
	public string ClientInfo
	{
		set
		{
			int num = 0;
			if (State == ConnectionState.Closed)
			{
				OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
			}
			m_opoConCtx.opoConRefCtx.clientInfo = value;
			if (m_opoConCtx.opoConRefCtx.clientInfo == null)
			{
				m_opoConCtx.opoConRefCtx.clientInfo = "";
			}
			try
			{
				num = OpsCon.SetClientInfo(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, m_opoConCtx.opoConRefCtx);
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
					OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
				}
			}
		}
	}

	[System.ComponentModel.Description("")]
	[DefaultValue("")]
	[Editor("Oracle.VsDevTools.OracleVSGConnStringEditor, Oracle.VsDevTools, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342, processorArchitecture=X86", "System.Drawing.Design.UITypeEditor")]
	[Category("Data")]
	public override string ConnectionString
	{
		get
		{
			if (m_conString == null || m_conString.Length == 0)
			{
				return string.Empty;
			}
			if (m_persist || !m_pwdValidated)
			{
				return m_conString;
			}
			if (m_pwdOSLessString == null)
			{
				m_pwdOSLessString = GetPasswordLessString(m_conString);
				return m_pwdOSLessString;
			}
			return m_pwdOSLessString;
		}
		set
		{
			if (m_state == ConnectionState.Open)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_NOT_UPDATABLE));
			}
			if (!(value != m_conString))
			{
				return;
			}
			if (m_validConString)
			{
				m_tmpConString = m_conString;
			}
			m_validConString = false;
			if (value != null)
			{
				m_conString = value;
			}
			else
			{
				m_conString = string.Empty;
			}
			m_pwdLessString = GetPasswordLessStringEx(m_conString, out m_password, out m_proxyPassword);
			if (MetaData.m_connDataPooler.Get(ConStrAtrribs, m_pwdLessString) is object[] conStrVals)
			{
				m_conStrVals = conStrVals;
				m_internalConStr = m_conStrVals[IndexInternalConStr] as string;
				m_conStrValsFromPool = true;
			}
			else
			{
				if (m_conStrVals == null || m_conStrValsFromPool)
				{
					m_conStrVals = new object[29];
					m_conStrValsFromPool = false;
				}
				ResetAttribsToDefaults();
				ParseConnectionString();
			}
			if ((int)m_conStrVals[IndexCtxConn] == 1)
			{
				m_contextConnection = true;
				m_conStrVals[IndexLifetime] = 0;
				m_conTimeout = 0;
			}
			else
			{
				m_contextConnection = false;
				m_conTimeout = (int)m_conStrVals[IndexTimeout];
			}
			m_dataSource = (string)m_conStrVals[IndexDataSrc];
			m_stmtCacheSize = (int)m_conStrVals[IndexStmtCache];
			m_tmpConString = null;
			m_validConString = true;
			m_pwdValidated = false;
			m_conSignature = 0;
			if ((int)m_conStrVals[IndexPersist] == 1)
			{
				m_persist = true;
			}
			else
			{
				m_persist = false;
			}
			if (1 == OraTrace.m_demandOrclPermission)
			{
				if (m_orclPermission == null)
				{
					m_orclPermission = new OraclePermission(PermissionState.None);
				}
				m_orclPermission.Clear();
				m_orclPermission.Add(value, "", KeyRestrictionBehavior.AllowOnly);
			}
		}
	}

	[Browsable(false)]
	[DefaultValue(15)]
	[System.ComponentModel.Description("")]
	public override int ConnectionTimeout => m_conTimeout;

	public override string Database => string.Empty;

	[DefaultValue("")]
	[System.ComponentModel.Description("")]
	public override string DataSource
	{
		get
		{
			if (m_dataSource != null)
			{
				return m_dataSource;
			}
			return string.Empty;
		}
	}

	[System.ComponentModel.Description("")]
	[Browsable(false)]
	[DefaultValue("")]
	public override string ServerVersion
	{
		get
		{
			if (m_state == ConnectionState.Open)
			{
				if (m_opoConCtx.pooledConCtx != null)
				{
					return m_opoConCtx.pooledConCtx.opoConRefCtx.serverVersion;
				}
				return m_serverVersion;
			}
			throw new InvalidOperationException();
		}
	}

	[System.ComponentModel.Description("")]
	[DefaultValue(ConnectionState.Closed)]
	[Browsable(false)]
	public override ConnectionState State => m_state;

	internal unsafe int TxnHndAllocated
	{
		get
		{
			return m_opoConCtx.pOpoConValCtx->TxnHndAllocated;
		}
		set
		{
			m_opoConCtx.pOpoConValCtx->TxnHndAllocated = value;
		}
	}

	internal static bool IsCtxConnAvailable
	{
		get
		{
			if (m_oraThreadDataSlot == null)
			{
				return false;
			}
			object data = Thread.GetData(m_oraThreadDataSlot);
			if (data != null)
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsDBVer10gR2OrHigher
	{
		get
		{
			if (m_majorVersion > 10 || (m_majorVersion == 10 && m_minorVersion >= 2))
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsDBVer11gR1OrHigher
	{
		get
		{
			if (m_majorVersion > 11 || (m_majorVersion == 11 && m_minorVersion >= 1))
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsDBVer11gR2OrHigher
	{
		get
		{
			if (m_majorVersion > 11 || (m_majorVersion == 11 && m_minorVersion >= 2))
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsDBVer_11_1_0_7_OrHigher
	{
		get
		{
			if (m_majorVersion > 11 || (m_majorVersion == 11 && m_minorVersion > 1) || (m_majorVersion == 11 && m_minorVersion == 1 && m_PatchSetVersion >= 7))
			{
				return true;
			}
			return false;
		}
	}

	public unsafe OracleConnectionType ConnectionType
	{
		get
		{
			if (State == ConnectionState.Closed || m_opoConCtx.pOpoConValCtx == null)
			{
				return OracleConnectionType.Undefined;
			}
			if (m_opoConCtx.pOpoConValCtx->bIsTimesTen != 0)
			{
				return OracleConnectionType.TimesTen;
			}
			return OracleConnectionType.Oracle;
		}
	}

	public static bool IsAvailable
	{
		get
		{
			if (!m_extprocFlagRead)
			{
				if (OpsCom.GetExtProcFlag() == 1)
				{
					m_extproc = true;
				}
				else
				{
					m_extproc = false;
				}
				m_extprocFlagRead = true;
			}
			return m_extproc;
		}
	}

	private static OracleConnection ExternalContextConnection
	{
		get
		{
			ThreadData threadData = Thread.GetData(m_oraThreadDataSlot) as ThreadData;
			return threadData.m_externalExtprocConn;
		}
		set
		{
			ThreadData threadData = Thread.GetData(m_oraThreadDataSlot) as ThreadData;
			threadData.m_externalExtprocConn = value;
		}
	}

	private static OracleConnection InternalContextConnection
	{
		get
		{
			ThreadData threadData = Thread.GetData(m_oraThreadDataSlot) as ThreadData;
			return threadData.m_internalExtprocConn;
		}
		set
		{
			ThreadData threadData = Thread.GetData(m_oraThreadDataSlot) as ThreadData;
			threadData.m_internalExtprocConn = value;
		}
	}

	protected override DbProviderFactory DbProviderFactory => OracleClientFactory.Instance;

	public event OracleInfoMessageEventHandler InfoMessage
	{
		add
		{
			m_infoMessageEventHandler = (OracleInfoMessageEventHandler)Delegate.Combine(m_infoMessageEventHandler, value);
		}
		remove
		{
			m_infoMessageEventHandler = (OracleInfoMessageEventHandler)Delegate.Remove(m_infoMessageEventHandler, value);
		}
	}

	public override event StateChangeEventHandler StateChange
	{
		add
		{
			m_stateChangeEventHandler = (StateChangeEventHandler)Delegate.Combine(m_stateChangeEventHandler, value);
		}
		remove
		{
			m_stateChangeEventHandler = (StateChangeEventHandler)Delegate.Remove(m_stateChangeEventHandler, value);
		}
	}

	public static event OracleHAEventHandler HAEvent
	{
		add
		{
			m_haEventHandler = (OracleHAEventHandler)Delegate.Combine(m_haEventHandler, value);
		}
		remove
		{
			m_haEventHandler = (OracleHAEventHandler)Delegate.Remove(m_haEventHandler, value);
		}
	}

	public event OracleFailoverEventHandler Failover
	{
		add
		{
			if (m_contextConnection)
			{
				throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_CTX_CONN));
			}
			if (m_state != ConnectionState.Open)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			int num = 0;
			bool flag = false;
			flag = m_failoverEventHandler != null;
			m_failoverEventHandler = value;
			if (flag)
			{
				return;
			}
			cb = OnFailoverCallback_fn;
			try
			{
				num = OpsCon.RegisterFailoverCallback(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, cb);
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
					OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		remove
		{
			if (m_contextConnection)
			{
				throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_CTX_CONN));
			}
			m_failoverEventHandler = (OracleFailoverEventHandler)Delegate.Remove(m_failoverEventHandler, value);
		}
	}

	internal void AcceptStatementData(string stmtText)
	{
		try
		{
			StatementDetails statementDetails = m_opoConCtx.m_statementData[stmtText] as StatementDetails;
			if (statementDetails == null)
			{
				lock (m_tuningLock)
				{
					statementDetails = m_opoConCtx.m_statementData[stmtText] as StatementDetails;
					if (statementDetails == null)
					{
						statementDetails = new StatementDetails();
						m_opoConCtx.m_statementData[stmtText] = statementDetails;
					}
				}
			}
			Interlocked.Increment(ref m_opoConCtx.m_totalDataAvailable);
			Interlocked.Increment(ref statementDetails.m_executionsIfNotSelect);
			if (m_opoConCtx.pool == null || m_opoConCtx.m_totalDataAvailable < m_opoConCtx.pool.m_stmtSamplesLimit)
			{
				return;
			}
			lock (m_tuningLock)
			{
				if (m_opoConCtx.m_totalDataAvailable >= m_opoConCtx.pool.m_stmtSamplesLimit)
				{
					m_opoConCtx.m_totalDataAvailable = 0;
					bool flag = m_opoConCtx.pool.m_clonedCtx.gridCR == 1 || m_opoConCtx.pool.m_clonedCtx.gridRLB == 1;
					OracleTuningAgent.AddData(m_opoConCtx.pool.m_agentKey, flag ? m_opoConCtx.pool.m_cpCtx.m_counter.total : m_opoConCtx.pool.m_counter.total, m_opoConCtx.pool.m_scsRecommendations, m_opoConCtx.m_statementData);
					m_opoConCtx.m_statementData = new Hashtable();
					if (m_opoConCtx.pooledConCtx != null)
					{
						m_opoConCtx.pooledConCtx.m_statementData = m_opoConCtx.m_statementData;
						m_opoConCtx.pooledConCtx.m_totalDataAvailable = 0;
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) OracleConnection::AcceptStatementData(): Error: " + ex.ToString() + " \n");
			}
		}
	}

	private string GetPasswordLessStringEx(string conString, out string password, out string proxyPassword)
	{
		password = "";
		proxyPassword = "";
		m_pwdOSLessString = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = null;
		bool flag = false;
		bool flag2 = false;
		int startIndex = 0;
		int num5 = conString.IndexOf('"', startIndex);
		if (num5 != -1)
		{
			int num6 = 0;
			array = new string[64];
			while (num5 != -1)
			{
				int num7 = conString.IndexOf(';', num5 + 1);
				if (num7 == -1)
				{
					num7 = conString.Length;
				}
				int num8 = conString.LastIndexOf('"', num7 - 1, num7 - num5);
				if (num5 == num8)
				{
					if (num7 == conString.Length)
					{
						num7--;
					}
					num8 = conString.IndexOf('"', num7);
					num7 = conString.IndexOf(';', num7 + 1);
				}
				if (num8 != -1)
				{
					int num9 = conString.IndexOf(';', num5, num8 - num5 + 1);
					if (num9 != -1)
					{
						flag = true;
						string oldValue = (array[num6] = conString.Substring(num5, num8 - num5 + 1));
						string text = conString.Substring(0, num8 + 1).Replace(oldValue, "*" + num6 + "*");
						conString = ((num8 + 1 >= conString.Length) ? text : (text + conString.Substring(num8 + 1, conString.Length - 1 - (num8 + 1) + 1)));
						num6++;
						startIndex = text.Length;
					}
					else
					{
						startIndex = num8 + 1;
					}
				}
				else
				{
					startIndex = conString.Length;
				}
				num5 = ((startIndex >= conString.Length) ? (-1) : conString.IndexOf('"', startIndex));
			}
		}
		string[] array2 = conString.Split(semiColon);
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(equalSign, 2);
			string text2 = array3[0].Trim(trimSpaces).ToLower();
			if (array3.Length != 2)
			{
				stringBuilder.Append(array2[i]);
				if (i != array2.Length - 1)
				{
					stringBuilder.Append(";");
				}
				continue;
			}
			switch (text2)
			{
			case "password":
				password = array3[1].Trim(trimSpaces);
				if (flag)
				{
					num5 = password.IndexOf("*");
					if (num5 != -1)
					{
						int num14 = password.IndexOf("*", num5 + 1);
						if (num14 == -1)
						{
							num14 = password.Length - 1;
						}
						int num15 = int.Parse(password.Substring(num5 + 1, num14 - 1 - num5));
						password = password.Replace("*" + num15 + "*", array[num15]);
					}
				}
				if (password == null || password.Length <= 0)
				{
					break;
				}
				num = password.IndexOf('\'', 0);
				num3 = password.IndexOf('"', 0);
				if (num != -1 && num3 != -1 && num < num3)
				{
					num4 = password.IndexOf('"', num3 + 1);
					num2 = password.IndexOf('\'', num4 + 1);
					if (num2 != -1 && num4 != -1 && num4 < num2)
					{
						password = password.Trim(delim2);
					}
				}
				break;
			case "proxy password":
				proxyPassword = array3[1].Trim(trimSpaces);
				if (flag)
				{
					num5 = proxyPassword.IndexOf("*");
					if (num5 != -1)
					{
						int num10 = proxyPassword.IndexOf("*", num5 + 1);
						if (num10 == -1)
						{
							num10 = proxyPassword.Length - 1;
						}
						int num11 = int.Parse(proxyPassword.Substring(num5 + 1, num10 - 1 - num5));
						password = proxyPassword.Replace("*" + num11 + "*", array[num11]);
					}
				}
				if (proxyPassword == null || proxyPassword.Length <= 0)
				{
					break;
				}
				num = 0;
				num2 = 0;
				num3 = 0;
				num4 = 0;
				num = proxyPassword.IndexOf('\'', 0);
				num3 = proxyPassword.IndexOf('"', 0);
				if (num != -1 && num3 != -1 && num < num3)
				{
					num4 = proxyPassword.IndexOf('"', num3 + 1);
					num2 = proxyPassword.IndexOf('\'', num4 + 1);
					if (num2 != -1 && num4 != -1 && num4 < num2)
					{
						proxyPassword = proxyPassword.Trim(delim2);
					}
				}
				break;
			case "user id":
			case "proxy user id":
			{
				string text3 = array3[1];
				if (flag)
				{
					text3 = text3.Trim(trimSpaces);
					num5 = text3.IndexOf("*");
					if (num5 != -1)
					{
						int num12 = text3.IndexOf("*", num5 + 1);
						if (num12 == -1)
						{
							num12 = text3.Length - 1;
						}
						int num13 = -1;
						num13 = int.Parse(text3.Substring(num5 + 1, num12 - 1 - num5));
						if (num13 != -1)
						{
							text3 = text3.Replace("*" + num13 + "*", array[num13]);
						}
					}
				}
				if (text2 == "user id" && text3 == "/")
				{
					flag2 = true;
				}
				stringBuilder.Append(array3[0]);
				stringBuilder.Append("=");
				stringBuilder.Append(text3);
				if (i != array2.Length - 1)
				{
					stringBuilder.Append(";");
				}
				break;
			}
			default:
				stringBuilder.Append(array2[i]);
				if (i != array2.Length - 1)
				{
					stringBuilder.Append(";");
				}
				break;
			}
		}
		m_pwdOSLessString = stringBuilder.ToString();
		if (flag2)
		{
			stringBuilder.Append(";osuserid=");
			stringBuilder.Append(WindowsIdentity.GetCurrent().Name);
		}
		return stringBuilder.ToString();
	}

	static OracleConnection()
	{
		s_lockObj = new object();
		trimSpaces = new char[4] { ' ', '\r', '\t', '\n' };
		doubleQuotes = new char[1] { '"' };
		semiColon = new char[1] { ';' };
		equalSign = new char[1] { '=' };
		delim = new char[3] { ' ', '\t', '"' };
		delim1 = new char[1] { '"' };
		delim2 = new char[2] { ' ', '\'' };
		m_pspePrimaryResourceEntry = null;
		ConStrAtrribs = "attribs";
		IndexUserID = 0;
		IndexPasswd = 1;
		IndexDataSrc = 2;
		IndexProxyUsr = 3;
		IndexProxyPwd = 4;
		IndexDBAPriv = 5;
		IndexPSPE = 6;
		IndexAppEdition = 7;
		IndexStrAttribMax = 7;
		IndexLifetime = 8;
		IndexPoolInc = 9;
		IndexPoolDec = 10;
		IndexTimeout = 11;
		IndexMaxPool = 12;
		IndexMinPool = 13;
		IndexPoolReg = 14;
		IndexStmtCache = 15;
		IndexIntAttribMax = 15;
		IndexEnlist = 16;
		IndexPersist = 17;
		IndexPooling = 18;
		IndexValidCon = 19;
		IndexMetaPool = 20;
		IndexStmtCachePurge = 21;
		IndexGridCR = 22;
		IndexGridRLB = 23;
		IndexCtxConn = 24;
		IndexSelfTuning = 25;
		IndexBoolAttribMax = 25;
		IndexInternalConStr = 26;
		IndexConStrHashCode = 27;
		s_bIsOdtConnection = false;
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		m_pspePrimaryResourceEntry = Hashtable.Synchronized(new Hashtable());
		m_boolMapping = new Hashtable(4);
		m_boolMapping["true"] = 1;
		m_boolMapping["false"] = 0;
		m_boolMapping["yes"] = 1;
		m_boolMapping["no"] = 0;
		m_AttribToIndex = new SortedList(new CaseInsensitiveComparer(CultureInfo.InvariantCulture), 29);
		m_AttribToIndex["USER ID"] = IndexUserID;
		m_AttribToIndex["PASSWORD"] = IndexPasswd;
		m_AttribToIndex["CONNECTION LIFETIME"] = IndexLifetime;
		m_AttribToIndex["INCR POOL SIZE"] = IndexPoolInc;
		m_AttribToIndex["DECR POOL SIZE"] = IndexPoolDec;
		m_AttribToIndex["CONNECTION TIMEOUT"] = IndexTimeout;
		m_AttribToIndex["DATA SOURCE"] = IndexDataSrc;
		m_AttribToIndex["ENLIST"] = IndexEnlist;
		m_AttribToIndex["MAX POOL SIZE"] = IndexMaxPool;
		m_AttribToIndex["MIN POOL SIZE"] = IndexMinPool;
		m_AttribToIndex["POOL REGULATOR"] = IndexPoolReg;
		m_AttribToIndex["PERSIST SECURITY INFO"] = IndexPersist;
		m_AttribToIndex["POOLING"] = IndexPooling;
		m_AttribToIndex["PROXY USER ID"] = IndexProxyUsr;
		m_AttribToIndex["PROXY PASSWORD"] = IndexProxyPwd;
		m_AttribToIndex["DBA PRIVILEGE"] = IndexDBAPriv;
		m_AttribToIndex["VALIDATE CONNECTION"] = IndexValidCon;
		m_AttribToIndex["METADATA POOLING"] = IndexMetaPool;
		m_AttribToIndex["STATEMENT CACHE PURGE"] = IndexStmtCachePurge;
		m_AttribToIndex["STATEMENT CACHE SIZE"] = IndexStmtCache;
		m_AttribToIndex["HA EVENTS"] = IndexGridCR;
		m_AttribToIndex["LOAD BALANCING"] = IndexGridRLB;
		m_AttribToIndex["CONTEXT CONNECTION"] = IndexCtxConn;
		m_AttribToIndex["PROMOTABLE TRANSACTION"] = IndexPSPE;
		m_AttribToIndex["SELF TUNING"] = IndexSelfTuning;
	}

	public OracleConnection()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::OracleConnection(1)\n");
		}
		Init();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::OracleConnection(1)\n");
		}
	}

	public OracleConnection(string connectionString)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::OracleConnection(2)\n");
		}
		Init();
		ConnectionString = connectionString;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::OracleConnection(2)\n");
		}
	}

	public unsafe override void Open()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::Open()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_state == ConnectionState.Open)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_ALREADY_OPEN));
		}
		if (m_conString == null || m_conString.Length == 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleConnection.ConnectionString"));
		}
		if (1 == OraTrace.m_demandOrclPermission && m_orclPermission != null)
		{
			m_orclPermission.Demand();
		}
		m_bLocalTxnStartedForSysTxn = false;
		m_promoteTxnMgr = null;
		if (!m_contextConnection)
		{
			if (m_conStrVals == null)
			{
				if (MetaData.m_connDataPooler.Get(ConStrAtrribs, m_pwdLessString) is object[] conStrVals)
				{
					m_conStrVals = conStrVals;
					m_internalConStr = (string)m_conStrVals[IndexInternalConStr];
					m_conStrValsFromPool = true;
				}
				else if (m_conStrVals == null)
				{
					m_conStrVals = new object[29];
					m_conStrValsFromPool = false;
					ResetAttribsToDefaults();
				}
			}
			if (m_opoConCtx == null)
			{
				m_opoConCtx = new OpoConCtx();
			}
			if (m_opoConCtx.pOpoConValCtx == null)
			{
				try
				{
					num = OpsCon.AllocValCtx(ref m_opoConCtx.pOpoConValCtx);
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
			string text = (string)m_conStrVals[IndexDBAPriv];
			m_opoConCtx.pOpoConValCtx->DBAPrivilege = 0;
			if (text != null && text.Length > 0)
			{
				if (text.ToLower() == "sysdba")
				{
					m_opoConCtx.pOpoConValCtx->DBAPrivilege = 2;
				}
				else if (text.ToLower() == "sysoper")
				{
					m_opoConCtx.pOpoConValCtx->DBAPrivilege = 4;
				}
			}
			else if (m_bStartupShutdown)
			{
				OracleException.HandleError(1031, null, m_opoConCtx.opsErrCtx, null);
			}
			if (!m_bStartupShutdown)
			{
				m_enlist = (int)m_conStrVals[IndexEnlist];
				if (m_enlist == 2)
				{
					m_opoConCtx.pOpoConValCtx->Enlist = 0;
					m_opoConCtx.pOpoConValCtx->SetIntAndExtName = 1;
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->Enlist = m_enlist;
					m_opoConCtx.pOpoConValCtx->SetIntAndExtName = m_enlist;
				}
				m_opoConCtx.pOpoConValCtx->Pooling = (int)m_conStrVals[IndexPooling];
				string text2 = (string)m_conStrVals[IndexPSPE];
				m_opoConCtx.pOpoConValCtx->PSPE = 1;
				if (text2 != null && text2.Length > 0 && text2.ToLower() == "local")
				{
					m_opoConCtx.pOpoConValCtx->PSPE = 0;
				}
				m_opoConCtx.m_bSelfTuning = Convert.ToBoolean(m_conStrVals[IndexSelfTuning]);
				if (m_opoConCtx.m_bSelfTuning && (m_opoConCtx.pOpoConValCtx->Pooling == 0 || IsAvailable))
				{
					m_opoConCtx.m_bSelfTuning = false;
				}
				if (m_opoConCtx.m_bSelfTuning)
				{
					m_opoConCtx.pOpoConValCtx->StmtCacheSize = m_opoConCtx.m_defaultStmtCacheSize;
					if (m_opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
					{
						m_opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
					}
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->StmtCacheSize = (int)m_conStrVals[IndexStmtCache];
				}
				m_opoConCtx.pOpoConValCtx->StmtCachePurge = (int)m_conStrVals[IndexStmtCachePurge];
				m_opoConCtx.poolRegulator = (int)m_conStrVals[IndexPoolReg];
				m_opoConCtx.maxPoolSize = (int)m_conStrVals[IndexMaxPool];
				m_opoConCtx.minPoolSize = (int)m_conStrVals[IndexMinPool];
				m_opoConCtx.origMinPoolSize = m_opoConCtx.minPoolSize;
				m_opoConCtx.poolIncSize = (int)m_conStrVals[IndexPoolInc];
				m_opoConCtx.poolDecSize = (int)m_conStrVals[IndexPoolDec];
				m_opoConCtx.origPoolDecSize = m_opoConCtx.poolDecSize;
				m_opoConCtx.lifeTime = new TimeSpan(0, 0, (int)m_conStrVals[IndexLifetime]);
				m_opoConCtx.origLifeTime = m_opoConCtx.lifeTime;
				m_opoConCtx.timeOut = new TimeSpan(0, 0, m_conTimeout);
				m_opoConCtx.validateCon = (int)m_conStrVals[IndexValidCon];
				m_opoConCtx.gridCR = (int)m_conStrVals[IndexGridCR];
				m_opoConCtx.gridRLB = (int)m_conStrVals[IndexGridRLB];
				m_opoConCtx.bGridRac = m_opoConCtx.gridCR == 1 || m_opoConCtx.gridRLB == 1;
				m_opoConCtx.metaPool = (int)m_conStrVals[IndexMetaPool];
			}
			else if (m_bPrelimAuthSession)
			{
				m_opoConCtx.pOpoConValCtx->DBStartup = 1;
				m_opoConCtx.pOpoConValCtx->Pooling = 0;
				m_opoConCtx.pOpoConValCtx->StmtCacheSize = 0;
			}
			else
			{
				m_opoConCtx.pOpoConValCtx->DBStartup = 0;
			}
			m_opoConCtx.conString = m_internalConStr;
			if (m_password == null && m_proxyPassword == null)
			{
				m_pwdLessString = GetPasswordLessStringEx(m_conString, out m_password, out m_proxyPassword);
			}
			if (OraTrace.m_TraceLevel != 0 && OraTrace.m_TraceLevel != 8)
			{
				if (m_pwdLessString != null)
				{
					m_opoConCtx.poolName = m_pwdLessString;
				}
				else
				{
					m_opoConCtx.poolName = GetPasswordLessStringEx(m_conString, out m_password, out m_proxyPassword);
					m_pwdLessString = m_opoConCtx.poolName;
				}
			}
			if (m_opoConCtx.opoConRefCtx == null)
			{
				m_opoConCtx.opoConRefCtx = new OpoConRefCtx();
			}
			if (((string)m_conStrVals[IndexUserID]).Trim(delim) == "/")
			{
				if (IsAvailable)
				{
					throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_DOTNET_SP));
				}
				m_opoConCtx.opoConRefCtx.userID = "";
				m_opoConCtx.opoConRefCtx.password = "";
				m_opoConCtx.pOpoConValCtx->OSAuthent = 1;
				m_password = null;
			}
			else
			{
				m_opoConCtx.opoConRefCtx.userID = (string)m_conStrVals[IndexUserID];
				m_opoConCtx.opoConRefCtx.password = m_password;
				m_password = null;
				m_opoConCtx.pOpoConValCtx->OSAuthent = 0;
			}
			m_opoConCtx.opoConRefCtx.dataSource = (string)m_conStrVals[IndexDataSrc];
			if ((string)m_conStrVals[IndexProxyUsr] == "/")
			{
				if (IsAvailable)
				{
					throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_DOTNET_SP));
				}
				m_opoConCtx.opoConRefCtx.proxyUserId = "";
				m_opoConCtx.opoConRefCtx.proxyPassword = "";
				m_opoConCtx.pOpoConValCtx->OSAuthent = 2;
				m_proxyPassword = null;
			}
			else
			{
				m_opoConCtx.opoConRefCtx.proxyUserId = (string)m_conStrVals[IndexProxyUsr];
				m_opoConCtx.opoConRefCtx.proxyPassword = m_proxyPassword;
				m_proxyPassword = null;
			}
			if (m_bStartupShutdown)
			{
				m_opoConCtx.opoConRefCtx.proxyUserId = "";
				m_opoConCtx.opoConRefCtx.proxyPassword = "";
			}
			if (!m_openWithNewPwd)
			{
				m_opoConCtx.opoConRefCtx.newPassword = string.Empty;
			}
			m_openWithNewPwd = false;
			m_opoConCtx.opoConRefCtx.appEdition = (string)m_conStrVals[IndexAppEdition];
			m_opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg = string.Empty;
			if (m_opoConCtx.bGridRac)
			{
				if (OraTrace.m_DBNotificationPort >= 0)
				{
					m_opoConCtx.pOpoConValCtx->DbNtfPort = OraTrace.m_DBNotificationPort;
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->DbNtfPort = -1;
				}
			}
			else
			{
				m_opoConCtx.pOpoConValCtx->DbNtfPort = -2;
			}
			bool flag = false;
			string key = string.Empty;
			int enlist = m_opoConCtx.pOpoConValCtx->Enlist;
			if (m_opoConCtx.pOpoConValCtx->Enlist == 1)
			{
				if ((m_opoConCtx.m_systemTransaction = Transaction.Current) != null)
				{
					Guid distributedIdentifier = m_opoConCtx.m_systemTransaction.TransactionInformation.DistributedIdentifier;
					key = m_opoConCtx.m_systemTransaction.TransactionInformation.LocalIdentifier;
					object obj = m_pspePrimaryResourceEntry[key];
					if (Guid.Empty == distributedIdentifier)
					{
						if (obj == null)
						{
							flag = true;
							m_opoConCtx.pOpoConValCtx->Enlist = 0;
							m_opoConCtx.opoConRefCtx.pITransaction = null;
							m_opoConCtx.m_txnType = TxnType.None;
						}
						else
						{
							PSPEPrimaryConnectionInfo pSPEPrimaryConnectionInfo = obj as PSPEPrimaryConnectionInfo;
							if (pSPEPrimaryConnectionInfo.m_pspeAttributeValue == 0 || m_opoConCtx.pOpoConValCtx->PSPE == 0 || !pSPEPrimaryConnectionInfo.m_dbSupportPromotion)
							{
								throw new TransactionPromotionException(OpoErrResManager.GetErrorMesg(ErrRes.CON_PSPE_RULE_VIOLATION));
							}
							TransactionInterop.GetTransmitterPropagationToken(m_opoConCtx.m_systemTransaction);
						}
					}
					if (!flag)
					{
						if (m_opoConCtx.pOpoConValCtx->PSPE == 0)
						{
							throw new TransactionPromotionException(OpoErrResManager.GetErrorMesg(ErrRes.CON_PSPE_RULE_VIOLATION));
						}
						m_opoConCtx.opoConRefCtx.pITransaction = (ITransaction)TransactionInterop.GetDtcTransaction(m_opoConCtx.m_systemTransaction);
						m_opoConCtx.m_txnType = TxnType.SystemTxn;
					}
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->Enlist = 0;
					m_opoConCtx.opoConRefCtx.pITransaction = null;
				}
			}
			else
			{
				m_opoConCtx.pOpoConValCtx->Enlist = 0;
				m_opoConCtx.opoConRefCtx.pITransaction = null;
			}
			num = ConnectionDispenser.Open(m_opoConCtx);
			m_bPrelimAuthSession = false;
			if (num != 0 || m_opoConCtx.pOpoConValCtx->SessionBegin != 1)
			{
				m_opoConCtx.bErrorOnOpen = true;
				if (num == 0 && m_opoConCtx.pOpoConValCtx->SessionBegin != 1)
				{
					OracleException.HandleError(m_opoConCtx.pOpoConValCtx->SessionBegin, null, IntPtr.Zero, null);
				}
				else
				{
					if (num != 0 && m_opoConCtx.pOpoConValCtx->bIsTimesTen != 0 && !m_opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg.Equals(string.Empty))
					{
						throw new OracleException(num, null, "OpsConOpen", m_opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg);
					}
					if (num == ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, null, IntPtr.Zero, m_opoConCtx.exceptMsg);
					}
					else
					{
						OracleException.HandleError(num, null, IntPtr.Zero, null);
					}
				}
			}
			else
			{
				m_opoConCtx.bErrorOnOpen = false;
				ConnectionState state = m_state;
				m_serverVersion = m_opoConCtx.opoConRefCtx.serverVersion;
				m_majorVersion = m_opoConCtx.pOpoConValCtx->MajorVersion;
				m_minorVersion = m_opoConCtx.pOpoConValCtx->MinorVersion;
				m_PatchSetVersion = m_opoConCtx.pOpoConValCtx->PatchSetVersion;
				m_state = ConnectionState.Open;
				if (m_opoConCtx.pOpoConValCtx->ConSignature == int.MaxValue)
				{
					m_opoConCtx.pOpoConValCtx->ConSignature = 0;
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->ConSignature = m_opoConCtx.pOpoConValCtx->ConSignature + 1;
				}
				double num2 = (double)m_opoConCtx.pOpoConValCtx->ConSignature + (double)(int)m_opoConCtx.opsConCtx / 10000000000.0;
				if (m_opoConCtx.m_bSelfTuning)
				{
					m_stmtCacheSize = m_opoConCtx.pOpoConValCtx->StmtCacheSize;
					if (m_opoConCtx.m_statementData == null)
					{
						m_opoConCtx.m_statementData = new Hashtable();
					}
				}
				m_conSignature = num2.GetHashCode();
				if (1 == m_opoConCtx.pOpoConValCtx->InMtsTxn)
				{
					if (null != Transaction.Current)
					{
						Transaction.Current.TransactionCompleted += TransactionComplete;
					}
				}
				else if (flag)
				{
					m_opoConCtx.pOpoConValCtx->Enlist = enlist;
					if (Transaction.Current != null && (int)m_conStrVals[IndexEnlist] == 1)
					{
						bool isDBVer_11_1_0_7_OrHigher = IsDBVer_11_1_0_7_OrHigher;
						m_pspePrimaryResourceEntry.Add(key, new PSPEPrimaryConnectionInfo(isDBVer_11_1_0_7_OrHigher, m_opoConCtx.pOpoConValCtx->PSPE));
						if (m_opoConCtx.pOpoConValCtx->PSPE == 0 || (isDBVer_11_1_0_7_OrHigher && m_opoConCtx.pOpoConValCtx->PSPE == 1))
						{
							if (m_promoteTxnMgr == null)
							{
								m_promoteTxnMgr = new PromotableTxnMgr();
							}
							Transaction.Current.EnlistPromotableSinglePhase(m_promoteTxnMgr);
							m_promoteTxnMgr.m_oraTransaction = BeginTransaction();
							m_bLocalTxnStartedForSysTxn = true;
							m_opoConCtx.m_promotableTxnManager = m_promoteTxnMgr;
							m_opoConCtx.m_txnType = TxnType.LocalTxnForSysTxn;
							m_promoteTxnMgr.m_localTxnIdentifier = Transaction.Current.TransactionInformation.LocalIdentifier;
							m_promoteTxnMgr.m_opsConCtx = m_opoConCtx.opsConCtx;
							m_promoteTxnMgr.m_opsErrCtx = m_opoConCtx.opsErrCtx;
							m_promoteTxnMgr.m_opoConRefCtx = m_opoConCtx.opoConRefCtx;
							ConnectionDispenser.CopyPooledConCtx(ref m_promoteTxnMgr.m_pOpoConValCtx, m_opoConCtx.pOpoConValCtx);
						}
						else if (m_opoConCtx.opoConRefCtx.proxyUserId == null || m_opoConCtx.opoConRefCtx.proxyUserId.Length == 0)
						{
							m_opoConCtx.opoConRefCtx.pITransaction = (ITransaction)TransactionInterop.GetDtcTransaction(m_opoConCtx.m_systemTransaction);
							m_opoConCtx.m_promotableTxnManager = new PromotableTxnMgr();
							m_opoConCtx.m_promotableTxnManager.m_localTxnIdentifier = Transaction.Current.TransactionInformation.LocalIdentifier;
							m_opoConCtx.m_txnType = TxnType.SystemTxn;
							num = ConnectionDispenser.Enlist(m_opoConCtx);
							if (num != 0)
							{
								OracleException.HandleError(num, null, IntPtr.Zero, null);
							}
						}
						Transaction.Current.TransactionCompleted += TransactionComplete;
					}
				}
				else
				{
					m_promoteTxnMgr = null;
				}
				if (OraTrace.m_fetchArrayPooling != 0 && m_opoConCtx.m_fetchArrayPooler == null && m_opoConCtx.opsConCtx != IntPtr.Zero)
				{
					m_opoConCtx.m_fetchArrayPooler = new FetchArrayPooler();
					try
					{
						OpsCon.SetFetchArrayGetFuncPtr(m_opoConCtx.opsConCtx, m_opoConCtx.m_fetchArrayPooler.m_pFetchArrayGet);
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
				if (m_stateChangeEventHandler != null)
				{
					RaiseStateChange(state, m_state);
				}
				m_pwdValidated = true;
				m_serviceName = m_opoConCtx.opoConRefCtx.serviceName;
				m_databaseName = m_opoConCtx.opoConRefCtx.dbName;
				m_databaseDomainName = m_opoConCtx.opoConRefCtx.dbDomainName;
				m_hostName = m_opoConCtx.opoConRefCtx.hostName;
				m_instanceName = m_opoConCtx.opoConRefCtx.instanceName;
				if (!m_conStrValsFromPool)
				{
					try
					{
						m_conStrVals[IndexInternalConStr] = m_internalConStr;
						MetaData.m_connDataPooler.Put(ConStrAtrribs, m_pwdLessString, m_conStrVals);
						m_conStrValsFromPool = false;
						m_conStrVals = null;
					}
					catch
					{
					}
				}
				else
				{
					m_conStrVals = null;
				}
			}
		}
		else
		{
			if (!IsCtxConnAvailable)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_NONORACLR_THREAD));
			}
			ConnectionState state2 = m_state;
			OpenExtprocConnection();
			if (OraTrace.m_fetchArrayPooling != 0 && m_opoConCtx.m_fetchArrayPooler == null && m_opoConCtx.opsConCtx != IntPtr.Zero)
			{
				m_opoConCtx.m_fetchArrayPooler = new FetchArrayPooler();
				try
				{
					OpsCon.SetFetchArrayGetFuncPtr(m_opoConCtx.opsConCtx, m_opoConCtx.m_fetchArrayPooler.m_pFetchArrayGet);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
					throw;
				}
			}
			if (m_stateChangeEventHandler != null)
			{
				RaiseStateChange(state2, m_state);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::Open()\n");
		}
	}

	public void OpenWithNewPassword(string newPassword)
	{
		if (m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_CTX_CONN));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::OpenWithNewPassword()\n");
		}
		if (m_opoConCtx == null)
		{
			m_opoConCtx = new OpoConCtx();
		}
		if (m_opoConCtx.opoConRefCtx == null)
		{
			m_opoConCtx.opoConRefCtx = new OpoConRefCtx();
		}
		m_opoConCtx.opoConRefCtx.newPassword = newPassword;
		m_openWithNewPwd = true;
		Open();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::OpenWithNewPassword()\n");
		}
	}

	internal int OnFailoverCallback_fn(IntPtr svchp, IntPtr envhp, IntPtr fo_ctx, int fo_type, int fo_event)
	{
		OracleFailoverEventArgs eventArgs = new OracleFailoverEventArgs(svchp, envhp, fo_ctx, fo_type, fo_event);
		return OnFailover(eventArgs);
	}

	public new unsafe OracleTransaction BeginTransaction()
	{
		if (m_contextConnection)
		{
			throw new NotSupportedException();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::BeginTransaction()\n");
		}
		m_oraTransaction = GetTransaction();
		if (m_oraTransaction != null || m_opoConCtx.pOpoConValCtx->InMtsTxn == 1)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_ALREADY_TXNED));
		}
		m_oraTransaction = new OracleTransaction(this, System.Data.IsolationLevel.ReadCommitted, TxnHndAllocated);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::BeginTransaction()\n");
		}
		return m_oraTransaction;
	}

	public new unsafe OracleTransaction BeginTransaction(System.Data.IsolationLevel isolationLevel)
	{
		if (m_contextConnection)
		{
			throw new NotSupportedException();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::BeginTransaction()\n");
		}
		m_oraTransaction = GetTransaction();
		if (m_oraTransaction != null || m_opoConCtx.pOpoConValCtx->InMtsTxn == 1)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_ALREADY_TXNED));
		}
		if (isolationLevel != System.Data.IsolationLevel.ReadCommitted && isolationLevel != System.Data.IsolationLevel.Serializable)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_INVALID_ISO_LEVEL), "isolationLevel");
		}
		m_oraTransaction = new OracleTransaction(this, isolationLevel, TxnHndAllocated);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::BeginTransaction()\n");
		}
		return m_oraTransaction;
	}

	public override void ChangeDatabase(string databaseName)
	{
		throw new NotSupportedException();
	}

	public override void Close()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::Close()\n");
		}
		try
		{
			if (m_state == ConnectionState.Open)
			{
				OracleDataReader[] array = null;
				lock (m_DataReaderList.SyncRoot)
				{
					if (m_DataReaderList.Count > 0)
					{
						array = new OracleDataReader[m_DataReaderList.Count];
						for (int i = 0; i < m_DataReaderList.Count; i++)
						{
							array[i] = (OracleDataReader)m_DataReaderList[i];
						}
						m_DataReaderList.Clear();
					}
				}
				if (array != null)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j] != null)
						{
							array[j].Close();
							array[j] = null;
						}
					}
					array = null;
				}
				if (m_state == ConnectionState.Open)
				{
					if (!m_contextConnection)
					{
						if (m_oraTransaction != null && m_oraTransaction.Completed)
						{
							m_oraTransaction = null;
						}
						if (m_oraTransaction != null)
						{
							try
							{
								if (!m_bLocalTxnStartedForSysTxn)
								{
									m_oraTransaction.Rollback();
								}
							}
							finally
							{
								m_bLocalTxnStartedForSysTxn = false;
								m_oraTransaction = null;
							}
						}
					}
					ConnectionState state = m_state;
					lock (m_syncTxnComplete)
					{
						m_state = ConnectionState.Closed;
					}
					if (m_opoConCtx.opoConRefCtx.proxyUserId != null && m_opoConCtx.opoConRefCtx.proxyUserId.Length > 0)
					{
						if (m_opoConCtx.m_udtDescPoolerByName != null)
						{
							m_opoConCtx.m_udtDescPoolerByName.Clear();
						}
						if (m_opoConCtx.m_udtDescPoolerByTDO != null)
						{
							m_opoConCtx.m_udtDescPoolerByTDO.Clear();
						}
					}
					ConnectionDispenser.Close(ref m_opoConCtx, m_contextConnection);
					if (m_stateChangeEventHandler != null)
					{
						RaiseStateChange(state, m_state);
					}
					if (m_opoConCtx != null)
					{
						m_opoConCtx.opoConRefCtx.clientID = "";
						m_opoConCtx.opoConRefCtx.moduleName = "";
						m_opoConCtx.opoConRefCtx.actionName = "";
						m_opoConCtx.opoConRefCtx.clientInfo = "";
					}
					if (m_metaDataCollectionDS != null)
					{
						m_metaDataCollectionDS.Clear();
						m_metaDataCollectionDS.Dispose();
						m_metaDataCollectionDS = null;
					}
				}
			}
		}
		finally
		{
			if (m_opoConCtx != null)
			{
				m_opoConCtx.m_fetchArrayPooler = null;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::Close()\n");
		}
	}

	public new OracleCommand CreateCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::CreateCommand()\n");
		}
		OracleCommand result = new OracleCommand("", this);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::CreateCommand()\n");
		}
		return result;
	}

	public object Clone()
	{
		if (m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_CTX_CONN));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::Clone()\n");
		}
		OracleConnection oracleConnection = new OracleConnection();
		if (m_conString != null && m_conString.Length != 0)
		{
			oracleConnection.ConnectionString = m_conString;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::Clone()\n");
		}
		return oracleConnection;
	}

	protected unsafe override void Dispose(bool disposing)
	{
		m_password = null;
		m_proxyPassword = null;
		bool flag = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::Dispose()\n");
		}
		if (m_disposed)
		{
			return;
		}
		try
		{
			if (m_opoConCtx != null && m_state == ConnectionState.Open)
			{
				flag = false;
				if (!disposing && m_opoConCtx.m_udtDescPoolerByName != null)
				{
					m_opoConCtx.m_udtDescPoolerByName.Clear();
				}
				if (!disposing && m_opoConCtx.m_udtDescPoolerByTDO != null)
				{
					m_opoConCtx.m_udtDescPoolerByTDO.Clear();
				}
				if (!disposing && m_opoConCtx.m_conPooler != null)
				{
					m_opoConCtx.m_conPooler.Clear();
				}
				try
				{
					Close();
				}
				catch
				{
				}
			}
			try
			{
				if (m_opoConCtx != null && m_opoConCtx.pOpoConValCtx != null && (m_opoConCtx.pOpoConValCtx->Pooling == 0 || m_opoConCtx.pOpoConValCtx->OSAuthent != 0))
				{
					try
					{
						ConnectionDispenser.Dispose(ref m_opoConCtx);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			if (m_opoConCtx != null)
			{
				try
				{
					if (m_opoConCtx.pOpoConValCtx != null)
					{
						try
						{
							OpsCon.FreeValCtx(ref m_opoConCtx.pOpoConValCtx);
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
						}
					}
				}
				catch
				{
				}
			}
			m_disposed = true;
		}
		finally
		{
			if (!disposing && (OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfReclaimedConnections) == PerfCounterLevel.NumberOfReclaimedConnections && !m_contextConnection && !flag)
			{
				OraclePerfCounterCollection.NumberOfReclaimedConnections.Increment();
			}
			try
			{
				base.Dispose(disposing);
			}
			catch
			{
			}
			try
			{
				GC.SuppressFinalize(this);
			}
			catch
			{
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::Dispose()\n");
		}
	}

	public OracleGlobalization GetSessionInfo()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::GetSessionInfo(1)\n");
		}
		if (State == ConnectionState.Closed)
		{
			OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
		}
		IntPtr intPtrOraGlob = IntPtr.Zero;
		OracleGlobalization oracleGlobalization = new OracleGlobalization();
		try
		{
			num = OpsCon.GetSessionInfo(m_opoConCtx.opsConCtx, ref intPtrOraGlob);
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
				OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
			}
		}
		Marshal.PtrToStructure(intPtrOraGlob, (object)oracleGlobalization.m_oraGlob);
		oracleGlobalization.TimeZone = "";
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::GetSessionInfo(1)\n");
		}
		return oracleGlobalization;
	}

	public void GetSessionInfo(OracleGlobalization oraGlob)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::GetSessionInfo(2)\n");
		}
		if (State == ConnectionState.Closed)
		{
			OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
		}
		IntPtr intPtrOraGlob = IntPtr.Zero;
		try
		{
			num = OpsCon.GetSessionInfo(m_opoConCtx.opsConCtx, ref intPtrOraGlob);
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
				OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
			}
		}
		Marshal.PtrToStructure(intPtrOraGlob, (object)oraGlob.m_oraGlob);
		oraGlob.TimeZone = "";
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::GetSessionInfo(2)\n");
		}
	}

	public void SetSessionInfo(OracleGlobalization oraGlob)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::SetSessionInfo()\n");
		}
		if (State == ConnectionState.Closed)
		{
			OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
		}
		StringBuilder stringBuilder = new StringBuilder("ALTER SESSION SET", 512);
		int majorVersion = m_majorVersion;
		int minorVersion = m_minorVersion;
		if (majorVersion >= 8)
		{
			stringBuilder.AppendFormat(" NLS_TERRITORY=\"{0}\"", oraGlob.Territory);
			stringBuilder.AppendFormat(" NLS_LANGUAGE=\"{0}\"", oraGlob.Language);
			stringBuilder.AppendFormat(" NLS_CALENDAR=\"{0}\"", oraGlob.Calendar);
			stringBuilder.AppendFormat(" NLS_DATE_LANGUAGE=\"{0}\"", oraGlob.DateLanguage);
			stringBuilder.AppendFormat(" NLS_CURRENCY=\"{0}\"", oraGlob.Currency);
			stringBuilder.AppendFormat(" NLS_DATE_FORMAT='{0}'", oraGlob.DateFormat);
			stringBuilder.AppendFormat(" NLS_ISO_CURRENCY=\"{0}\"", oraGlob.ISOCurrency);
			stringBuilder.AppendFormat(" NLS_NUMERIC_CHARACTERS=\"{0}\"", oraGlob.NumericCharacters);
			stringBuilder.AppendFormat(" NLS_SORT=\"{0}\"", oraGlob.Sort);
			if (minorVersion >= 1)
			{
				stringBuilder.AppendFormat(" NLS_COMP=\"{0}\"", oraGlob.Comparison);
				stringBuilder.AppendFormat(" NLS_DUAL_CURRENCY=\"{0}\"", oraGlob.DualCurrency);
			}
		}
		if (majorVersion >= 9)
		{
			stringBuilder.AppendFormat(" NLS_LENGTH_SEMANTICS=\"{0}\"", oraGlob.LengthSemantics);
			stringBuilder.AppendFormat(" NLS_NCHAR_CONV_EXCP=\"{0}\"", oraGlob.NCharConversionException);
			stringBuilder.AppendFormat(" NLS_TIMESTAMP_FORMAT='{0}'", oraGlob.TimeStampFormat);
			stringBuilder.AppendFormat(" NLS_TIMESTAMP_TZ_FORMAT='{0}'", oraGlob.TimeStampTZFormat);
		}
		if (oraGlob.TimeZone != null && oraGlob.TimeZone.Length != 0)
		{
			if (oraGlob.TimeZone.ToLower() == "local")
			{
				stringBuilder.AppendFormat(" TIME_ZONE=local");
			}
			else if (oraGlob.TimeZone.ToLower(CultureInfo.InvariantCulture) == "dbtimezone")
			{
				stringBuilder.AppendFormat(" TIME_ZONE=DBTIMEZONE");
			}
			else if (oraGlob.TimeZone.Length > 0)
			{
				stringBuilder.AppendFormat(" TIME_ZONE='{0}'", oraGlob.TimeZone);
			}
		}
		GCHandle gCHandle = default(GCHandle);
		try
		{
			string value = stringBuilder.ToString();
			gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
			IntPtr pSql = gCHandle.AddrOfPinnedObject();
			num = OpsCon.SetSessionInfo(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, pSql);
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
			switch (num)
			{
			case -1:
				OracleException.HandleError(num, null, m_opoConCtx.opsErrCtx, null);
				break;
			default:
				OracleException.HandleError(12705, null, m_opoConCtx.opsErrCtx, null);
				break;
			case 0:
				break;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::SetSessionInfo()\n");
		}
	}

	public unsafe void PurgeStatementCache()
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::PurgeStatementCache()\n");
		}
		try
		{
			if (m_opoConCtx.pOpoConValCtx != null && m_opoConCtx.pOpoConValCtx->StmtCacheSize > 0)
			{
				num = OpsCon.PurgeStatementCache(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx, m_opoConCtx.pOpoConValCtx);
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
				OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::PurgeStatementCache()\n");
		}
	}

	public override DataTable GetSchema()
	{
		return GetSchema(DbMetaDataCollectionNames.MetaDataCollections, null);
	}

	public override DataTable GetSchema(string collectionName)
	{
		return GetSchema(collectionName, null);
	}

	public override DataTable GetSchema(string collectionName, string[] restrictionsArray)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::GetSchema(string, string[])\n");
		}
		if (collectionName == null || collectionName.Length == 0)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_COLL_NOT_DEFINED, collectionName));
		}
		if (m_state == ConnectionState.Closed)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_metaDataCollectionDS == null)
		{
			LoadMetaDataXmlDS();
		}
		DataTable dataTable = null;
		if (m_metaDataCollectionDS != null)
		{
			dataTable = new DataTable();
			string text = NormalizeDBVersion(m_serverVersion);
			string text2 = collectionName.ToUpperInvariant();
			int num = 0;
			if (restrictionsArray != null)
			{
				num = restrictionsArray.Length;
			}
			switch (text2)
			{
			case "METADATACOLLECTIONS":
				if (num > 0)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_MORE_RESTRICTIONS, collectionName, "0"));
				}
				PopulateSupportedDataRows(dataTable, collectionName, text);
				dataTable.TableName = DbMetaDataCollectionNames.MetaDataCollections;
				dataTable.AcceptChanges();
				break;
			case "DATATYPES":
				if (num > 0)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_MORE_RESTRICTIONS, collectionName, "0"));
				}
				PopulateSupportedDataRows(dataTable, collectionName, text);
				dataTable.TableName = DbMetaDataCollectionNames.DataTypes;
				dataTable.AcceptChanges();
				break;
			case "RESTRICTIONS":
				if (num > 0)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_MORE_RESTRICTIONS, collectionName, "0"));
				}
				PopulateSupportedDataRows(dataTable, collectionName, text);
				dataTable.TableName = DbMetaDataCollectionNames.Restrictions;
				dataTable.AcceptChanges();
				break;
			case "RESERVEDWORDS":
				if (num > 0)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_MORE_RESTRICTIONS, collectionName, "0"));
				}
				PopulateSupportedDataRows(dataTable, collectionName, text);
				dataTable.TableName = DbMetaDataCollectionNames.ReservedWords;
				dataTable.AcceptChanges();
				break;
			case "DATASOURCEINFORMATION":
				if (num > 0)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_MORE_RESTRICTIONS, collectionName, "0"));
				}
				dataTable = m_metaDataCollectionDS.Tables[collectionName].Copy();
				dataTable.Rows[0][DbMetaDataColumnNames.DataSourceProductVersion] = m_serverVersion;
				dataTable.Rows[0][DbMetaDataColumnNames.DataSourceProductVersionNormalized] = text;
				dataTable.TableName = DbMetaDataCollectionNames.DataSourceInformation;
				dataTable.AcceptChanges();
				break;
			default:
			{
				string text3 = null;
				int num2 = 0;
				string text4 = null;
				bool flag = false;
				bool flag2 = false;
				DataRowCollection rows = m_metaDataCollectionDS.Tables[DbMetaDataCollectionNames.MetaDataCollections].Rows;
				for (int i = 0; i < rows.Count; i++)
				{
					if (((string)rows[i][DbMetaDataColumnNames.CollectionName]).ToUpperInvariant() == text2 && ((string)rows[i]["PopulationMechanism"]).ToUpperInvariant() == "ORACLECOMMAND")
					{
						flag2 = true;
						if (text4 == null)
						{
							text4 = (string)rows[i][DbMetaDataColumnNames.CollectionName];
						}
						if (SupportedInCurrentVersion(rows[i], text))
						{
							num2 = (int)rows[i][DbMetaDataColumnNames.NumberOfRestrictions];
							text3 = (string)rows[i]["PopulationString"];
							flag = false;
							break;
						}
						flag = true;
					}
					else if (((string)rows[i][DbMetaDataColumnNames.CollectionName]).ToUpperInvariant() == text2 && ((string)rows[i]["PopulationMechanism"]).ToUpperInvariant() == "DATATABLE")
					{
						dataTable = m_metaDataCollectionDS.Tables[collectionName].Copy();
						dataTable.TableName = collectionName.ToString();
						dataTable.AcceptChanges();
						return dataTable;
					}
				}
				if (!flag2)
				{
					throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_COLL_NOT_DEFINED, collectionName));
				}
				if (flag)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_COLL_NOT_SUPPORTED, collectionName));
				}
				if (num > num2)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_MORE_RESTRICTIONS, collectionName, num2.ToString()));
				}
				DataRowCollection rows2 = m_metaDataCollectionDS.Tables[DbMetaDataCollectionNames.Restrictions].Rows;
				int num3 = 0;
				ArrayList arrayList = new ArrayList();
				for (int j = 0; j < rows2.Count; j++)
				{
					if (!(((string)rows2[j][DbMetaDataColumnNames.CollectionName]).ToUpperInvariant() == text2))
					{
						continue;
					}
					OracleParameter oracleParameter = new OracleParameter();
					if (restrictionsArray != null)
					{
						if (num3 >= restrictionsArray.Length)
						{
							oracleParameter.Value = null;
						}
						else
						{
							oracleParameter.Value = restrictionsArray[num3];
						}
					}
					else
					{
						oracleParameter.Value = null;
					}
					oracleParameter.ParameterName = (string)rows2[j]["ParameterName"];
					arrayList.Add(oracleParameter);
					num3++;
					if (num3 >= num2)
					{
						break;
					}
				}
				if (text3 != null)
				{
					OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(text3, this);
					oracleDataAdapter.SelectCommand.InitialLONGFetchSize = -1;
					oracleDataAdapter.SelectCommand.InitialLOBFetchSize = -1;
					foreach (OracleParameter item in arrayList)
					{
						oracleDataAdapter.SelectCommand.Parameters.Add(item);
					}
					oracleDataAdapter.SelectCommand.BindByName = true;
					try
					{
						oracleDataAdapter.Fill(dataTable);
					}
					catch (Exception innerException)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_QUERY_FAILED, collectionName), innerException);
					}
					if (text4 != null)
					{
						dataTable.TableName = text4;
					}
					dataTable.AcceptChanges();
					foreach (OracleParameter item2 in arrayList)
					{
						item2.Dispose();
					}
					arrayList.Clear();
					arrayList = null;
					oracleDataAdapter.Dispose();
					oracleDataAdapter = null;
					break;
				}
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_NO_POPULATION_STRING, collectionName));
			}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT) OracleConnection::GetSchema(string, string[])\n");
			}
			return dataTable;
		}
		throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_NO_METADATA_STREAM, collectionName));
	}

	private void PopulateSupportedDataRows(DataTable dt, string collectionName, string normalizedDBVersion)
	{
		int count = m_metaDataCollectionDS.Tables[collectionName].Columns.Count;
		for (int i = 0; i < count; i++)
		{
			DataColumn dataColumn = new DataColumn();
			dataColumn.ColumnName = m_metaDataCollectionDS.Tables[collectionName].Columns[i].ColumnName;
			dataColumn.DataType = m_metaDataCollectionDS.Tables[collectionName].Columns[i].DataType;
			dt.Columns.Add(dataColumn);
		}
		DataRowCollection rows = m_metaDataCollectionDS.Tables[collectionName].Rows;
		foreach (DataRow item in rows)
		{
			if (SupportedInCurrentVersion(item, normalizedDBVersion))
			{
				DataRow dataRow2 = dt.NewRow();
				for (int j = 0; j < count; j++)
				{
					dataRow2[j] = item[j];
				}
				dt.Rows.Add(dataRow2);
			}
		}
		dt.Columns.Remove("MaximumVersion");
		dt.Columns.Remove("MinimumVersion");
	}

	[ConfigurationPermission(SecurityAction.Assert, Unrestricted = true)]
	private void LoadMetaDataXmlDS()
	{
		Stream stream = null;
		try
		{
			string metaDataXml = OraTrace.m_MetaDataXml;
			if (metaDataXml != null)
			{
				try
				{
					Configuration configuration = ConfigurationManager.OpenMachineConfiguration();
					stream = new FileStream(configuration.FilePath.Replace("machine.config", metaDataXml), FileMode.Open);
				}
				catch (FileNotFoundException)
				{
					throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.CON_GS_NO_CUSTOM_FILE, metaDataXml));
				}
			}
		}
		catch (Exception ex2)
		{
			throw ex2;
		}
		if (stream == null)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			stream = ((ConnectionType != OracleConnectionType.TimesTen) ? executingAssembly.GetManifestResourceStream("Oracle.DataAccess.src.Client.Resources.OracleMetaData.xml") : executingAssembly.GetManifestResourceStream("Oracle.DataAccess.src.Client.Resources.TimesTenMetaData.xml"));
		}
		if (stream != null)
		{
			XmlTextReader xmlTextReader = new XmlTextReader(stream);
			m_metaDataCollectionDS = new DataSet("DocumentElement");
			m_metaDataCollectionDS.ReadXml(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private string NormalizeDBVersion(string str)
	{
		string text = null;
		int num = 0;
		int num2 = 0;
		int length = str.Length;
		while (num <= length && num2 > -1)
		{
			num2 = str.IndexOf(".", num);
			if (num2 == -1)
			{
				if (length - num == 1)
				{
					text += "0";
				}
				text += str.Substring(num, length - num);
				break;
			}
			if (num2 - num == 1)
			{
				text += "0";
			}
			text += str.Substring(num, num2 - num + 1);
			num = num2 + 1;
		}
		return text;
	}

	private bool SupportedInCurrentVersion(DataRow row, string normalizedDBVersion)
	{
		string xmlnormalizedDBVersion = row["MaximumVersion"].ToString();
		string xmlnormalizedDBVersion2 = row["MinimumVersion"].ToString();
		if (ComparenormalizedDBVersions(normalizedDBVersion, xmlnormalizedDBVersion2) >= 0 && ComparenormalizedDBVersions(normalizedDBVersion, xmlnormalizedDBVersion) <= 0)
		{
			return true;
		}
		return false;
	}

	private int ComparenormalizedDBVersions(string normalizedDBVersion, string xmlnormalizedDBVersion)
	{
		int result = 0;
		int i = 0;
		int length = normalizedDBVersion.Length;
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
		numberFormatInfo.NumberDecimalSeparator = ".";
		if (xmlnormalizedDBVersion.Length > 0)
		{
			for (; i <= length; i += 3)
			{
				if (int.Parse(normalizedDBVersion.Substring(i, 2), numberFormatInfo) > int.Parse(xmlnormalizedDBVersion.Substring(i, 2), numberFormatInfo))
				{
					return result = 1;
				}
				if (int.Parse(normalizedDBVersion.Substring(i, 2), numberFormatInfo) < int.Parse(xmlnormalizedDBVersion.Substring(i, 2), numberFormatInfo))
				{
					return result = -1;
				}
			}
		}
		return result;
	}

	public unsafe void EnlistDistributedTransaction(ITransaction itrans)
	{
		if (IsAvailable)
		{
			throw new NotSupportedException();
		}
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::EnlistDistributedTransaction()\n");
		}
		if (State == ConnectionState.Closed)
		{
			OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
		}
		if (m_bLocalTxnStartedForSysTxn)
		{
			if (m_promoteTxnMgr == null || !m_promoteTxnMgr.m_bLocalTxnPromoted)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_MTS_ENLIST_FAIL));
			}
		}
		else
		{
			m_oraTransaction = GetTransaction();
			if (m_oraTransaction != null)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_ALREADY_TXNED));
			}
		}
		if (m_opoConCtx.pOpoConValCtx->InMtsTxn == 1)
		{
			try
			{
				m_opoConCtx.m_systemTransaction = null;
				m_opoConCtx.m_txnType = TxnType.None;
				m_opoConCtx.opoConRefCtx.pITransaction = null;
				num = OpsCon.Enlist(m_opoConCtx.opsConCtx, m_opoConCtx.pOpoConValCtx, m_opoConCtx.opoConRefCtx);
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
				m_opoConCtx.pOpoConValCtx->InMtsTxn = 0;
			}
			if (num != 0)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_MTS_ENLIST_FAIL));
			}
		}
		if (itrans != null)
		{
			try
			{
				m_opoConCtx.opoConRefCtx.pITransaction = itrans;
				num = OpsCon.Enlist(m_opoConCtx.opsConCtx, m_opoConCtx.pOpoConValCtx, m_opoConCtx.opoConRefCtx);
				if (num == 0)
				{
					m_opoConCtx.m_systemTransaction = TransactionInterop.GetTransactionFromDtcTransaction(itrans as IDtcTransaction);
					if (m_opoConCtx.m_systemTransaction == null)
					{
						m_opoConCtx.opoConRefCtx.pITransaction = null;
						num = OpsCon.Enlist(m_opoConCtx.opsConCtx, m_opoConCtx.pOpoConValCtx, m_opoConCtx.opoConRefCtx);
						m_opoConCtx.pOpoConValCtx->InMtsTxn = 0;
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_MTS_ENLIST_FAIL));
					}
					m_opoConCtx.m_txnType = TxnType.SystemTxn;
					m_opoConCtx.pOpoConValCtx->InMtsTxn = 1;
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
		if (num != 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_MTS_ENLIST_FAIL));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleConnection::EnlistDistributedTransaction()\n");
		}
	}

	public unsafe override void EnlistTransaction(Transaction transaction)
	{
		if (IsAvailable)
		{
			throw new NotSupportedException();
		}
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::EnlistTransaction()\n");
		}
		if (State == ConnectionState.Closed)
		{
			OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
		}
		string text = null;
		if (m_promoteTxnMgr != null && !string.IsNullOrEmpty(m_promoteTxnMgr.m_localTxnIdentifier))
		{
			text = m_promoteTxnMgr.m_localTxnIdentifier;
		}
		else if (null != m_opoConCtx.m_systemTransaction)
		{
			text = m_opoConCtx.m_systemTransaction.TransactionInformation.LocalIdentifier;
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (!text.Equals(transaction.TransactionInformation.LocalIdentifier))
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_ALREADY_TXNED));
			}
		}
		else
		{
			m_oraTransaction = GetTransaction();
			if (m_oraTransaction != null || m_opoConCtx.pOpoConValCtx->InMtsTxn == 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_ALREADY_TXNED));
			}
			if (null == transaction && m_opoConCtx.pOpoConValCtx->InMtsTxn == 0)
			{
				return;
			}
			bool flag = true;
			if (transaction != null)
			{
				Guid distributedIdentifier = transaction.TransactionInformation.DistributedIdentifier;
				string localIdentifier = transaction.TransactionInformation.LocalIdentifier;
				object obj = m_pspePrimaryResourceEntry[localIdentifier];
				if (distributedIdentifier == Guid.Empty)
				{
					if (obj == null)
					{
						bool isDBVer_11_1_0_7_OrHigher = IsDBVer_11_1_0_7_OrHigher;
						m_pspePrimaryResourceEntry.Add(localIdentifier, new PSPEPrimaryConnectionInfo(isDBVer_11_1_0_7_OrHigher, m_opoConCtx.pOpoConValCtx->PSPE));
						if (m_opoConCtx.pOpoConValCtx->PSPE == 0 || (isDBVer_11_1_0_7_OrHigher && m_opoConCtx.pOpoConValCtx->PSPE == 1))
						{
							flag = false;
							if (m_promoteTxnMgr == null)
							{
								m_promoteTxnMgr = new PromotableTxnMgr();
							}
							transaction.EnlistPromotableSinglePhase(m_promoteTxnMgr);
							m_promoteTxnMgr.m_oraTransaction = BeginTransaction();
							m_bLocalTxnStartedForSysTxn = true;
							m_opoConCtx.m_promotableTxnManager = m_promoteTxnMgr;
							m_opoConCtx.m_systemTransaction = transaction;
							m_opoConCtx.m_txnType = TxnType.LocalTxnForSysTxn;
							m_promoteTxnMgr.m_localTxnIdentifier = transaction.TransactionInformation.LocalIdentifier;
							m_promoteTxnMgr.m_opsConCtx = m_opoConCtx.opsConCtx;
							m_promoteTxnMgr.m_opsErrCtx = m_opoConCtx.opsErrCtx;
							m_promoteTxnMgr.m_opoConRefCtx = m_opoConCtx.opoConRefCtx;
							ConnectionDispenser.CopyPooledConCtx(ref m_promoteTxnMgr.m_pOpoConValCtx, m_opoConCtx.pOpoConValCtx);
							transaction.TransactionCompleted += TransactionComplete;
						}
						else
						{
							m_opoConCtx.m_promotableTxnManager = new PromotableTxnMgr();
							m_opoConCtx.m_promotableTxnManager.m_localTxnIdentifier = transaction.TransactionInformation.LocalIdentifier;
							m_opoConCtx.m_txnType = TxnType.SystemTxn;
						}
					}
					else
					{
						PSPEPrimaryConnectionInfo pSPEPrimaryConnectionInfo = obj as PSPEPrimaryConnectionInfo;
						if (pSPEPrimaryConnectionInfo.m_pspeAttributeValue == 0 || m_opoConCtx.pOpoConValCtx->PSPE == 0 || !pSPEPrimaryConnectionInfo.m_dbSupportPromotion)
						{
							throw new TransactionPromotionException(OpoErrResManager.GetErrorMesg(ErrRes.CON_PSPE_RULE_VIOLATION));
						}
						TransactionInterop.GetTransmitterPropagationToken(transaction);
					}
				}
				else if (m_opoConCtx.pOpoConValCtx->PSPE == 0)
				{
					throw new TransactionPromotionException(OpoErrResManager.GetErrorMesg(ErrRes.CON_PSPE_RULE_VIOLATION));
				}
				if (flag)
				{
					m_opoConCtx.m_txnType = TxnType.SystemTxn;
					ITransaction transaction2 = (ITransaction)TransactionInterop.GetDtcTransaction(transaction);
					if (transaction2 != null)
					{
						try
						{
							m_opoConCtx.opoConRefCtx.pITransaction = transaction2;
							num = OpsCon.Enlist(m_opoConCtx.opsConCtx, m_opoConCtx.pOpoConValCtx, m_opoConCtx.opoConRefCtx);
							if (num == 0)
							{
								m_opoConCtx.m_systemTransaction = transaction;
								m_opoConCtx.m_txnType = TxnType.SystemTxn;
								m_opoConCtx.pOpoConValCtx->InMtsTxn = 1;
								transaction.TransactionCompleted += TransactionComplete;
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
					}
				}
			}
			if (num != 0)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_MTS_ENLIST_FAIL));
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleConnection::EnlistTransaction()\n");
		}
	}

	internal unsafe void TransactionComplete(object sender, TransactionEventArgs e)
	{
		if (m_state == ConnectionState.Closed)
		{
			return;
		}
		lock (m_syncTxnComplete)
		{
			if (m_state != 0)
			{
				if (m_opoConCtx != null && m_opoConCtx.m_txnid != null)
				{
					m_opoConCtx.pool.m_cpCtx.m_htTxnIdToIntance.Remove(m_opoConCtx.m_txnid);
					m_opoConCtx.m_txnid = null;
				}
				try
				{
					if (!m_bLocalTxnStartedForSysTxn)
					{
						if (m_opoConCtx != null && null != m_opoConCtx.pOpoConValCtx && 1 == m_opoConCtx.pOpoConValCtx->InMtsTxn)
						{
							try
							{
								m_opoConCtx.opoConRefCtx.pITransaction = null;
								OpsCon.Enlist(m_opoConCtx.opsConCtx, m_opoConCtx.pOpoConValCtx, m_opoConCtx.opoConRefCtx);
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
					}
					else
					{
						try
						{
							if (m_promoteTxnMgr != null && m_promoteTxnMgr.m_bLocalTxnPromoted)
							{
								OpsCon.DelistPromotedTxn(m_opoConCtx.opsConCtx);
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
				finally
				{
					m_bLocalTxnStartedForSysTxn = false;
					m_promoteTxnMgr = null;
					m_oraTransaction = null;
					if (m_opoConCtx != null)
					{
						if (m_opoConCtx.m_promotableTxnManager != null)
						{
							string localTxnIdentifier = m_opoConCtx.m_promotableTxnManager.m_localTxnIdentifier;
							if (!string.IsNullOrEmpty(localTxnIdentifier))
							{
								m_pspePrimaryResourceEntry.Remove(localTxnIdentifier);
							}
							m_opoConCtx.m_promotableTxnManager.m_localTxnIdentifier = null;
							m_opoConCtx.m_promotableTxnManager = null;
						}
						m_opoConCtx.m_txnType = TxnType.None;
						m_opoConCtx.m_systemTransaction = null;
					}
				}
			}
			if (sender is Transaction)
			{
				(sender as Transaction).TransactionCompleted -= TransactionComplete;
			}
		}
	}

	public void FlushCache()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::FlushCache()\n");
		}
		if (State == ConnectionState.Closed)
		{
			OracleException.HandleError(ErrRes.CON_CLOSED, this, m_opoConCtx.opsErrCtx, this);
		}
		int num = 0;
		try
		{
			num = OpsCon.FlushCache(m_opoConCtx.opsConCtx, m_opoConCtx.opsErrCtx);
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
				OracleException.HandleError(num, this, m_opoConCtx.opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::FlushCache()\n");
		}
	}

	private void ParseConnectionString()
	{
		int num = 0;
		string text = m_conString.Trim();
		int length = text.Length;
		while (num < length)
		{
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			bool flag = false;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			bool flag2 = false;
			while (!flag2)
			{
				char c = text[num];
				if (c != ';' && c != '\t' && c != ' ')
				{
					flag2 = true;
					continue;
				}
				if (num == length - 1)
				{
					return;
				}
				if (num < length)
				{
					num++;
				}
			}
			num2 = num;
			num3 = text.IndexOf('=', num);
			if (num3 == -1)
			{
				RestoreConStrVals();
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_NOT_WELL_FORMED));
			}
			text2 = text.Substring(num2, num3 - num2).Trim();
			num4 = text.IndexOf(';', num3);
			if (num4 == -1)
			{
				num4 = length;
			}
			num5 = text.IndexOf('"', num3);
			num9 = text.IndexOf('\'', num3);
			if (num5 < num4 && num5 != -1)
			{
				num6 = text.IndexOf('"', num5 + 1);
				if (num6 > num4)
				{
					num4 = text.IndexOf(';', num6 + 1);
					if (num4 == -1)
					{
						num4 = length;
					}
				}
				num7 = text.IndexOf('"', num6 + 1);
				if (num7 == -1)
				{
					num7 = length;
				}
				if (num7 < num4)
				{
					if (string.Compare(text2, "PASSWORD", ignoreCase: true) != 0 && string.Compare(text2, "PROXY PASSWORD", ignoreCase: true) != 0)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_NOT_WELL_FORMED));
					}
					num8 = num7;
					while (num8 < num4 && num8 != -1)
					{
						num7 = num8;
						num8 = text.IndexOf('"', num8 + 1);
					}
				}
				string text5 = text.Substring(num3 + 1, num4 - (num3 + 1));
				if (num9 != -1 && num9 < num5)
				{
					num10 = text.IndexOf('\'', num6 + 1);
					if (num10 != -1 && num10 < num4)
					{
						text5 = text5.Trim(delim2);
						flag = true;
					}
				}
				if (string.Compare(strB: ((num8 != 0) ? text.Substring(num5, num7 - (num5 - 1)) : text.Substring(num5, num6 - (num5 - 1))).Trim(delim), strA: text5.Trim(delim)) != 0)
				{
					throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_NOT_WELL_FORMED));
				}
			}
			if (string.Compare(text2, "CONNECT TIMEOUT", ignoreCase: true, CultureInfo.InvariantCulture) == 0)
			{
				text2 = "CONNECTION TIMEOUT";
			}
			if (m_AttribToIndex.ContainsKey(text2))
			{
				text3 = text.Substring(++num3, num4 - num3).Trim();
				if (flag)
				{
					text3 = text3.Trim(delim2);
				}
				if (text3 != null && text3.Length != 0)
				{
					if (text3[0] == '"')
					{
						if (text3[text3.Length - 1] != '"')
						{
							RestoreConStrVals();
							throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_NOT_WELL_FORMED));
						}
						text3 = ((string.Compare(text3, "\"/\"", ignoreCase: true) == 0) ? "/" : ((string.Compare(text2, "USER ID", ignoreCase: true, CultureInfo.InvariantCulture) == 0 || string.Compare(text2, "PROXY USER ID", ignoreCase: true, CultureInfo.InvariantCulture) == 0 || string.Compare(text2, "PASSWORD", ignoreCase: true) == 0 || string.Compare(text2, "PROXY PASSWORD", ignoreCase: true) == 0) ? text3.Trim(' ', '\t') : text3.Trim(delim1).ToLower()));
						int num11 = (int)m_AttribToIndex[text2];
						if (num11 <= IndexStrAttribMax)
						{
							if (num11 != IndexPasswd && num11 != IndexProxyPwd)
							{
								m_conStrVals[num11] = text3;
							}
						}
						else if (num11 <= IndexIntAttribMax)
						{
							m_conStrVals[num11] = int.Parse(text3, NumberStyles.AllowLeadingSign);
						}
						else if (num11 <= IndexBoolAttribMax)
						{
							object obj = null;
							obj = ((num11 != IndexEnlist) ? m_boolMapping[text3.ToLower()] : ((!(text3.ToLower(CultureInfo.InvariantCulture) == "dynamic")) ? m_boolMapping[text3.ToLower()] : ((object)2)));
							if (obj == null)
							{
								RestoreConStrVals();
								throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, text2, text3));
							}
							m_conStrVals[num11] = (int)obj;
						}
					}
					else
					{
						int num11 = (int)m_AttribToIndex[text2];
						if (num11 <= IndexStrAttribMax)
						{
							if (num11 != IndexPasswd && num11 != IndexProxyPwd)
							{
								m_conStrVals[num11] = text3;
							}
						}
						else if (num11 <= IndexIntAttribMax)
						{
							m_conStrVals[num11] = int.Parse(text3, NumberStyles.AllowLeadingSign);
						}
						else if (num11 <= IndexBoolAttribMax)
						{
							object obj2 = null;
							obj2 = ((num11 != IndexEnlist) ? m_boolMapping[text3.ToLower()] : ((!(text3.ToLower(CultureInfo.InvariantCulture) == "dynamic")) ? m_boolMapping[text3.ToLower()] : ((object)2)));
							if (obj2 == null)
							{
								RestoreConStrVals();
								throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, text2, text3));
							}
							m_conStrVals[num11] = (int)obj2;
						}
					}
				}
				else
				{
					int num11 = (int)m_AttribToIndex[text2];
					if ((int)m_AttribToIndex[text2] <= IndexStrAttribMax)
					{
						m_conStrVals[num11] = string.Empty;
					}
				}
				num = num4 + 1;
				continue;
			}
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_ATTRIB, text2));
		}
		if (m_conString != null && m_conString.Length != 0)
		{
			ValidateValues();
		}
		m_internalConStr = ConstructConString();
	}

	private string GetPasswordLessString(string conString)
	{
		string value = "password";
		string value2 = "proxy password";
		string[] array = conString.Split(';');
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		for (int i = 0; i < array.Length; i++)
		{
			text = array[i].ToLower();
			if (text.IndexOf(value) == -1 && text.IndexOf(value2) == -1)
			{
				stringBuilder.Append(array[i]);
			}
			else
			{
				string[] array2 = text.Split('=');
				string text2 = array2[0].Trim();
				if (text2.Equals(value) || text2.Equals(value2))
				{
					continue;
				}
				stringBuilder.Append(array[i]);
			}
			if (i < array.Length - 1)
			{
				stringBuilder.Append(";");
			}
		}
		return stringBuilder.ToString();
	}

	private void ResetAttribsToDefaults()
	{
		m_conStrVals[IndexUserID] = "";
		m_conStrVals[IndexPasswd] = "";
		m_conStrVals[IndexLifetime] = 0;
		m_conStrVals[IndexPoolInc] = 5;
		m_conStrVals[IndexPoolDec] = 1;
		m_conStrVals[IndexTimeout] = 15;
		m_conStrVals[IndexDataSrc] = "";
		m_conStrVals[IndexEnlist] = 1;
		m_conStrVals[IndexMaxPool] = 100;
		m_conStrVals[IndexMinPool] = 1;
		m_conStrVals[IndexPoolReg] = 180;
		m_conStrVals[IndexPersist] = 0;
		m_conStrVals[IndexPooling] = 1;
		m_conStrVals[IndexProxyUsr] = "";
		m_conStrVals[IndexProxyPwd] = "";
		m_conStrVals[IndexDBAPriv] = "";
		m_conStrVals[IndexValidCon] = 0;
		if (OraTrace.m_MetadataPooling != 0)
		{
			m_conStrVals[IndexMetaPool] = 1;
		}
		else
		{
			m_conStrVals[IndexMetaPool] = 0;
		}
		m_conStrVals[IndexGridCR] = 0;
		m_conStrVals[IndexGridRLB] = 0;
		m_conStrVals[IndexCtxConn] = 0;
		m_conStrVals[IndexStmtCachePurge] = 0;
		m_conStrVals[IndexAppEdition] = OraTrace.m_appEdition;
		if (OraTrace.m_StmtCacheSize > 0)
		{
			m_conStrVals[IndexStmtCache] = OraTrace.m_StmtCacheSize;
		}
		else
		{
			m_conStrVals[IndexStmtCache] = 0;
		}
		if (OraTrace.m_PSPE > 0)
		{
			m_conStrVals[IndexPSPE] = "promotable";
		}
		else
		{
			m_conStrVals[IndexPSPE] = "local";
		}
		if (OraTrace.m_selfTuning)
		{
			m_conStrVals[IndexSelfTuning] = 1;
		}
		else
		{
			m_conStrVals[IndexSelfTuning] = 0;
		}
	}

	private void Init()
	{
		m_conString = string.Empty;
		m_conTimeout = 15;
		m_dataSource = string.Empty;
		m_serverVersion = string.Empty;
		m_state = ConnectionState.Closed;
		m_tmpConString = string.Empty;
		m_serviceName = string.Empty;
		m_databaseName = string.Empty;
		m_databaseDomainName = string.Empty;
		m_hostName = string.Empty;
		m_instanceName = string.Empty;
		m_DataReaderList = new ArrayList();
		m_opoConCtx = new OpoConCtx();
	}

	private void ValidateValues()
	{
		string text = null;
		int num = 0;
		int num2 = 0;
		text = (string)m_conStrVals[IndexDBAPriv];
		if (text != null && text.Length != 0 && text.ToLower() != "sysdba" && text.ToLower() != "sysoper")
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "DBA Privilege", text));
		}
		text = (string)m_conStrVals[IndexPSPE];
		if (text != null && text.Length != 0 && text.ToLower() != "local" && text.ToLower() != "promotable")
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Promotable Transaction", text));
		}
		try
		{
			num = (int)m_conStrVals[IndexTimeout];
		}
		catch
		{
			string errorMesg = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Timeout", num.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg);
		}
		if (num < 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Timeout", num.ToString()));
		}
		try
		{
			num = (int)m_conStrVals[IndexLifetime];
		}
		catch
		{
			string errorMesg2 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Lifetime", num.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg2);
		}
		if (num < 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Lifetime", num.ToString()));
		}
		try
		{
			num = (int)m_conStrVals[IndexMaxPool];
		}
		catch
		{
			string errorMesg3 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Max Pool Size", num.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg3);
		}
		if (num <= 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Max Pool Size", num.ToString()));
		}
		try
		{
			num2 = (int)m_conStrVals[IndexMinPool];
		}
		catch
		{
			string errorMesg4 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Min Pool Size", num2.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg4);
		}
		if (num2 < 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Min Pool Size", num2.ToString()));
		}
		if (num < num2)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Max Pool Size", num.ToString()));
		}
		try
		{
			num = (int)m_conStrVals[IndexPoolInc];
		}
		catch
		{
			string errorMesg5 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Increment", num.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg5);
		}
		if (num <= 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Increment", num.ToString()));
		}
		try
		{
			num = (int)m_conStrVals[IndexPoolDec];
		}
		catch
		{
			string errorMesg6 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Decrement", num.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg6);
		}
		if (num <= 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Decrement", num.ToString()));
		}
		try
		{
			num = (int)m_conStrVals[IndexStmtCache];
		}
		catch
		{
			string errorMesg7 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Statement Cache Size", num.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg7);
		}
		if (num < 0)
		{
			RestoreConStrVals();
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Statement Cache Size", num.ToString()));
		}
		bool flag = false;
		try
		{
			flag = Convert.ToBoolean(m_conStrVals[IndexSelfTuning]);
		}
		catch
		{
			string errorMesg8 = OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Self Tuning", flag.ToString());
			RestoreConStrVals();
			throw new ArgumentException(errorMesg8);
		}
	}

	private void RestoreConStrVals()
	{
		if (m_tmpConString == null)
		{
			m_conString = string.Empty;
			return;
		}
		ConnectionString = m_tmpConString;
		m_tmpConString = string.Empty;
	}

	internal string ConstructConString()
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		stringBuilder.Append("datasrc=");
		stringBuilder.Append(m_conStrVals[IndexDataSrc]);
		stringBuilder.Append(";enlist=");
		stringBuilder.Append(m_conStrVals[IndexEnlist]);
		stringBuilder.Append(";lifetime=");
		stringBuilder.Append(m_conStrVals[IndexLifetime]);
		stringBuilder.Append(";maxsize=");
		stringBuilder.Append(m_conStrVals[IndexMaxPool]);
		stringBuilder.Append(";minsize=");
		stringBuilder.Append(m_conStrVals[IndexMinPool]);
		stringBuilder.Append(";incsize=");
		stringBuilder.Append(m_conStrVals[IndexPoolInc]);
		stringBuilder.Append(";decsize=");
		stringBuilder.Append(m_conStrVals[IndexPoolDec]);
		stringBuilder.Append(";timeout=");
		stringBuilder.Append(m_conStrVals[IndexTimeout]);
		stringBuilder.Append(";dbapriv=");
		stringBuilder.Append(m_conStrVals[IndexDBAPriv]);
		stringBuilder.Append(";validcon=");
		stringBuilder.Append(m_conStrVals[IndexValidCon]);
		if (!Convert.ToBoolean(m_conStrVals[IndexSelfTuning]))
		{
			stringBuilder.Append(";stmtcache=");
			stringBuilder.Append(m_conStrVals[IndexStmtCache]);
		}
		else
		{
			stringBuilder.Append(";stmtcache=0");
		}
		if ((int)m_conStrVals[IndexStmtCache] > 0 && !Convert.ToBoolean(m_conStrVals[IndexSelfTuning]))
		{
			stringBuilder.Append(";stmtcachepurge=");
			stringBuilder.Append(m_conStrVals[IndexStmtCachePurge]);
		}
		else
		{
			stringBuilder.Append(";stmtcachepurge=0");
		}
		stringBuilder.Append(";metapool=");
		stringBuilder.Append(m_conStrVals[IndexMetaPool]);
		stringBuilder.Append(";selftuning=");
		stringBuilder.Append(m_conStrVals[IndexSelfTuning]);
		stringBuilder.Append(";pspe=");
		stringBuilder.Append(m_conStrVals[IndexPSPE]);
		int num = (int)m_conStrVals[IndexGridCR];
		_ = (int)m_conStrVals[IndexGridRLB];
		if (num == 1)
		{
			stringBuilder.Append(";gridrac=");
			stringBuilder.Append(m_conStrVals[IndexGridCR]);
		}
		else
		{
			stringBuilder.Append(";gridrac=");
			stringBuilder.Append(m_conStrVals[IndexGridRLB]);
		}
		if (m_conStrVals[IndexProxyUsr].ToString().Length > 0)
		{
			stringBuilder.Append(";pxyusr=");
			stringBuilder.Append(m_conStrVals[IndexProxyUsr]);
		}
		else
		{
			bool flag = false;
			if (((string)m_conStrVals[IndexUserID]).Trim(delim) == "/")
			{
				flag = true;
			}
			if (flag)
			{
				stringBuilder.Append(";osuserid=");
				stringBuilder.Append(WindowsIdentity.GetCurrent().Name);
			}
			else
			{
				stringBuilder.Append(";userid=");
				stringBuilder.Append(m_conStrVals[IndexUserID]);
			}
		}
		return stringBuilder.ToString();
	}

	internal OracleTransaction GetTransaction()
	{
		if (m_oraTransaction != null && m_oraTransaction.Completed)
		{
			m_oraTransaction = null;
		}
		return m_oraTransaction;
	}

	internal unsafe bool IsInMtsTxn()
	{
		if (m_opoConCtx != null && m_opoConCtx.pOpoConValCtx != null && m_opoConCtx.pOpoConValCtx->InMtsTxn == 1)
		{
			return true;
		}
		return false;
	}

	internal void EndTransaction()
	{
		m_oraTransaction = null;
	}

	internal void OnInfoMessage(object obj, OracleInfoMessageEventArgs eventArgs)
	{
		if (m_infoMessageEventHandler != null)
		{
			try
			{
				m_infoMessageEventHandler(obj, eventArgs);
			}
			catch
			{
			}
		}
	}

	protected override void OnStateChange(StateChangeEventArgs eventArgs)
	{
		if (m_stateChangeEventHandler != null)
		{
			m_stateChangeEventHandler(this, eventArgs);
		}
	}

	internal void RaiseStateChange(ConnectionState originalState, ConnectionState currentState)
	{
		StateChangeEventArgs stateChange = new StateChangeEventArgs(originalState, currentState);
		OnStateChange(stateChange);
	}

	internal int OnFailover(OracleFailoverEventArgs eventArgs)
	{
		int result = 0;
		if (m_failoverEventHandler != null)
		{
			try
			{
				result = (int)m_failoverEventHandler(this, eventArgs);
			}
			catch
			{
			}
		}
		else if (eventArgs.FailoverEvent == FailoverEvent.Error)
		{
			return 25410;
		}
		return result;
	}

	internal static void OnHAEvent(object state)
	{
		OracleHAEventArgs eventArgs = (OracleHAEventArgs)state;
		if (m_haEventHandler != null)
		{
			m_haEventHandler(eventArgs);
		}
	}

	internal Type GetCustomUdt(string udtName)
	{
		Type result = null;
		_ = m_state;
		_ = 1;
		return result;
	}

	internal static void SetOdtConnection(bool bIsOdtConnection)
	{
		s_bIsOdtConnection = bIsOdtConnection;
	}

	private unsafe void OpenExtprocConnection()
	{
		IntPtr ociExtProcContext = GetOciExtProcContext();
		m_extProcEnv = (Thread.GetData(m_oraThreadDataSlot) as ThreadData).m_extProcEnv;
		if (!m_internalUse && ExternalContextConnection != null && ExternalContextConnection.State != 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_CTX_CONN_OPENED_ALREADY));
		}
		int num = 0;
		try
		{
			if (m_opoConCtx.opoConRefCtx == null)
			{
				m_opoConCtx.opoConRefCtx = new OpoConRefCtx();
			}
			m_opoConCtx.opoConRefCtx.pITransaction = null;
			if (m_opoConCtx.pOpoConValCtx == null)
			{
				OpsCon.AllocValCtx(ref m_opoConCtx.pOpoConValCtx);
			}
			m_opoConCtx.pOpoConValCtx->Enlist = 0;
			m_opoConCtx.m_bSelfTuning = false;
			m_opoConCtx.pOpoConValCtx->StmtCacheSize = (int)m_conStrVals[IndexStmtCache];
			num = OpsCon.OpenUsingExtProcContext(ociExtProcContext, ref m_opoConCtx.opsConCtx, ref m_opoConCtx.opsErrCtx, m_opoConCtx.pOpoConValCtx, ref m_opoConCtx.opoConRefCtx);
			m_majorVersion = m_opoConCtx.pOpoConValCtx->MajorVersion;
			m_minorVersion = m_opoConCtx.pOpoConValCtx->MinorVersion;
			m_PatchSetVersion = m_opoConCtx.pOpoConValCtx->PatchSetVersion;
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
			OracleException.HandleError(ErrRes.INT_ERR, null, IntPtr.Zero, this);
		}
		if (m_internalUse)
		{
			if (ExternalContextConnection != null && ExternalContextConnection.State == ConnectionState.Open)
			{
				m_conSignature = ExternalContextConnection.m_conSignature;
			}
			else
			{
				if (m_opoConCtx.pOpoConValCtx->ConSignature == int.MaxValue)
				{
					m_opoConCtx.pOpoConValCtx->ConSignature = 0;
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->ConSignature = m_opoConCtx.pOpoConValCtx->ConSignature + 1;
				}
				m_conSignature = ((double)m_opoConCtx.pOpoConValCtx->ConSignature + (double)(int)m_opoConCtx.opsConCtx / 10000000000.0).GetHashCode();
			}
			if (InternalContextConnection != null && InternalContextConnection.State == ConnectionState.Open)
			{
				InternalContextConnection.Close();
			}
			InternalContextConnection = this;
		}
		else
		{
			if (InternalContextConnection != null && InternalContextConnection.State == ConnectionState.Open)
			{
				m_conSignature = InternalContextConnection.m_conSignature;
			}
			else
			{
				if (m_opoConCtx.pOpoConValCtx->ConSignature == int.MaxValue)
				{
					m_opoConCtx.pOpoConValCtx->ConSignature = 0;
				}
				else
				{
					m_opoConCtx.pOpoConValCtx->ConSignature = m_opoConCtx.pOpoConValCtx->ConSignature + 1;
				}
				m_conSignature = ((double)m_opoConCtx.pOpoConValCtx->ConSignature + (double)(int)m_opoConCtx.opsConCtx / 10000000000.0).GetHashCode();
			}
			if (ExternalContextConnection != null && ExternalContextConnection.State == ConnectionState.Open)
			{
				ExternalContextConnection.Close();
			}
			ExternalContextConnection = this;
		}
		m_state = ConnectionState.Open;
		m_serverVersion = m_opoConCtx.opoConRefCtx.serverVersion;
		m_pwdValidated = true;
	}

	internal static OracleConnection GetInternalConnection()
	{
		if (!(Thread.GetData(m_oraThreadDataSlot) is ThreadData threadData))
		{
			throw new InvalidOperationException();
		}
		if (threadData.m_internalExtprocConn == null)
		{
			threadData.m_internalExtprocConn = new OracleConnection("context connection=true");
			threadData.m_internalExtprocConn.m_internalUse = true;
			threadData.m_internalExtprocConn.Open();
		}
		return threadData.m_internalExtprocConn;
	}

	private static IntPtr GetOciExtProcContext()
	{
		if (!(Thread.GetData(m_oraThreadDataSlot) is ThreadData threadData))
		{
			return IntPtr.Zero;
		}
		return threadData.m_ociExtProcContext;
	}

	internal static void ValidateAdminValues(OracleConnection conn)
	{
		if (conn.m_internalConStr == null)
		{
			throw new InvalidOperationException();
		}
		object[] array = null;
		array = ((conn.m_conStrVals == null) ? ((object[])MetaData.m_connDataPooler.Get(ConStrAtrribs, conn.m_pwdLessString)) : conn.m_conStrVals);
		if (array == null)
		{
			throw new InvalidOperationException();
		}
		conn.m_opoConCtx.gridCR = (int)array[IndexGridCR];
		conn.m_opoConCtx.gridRLB = (int)array[IndexGridRLB];
		conn.m_opoConCtx.bGridRac = conn.m_opoConCtx.gridCR == 1 || conn.m_opoConCtx.gridRLB == 1;
		conn.m_opoConCtx.conString = conn.m_internalConStr;
		conn.m_opoConCtx.dataSrc = conn.m_dataSource;
		if (conn.m_opoConCtx.bGridRac)
		{
			if (ConnectionDispenser.m_htTnsToSvc == null || ConnectionDispenser.m_htSvcToRLB == null)
			{
				throw new InvalidOperationException();
			}
			string text = (string)ConnectionDispenser.m_htTnsToSvc[conn.m_opoConCtx.dataSrc];
			if (text == null)
			{
				throw new InvalidOperationException();
			}
			RLBCtx rLBCtx = (RLBCtx)ConnectionDispenser.m_htSvcToRLB[text];
			if (rLBCtx == null)
			{
				throw new InvalidOperationException();
			}
			CPCtx cPCtx = (CPCtx)rLBCtx.htConToInst[conn.m_opoConCtx.conString];
			if (cPCtx == null)
			{
				throw new InvalidOperationException();
			}
		}
		else
		{
			if (ConnectionDispenser.m_ConnectionPools == null)
			{
				throw new InvalidOperationException();
			}
			if (ConnectionDispenser.m_ConnectionPools[conn.m_internalConStr] == null)
			{
				throw new InvalidOperationException();
			}
			if (conn.m_opoConCtx.pool == null)
			{
				conn.m_opoConCtx.pool = (ConnectionPool)ConnectionDispenser.m_ConnectionPools[conn.m_internalConStr];
			}
		}
	}

	internal static void CloseExtprocConnection()
	{
		if (m_oraThreadDataSlot != null && Thread.GetData(m_oraThreadDataSlot) is ThreadData threadData)
		{
			lock (threadData.m_extProcEnv)
			{
				threadData.m_extProcEnv.m_status = false;
			}
			if (threadData.m_externalExtprocConn != null && threadData.m_externalExtprocConn.State == ConnectionState.Open)
			{
				threadData.m_externalExtprocConn.Close();
				threadData.m_externalExtprocConn = null;
			}
			if (threadData.m_internalExtprocConn != null && threadData.m_internalExtprocConn.State == ConnectionState.Open)
			{
				threadData.m_internalExtprocConn.Close();
				threadData.m_internalExtprocConn = null;
			}
			threadData.m_ociExtProcContext = IntPtr.Zero;
			Thread.SetData(m_oraThreadDataSlot, null);
		}
	}

	internal static void CreateExtprocTDS()
	{
		if (m_oraThreadDataSlot == null)
		{
			m_oraThreadDataSlot = Thread.AllocateDataSlot();
		}
	}

	internal static void SetExtProcContext(IntPtr extProcContext)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::SetExtProcContext()\n");
		}
		ThreadData data = new ThreadData(extProcContext);
		Thread.SetData(m_oraThreadDataSlot, data);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleConnection::SetExtProcContext()\n");
		}
	}

	internal static void SetExtProcFlag()
	{
		OpsCom.Exf();
	}

	public static void ClearPool(OracleConnection conn)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection.ClearPool()\n");
		}
		if (conn == null)
		{
			throw new ArgumentNullException();
		}
		if (conn.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_NOTSUPPORTED_CTX_CONN));
		}
		if (1 == OraTrace.m_demandOrclPermission && conn.m_orclPermission != null)
		{
			conn.m_orclPermission.Demand();
		}
		try
		{
			ValidateAdminValues(conn);
			ConnectionDispenser.ClearPool(conn.m_opoConCtx, bInvalidOnly: false, bRefresh: false);
		}
		catch
		{
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::ClearPool()\n");
		}
	}

	public static void ClearAllPools()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::ClearAllPools()\n");
		}
		if (1 == OraTrace.m_demandOrclPermission)
		{
			new OraclePermission(PermissionState.Unrestricted).Demand();
		}
		if ((ConnectionDispenser.m_ConnectionPools == null || ConnectionDispenser.m_ConnectionPools.Count == 0) && (ConnectionDispenser.m_htSvcToRLB == null || ConnectionDispenser.m_htSvcToRLB.Count == 0))
		{
			throw new InvalidOperationException();
		}
		ConnectionDispenser.ClearAllPools();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::ClearAllPools()\n");
		}
	}

	protected override DbCommand CreateDbCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, "(ENTRY) OracleConnection::CreateDbCommand()\n");
		}
		DbCommand result = new OracleCommand("", this);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::CreateDbCommand()\n");
		}
		return result;
	}

	protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnection::BeginDbTransaction()\n");
		}
		if (System.Data.IsolationLevel.Unspecified == isolationLevel)
		{
			isolationLevel = System.Data.IsolationLevel.ReadCommitted;
		}
		DbTransaction result = BeginTransaction(isolationLevel);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnection::BeginDbTransaction()\n");
		}
		return result;
	}
}

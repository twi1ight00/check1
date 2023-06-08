using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Transactions;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential)]
[SuppressUnmanagedCodeSecurity]
internal class OpoConCtx : ICloneable
{
	public IntPtr opsConCtx;

	public IntPtr opsErrCtx;

	public unsafe OpoConValCtx* pOpoConValCtx;

	public OpoConRefCtx opoConRefCtx;

	public string conString;

	public string affinityInstanceName;

	public int instanceConCount;

	public ConnectionPool pool;

	public int maxPoolSize;

	public int minPoolSize;

	public int poolIncSize;

	public int poolDecSize;

	public int poolRegulator;

	public DateTime creationTime;

	public TimeSpan lifeTime;

	public TimeSpan timeOut;

	public PooledConCtx pooledConCtx;

	public string poolName;

	public bool bErrorOnOpen;

	public int validateCon;

	public int gridCR;

	public int gridRLB;

	public bool bGridRac;

	public string dataSrc;

	public int metaPool;

	public TimeSpan origLifeTime;

	public int origPoolDecSize;

	public int origMinPoolSize;

	public string exceptMsg;

	public ConPooler m_conPooler;

	public Transaction m_systemTransaction;

	public TxnType m_txnType;

	public PromotableTxnMgr m_promotableTxnManager;

	internal FetchArrayPooler m_fetchArrayPooler;

	public string m_txnid;

	internal Hashtable m_statementData;

	internal int m_totalDataAvailable;

	internal bool m_bSelfTuning = true;

	internal int m_defaultStmtCacheSize = 30;

	public ConPooler m_udtDescPoolerByName;

	public ConPooler m_udtDescPoolerByTDO;

	internal OpoConCtx()
	{
	}

	public unsafe object Clone()
	{
		int num = 0;
		OpoConCtx opoConCtx = new OpoConCtx();
		try
		{
			num = OpsCon.AllocValCtx(ref opoConCtx.pOpoConValCtx);
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
			OracleException.HandleError(num, null, IntPtr.Zero, null);
		}
		opoConCtx.opoConRefCtx = new OpoConRefCtx();
		opoConCtx.opoConRefCtx.dataSource = opoConRefCtx.dataSource;
		opoConCtx.opoConRefCtx.newPassword = string.Empty;
		opoConCtx.opoConRefCtx.password = opoConRefCtx.password;
		opoConCtx.opoConRefCtx.pITransaction = null;
		opoConCtx.opoConRefCtx.proxyPassword = opoConRefCtx.proxyPassword;
		opoConCtx.opoConRefCtx.proxyUserId = opoConRefCtx.proxyUserId;
		opoConCtx.opoConRefCtx.serverVersion = opoConRefCtx.serverVersion;
		opoConCtx.opoConRefCtx.userID = opoConRefCtx.userID;
		opoConCtx.opoConRefCtx.dbName = opoConRefCtx.dbName;
		opoConCtx.opoConRefCtx.hostName = opoConRefCtx.hostName;
		opoConCtx.opoConRefCtx.instanceName = opoConRefCtx.instanceName;
		opoConCtx.opoConRefCtx.serviceName = opoConRefCtx.serviceName;
		opoConCtx.opoConRefCtx.dbDomainName = opoConRefCtx.dbDomainName;
		opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg = opoConRefCtx.ttOpsConOpenErrMssg;
		opoConCtx.opoConRefCtx.appEdition = opoConRefCtx.appEdition;
		opoConCtx.conString = conString;
		opoConCtx.pool = pool;
		opoConCtx.maxPoolSize = maxPoolSize;
		opoConCtx.minPoolSize = origMinPoolSize;
		opoConCtx.lifeTime = origLifeTime;
		opoConCtx.creationTime = creationTime;
		opoConCtx.poolDecSize = origPoolDecSize;
		opoConCtx.poolIncSize = poolIncSize;
		opoConCtx.poolRegulator = poolRegulator;
		opoConCtx.validateCon = validateCon;
		opoConCtx.poolDecSize = origPoolDecSize;
		opoConCtx.gridCR = gridCR;
		opoConCtx.gridRLB = gridRLB;
		opoConCtx.bGridRac = bGridRac;
		opoConCtx.origMinPoolSize = origMinPoolSize;
		opoConCtx.origLifeTime = origLifeTime;
		opoConCtx.origPoolDecSize = origPoolDecSize;
		opoConCtx.dataSrc = dataSrc;
		opoConCtx.metaPool = metaPool;
		opoConCtx.timeOut = timeOut;
		opoConCtx.m_bSelfTuning = m_bSelfTuning;
		opoConCtx.m_defaultStmtCacheSize = m_defaultStmtCacheSize;
		opoConCtx.pOpoConValCtx->Enlist = pOpoConValCtx->Enlist;
		opoConCtx.pOpoConValCtx->InMtsTxn = 0;
		opoConCtx.pOpoConValCtx->OSAuthent = pOpoConValCtx->OSAuthent;
		opoConCtx.pOpoConValCtx->Pooling = pOpoConValCtx->Pooling;
		opoConCtx.pOpoConValCtx->ServerAttach = 0;
		opoConCtx.pOpoConValCtx->SessionBegin = 0;
		opoConCtx.pOpoConValCtx->TxnHndAllocated = 0;
		opoConCtx.pOpoConValCtx->SetIntAndExtName = pOpoConValCtx->SetIntAndExtName;
		opoConCtx.pOpoConValCtx->DBAPrivilege = pOpoConValCtx->DBAPrivilege;
		opoConCtx.pOpoConValCtx->registerHA = pOpoConValCtx->registerHA;
		opoConCtx.pOpoConValCtx->registerRLB = pOpoConValCtx->registerRLB;
		opoConCtx.pOpoConValCtx->HASubscrHnd = IntPtr.Zero;
		opoConCtx.pOpoConValCtx->reRegHAFailed = 0;
		opoConCtx.pOpoConValCtx->RLBSubscrHnd = IntPtr.Zero;
		opoConCtx.pOpoConValCtx->reRegRLBFailed = 0;
		opoConCtx.pOpoConValCtx->PSPE = pOpoConValCtx->PSPE;
		opoConCtx.pOpoConValCtx->bTAFEnabled = 0;
		opoConCtx.pOpoConValCtx->StmtCachePurge = pOpoConValCtx->StmtCachePurge;
		opoConCtx.pOpoConValCtx->StmtCacheSize = pOpoConValCtx->StmtCacheSize;
		opoConCtx.pOpoConValCtx->MajorVersion = pOpoConValCtx->MajorVersion;
		opoConCtx.pOpoConValCtx->MinorVersion = pOpoConValCtx->MinorVersion;
		opoConCtx.pOpoConValCtx->PatchSetVersion = pOpoConValCtx->PatchSetVersion;
		opoConCtx.pOpoConValCtx->DbNtfPort = pOpoConValCtx->DbNtfPort;
		opoConCtx.pOpoConValCtx->bIsTimesTen = pOpoConValCtx->bIsTimesTen;
		opoConCtx.m_conPooler = null;
		opoConCtx.m_udtDescPoolerByName = null;
		opoConCtx.m_udtDescPoolerByTDO = null;
		opoConCtx.m_systemTransaction = null;
		opoConCtx.m_txnType = TxnType.None;
		return opoConCtx;
	}

	public int AuthenticateUser()
	{
		lock (pool.m_passwordSyncObj)
		{
			bool flag = false;
			bool flag2 = false;
			if (pool.m_encryptedPwd == null)
			{
				flag = ((opoConRefCtx.password == "") ? true : false);
			}
			else if (opoConRefCtx.password == pool.m_encryptedPwd.Password)
			{
				flag = true;
			}
			else
			{
				if (opoConRefCtx.password == "")
				{
					return 1005;
				}
				flag = false;
			}
			flag2 = ((pool.m_encryptedPxyPwd != null) ? ((opoConRefCtx.proxyPassword == pool.m_encryptedPxyPwd.Password) ? true : false) : ((opoConRefCtx.proxyPassword == "") ? true : false));
			if (flag && flag2)
			{
				return 0;
			}
			return 1017;
		}
	}
}

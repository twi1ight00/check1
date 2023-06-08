using System;
using System.Collections;

namespace Oracle.DataAccess.Client;

internal class PooledConCtx
{
	public IntPtr opsConCtx;

	public IntPtr opsErrCtx;

	public unsafe OpoConValCtx* pOpoConValCtx;

	public OpoConRefCtx opoConRefCtx;

	public string conString;

	public DateTime creationTime;

	public ConPooler m_conPooler;

	public ConPooler m_udtDescPoolerByName;

	public ConPooler m_udtDescPoolerByTDO;

	public string m_txnid;

	internal Hashtable m_statementData;

	internal int m_totalDataAvailable;

	public PromotableTxnMgr m_promotableTxnManager;

	public FetchArrayPooler m_fetchArrayPooler;
}

using System;
using System.Collections;
using System.Transactions;

namespace Oracle.DataAccess.Client;

internal class OracleResourceHolder : IDisposable
{
	internal string m_txnLocalId;

	internal Stack m_stack = new Stack();

	internal object m_resourceWithLocalTxn;

	private OracleResourcePool m_oraResPool;

	internal bool m_disposed;

	public OracleResourceHolder(string txnLocalId, OracleResourcePool oraResPool)
	{
		m_txnLocalId = txnLocalId;
		m_oraResPool = oraResPool;
	}

	internal void TransactionCompleted(object sender, TransactionEventArgs e)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(2u, " (POOL) OracleResourceHolder::TransactionCompleted(), Local Identifier = {0}\n", m_txnLocalId);
		}
		if (!m_disposed)
		{
			Dispose();
		}
	}

	public void Dispose()
	{
		if (!m_disposed)
		{
			GC.SuppressFinalize(this);
			m_disposed = true;
			if (m_oraResPool != null)
			{
				m_oraResPool.RemoveResourceHolder(this);
			}
			m_oraResPool = null;
			m_txnLocalId = null;
		}
	}
}

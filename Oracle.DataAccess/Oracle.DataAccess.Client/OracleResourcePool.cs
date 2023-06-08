using System;
using System.Collections;
using System.Transactions;

namespace Oracle.DataAccess.Client;

internal class OracleResourcePool
{
	internal delegate void TransactionEndDelegate(object resource);

	private Hashtable m_resHolders;

	internal TransactionEndDelegate m_transactionEndDelegate;

	internal static object m_orhLock = new object();

	internal OracleResourcePool(TransactionEndDelegate deleg)
	{
		m_resHolders = Hashtable.Synchronized(new Hashtable());
		m_transactionEndDelegate = deleg;
	}

	internal object GetResource(string txnLocalId)
	{
		object result = null;
		try
		{
			if (!(m_resHolders[txnLocalId] is OracleResourceHolder oracleResourceHolder))
			{
				return null;
			}
			if (!oracleResourceHolder.m_disposed)
			{
				lock (oracleResourceHolder)
				{
					if (!oracleResourceHolder.m_disposed && oracleResourceHolder.m_stack.Count > 0)
					{
						result = oracleResourceHolder.m_stack.Pop();
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(2u, " (ERROR) OracleResourcePool::GetResource(), Exception = {0}\n", ex.Message);
			}
			return null;
		}
		return result;
	}

	public bool PutResource(Transaction txn, object resource)
	{
		OracleResourceHolder orh = null;
		bool orhWasCreatedHere = false;
		try
		{
			GetResourceHolder(txn, ref orh, ref orhWasCreatedHere);
			lock (orh)
			{
				if (orh.m_disposed)
				{
					m_transactionEndDelegate(resource);
					return false;
				}
				orh.m_stack.Push(resource);
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(2u, " (ERROR) OracleResourcePool::PutResource(), Exception = {0}\n", ex.Message);
			}
			if (orh != null && orhWasCreatedHere)
			{
				orh.Dispose();
			}
			else
			{
				m_transactionEndDelegate(resource);
			}
			return false;
		}
		return true;
	}

	public void CacheResourceWithLocalTxn(Transaction txn, object resource)
	{
		OracleResourceHolder orh = null;
		bool orhWasCreatedHere = false;
		try
		{
			GetResourceHolder(txn, ref orh, ref orhWasCreatedHere);
			if (orh == null)
			{
				return;
			}
			lock (orh)
			{
				if (!orh.m_disposed)
				{
					orh.m_resourceWithLocalTxn = resource;
				}
				else
				{
					m_transactionEndDelegate(resource);
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(2u, " (ERROR) OracleResourcePool::CacheResourceWithLocalTxn(), Exception = {0}\n", ex.Message);
			}
			if (orh != null && orhWasCreatedHere)
			{
				orh.Dispose();
			}
			else
			{
				m_transactionEndDelegate(resource);
			}
		}
	}

	private void GetResourceHolder(Transaction txn, ref OracleResourceHolder orh, ref bool orhWasCreatedHere)
	{
		string localIdentifier = txn.TransactionInformation.LocalIdentifier;
		orh = m_resHolders[localIdentifier] as OracleResourceHolder;
		if (orh != null)
		{
			return;
		}
		lock (m_orhLock)
		{
			orh = m_resHolders[localIdentifier] as OracleResourceHolder;
			if (orh == null)
			{
				orh = new OracleResourceHolder(localIdentifier, this);
				orhWasCreatedHere = true;
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(2u, " (POOL) OracleResourcePool::PutResource(), Registering TransactionCompleted for LID = {0}\n", localIdentifier);
				}
				txn.TransactionCompleted += orh.TransactionCompleted;
				m_resHolders[localIdentifier] = orh;
			}
		}
	}

	internal void RemoveResourceHolder(OracleResourceHolder resHolder)
	{
		try
		{
			lock (resHolder)
			{
				if (resHolder.m_resourceWithLocalTxn != null)
				{
					m_transactionEndDelegate(resHolder.m_resourceWithLocalTxn);
				}
				int num = resHolder.m_stack.Count;
				while (num != 0)
				{
					num--;
					m_transactionEndDelegate(resHolder.m_stack.Pop());
				}
			}
			m_resHolders.Remove(resHolder.m_txnLocalId);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(2u, " (ERROR) OracleResourcePool::RemoveResourceHolder(), Exception = {0}\n", ex.Message);
			}
		}
	}
}

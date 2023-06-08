using System;
using System.Runtime.InteropServices;
using System.Transactions;

namespace Oracle.DataAccess.Client;

internal class PromotableTxnMgr : IPromotableSinglePhaseNotification, ITransactionPromoter
{
	internal IntPtr m_opsConCtx;

	internal IntPtr m_opsErrCtx;

	internal OpoConRefCtx m_opoConRefCtx;

	internal unsafe OpoConValCtx* m_pOpoConValCtx;

	internal OracleTransaction m_oraTransaction;

	internal bool m_bLocalTxnPromoted;

	internal string m_localTxnIdentifier;

	unsafe ~PromotableTxnMgr()
	{
		try
		{
			if (null == m_pOpoConValCtx)
			{
				return;
			}
			try
			{
				OpsCon.FreeValCtx(ref m_pOpoConValCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
		}
		catch
		{
		}
	}

	internal PromotableTxnMgr()
	{
	}

	public void Initialize()
	{
	}

	public unsafe void CommitTransaction()
	{
		try
		{
			if (string.IsNullOrEmpty(m_localTxnIdentifier))
			{
				return;
			}
			if (!m_bLocalTxnPromoted)
			{
				if (m_oraTransaction == null)
				{
					return;
				}
				try
				{
					OpsTxn.Commit(m_opsConCtx, m_opsErrCtx, null);
					return;
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
			try
			{
				OpsCon.CommitPromotedTxn(m_opsConCtx, m_pOpoConValCtx);
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
		finally
		{
			CloseNonPooledConnection();
			if (m_oraTransaction != null)
			{
				m_oraTransaction.Completed = true;
				m_oraTransaction.Dispose();
				m_oraTransaction = null;
			}
			string localTxnIdentifier = m_localTxnIdentifier;
			if (!string.IsNullOrEmpty(localTxnIdentifier))
			{
				OracleConnection.m_pspePrimaryResourceEntry.Remove(localTxnIdentifier);
				m_localTxnIdentifier = null;
			}
		}
	}

	public void SinglePhaseCommit(SinglePhaseEnlistment spe)
	{
		try
		{
			CommitTransaction();
		}
		finally
		{
			spe.Committed();
		}
	}

	internal unsafe void RollbackTransaction()
	{
		try
		{
			if (string.IsNullOrEmpty(m_localTxnIdentifier))
			{
				return;
			}
			if (!m_bLocalTxnPromoted)
			{
				if (m_oraTransaction == null)
				{
					return;
				}
				try
				{
					OpsTxn.Rollback(m_opsConCtx, m_opsErrCtx, null);
					return;
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
			try
			{
				OpsCon.AbortPromotedTxn(m_opsConCtx, m_pOpoConValCtx);
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
		finally
		{
			CloseNonPooledConnection();
			if (m_oraTransaction != null)
			{
				m_oraTransaction.Completed = true;
				m_oraTransaction.Dispose();
				m_oraTransaction = null;
			}
			string localTxnIdentifier = m_localTxnIdentifier;
			if (!string.IsNullOrEmpty(localTxnIdentifier))
			{
				OracleConnection.m_pspePrimaryResourceEntry.Remove(localTxnIdentifier);
				m_localTxnIdentifier = null;
			}
		}
	}

	private unsafe void CloseNonPooledConnection()
	{
		try
		{
			if (string.IsNullOrEmpty(m_localTxnIdentifier))
			{
				return;
			}
			object obj = ConnectionDispenser.m_pspePrimaryResources[m_localTxnIdentifier];
			if (obj == null)
			{
				return;
			}
			ConnectionDispenser.m_pspePrimaryResources.Remove(m_localTxnIdentifier);
			OpoConCtx opoConCtx = obj as OpoConCtx;
			opoConCtx.m_txnType = TxnType.None;
			if (m_bLocalTxnPromoted)
			{
				try
				{
					OpsCon.DelistPromotedTxn(opoConCtx.opsConCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			ConnectionDispenser.Close(ref opoConCtx, isContextConnection: false);
			if (null == opoConCtx.pOpoConValCtx)
			{
				return;
			}
			try
			{
				OpsCon.FreeValCtx(ref opoConCtx.pOpoConValCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void Rollback(SinglePhaseEnlistment spe)
	{
		try
		{
			RollbackTransaction();
		}
		finally
		{
			spe.Aborted();
		}
	}

	public unsafe byte[] Promote()
	{
		int num = 0;
		byte[] array = null;
		try
		{
			num = OpsCon.Promote(m_opsConCtx, m_pOpoConValCtx, m_opoConRefCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
		}
		if (num == 0 && ErrRes.INT_ERR != num && m_pOpoConValCtx->token_size > 0)
		{
			array = new byte[m_pOpoConValCtx->token_size];
			Marshal.Copy(m_pOpoConValCtx->token, array, 0, m_pOpoConValCtx->token_size);
			m_bLocalTxnPromoted = true;
		}
		return array;
	}
}

using System.Threading;

namespace Oracle.DataAccess.Client;

internal class Counter
{
	public int total;

	public int potentialTotal;

	public int threadWait;

	public int totalAvailable;

	public bool bOwnedByCPCtx;

	public Counter(bool bOwnedByCPCtx)
	{
		this.bOwnedByCPCtx = bOwnedByCPCtx;
	}

	public void UpdateTotalCount(ConnectionPool conPool, int val, bool bForPotential)
	{
		lock (this)
		{
			total += val;
			if (bForPotential)
			{
				UpdatePotentialTotalCount(val);
			}
			if (OraTrace.m_TraceLevel != 0 && !bOwnedByCPCtx)
			{
				if (conPool.m_cpCtx != null)
				{
					OraTrace.Trace(2u, " (POOL)  Num of cons in (CP id: " + conPool.m_cpCtx.GetHashCode() + ", Inst CP id: " + conPool.GetHashCode() + ") : (" + conPool.m_cpCtx.m_counter.total + ", " + total + ")\n");
				}
				else
				{
					OraTrace.Trace(2u, " (POOL)  Total number of connections for pool (id: " + conPool.m_clonedCtx.conString.GetHashCode() + ") : " + total.ToString() + "\n");
				}
			}
		}
	}

	public void UpdatePotentialTotalCount(int val)
	{
		lock (this)
		{
			potentialTotal += val;
		}
	}

	public void UpdateThreadWaitCount(ConnectionPool conPool, int val)
	{
		bool flag = false;
		int num = 0;
		lock (this)
		{
			threadWait += val;
			if (!conPool.m_bGridRac)
			{
				if (val > 0 && potentialTotal < conPool.m_clonedCtx.maxPoolSize && potentialTotal <= total + threadWait && totalAvailable <= 0)
				{
					int num2 = 0;
					if (conPool.m_clonedCtx.minPoolSize > conPool.m_counter.potentialTotal)
					{
						num2 = conPool.m_clonedCtx.minPoolSize - conPool.m_counter.potentialTotal;
					}
					num = ((potentialTotal + conPool.m_clonedCtx.poolIncSize <= conPool.m_clonedCtx.maxPoolSize) ? conPool.m_clonedCtx.poolIncSize : (conPool.m_clonedCtx.maxPoolSize - potentialTotal));
					if (num2 > num)
					{
						num = num2;
					}
					UpdatePotentialTotalCount(num);
					if (num > 0)
					{
						flag = true;
					}
				}
				if (val > 0)
				{
					Interlocked.Decrement(ref totalAvailable);
				}
			}
			else if (conPool.m_cpCtx != null)
			{
				if (val > 0 && conPool.m_cpCtx.m_counter.potentialTotal < conPool.m_clonedCtx.maxPoolSize && conPool.m_cpCtx.m_counter.potentialTotal <= conPool.m_cpCtx.m_counter.total + conPool.m_cpCtx.m_counter.threadWait && conPool.m_cpCtx.totalAvaliableConnections <= 0)
				{
					int num3 = 0;
					if (conPool.m_clonedCtx.minPoolSize > conPool.m_cpCtx.m_counter.potentialTotal)
					{
						num3 = conPool.m_clonedCtx.minPoolSize - conPool.m_cpCtx.m_counter.potentialTotal;
					}
					num = ((conPool.m_cpCtx.m_counter.potentialTotal + conPool.m_clonedCtx.poolIncSize <= conPool.m_clonedCtx.maxPoolSize) ? conPool.m_clonedCtx.poolIncSize : (conPool.m_clonedCtx.maxPoolSize - conPool.m_cpCtx.m_counter.potentialTotal));
					if (num3 > num)
					{
						num = num3;
					}
					conPool.UpdatePotentialTotalCount(num);
					if (num > 0)
					{
						flag = true;
					}
				}
				if (val > 0 && bOwnedByCPCtx)
				{
					Interlocked.Decrement(ref conPool.m_cpCtx.totalAvaliableConnections);
					Interlocked.Decrement(ref conPool.m_counter.totalAvailable);
				}
			}
		}
		if (flag)
		{
			ThreadPool.QueueUserWorkItem(conPool.PopulatePool, num);
		}
	}
}

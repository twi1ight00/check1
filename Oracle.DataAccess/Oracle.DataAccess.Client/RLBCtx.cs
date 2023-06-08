using System.Collections;
using System.Text;

namespace Oracle.DataAccess.Client;

internal class RLBCtx
{
	private string m_ServiceName;

	private Hashtable m_htConToInst;

	private ArrayList m_RLBMetricsList;

	private string m_timeStamp;

	private bool m_bNeedNormalization;

	public string ServiceName
	{
		get
		{
			return m_ServiceName;
		}
		set
		{
			m_ServiceName = value;
		}
	}

	public Hashtable htConToInst
	{
		get
		{
			return m_htConToInst;
		}
		set
		{
			m_htConToInst = value;
		}
	}

	public ArrayList RLBMetricsList
	{
		get
		{
			return m_RLBMetricsList;
		}
		set
		{
			m_RLBMetricsList = value;
		}
	}

	public string timeStamp
	{
		get
		{
			return m_timeStamp;
		}
		set
		{
			m_timeStamp = value;
		}
	}

	public bool bNeedNormalization
	{
		get
		{
			return m_bNeedNormalization;
		}
		set
		{
			m_bNeedNormalization = value;
		}
	}

	public RLBCtx(string serviceName)
	{
		m_htConToInst = Hashtable.Synchronized(new Hashtable());
		m_ServiceName = serviceName;
	}

	public void NormalizeCounters(RLBCtx rlbCtx, CPCtx cpCtx)
	{
		if (cpCtx == null)
		{
			return;
		}
		for (int i = 0; i < rlbCtx.RLBMetricsList.Count; i++)
		{
			ConnectionPool connectionPool = (ConnectionPool)cpCtx.htInstToCp[((RLBMetrics)rlbCtx.RLBMetricsList[i]).InstanceName];
			if (connectionPool != null)
			{
				int num = 1;
				if (connectionPool.m_counter.total > connectionPool.m_connections.Count)
				{
					num = connectionPool.m_counter.total - connectionPool.m_connections.Count;
				}
				if (num < 1)
				{
					num = 1;
				}
				if (num * ((RLBMetrics)rlbCtx.RLBMetricsList[i]).MaxDistribFreq < 0 || num * ((RLBMetrics)rlbCtx.RLBMetricsList[i]).MaxDistribFreq >= 1073741822)
				{
					((RLBMetrics)rlbCtx.RLBMetricsList[i]).CurDistribFreq = 1073741822;
				}
				else
				{
					((RLBMetrics)rlbCtx.RLBMetricsList[i]).CurDistribFreq = num * ((RLBMetrics)rlbCtx.RLBMetricsList[i]).MaxDistribFreq;
				}
			}
		}
		rlbCtx.bNeedNormalization = false;
		if ((OraTrace.m_TraceLevel & 0x20) != 32)
		{
			return;
		}
		int num2 = 0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(" (GRID) (RLB) (NORMALIZE) ");
		ConnectionPool connectionPool2 = null;
		for (num2 = 0; num2 < rlbCtx.RLBMetricsList.Count; num2++)
		{
			stringBuilder.Append("(");
			stringBuilder.Append(((RLBMetrics)rlbCtx.RLBMetricsList[num2]).InstanceName);
			connectionPool2 = (ConnectionPool)cpCtx.htInstToCp[((RLBMetrics)rlbCtx.RLBMetricsList[num2]).InstanceName];
			if (connectionPool2 != null)
			{
				stringBuilder.Append(": used=");
				stringBuilder.Append(connectionPool2.m_counter.total - connectionPool2.m_connections.Count);
				stringBuilder.Append("; idle=");
				stringBuilder.Append(connectionPool2.m_connections.Count);
				stringBuilder.Append("; tot=");
				stringBuilder.Append(connectionPool2.m_counter.total);
			}
			else
			{
				stringBuilder.Append(": N/A");
			}
			stringBuilder.Append("; counter=");
			stringBuilder.Append(((RLBMetrics)rlbCtx.RLBMetricsList[num2]).CurDistribFreq);
			stringBuilder.Append("/");
			stringBuilder.Append(((RLBMetrics)rlbCtx.RLBMetricsList[num2]).MaxDistribFreq);
			stringBuilder.Append(") ");
		}
		stringBuilder.Append(")\n");
		OraTrace.Trace(32u, stringBuilder.ToString());
	}
}

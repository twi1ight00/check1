namespace Oracle.DataAccess.Client;

internal class RLBMetrics
{
	private string m_InstanceName;

	private int m_CurDistribFreq;

	private int m_MaxDistribFreq;

	private int m_StdDevViolation;

	private double m_Percentage;

	private RLBMetricsFlag m_Flag;

	public string InstanceName => m_InstanceName;

	public RLBMetricsFlag Flag => m_Flag;

	public int CurDistribFreq
	{
		get
		{
			return m_CurDistribFreq;
		}
		set
		{
			m_CurDistribFreq = value;
		}
	}

	public int MaxDistribFreq
	{
		get
		{
			return m_MaxDistribFreq;
		}
		set
		{
			m_MaxDistribFreq = value;
		}
	}

	public int StdDevViolation
	{
		get
		{
			return m_StdDevViolation;
		}
		set
		{
			m_StdDevViolation = value;
		}
	}

	public double Percentage
	{
		get
		{
			return m_Percentage;
		}
		set
		{
			m_Percentage = value;
		}
	}

	public RLBMetrics(string instanceName, double precentage, int frequency, RLBMetricsFlag flag)
	{
		m_InstanceName = instanceName;
		m_Percentage = precentage;
		m_CurDistribFreq = (m_MaxDistribFreq = frequency);
		m_Flag = flag;
	}
}

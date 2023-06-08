using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleAQDequeueOptions : ICloneable
{
	internal OracleAQDequeueMode m_dequeueMode = OracleAQDequeueMode.Remove;

	internal OracleAQNavigationMode m_navigationMode = OracleAQNavigationMode.NextMessage;

	internal OracleAQVisibilityMode m_visibility = OracleAQVisibilityMode.OnCommit;

	internal int m_wait = -1;

	internal OracleAQMessageDeliveryMode m_deliveryMode = OracleAQMessageDeliveryMode.Persistent;

	internal string m_consumerName;

	internal byte[] m_messageId;

	internal string m_correlation;

	internal bool m_providerSpecificType;

	public OracleAQDequeueMode DequeueMode
	{
		get
		{
			return m_dequeueMode;
		}
		set
		{
			if (value != OracleAQDequeueMode.Browse && value != OracleAQDequeueMode.Locked && value != OracleAQDequeueMode.Remove && value != OracleAQDequeueMode.RemoveNoData)
			{
				throw new ArgumentOutOfRangeException("DequeueMode");
			}
			if (value != m_dequeueMode)
			{
				m_dequeueMode = value;
			}
		}
	}

	public OracleAQNavigationMode NavigationMode
	{
		get
		{
			return m_navigationMode;
		}
		set
		{
			if (value != OracleAQNavigationMode.FirstMessage && value != OracleAQNavigationMode.NextMessage && value != OracleAQNavigationMode.NextTransaction && value != OracleAQNavigationMode.FirstMessageMultiGroup && value != OracleAQNavigationMode.NextMessageMultiGroup)
			{
				throw new ArgumentOutOfRangeException("NavigationMode");
			}
			if (value != m_navigationMode)
			{
				m_navigationMode = value;
			}
		}
	}

	public OracleAQMessageDeliveryMode DeliveryMode
	{
		get
		{
			return m_deliveryMode;
		}
		set
		{
			if (value != OracleAQMessageDeliveryMode.Buffered && value != OracleAQMessageDeliveryMode.Persistent && value != OracleAQMessageDeliveryMode.PersistentOrBuffered)
			{
				throw new ArgumentOutOfRangeException("DeliveryMode");
			}
			if (value != m_deliveryMode)
			{
				m_deliveryMode = value;
			}
		}
	}

	public OracleAQVisibilityMode Visibility
	{
		get
		{
			return m_visibility;
		}
		set
		{
			if (value != OracleAQVisibilityMode.Immediate && value != OracleAQVisibilityMode.OnCommit)
			{
				throw new ArgumentOutOfRangeException("Visibility");
			}
			if (value != m_visibility)
			{
				m_visibility = value;
			}
		}
	}

	public int Wait
	{
		get
		{
			return m_wait;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentOutOfRangeException("Wait");
			}
			if (value != m_wait)
			{
				m_wait = value;
			}
		}
	}

	public byte[] MessageId
	{
		get
		{
			return m_messageId;
		}
		set
		{
			if (value != m_messageId)
			{
				m_messageId = value;
			}
		}
	}

	public string Correlation
	{
		get
		{
			return m_correlation;
		}
		set
		{
			if (value != m_correlation)
			{
				m_correlation = value;
			}
		}
	}

	public string ConsumerName
	{
		get
		{
			return m_consumerName;
		}
		set
		{
			if (value != m_consumerName)
			{
				m_consumerName = value;
			}
		}
	}

	public bool ProviderSpecificType
	{
		get
		{
			return m_providerSpecificType;
		}
		set
		{
			m_providerSpecificType = value;
		}
	}

	static OracleAQDequeueOptions()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public object Clone()
	{
		OracleAQDequeueOptions oracleAQDequeueOptions = new OracleAQDequeueOptions();
		oracleAQDequeueOptions.m_consumerName = m_consumerName;
		oracleAQDequeueOptions.m_correlation = m_correlation;
		oracleAQDequeueOptions.m_deliveryMode = m_deliveryMode;
		oracleAQDequeueOptions.m_dequeueMode = m_dequeueMode;
		oracleAQDequeueOptions.m_messageId = m_messageId;
		oracleAQDequeueOptions.m_navigationMode = m_navigationMode;
		oracleAQDequeueOptions.m_visibility = m_visibility;
		oracleAQDequeueOptions.m_wait = m_wait;
		return oracleAQDequeueOptions;
	}
}

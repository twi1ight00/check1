using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleAQEnqueueOptions : ICloneable
{
	internal OracleAQVisibilityMode m_visibility = OracleAQVisibilityMode.OnCommit;

	internal OracleAQMessageDeliveryMode m_deliveryMode = OracleAQMessageDeliveryMode.Persistent;

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

	public OracleAQMessageDeliveryMode DeliveryMode
	{
		get
		{
			return m_deliveryMode;
		}
		set
		{
			if (value != OracleAQMessageDeliveryMode.Buffered && value != OracleAQMessageDeliveryMode.Persistent)
			{
				throw new ArgumentOutOfRangeException("DeliveryMode");
			}
			if (value != m_deliveryMode)
			{
				m_deliveryMode = value;
			}
		}
	}

	static OracleAQEnqueueOptions()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public object Clone()
	{
		OracleAQEnqueueOptions oracleAQEnqueueOptions = new OracleAQEnqueueOptions();
		oracleAQEnqueueOptions.m_deliveryMode = m_deliveryMode;
		oracleAQEnqueueOptions.m_visibility = m_visibility;
		return oracleAQEnqueueOptions;
	}
}

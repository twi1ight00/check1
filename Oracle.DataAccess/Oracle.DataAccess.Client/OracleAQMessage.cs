using System;
using System.Xml;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

public sealed class OracleAQMessage
{
	internal object m_payload;

	internal OracleAQMessageDeliveryMode m_deliveryMode = OracleAQMessageDeliveryMode.Persistent;

	internal int m_deqAttempts;

	internal string m_correlation;

	internal string m_exceptionQueue;

	internal int m_expiration = -1;

	internal int m_delay;

	internal OracleAQAgent[] m_recipients;

	internal OracleAQAgent m_senderId;

	internal string m_transactionGroup;

	internal byte[] m_messageId;

	internal DateTime m_enqueueTime;

	internal OracleAQMessageState m_state;

	internal int m_priority;

	internal byte[] m_originalMessageId;

	internal bool m_msgPropsModified;

	public int DequeueAttempts => m_deqAttempts;

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
				m_msgPropsModified = true;
				m_correlation = value;
			}
		}
	}

	public byte[] OriginalMessageId => m_originalMessageId;

	public OracleAQMessageDeliveryMode DeliveryMode => m_deliveryMode;

	public int Delay
	{
		get
		{
			return m_delay;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Delay");
			}
			if (value != m_delay)
			{
				m_msgPropsModified = true;
				m_delay = value;
			}
		}
	}

	public string ExceptionQueue
	{
		get
		{
			return m_exceptionQueue;
		}
		set
		{
			if (value != m_exceptionQueue)
			{
				m_msgPropsModified = true;
				m_exceptionQueue = value;
			}
		}
	}

	public int Expiration
	{
		get
		{
			return m_expiration;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentOutOfRangeException("Expiration");
			}
			if (value != m_expiration)
			{
				m_msgPropsModified = true;
				m_expiration = value;
			}
		}
	}

	public int Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			if (value != m_priority)
			{
				m_msgPropsModified = true;
				m_priority = value;
			}
		}
	}

	public OracleAQAgent[] Recipients
	{
		get
		{
			return m_recipients;
		}
		set
		{
			if (value != m_recipients)
			{
				m_msgPropsModified = true;
				m_recipients = value;
			}
		}
	}

	public string TransactionGroup => m_transactionGroup;

	public byte[] MessageId => m_messageId;

	public DateTime EnqueueTime => m_enqueueTime;

	public OracleAQMessageState State => m_state;

	public object Payload
	{
		get
		{
			return m_payload;
		}
		set
		{
			if (value is OracleXmlType || value is XmlReader || value is string || value is byte[] || value is OracleBinary || value is IOracleCustomType || value == null)
			{
				m_payload = value;
				return;
			}
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Payload"));
		}
	}

	public OracleAQAgent SenderId
	{
		get
		{
			return m_senderId;
		}
		set
		{
			m_msgPropsModified = true;
			m_senderId = value;
		}
	}

	static OracleAQMessage()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleAQMessage()
	{
	}

	public OracleAQMessage(object payload)
		: this()
	{
		if (payload is OracleXmlType || payload is XmlReader || payload is string || payload is byte[] || payload is OracleBinary || payload is IOracleCustomType || payload == null)
		{
			m_payload = payload;
			return;
		}
		throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "payload"));
	}
}

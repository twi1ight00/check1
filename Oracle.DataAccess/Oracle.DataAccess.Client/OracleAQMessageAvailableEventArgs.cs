using System;

namespace Oracle.DataAccess.Client;

public class OracleAQMessageAvailableEventArgs
{
	internal string m_queueName;

	internal string m_consumerName;

	internal byte[][] m_messageId;

	internal string m_correlation;

	internal int m_delay;

	internal string m_exceptionQueue;

	internal int m_expiration;

	internal int m_priority;

	internal DateTime m_enqueueTime;

	internal OracleAQMessageState m_state;

	internal OracleAQMessageDeliveryMode m_deliveryMode;

	internal OracleAQAgent m_senderId;

	internal byte[] m_originalMessageId;

	internal OracleAQNotificationType m_notificationType;

	internal int m_availableMessages;

	public string QueueName => m_queueName;

	public string ConsumerName => m_consumerName;

	public byte[][] MessageId => m_messageId;

	public string Correlation => m_correlation;

	public int Delay => m_delay;

	public string ExceptionQueue => m_exceptionQueue;

	public int Expiration => m_expiration;

	public int Priority => m_priority;

	public DateTime EnqueueTime => m_enqueueTime;

	public OracleAQMessageState State => m_state;

	public OracleAQMessageDeliveryMode DeliveryMode => m_deliveryMode;

	public OracleAQAgent SenderId => m_senderId;

	public byte[] OriginalMessageId => m_originalMessageId;

	public OracleAQNotificationType NotificationType => m_notificationType;

	public int AvailableMessages => m_availableMessages;
}

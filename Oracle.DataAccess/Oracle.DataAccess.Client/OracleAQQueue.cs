using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

public class OracleAQQueue : IDisposable
{
	internal class EventWrapper
	{
		public int InvocationListLength
		{
			get
			{
				if (this.OnMessageAvailable != null)
				{
					return this.OnMessageAvailable.GetInvocationList().Length;
				}
				return 0;
			}
		}

		internal event OracleAQMessageAvailableEventHandler OnMessageAvailable;

		internal void FireEvent(object sender, OracleAQMessageAvailableEventArgs e)
		{
			if (this.OnMessageAvailable != null)
			{
				this.OnMessageAvailable(sender, e);
			}
		}
	}

	internal class NtfnInfo
	{
		internal EventWrapper m_eventWrapper;

		internal string m_queueName;

		internal string m_consumerName;

		internal bool m_isNotifiedOnce;
	}

	private const int LISTENFOREVER = -1;

	internal OracleConnection m_connection;

	internal IntPtr m_opsConCtx;

	internal IntPtr m_opsErrCtx;

	internal int m_conSignature;

	private IntPtr m_OCIAQEnqOptions = IntPtr.Zero;

	private IntPtr m_OCIAQDeqOptions = IntPtr.Zero;

	private IntPtr m_OCIAQMsgProperties = IntPtr.Zero;

	private bool m_disposed;

	protected string m_name;

	private string m_udtTypeName;

	private OracleAQMessageType m_messageType = OracleAQMessageType.Raw;

	private OracleAQEnqueueOptions m_aqEnqOptions = new OracleAQEnqueueOptions();

	private OracleAQDequeueOptions m_aqDeqOptions = new OracleAQDequeueOptions();

	private int m_enqOptsInfo = 65535;

	private int m_deqOptsInfo = 65535;

	internal unsafe OpoAQEnqOptionsValCtx* m_pOpoAQEnqOptionsValCtx;

	internal unsafe OpoAQDeqOptionsValCtx* m_pOpoAQDeqOptionsValCtx;

	internal OpoAQDeqOptionsRefCtx m_opoAQDeqOptionsRefCtx;

	private unsafe OpoAQMsgPropsValCtx* m_pOpoAQMsgPropsValCtx;

	private OpoAQMsgPropsRefCtx m_opoAQMsgPropsRefCtx;

	private unsafe OpoAQMsgValCtx* m_pOpoAQMsgValCtx;

	internal EventWrapper m_eventWrapper = new EventWrapper();

	private NtfnInfo[] m_ntfnInfo;

	private static OnAQNTFNCallback s_onAQNTFNOpsCallback;

	private object m_lockObj = new object();

	private OracleNotificationRequest m_NTFNReq;

	private static Hashtable m_subscriptionMap;

	private IntPtr[] m_pCtxNTFN;

	private IntPtr[] m_pOCISubscription;

	private string[] m_subscriptionName;

	private string[] m_notificationConsumers;

	private bool m_isConSet;

	public OracleConnection Connection
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_connection;
		}
		set
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			m_connection = value;
		}
	}

	public string Name
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_name;
		}
	}

	public string UdtTypeName
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_udtTypeName;
		}
		set
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			m_udtTypeName = value;
		}
	}

	public string[] NotificationConsumers
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_notificationConsumers;
		}
		set
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (m_eventWrapper.InvocationListLength != 0)
			{
				throw new InvalidOperationException();
			}
			m_notificationConsumers = value;
		}
	}

	public OracleAQMessageType MessageType
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_messageType;
		}
		set
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (value != OracleAQMessageType.Raw && value != OracleAQMessageType.Udt && value != OracleAQMessageType.Xml)
			{
				throw new ArgumentOutOfRangeException("MessageType");
			}
			m_messageType = value;
		}
	}

	public OracleAQEnqueueOptions EnqueueOptions
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_aqEnqOptions;
		}
		set
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			m_aqEnqOptions = value;
		}
	}

	public OracleAQDequeueOptions DequeueOptions
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return m_aqDeqOptions;
		}
		set
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			m_aqDeqOptions = value;
		}
	}

	public OracleNotificationRequest Notification
	{
		get
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (m_NTFNReq == null)
			{
				m_NTFNReq = new OracleNotificationRequest(isNotifiedOnce: false, 0L, isPersistent: false, groupingNotificationEnabled: false, OracleAQNotificationGroupingType.Summary, 600);
			}
			return m_NTFNReq;
		}
	}

	public event OracleAQMessageAvailableEventHandler MessageAvailable
	{
		add
		{
			lock (m_lockObj)
			{
				m_eventWrapper.OnMessageAvailable += value;
				if (m_eventWrapper.InvocationListLength == 1)
				{
					SubscriptionRegister();
				}
			}
		}
		remove
		{
			m_eventWrapper.OnMessageAvailable -= value;
			if (m_eventWrapper.InvocationListLength == 0)
			{
				SubscriptionUnRegister();
			}
		}
	}

	unsafe static OracleAQQueue()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		m_subscriptionMap = Hashtable.Synchronized(new Hashtable());
		s_onAQNTFNOpsCallback = OnAQNTFNOpsCallback_fn;
		OpsAQ.RegisterNotificationCallback(s_onAQNTFNOpsCallback);
	}

	public OracleAQQueue(string name)
		: this(name, null, OracleAQMessageType.Raw, null, checkConnReference: false)
	{
	}

	public OracleAQQueue(string name, OracleConnection con)
		: this(name, con, OracleAQMessageType.Raw)
	{
	}

	public OracleAQQueue(string name, OracleConnection con, OracleAQMessageType messageType)
		: this(name, con, messageType, null)
	{
	}

	public OracleAQQueue(string name, OracleConnection con, OracleAQMessageType messageType, string udtTypeName)
		: this(name, con, messageType, udtTypeName, checkConnReference: true)
	{
	}

	private OracleAQQueue(string name, OracleConnection con, OracleAQMessageType messageType, string udtTypeName, bool checkConnReference)
	{
		if (con == null && checkConnReference)
		{
			throw new ArgumentNullException("con");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "name"));
		}
		if (messageType != OracleAQMessageType.Raw && messageType != OracleAQMessageType.Udt && messageType != OracleAQMessageType.Xml)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "messageType"));
		}
		m_name = name;
		m_connection = con;
		m_messageType = messageType;
		m_udtTypeName = udtTypeName;
		Init();
	}

	private void SetConnection(OracleConnection con)
	{
		if (m_isConSet && m_conSignature != m_connection.m_conSignature)
		{
			m_enqOptsInfo = 65535;
			m_deqOptsInfo = 65535;
			if (m_OCIAQEnqOptions != IntPtr.Zero || m_OCIAQDeqOptions != IntPtr.Zero || m_OCIAQMsgProperties != IntPtr.Zero)
			{
				try
				{
					OpsAQ.FreeCachedDesc(ref m_OCIAQEnqOptions, ref m_OCIAQDeqOptions, ref m_OCIAQMsgProperties);
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
			if (m_opsErrCtx != IntPtr.Zero)
			{
				try
				{
					OpsErr.FreeCtx(ref m_opsErrCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					throw;
				}
				m_opsErrCtx = IntPtr.Zero;
			}
			if (m_opsConCtx != IntPtr.Zero)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
					throw;
				}
			}
		}
		m_opsConCtx = con.m_opoConCtx.opsConCtx;
		int num = 0;
		try
		{
			num = OpsCon.AddRef(m_opsConCtx);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			m_opsConCtx = IntPtr.Zero;
			throw;
		}
		if (num <= 1)
		{
			m_opsConCtx = IntPtr.Zero;
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		try
		{
			OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
		}
		catch (Exception ex5)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex5);
			}
			throw;
		}
		m_conSignature = con.m_conSignature;
		m_isConSet = true;
	}

	private unsafe void Init()
	{
		m_opoAQMsgPropsRefCtx = new OpoAQMsgPropsRefCtx();
		int num = 0;
		try
		{
			num = OpsAQ.AllocValCtx(out m_pOpoAQMsgPropsValCtx, out m_pOpoAQMsgValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	internal unsafe static void OnAQNTFNOpsCallback_fn(IntPtr pSubscrhp, IntPtr pDesc, IntPtr ctx, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, OpoAQMsgValCtx* pOpoAQMsgValCtx)
	{
		int num = 0;
		OpoAQMsgPropsRefCtx opoAQMsgPropsRefCtx = new OpoAQMsgPropsRefCtx();
		OpoAQNtfnDataRefCtx opoAQNtfnDataRefCtx = new OpoAQNtfnDataRefCtx();
		OracleAQNotificationType flags = OracleAQNotificationType.Regular;
		int availableMsgs = 0;
		OpoAQMsgIdValCtx* pOpoAQMsgIdValCtx = null;
		int num_msgid = 0;
		string text = null;
		string text2 = null;
		OracleAQMessageAvailableEventArgs oracleAQMessageAvailableEventArgs = new OracleAQMessageAvailableEventArgs();
		if (!(m_subscriptionMap[ctx] is NtfnInfo ntfnInfo))
		{
			return;
		}
		lock (ntfnInfo)
		{
			if (!(m_subscriptionMap[ctx] is NtfnInfo))
			{
				return;
			}
			try
			{
				num = OpsAQ.ProcessNtfn(pSubscrhp, pDesc, ctx, pOpoAQMsgValCtx, pOpoAQMsgPropsValCtx, ref opoAQMsgPropsRefCtx, ref flags, ref availableMsgs, out pOpoAQMsgIdValCtx, ref num_msgid, ref opoAQNtfnDataRefCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				return;
			}
		}
		text = opoAQNtfnDataRefCtx.queueName;
		text2 = opoAQNtfnDataRefCtx.consumerName;
		if (flags == OracleAQNotificationType.Regular)
		{
			if (num == 0)
			{
				oracleAQMessageAvailableEventArgs.m_notificationType = OracleAQNotificationType.Regular;
				oracleAQMessageAvailableEventArgs.m_availableMessages = 1;
				oracleAQMessageAvailableEventArgs.m_queueName = text;
				oracleAQMessageAvailableEventArgs.m_consumerName = text2;
				oracleAQMessageAvailableEventArgs.m_deliveryMode = (OracleAQMessageDeliveryMode)pOpoAQMsgPropsValCtx->deliveryMode;
				oracleAQMessageAvailableEventArgs.m_messageId = new byte[1][];
				oracleAQMessageAvailableEventArgs.m_messageId[0] = new byte[pOpoAQMsgValCtx->msgIdLen];
				Marshal.Copy(pOpoAQMsgValCtx->pMsgId, oracleAQMessageAvailableEventArgs.m_messageId[0], 0, pOpoAQMsgValCtx->msgIdLen);
				oracleAQMessageAvailableEventArgs.m_correlation = opoAQMsgPropsRefCtx.correlationId;
				oracleAQMessageAvailableEventArgs.m_delay = pOpoAQMsgPropsValCtx->delay;
				oracleAQMessageAvailableEventArgs.m_exceptionQueue = opoAQMsgPropsRefCtx.exceptionQueue;
				oracleAQMessageAvailableEventArgs.m_expiration = pOpoAQMsgPropsValCtx->expiration;
				oracleAQMessageAvailableEventArgs.m_priority = pOpoAQMsgPropsValCtx->priority;
				oracleAQMessageAvailableEventArgs.m_enqueueTime = new DateTime(pOpoAQMsgPropsValCtx->year, pOpoAQMsgPropsValCtx->month, pOpoAQMsgPropsValCtx->day, pOpoAQMsgPropsValCtx->hour, pOpoAQMsgPropsValCtx->min, pOpoAQMsgPropsValCtx->sec);
				oracleAQMessageAvailableEventArgs.m_state = (OracleAQMessageState)pOpoAQMsgPropsValCtx->msgState;
				if (pOpoAQMsgPropsValCtx->origMsgIdLen > 0)
				{
					oracleAQMessageAvailableEventArgs.m_originalMessageId = new byte[pOpoAQMsgPropsValCtx->origMsgIdLen];
					Marshal.Copy(pOpoAQMsgPropsValCtx->pOrigMsgId, oracleAQMessageAvailableEventArgs.m_originalMessageId, 0, pOpoAQMsgPropsValCtx->origMsgIdLen);
				}
				if (opoAQMsgPropsRefCtx.senderId.name != null && opoAQMsgPropsRefCtx.senderId.address == null)
				{
					oracleAQMessageAvailableEventArgs.m_senderId = new OracleAQAgent(opoAQMsgPropsRefCtx.senderId.name);
				}
				else if (opoAQMsgPropsRefCtx.senderId.name != null && opoAQMsgPropsRefCtx.senderId.address != null)
				{
					oracleAQMessageAvailableEventArgs.m_senderId = new OracleAQAgent(opoAQMsgPropsRefCtx.senderId.name, opoAQMsgPropsRefCtx.senderId.address);
				}
			}
			opoAQMsgPropsRefCtx = null;
			opoAQNtfnDataRefCtx = null;
		}
		else if (OracleAQNotificationType.Timeout == flags)
		{
			oracleAQMessageAvailableEventArgs.m_notificationType = OracleAQNotificationType.Timeout;
			oracleAQMessageAvailableEventArgs.m_availableMessages = 0;
			if (text == null && ntfnInfo != null)
			{
				oracleAQMessageAvailableEventArgs.m_queueName = ntfnInfo.m_queueName;
			}
			else
			{
				oracleAQMessageAvailableEventArgs.m_queueName = text;
			}
			if (text2 == null && ntfnInfo != null)
			{
				oracleAQMessageAvailableEventArgs.m_consumerName = ntfnInfo.m_consumerName;
			}
			else
			{
				oracleAQMessageAvailableEventArgs.m_consumerName = text2;
			}
		}
		else if (OracleAQNotificationType.Group == flags)
		{
			oracleAQMessageAvailableEventArgs.m_availableMessages = availableMsgs;
			oracleAQMessageAvailableEventArgs.m_notificationType = OracleAQNotificationType.Group;
			if (text == null && ntfnInfo != null)
			{
				oracleAQMessageAvailableEventArgs.m_queueName = ntfnInfo.m_queueName;
			}
			else
			{
				oracleAQMessageAvailableEventArgs.m_queueName = text;
			}
			if (text2 == null && ntfnInfo != null)
			{
				oracleAQMessageAvailableEventArgs.m_consumerName = ntfnInfo.m_consumerName;
			}
			else
			{
				oracleAQMessageAvailableEventArgs.m_consumerName = text2;
			}
			oracleAQMessageAvailableEventArgs.m_messageId = new byte[num_msgid][];
			for (int i = 0; i < num_msgid; i++)
			{
				oracleAQMessageAvailableEventArgs.m_messageId[i] = new byte[pOpoAQMsgIdValCtx[i].msgIdLen];
				Marshal.Copy(pOpoAQMsgIdValCtx[i].pMsgId, oracleAQMessageAvailableEventArgs.m_messageId[i], 0, pOpoAQMsgIdValCtx[i].msgIdLen);
			}
			try
			{
				OpsAQ.FreeMsgIdValCtxArray(ref pOpoAQMsgIdValCtx);
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.Message);
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
		}
		if (num == 0)
		{
			EventWrapper eventWrapper = null;
			if (ntfnInfo != null)
			{
				eventWrapper = ntfnInfo.m_eventWrapper;
			}
			eventWrapper?.FireEvent(text, oracleAQMessageAvailableEventArgs);
		}
	}

	public void Enqueue(OracleAQMessage msg)
	{
		Enqueue(msg, m_aqEnqOptions);
	}

	public unsafe void Enqueue(OracleAQMessage msg, OracleAQEnqueueOptions aqEnqOptions)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::Enqueue()\n");
		}
		OracleXmlType oracleXmlType = null;
		int num = 0;
		if (msg == null)
		{
			throw new ArgumentNullException("msg");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (!m_isConSet || m_connection.m_conSignature != m_conSignature)
		{
			SetConnection(m_connection);
		}
		if (msg.Payload is OracleXmlType && ((OracleXmlType)msg.Payload).m_conSignature != m_conSignature)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "msg.Payload"));
		}
		if (aqEnqOptions != null)
		{
			if (m_pOpoAQEnqOptionsValCtx == null)
			{
				try
				{
					num = OpsAQ.AllocEnqOptValCtx(out m_pOpoAQEnqOptionsValCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				finally
				{
					if (num != 0)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
			GetModEnqOptDescAttribFlag(aqEnqOptions, ref m_enqOptsInfo);
		}
		IntPtr ppAQAgent = IntPtr.Zero;
		if (msg.m_msgPropsModified)
		{
			m_pOpoAQMsgPropsValCtx->isNull = 0;
			m_pOpoAQMsgPropsValCtx->delay = msg.m_delay;
			m_pOpoAQMsgPropsValCtx->expiration = msg.m_expiration;
			m_pOpoAQMsgPropsValCtx->priority = msg.m_priority;
			if (msg.m_recipients != null)
			{
				m_pOpoAQMsgPropsValCtx->numRecipients = msg.m_recipients.Length;
				OpoAQAgentRefCtx[] opoAQAgentRefCtx = new OpoAQAgentRefCtx[msg.m_recipients.Length];
				for (int i = 0; i < msg.m_recipients.Length; i++)
				{
					opoAQAgentRefCtx[i] = default(OpoAQAgentRefCtx);
					opoAQAgentRefCtx[i].name = msg.m_recipients[i].m_name;
					opoAQAgentRefCtx[i].address = msg.m_recipients[i].m_address;
				}
				num = OpsAQ.PrepareAgentArray(m_opsConCtx, m_opsErrCtx, ref opoAQAgentRefCtx, msg.m_recipients.Length, out ppAQAgent);
				m_pOpoAQMsgPropsValCtx->pRecipients = ppAQAgent;
			}
			else
			{
				m_pOpoAQMsgPropsValCtx->numRecipients = 0;
			}
			if (msg.m_senderId != null)
			{
				m_opoAQMsgPropsRefCtx.senderId.name = msg.m_senderId.Name;
				m_opoAQMsgPropsRefCtx.senderId.address = msg.m_senderId.Address;
			}
			else
			{
				m_opoAQMsgPropsRefCtx.senderId.name = null;
				m_opoAQMsgPropsRefCtx.senderId.address = null;
			}
			m_opoAQMsgPropsRefCtx.correlationId = msg.m_correlation;
			m_opoAQMsgPropsRefCtx.exceptionQueue = msg.m_exceptionQueue;
		}
		else
		{
			m_pOpoAQMsgPropsValCtx->isNull = 1;
		}
		_ = IntPtr.Zero;
		_ = IntPtr.Zero;
		byte[] array = null;
		if (OracleAQMessageType.Raw == m_messageType)
		{
			m_pOpoAQMsgValCtx->payloadType = 1;
			if (msg.m_payload is OracleBinary)
			{
				array = ((OracleBinary)msg.m_payload).m_value;
				m_pOpoAQMsgValCtx->rawPayloadLen = array.Length;
			}
			else if (msg.m_payload is byte[])
			{
				array = (byte[])msg.m_payload;
				m_pOpoAQMsgValCtx->rawPayloadLen = array.Length;
			}
			else
			{
				if (msg.m_payload != null)
				{
					throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "msg"));
				}
				array = null;
				m_pOpoAQMsgValCtx->rawPayloadLen = 0;
			}
		}
		else if (OracleAQMessageType.Udt == m_messageType)
		{
			if (msg.m_payload is IOracleCustomType && !((INullable)msg.m_payload).IsNull)
			{
				SetUDTFromCustomObject((IOracleCustomType)msg.m_payload, m_pOpoAQMsgValCtx);
			}
			else
			{
				if (msg.m_payload != null && (!(msg.m_payload is IOracleCustomType) || !((INullable)msg.m_payload).IsNull))
				{
					throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "msg"));
				}
				SetNullUDTFromCustomObject(m_udtTypeName, m_pOpoAQMsgValCtx);
			}
			m_pOpoAQMsgValCtx->payloadType = 2;
		}
		else if (OracleAQMessageType.Xml == m_messageType)
		{
			try
			{
				m_pOpoAQMsgValCtx->payloadType = 3;
				if (msg.Payload != null)
				{
					if (msg.Payload is OracleXmlType)
					{
						num = (msg.Payload as OracleXmlType).GetOCIXMLType(out m_pOpoAQMsgValCtx->pXmlPayload);
					}
					else if (msg.Payload is XmlReader)
					{
						OracleXmlType oracleXmlType2 = new OracleXmlType(m_connection, msg.Payload as XmlReader);
						num = oracleXmlType2.GetOCIXMLType(out m_pOpoAQMsgValCtx->pXmlPayload);
						oracleXmlType = oracleXmlType2;
					}
					else
					{
						if (!(msg.Payload is string))
						{
							throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "msg"));
						}
						OracleXmlType oracleXmlType3 = new OracleXmlType(m_connection, msg.Payload as string);
						num = oracleXmlType3.GetOCIXMLType(out m_pOpoAQMsgValCtx->pXmlPayload);
						oracleXmlType = oracleXmlType3;
					}
				}
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
		try
		{
			if (num == 0)
			{
				num = OpsAQ.Enqueue(m_opsConCtx, m_opsErrCtx, m_name, (OracleAQMessageType.Raw == m_messageType) ? array : null, (aqEnqOptions != null) ? m_pOpoAQEnqOptionsValCtx : null, m_pOpoAQMsgPropsValCtx, m_opoAQMsgPropsRefCtx, m_pOpoAQMsgValCtx, ref m_OCIAQEnqOptions, (aqEnqOptions != null) ? m_enqOptsInfo : 0, ref m_OCIAQMsgProperties);
			}
			if (num == 0 && OracleAQMessageType.Udt == m_messageType)
			{
				if (m_pOpoAQMsgValCtx->pOpoUdtValCtx->pUDT != IntPtr.Zero)
				{
					OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, m_pOpoAQMsgValCtx->pOpoUdtValCtx->pUDT);
				}
				OpsUdt.FreeValCtx(m_pOpoAQMsgValCtx->pOpoUdtValCtx, bFreeOuter: true);
				m_pOpoAQMsgValCtx->pOpoUdtValCtx = (OpoUdtValCtx*)(void*)IntPtr.Zero;
			}
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		finally
		{
			if (aqEnqOptions != null)
			{
				m_enqOptsInfo = 0;
			}
			if (OracleAQMessageType.Xml == m_messageType)
			{
				m_pOpoAQMsgValCtx->pXmlPayload = IntPtr.Zero;
				m_pOpoAQMsgValCtx->isXmlOrUDTNull = 0;
			}
			oracleXmlType?.Dispose();
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (aqEnqOptions == null || aqEnqOptions.m_deliveryMode != OracleAQMessageDeliveryMode.Buffered)
		{
			msg.m_messageId = new byte[m_pOpoAQMsgValCtx->msgIdLen];
			Marshal.Copy(m_pOpoAQMsgValCtx->pMsgId, msg.m_messageId, 0, m_pOpoAQMsgValCtx->msgIdLen);
		}
		try
		{
			OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, m_pOpoAQMsgValCtx->pMsgIdObject);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleAQQueue::Enqueue()\n");
		}
	}

	public int EnqueueArray(OracleAQMessage[] messages)
	{
		return EnqueueArray(messages, m_aqEnqOptions);
	}

	public unsafe int EnqueueArray(OracleAQMessage[] messages, OracleAQEnqueueOptions aqEnqOptions)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::EnqueueArray()\n");
		}
		OracleXmlType[] array = null;
		OracleXmlType[] array2 = null;
		if (messages == null)
		{
			throw new ArgumentNullException("msg");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (!m_isConSet || m_connection.m_conSignature != m_conSignature)
		{
			SetConnection(m_connection);
		}
		for (int i = 0; i < messages.Length; i++)
		{
			if (messages[i] == null)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "messages"));
			}
			if (messages[i].Payload is OracleXmlType && ((OracleXmlType)messages[i].Payload).m_conSignature != m_conSignature)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "messages[ " + i + " ].Payload"));
			}
		}
		int num = 0;
		int numElements = messages.Length;
		if (aqEnqOptions != null)
		{
			if (m_pOpoAQEnqOptionsValCtx == null)
			{
				try
				{
					num = OpsAQ.AllocEnqOptValCtx(out m_pOpoAQEnqOptionsValCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				finally
				{
					if (num != 0)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
			GetModEnqOptDescAttribFlag(aqEnqOptions, ref m_enqOptsInfo);
		}
		OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx = null;
		OpoAQMsgValCtx* pOpoAQMsgValCtx = null;
		OpoAQMsgPropsRefCtx[] array3 = new OpoAQMsgPropsRefCtx[messages.Length];
		try
		{
			num = OpsAQ.AllocValCtxArray(out pOpoAQMsgPropsValCtx, out pOpoAQMsgValCtx, messages.Length);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		IntPtr ppAQAgent = IntPtr.Zero;
		for (int j = 0; j < messages.Length; j++)
		{
			if (messages[j].m_msgPropsModified)
			{
				pOpoAQMsgPropsValCtx[j].isNull = 0;
				pOpoAQMsgPropsValCtx[j].delay = messages[j].m_delay;
				pOpoAQMsgPropsValCtx[j].expiration = messages[j].m_expiration;
				pOpoAQMsgPropsValCtx[j].priority = messages[j].m_priority;
				if (messages[j].m_recipients != null)
				{
					pOpoAQMsgPropsValCtx[j].numRecipients = messages[j].m_recipients.Length;
					OpoAQAgentRefCtx[] opoAQAgentRefCtx = new OpoAQAgentRefCtx[messages[j].m_recipients.Length];
					for (int k = 0; k < messages[j].m_recipients.Length; k++)
					{
						opoAQAgentRefCtx[k] = default(OpoAQAgentRefCtx);
						opoAQAgentRefCtx[k].name = messages[j].m_recipients[k].m_name;
						opoAQAgentRefCtx[k].address = messages[j].m_recipients[k].m_address;
					}
					try
					{
						num = OpsAQ.PrepareAgentArray(m_opsConCtx, m_opsErrCtx, ref opoAQAgentRefCtx, messages[j].m_recipients.Length, out ppAQAgent);
					}
					catch (Exception ex3)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex3);
						}
						num = ErrRes.INT_ERR;
						throw;
					}
					finally
					{
						if (num == 0)
						{
							pOpoAQMsgPropsValCtx[j].pRecipients = ppAQAgent;
						}
						else if (num != ErrRes.INT_ERR)
						{
							OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						}
					}
				}
				else
				{
					pOpoAQMsgPropsValCtx[j].numRecipients = 0;
				}
				array3[j] = new OpoAQMsgPropsRefCtx();
				if (messages[j].m_senderId != null)
				{
					array3[j].senderId.name = messages[j].m_senderId.Name;
					array3[j].senderId.address = messages[j].m_senderId.Address;
				}
				else
				{
					array3[j].senderId.name = null;
					array3[j].senderId.address = null;
				}
				array3[j].correlationId = messages[j].m_correlation;
				array3[j].exceptionQueue = messages[j].m_exceptionQueue;
			}
			else
			{
				pOpoAQMsgPropsValCtx[j].isNull = 1;
			}
		}
		byte[] array4 = null;
		IntPtr[] array5 = new IntPtr[messages.Length];
		IntPtr[] array6 = new IntPtr[messages.Length];
		try
		{
			num = OpsAQ.AllocMsgPropsRefCtxArray(array6, messages.Length);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		for (int l = 0; l < messages.Length; l++)
		{
			if (pOpoAQMsgPropsValCtx[l].isNull != 1)
			{
				Marshal.StructureToPtr((object)array3[l], array6[l], fDeleteOld: true);
			}
		}
		if (OracleAQMessageType.Raw == m_messageType)
		{
			for (int m = 0; m < messages.Length; m++)
			{
				pOpoAQMsgValCtx[m].payloadType = 1;
				if (messages[m].m_payload == null)
				{
					continue;
				}
				if (messages[m].m_payload is OracleBinary)
				{
					array4 = ((OracleBinary)messages[m].m_payload).m_value;
					pOpoAQMsgValCtx[m].rawPayloadLen = array4.Length;
				}
				else
				{
					if (!(messages[m].m_payload is byte[]))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "messages"));
					}
					array4 = (byte[])messages[m].m_payload;
					pOpoAQMsgValCtx[m].rawPayloadLen = array4.Length;
				}
				if (pOpoAQMsgValCtx[m].rawPayloadLen > 0)
				{
					ref IntPtr reference = ref array5[m];
					reference = Marshal.AllocCoTaskMem(pOpoAQMsgValCtx[m].rawPayloadLen);
					try
					{
						num = OpsAQ.ConvertByteArray(array5[m], array4, pOpoAQMsgValCtx[m].rawPayloadLen);
					}
					catch (Exception ex5)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex5);
						}
						throw;
					}
				}
				else
				{
					ref IntPtr reference2 = ref array5[m];
					reference2 = IntPtr.Zero;
				}
			}
		}
		else if (OracleAQMessageType.Udt == m_messageType)
		{
			for (int n = 0; n < messages.Length; n++)
			{
				if (messages[n].m_payload is IOracleCustomType && !((INullable)messages[n].m_payload).IsNull)
				{
					SetUDTFromCustomObject((IOracleCustomType)messages[n].m_payload, pOpoAQMsgValCtx + n);
				}
				else
				{
					if (messages[n].m_payload != null && (!(messages[n].m_payload is IOracleCustomType) || !((INullable)messages[n].m_payload).IsNull))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "messages"));
					}
					SetNullUDTFromCustomObject(m_udtTypeName, pOpoAQMsgValCtx + n);
				}
				pOpoAQMsgValCtx[n].payloadType = 2;
			}
		}
		else if (OracleAQMessageType.Xml == m_messageType)
		{
			try
			{
				bool flag = false;
				if (array2 == null)
				{
					array2 = new OracleXmlType[messages.Length];
				}
				for (int num2 = 0; num2 < messages.Length; num2++)
				{
					if (messages[num2].Payload != null && messages[num2].Payload is XmlReader)
					{
						if (num2 == 0)
						{
							array2[num2] = new OracleXmlType(m_connection, messages[num2].Payload as XmlReader);
						}
						else
						{
							for (int num3 = num2; num3 > 0; num3--)
							{
								if (messages[num3 - 1].Payload != null && messages[num3 - 1].Payload is XmlReader && ((XmlReader)messages[num2].Payload).Equals((XmlReader)messages[num3 - 1].Payload))
								{
									array2[num2] = array2[num3 - 1];
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								array2[num2] = new OracleXmlType(m_connection, messages[num2].Payload as XmlReader);
							}
						}
					}
					flag = false;
				}
				for (int num4 = 0; num4 < messages.Length; num4++)
				{
					pOpoAQMsgValCtx[num4].payloadType = 3;
					if (messages[num4].Payload == null)
					{
						continue;
					}
					if (messages[num4].Payload is OracleXmlType)
					{
						num = (messages[num4].Payload as OracleXmlType).GetOCIXMLType(out pOpoAQMsgValCtx[num4].pXmlPayload);
						continue;
					}
					if (messages[num4].Payload is XmlReader)
					{
						num = array2[num4].GetOCIXMLType(out pOpoAQMsgValCtx[num4].pXmlPayload);
						continue;
					}
					if (messages[num4].Payload is string)
					{
						if (array == null)
						{
							array = new OracleXmlType[messages.Length];
						}
						OracleXmlType oracleXmlType = new OracleXmlType(m_connection, messages[num4].Payload as string);
						num = oracleXmlType.GetOCIXMLType(out pOpoAQMsgValCtx[num4].pXmlPayload);
						array[num4] = oracleXmlType;
						continue;
					}
					throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "messages"));
				}
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
		try
		{
			if (num == 0)
			{
				num = OpsAQ.EnqueueArray(m_opsConCtx, m_opsErrCtx, m_name, ref numElements, (OracleAQMessageType.Raw == m_messageType) ? array5 : null, (aqEnqOptions != null) ? m_pOpoAQEnqOptionsValCtx : null, pOpoAQMsgPropsValCtx, array6, pOpoAQMsgValCtx, ref m_OCIAQEnqOptions, (aqEnqOptions != null) ? m_enqOptsInfo : 0);
			}
		}
		catch (Exception ex6)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex6);
			}
			throw;
		}
		finally
		{
			if (OracleAQMessageType.Raw == m_messageType)
			{
				for (int num5 = 0; num5 < messages.Length; num5++)
				{
					if (array5[num5] != IntPtr.Zero)
					{
						Marshal.FreeCoTaskMem(array5[num5]);
					}
				}
			}
			if (aqEnqOptions != null)
			{
				m_enqOptsInfo = 0;
			}
			if (array != null)
			{
				for (int num6 = 0; num6 < array.Length; num6++)
				{
					if (array[num6] != null)
					{
						array[num6].Dispose();
					}
				}
			}
			if (array2 != null)
			{
				for (int num7 = 0; num7 < array2.Length; num7++)
				{
					if (array2[num7] != null)
					{
						array2[num7].Dispose();
					}
				}
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		for (int num8 = 0; num8 < messages.Length; num8++)
		{
			if (aqEnqOptions == null || aqEnqOptions.m_deliveryMode != OracleAQMessageDeliveryMode.Buffered)
			{
				messages[num8].m_messageId = new byte[pOpoAQMsgValCtx[num8].msgIdLen];
				Marshal.Copy(pOpoAQMsgValCtx[num8].pMsgId, messages[num8].m_messageId, 0, pOpoAQMsgValCtx[num8].msgIdLen);
			}
			try
			{
				OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, pOpoAQMsgValCtx[num8].pMsgIdObject);
				if (OracleAQMessageType.Udt == m_messageType)
				{
					if (pOpoAQMsgValCtx[num8].pOpoUdtValCtx->pUDT != IntPtr.Zero)
					{
						OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, pOpoAQMsgValCtx[num8].pOpoUdtValCtx->pUDT);
					}
					OpsUdt.FreeValCtx(pOpoAQMsgValCtx[num8].pOpoUdtValCtx, bFreeOuter: true);
					pOpoAQMsgValCtx[num8].pOpoUdtValCtx = (OpoUdtValCtx*)(void*)IntPtr.Zero;
				}
			}
			catch (Exception ex7)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex7);
				}
				throw;
			}
		}
		try
		{
			OpsAQ.FreeValCtxArray(ref pOpoAQMsgPropsValCtx, ref pOpoAQMsgValCtx, messages.Length);
			OpsAQ.FreeMsgPropsRefCtxArray(array6, messages.Length);
		}
		catch (Exception ex8)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex8);
			}
			throw;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleAQQueue::EnqueueArray()\n");
		}
		return numElements;
	}

	public OracleAQMessage Dequeue()
	{
		return Dequeue(m_aqDeqOptions);
	}

	public unsafe OracleAQMessage Dequeue(OracleAQDequeueOptions aqDeqOptions)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::Dequeue()\n");
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (!m_isConSet || m_connection.m_conSignature != m_conSignature)
		{
			SetConnection(m_connection);
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		int num = 0;
		OracleAQMessage oracleAQMessage = new OracleAQMessage();
		if (aqDeqOptions != null)
		{
			if (m_pOpoAQDeqOptionsValCtx == null)
			{
				try
				{
					OpsAQ.AllocDeqOptValCtx(out m_pOpoAQDeqOptionsValCtx);
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
			if (m_opoAQDeqOptionsRefCtx == null)
			{
				m_opoAQDeqOptionsRefCtx = new OpoAQDeqOptionsRefCtx();
			}
			GetModDeqOptDescAttribFlag(aqDeqOptions, ref m_deqOptsInfo);
		}
		OracleUdtDescriptor oracleUdtDescriptor = null;
		if (OracleAQMessageType.Raw == m_messageType)
		{
			m_pOpoAQMsgValCtx->payloadType = 1;
		}
		else if (OracleAQMessageType.Udt == m_messageType)
		{
			if (m_udtTypeName == null || m_udtTypeName.Length == 0)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "UdtTypeName"));
			}
			m_pOpoAQMsgValCtx->payloadType = 2;
			oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, m_udtTypeName);
			if (oracleUdtDescriptor.m_customTypeFactory == null)
			{
				object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
				oracleUdtDescriptor.DescribeCustomType(factory);
			}
			int num2 = 0;
			if ((IntPtr)m_pOpoAQMsgValCtx->pOpoUdtValCtx == IntPtr.Zero)
			{
				try
				{
					num2 = OpsUdt.AllocValCtx(out m_pOpoAQMsgValCtx->pOpoUdtValCtx, 1);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					throw;
				}
				finally
				{
					if (num2 != 0)
					{
						OracleException.HandleError(num2, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
					}
				}
			}
			m_pOpoAQMsgValCtx->pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
			m_pOpoAQMsgValCtx->pOpoUdtValCtx->pTDO = oracleUdtDescriptor.m_opsDscCtx;
			m_pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		}
		else if (m_messageType == OracleAQMessageType.Xml)
		{
			m_pOpoAQMsgValCtx->payloadType = 3;
		}
		try
		{
			num = OpsAQ.Dequeue(m_opsConCtx, m_opsErrCtx, m_name, (aqDeqOptions == null) ? null : ((aqDeqOptions.m_messageId != null) ? aqDeqOptions.m_messageId : null), (aqDeqOptions != null) ? m_pOpoAQDeqOptionsValCtx : null, (aqDeqOptions != null) ? m_opoAQDeqOptionsRefCtx : null, m_pOpoAQMsgPropsValCtx, ref m_opoAQMsgPropsRefCtx, m_pOpoAQMsgValCtx, ref m_OCIAQDeqOptions, (aqDeqOptions != null) ? m_deqOptsInfo : 0, ref m_OCIAQMsgProperties);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (aqDeqOptions != null)
		{
			m_deqOptsInfo = 0;
		}
		if (num == 0)
		{
			if (OracleAQMessageType.Raw == m_messageType)
			{
				if (m_pOpoAQMsgValCtx->rawPayloadLen != 0)
				{
					byte[] array = new byte[m_pOpoAQMsgValCtx->rawPayloadLen];
					Marshal.Copy(m_pOpoAQMsgValCtx->pPayloadOut, array, 0, m_pOpoAQMsgValCtx->rawPayloadLen);
					if (aqDeqOptions != null && aqDeqOptions.m_providerSpecificType)
					{
						OracleBinary oracleBinary = new OracleBinary(array, bCopy: false);
						oracleAQMessage.m_payload = oracleBinary;
					}
					else
					{
						oracleAQMessage.m_payload = array;
					}
				}
				else
				{
					oracleAQMessage.m_payload = null;
				}
			}
			else if (m_messageType == OracleAQMessageType.Xml)
			{
				try
				{
					if (m_pOpoAQMsgValCtx->isXmlOrUDTNull == 1)
					{
						oracleAQMessage.m_payload = OracleXmlType.Null;
					}
					else
					{
						OracleXmlType oracleXmlType = new OracleXmlType(m_connection, m_pOpoAQMsgValCtx->pXmlPayload, addRef: false, 1);
						if (aqDeqOptions != null && aqDeqOptions.m_providerSpecificType)
						{
							oracleAQMessage.m_payload = oracleXmlType;
						}
						else
						{
							XmlReader xmlReader;
							try
							{
								xmlReader = oracleXmlType.GetXmlReader();
							}
							finally
							{
								oracleXmlType.Dispose();
							}
							oracleAQMessage.m_payload = xmlReader;
						}
					}
				}
				finally
				{
					m_pOpoAQMsgValCtx->pXmlPayload = IntPtr.Zero;
					m_pOpoAQMsgValCtx->isXmlOrUDTNull = 0;
				}
			}
			else if (m_messageType == OracleAQMessageType.Udt)
			{
				if (aqDeqOptions.DequeueMode != OracleAQDequeueMode.RemoveNoData)
				{
					IOracleCustomType oracleCustomType = null;
					if (m_pOpoAQMsgValCtx->isXmlOrUDTNull == 0)
					{
						try
						{
							num = OpsUdt.GetObj(m_connection.m_opoConCtx.opsConCtx, m_pOpoAQMsgValCtx->pOpoUdtValCtx);
						}
						catch (Exception ex4)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex4);
							}
							num = ErrRes.INT_ERR;
							throw;
						}
						finally
						{
							if (num == 0)
							{
								m_pOpoAQMsgValCtx->pOpoUdtValCtx->bIsNull = 0;
							}
							else if (num != ErrRes.INT_ERR)
							{
								OracleException.HandleError(num, m_connection, m_pOpoAQMsgValCtx->pOpoUdtValCtx->pOpsErrCtx, this);
							}
						}
					}
					else
					{
						m_pOpoAQMsgValCtx->pOpoUdtValCtx->bIsNull = 1;
					}
					oracleCustomType = ((IOracleCustomTypeFactory)oracleUdtDescriptor.m_customTypeFactory).CreateObject();
					if (m_pOpoAQMsgValCtx->pOpoUdtValCtx->bIsNull == 1)
					{
						Type type = oracleCustomType.GetType();
						PropertyInfo property = type.GetProperty("Null");
						if (property == null)
						{
							oracleAQMessage.m_payload = null;
						}
						else
						{
							oracleAQMessage.m_payload = property.GetValue(null, null);
						}
					}
					else
					{
						oracleCustomType.ToCustomObject(m_connection, (IntPtr)m_pOpoAQMsgValCtx->pOpoUdtValCtx);
						oracleAQMessage.m_payload = oracleCustomType;
						try
						{
							num = OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, m_pOpoAQMsgValCtx->pOpoUdtValCtx->pUDT);
						}
						catch (Exception ex5)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex5);
							}
							throw;
						}
						finally
						{
							if (num != 0)
							{
								OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
							}
						}
					}
					try
					{
						OpsUdt.FreeValCtx(m_pOpoAQMsgValCtx->pOpoUdtValCtx, bFreeOuter: true);
					}
					catch (Exception ex6)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex6);
						}
						throw;
					}
					m_pOpoAQMsgValCtx->pOpoUdtValCtx = (OpoUdtValCtx*)(void*)IntPtr.Zero;
					GC.KeepAlive(oracleUdtDescriptor);
				}
				else
				{
					oracleAQMessage.m_payload = null;
				}
			}
			oracleAQMessage.m_deliveryMode = (OracleAQMessageDeliveryMode)m_pOpoAQMsgPropsValCtx->deliveryMode;
			if (oracleAQMessage.m_deliveryMode != OracleAQMessageDeliveryMode.Buffered)
			{
				oracleAQMessage.m_messageId = new byte[m_pOpoAQMsgValCtx->msgIdLen];
				Marshal.Copy(m_pOpoAQMsgValCtx->pMsgId, oracleAQMessage.m_messageId, 0, m_pOpoAQMsgValCtx->msgIdLen);
			}
			if (m_pOpoAQMsgPropsValCtx->origMsgIdLen > 0)
			{
				oracleAQMessage.m_originalMessageId = new byte[m_pOpoAQMsgPropsValCtx->origMsgIdLen];
				Marshal.Copy(m_pOpoAQMsgPropsValCtx->pOrigMsgId, oracleAQMessage.m_originalMessageId, 0, m_pOpoAQMsgPropsValCtx->origMsgIdLen);
			}
			oracleAQMessage.m_correlation = m_opoAQMsgPropsRefCtx.correlationId;
			oracleAQMessage.m_exceptionQueue = m_opoAQMsgPropsRefCtx.exceptionQueue;
			if (m_opoAQMsgPropsRefCtx.senderId.name != null && m_opoAQMsgPropsRefCtx.senderId.address == null)
			{
				oracleAQMessage.m_senderId = new OracleAQAgent(m_opoAQMsgPropsRefCtx.senderId.name);
			}
			else if (m_opoAQMsgPropsRefCtx.senderId.name != null && m_opoAQMsgPropsRefCtx.senderId.address != null)
			{
				oracleAQMessage.m_senderId = new OracleAQAgent(m_opoAQMsgPropsRefCtx.senderId.name, m_opoAQMsgPropsRefCtx.senderId.address);
			}
			if (oracleAQMessage.m_deliveryMode == OracleAQMessageDeliveryMode.Buffered && aqDeqOptions.m_correlation != null)
			{
				oracleAQMessage.m_state = OracleAQMessageState.Ready;
			}
			else
			{
				oracleAQMessage.m_state = (OracleAQMessageState)m_pOpoAQMsgPropsValCtx->msgState;
			}
			oracleAQMessage.m_enqueueTime = new DateTime(m_pOpoAQMsgPropsValCtx->year, m_pOpoAQMsgPropsValCtx->month, m_pOpoAQMsgPropsValCtx->day, m_pOpoAQMsgPropsValCtx->hour, m_pOpoAQMsgPropsValCtx->min, m_pOpoAQMsgPropsValCtx->sec);
			oracleAQMessage.m_deqAttempts = m_pOpoAQMsgPropsValCtx->dequeueAttempts;
			oracleAQMessage.m_delay = m_pOpoAQMsgPropsValCtx->delay;
			oracleAQMessage.m_expiration = m_pOpoAQMsgPropsValCtx->expiration;
			oracleAQMessage.m_priority = m_pOpoAQMsgPropsValCtx->priority;
		}
		try
		{
			OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, m_pOpoAQMsgValCtx->pMsgIdObject);
			if (m_pOpoAQMsgPropsValCtx->origMsgIdLen > 0)
			{
				OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, m_pOpoAQMsgPropsValCtx->pOrigMsgIdObject);
			}
			if (OracleAQMessageType.Raw == m_messageType && oracleAQMessage.m_payload != null)
			{
				OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, m_pOpoAQMsgValCtx->pPayloadObject);
			}
		}
		catch (Exception ex7)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex7);
			}
			throw;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleAQQueue::Dequeue()\n");
		}
		return oracleAQMessage;
	}

	public OracleAQMessage[] DequeueArray(int dequeueCount)
	{
		return DequeueArray(dequeueCount, m_aqDeqOptions);
	}

	public unsafe OracleAQMessage[] DequeueArray(int dequeueCount, OracleAQDequeueOptions aqDeqOptions)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::DequeueArray()\n");
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (!m_isConSet || m_connection.m_conSignature != m_conSignature)
		{
			SetConnection(m_connection);
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (dequeueCount <= 0)
		{
			throw new ArgumentOutOfRangeException("dequeueCount");
		}
		int num = 0;
		OracleAQMessage[] array = null;
		object[] array2 = null;
		if (aqDeqOptions != null)
		{
			if (m_pOpoAQDeqOptionsValCtx == null)
			{
				try
				{
					OpsAQ.AllocDeqOptValCtx(out m_pOpoAQDeqOptionsValCtx);
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
			if (m_opoAQDeqOptionsRefCtx == null)
			{
				m_opoAQDeqOptionsRefCtx = new OpoAQDeqOptionsRefCtx();
			}
			GetModDeqOptDescAttribFlag(aqDeqOptions, ref m_deqOptsInfo);
		}
		OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx = null;
		OpoAQMsgValCtx* pOpoAQMsgValCtx = null;
		OpoAQMsgPropsRefCtx[] array3 = null;
		try
		{
			OpsAQ.AllocValCtxArray(out pOpoAQMsgPropsValCtx, out pOpoAQMsgValCtx, 1);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		IntPtr[] array4 = null;
		OracleUdtDescriptor oracleUdtDescriptor = null;
		if (m_messageType == OracleAQMessageType.Raw)
		{
			pOpoAQMsgValCtx->payloadType = 1;
		}
		else if (m_messageType == OracleAQMessageType.Udt)
		{
			if (m_udtTypeName == null || m_udtTypeName.Length == 0)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "UdtTypeName"));
			}
			pOpoAQMsgValCtx->payloadType = 2;
			oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, m_udtTypeName);
			if (oracleUdtDescriptor.m_customTypeFactory == null)
			{
				object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
				oracleUdtDescriptor.DescribeCustomType(factory);
			}
			int num2 = 0;
			pOpoAQMsgValCtx->payloadType = 2;
			if ((IntPtr)pOpoAQMsgValCtx->pOpoUdtValCtx == IntPtr.Zero)
			{
				try
				{
					num2 = OpsUdt.AllocValCtx(out pOpoAQMsgValCtx->pOpoUdtValCtx, 1);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
					throw;
				}
				finally
				{
					if (num2 != 0)
					{
						OracleException.HandleError(num2, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
					}
				}
			}
			pOpoAQMsgValCtx->pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
			pOpoAQMsgValCtx->pOpoUdtValCtx->pTDO = oracleUdtDescriptor.m_opsDscCtx;
			pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		}
		else if (m_messageType == OracleAQMessageType.Xml)
		{
			pOpoAQMsgValCtx->payloadType = 3;
		}
		OpoAQDequeueArrayPtrs* pOpoAQDequeueArrayPtrs = null;
		OpoUdtValCtx* pOpoUdtValCtx = null;
		try
		{
			num = OpsAQ.DequeueArray(m_opsConCtx, m_opsErrCtx, m_name, ref dequeueCount, (aqDeqOptions == null) ? null : ((aqDeqOptions.m_messageId != null) ? aqDeqOptions.m_messageId : null), (aqDeqOptions != null) ? m_pOpoAQDeqOptionsValCtx : null, (aqDeqOptions != null) ? m_opoAQDeqOptionsRefCtx : null, ref pOpoAQMsgPropsValCtx, ref pOpoAQMsgValCtx, ref m_OCIAQDeqOptions, (aqDeqOptions != null) ? m_deqOptsInfo : 0, out pOpoAQDequeueArrayPtrs);
			if (num == 0 && dequeueCount > 0)
			{
				OpsAQ.AllocValCtxArray(out pOpoAQMsgPropsValCtx, out pOpoAQMsgValCtx, dequeueCount);
				array3 = new OpoAQMsgPropsRefCtx[dequeueCount];
				array4 = new IntPtr[dequeueCount];
				OpsAQ.AllocMsgPropsRefCtxArray(array4, dequeueCount);
				if (m_messageType == OracleAQMessageType.Raw)
				{
					pOpoAQMsgValCtx->payloadType = 1;
				}
				else if (m_messageType == OracleAQMessageType.Udt)
				{
					pOpoAQMsgValCtx->payloadType = 2;
					num = OpsUdt.AllocValCtx(out pOpoUdtValCtx, dequeueCount);
					if (num == 0)
					{
						for (int i = 0; i < dequeueCount; i++)
						{
							pOpoAQMsgValCtx[i].payloadType = 2;
							pOpoAQMsgValCtx[i].pOpoUdtValCtx = pOpoUdtValCtx + i;
							pOpoAQMsgValCtx[i].pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
							pOpoAQMsgValCtx[i].pOpoUdtValCtx->pTDO = oracleUdtDescriptor.m_opsDscCtx;
							pOpoAQMsgValCtx[i].pOpoUdtValCtx->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
						}
					}
				}
				else if (m_messageType == OracleAQMessageType.Xml)
				{
					pOpoAQMsgValCtx->payloadType = 3;
				}
			}
			if (num == 0 && dequeueCount > 0)
			{
				num = OpsAQ.DequeueArrayGetInfo(m_opsConCtx, m_opsErrCtx, dequeueCount, pOpoAQMsgPropsValCtx, array4, pOpoAQMsgValCtx, ref pOpoAQDequeueArrayPtrs);
			}
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OpsAQ.FreeDeqArrPtrs(ref pOpoAQDequeueArrayPtrs);
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (aqDeqOptions != null)
		{
			m_deqOptsInfo = 0;
		}
		if (num == 0 && dequeueCount > 0)
		{
			if (OracleAQMessageType.Raw == m_messageType)
			{
				array = new OracleAQMessage[dequeueCount];
				for (int j = 0; j < dequeueCount; j++)
				{
					array3[j] = new OpoAQMsgPropsRefCtx();
					Marshal.PtrToStructure(array4[j], (object)array3[j]);
				}
				for (int k = 0; k < dequeueCount; k++)
				{
					array[k] = new OracleAQMessage();
					if (pOpoAQMsgValCtx[k].rawPayloadLen != 0)
					{
						byte[] array5 = new byte[pOpoAQMsgValCtx[k].rawPayloadLen];
						Marshal.Copy(pOpoAQMsgValCtx[k].pPayloadOut, array5, 0, pOpoAQMsgValCtx[k].rawPayloadLen);
						if (aqDeqOptions != null && aqDeqOptions.m_providerSpecificType)
						{
							OracleBinary oracleBinary = new OracleBinary(array5, bCopy: false);
							array[k].m_payload = oracleBinary;
						}
						else
						{
							array[k].m_payload = array5;
						}
					}
					else
					{
						array[k].m_payload = null;
					}
				}
			}
			else if (m_messageType == OracleAQMessageType.Udt)
			{
				if (aqDeqOptions.DequeueMode != OracleAQDequeueMode.RemoveNoData)
				{
					IOracleCustomType[] array6 = new IOracleCustomType[dequeueCount];
					for (int l = 0; l < dequeueCount; l++)
					{
						if (pOpoAQMsgValCtx[l].isXmlOrUDTNull == 0)
						{
							try
							{
								num = OpsUdt.GetObj(m_connection.m_opoConCtx.opsConCtx, pOpoAQMsgValCtx[l].pOpoUdtValCtx);
							}
							catch (Exception ex5)
							{
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.TraceExceptionInfo(ex5);
								}
								num = ErrRes.INT_ERR;
								throw;
							}
							finally
							{
								if (num == 0)
								{
									pOpoAQMsgValCtx[l].pOpoUdtValCtx->bIsNull = 0;
								}
								else if (num != ErrRes.INT_ERR)
								{
									OracleException.HandleError(num, m_connection, pOpoAQMsgValCtx[l].pOpoUdtValCtx->pOpsErrCtx, this);
								}
							}
						}
						else
						{
							pOpoAQMsgValCtx[l].pOpoUdtValCtx->bIsNull = 1;
						}
						array6[l] = ((IOracleCustomTypeFactory)oracleUdtDescriptor.m_customTypeFactory).CreateObject();
						if (pOpoAQMsgValCtx[l].pOpoUdtValCtx->bIsNull == 1)
						{
							Type type = array6[l].GetType();
							PropertyInfo property = type.GetProperty("Null");
							if (property == null)
							{
								array6[l] = null;
							}
							else
							{
								array6[l] = (IOracleCustomType)property.GetValue(null, null);
							}
							continue;
						}
						array6[l].ToCustomObject(m_connection, (IntPtr)pOpoAQMsgValCtx[l].pOpoUdtValCtx);
						try
						{
							OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, pOpoAQMsgValCtx[l].pOpoUdtValCtx->pUDT);
						}
						catch (Exception ex6)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex6);
							}
							throw;
						}
						finally
						{
							if (num != 0)
							{
								OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
							}
						}
					}
					try
					{
						OpsAQ.FreeUdtValCtxArray(pOpoUdtValCtx, dequeueCount);
					}
					catch (Exception ex7)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex7);
						}
						throw;
					}
					pOpoAQMsgValCtx->pOpoUdtValCtx = (OpoUdtValCtx*)(void*)IntPtr.Zero;
					GC.KeepAlive(oracleUdtDescriptor);
					array2 = array6;
				}
				else
				{
					array2 = null;
				}
				array = new OracleAQMessage[dequeueCount];
				if (array2 != null)
				{
					for (int m = 0; m < dequeueCount; m++)
					{
						array[m] = new OracleAQMessage(array2[m]);
					}
				}
				else
				{
					for (int n = 0; n < dequeueCount; n++)
					{
						array[n] = new OracleAQMessage();
					}
				}
				for (int num3 = 0; num3 < dequeueCount; num3++)
				{
					array3[num3] = new OpoAQMsgPropsRefCtx();
					Marshal.PtrToStructure(array4[num3], (object)array3[num3]);
				}
			}
			else if (m_messageType == OracleAQMessageType.Xml)
			{
				try
				{
					array = new OracleAQMessage[dequeueCount];
					for (int num4 = 0; num4 < dequeueCount; num4++)
					{
						array[num4] = new OracleAQMessage();
						array3[num4] = new OpoAQMsgPropsRefCtx();
						Marshal.PtrToStructure(array4[num4], (object)array3[num4]);
						if (pOpoAQMsgValCtx[num4].isXmlOrUDTNull == 1)
						{
							array[num4].m_payload = OracleXmlType.Null;
							continue;
						}
						OracleXmlType oracleXmlType = new OracleXmlType(m_connection, pOpoAQMsgValCtx[num4].pXmlPayload, addRef: false, 1);
						if (aqDeqOptions != null && aqDeqOptions.m_providerSpecificType)
						{
							array[num4].m_payload = oracleXmlType;
							continue;
						}
						XmlReader xmlReader;
						try
						{
							xmlReader = oracleXmlType.GetXmlReader();
						}
						finally
						{
							oracleXmlType.Dispose();
						}
						array[num4].m_payload = xmlReader;
					}
				}
				finally
				{
					for (int num5 = 0; num5 < dequeueCount; num5++)
					{
						pOpoAQMsgValCtx[num5].pXmlPayload = IntPtr.Zero;
						pOpoAQMsgValCtx[num5].isXmlOrUDTNull = 0;
					}
				}
			}
			for (int num6 = 0; num6 < dequeueCount; num6++)
			{
				if (m_connection.IsDBVer11gR2OrHigher && (aqDeqOptions == null || aqDeqOptions.DeliveryMode != OracleAQMessageDeliveryMode.Buffered))
				{
					array[num6].m_messageId = new byte[pOpoAQMsgValCtx[num6].msgIdLen];
					Marshal.Copy(pOpoAQMsgValCtx[num6].pMsgId, array[num6].m_messageId, 0, pOpoAQMsgValCtx[num6].msgIdLen);
				}
				if (pOpoAQMsgPropsValCtx[num6].origMsgIdLen > 0)
				{
					array[num6].m_originalMessageId = new byte[pOpoAQMsgPropsValCtx[num6].origMsgIdLen];
					Marshal.Copy(pOpoAQMsgPropsValCtx[num6].pOrigMsgId, array[num6].m_originalMessageId, 0, pOpoAQMsgPropsValCtx[num6].origMsgIdLen);
				}
				array[num6].m_correlation = array3[num6].correlationId;
				array[num6].m_exceptionQueue = array3[num6].exceptionQueue;
				array[num6].m_transactionGroup = array3[num6].transNo;
				if (array3[num6].senderId.name != null && array3[num6].senderId.address == null)
				{
					array[num6].m_senderId = new OracleAQAgent(array3[num6].senderId.name);
				}
				else if (array3[num6].senderId.name != null && array3[num6].senderId.address != null)
				{
					array[num6].m_senderId = new OracleAQAgent(array3[num6].senderId.name, array3[num6].senderId.address);
				}
				array[num6].m_state = (OracleAQMessageState)pOpoAQMsgPropsValCtx[num6].msgState;
				array[num6].m_deliveryMode = (OracleAQMessageDeliveryMode)pOpoAQMsgPropsValCtx[num6].deliveryMode;
				array[num6].m_enqueueTime = new DateTime(pOpoAQMsgPropsValCtx[num6].year, pOpoAQMsgPropsValCtx[num6].month, pOpoAQMsgPropsValCtx[num6].day, pOpoAQMsgPropsValCtx[num6].hour, pOpoAQMsgPropsValCtx[num6].min, pOpoAQMsgPropsValCtx[num6].sec);
				array[num6].m_deqAttempts = pOpoAQMsgPropsValCtx[num6].dequeueAttempts;
				array[num6].m_delay = pOpoAQMsgPropsValCtx[num6].delay;
				array[num6].m_expiration = pOpoAQMsgPropsValCtx[num6].expiration;
				array[num6].m_priority = pOpoAQMsgPropsValCtx[num6].priority;
				try
				{
					if (m_connection.IsDBVer11gR2OrHigher)
					{
						OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, pOpoAQMsgValCtx[num6].pMsgIdObject);
					}
					if (pOpoAQMsgPropsValCtx[num6].origMsgIdLen > 0)
					{
						OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, pOpoAQMsgPropsValCtx[num6].pOrigMsgIdObject);
					}
					if (OracleAQMessageType.Raw == m_messageType && array[num6].m_payload != null)
					{
						OpsAQ.FreeObject(m_opsConCtx, m_opsErrCtx, pOpoAQMsgValCtx[num6].pPayloadObject);
					}
				}
				catch (Exception ex8)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex8);
					}
					throw;
				}
			}
		}
		if (num == 0 && dequeueCount > 0)
		{
			try
			{
				OpsAQ.FreeValCtxArray(ref pOpoAQMsgPropsValCtx, ref pOpoAQMsgValCtx, dequeueCount);
				OpsAQ.FreeMsgPropsRefCtxArray(array4, dequeueCount);
			}
			catch (Exception ex9)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex9);
				}
				throw;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleAQQueue::DequeueArray()\n");
		}
		return array;
	}

	public string Listen(string[] listenConsumers)
	{
		return Listen(listenConsumers, -1);
	}

	public string Listen(string[] listenConsumers, int waitTime)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::Listen()\n");
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (!m_isConSet || m_connection.m_conSignature != m_conSignature)
		{
			SetConnection(m_connection);
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (waitTime < -1)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "waitTime"));
		}
		int num = 0;
		int num2 = ((listenConsumers == null) ? 1 : listenConsumers.Length);
		OpoAQAgentRefCtx[] opoAQAgentRefCtx = new OpoAQAgentRefCtx[num2];
		for (int i = 0; i < num2; i++)
		{
			opoAQAgentRefCtx[i] = default(OpoAQAgentRefCtx);
			opoAQAgentRefCtx[i].name = ((listenConsumers != null) ? listenConsumers[i] : null);
			opoAQAgentRefCtx[i].address = m_name;
		}
		OpoAQAgentRefCtx opoAQAgentRefCtx2 = default(OpoAQAgentRefCtx);
		try
		{
			IntPtr pOpoAQAgentRet = IntPtr.Zero;
			if (num == 0)
			{
				num = OpsAQ.Listen(m_connection.m_opoConCtx.opsConCtx, m_connection.m_opoConCtx.opsErrCtx, ref opoAQAgentRefCtx, num2, waitTime, out pOpoAQAgentRet);
			}
			if (num == 0)
			{
				opoAQAgentRefCtx2 = (OpoAQAgentRefCtx)Marshal.PtrToStructure(pOpoAQAgentRet, typeof(OpoAQAgentRefCtx));
			}
			OpsAQ.FreeAQAgentCtx(ref pOpoAQAgentRet);
			if (num == 25254)
			{
				return null;
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0 && num != 25254)
			{
				OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, null);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleAQQueue::Listen()\n");
		}
		if (opoAQAgentRefCtx2.name == null)
		{
			return "";
		}
		return opoAQAgentRefCtx2.name;
	}

	public static OracleAQAgent Listen(OracleConnection con, OracleAQAgent[] listenConsumers)
	{
		return Listen(con, listenConsumers, -1);
	}

	public static OracleAQAgent Listen(OracleConnection con, OracleAQAgent[] listenConsumers, int waitTime)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) Static-OracleAQAgent::Listen()\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (listenConsumers == null)
		{
			throw new ArgumentNullException("listenConsumers");
		}
		if (waitTime < -1)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "waitTime"));
		}
		if (con.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		int num = 0;
		int num2 = listenConsumers.Length;
		OpoAQAgentRefCtx[] opoAQAgentRefCtx = new OpoAQAgentRefCtx[num2];
		for (int i = 0; i < num2; i++)
		{
			opoAQAgentRefCtx[i] = default(OpoAQAgentRefCtx);
			opoAQAgentRefCtx[i].name = listenConsumers[i].m_name;
			opoAQAgentRefCtx[i].address = listenConsumers[i].m_address;
		}
		OpoAQAgentRefCtx opoAQAgentRefCtx2 = default(OpoAQAgentRefCtx);
		try
		{
			IntPtr pOpoAQAgentRet = IntPtr.Zero;
			if (num == 0)
			{
				num = OpsAQ.Listen(con.m_opoConCtx.opsConCtx, con.m_opoConCtx.opsErrCtx, ref opoAQAgentRefCtx, num2, waitTime, out pOpoAQAgentRet);
			}
			if (num == 0)
			{
				opoAQAgentRefCtx2 = (OpoAQAgentRefCtx)Marshal.PtrToStructure(pOpoAQAgentRet, typeof(OpoAQAgentRefCtx));
			}
			OpsAQ.FreeAQAgentCtx(ref pOpoAQAgentRet);
			if (num == 25254)
			{
				return null;
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0 && num != 25254)
			{
				OracleException.HandleError(num, con, con.m_opoConCtx.opsErrCtx, null);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  Static-OracleAQAgent::Listen()\n");
		}
		return new OracleAQAgent(opoAQAgentRefCtx2.name, opoAQAgentRefCtx2.address);
	}

	private unsafe void SetUDTFromCustomObject(IOracleCustomType customObj, OpoAQMsgValCtx* pOpoAQMsgValCtx)
	{
		int num = 0;
		OracleUdtDescriptor oracleUdtDescriptor = null;
		oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor2(m_connection, (OpoDscRefCtx)OracleUdt.GetUdtName(customObj.GetType().FullName, m_connection.DataSource));
		if (oracleUdtDescriptor == null)
		{
			throw new InvalidOperationException();
		}
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		if ((IntPtr)pOpoAQMsgValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out pOpoAQMsgValCtx->pOpoUdtValCtx, 1);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		if ((IntPtr)pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			finally
			{
				if (num == 0)
				{
					pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
				}
				else
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		else if (pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx < oracleUdtDescriptor.AttributeCount)
		{
			try
			{
				num = OpsUdt.ReAllocValCtx(ref pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx, pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			finally
			{
				if (num == 0)
				{
					pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
				}
				else
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		pOpoAQMsgValCtx->pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
		pOpoAQMsgValCtx->pOpoUdtValCtx->pTDO = oracleUdtDescriptor.m_opsDscCtx;
		pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		for (int i = 0; i < oracleUdtDescriptor.AttributeCount; i++)
		{
			pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx[i].bIsNull = 1;
		}
		customObj.FromCustomObject(m_connection, (IntPtr)pOpoAQMsgValCtx->pOpoUdtValCtx);
		if (!((INullable)customObj).IsNull)
		{
			try
			{
				num = OpsUdt.SetData(m_connection.m_opoConCtx.opsConCtx, pOpoAQMsgValCtx->pOpoUdtValCtx);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		GC.KeepAlive(oracleUdtDescriptor);
	}

	private unsafe void SetNullUDTFromCustomObject(string udtTypeName, OpoAQMsgValCtx* pOpoAQMsgValCtx)
	{
		OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, udtTypeName);
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		int num = 0;
		if ((IntPtr)pOpoAQMsgValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out pOpoAQMsgValCtx->pOpoUdtValCtx, 1);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		if ((IntPtr)pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			finally
			{
				if (num == 0)
				{
					pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
				}
				else
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		else if (pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx < oracleUdtDescriptor.AttributeCount)
		{
			try
			{
				num = OpsUdt.ReAllocValCtx(ref pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx, pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			finally
			{
				if (num == 0)
				{
					pOpoAQMsgValCtx->pOpoUdtValCtx->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
				}
				else
				{
					OracleException.HandleError(num, m_connection, m_connection.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		pOpoAQMsgValCtx->pOpoUdtValCtx->pOpsErrCtx = m_connection.m_opoConCtx.opsErrCtx;
		pOpoAQMsgValCtx->pOpoUdtValCtx->pTDO = oracleUdtDescriptor.m_opsDscCtx;
		pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		pOpoAQMsgValCtx->pOpoUdtValCtx->bIsNull = 1;
		for (int i = 0; i < oracleUdtDescriptor.AttributeCount; i++)
		{
			pOpoAQMsgValCtx->pOpoUdtValCtx->pOpoUdtValCtx[i].bIsNull = 1;
		}
		GC.KeepAlive(oracleUdtDescriptor);
	}

	private unsafe void Dispose(bool disposing)
	{
		if (m_disposed)
		{
			return;
		}
		try
		{
			if (disposing)
			{
				if (m_aqEnqOptions != null)
				{
					m_aqEnqOptions = null;
				}
				if (m_aqDeqOptions != null)
				{
					m_aqDeqOptions = null;
				}
				m_opoAQMsgPropsRefCtx = null;
			}
			if (m_pCtxNTFN != null)
			{
				try
				{
					SubscriptionUnRegister();
				}
				catch
				{
				}
			}
			try
			{
				OpsAQ.FreeValCtx(ref m_pOpoAQMsgPropsValCtx, ref m_pOpoAQMsgValCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			try
			{
				if (m_pOpoAQEnqOptionsValCtx != null)
				{
					OpsAQ.FreeEnqOptValCtx(ref m_pOpoAQEnqOptionsValCtx);
				}
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
			try
			{
				if (m_pOpoAQDeqOptionsValCtx != null)
				{
					OpsAQ.FreeDeqOptValCtx(ref m_pOpoAQDeqOptionsValCtx);
				}
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
			}
			if (m_OCIAQEnqOptions != IntPtr.Zero || m_OCIAQDeqOptions != IntPtr.Zero || m_OCIAQMsgProperties != IntPtr.Zero)
			{
				try
				{
					OpsAQ.FreeCachedDesc(ref m_OCIAQEnqOptions, ref m_OCIAQDeqOptions, ref m_OCIAQMsgProperties);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
			}
			if (m_opsErrCtx != IntPtr.Zero)
			{
				try
				{
					OpsErr.FreeCtx(ref m_opsErrCtx);
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
				}
			}
			if (!(m_opsConCtx != IntPtr.Zero))
			{
				return;
			}
			try
			{
				OpsCon.RelRef(ref m_opsConCtx);
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
			}
		}
		finally
		{
			m_disposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void SubscriptionRegister()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::SubscriptionRegister\n");
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (!m_isConSet || m_connection.m_conSignature != m_conSignature || m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			SetConnection(m_connection);
		}
		int num = 0;
		int num2 = 1;
		if (m_notificationConsumers != null)
		{
			num2 = m_notificationConsumers.Length;
			m_subscriptionName = new string[num2];
			m_pOCISubscription = new IntPtr[num2];
			for (int i = 0; i < num2; i++)
			{
				m_subscriptionName[i] = m_name + ":" + m_notificationConsumers[i];
			}
			m_pCtxNTFN = new IntPtr[num2];
		}
		else
		{
			m_subscriptionName = new string[1];
			m_pOCISubscription = new IntPtr[1];
			m_subscriptionName[0] = m_name;
			m_pCtxNTFN = new IntPtr[1];
		}
		try
		{
			num = OpsAQ.AllocSubscrHandle(m_opsConCtx, OracleDependency.s_opsEnvCtx, m_pOCISubscription, m_pCtxNTFN, num2);
			if (num == 0)
			{
				m_ntfnInfo = new NtfnInfo[num2];
				string ntfnFormatQueueName = GetNtfnFormatQueueName();
				for (int j = 0; j < num2; j++)
				{
					m_ntfnInfo[j] = new NtfnInfo();
					m_ntfnInfo[j].m_queueName = ntfnFormatQueueName;
					m_ntfnInfo[j].m_isNotifiedOnce = m_NTFNReq != null && m_NTFNReq.m_bIsNotifiedOnce;
					m_ntfnInfo[j].m_eventWrapper = m_eventWrapper;
					if (m_notificationConsumers == null)
					{
						m_ntfnInfo[j].m_consumerName = null;
					}
					else
					{
						m_ntfnInfo[j].m_consumerName = m_notificationConsumers[j];
					}
					m_subscriptionMap.Add(m_pCtxNTFN[j], m_ntfnInfo[j]);
				}
				num = OpsAQ.SubscriptionRegister(OracleDependency.s_opsEnvCtx, m_opsConCtx, m_opsErrCtx, m_pOCISubscription, m_subscriptionName, num2, (m_NTFNReq != null) ? (m_NTFNReq.m_bIsNotifiedOnce ? 1 : 0) : 0, (m_NTFNReq != null) ? (m_NTFNReq.m_bIsPersistent ? 1 : 0) : 0, (uint)((m_NTFNReq != null) ? m_NTFNReq.m_timeout : 0u), (m_NTFNReq != null) ? ((uint)m_NTFNReq.m_groupingInterval) : 600u, (m_NTFNReq != null) ? (m_NTFNReq.m_bGroupingNotificationEnabled ? 1 : 0) : 0, (int)((m_NTFNReq == null) ? OracleAQNotificationGroupingType.Summary : m_NTFNReq.m_groupingType), m_pCtxNTFN);
			}
			if (!OracleDependency.s_Listener.bListenerStart)
			{
				lock (OracleDependency.s_Listener)
				{
					if (!OracleDependency.s_Listener.bListenerStart)
					{
						uint port = 0u;
						OpsSubscr.GetPort(OracleDependency.s_opsEnvCtx, OracleDependency.s_opsErrCtx, out port);
						OracleDependency.s_Listener.port = (int)port;
						OracleDependency.s_Listener.bListenerStart = true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleAQQueue::SubscriptionRegister\n");
		}
	}

	private void SubscriptionUnRegister()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleAQQueue::SubscriptionUnRegister\n");
		}
		if (m_pCtxNTFN != null && m_pOCISubscription != null)
		{
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (!m_isConSet || m_connection.m_conSignature != m_conSignature)
			{
				SetConnection(m_connection);
			}
			int num = 0;
			int num2 = m_pOCISubscription.Length;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					NtfnInfo ntfnInfo = m_subscriptionMap[m_pCtxNTFN[i]] as NtfnInfo;
					lock (ntfnInfo)
					{
						m_subscriptionMap.Remove(m_pCtxNTFN[i]);
					}
				}
				num = OpsAQ.SubscriptionUnRegister(m_opsConCtx, m_opsErrCtx, num2, m_pOCISubscription);
				if (num == 0)
				{
					num = OpsAQ.FreeCtxNTFN(m_pCtxNTFN, num2);
					m_pCtxNTFN = null;
				}
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleAQQueue::SubscriptionUnRegister\n");
		}
	}

	private unsafe void GetModEnqOptDescAttribFlag(OracleAQEnqueueOptions aqEnqOptions, ref int enqOptsInfo)
	{
		if (aqEnqOptions.m_deliveryMode != (OracleAQMessageDeliveryMode)m_pOpoAQEnqOptionsValCtx->deliveryMode)
		{
			enqOptsInfo |= 1;
			m_pOpoAQEnqOptionsValCtx->deliveryMode = (int)aqEnqOptions.m_deliveryMode;
		}
		if (aqEnqOptions.m_visibility != (OracleAQVisibilityMode)m_pOpoAQEnqOptionsValCtx->visibility)
		{
			enqOptsInfo |= 2;
			m_pOpoAQEnqOptionsValCtx->visibility = (int)aqEnqOptions.m_visibility;
		}
	}

	private unsafe void GetModDeqOptDescAttribFlag(OracleAQDequeueOptions aqDeqOptions, ref int deqOptsInfo)
	{
		if (!string.Equals(aqDeqOptions.m_consumerName, m_opoAQDeqOptionsRefCtx.consumerName))
		{
			deqOptsInfo |= 1;
			m_opoAQDeqOptionsRefCtx.consumerName = aqDeqOptions.m_consumerName;
		}
		if (!string.Equals(aqDeqOptions.m_correlation, m_opoAQDeqOptionsRefCtx.correlationId))
		{
			deqOptsInfo |= 2;
			m_opoAQDeqOptionsRefCtx.correlationId = aqDeqOptions.m_correlation;
		}
		if (aqDeqOptions.m_deliveryMode != (OracleAQMessageDeliveryMode)m_pOpoAQDeqOptionsValCtx->deliveryMode)
		{
			deqOptsInfo |= 4;
			m_pOpoAQDeqOptionsValCtx->deliveryMode = (int)aqDeqOptions.m_deliveryMode;
		}
		if (aqDeqOptions.m_dequeueMode != (OracleAQDequeueMode)m_pOpoAQDeqOptionsValCtx->deqMode)
		{
			deqOptsInfo |= 8;
			m_pOpoAQDeqOptionsValCtx->deqMode = (int)aqDeqOptions.m_dequeueMode;
		}
		if (!ArraysEqual(aqDeqOptions.m_messageId, m_opoAQDeqOptionsRefCtx.msgId))
		{
			deqOptsInfo |= 16;
			if (aqDeqOptions.m_messageId == null)
			{
				m_opoAQDeqOptionsRefCtx.msgId = null;
				m_pOpoAQDeqOptionsValCtx->msgIdSize = 0;
			}
			else
			{
				m_pOpoAQDeqOptionsValCtx->msgIdSize = aqDeqOptions.m_messageId.Length;
				m_opoAQDeqOptionsRefCtx.msgId = new byte[m_pOpoAQDeqOptionsValCtx->msgIdSize];
				Array.Copy(aqDeqOptions.m_messageId, m_opoAQDeqOptionsRefCtx.msgId, aqDeqOptions.m_messageId.Length);
			}
		}
		if (aqDeqOptions.m_navigationMode != (OracleAQNavigationMode)m_pOpoAQDeqOptionsValCtx->navigation)
		{
			deqOptsInfo |= 32;
			m_pOpoAQDeqOptionsValCtx->navigation = (int)aqDeqOptions.m_navigationMode;
		}
		if (aqDeqOptions.m_visibility != (OracleAQVisibilityMode)m_pOpoAQDeqOptionsValCtx->visibility)
		{
			deqOptsInfo |= 64;
			m_pOpoAQDeqOptionsValCtx->visibility = (int)aqDeqOptions.m_visibility;
		}
		if (aqDeqOptions.m_wait != m_pOpoAQDeqOptionsValCtx->wait)
		{
			deqOptsInfo |= 128;
			m_pOpoAQDeqOptionsValCtx->wait = aqDeqOptions.m_wait;
		}
	}

	private bool ArraysEqual(byte[] ba1, byte[] ba2)
	{
		if (ba1 == null && ba2 == null)
		{
			return true;
		}
		if (ba1 == null && ba2 != null)
		{
			return false;
		}
		if (ba1 != null && ba2 == null)
		{
			return false;
		}
		if (ba1.Length != ba2.Length)
		{
			return false;
		}
		for (int i = 0; i < ba1.Length; i++)
		{
			if (ba1[i] != ba2[i])
			{
				return false;
			}
		}
		return true;
	}

	private string GetNtfnFormatQueueName()
	{
		string userID = m_connection.m_opoConCtx.opoConRefCtx.userID;
		string qName = null;
		string sName = null;
		try
		{
			m_name.Trim();
			if (-1 != m_name.IndexOf("."))
			{
				if (-1 != m_name.IndexOf("\".\""))
				{
					int num = m_name.IndexOf("\".\"");
					sName = m_name.Substring(0, num + 1);
					qName = m_name.Substring(num + 2).ToUpper();
				}
				else if (-1 == m_name.IndexOf("\""))
				{
					int num2 = m_name.IndexOf('.');
					sName = "\"" + m_name.Substring(0, num2).ToUpper() + "\"";
					qName = "\"" + m_name.Substring(num2 + 1).ToUpper() + "\"";
				}
				else
				{
					int num3 = m_name.IndexOf("\"");
					int num4 = m_name.LastIndexOf("\"");
					bool flag = false;
					if (-1 != m_name.IndexOf("\"."))
					{
						int num5 = m_name.LastIndexOf("\".");
						if (num5 >= num4)
						{
							sName = m_name.Substring(0, num5 + 1);
							qName = "\"" + m_name.Substring(num5 + 2).ToUpper() + "\"";
						}
						else
						{
							flag = true;
						}
					}
					if (-1 != m_name.IndexOf(".\""))
					{
						int num6 = m_name.IndexOf(".\"");
						if (num6 + 1 <= num3)
						{
							sName = "\"" + m_name.Substring(0, num6).ToUpper() + "\"";
							qName = m_name.Substring(num6 + 1).ToUpper();
						}
						else if (flag)
						{
							GetDefaultNtfnFormatQNameAndSName(userID, ref qName, ref sName);
						}
					}
				}
			}
			else if (m_name.StartsWith("\"") && m_name.EndsWith("\""))
			{
				if (userID.StartsWith("\"") && userID.EndsWith("\""))
				{
					sName = userID;
					qName = m_name.ToUpper();
				}
				else
				{
					sName = "\"" + userID.ToUpper() + "\"";
					qName = m_name.ToUpper();
				}
			}
			else
			{
				GetDefaultNtfnFormatQNameAndSName(userID, ref qName, ref sName);
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) OracleAQQueue::GetNtfnFormatQueueName():" + ex.ToString() + "\n");
			}
			GetDefaultNtfnFormatQNameAndSName(userID, ref qName, ref sName);
		}
		return sName + "." + qName;
	}

	private void GetDefaultNtfnFormatQNameAndSName(string schemaName, ref string qName, ref string sName)
	{
		if (schemaName.StartsWith("\"") && schemaName.EndsWith("\""))
		{
			sName = schemaName;
			qName = "\"" + m_name.ToUpper() + "\"";
		}
		else
		{
			sName = "\"" + schemaName.ToUpper() + "\"";
			qName = "\"" + m_name.ToUpper() + "\"";
		}
	}

	~OracleAQQueue()
	{
		Dispose(disposing: false);
	}
}

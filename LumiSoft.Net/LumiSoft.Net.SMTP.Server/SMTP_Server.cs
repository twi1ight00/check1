using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LumiSoft.Net.AUTH;

namespace LumiSoft.Net.SMTP.Server;

public class SMTP_Server : SocketServer<SMTP_Session>
{
	private int m_MaxConnectionsPerIP = 0;

	private int m_MaxMessageSize = 1000000;

	private int m_MaxRecipients = 100;

	private SaslAuthTypes m_SupportedAuth = SaslAuthTypes.All;

	private string m_GreetingText = "";

	public string GreetingText
	{
		get
		{
			return m_GreetingText;
		}
		set
		{
			m_GreetingText = value;
		}
	}

	public int MaxConnectionsPerIP
	{
		get
		{
			return m_MaxConnectionsPerIP;
		}
		set
		{
			m_MaxConnectionsPerIP = value;
		}
	}

	public int MaxMessageSize
	{
		get
		{
			return m_MaxMessageSize;
		}
		set
		{
			m_MaxMessageSize = value;
		}
	}

	public int MaxRecipients
	{
		get
		{
			return m_MaxRecipients;
		}
		set
		{
			m_MaxRecipients = value;
		}
	}

	public SaslAuthTypes SupportedAuthentications
	{
		get
		{
			return m_SupportedAuth;
		}
		set
		{
			m_SupportedAuth = value;
		}
	}

	public event ValidateIPHandler ValidateIPAddress = null;

	public event AuthUserEventHandler AuthUser = null;

	public event ValidateMailFromHandler ValidateMailFrom = null;

	public event ValidateMailToHandler ValidateMailTo = null;

	public event ValidateMailboxSize ValidateMailboxSize = null;

	public event GetMessageStoreStreamHandler GetMessageStoreStream = null;

	public event MessageStoringCompletedHandler MessageStoringCompleted = null;

	[Obsolete("Use GetMessageStoreStream and MessageStoringCompleted events instead !", true)]
	public event NewMailEventHandler StoreMessage = null;

	public event LogEventHandler SessionLog = null;

	public SMTP_Server()
	{
		base.BindInfo = new BindInfo[1]
		{
			new BindInfo(IPAddress.Any, 25, ssl: false, null)
		};
	}

	protected override void InitNewSession(Socket socket, BindInfo bindInfo)
	{
		if (m_MaxConnectionsPerIP > 0)
		{
			lock (base.Sessions)
			{
				int num = 0;
				foreach (SMTP_Session value in base.Sessions.Values)
				{
					IPEndPoint remoteEndPoint = value.RemoteEndPoint;
					if (remoteEndPoint != null && remoteEndPoint.Address.Equals(((IPEndPoint)socket.RemoteEndPoint).Address))
					{
						num++;
					}
					if (num >= m_MaxConnectionsPerIP)
					{
						socket.Send(Encoding.ASCII.GetBytes("421 Maximum connections from your IP address is exceeded, try again later !\r\n"));
						socket.Shutdown(SocketShutdown.Both);
						socket.Close();
						return;
					}
				}
			}
		}
		SocketLogger logWriter = new SocketLogger(socket, this.SessionLog);
		SMTP_Session sMTP_Session2 = new SMTP_Session(socket, bindInfo, this, logWriter);
	}

	internal ValidateIP_EventArgs OnValidate_IpAddress(SMTP_Session session)
	{
		ValidateIP_EventArgs validateIP_EventArgs = new ValidateIP_EventArgs(session.LocalEndPoint, session.RemoteEndPoint);
		if (this.ValidateIPAddress != null)
		{
			this.ValidateIPAddress(this, validateIP_EventArgs);
		}
		session.Tag = validateIP_EventArgs.SessionTag;
		return validateIP_EventArgs;
	}

	internal AuthUser_EventArgs OnAuthUser(SMTP_Session session, string userName, string passwordData, string data, AuthType authType)
	{
		AuthUser_EventArgs authUser_EventArgs = new AuthUser_EventArgs(session, userName, passwordData, data, authType);
		if (this.AuthUser != null)
		{
			this.AuthUser(this, authUser_EventArgs);
		}
		return authUser_EventArgs;
	}

	internal ValidateSender_EventArgs OnValidate_MailFrom(SMTP_Session session, string reverse_path, string email)
	{
		ValidateSender_EventArgs validateSender_EventArgs = new ValidateSender_EventArgs(session, email);
		if (this.ValidateMailFrom != null)
		{
			this.ValidateMailFrom(this, validateSender_EventArgs);
		}
		return validateSender_EventArgs;
	}

	internal ValidateRecipient_EventArgs OnValidate_MailTo(SMTP_Session session, string forward_path, string email, bool authenticated)
	{
		ValidateRecipient_EventArgs validateRecipient_EventArgs = new ValidateRecipient_EventArgs(session, email, authenticated);
		if (this.ValidateMailTo != null)
		{
			this.ValidateMailTo(this, validateRecipient_EventArgs);
		}
		return validateRecipient_EventArgs;
	}

	internal bool Validate_MailBoxSize(SMTP_Session session, string eAddress, long messageSize)
	{
		ValidateMailboxSize_EventArgs validateMailboxSize_EventArgs = new ValidateMailboxSize_EventArgs(session, eAddress, messageSize);
		if (this.ValidateMailboxSize != null)
		{
			this.ValidateMailboxSize(this, validateMailboxSize_EventArgs);
		}
		return validateMailboxSize_EventArgs.IsValid;
	}

	internal GetMessageStoreStream_eArgs OnGetMessageStoreStream(SMTP_Session session)
	{
		GetMessageStoreStream_eArgs getMessageStoreStream_eArgs = new GetMessageStoreStream_eArgs(session);
		if (this.GetMessageStoreStream != null)
		{
			this.GetMessageStoreStream(this, getMessageStoreStream_eArgs);
		}
		return getMessageStoreStream_eArgs;
	}

	internal MessageStoringCompleted_eArgs OnMessageStoringCompleted(SMTP_Session session, string errorText, Stream messageStream)
	{
		MessageStoringCompleted_eArgs messageStoringCompleted_eArgs = new MessageStoringCompleted_eArgs(session, errorText, messageStream);
		if (this.MessageStoringCompleted != null)
		{
			this.MessageStoringCompleted(this, messageStoringCompleted_eArgs);
		}
		if (this.StoreMessage != null && messageStream is MemoryStream)
		{
			messageStream.Position = 0L;
			NewMail_EventArgs newMail_EventArgs = new NewMail_EventArgs(session, (MemoryStream)messageStream);
			this.StoreMessage(this, newMail_EventArgs);
			messageStoringCompleted_eArgs.ServerReply.ErrorReply = newMail_EventArgs.ServerReply.ErrorReply;
			messageStoringCompleted_eArgs.ServerReply.ReplyText = newMail_EventArgs.ServerReply.ReplyText;
			messageStoringCompleted_eArgs.ServerReply.SmtpReplyCode = newMail_EventArgs.ServerReply.SmtpReplyCode;
		}
		return messageStoringCompleted_eArgs;
	}
}

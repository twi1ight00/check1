using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LumiSoft.Net.AUTH;

namespace LumiSoft.Net.POP3.Server;

public class POP3_Server : SocketServer<POP3_Session>
{
	private int m_MaxConnectionsPerIP = 0;

	private SaslAuthTypes m_SupportedAuth = SaslAuthTypes.All;

	private string m_GreetingText = "";

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

	public event ValidateIPHandler ValidateIPAddress = null;

	public event AuthUserEventHandler AuthUser = null;

	public event EventHandler SessionEnd = null;

	public event EventHandler SessionResetted = null;

	public event GetMessagesInfoHandler GetMessgesList = null;

	[Obsolete("Use GetMessageStream instead !", true)]
	public event MessageHandler GetMessage = null;

	public event GetMessageStreamHandler GetMessageStream = null;

	public event MessageHandler DeleteMessage = null;

	public event MessageHandler GetTopLines = null;

	public event LogEventHandler SessionLog = null;

	public POP3_Server()
	{
		base.BindInfo = new BindInfo[1]
		{
			new BindInfo(IPAddress.Any, 110, ssl: false, null)
		};
	}

	protected override void InitNewSession(Socket socket, BindInfo bindInfo)
	{
		if (m_MaxConnectionsPerIP > 0)
		{
			lock (base.Sessions)
			{
				int num = 0;
				foreach (POP3_Session value in base.Sessions.Values)
				{
					IPEndPoint remoteEndPoint = value.RemoteEndPoint;
					if (remoteEndPoint != null && remoteEndPoint.Address.Equals(((IPEndPoint)socket.RemoteEndPoint).Address))
					{
						num++;
					}
					if (num >= m_MaxConnectionsPerIP)
					{
						socket.Send(Encoding.ASCII.GetBytes("-ERR Maximum connections from your IP address is exceeded, try again later !\r\n"));
						socket.Shutdown(SocketShutdown.Both);
						socket.Close();
						return;
					}
				}
			}
		}
		SocketLogger logWriter = new SocketLogger(socket, this.SessionLog);
		POP3_Session pOP3_Session2 = new POP3_Session(socket, bindInfo, this, logWriter);
	}

	internal bool IsUserLoggedIn(string userName)
	{
		lock (base.Sessions)
		{
			foreach (POP3_Session value in base.Sessions.Values)
			{
				if (value.UserName.ToLower() == userName.ToLower())
				{
					return true;
				}
			}
		}
		return false;
	}

	internal virtual bool OnValidate_IpAddress(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
	{
		ValidateIP_EventArgs validateIP_EventArgs = new ValidateIP_EventArgs(localEndPoint, remoteEndPoint);
		if (this.ValidateIPAddress != null)
		{
			this.ValidateIPAddress(this, validateIP_EventArgs);
		}
		return validateIP_EventArgs.Validated;
	}

	internal virtual AuthUser_EventArgs OnAuthUser(POP3_Session session, string userName, string passwData, string data, AuthType authType)
	{
		AuthUser_EventArgs authUser_EventArgs = new AuthUser_EventArgs(session, userName, passwData, data, authType);
		if (this.AuthUser != null)
		{
			this.AuthUser(this, authUser_EventArgs);
		}
		return authUser_EventArgs;
	}

	internal virtual void OnGetMessagesInfo(POP3_Session session, POP3_Messages messages)
	{
		GetMessagesInfo_EventArgs e = new GetMessagesInfo_EventArgs(session, messages, session.UserName);
		if (this.GetMessgesList != null)
		{
			this.GetMessgesList(this, e);
		}
	}

	internal POP3_eArgs_GetMessageStream OnGetMessageStream(POP3_Session session, POP3_Message messageInfo)
	{
		POP3_eArgs_GetMessageStream pOP3_eArgs_GetMessageStream = new POP3_eArgs_GetMessageStream(session, messageInfo);
		if (this.GetMessageStream != null)
		{
			this.GetMessageStream(this, pOP3_eArgs_GetMessageStream);
		}
		return pOP3_eArgs_GetMessageStream;
	}

	internal virtual byte[] OnGetMail(POP3_Session session, POP3_Message message, Socket sessionSocket)
	{
		POP3_Message_EventArgs pOP3_Message_EventArgs = new POP3_Message_EventArgs(session, message, sessionSocket);
		if (this.GetMessage != null)
		{
			this.GetMessage(this, pOP3_Message_EventArgs);
		}
		return pOP3_Message_EventArgs.MessageData;
	}

	internal virtual bool OnDeleteMessage(POP3_Session session, POP3_Message message)
	{
		POP3_Message_EventArgs e = new POP3_Message_EventArgs(session, message, null);
		if (this.DeleteMessage != null)
		{
			this.DeleteMessage(this, e);
		}
		return true;
	}

	internal byte[] OnGetTopLines(POP3_Session session, POP3_Message message, int nLines)
	{
		POP3_Message_EventArgs pOP3_Message_EventArgs = new POP3_Message_EventArgs(session, message, null, nLines);
		if (this.GetTopLines != null)
		{
			this.GetTopLines(this, pOP3_Message_EventArgs);
		}
		return pOP3_Message_EventArgs.MessageData;
	}

	internal void OnSessionEnd(object session)
	{
		if (this.SessionEnd != null)
		{
			this.SessionEnd(session, new EventArgs());
		}
	}

	internal void OnSessionResetted(object session)
	{
		if (this.SessionResetted != null)
		{
			this.SessionResetted(session, new EventArgs());
		}
	}
}

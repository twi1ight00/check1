using System.Net.Sockets;

namespace LumiSoft.Net.POP3.Server;

public class POP3_Message_EventArgs
{
	private POP3_Session m_pSession = null;

	private POP3_Message m_pMessage = null;

	private Socket m_pSocket = null;

	private byte[] m_MessageData = null;

	private int m_Lines = 0;

	public POP3_Session Session => m_pSession;

	public POP3_Message Message => m_pMessage;

	public string MessageID => m_pMessage.MessageID;

	public string MessageUID => m_pMessage.MessageUID;

	public byte[] MessageData
	{
		get
		{
			return m_MessageData;
		}
		set
		{
			m_MessageData = value;
		}
	}

	public int Lines => m_Lines;

	public string UserName => m_pSession.UserName;

	public POP3_Message_EventArgs(POP3_Session session, POP3_Message message, Socket socket)
	{
		m_pSession = session;
		m_pMessage = message;
		m_pSocket = socket;
	}

	public POP3_Message_EventArgs(POP3_Session session, POP3_Message message, Socket socket, int nLines)
	{
		m_pSession = session;
		m_pMessage = message;
		m_pSocket = socket;
		m_Lines = nLines;
	}
}

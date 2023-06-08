namespace LumiSoft.Net.IMAP.Server;

public class Message_EventArgs
{
	private IMAP_Message m_pMessage = null;

	private string m_Folder = "";

	private string m_CopyLocation = "";

	private byte[] m_MessageData = null;

	private bool m_HeadersOnly = false;

	private string m_ErrorText = null;

	public string Folder => m_Folder;

	public IMAP_Message Message => m_pMessage;

	public string CopyLocation => m_CopyLocation;

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

	public bool HeadersOnly => m_HeadersOnly;

	public string ErrorText
	{
		get
		{
			return m_ErrorText;
		}
		set
		{
			m_ErrorText = value;
		}
	}

	public Message_EventArgs(string folder, IMAP_Message msg)
	{
		m_Folder = folder;
		m_pMessage = msg;
	}

	public Message_EventArgs(string folder, IMAP_Message msg, string copyLocation)
	{
		m_Folder = folder;
		m_pMessage = msg;
		m_CopyLocation = copyLocation;
	}

	public Message_EventArgs(string folder, IMAP_Message msg, bool headersOnly)
	{
		m_Folder = folder;
		m_pMessage = msg;
		m_HeadersOnly = headersOnly;
	}
}

namespace LumiSoft.Net.POP3.Server;

public class POP3_Message
{
	private POP3_Messages m_pMessages = null;

	private string m_MessageID = "";

	private string m_MessageUID = "";

	private int m_MessageSize = 0;

	private bool m_MarkedForDelete = false;

	private object m_Tag = null;

	public string MessageID
	{
		get
		{
			return m_MessageID;
		}
		set
		{
			m_MessageID = value;
		}
	}

	public string MessageUID
	{
		get
		{
			return m_MessageUID;
		}
		set
		{
			m_MessageUID = value;
		}
	}

	public int MessageSize
	{
		get
		{
			return m_MessageSize;
		}
		set
		{
			m_MessageSize = value;
		}
	}

	public bool MarkedForDelete
	{
		get
		{
			return m_MarkedForDelete;
		}
		set
		{
			m_MarkedForDelete = value;
		}
	}

	public int MessageNr => m_pMessages.Messages.IndexOf(this) + 1;

	public object Tag
	{
		get
		{
			return m_Tag;
		}
		set
		{
			m_Tag = value;
		}
	}

	public POP3_Message(POP3_Messages messages)
	{
		m_pMessages = messages;
	}
}

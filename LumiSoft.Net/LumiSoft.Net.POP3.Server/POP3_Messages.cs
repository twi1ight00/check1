using System.Collections;

namespace LumiSoft.Net.POP3.Server;

public class POP3_Messages
{
	private ArrayList m_POP3_Messages = null;

	public int Count
	{
		get
		{
			int num = 0;
			foreach (POP3_Message pOP3_Message in m_POP3_Messages)
			{
				if (!pOP3_Message.MarkedForDelete)
				{
					num++;
				}
			}
			return num;
		}
	}

	public POP3_Message[] ActiveMessages
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			foreach (POP3_Message pOP3_Message in m_POP3_Messages)
			{
				if (!pOP3_Message.MarkedForDelete)
				{
					arrayList.Add(pOP3_Message);
				}
			}
			POP3_Message[] array = new POP3_Message[arrayList.Count];
			arrayList.CopyTo(array);
			return array;
		}
	}

	internal ArrayList Messages => m_POP3_Messages;

	internal POP3_Message this[int messageNr] => (POP3_Message)m_POP3_Messages[messageNr - 1];

	public POP3_Messages()
	{
		m_POP3_Messages = new ArrayList();
	}

	public void AddMessage(string messageID, string uid, int messageSize)
	{
		AddMessage(messageID, uid, messageSize, null);
	}

	public void AddMessage(string messageID, string uid, int messageSize, object tag)
	{
		POP3_Message pOP3_Message = new POP3_Message(this);
		pOP3_Message.MessageUID = uid;
		pOP3_Message.MessageID = messageID;
		pOP3_Message.MessageSize = messageSize;
		pOP3_Message.Tag = tag;
		m_POP3_Messages.Add(pOP3_Message);
	}

	public POP3_Message GetMessage(int messageNr)
	{
		return (POP3_Message)m_POP3_Messages[messageNr];
	}

	public bool MessageExists(int nr)
	{
		try
		{
			if (nr > 0 && nr <= m_POP3_Messages.Count)
			{
				POP3_Message pOP3_Message = (POP3_Message)m_POP3_Messages[nr - 1];
				if (!pOP3_Message.MarkedForDelete)
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	public int GetTotalMessagesSize()
	{
		int num = 0;
		foreach (POP3_Message pOP3_Message in m_POP3_Messages)
		{
			if (!pOP3_Message.MarkedForDelete)
			{
				num += pOP3_Message.MessageSize;
			}
		}
		return num;
	}

	public void ResetDeleteFlags()
	{
		foreach (POP3_Message pOP3_Message in m_POP3_Messages)
		{
			pOP3_Message.MarkedForDelete = false;
		}
	}
}

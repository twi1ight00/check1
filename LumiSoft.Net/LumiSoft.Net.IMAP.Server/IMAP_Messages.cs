using System;
using System.Collections;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Messages
{
	private SortedList m_pMessages = null;

	private string m_Folder = "";

	private string m_Error = null;

	private bool m_ReadOnly = false;

	private int m_FolderUID = 124221;

	public IMAP_Message this[int msgNo] => (IMAP_Message)m_pMessages.GetValueList()[msgNo];

	public int FirstUnseen
	{
		get
		{
			for (int i = 0; i < m_pMessages.Count; i++)
			{
				IMAP_Message iMAP_Message = (IMAP_Message)m_pMessages.GetValueList()[i];
				if ((IMAP_MessageFlags.Seen & iMAP_Message.Flags) == 0)
				{
					return i + 1;
				}
			}
			return 0;
		}
	}

	public int UnSeenCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < m_pMessages.Count; i++)
			{
				IMAP_Message iMAP_Message = (IMAP_Message)m_pMessages.GetValueList()[i];
				if ((IMAP_MessageFlags.Seen & iMAP_Message.Flags) == 0)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int RecentCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < m_pMessages.Count; i++)
			{
				IMAP_Message iMAP_Message = (IMAP_Message)m_pMessages.GetValueList()[i];
				if ((IMAP_MessageFlags.Recent & iMAP_Message.Flags) != 0)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int DeleteCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < m_pMessages.Count; i++)
			{
				IMAP_Message iMAP_Message = (IMAP_Message)m_pMessages.GetValueList()[i];
				if ((IMAP_MessageFlags.Deleted & iMAP_Message.Flags) != 0)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int Count => m_pMessages.Count;

	public string Mailbox => m_Folder;

	public int MailboxUID
	{
		get
		{
			return m_FolderUID;
		}
		set
		{
			m_FolderUID = value;
		}
	}

	public int UID_Next
	{
		get
		{
			if (m_pMessages.Count > 0)
			{
				return ((IMAP_Message)m_pMessages.GetValueList()[m_pMessages.Count - 1]).MessageUID + 1;
			}
			return 1;
		}
	}

	public bool ReadOnly
	{
		get
		{
			return m_ReadOnly;
		}
		set
		{
			m_ReadOnly = value;
		}
	}

	public string ErrorText
	{
		get
		{
			return m_Error;
		}
		set
		{
			m_Error = value;
		}
	}

	public IMAP_Messages(string folder)
	{
		m_Folder = folder;
		m_pMessages = new SortedList();
	}

	public void AddMessage(string messageID, int UID, IMAP_MessageFlags flags, long size, DateTime date)
	{
		m_pMessages.Add(UID, new IMAP_Message(this, messageID, UID, flags, size, date));
	}

	public void RemoveMessage(IMAP_Message msg)
	{
		m_pMessages.RemoveAt(msg.MessageNo - 1);
	}

	public int IndexOf(IMAP_Message message)
	{
		return m_pMessages.IndexOfValue(message) + 1;
	}

	public IMAP_Message[] GetDeleteMessages()
	{
		ArrayList arrayList = new ArrayList();
		foreach (IMAP_Message value in m_pMessages.GetValueList())
		{
			if ((IMAP_MessageFlags.Deleted & value.Flags) != 0)
			{
				arrayList.Add(value);
			}
		}
		IMAP_Message[] array = new IMAP_Message[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}
}

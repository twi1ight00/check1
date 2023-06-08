using System;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Message
{
	private IMAP_Messages m_Messages = null;

	private string m_MessageID = "";

	private int m_UID = 1;

	private IMAP_MessageFlags m_Flags;

	private long m_Size = 0L;

	private DateTime m_InternalDate;

	public int MessageNo
	{
		get
		{
			if (m_Messages != null)
			{
				return m_Messages.IndexOf(this);
			}
			return -1;
		}
	}

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

	public int MessageUID => m_UID;

	public IMAP_MessageFlags Flags => m_Flags;

	public long Size => m_Size;

	public DateTime Date => m_InternalDate;

	internal IMAP_Message(IMAP_Messages messages, string messageID, int UID, IMAP_MessageFlags flags, long size, DateTime internalDate)
	{
		m_Messages = messages;
		m_MessageID = messageID;
		m_UID = UID;
		m_Flags = flags;
		m_Size = size;
		m_InternalDate = internalDate;
	}

	public string FlagsToString()
	{
		return IMAP_Utils.MessageFlagsToString(Flags);
	}

	internal void SetFlags(IMAP_MessageFlags flags)
	{
		m_Flags = flags;
	}
}

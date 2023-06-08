using System;
using System.IO;
using System.Text;
using LumiSoft.Net.IMAP.Server;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Client;

public class IMAP_FetchItem
{
	private int m_No = 0;

	private int m_UID = 0;

	private int m_Size = 0;

	private string m_InternalDate = "";

	private byte[] m_Data = null;

	private IMAP_FetchItem_Flags m_FetchFlags = IMAP_FetchItem_Flags.MessageFlags;

	private IMAP_MessageFlags m_Flags = IMAP_MessageFlags.Recent;

	private string m_Envelope = "";

	private string m_BodyStructure = "";

	public IMAP_FetchItem_Flags FetchFlags => m_FetchFlags;

	public int MessageNumber => m_No;

	public int UID
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.UID) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.UID wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return m_UID;
		}
	}

	public int Size
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.Size) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.Size wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return m_Size;
		}
	}

	public DateTime InternalDate
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.InternalDate) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.InternalDate wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return IMAP_Utils.ParseDate(m_InternalDate);
		}
	}

	public IMAP_MessageFlags MessageFlags
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.MessageFlags) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.MessageFlags wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return m_Flags;
		}
	}

	public IMAP_Envelope Envelope
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.Envelope) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.Envelope wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			IMAP_Envelope iMAP_Envelope = new IMAP_Envelope();
			iMAP_Envelope.Parse(m_Envelope);
			return iMAP_Envelope;
		}
	}

	public IMAP_BODY BodyStructure
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.BodyStructure) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.BodyStructure wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			IMAP_BODY iMAP_BODY = new IMAP_BODY();
			iMAP_BODY.Parse(m_BodyStructure);
			return iMAP_BODY;
		}
	}

	public byte[] HeaderData
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.Header) == 0 && (m_FetchFlags & IMAP_FetchItem_Flags.Message) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.Header wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			if ((m_FetchFlags & IMAP_FetchItem_Flags.Message) != 0)
			{
				return Encoding.ASCII.GetBytes(MimeUtils.ParseHeaders(new MemoryStream(m_Data)));
			}
			return m_Data;
		}
	}

	public byte[] MessageData
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.Message) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.Message wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return m_Data;
		}
	}

	public bool IsNewMessage
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.MessageFlags) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.MessageFlags wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return (m_Flags & IMAP_MessageFlags.Seen) == 0;
		}
	}

	public bool IsAnswered
	{
		get
		{
			if ((m_FetchFlags & IMAP_FetchItem_Flags.MessageFlags) == 0)
			{
				throw new Exception("IMAP_FetchItem_Flags.MessageFlags wasn't specified in FetchMessages command, becuse of it this property is unavailable.");
			}
			return (m_Flags & IMAP_MessageFlags.Answered) != 0;
		}
	}

	[Obsolete("Use HeaderData or MessageData data instead.")]
	public byte[] Data => m_Data;

	[Obsolete("Use FetchFlags property instead !")]
	public bool HeadersOnly => (m_FetchFlags & IMAP_FetchItem_Flags.Header) != 0;

	internal IMAP_FetchItem(int no, int uid, int size, byte[] data, IMAP_MessageFlags flags, string internalDate, string envelope, string bodyStructure, IMAP_FetchItem_Flags fetchFlags)
	{
		m_No = no;
		m_UID = uid;
		m_Size = size;
		m_Data = data;
		m_Flags = flags;
		m_InternalDate = internalDate;
		m_Envelope = envelope;
		m_FetchFlags = fetchFlags;
		m_BodyStructure = bodyStructure;
	}
}

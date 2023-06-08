using System;
using System.IO;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_eArgs_MessageItems
{
	private IMAP_Session m_pSession = null;

	private IMAP_Message m_pMessageInfo = null;

	private IMAP_MessageItems_enum m_MessageItems = IMAP_MessageItems_enum.Message;

	private bool m_CloseMessageStream = true;

	private Stream m_MessageStream = null;

	private long m_MessageStartOffset = 0L;

	private byte[] m_Header = null;

	private string m_Envelope = null;

	private string m_BodyStructure = null;

	private bool m_MessageExists = true;

	public IMAP_Session Session => m_pSession;

	public IMAP_Message MessageInfo => m_pMessageInfo;

	public IMAP_MessageItems_enum MessageItems => m_MessageItems;

	public bool CloseMessageStream
	{
		get
		{
			return m_CloseMessageStream;
		}
		set
		{
			m_CloseMessageStream = value;
		}
	}

	public Stream MessageStream
	{
		get
		{
			if (m_MessageStream != null)
			{
				m_MessageStream.Position = m_MessageStartOffset;
			}
			return m_MessageStream;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Property MessageStream value can't be null !");
			}
			if (!value.CanSeek)
			{
				throw new Exception("Stream must support seeking !");
			}
			m_MessageStream = value;
			m_MessageStartOffset = m_MessageStream.Position;
		}
	}

	public long MessageSize
	{
		get
		{
			if (m_MessageStream == null)
			{
				throw new Exception("You must set MessageStream property first to use this property !");
			}
			return m_MessageStream.Length - m_MessageStream.Position;
		}
	}

	public byte[] Header
	{
		get
		{
			return m_Header;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Property Header value can't be null !");
			}
			m_Header = value;
		}
	}

	public string Envelope
	{
		get
		{
			return m_Envelope;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Property Envelope value can't be null !");
			}
			m_Envelope = value;
		}
	}

	public string BodyStructure
	{
		get
		{
			return m_BodyStructure;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Property BodyStructure value can't be null !");
			}
			m_BodyStructure = value;
		}
	}

	public bool MessageExists
	{
		get
		{
			return m_MessageExists;
		}
		set
		{
			m_MessageExists = value;
		}
	}

	public IMAP_eArgs_MessageItems(IMAP_Session session, IMAP_Message messageInfo, IMAP_MessageItems_enum messageItems)
	{
		m_pSession = session;
		m_pMessageInfo = messageInfo;
		m_MessageItems = messageItems;
	}

	~IMAP_eArgs_MessageItems()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (m_CloseMessageStream && m_MessageStream != null)
		{
			m_MessageStream.Dispose();
			m_MessageStream = null;
		}
	}

	internal void Validate()
	{
		if ((m_MessageItems & IMAP_MessageItems_enum.BodyStructure) != 0 && m_BodyStructure == null)
		{
			throw new Exception("IMAP BODYSTRUCTURE is required, but not provided to IMAP server component !");
		}
		if ((m_MessageItems & IMAP_MessageItems_enum.Envelope) != 0 && m_Envelope == null)
		{
			throw new Exception("IMAP ENVELOPE is required, but not provided to IMAP server component  !");
		}
		if ((m_MessageItems & IMAP_MessageItems_enum.Header) != 0 && m_Header == null)
		{
			throw new Exception("Message header is required, but not provided to IMAP server component  !");
		}
		if ((m_MessageItems & IMAP_MessageItems_enum.Message) != 0 && m_MessageStream == null)
		{
			throw new Exception("Full message is required, but not provided to IMAP server component  !");
		}
	}
}

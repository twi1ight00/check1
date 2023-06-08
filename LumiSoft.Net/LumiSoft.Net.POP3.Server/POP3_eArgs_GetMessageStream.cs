using System;
using System.IO;

namespace LumiSoft.Net.POP3.Server;

public class POP3_eArgs_GetMessageStream
{
	private POP3_Session m_pSession = null;

	private POP3_Message m_pMessageInfo = null;

	private bool m_CloseMessageStream = true;

	private Stream m_MessageStream = null;

	private long m_MessageStartOffset = 0L;

	private bool m_MessageExists = true;

	public POP3_Session Session => m_pSession;

	public POP3_Message MessageInfo => m_pMessageInfo;

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

	public POP3_eArgs_GetMessageStream(POP3_Session session, POP3_Message messageInfo)
	{
		m_pSession = session;
		m_pMessageInfo = messageInfo;
	}
}

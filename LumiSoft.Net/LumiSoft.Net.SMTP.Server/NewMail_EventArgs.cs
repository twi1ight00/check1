using System;
using System.IO;

namespace LumiSoft.Net.SMTP.Server;

public class NewMail_EventArgs
{
	private SMTP_Session m_pSession = null;

	private MemoryStream m_MsgStream = null;

	private SmtpServerReply m_pCustomReply = null;

	private string m_ReplyText = "";

	public SMTP_Session Session => m_pSession;

	public MemoryStream MessageStream => m_MsgStream;

	public long MessageSize
	{
		get
		{
			long result = 0L;
			if (m_MsgStream != null)
			{
				result = m_MsgStream.Length;
			}
			return result;
		}
	}

	public string MailFrom => m_pSession.MailFrom;

	public string[] MailTo => m_pSession.MailTo;

	public SmtpServerReply ServerReply => m_pCustomReply;

	[Obsolete("Use ServerReply property instead !")]
	public string ReplyText
	{
		get
		{
			return m_ReplyText;
		}
		set
		{
			m_ReplyText = value.Replace("\r", "").Replace("\n", "");
		}
	}

	public NewMail_EventArgs(SMTP_Session session, MemoryStream msgStream)
	{
		m_pSession = session;
		m_MsgStream = msgStream;
		m_pCustomReply = new SmtpServerReply();
	}
}

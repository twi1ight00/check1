using System.IO;

namespace LumiSoft.Net.SMTP.Server;

public class MessageStoringCompleted_eArgs
{
	private SMTP_Session m_pSession = null;

	private string m_ErrorText = null;

	private Stream m_pMessageStream = null;

	private SmtpServerReply m_pCustomReply = null;

	public SMTP_Session Session => m_pSession;

	public string ErrorText => m_ErrorText;

	public Stream MessageStream => m_pMessageStream;

	public SmtpServerReply ServerReply => m_pCustomReply;

	public MessageStoringCompleted_eArgs(SMTP_Session session, string errorText, Stream messageStream)
	{
		m_pSession = session;
		m_ErrorText = errorText;
		m_pMessageStream = messageStream;
		m_pCustomReply = new SmtpServerReply();
	}
}

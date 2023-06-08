namespace LumiSoft.Net.SMTP.Server;

public class ValidateRecipient_EventArgs
{
	private SMTP_Session m_pSession = null;

	private string m_MailTo = "";

	private bool m_Validated = true;

	private bool m_Authenticated = false;

	private bool m_LocalRecipient = true;

	public SMTP_Session Session => m_pSession;

	public string MailTo => m_MailTo;

	public bool Authenticated => m_Authenticated;

	public string ConnectedIP => m_pSession.RemoteEndPoint.Address.ToString();

	public bool Validated
	{
		get
		{
			return m_Validated;
		}
		set
		{
			m_Validated = value;
		}
	}

	public bool LocalRecipient
	{
		get
		{
			return m_LocalRecipient;
		}
		set
		{
			m_LocalRecipient = value;
		}
	}

	public ValidateRecipient_EventArgs(SMTP_Session session, string mailTo, bool authenticated)
	{
		m_pSession = session;
		m_MailTo = mailTo;
		m_Authenticated = authenticated;
	}
}

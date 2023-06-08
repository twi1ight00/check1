namespace LumiSoft.Net.SMTP.Server;

public class ValidateSender_EventArgs
{
	private SMTP_Session m_pSession = null;

	private string m_MailFrom = "";

	private string m_ErrorText = "";

	private bool m_Validated = true;

	public SMTP_Session Session => m_pSession;

	public string MailFrom => m_MailFrom;

	public string ErrorText
	{
		get
		{
			return m_ErrorText;
		}
		set
		{
			value = value.Replace("\r\n", " ");
			if (value.Length > 200)
			{
				m_ErrorText = value.Substring(0, 200);
			}
			else
			{
				m_ErrorText = value;
			}
		}
	}

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

	public ValidateSender_EventArgs(SMTP_Session session, string mailFrom)
	{
		m_pSession = session;
		m_MailFrom = mailFrom;
	}
}

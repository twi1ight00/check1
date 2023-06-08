namespace LumiSoft.Net.SMTP.Server;

internal class SMTP_Cmd_Validator
{
	private bool m_Helo_ok = false;

	private bool m_Authenticated = false;

	private bool m_MailFrom_ok = false;

	private bool m_RcptTo_ok = false;

	private bool m_BdatLast_ok = false;

	public bool MayHandle_MAIL => m_Helo_ok && !MailFrom_ok;

	public bool MayHandle_RCPT => MailFrom_ok;

	public bool MayHandle_DATA => RcptTo_ok;

	public bool MayHandle_BDAT => RcptTo_ok && !m_BdatLast_ok;

	public bool MayHandle_AUTH => !m_Authenticated;

	public bool Helo_ok
	{
		get
		{
			return m_Helo_ok;
		}
		set
		{
			m_Helo_ok = value;
		}
	}

	public bool Authenticated
	{
		get
		{
			return m_Authenticated;
		}
		set
		{
			m_Authenticated = value;
		}
	}

	public bool MailFrom_ok
	{
		get
		{
			return m_MailFrom_ok;
		}
		set
		{
			m_MailFrom_ok = value;
		}
	}

	public bool RcptTo_ok
	{
		get
		{
			return m_RcptTo_ok;
		}
		set
		{
			m_RcptTo_ok = value;
		}
	}

	public bool BDAT_Last_ok
	{
		get
		{
			return m_BdatLast_ok;
		}
		set
		{
			m_BdatLast_ok = value;
		}
	}

	public void Reset()
	{
		m_Helo_ok = false;
		m_Authenticated = false;
		m_MailFrom_ok = false;
		m_RcptTo_ok = false;
		m_BdatLast_ok = false;
	}
}

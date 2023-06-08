namespace LumiSoft.Net.SMTP.Server;

public class AuthUser_EventArgs
{
	private SMTP_Session m_pSession = null;

	private string m_UserName = "";

	private string m_PasswData = "";

	private string m_Data = "";

	private AuthType m_AuthType;

	private bool m_Validated = true;

	private string m_ReturnData = "";

	public SMTP_Session Session => m_pSession;

	public string UserName => m_UserName;

	public string PasswData => m_PasswData;

	public string AuthData => m_Data;

	public AuthType AuthType => m_AuthType;

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

	public string ReturnData
	{
		get
		{
			return m_ReturnData;
		}
		set
		{
			m_ReturnData = value;
		}
	}

	public AuthUser_EventArgs(SMTP_Session session, string userName, string passwData, string data, AuthType authType)
	{
		m_pSession = session;
		m_UserName = userName;
		m_PasswData = passwData;
		m_Data = data;
		m_AuthType = authType;
	}
}

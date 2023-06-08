namespace LumiSoft.Net.FTP.Server;

public class AuthUser_EventArgs
{
	private FTP_Session m_pSession = null;

	private string m_UserName = "";

	private string m_PasswData = "";

	private string m_Data = "";

	private AuthType m_AuthType;

	private bool m_Validated = true;

	public FTP_Session Session => m_pSession;

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

	public AuthUser_EventArgs(FTP_Session session, string userName, string passwData, string data, AuthType authType)
	{
		m_pSession = session;
		m_UserName = userName;
		m_PasswData = passwData;
		m_Data = data;
		m_AuthType = authType;
	}
}

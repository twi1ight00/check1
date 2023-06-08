namespace LumiSoft.Net.IMAP.Server;

public class IMAP_GetUserACL_eArgs
{
	private IMAP_Session m_pSession = null;

	private string m_pFolderName = "";

	private string m_UserName = "";

	private IMAP_ACL_Flags m_ACL_Flags = IMAP_ACL_Flags.None;

	private string m_ErrorText = "";

	public IMAP_Session Session => m_pSession;

	public string Folder => m_pFolderName;

	public string UserName => m_UserName;

	public IMAP_ACL_Flags ACL
	{
		get
		{
			return m_ACL_Flags;
		}
		set
		{
			m_ACL_Flags = value;
		}
	}

	public string ErrorText
	{
		get
		{
			return m_ErrorText;
		}
		set
		{
			m_ErrorText = value;
		}
	}

	public IMAP_GetUserACL_eArgs(IMAP_Session session, string folderName, string userName)
	{
		m_pSession = session;
		m_pFolderName = folderName;
		m_UserName = userName;
	}
}

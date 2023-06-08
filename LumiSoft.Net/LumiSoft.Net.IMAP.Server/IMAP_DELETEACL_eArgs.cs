namespace LumiSoft.Net.IMAP.Server;

public class IMAP_DELETEACL_eArgs
{
	private IMAP_Session m_pSession = null;

	private string m_pFolderName = "";

	private string m_UserName = "";

	private string m_ErrorText = "";

	public IMAP_Session Session => m_pSession;

	public string Folder => m_pFolderName;

	public string UserName => m_UserName;

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

	public IMAP_DELETEACL_eArgs(IMAP_Session session, string folderName, string userName)
	{
		m_pSession = session;
		m_pFolderName = folderName;
		m_UserName = userName;
	}
}

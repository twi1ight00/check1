using System.Collections;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_GETACL_eArgs
{
	private IMAP_Session m_pSession = null;

	private string m_pFolderName = "";

	private Hashtable m_ACLs = null;

	private string m_ErrorText = "";

	public IMAP_Session Session => m_pSession;

	public string Folder => m_pFolderName;

	public Hashtable ACL => m_ACLs;

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

	public IMAP_GETACL_eArgs(IMAP_Session session, string folderName)
	{
		m_pSession = session;
		m_pFolderName = folderName;
		m_ACLs = new Hashtable();
	}
}

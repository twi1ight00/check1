namespace LumiSoft.Net.IMAP.Server;

public class SharedRootFolders_EventArgs
{
	private IMAP_Session m_pSession = null;

	private string[] m_SharedRootFolders = null;

	private string[] m_PublicRootFolders = null;

	public IMAP_Session Session => m_pSession;

	public string[] SharedRootFolders
	{
		get
		{
			return m_SharedRootFolders;
		}
		set
		{
			m_SharedRootFolders = value;
		}
	}

	public string[] PublicRootFolders
	{
		get
		{
			return m_PublicRootFolders;
		}
		set
		{
			m_PublicRootFolders = value;
		}
	}

	public SharedRootFolders_EventArgs(IMAP_Session session)
	{
		m_pSession = session;
	}
}

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_eArgs_Search
{
	private IMAP_Session m_pSession = null;

	private string m_Folder = "";

	private IMAP_Messages m_pMessages = null;

	private IMAP_SearchMatcher m_pMatcher = null;

	public IMAP_Session Session => m_pSession;

	public string Folder => m_Folder;

	public IMAP_Messages MatchingMessages => m_pMessages;

	public IMAP_SearchMatcher Matcher => m_pMatcher;

	public IMAP_eArgs_Search(IMAP_Session session, string folder, IMAP_SearchMatcher matcher)
	{
		m_pSession = session;
		m_Folder = folder;
		m_pMatcher = matcher;
		m_pMessages = new IMAP_Messages(folder);
	}
}

namespace LumiSoft.Net.POP3.Server;

public class GetMessagesInfo_EventArgs
{
	private POP3_Session m_pSession = null;

	private POP3_Messages m_pPOP3_Messages = null;

	private string m_UserName = "";

	public POP3_Session Session => m_pSession;

	public POP3_Messages Messages => m_pPOP3_Messages;

	public string UserName => m_UserName;

	public string Mailbox => m_UserName;

	public GetMessagesInfo_EventArgs(POP3_Session session, POP3_Messages messages, string mailbox)
	{
		m_pSession = session;
		m_pPOP3_Messages = messages;
		m_UserName = mailbox;
	}
}

namespace LumiSoft.Net.SMTP.Server;

public class ValidateMailboxSize_EventArgs
{
	private SMTP_Session m_pSession = null;

	private string m_eAddress = "";

	private long m_MsgSize = 0L;

	private bool m_IsValid = true;

	public SMTP_Session Session => m_pSession;

	public string eAddress => m_eAddress;

	public long MessageSize => m_MsgSize;

	public bool IsValid
	{
		get
		{
			return m_IsValid;
		}
		set
		{
			m_IsValid = value;
		}
	}

	public ValidateMailboxSize_EventArgs(SMTP_Session session, string eAddress, long messageSize)
	{
		m_pSession = session;
		m_eAddress = eAddress;
		m_MsgSize = messageSize;
	}
}

namespace LumiSoft.Net.SMTP.Client;

public class PartOfMessage_EventArgs
{
	private string m_JobID = "";

	private long m_SentBlockSize = 0L;

	private long m_TotalSent = 0L;

	private long m_MessageSize = 0L;

	public string JobID => m_JobID;

	public long SentBlockSize => m_SentBlockSize;

	public long TotalSent => m_TotalSent;

	public long MessageSize => m_MessageSize;

	public PartOfMessage_EventArgs(string jobID, long sentBlockSize, long totalSent, long messageSize)
	{
		m_JobID = jobID;
		m_SentBlockSize = sentBlockSize;
		m_TotalSent = totalSent;
		m_MessageSize = messageSize;
	}
}

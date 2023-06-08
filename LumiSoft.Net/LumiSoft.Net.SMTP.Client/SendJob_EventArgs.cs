namespace LumiSoft.Net.SMTP.Client;

public class SendJob_EventArgs
{
	private string m_JobID = "";

	private string[] m_To = null;

	private string[] m_DefEmails = null;

	public string JobID => m_JobID;

	public string[] To => m_To;

	public string[] DeffectiveEmails => m_DefEmails;

	public SendJob_EventArgs(string jobID, string[] to)
		: this(jobID, to, null)
	{
	}

	public SendJob_EventArgs(string jobID, string[] to, string[] defectiveEmails)
	{
		m_JobID = jobID;
		m_To = to;
		m_DefEmails = defectiveEmails;
	}
}

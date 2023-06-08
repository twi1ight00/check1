namespace LumiSoft.Net.SMTP.Client;

public class SMTP_Error
{
	private SMTP_ErrorType m_ErrorType = SMTP_ErrorType.UnKnown;

	private string[] m_AffectedEmails = null;

	private string m_ErrorText = "";

	public SMTP_ErrorType ErrorType => m_ErrorType;

	public string[] AffectedEmails => m_AffectedEmails;

	public string ErrorText => m_ErrorText;

	public SMTP_Error(SMTP_ErrorType errorType, string[] affectedEmails, string errorText)
	{
		m_ErrorType = errorType;
		m_AffectedEmails = affectedEmails;
		m_ErrorText = errorText;
	}
}

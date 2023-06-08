namespace LumiSoft.Net.IMAP.Server;

public class Mailbox_EventArgs
{
	private string m_Folder = "";

	private string m_NewFolder = "";

	private string m_Error = null;

	public string Folder => m_Folder;

	public string NewFolder => m_NewFolder;

	public string ErrorText
	{
		get
		{
			return m_Error;
		}
		set
		{
			m_Error = value;
		}
	}

	public Mailbox_EventArgs(string folder)
	{
		m_Folder = folder;
	}

	public Mailbox_EventArgs(string folder, string newFolder)
	{
		m_Folder = folder;
		m_NewFolder = newFolder;
	}
}

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Folder
{
	private string m_Folder = "";

	private bool m_Selectable = true;

	public string Folder => m_Folder;

	public bool Selectable
	{
		get
		{
			return m_Selectable;
		}
		set
		{
			m_Selectable = value;
		}
	}

	public IMAP_Folder(string folder, bool selectable)
	{
		m_Folder = folder;
		m_Selectable = selectable;
	}
}

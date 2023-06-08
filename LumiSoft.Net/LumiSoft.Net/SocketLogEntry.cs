namespace LumiSoft.Net;

public class SocketLogEntry
{
	private string m_Text = "";

	private long m_Size = 0L;

	private SocketLogEntryType m_Type = SocketLogEntryType.FreeText;

	public string Text => m_Text;

	public long Size => m_Size;

	public SocketLogEntryType Type => m_Type;

	public SocketLogEntry(string text, long size, SocketLogEntryType type)
	{
		m_Text = text;
		m_Type = type;
		m_Size = size;
	}
}

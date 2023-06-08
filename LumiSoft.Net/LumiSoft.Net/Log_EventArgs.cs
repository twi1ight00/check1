namespace LumiSoft.Net;

public class Log_EventArgs
{
	private SocketLogger m_pLoggger = null;

	private bool m_FirstLogPart = true;

	private bool m_LastLogPart = false;

	public string LogText => SocketLogger.LogEntriesToString(m_pLoggger, m_FirstLogPart, m_LastLogPart);

	public SocketLogger Logger => m_pLoggger;

	public Log_EventArgs(SocketLogger logger, bool firstLogPart, bool lastLogPart)
	{
		m_pLoggger = logger;
		m_FirstLogPart = firstLogPart;
		m_LastLogPart = lastLogPart;
	}
}

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace LumiSoft.Net;

public class SocketLogger
{
	private Socket m_pSocket = null;

	private string m_SessionID = "";

	private LogEventHandler m_pLogHandler = null;

	private ArrayList m_pEntries = null;

	private bool m_FirstLogPart = true;

	public string SessionID
	{
		get
		{
			return m_SessionID;
		}
		set
		{
			m_SessionID = value;
		}
	}

	public SocketLogEntry[] LogEntries
	{
		get
		{
			SocketLogEntry[] array = new SocketLogEntry[m_pEntries.Count];
			m_pEntries.CopyTo(array);
			return array;
		}
	}

	public IPEndPoint LocalEndPoint => (IPEndPoint)m_pSocket.LocalEndPoint;

	public IPEndPoint RemoteEndPoint => (IPEndPoint)m_pSocket.RemoteEndPoint;

	public SocketLogger(Socket socket, LogEventHandler logHandler)
	{
		m_pSocket = socket;
		m_pLogHandler = logHandler;
		m_pEntries = new ArrayList();
	}

	public static string LogEntriesToString(SocketLogger logger, bool firstLogPart, bool lastLogPart)
	{
		string text = string.Concat("//----- Sys: 'Session:'", logger.SessionID, " added ", DateTime.Now, "\r\n");
		if (!firstLogPart)
		{
			text = string.Concat("//----- Sys: 'Session:'", logger.SessionID, " partial log continues ", DateTime.Now, "\r\n");
		}
		SocketLogEntry[] logEntries = logger.LogEntries;
		foreach (SocketLogEntry socketLogEntry in logEntries)
		{
			text = ((socketLogEntry.Type != 0) ? ((socketLogEntry.Type != SocketLogEntryType.SendToRemoteEP) ? (text + CreateEntry(logger, socketLogEntry.Text, "---")) : (text + CreateEntry(logger, socketLogEntry.Text, "<<<"))) : (text + CreateEntry(logger, socketLogEntry.Text, ">>>")));
		}
		object obj;
		if (lastLogPart)
		{
			obj = text;
			return string.Concat(obj, "//----- Sys: 'Session:'", logger.SessionID, " removed ", DateTime.Now, "\r\n");
		}
		obj = text;
		return string.Concat(obj, "//----- Sys: 'Session:'", logger.SessionID, " partial log ", DateTime.Now, "\r\n");
	}

	private static string CreateEntry(SocketLogger logger, string text, string prefix)
	{
		string text2 = "";
		if (text.EndsWith("\r\n"))
		{
			text = text.Substring(0, text.Length - 2);
		}
		string text3 = "xxx.xxx.xxx.xxx";
		try
		{
			if (logger.RemoteEndPoint != null)
			{
				text3 = logger.RemoteEndPoint.Address.ToString();
			}
		}
		catch
		{
		}
		string[] array = text.Replace("\r\n", "\n").Split('\n');
		string[] array2 = array;
		foreach (string text4 in array2)
		{
			string text5 = text2;
			text2 = text5 + "SessionID: " + logger.SessionID + "  RemIP: " + text3 + "  " + prefix + "  '" + text4 + "'\r\n";
		}
		return text2;
	}

	public void AddReadEntry(string text, long size)
	{
		m_pEntries.Add(new SocketLogEntry(text, size, SocketLogEntryType.ReadFromRemoteEP));
		OnEntryAdded();
	}

	public void AddSendEntry(string text, long size)
	{
		m_pEntries.Add(new SocketLogEntry(text, size, SocketLogEntryType.SendToRemoteEP));
		OnEntryAdded();
	}

	public void AddTextEntry(string text)
	{
		m_pEntries.Add(new SocketLogEntry(text, 0L, SocketLogEntryType.FreeText));
		OnEntryAdded();
	}

	public void Flush()
	{
		if (m_pLogHandler != null)
		{
			m_pLogHandler(this, new Log_EventArgs(this, m_FirstLogPart, lastLogPart: true));
		}
	}

	private void OnEntryAdded()
	{
		if (m_pEntries.Count > 100)
		{
			if (m_pLogHandler != null)
			{
				m_pLogHandler(this, new Log_EventArgs(this, m_FirstLogPart, lastLogPart: false));
			}
			m_pEntries.Clear();
			m_FirstLogPart = false;
		}
	}
}

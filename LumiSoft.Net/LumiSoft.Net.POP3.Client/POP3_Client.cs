using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace LumiSoft.Net.POP3.Client;

public class POP3_Client : IDisposable
{
	private SocketEx m_pSocket = null;

	private SocketLogger m_pLogger = null;

	private bool m_Connected = false;

	private bool m_Authenticated = false;

	private string m_ApopHashKey = "";

	private bool m_LogCmds = false;

	public bool Connected => m_Connected;

	public bool Authenticated => m_Authenticated;

	public bool LogCommands
	{
		get
		{
			return m_LogCmds;
		}
		set
		{
			m_LogCmds = value;
		}
	}

	public bool IsSecureConnection
	{
		get
		{
			if (!m_Connected)
			{
				throw new Exception("You must connect first");
			}
			return m_pSocket.SSL;
		}
	}

	public event LogEventHandler SessionLog = null;

	public void Dispose()
	{
		try
		{
			Disconnect();
		}
		catch
		{
		}
	}

	public void Connect(string host, int port)
	{
		Connect(host, port, ssl: false);
	}

	public void Connect(string host, int port, bool ssl)
	{
		if (!m_Connected)
		{
			SocketEx socketEx = new SocketEx();
			socketEx.Connect(host, port, ssl);
			m_pSocket = socketEx;
			if (m_LogCmds && this.SessionLog != null)
			{
				m_pLogger = new SocketLogger(socketEx.RawSocket, this.SessionLog);
				m_pLogger.SessionID = Guid.NewGuid().ToString();
				m_pSocket.Logger = m_pLogger;
			}
			m_Connected = true;
			string text = m_pSocket.ReadLine();
			if (text.StartsWith("+OK") && text.IndexOf("<") > -1 && text.IndexOf(">") > -1)
			{
				m_ApopHashKey = text.Substring(text.LastIndexOf("<"), text.LastIndexOf(">") - text.LastIndexOf("<") + 1);
			}
		}
	}

	public void Disconnect()
	{
		try
		{
			if (m_pSocket != null)
			{
				m_pSocket.WriteLine("QUIT");
				m_pSocket.Shutdown(SocketShutdown.Both);
			}
		}
		catch
		{
		}
		if (m_pLogger != null)
		{
			m_pLogger.Flush();
		}
		m_pLogger = null;
		m_pSocket = null;
		m_Connected = false;
		m_Authenticated = false;
	}

	public void StartTLS()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (m_Authenticated)
		{
			throw new Exception("The STLS command is only valid in non-authenticated state !");
		}
		if (m_pSocket.SSL)
		{
			throw new Exception("Connection is already secure !");
		}
		m_pSocket.WriteLine("STLS");
		string text = m_pSocket.ReadLine();
		if (!text.ToUpper().StartsWith("+OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_pSocket.SwitchToSSL_AsClient();
	}

	public void Authenticate(string userName, string password, bool tryApop)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (m_Authenticated)
		{
			throw new Exception("You are already authenticated !");
		}
		string text2;
		if (tryApop && m_ApopHashKey.Length > 0)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(m_ApopHashKey + password);
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] array = mD.ComputeHash(bytes);
			string text = BitConverter.ToString(array).ToLower().Replace("-", "");
			m_pSocket.WriteLine("APOP " + userName + " " + text);
			text2 = m_pSocket.ReadLine();
			if (text2.StartsWith("+OK"))
			{
				m_Authenticated = true;
				return;
			}
			throw new Exception("Server returned:" + text2);
		}
		m_pSocket.WriteLine("USER " + userName);
		text2 = m_pSocket.ReadLine();
		if (text2.StartsWith("+OK"))
		{
			m_pSocket.WriteLine("PASS " + password);
			text2 = m_pSocket.ReadLine();
			if (text2.StartsWith("+OK"))
			{
				m_Authenticated = true;
				return;
			}
			throw new Exception("Server returned:" + text2);
		}
		throw new Exception("Server returned:" + text2);
	}

	public POP3_MessagesInfo GetMessagesInfo()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		POP3_MessagesInfo pOP3_MessagesInfo = new POP3_MessagesInfo();
		Hashtable uidlList = GetUidlList();
		m_pSocket.WriteLine("LIST");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("+OK"))
		{
			while (true)
			{
				bool flag = true;
				text = m_pSocket.ReadLine();
				if (text.Trim() == ".")
				{
					break;
				}
				string[] array = text.Trim().Split(' ');
				int num = Convert.ToInt32(array[0]);
				long messageSize = Convert.ToInt64(array[1]);
				pOP3_MessagesInfo.Add(uidlList[num].ToString(), num, messageSize);
			}
			return pOP3_MessagesInfo;
		}
		throw new Exception("Server returned:" + text);
	}

	public Hashtable GetUidlList()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		Hashtable hashtable = new Hashtable();
		m_pSocket.WriteLine("UIDL");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("+OK"))
		{
			while (true)
			{
				bool flag = true;
				text = m_pSocket.ReadLine();
				if (text.Trim() == ".")
				{
					break;
				}
				string[] array = text.Trim().Split(' ');
				int num = Convert.ToInt32(array[0]);
				string value = array[1];
				hashtable.Add(num, value);
			}
			return hashtable;
		}
		throw new Exception("Server returned:" + text);
	}

	public byte[] GetMessage(POP3_MessageInfo msgInfo)
	{
		return GetMessage(msgInfo.MessageNumber);
	}

	public byte[] GetMessage(int messageNo)
	{
		MemoryStream memoryStream = new MemoryStream();
		GetMessage(messageNo, memoryStream);
		return memoryStream.ToArray();
	}

	public void GetMessage(int messageNo, Stream stream)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("RETR " + messageNo);
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("+OK"))
		{
			m_pSocket.ReadPeriodTerminated(stream, 100000000);
			return;
		}
		throw new Exception("Server returned:" + text);
	}

	public void DeleteMessage(int messageNr)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("DELE " + messageNr);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("+OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public byte[] GetTopOfMessage(int nr, int nLines)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("TOP " + nr + " " + nLines);
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("+OK"))
		{
			MemoryStream memoryStream = new MemoryStream();
			m_pSocket.ReadPeriodTerminated(memoryStream, 100000000);
			return memoryStream.ToArray();
		}
		throw new Exception("Server returned:" + text);
	}

	public void Reset()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("RSET");
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("+OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}
}

using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LumiSoft.Net.Dns.Client;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.SMTP.Client;

public class SMTP_Client
{
	private string m_Password = "";

	private string m_Username = "";

	private string m_HostName = "";

	private string m_SmartHost = "";

	private string[] m_DnsServers = null;

	private bool m_UseSmartHost = false;

	private int m_Port = 25;

	private int m_MaxThreads = 10;

	private ArrayList m_pErrors = null;

	private Hashtable m_SendTrTable = null;

	private Control m_pOwnerUI = null;

	private object[] m_Params = null;

	private bool m_LogCmds = false;

	private bool m_UseBDAT = true;

	public string Username
	{
		get
		{
			return m_Username;
		}
		set
		{
			m_Username = value;
		}
	}

	public string Password
	{
		get
		{
			return m_Password;
		}
		set
		{
			m_Password = value;
		}
	}

	public string HostName
	{
		get
		{
			return m_HostName;
		}
		set
		{
			if (value.Length > 0)
			{
				m_HostName = value;
			}
		}
	}

	public string SmartHost
	{
		get
		{
			return m_SmartHost;
		}
		set
		{
			m_SmartHost = value;
		}
	}

	public string[] DnsServers
	{
		get
		{
			return m_DnsServers;
		}
		set
		{
			m_DnsServers = value;
		}
	}

	public bool UseSmartHost
	{
		get
		{
			return m_UseSmartHost;
		}
		set
		{
			m_UseSmartHost = value;
		}
	}

	public int Port
	{
		get
		{
			return m_Port;
		}
		set
		{
			m_Port = value;
		}
	}

	public int MaxSenderThreads
	{
		get
		{
			return m_MaxThreads;
		}
		set
		{
			if (value < 1)
			{
				m_MaxThreads = 1;
			}
			else
			{
				m_MaxThreads = value;
			}
		}
	}

	public SMTP_Error[] Errors
	{
		get
		{
			SMTP_Error[] array = new SMTP_Error[m_pErrors.Count];
			m_pErrors.CopyTo(array);
			return array;
		}
	}

	public bool UseBDAT
	{
		get
		{
			return m_UseBDAT;
		}
		set
		{
			m_UseBDAT = value;
		}
	}

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

	public bool IsSending
	{
		get
		{
			if (m_SendTrTable.Count > 0)
			{
				return true;
			}
			return false;
		}
	}

	public event SMTP_PartOfMessage_EventHandler PartOfMessageIsSent = null;

	public event SMTP_SendJob_EventHandler NewSendJob = null;

	public event SMTP_SendJob_EventHandler SendJobCompleted = null;

	public event SMTP_Error_EventHandler Error = null;

	public event EventHandler CompletedAll = null;

	public event LogEventHandler SessionLog = null;

	public SMTP_Client()
		: this(null)
	{
	}

	public SMTP_Client(Control ownerUI)
	{
		m_pOwnerUI = ownerUI;
		m_pErrors = new ArrayList();
		m_SendTrTable = new Hashtable();
		try
		{
			m_HostName = System.Net.Dns.GetHostName();
		}
		catch
		{
			m_HostName = "UnKnown";
		}
	}

	public void BeginSend(string[] to, string from, Stream message)
	{
		m_pErrors.Clear();
		m_Params = new object[3] { to, from, message };
		Thread thread = new Thread(BeginSend);
		thread.Start();
	}

	private void BeginSend()
	{
		string[] array = (string[])m_Params[0];
		string text = (string)m_Params[1];
		Stream stream = (Stream)m_Params[2];
		Hashtable hashtable = new Hashtable();
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			string key = text2.Substring(text2.IndexOf("@"));
			if (hashtable.Contains(key))
			{
				ArrayList arrayList = (ArrayList)hashtable[key];
				arrayList.Add(text2);
			}
			else
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Add(text2);
				hashtable.Add(key, arrayList);
			}
		}
		foreach (ArrayList value in hashtable.Values)
		{
			string[] array3 = new string[value.Count];
			value.CopyTo(array3);
			long position = stream.Position;
			byte[] buffer = new byte[stream.Length - stream.Position];
			stream.Read(buffer, 0, (int)(stream.Length - stream.Position));
			MemoryStream memoryStream = new MemoryStream(buffer);
			stream.Position = position;
			Thread thread = new Thread(StartSendJob);
			m_SendTrTable.Add(thread, new object[3] { array3, text, memoryStream });
			thread.Start();
			while (m_SendTrTable.Count > m_MaxThreads)
			{
				Thread.Sleep(100);
			}
		}
		while (m_SendTrTable.Count > 0)
		{
			Thread.Sleep(300);
		}
		OnCompletedAll();
	}

	public bool Send(string[] to, string from, Stream message)
	{
		m_pErrors.Clear();
		return SendMessageToServer(to, from, message);
	}

	private void StartSendJob()
	{
		try
		{
			if (m_SendTrTable.Contains(Thread.CurrentThread))
			{
				object[] array = (object[])m_SendTrTable[Thread.CurrentThread];
				OnNewSendJobStarted(Thread.CurrentThread.GetHashCode().ToString(), (string[])array[0]);
				SendMessageToServer((string[])array[0], (string)array[1], (Stream)array[2]);
			}
		}
		catch
		{
		}
		finally
		{
			RemoveSenderThread(Thread.CurrentThread);
		}
	}

	private void RemoveSenderThread(Thread t)
	{
		lock (m_SendTrTable)
		{
			if (m_SendTrTable.ContainsKey(t))
			{
				m_SendTrTable.Remove(t);
			}
		}
	}

	private bool SendMessageToServer(string[] to, string reverse_path, Stream message)
	{
		for (int i = 0; i < to.Length; i++)
		{
			to[i] = MailboxAddress.Parse(to[i]).EmailAddress;
		}
		ArrayList arrayList = new ArrayList();
		SocketEx socketEx = new SocketEx();
		SocketLogger socketLogger = null;
		if (m_LogCmds && this.SessionLog != null)
		{
			socketLogger = new SocketLogger(socketEx.RawSocket, this.SessionLog);
			socketLogger.SessionID = socketEx.GetHashCode().ToString();
			socketEx.Logger = socketLogger;
		}
		try
		{
			string text = "";
			bool flag = false;
			bool flag2 = false;
			if (m_UseSmartHost)
			{
				socketEx.Connect(new IPEndPoint(System.Net.Dns.GetHostEntry(m_SmartHost).AddressList[0], m_Port));
			}
			else
			{
				string text2 = to[0];
				if (text2.IndexOf("<") > -1 && text2.IndexOf(">") > -1)
				{
					text2 = text2.Substring(text2.IndexOf("<") + 1, text2.IndexOf(">") - text2.IndexOf("<") - 1);
				}
				if (text2.IndexOf("@") > -1)
				{
					text2 = text2.Substring(text2.LastIndexOf("@") + 1);
				}
				if (text2.Trim().Length == 0)
				{
					socketLogger?.AddTextEntry("Destination address '" + to[0] + "' is invalid, aborting !");
					return false;
				}
				Dns_Client dns_Client = new Dns_Client();
				Dns_Client.DnsServers = m_DnsServers;
				DnsServerResponse dnsServerResponse = dns_Client.Query(text2, QTYPE.MX);
				switch (dnsServerResponse.ResponseCode)
				{
				case RCODE.NO_ERROR:
				{
					MX_Record[] mXRecords = dnsServerResponse.GetMXRecords();
					MX_Record[] array = mXRecords;
					foreach (MX_Record mX_Record in array)
					{
						try
						{
							socketLogger?.AddTextEntry("Connecting with mx record to: " + mX_Record.Host);
							socketEx.Connect(new IPEndPoint(System.Net.Dns.GetHostEntry(mX_Record.Host).AddressList[0], m_Port));
						}
						catch
						{
							socketLogger?.AddTextEntry("Failed connect to: " + mX_Record.Host);
							continue;
						}
						break;
					}
					if (mXRecords.Length == 0)
					{
						IPHostEntry iPHostEntry = null;
						try
						{
							socketLogger?.AddTextEntry("No mx record, trying to get A record for: " + text2);
							iPHostEntry = System.Net.Dns.GetHostEntry(text2);
						}
						catch
						{
							socketLogger?.AddTextEntry("Invalid domain,no MX or A record: " + text2);
							OnError(SMTP_ErrorType.InvalidEmailAddress, to, "email domain <" + text2 + "> is invalid");
							arrayList.AddRange(to);
							socketLogger?.Flush();
							return false;
						}
						try
						{
							socketLogger?.AddTextEntry("Connecting with A record to:" + text2);
							socketEx.Connect(new IPEndPoint(iPHostEntry.AddressList[0], m_Port));
						}
						catch
						{
							socketLogger?.AddTextEntry("Failed connect to:" + text2);
						}
					}
					break;
				}
				case RCODE.NAME_ERROR:
					socketLogger?.AddTextEntry("Invalid domain,no MX or A record: " + text2);
					OnError(SMTP_ErrorType.InvalidEmailAddress, to, "email domain <" + text2 + "> is invalid");
					arrayList.AddRange(to);
					socketLogger?.Flush();
					return false;
				case RCODE.SERVER_FAILURE:
					socketLogger?.AddTextEntry("Dns server unvailable.");
					OnError(SMTP_ErrorType.UnKnown, to, "Dns server unvailable.");
					arrayList.AddRange(to);
					socketLogger?.Flush();
					return false;
				}
			}
			if (!socketEx.Connected)
			{
				OnError(SMTP_ErrorType.UnKnown, to, "Unable connect to server !");
				socketLogger?.Flush();
				return false;
			}
			text = socketEx.ReadLine();
			if (!IsReplyCode("220", text))
			{
				OnError(SMTP_ErrorType.UnKnown, to, text);
				socketEx.WriteLine("QUIT");
				socketLogger?.Flush();
				return false;
			}
			while (text.IndexOf("220 ") == -1)
			{
				text += socketEx.ReadLine();
			}
			socketEx.WriteLine("EHLO " + m_HostName);
			text = socketEx.ReadLine();
			if (!IsReplyCode("250", text))
			{
				socketEx.WriteLine("HELO " + m_HostName);
				text = socketEx.ReadLine();
				if (!IsReplyCode("250", text))
				{
					OnError(SMTP_ErrorType.UnKnown, to, text);
					socketEx.WriteLine("QUIT");
					arrayList.AddRange(to);
					socketLogger?.Flush();
					return false;
				}
			}
			else
			{
				while (text.IndexOf("250 ") == -1)
				{
					text += socketEx.ReadLine();
				}
				if (text.ToUpper().IndexOf("SIZE") > -1)
				{
					flag = true;
				}
				if (text.ToUpper().IndexOf("8BITMIME") > -1)
				{
				}
				if (text.ToUpper().IndexOf("CHUNKING") > -1)
				{
					flag2 = true;
				}
			}
			if (m_Username != null && m_Username.Length > 0 && m_Password != null && m_Password.Length > 0 && text.ToUpper().IndexOf("AUTH") > -1 && text.ToUpper().IndexOf("LOGIN") > -1)
			{
				socketEx.WriteLine("AUTH LOGIN");
				text = socketEx.ReadLine();
				if (!IsReplyCode("334", text))
				{
					OnError(SMTP_ErrorType.NotAuthenticated, to, "Failed to authenticate");
					socketEx.WriteLine("QUIT");
					socketLogger?.Flush();
					return false;
				}
				socketEx.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(m_Username.ToCharArray())));
				text = socketEx.ReadLine();
				if (!IsReplyCode("334", text))
				{
					OnError(SMTP_ErrorType.NotAuthenticated, to, "Failed to authenticate");
					socketEx.WriteLine("QUIT");
					socketLogger?.Flush();
					return false;
				}
				socketEx.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(m_Password.ToCharArray())));
				text = socketEx.ReadLine();
				if (!IsReplyCode("235", text))
				{
					OnError(SMTP_ErrorType.NotAuthenticated, to, "Failed to authenticate");
					socketEx.WriteLine("QUIT");
					socketLogger?.Flush();
					return false;
				}
			}
			if (flag)
			{
				socketEx.WriteLine("MAIL FROM:<" + reverse_path + "> SIZE=" + (message.Length - message.Position));
			}
			else
			{
				socketEx.WriteLine("MAIL FROM:<" + reverse_path + ">");
			}
			text = socketEx.ReadLine();
			if (!IsReplyCode("250", text))
			{
				OnError(SMTP_ErrorType.UnKnown, to, text);
				socketEx.WriteLine("QUIT");
				arrayList.AddRange(to);
				socketLogger?.Flush();
				return false;
			}
			bool flag3 = false;
			foreach (string text3 in to)
			{
				socketEx.WriteLine("RCPT TO:<" + text3 + ">");
				text = socketEx.ReadLine();
				if (!IsReplyCode("250", text))
				{
					if (IsReplyCode("550", text))
					{
						OnError(SMTP_ErrorType.InvalidEmailAddress, new string[1] { text3 }, text);
					}
					else
					{
						OnError(SMTP_ErrorType.UnKnown, new string[1] { text3 }, text);
					}
					arrayList.Add(text3);
				}
				else
				{
					flag3 = true;
				}
			}
			if (!flag3)
			{
				socketEx.WriteLine("QUIT");
				socketLogger?.Flush();
				return false;
			}
			if (!flag2 || !m_UseBDAT)
			{
				socketEx.WriteLine("DATA");
				text = socketEx.ReadLine();
				if (!IsReplyCode("354", text))
				{
					OnError(SMTP_ErrorType.UnKnown, to, text);
					socketEx.WriteLine("QUIT");
					arrayList.AddRange(to);
					socketLogger?.Flush();
					return false;
				}
				MemoryStream memoryStream = Core.DoPeriodHandling(message, add_Remove: true, setStrmPosTo0: false);
				if (memoryStream.Length >= 2)
				{
					byte[] array2 = new byte[2];
					memoryStream.Position = memoryStream.Length - 2;
					memoryStream.Read(array2, 0, 2);
					if (array2[0] != 13 && array2[1] != 10)
					{
						memoryStream.Write(new byte[2] { 13, 10 }, 0, 2);
					}
				}
				memoryStream.Position = 0L;
				long num = 0L;
				long length = memoryStream.Length;
				while (num < length)
				{
					byte[] array3 = new byte[4000];
					int num2 = memoryStream.Read(array3, 0, array3.Length);
					int num3 = socketEx.RawSocket.Send(array3, 0, num2, SocketFlags.None);
					num += num3;
					if (num3 != num2)
					{
						memoryStream.Position = num;
					}
					OnPartOfMessageIsSent(num3, num, length);
				}
				memoryStream.Close();
				socketEx.WriteLine(".");
				text = socketEx.ReadLine();
				if (!IsReplyCode("250", text))
				{
					OnError(SMTP_ErrorType.UnKnown, to, text);
					socketEx.WriteLine("QUIT");
					arrayList.AddRange(to);
					socketLogger?.Flush();
					return false;
				}
			}
			if (flag2 && m_UseBDAT)
			{
				socketEx.WriteLine("BDAT " + (message.Length - message.Position) + " LAST");
				long num = 0L;
				long length = message.Length - message.Position;
				while (num < length)
				{
					byte[] array3 = new byte[4000];
					int num2 = message.Read(array3, 0, array3.Length);
					int num3 = socketEx.RawSocket.Send(array3, 0, num2, SocketFlags.None);
					num += num3;
					if (num3 != num2)
					{
						message.Position = num;
					}
					OnPartOfMessageIsSent(num3, num, length);
				}
				text = socketEx.ReadLine();
				if (!text.StartsWith("250"))
				{
					OnError(SMTP_ErrorType.UnKnown, to, text);
					socketEx.WriteLine("QUIT");
					arrayList.AddRange(to);
					socketLogger?.Flush();
					return false;
				}
			}
			socketEx.WriteLine("QUIT");
		}
		catch (Exception ex)
		{
			OnError(SMTP_ErrorType.UnKnown, to, ex.Message);
			arrayList.AddRange(to);
			socketLogger?.Flush();
			return false;
		}
		finally
		{
			OnSendJobCompleted(Thread.CurrentThread.GetHashCode().ToString(), to, arrayList);
		}
		socketLogger?.Flush();
		return true;
	}

	private bool IsReplyCode(string replyCode, string reply)
	{
		if (reply.IndexOf(replyCode) > -1)
		{
			return true;
		}
		return false;
	}

	private bool Is8BitMime(Stream strm)
	{
		bool result = false;
		long position = strm.Position;
		TextReader textReader = new StreamReader(strm);
		for (string text = textReader.ReadLine(); text != null; text = textReader.ReadLine())
		{
			if (text.ToUpper().IndexOf("CONTENT-TR") > -1 && text.ToUpper().IndexOf("8BIT") > -1)
			{
				result = true;
				break;
			}
		}
		strm.Position = position;
		return result;
	}

	protected void OnPartOfMessageIsSent(long sentBlockSize, long totalSent, long messageSize)
	{
		if (this.PartOfMessageIsSent != null)
		{
			string jobID = Thread.CurrentThread.GetHashCode().ToString();
			if (m_pOwnerUI == null)
			{
				this.PartOfMessageIsSent(this, new PartOfMessage_EventArgs(jobID, sentBlockSize, totalSent, messageSize));
				return;
			}
			m_pOwnerUI.Invoke(this.PartOfMessageIsSent, this, new PartOfMessage_EventArgs(jobID, sentBlockSize, totalSent, messageSize));
		}
	}

	protected void OnNewSendJobStarted(string jobID, string[] to)
	{
		if (this.NewSendJob != null)
		{
			if (m_pOwnerUI == null)
			{
				this.NewSendJob(this, new SendJob_EventArgs(jobID, to));
				return;
			}
			m_pOwnerUI.Invoke(this.NewSendJob, this, new SendJob_EventArgs(jobID, to));
		}
	}

	protected void OnSendJobCompleted(string jobID, string[] to, ArrayList defectiveEmails)
	{
		if (this.SendJobCompleted != null)
		{
			string[] array = new string[defectiveEmails.Count];
			defectiveEmails.CopyTo(array);
			if (m_pOwnerUI == null)
			{
				this.SendJobCompleted(this, new SendJob_EventArgs(jobID, to, array));
				return;
			}
			m_pOwnerUI.Invoke(this.SendJobCompleted, this, new SendJob_EventArgs(jobID, to, array));
		}
	}

	private void OnCompletedAll()
	{
		if (this.CompletedAll != null)
		{
			this.CompletedAll(this, new EventArgs());
		}
	}

	protected void OnError(SMTP_ErrorType type, string[] affectedAddresses, string errorText)
	{
		lock (m_pErrors)
		{
			m_pErrors.Add(new SMTP_Error(type, affectedAddresses, errorText));
		}
		if (this.Error != null)
		{
			if (m_pOwnerUI == null)
			{
				this.Error(this, new SMTP_Error(type, affectedAddresses, errorText));
				return;
			}
			m_pOwnerUI.Invoke(this.Error, this, new SMTP_Error(type, affectedAddresses, errorText));
		}
	}
}

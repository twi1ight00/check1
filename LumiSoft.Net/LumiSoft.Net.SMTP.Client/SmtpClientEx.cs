using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using LumiSoft.Net.Dns.Client;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.SMTP.Client;

public class SmtpClientEx : IDisposable
{
	private SocketEx m_pSocket = null;

	private SocketLogger m_pLogger = null;

	private bool m_Connected = false;

	private bool m_Authenticated = false;

	private bool m_Supports_Size = false;

	private bool m_Supports_Bdat = false;

	private bool m_Supports_Login = false;

	private bool m_Supports_CramMd5 = false;

	private string[] m_pDnsServers = null;

	public EndPoint LocalEndpoint
	{
		get
		{
			if (m_pSocket != null)
			{
				return m_pSocket.LocalEndPoint;
			}
			return null;
		}
	}

	public EndPoint RemoteEndPoint
	{
		get
		{
			if (m_pSocket != null)
			{
				return m_pSocket.RemoteEndPoint;
			}
			return null;
		}
	}

	public string[] DnsServers
	{
		get
		{
			return m_pDnsServers;
		}
		set
		{
			m_pDnsServers = value;
		}
	}

	public bool Connected => m_Connected;

	public bool Authenticated => m_Authenticated;

	public DateTime LastDataTime => m_pSocket.LastActivity;

	public SocketLogger SessionActiveLog
	{
		get
		{
			if (!m_Connected)
			{
				throw new Exception("You must connect first");
			}
			return m_pSocket.Logger;
		}
	}

	public long ReadedCount
	{
		get
		{
			if (!m_Connected)
			{
				throw new Exception("You must connect first");
			}
			return m_pSocket.ReadedCount;
		}
	}

	public long WrittenCount
	{
		get
		{
			if (!m_Connected)
			{
				throw new Exception("You must connect first");
			}
			return m_pSocket.WrittenCount;
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
		Connect(null, host, port, ssl: false);
	}

	public void Connect(string host, int port, bool ssl)
	{
		Connect(null, host, port, ssl);
	}

	public void Connect(IPEndPoint localEndpoint, string host, int port)
	{
		Connect(localEndpoint, host, port, ssl: false);
	}

	public void Connect(IPEndPoint localEndpoint, string host, int port, bool ssl)
	{
		m_pSocket = new SocketEx();
		if (localEndpoint != null)
		{
			m_pSocket.Bind(localEndpoint);
		}
		if (this.SessionLog != null)
		{
			m_pLogger = new SocketLogger(m_pSocket.RawSocket, this.SessionLog);
			m_pLogger.SessionID = Guid.NewGuid().ToString();
			m_pSocket.Logger = m_pLogger;
		}
		if (host.IndexOf("@") == -1)
		{
			m_pSocket.Connect(host, port, ssl);
		}
		else
		{
			string text = host;
			if (text.IndexOf("<") > -1 && text.IndexOf(">") > -1)
			{
				text = text.Substring(text.IndexOf("<") + 1, text.IndexOf(">") - text.IndexOf("<") - 1);
			}
			if (text.IndexOf("@") > -1)
			{
				text = text.Substring(text.LastIndexOf("@") + 1);
			}
			if (text.Trim().Length == 0)
			{
				if (m_pLogger != null)
				{
					m_pLogger.AddTextEntry("Destination address '" + host + "' is invalid, aborting !");
				}
				throw new Exception("Destination address '" + host + "' is invalid, aborting !");
			}
			Dns_Client dns_Client = new Dns_Client();
			Dns_Client.DnsServers = m_pDnsServers;
			DnsServerResponse dnsServerResponse = dns_Client.Query(text, QTYPE.MX);
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
						if (m_pLogger != null)
						{
							m_pLogger.AddTextEntry("Connecting with mx record to: " + mX_Record.Host);
						}
						m_pSocket.Connect(mX_Record.Host, port, ssl);
					}
					catch
					{
						if (m_pLogger != null)
						{
							m_pLogger.AddTextEntry("Failed connect to: " + mX_Record.Host);
						}
						continue;
					}
					break;
				}
				if (mXRecords.Length > 0 && !m_pSocket.Connected)
				{
					throw new Exception("Destination email server is down");
				}
				if (mXRecords.Length != 0)
				{
					break;
				}
				IPAddress[] array2 = null;
				try
				{
					if (m_pLogger != null)
					{
						m_pLogger.AddTextEntry("No mx record, trying to get A record for: " + text);
					}
					array2 = Dns_Client.Resolve(text);
				}
				catch
				{
					if (m_pLogger != null)
					{
						m_pLogger.AddTextEntry("Invalid domain,no MX or A record: " + text);
					}
					throw new Exception("Invalid domain,no MX or A record: " + text);
				}
				try
				{
					if (m_pLogger != null)
					{
						m_pLogger.AddTextEntry("Connecting with A record to:" + text);
					}
					m_pSocket.Connect(text, port, ssl);
				}
				catch
				{
					if (m_pLogger != null)
					{
						m_pLogger.AddTextEntry("Failed connect to:" + text);
					}
					throw new Exception("Destination email server is down");
				}
				break;
			}
			case RCODE.NAME_ERROR:
				if (m_pLogger != null)
				{
					m_pLogger.AddTextEntry("Invalid domain,no MX or A record: " + text);
				}
				throw new Exception("Invalid domain,no MX or A record: " + text);
			case RCODE.SERVER_FAILURE:
				if (m_pLogger != null)
				{
					m_pLogger.AddTextEntry("Dns server unvailable.");
				}
				throw new Exception("Dns server unvailable.");
			}
		}
		string text2 = m_pSocket.ReadLine(1000);
		while (!text2.StartsWith("220 "))
		{
			if (!text2.StartsWith("220"))
			{
				throw new Exception(text2);
			}
			text2 = m_pSocket.ReadLine(1000);
		}
		m_Connected = true;
	}

	public void BeginConnect(string host, int port, CommadCompleted callback)
	{
		BeginConnect(null, host, port, ssl: false, callback);
	}

	public void BeginConnect(string host, int port, bool ssl, CommadCompleted callback)
	{
		BeginConnect(null, host, port, ssl, callback);
	}

	public void BeginConnect(IPEndPoint localEndpoint, string host, int port, CommadCompleted callback)
	{
		BeginConnect(localEndpoint, host, port, ssl: false, callback);
	}

	public void BeginConnect(IPEndPoint localEndpoint, string host, int port, bool ssl, CommadCompleted callback)
	{
		ThreadPool.QueueUserWorkItem(BeginConnect_workerThread, new object[5] { localEndpoint, host, port, ssl, callback });
	}

	private void BeginConnect_workerThread(object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[4];
		try
		{
			IPEndPoint localEndpoint = (IPEndPoint)((object[])tag)[0];
			string host = (string)((object[])tag)[1];
			int port = (int)((object[])tag)[2];
			bool ssl = (bool)((object[])tag)[3];
			Connect(localEndpoint, host, port, ssl);
			commadCompleted(SocketCallBackResult.Ok, null);
		}
		catch (Exception exception)
		{
			commadCompleted(SocketCallBackResult.Exception, exception);
		}
	}

	public void Disconnect()
	{
		try
		{
			if (m_pSocket != null && m_pSocket.Connected)
			{
				m_pSocket.WriteLine("QUIT");
				m_pSocket.Shutdown(SocketShutdown.Both);
			}
		}
		catch
		{
		}
		m_pSocket = null;
		m_Connected = false;
		m_Supports_Size = false;
		m_Supports_Bdat = false;
		m_Supports_Login = false;
		m_Supports_CramMd5 = false;
		if (m_pLogger != null)
		{
			m_pLogger.Flush();
			m_pLogger = null;
		}
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
		m_pSocket.WriteLine("STARTTLS");
		string text = m_pSocket.ReadLine();
		if (!text.ToUpper().StartsWith("220"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_pSocket.SwitchToSSL_AsClient();
	}

	public void BeginStartTLS(CommadCompleted callback)
	{
		ThreadPool.QueueUserWorkItem(BeginStartTLS_workerThread, callback);
	}

	private void BeginStartTLS_workerThread(object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			StartTLS();
			commadCompleted(SocketCallBackResult.Ok, null);
		}
		catch (Exception exception)
		{
			commadCompleted(SocketCallBackResult.Exception, exception);
		}
	}

	public void Ehlo(string hostName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		if (hostName.Length == 0)
		{
			hostName = System.Net.Dns.GetHostName();
		}
		m_pSocket.WriteLine("EHLO " + hostName);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			m_pSocket.WriteLine("HELO " + hostName);
			text = m_pSocket.ReadLine();
			if (!text.StartsWith("250"))
			{
				throw new Exception(text);
			}
		}
		while (!text.StartsWith("250 "))
		{
			if (text.ToLower().IndexOf("size") > -1)
			{
				m_Supports_Size = true;
			}
			else if (text.ToLower().IndexOf("chunking") > -1)
			{
				m_Supports_Bdat = true;
			}
			else if (text.ToLower().IndexOf("cram-md5") > -1)
			{
				m_Supports_CramMd5 = true;
			}
			else if (text.ToLower().IndexOf("login") > -1)
			{
				m_Supports_Login = true;
			}
			text = m_pSocket.ReadLine();
		}
	}

	public void BeginEhlo(string hostName, CommadCompleted callback)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		if (hostName.Length == 0)
		{
			hostName = System.Net.Dns.GetHostName();
		}
		m_pSocket.BeginWriteLine("EHLO " + hostName, new object[2] { hostName, callback }, OnEhloSendFinished);
	}

	private void OnEhloSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[3]
				{
					((object[])tag)[0],
					commadCompleted,
					memoryStream
				}, OnEhloReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnEhloReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[2]).ToArray());
				if (!@string.StartsWith("250"))
				{
					string text = (string)((object[])tag)[0];
					m_pSocket.BeginWriteLine("HELO " + text, commadCompleted, OnHeloSendFinished);
					return;
				}
				if (@string.ToLower().IndexOf("size") > -1)
				{
					m_Supports_Size = true;
				}
				else if (@string.ToLower().IndexOf("chunking") > -1)
				{
					m_Supports_Bdat = true;
				}
				else if (@string.ToLower().IndexOf("cram-md5") > -1)
				{
					m_Supports_CramMd5 = true;
				}
				else if (@string.ToLower().IndexOf("login") > -1)
				{
					m_Supports_Login = true;
				}
				if (!@string.StartsWith("250 "))
				{
					MemoryStream memoryStream = new MemoryStream();
					m_pSocket.BeginReadLine(memoryStream, 1000, new object[3]
					{
						((object[])tag)[0],
						commadCompleted,
						memoryStream
					}, OnEhloReadServerResponseFinished);
				}
				else
				{
					commadCompleted(SocketCallBackResult.Ok, null);
				}
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnHeloSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnHeloReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnHeloReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("250"))
				{
					throw new Exception(@string);
				}
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	public void Authenticate(string userName, string password)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Supports_CramMd5 && !m_Supports_Login)
		{
			throw new Exception("Authentication isn't supported.");
		}
		if (m_Supports_CramMd5)
		{
			m_pSocket.WriteLine("AUTH CRAM-MD5");
			string text = m_pSocket.ReadLine();
			if (!text.StartsWith("334"))
			{
				throw new Exception(text);
			}
			string @string = Encoding.ASCII.GetString(Convert.FromBase64String(text.Split(' ')[1]));
			HMACMD5 hMACMD = new HMACMD5(Encoding.ASCII.GetBytes(password));
			byte[] array = hMACMD.ComputeHash(Encoding.ASCII.GetBytes(@string));
			string text2 = BitConverter.ToString(array).ToLower().Replace("-", "");
			m_pSocket.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + " " + text2)));
			text = m_pSocket.ReadLine();
			if (!text.StartsWith("235"))
			{
				throw new Exception(text);
			}
			m_Authenticated = true;
		}
		else if (m_Supports_Login)
		{
			m_pSocket.WriteLine("AUTH LOGIN");
			string text = m_pSocket.ReadLine();
			if (!text.StartsWith("334"))
			{
				throw new Exception(text);
			}
			m_pSocket.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(userName)));
			text = m_pSocket.ReadLine();
			if (!text.StartsWith("334"))
			{
				throw new Exception(text);
			}
			m_pSocket.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(password)));
			text = m_pSocket.ReadLine();
			if (!text.StartsWith("235"))
			{
				throw new Exception(text);
			}
			m_Authenticated = true;
		}
	}

	public void BeginAuthenticate(string userName, string password, CommadCompleted callback)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Supports_CramMd5 && !m_Supports_Login)
		{
			throw new Exception("Authentication isn't supported.");
		}
		if (m_Supports_CramMd5)
		{
			m_pSocket.BeginWriteLine("AUTH CRAM-MD5", new object[3] { userName, password, callback }, OnAuthCramMd5SendFinished);
		}
		else if (m_Supports_Login)
		{
			m_pSocket.BeginWriteLine("AUTH LOGIN", new object[3] { userName, password, callback }, OnAuthLoginSendFinished);
		}
	}

	private void OnAuthCramMd5SendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[2];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[4]
				{
					((object[])tag)[0],
					((object[])tag)[1],
					commadCompleted,
					memoryStream
				}, OnAuthCramMd5ReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthCramMd5ReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[2];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[3]).ToArray());
				if (!@string.StartsWith("334"))
				{
					throw new Exception(@string);
				}
				string string2 = Encoding.ASCII.GetString(Convert.FromBase64String(@string.Split(' ')[1]));
				string text = (string)((object[])tag)[0];
				string s = (string)((object[])tag)[1];
				HMACMD5 hMACMD = new HMACMD5(Encoding.ASCII.GetBytes(s));
				byte[] array = hMACMD.ComputeHash(Encoding.ASCII.GetBytes(string2));
				string text2 = BitConverter.ToString(array).ToLower().Replace("-", "");
				m_pSocket.BeginWriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(text + " " + text2)), commadCompleted, OnAuthCramMd5UserPwdSendFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthCramMd5UserPwdSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnAuthCramMd5UserPwdReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthCramMd5UserPwdReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("235"))
				{
					throw new Exception(@string);
				}
				m_Authenticated = true;
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthLoginSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[2];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[4]
				{
					((object[])tag)[0],
					((object[])tag)[1],
					commadCompleted,
					memoryStream
				}, OnAuthLoginReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthLoginReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[2];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[3]).ToArray());
				if (!@string.StartsWith("334"))
				{
					throw new Exception(@string);
				}
				string s = (string)((object[])tag)[0];
				m_pSocket.BeginWriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(s)), new object[2]
				{
					((object[])tag)[1],
					commadCompleted
				}, OnAuthLoginUserSendFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthLoginUserSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[3]
				{
					((object[])tag)[0],
					commadCompleted,
					memoryStream
				}, OnAuthLoginUserReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthLoginUserReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[2]).ToArray());
				if (!@string.StartsWith("334"))
				{
					throw new Exception(@string);
				}
				string s = (string)((object[])tag)[0];
				m_pSocket.BeginWriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(s)), new object[2]
				{
					((object[])tag)[1],
					commadCompleted
				}, OnAuthLoginPasswordSendFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthLoginPasswordSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnAuthLoginPwdReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnAuthLoginPwdReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("235"))
				{
					throw new Exception(@string);
				}
				m_Authenticated = true;
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	public void SetSender(string senderEmail, long messageSize)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		if (m_Supports_Size && messageSize > -1)
		{
			m_pSocket.WriteLine("MAIL FROM:<" + senderEmail + "> SIZE=" + messageSize);
		}
		else
		{
			m_pSocket.WriteLine("MAIL FROM:<" + senderEmail + ">");
		}
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception(text);
		}
	}

	public void BeginSetSender(string senderEmail, long messageSize, CommadCompleted callback)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		if (m_Supports_Size && messageSize > -1)
		{
			m_pSocket.BeginWriteLine("MAIL FROM:<" + senderEmail + "> SIZE=" + messageSize, callback, OnMailSendFinished);
		}
		else
		{
			m_pSocket.BeginWriteLine("MAIL FROM:<" + senderEmail + ">", callback, OnMailSendFinished);
		}
	}

	private void OnMailSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnMailReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnMailReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("250"))
				{
					throw new Exception(@string);
				}
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	public void AddRecipient(string recipientEmail)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		m_pSocket.WriteLine("RCPT TO:<" + recipientEmail + ">");
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception(text);
		}
	}

	public void BeginAddRecipient(string recipientEmail, CommadCompleted callback)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		m_pSocket.BeginWriteLine("RCPT TO:<" + recipientEmail + ">", callback, OnRcptSendFinished);
	}

	private void OnRcptSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnRcptReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnRcptReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("250"))
				{
					throw new Exception(@string);
				}
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	public void SendMessage(Stream message)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		string text;
		if (m_Supports_Bdat)
		{
			m_pSocket.WriteLine("BDAT " + (message.Length - message.Position) + " LAST");
			m_pSocket.Write(message);
			text = m_pSocket.ReadLine();
			if (!text.StartsWith("250"))
			{
				throw new Exception(text);
			}
			return;
		}
		m_pSocket.WriteLine("DATA");
		text = m_pSocket.ReadLine();
		if (!text.StartsWith("354"))
		{
			throw new Exception(text);
		}
		m_pSocket.WritePeriodTerminated(message);
		text = m_pSocket.ReadLine();
		if (text.StartsWith("250"))
		{
			return;
		}
		throw new Exception(text);
	}

	public void BeginSendMessage(Stream message, CommadCompleted callback)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		if (m_Supports_Bdat)
		{
			m_pSocket.BeginWriteLine("BDAT " + (message.Length - message.Position) + " LAST", new object[2] { message, callback }, OnBdatSendFinished);
		}
		else
		{
			m_pSocket.BeginWriteLine("DATA", new object[2] { message, callback }, OnDataSendFinished);
		}
	}

	private void OnBdatSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				m_pSocket.BeginWrite((Stream)((object[])tag)[0], commadCompleted, OnBdatDataSendFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnBdatDataSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnBdatReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnBdatReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("250"))
				{
					throw new Exception(@string);
				}
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnDataSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[3]
				{
					(Stream)((object[])tag)[0],
					commadCompleted,
					memoryStream
				}, OnDataReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnDataReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[1];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[2]).ToArray());
				if (!@string.StartsWith("354"))
				{
					throw new Exception(@string);
				}
				Stream stream = (Stream)((object[])tag)[0];
				m_pSocket.BeginWritePeriodTerminated(stream, commadCompleted, OnDataMessageSendFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnDataMessageSendFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)tag;
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				MemoryStream memoryStream = new MemoryStream();
				m_pSocket.BeginReadLine(memoryStream, 1000, new object[2] { commadCompleted, memoryStream }, OnDataMessageSendReadServerResponseFinished);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	private void OnDataMessageSendReadServerResponseFinished(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		CommadCompleted commadCompleted = (CommadCompleted)((object[])tag)[0];
		try
		{
			if (result == SocketCallBackResult.Ok)
			{
				string @string = Encoding.ASCII.GetString(((MemoryStream)((object[])tag)[1]).ToArray());
				if (!@string.StartsWith("250"))
				{
					throw new Exception(@string);
				}
				commadCompleted(SocketCallBackResult.Ok, null);
			}
			else
			{
				HandleSocketError(result, exception);
			}
		}
		catch (Exception exception2)
		{
			commadCompleted(SocketCallBackResult.Exception, exception2);
		}
	}

	public void Reset()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		m_pSocket.WriteLine("RSET");
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception(text);
		}
	}

	private void HandleSocketError(SocketCallBackResult result, Exception x)
	{
		if (result == SocketCallBackResult.Exception)
		{
			throw x;
		}
		throw new Exception(result.ToString());
	}

	public static void QuickSendSmartHost(string smartHost, int port, string hostName, LumiSoft.Net.Mime.Mime message)
	{
		QuickSendSmartHost(smartHost, port, hostName, "", "", message);
	}

	public static void QuickSendSmartHost(string smartHost, int port, string hostName, string userName, string password, LumiSoft.Net.Mime.Mime message)
	{
		QuickSendSmartHost(smartHost, port, ssl: false, hostName, userName, password, message);
	}

	public static void QuickSendSmartHost(string smartHost, int port, bool ssl, string hostName, string userName, string password, LumiSoft.Net.Mime.Mime message)
	{
		string from = "";
		if (message.MainEntity.From != null)
		{
			MailboxAddress[] mailboxes = message.MainEntity.From.Mailboxes;
			if (mailboxes.Length > 0)
			{
				from = mailboxes[0].EmailAddress;
			}
		}
		ArrayList arrayList = new ArrayList();
		if (message.MainEntity.To != null)
		{
			MailboxAddress[] mailboxes = message.MainEntity.To.Mailboxes;
			MailboxAddress[] array = mailboxes;
			foreach (MailboxAddress mailboxAddress in array)
			{
				arrayList.Add(mailboxAddress.EmailAddress);
			}
		}
		if (message.MainEntity.Cc != null)
		{
			MailboxAddress[] mailboxes = message.MainEntity.Cc.Mailboxes;
			MailboxAddress[] array = mailboxes;
			foreach (MailboxAddress mailboxAddress in array)
			{
				arrayList.Add(mailboxAddress.EmailAddress);
			}
		}
		if (message.MainEntity.Bcc != null)
		{
			MailboxAddress[] mailboxes = message.MainEntity.Bcc.Mailboxes;
			MailboxAddress[] array = mailboxes;
			foreach (MailboxAddress mailboxAddress in array)
			{
				arrayList.Add(mailboxAddress.EmailAddress);
			}
		}
		string[] array2 = new string[arrayList.Count];
		arrayList.CopyTo(array2);
		MemoryStream memoryStream = new MemoryStream();
		message.ToStream(memoryStream);
		memoryStream.Position = 0L;
		QuickSendSmartHost(smartHost, port, ssl, hostName, userName, password, from, array2, memoryStream);
	}

	public static void QuickSendSmartHost(string smartHost, int port, string hostName, string from, string[] to, Stream messageStream)
	{
		QuickSendSmartHost(smartHost, port, ssl: false, hostName, "", "", from, to, messageStream);
	}

	public static void QuickSendSmartHost(string smartHost, int port, string hostName, string userName, string password, string from, string[] to, Stream messageStream)
	{
		QuickSendSmartHost(smartHost, port, ssl: false, hostName, userName, password, from, to, messageStream);
	}

	public static void QuickSendSmartHost(string smartHost, int port, bool ssl, string hostName, string userName, string password, string from, string[] to, Stream messageStream)
	{
		using SmtpClientEx smtpClientEx = new SmtpClientEx();
		smtpClientEx.Connect(smartHost, port, ssl);
		if (userName.Length > 0)
		{
			smtpClientEx.Authenticate(userName, password);
		}
		smtpClientEx.Ehlo(hostName);
		smtpClientEx.SetSender(MailboxAddress.Parse(from).EmailAddress, messageStream.Length - messageStream.Position);
		foreach (string mailbox in to)
		{
			smtpClientEx.AddRecipient(MailboxAddress.Parse(mailbox).EmailAddress);
		}
		smtpClientEx.SendMessage(messageStream);
	}
}

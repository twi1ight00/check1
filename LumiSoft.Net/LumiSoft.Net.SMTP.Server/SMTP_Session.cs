using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LumiSoft.Net.AUTH;

namespace LumiSoft.Net.SMTP.Server;

public class SMTP_Session : ISocketServerSession
{
	private SMTP_Cmd_Validator m_CmdValidator = null;

	private SocketEx m_pSocket = null;

	private BindInfo m_pBindInfo = null;

	private SMTP_Server m_pServer = null;

	private Stream m_pMsgStream = null;

	private long m_BDAT_ReadedCount = 0L;

	private string m_SessionID = "";

	private string m_EhloName = "";

	private string m_UserName = "";

	private bool m_Authenticated = false;

	private string m_Reverse_path = "";

	private Hashtable m_Forward_path = null;

	private int m_BadCmdCount = 0;

	private BodyType m_BodyType;

	private bool m_BDat = false;

	private DateTime m_SessionStart;

	private object m_Tag = null;

	public string SessionID => m_SessionID;

	public string EhloName => m_EhloName;

	public bool Authenticated => m_Authenticated;

	public string UserName => m_UserName;

	public BodyType BodyType => m_BodyType;

	public IPEndPoint LocalEndPoint => (IPEndPoint)m_pSocket.LocalEndPoint;

	public IPEndPoint RemoteEndPoint => (IPEndPoint)m_pSocket.RemoteEndPoint;

	public string MailFrom => m_Reverse_path;

	public string[] MailTo
	{
		get
		{
			string[] array = new string[m_Forward_path.Count];
			m_Forward_path.Values.CopyTo(array, 0);
			return array;
		}
	}

	public DateTime SessionStartTime => m_SessionStart;

	public int ExpectedTimeout => (int)((m_pServer.SessionIdleTimeOut - (DateTime.Now.Ticks - SessionLastDataTime.Ticks) / 10000) / 1000);

	public DateTime SessionLastDataTime => m_pSocket.LastActivity;

	public object Tag
	{
		get
		{
			return m_Tag;
		}
		set
		{
			m_Tag = value;
		}
	}

	public SocketLogger SessionActiveLog => m_pSocket.Logger;

	public long ReadedCount => m_pSocket.ReadedCount;

	public long WrittenCount => m_pSocket.WrittenCount;

	public bool IsSecureConnection => m_pSocket.SSL;

	internal SMTP_Session(Socket clientSocket, BindInfo bindInfo, SMTP_Server server, SocketLogger logWriter)
	{
		m_pSocket = new SocketEx(clientSocket);
		m_pBindInfo = bindInfo;
		m_pServer = server;
		m_SessionID = Guid.NewGuid().ToString();
		m_BodyType = BodyType.x7_bit;
		m_Forward_path = new Hashtable();
		m_CmdValidator = new SMTP_Cmd_Validator();
		m_SessionStart = DateTime.Now;
		if (m_pServer.LogCommands)
		{
			m_pSocket.Logger = logWriter;
			m_pSocket.Logger.SessionID = m_SessionID;
		}
		StartSession();
	}

	private void StartSession()
	{
		m_pServer.AddSession(this);
		try
		{
			ValidateIP_EventArgs validateIP_EventArgs = m_pServer.OnValidate_IpAddress(this);
			if (validateIP_EventArgs.Validated)
			{
				if (m_pBindInfo.SSL)
				{
					try
					{
						m_pSocket.SwitchToSSL(m_pBindInfo.SSL_Certificate);
						if (m_pSocket.Logger != null)
						{
							m_pSocket.Logger.AddTextEntry("SSL negotiation completed successfully.");
						}
					}
					catch (Exception ex)
					{
						if (m_pSocket.Logger != null)
						{
							m_pSocket.Logger.AddTextEntry("SSL handshake failed ! " + ex.Message);
							EndSession();
							return;
						}
					}
				}
				if (m_pServer.GreetingText.Length > 0)
				{
					m_pSocket.WriteLine("220 " + m_pServer.GreetingText);
				}
				else
				{
					m_pSocket.WriteLine("220 " + m_pServer.HostName + " SMTP Server ready");
				}
				BeginRecieveCmd();
			}
			else
			{
				if (validateIP_EventArgs.ErrorText.Length > 0)
				{
					m_pSocket.WriteLine(validateIP_EventArgs.ErrorText);
				}
				EndSession();
			}
		}
		catch (Exception ex)
		{
			OnError(ex);
		}
	}

	private void EndSession()
	{
		try
		{
			try
			{
				if (m_pMsgStream != null)
				{
					m_pServer.OnMessageStoringCompleted(this, "Message storing not completed successfully", m_pMsgStream);
					m_pMsgStream = null;
				}
			}
			catch
			{
			}
			if (m_pSocket != null)
			{
				if (m_pServer.LogCommands)
				{
					m_pSocket.Logger.Flush();
				}
				m_pSocket.Shutdown(SocketShutdown.Both);
				m_pSocket.Disconnect();
				m_pSocket = null;
			}
		}
		catch
		{
		}
		finally
		{
			m_pServer.RemoveSession(this);
		}
	}

	public void OnSessionTimeout()
	{
		try
		{
			m_pSocket.WriteLine("421 Session timeout, closing transmission channel");
		}
		catch
		{
		}
		EndSession();
	}

	private void OnError(Exception x)
	{
		try
		{
			SocketException ex = null;
			if (x is SocketException)
			{
				ex = (SocketException)x;
			}
			else if (x.InnerException != null && x.InnerException is SocketException)
			{
				ex = (SocketException)x.InnerException;
			}
			if (ex != null && (ex.ErrorCode == 10054 || ex.ErrorCode == 10053))
			{
				if (m_pServer.LogCommands)
				{
					m_pSocket.Logger.AddTextEntry("Client aborted/disconnected");
				}
				EndSession();
			}
			else
			{
				m_pServer.OnSysError("", x);
			}
		}
		catch (Exception x2)
		{
			m_pServer.OnSysError("", x2);
		}
	}

	private void BeginRecieveCmd()
	{
		MemoryStream memoryStream = new MemoryStream();
		m_pSocket.BeginReadLine(memoryStream, 1024, memoryStream, EndRecieveCmd);
	}

	private void EndRecieveCmd(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		try
		{
			switch (result)
			{
			case SocketCallBackResult.Ok:
			{
				MemoryStream memoryStream = (MemoryStream)tag;
				string @string = Encoding.Default.GetString(memoryStream.ToArray());
				if (SwitchCommand(@string))
				{
					EndSession();
				}
				break;
			}
			case SocketCallBackResult.LengthExceeded:
				m_pSocket.WriteLine("500 Line too long.");
				BeginRecieveCmd();
				break;
			case SocketCallBackResult.SocketClosed:
				EndSession();
				break;
			case SocketCallBackResult.Exception:
				OnError(exception);
				break;
			}
		}
		catch (Exception x)
		{
			OnError(x);
		}
	}

	private bool SwitchCommand(string SMTP_commandTxt)
	{
		string[] array = SMTP_commandTxt.TrimStart().Split(' ');
		string text = array[0].ToUpper().Trim();
		string argsText = Core.GetArgsText(SMTP_commandTxt, text);
		bool flag = true;
		switch (text)
		{
		case "HELO":
			HELO(argsText);
			flag = false;
			break;
		case "EHLO":
			EHLO(argsText);
			flag = false;
			break;
		case "STARTTLS":
			STARTTLS(argsText);
			flag = false;
			break;
		case "AUTH":
			AUTH(argsText);
			break;
		case "MAIL":
			MAIL(argsText);
			flag = false;
			break;
		case "RCPT":
			RCPT(argsText);
			flag = false;
			break;
		case "DATA":
			BeginDataCmd(argsText);
			flag = false;
			break;
		case "BDAT":
			BeginBDATCmd(argsText);
			flag = false;
			break;
		case "RSET":
			RSET(argsText);
			flag = false;
			break;
		case "HELP":
			HELP();
			break;
		case "NOOP":
			NOOP();
			flag = false;
			break;
		case "QUIT":
			QUIT(argsText);
			flag = false;
			return true;
		default:
			m_pSocket.WriteLine("500 command unrecognized");
			if (m_BadCmdCount > m_pServer.MaxBadCommands - 1)
			{
				m_pSocket.WriteLine("421 Too many bad commands, closing transmission channel");
				return true;
			}
			m_BadCmdCount++;
			break;
		}
		if (flag)
		{
			BeginRecieveCmd();
		}
		return false;
	}

	private void HELO(string argsText)
	{
		m_EhloName = argsText;
		ResetState();
		m_pSocket.BeginWriteLine("250 " + m_pServer.HostName + " Hello [" + RemoteEndPoint.Address.ToString() + "]", EndSend);
		m_CmdValidator.Helo_ok = true;
	}

	private void EHLO(string argsText)
	{
		m_EhloName = argsText;
		ResetState();
		string text = "";
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Login) != 0)
		{
			text += "LOGIN ";
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Cram_md5) != 0)
		{
			text += "CRAM-MD5 ";
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Digest_md5) != 0)
		{
			text += "DIGEST-MD5 ";
		}
		text = text.Trim();
		string text2 = "";
		string text3 = text2;
		text2 = text3 + "250-" + m_pServer.HostName + " Hello [" + RemoteEndPoint.Address.ToString() + "]\r\n";
		text2 += "250-PIPELINING\r\n";
		object obj = text2;
		text2 = string.Concat(obj, "250-SIZE ", m_pServer.MaxMessageSize, "\r\n");
		text2 += "250-8BITMIME\r\n";
		text2 += "250-BINARYMIME\r\n";
		text2 += "250-CHUNKING\r\n";
		if (text.Length > 0)
		{
			text2 = text2 + "250-AUTH " + text + "\r\n";
		}
		if (!m_pSocket.SSL && m_pBindInfo.SSL_Certificate != null)
		{
			text2 += "250-STARTTLS\r\n";
		}
		text2 += "250 Ok\r\n";
		m_pSocket.BeginWriteLine(text2, null, EndSend);
		m_CmdValidator.Helo_ok = true;
	}

	private void STARTTLS(string argsText)
	{
		if (m_pSocket.SSL)
		{
			m_pSocket.WriteLine("500 TLS already started !");
			return;
		}
		if (m_pBindInfo.SSL_Certificate == null)
		{
			m_pSocket.WriteLine("454 TLS not available, SSL certificate isn't specified !");
			return;
		}
		m_pSocket.WriteLine("220 Ready to start TLS");
		try
		{
			m_pSocket.SwitchToSSL(m_pBindInfo.SSL_Certificate);
			if (m_pServer.LogCommands)
			{
				m_pSocket.Logger.AddTextEntry("TLS negotiation completed successfully.");
			}
		}
		catch (Exception ex)
		{
			m_pSocket.WriteLine("500 TLS handshake failed ! " + ex.Message);
		}
		ResetState();
		BeginRecieveCmd();
	}

	private void AUTH(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine("503 already authenticated");
			return;
		}
		string userName = "";
		string passwordData = "";
		AuthUser_EventArgs authUser_EventArgs = null;
		string[] array = argsText.Split(' ');
		switch (array[0].ToUpper())
		{
		case "PLAIN":
			m_pSocket.WriteLine("504 Unrecognized authentication type.");
			break;
		case "LOGIN":
		{
			if (array.Length == 1)
			{
				m_pSocket.WriteLine("334 VXNlcm5hbWU6");
				string text6 = m_pSocket.ReadLine();
				if (text6.Length > 0)
				{
					userName = Encoding.Default.GetString(Convert.FromBase64String(text6));
				}
			}
			else
			{
				userName = Encoding.Default.GetString(Convert.FromBase64String(array[1]));
			}
			m_pSocket.WriteLine("334 UGFzc3dvcmQ6");
			string text7 = m_pSocket.ReadLine();
			if (text7.Length > 0)
			{
				passwordData = Encoding.Default.GetString(Convert.FromBase64String(text7));
			}
			authUser_EventArgs = m_pServer.OnAuthUser(this, userName, passwordData, "", AuthType.Plain);
			if (authUser_EventArgs.Validated)
			{
				m_pSocket.WriteLine("235 Authentication successful.");
				m_Authenticated = true;
				m_UserName = userName;
			}
			else
			{
				m_pSocket.WriteLine("535 Authentication failed");
			}
			break;
		}
		case "CRAM-MD5":
		{
			string text5 = "<" + Guid.NewGuid().ToString().ToLower() + ">";
			m_pSocket.WriteLine("334 " + Convert.ToBase64String(Encoding.ASCII.GetBytes(text5)));
			string s = m_pSocket.ReadLine();
			s = Encoding.Default.GetString(Convert.FromBase64String(s));
			string[] array3 = s.Split(' ');
			userName = array3[0];
			authUser_EventArgs = m_pServer.OnAuthUser(this, userName, array3[1], text5, AuthType.CRAM_MD5);
			if (authUser_EventArgs.Validated)
			{
				m_pSocket.WriteLine("235 Authentication successful.");
				m_Authenticated = true;
				m_UserName = userName;
			}
			else
			{
				m_pSocket.WriteLine("535 Authentication failed");
			}
			break;
		}
		case "DIGEST-MD5":
		{
			string hostName = m_pServer.HostName;
			string text = AuthHelper.GenerateNonce();
			m_pSocket.WriteLine("334 " + AuthHelper.Base64en(AuthHelper.Create_Digest_Md5_ServerResponse(hostName, text)));
			string text2 = AuthHelper.Base64de(m_pSocket.ReadLine());
			if (text2.IndexOf("realm=\"" + hostName + "\"") > -1 && text2.IndexOf("nonce=\"" + text + "\"") > -1)
			{
				string passwordData2 = "";
				string text3 = "";
				string[] array2 = text2.Split(',');
				foreach (string text4 in array2)
				{
					if (text4.StartsWith("username="))
					{
						userName = text4.Split(new char[1] { '=' }, 2)[1].Replace("\"", "");
					}
					else if (text4.StartsWith("response="))
					{
						passwordData2 = text4.Split(new char[1] { '=' }, 2)[1];
					}
					else if (text4.StartsWith("cnonce="))
					{
						text3 = text4.Split(new char[1] { '=' }, 2)[1].Replace("\"", "");
					}
				}
				authUser_EventArgs = m_pServer.OnAuthUser(this, userName, passwordData2, text2, AuthType.DIGEST_MD5);
				if (authUser_EventArgs.Validated)
				{
					m_pSocket.WriteLine("334 " + AuthHelper.Base64en("rspauth=" + authUser_EventArgs.ReturnData));
					text2 = m_pSocket.ReadLine();
					if (text2 == "")
					{
						m_pSocket.WriteLine("235 Authentication successful.");
						m_Authenticated = true;
						m_UserName = userName;
					}
					else
					{
						m_pSocket.WriteLine("535 Authentication failed");
					}
				}
				else
				{
					m_pSocket.WriteLine("535 Authentication failed");
				}
			}
			else
			{
				m_pSocket.WriteLine("535 Authentication failed");
			}
			break;
		}
		default:
			m_pSocket.WriteLine("504 Unrecognized authentication type.");
			break;
		}
	}

	private void MAIL(string argsText)
	{
		if (!m_CmdValidator.MayHandle_MAIL)
		{
			if (m_CmdValidator.MailFrom_ok)
			{
				m_pSocket.BeginWriteLine("503 Sender already specified", EndSend);
			}
			else
			{
				m_pSocket.BeginWriteLine("503 Bad sequence of commands", EndSend);
			}
			return;
		}
		string text = "";
		long num = 0L;
		BodyType bodyType = BodyType.x7_bit;
		bool flag = false;
		while (argsText.Length > 0)
		{
			if (argsText.ToLower().StartsWith("from:"))
			{
				argsText = argsText.Substring(5).Trim();
				if (argsText.IndexOf(" ") > -1)
				{
					text = argsText.Substring(0, argsText.IndexOf(" "));
					argsText = argsText.Substring(argsText.IndexOf(" ")).Trim();
				}
				else
				{
					text = argsText;
					argsText = "";
				}
				if (text.StartsWith("<") && text.EndsWith(">"))
				{
					text = text.Substring(1, text.Length - 2);
				}
				flag = true;
			}
			else if (argsText.ToLower().StartsWith("size="))
			{
				argsText = argsText.Substring(5).Trim();
				string text2 = "";
				if (argsText.IndexOf(" ") > -1)
				{
					text2 = argsText.Substring(0, argsText.IndexOf(" "));
					argsText = argsText.Substring(argsText.IndexOf(" ")).Trim();
				}
				else
				{
					text2 = argsText;
					argsText = "";
				}
				if (!Core.IsNumber(text2))
				{
					m_pSocket.BeginWriteLine("501 SIZE parameter value is invalid. Syntax:{MAIL FROM:<address> [SIZE=msgSize] [BODY=8BITMIME]}", EndSend);
					return;
				}
				num = Convert.ToInt64(text2);
			}
			else if (argsText.ToLower().StartsWith("body="))
			{
				argsText = argsText.Substring(5).Trim();
				string text3 = "";
				if (argsText.IndexOf(" ") > -1)
				{
					text3 = argsText.Substring(0, argsText.IndexOf(" "));
					argsText = argsText.Substring(argsText.IndexOf(" ")).Trim();
				}
				else
				{
					text3 = argsText;
					argsText = "";
				}
				switch (text3.ToUpper())
				{
				case "7BIT":
					bodyType = BodyType.x7_bit;
					break;
				case "8BITMIME":
					bodyType = BodyType.x8_bit;
					break;
				case "BINARYMIME":
					bodyType = BodyType.binary;
					break;
				default:
					m_pSocket.BeginWriteLine("501 BODY parameter value is invalid. Syntax:{MAIL FROM:<address> [BODY=(7BIT/8BITMIME)]}", EndSend);
					return;
				}
			}
			else
			{
				if (!argsText.ToLower().StartsWith("auth="))
				{
					m_pSocket.BeginWriteLine("501 Error in parameters. Syntax:{MAIL FROM:<address> [SIZE=msgSize] [BODY=8BITMIME]}", EndSend);
					return;
				}
				argsText = argsText.Substring(5).Trim();
				string text4 = "";
				if (argsText.IndexOf(" ") > -1)
				{
					text4 = argsText.Substring(0, argsText.IndexOf(" "));
					argsText = argsText.Substring(argsText.IndexOf(" ")).Trim();
				}
				else
				{
					text4 = argsText;
					argsText = "";
				}
			}
		}
		if (!flag)
		{
			m_pSocket.BeginWriteLine("501 Required param FROM: is missing. Syntax:{MAIL FROM:<address> [SIZE=msgSize] [BODY=8BITMIME]}", EndSend);
		}
		else if (m_pServer.MaxMessageSize > num)
		{
			ValidateSender_EventArgs validateSender_EventArgs = m_pServer.OnValidate_MailFrom(this, text, text);
			if (validateSender_EventArgs.Validated)
			{
				ResetState();
				m_Reverse_path = text;
				m_CmdValidator.MailFrom_ok = true;
				m_BodyType = bodyType;
				m_pSocket.BeginWriteLine("250 OK <" + text + "> Sender ok", EndSend);
			}
			else if (validateSender_EventArgs.ErrorText != null && validateSender_EventArgs.ErrorText.Length > 0)
			{
				m_pSocket.BeginWriteLine("550 " + validateSender_EventArgs.ErrorText, EndSend);
			}
			else
			{
				m_pSocket.BeginWriteLine("550 You are refused to send mail here", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("552 Message exceeds allowed size", EndSend);
		}
	}

	private void RCPT(string argsText)
	{
		if (!m_CmdValidator.MayHandle_RCPT || m_BDat)
		{
			m_pSocket.BeginWriteLine("503 Bad sequence of commands", EndSend);
			return;
		}
		if (m_Forward_path.Count > m_pServer.MaxRecipients)
		{
			m_pSocket.BeginWriteLine("452 Too many recipients", EndSend);
			return;
		}
		string text = "";
		long num = 0L;
		bool flag = false;
		while (argsText.Length > 0)
		{
			if (argsText.ToLower().StartsWith("to:"))
			{
				argsText = argsText.Substring(3).Trim();
				if (argsText.IndexOf(" ") > -1)
				{
					text = argsText.Substring(0, argsText.IndexOf(" "));
					argsText = argsText.Substring(argsText.IndexOf(" ")).Trim();
				}
				else
				{
					text = argsText;
					argsText = "";
				}
				if (text.StartsWith("<") && text.EndsWith(">"))
				{
					text = text.Substring(1, text.Length - 2);
				}
				if (text.Length == 0)
				{
					m_pSocket.BeginWriteLine("501 Recipient address isn't specified. Syntax:{RCPT TO:<address> [SIZE=msgSize]}", EndSend);
					return;
				}
				flag = true;
				continue;
			}
			if (argsText.ToLower().StartsWith("size="))
			{
				argsText = argsText.Substring(5).Trim();
				string text2 = "";
				if (argsText.IndexOf(" ") > -1)
				{
					text2 = argsText.Substring(0, argsText.IndexOf(" "));
					argsText = argsText.Substring(argsText.IndexOf(" ")).Trim();
				}
				else
				{
					text2 = argsText;
					argsText = "";
				}
				if (Core.IsNumber(text2))
				{
					num = Convert.ToInt64(text2);
					continue;
				}
				m_pSocket.BeginWriteLine("501 SIZE parameter value is invalid. Syntax:{RCPT TO:<address> [SIZE=msgSize]}", EndSend);
				return;
			}
			m_pSocket.BeginWriteLine("501 Error in parameters. Syntax:{RCPT TO:<address> [SIZE=msgSize]}", EndSend);
			return;
		}
		if (!flag)
		{
			m_pSocket.BeginWriteLine("501 Required param TO: is missing. Syntax:<RCPT TO:{address> [SIZE=msgSize]}", EndSend);
		}
		else if (m_pServer.MaxMessageSize > num)
		{
			ValidateRecipient_EventArgs validateRecipient_EventArgs = m_pServer.OnValidate_MailTo(this, text, text, m_Authenticated);
			if (validateRecipient_EventArgs.Validated)
			{
				if (m_pServer.Validate_MailBoxSize(this, text, num))
				{
					if (!m_Forward_path.Contains(text))
					{
						m_Forward_path.Add(text, text);
					}
					m_CmdValidator.RcptTo_ok = true;
					m_pSocket.BeginWriteLine("250 OK <" + text + "> Recipient ok", EndSend);
				}
				else
				{
					m_pSocket.BeginWriteLine("552 Mailbox size limit exceeded", EndSend);
				}
			}
			else if (validateRecipient_EventArgs.LocalRecipient)
			{
				m_pSocket.BeginWriteLine("550 <" + text + "> No such user here", EndSend);
			}
			else
			{
				m_pSocket.BeginWriteLine("550 <" + text + "> Relay not allowed", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("552 Message exceeds allowed size", EndSend);
		}
	}

	private void BeginDataCmd(string argsText)
	{
		if (argsText.Length > 0)
		{
			m_pSocket.BeginWriteLine("500 Syntax error. Syntax:{DATA}", EndSend);
			return;
		}
		if (!m_CmdValidator.MayHandle_DATA || m_BDat)
		{
			m_pSocket.BeginWriteLine("503 Bad sequence of commands", EndSend);
			return;
		}
		if (m_Forward_path.Count == 0)
		{
			m_pSocket.BeginWriteLine("554 no valid recipients given", EndSend);
			return;
		}
		GetMessageStoreStream_eArgs getMessageStoreStream_eArgs = m_pServer.OnGetMessageStoreStream(this);
		m_pMsgStream = getMessageStoreStream_eArgs.StoreStream;
		m_pSocket.WriteLine("354 Start mail input; end with <CRLF>.<CRLF>");
		string text = "Received: from " + Core.GetHostName(RemoteEndPoint.Address) + " (" + RemoteEndPoint.Address.ToString() + ")\r\n";
		string text2 = text;
		text = text2 + "\tby " + m_pServer.HostName + " with SMTP; " + DateTime.Now.ToUniversalTime().ToString("r", DateTimeFormatInfo.InvariantInfo) + "\r\n";
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		m_pMsgStream.Write(bytes, 0, bytes.Length);
		m_pSocket.BeginReadPeriodTerminated(m_pMsgStream, m_pServer.MaxMessageSize, null, EndDataCmd);
	}

	private void EndDataCmd(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		try
		{
			switch (result)
			{
			case SocketCallBackResult.Ok:
			{
				MessageStoringCompleted_eArgs messageStoringCompleted_eArgs = m_pServer.OnMessageStoringCompleted(this, null, m_pMsgStream);
				if (messageStoringCompleted_eArgs.ServerReply.ErrorReply)
				{
					m_pSocket.BeginWriteLine(messageStoringCompleted_eArgs.ServerReply.ToSmtpReply("500", "Error storing message"), EndSend);
				}
				else
				{
					m_pSocket.BeginWriteLine(messageStoringCompleted_eArgs.ServerReply.ToSmtpReply("250", "OK"), EndSend);
				}
				break;
			}
			case SocketCallBackResult.LengthExceeded:
				m_pServer.OnMessageStoringCompleted(this, "Requested mail action aborted: exceeded storage allocation", m_pMsgStream);
				m_pSocket.BeginWriteLine("552 Requested mail action aborted: exceeded storage allocation", EndSend);
				break;
			case SocketCallBackResult.SocketClosed:
				if (m_pMsgStream != null)
				{
					m_pServer.OnMessageStoringCompleted(this, "SocketClosed", m_pMsgStream);
					m_pMsgStream = null;
				}
				EndSession();
				break;
			case SocketCallBackResult.Exception:
				if (m_pMsgStream != null)
				{
					m_pServer.OnMessageStoringCompleted(this, "Exception: " + exception.Message, m_pMsgStream);
					m_pMsgStream = null;
				}
				OnError(exception);
				break;
			}
			ResetState();
		}
		catch (Exception x)
		{
			OnError(x);
		}
	}

	private void BeginBDATCmd(string argsText)
	{
		if (!m_CmdValidator.MayHandle_BDAT)
		{
			m_pSocket.BeginWriteLine("503 Bad sequence of commands", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (array.Length > 0 && array.Length < 3)
		{
			if (Core.IsNumber(array[0]))
			{
				int num = Convert.ToInt32(array[0]);
				bool flag = false;
				if (array.Length == 2)
				{
					flag = true;
				}
				if (!m_BDat)
				{
					GetMessageStoreStream_eArgs getMessageStoreStream_eArgs = m_pServer.OnGetMessageStoreStream(this);
					m_pMsgStream = getMessageStoreStream_eArgs.StoreStream;
					string text = "Received: from " + Core.GetHostName(RemoteEndPoint.Address) + " (" + RemoteEndPoint.Address.ToString() + ")\r\n";
					string text2 = text;
					text = text2 + "\tby " + m_pServer.HostName + " with SMTP; " + DateTime.Now.ToUniversalTime().ToString("r", DateTimeFormatInfo.InvariantInfo) + "\r\n";
					byte[] bytes = Encoding.ASCII.GetBytes(text);
					m_pMsgStream.Write(bytes, 0, bytes.Length);
				}
				if (m_BDAT_ReadedCount + num > m_pServer.MaxMessageSize)
				{
					m_pSocket.BeginReadSpecifiedLength(new JunkingStream(), num, flag, EndBDatCmd);
				}
				else
				{
					m_pSocket.BeginReadSpecifiedLength(m_pMsgStream, num, flag, EndBDatCmd);
				}
				m_BDat = true;
			}
			else
			{
				m_pSocket.BeginWriteLine("500 Syntax error. Syntax:{BDAT chunk-size [LAST]}", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("500 Syntax error. Syntax:{BDAT chunk-size [LAST]}", EndSend);
		}
	}

	private void EndBDatCmd(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		try
		{
			switch (result)
			{
			case SocketCallBackResult.Ok:
				m_BDAT_ReadedCount += count;
				if ((bool)tag)
				{
					if (m_BDAT_ReadedCount > m_pServer.MaxMessageSize)
					{
						m_pServer.OnMessageStoringCompleted(this, "Requested mail action aborted: exceeded storage allocation", m_pMsgStream);
						m_pSocket.BeginWriteLine("552 Requested mail action aborted: exceeded storage allocation", EndSend);
					}
					else
					{
						MessageStoringCompleted_eArgs messageStoringCompleted_eArgs = m_pServer.OnMessageStoringCompleted(this, null, m_pMsgStream);
						if (messageStoringCompleted_eArgs.ServerReply.ErrorReply)
						{
							m_pSocket.BeginWriteLine(messageStoringCompleted_eArgs.ServerReply.ToSmtpReply("500", "Error storing message"), EndSend);
						}
						else
						{
							m_pSocket.BeginWriteLine(messageStoringCompleted_eArgs.ServerReply.ToSmtpReply("250", "Message(" + m_BDAT_ReadedCount + " bytes) stored ok."), EndSend);
						}
					}
					ResetState();
				}
				else if (m_BDAT_ReadedCount > m_pServer.MaxMessageSize)
				{
					m_pSocket.BeginWriteLine("552 Requested mail action aborted: exceeded storage allocation", EndSend);
				}
				else
				{
					m_pSocket.BeginWriteLine("250 Data block of " + count + " bytes recieved OK.", EndSend);
				}
				break;
			case SocketCallBackResult.SocketClosed:
				if (m_pMsgStream != null)
				{
					m_pServer.OnMessageStoringCompleted(this, "SocketClosed", m_pMsgStream);
					m_pMsgStream = null;
				}
				EndSession();
				break;
			case SocketCallBackResult.Exception:
				if (m_pMsgStream != null)
				{
					m_pServer.OnMessageStoringCompleted(this, "Exception: " + exception.Message, m_pMsgStream);
					m_pMsgStream = null;
				}
				OnError(exception);
				break;
			case SocketCallBackResult.LengthExceeded:
				break;
			}
		}
		catch (Exception x)
		{
			OnError(x);
		}
	}

	private void RSET(string argsText)
	{
		if (argsText.Length > 0)
		{
			m_pSocket.BeginWriteLine("500 Syntax error. Syntax:{RSET}", EndSend);
			return;
		}
		try
		{
			if (m_pMsgStream != null)
			{
				m_pServer.OnMessageStoringCompleted(this, "Message storing aborted by RSET", m_pMsgStream);
				m_pMsgStream = null;
			}
		}
		catch
		{
		}
		ResetState();
		m_pSocket.BeginWriteLine("250 OK", EndSend);
	}

	private void VRFY()
	{
		m_pSocket.BeginWriteLine("502 Command not implemented", EndSend);
	}

	private void NOOP()
	{
		m_pSocket.BeginWriteLine("250 OK", EndSend);
	}

	private void QUIT(string argsText)
	{
		if (argsText.Length > 0)
		{
			m_pSocket.BeginWriteLine("500 Syntax error. Syntax:<QUIT>", EndSend);
		}
		else
		{
			m_pSocket.WriteLine("221 Service closing transmission channel");
		}
	}

	private void EXPN()
	{
		m_pSocket.WriteLine("502 Command not implemented");
	}

	private void HELP()
	{
		m_pSocket.WriteLine("502 Command not implemented");
	}

	private void ResetState()
	{
		m_BodyType = BodyType.x7_bit;
		m_Forward_path.Clear();
		m_Reverse_path = "";
		m_CmdValidator.Reset();
		m_CmdValidator.Helo_ok = true;
		m_pMsgStream = null;
		m_BDat = false;
		m_BDAT_ReadedCount = 0L;
	}

	private void EndSend(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		try
		{
			switch (result)
			{
			case SocketCallBackResult.Ok:
				BeginRecieveCmd();
				break;
			case SocketCallBackResult.SocketClosed:
				EndSession();
				break;
			case SocketCallBackResult.Exception:
				OnError(exception);
				break;
			case SocketCallBackResult.LengthExceeded:
				break;
			}
		}
		catch (Exception x)
		{
			OnError(x);
		}
	}
}

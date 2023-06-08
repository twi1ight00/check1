using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LumiSoft.Net.AUTH;

namespace LumiSoft.Net.POP3.Server;

public class POP3_Session : ISocketServerSession
{
	private SocketEx m_pSocket = null;

	private BindInfo m_pBindInfo = null;

	private POP3_Server m_pServer = null;

	private string m_SessionID = "";

	private string m_UserName = "";

	private string m_Password = "";

	private bool m_Authenticated = false;

	private string m_MD5_prefix = "";

	private int m_BadCmdCount = 0;

	private POP3_Messages m_POP3_Messages = null;

	private DateTime m_SessionStartTime;

	private object m_Tag = null;

	public string SessionID => m_SessionID;

	public DateTime SessionStartTime => m_SessionStartTime;

	public int ExpectedTimeout => (int)((m_pServer.SessionIdleTimeOut - (DateTime.Now.Ticks - SessionLastDataTime.Ticks) / 10000) / 1000);

	public DateTime SessionLastDataTime => m_pSocket.LastActivity;

	public string UserName => m_UserName;

	public IPEndPoint LocalEndPoint => (IPEndPoint)m_pSocket.LocalEndPoint;

	public IPEndPoint RemoteEndPoint => (IPEndPoint)m_pSocket.RemoteEndPoint;

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

	public POP3_Session(Socket clientSocket, BindInfo bindInfo, POP3_Server server, SocketLogger logWriter)
	{
		m_pSocket = new SocketEx(clientSocket);
		m_pBindInfo = bindInfo;
		m_pServer = server;
		m_SessionID = Guid.NewGuid().ToString();
		m_POP3_Messages = new POP3_Messages();
		m_SessionStartTime = DateTime.Now;
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
			if (m_pServer.OnValidate_IpAddress(LocalEndPoint, RemoteEndPoint))
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
				m_MD5_prefix = "<" + Guid.NewGuid().ToString().ToLower() + ">";
				if (m_pServer.GreetingText == "")
				{
					m_pSocket.WriteLine("+OK " + m_pServer.HostName + " POP3 Server ready " + m_MD5_prefix);
				}
				else
				{
					m_pSocket.WriteLine("+OK " + m_pServer.GreetingText + " " + m_MD5_prefix);
				}
				BeginRecieveCmd();
			}
			else
			{
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
			if (m_pServer.LogCommands)
			{
				m_pSocket.Logger.Flush();
			}
			if (m_pSocket != null)
			{
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
			m_pSocket.WriteLine("-ERR Session timeout, closing transmission channel");
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
				m_pSocket.WriteLine("-ERR Line too long.");
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

	private bool SwitchCommand(string POP3_commandTxt)
	{
		string[] array = POP3_commandTxt.TrimStart().Split(' ');
		string text = array[0].ToUpper().Trim();
		string argsText = Core.GetArgsText(POP3_commandTxt, text);
		bool flag = true;
		switch (text)
		{
		case "USER":
			USER(argsText);
			flag = false;
			break;
		case "PASS":
			PASS(argsText);
			flag = false;
			break;
		case "STAT":
			STAT();
			flag = false;
			break;
		case "LIST":
			LIST(argsText);
			flag = false;
			break;
		case "RETR":
			RETR(argsText);
			flag = false;
			break;
		case "DELE":
			DELE(argsText);
			flag = false;
			break;
		case "NOOP":
			NOOP();
			flag = false;
			break;
		case "RSET":
			RSET();
			flag = false;
			break;
		case "QUIT":
			QUIT();
			flag = false;
			return true;
		case "UIDL":
			UIDL(argsText);
			flag = false;
			break;
		case "APOP":
			APOP(argsText);
			flag = false;
			break;
		case "TOP":
			TOP(argsText);
			flag = false;
			break;
		case "AUTH":
			AUTH(argsText);
			flag = false;
			break;
		case "CAPA":
			CAPA(argsText);
			flag = false;
			break;
		case "STLS":
			STLS(argsText);
			flag = false;
			break;
		default:
			m_pSocket.WriteLine("-ERR Invalid command");
			if (m_BadCmdCount > m_pServer.MaxBadCommands - 1)
			{
				m_pSocket.WriteLine("-ERR Too many bad commands, closing transmission channel");
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

	private void USER(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You are already authenticated", EndSend);
			return;
		}
		if (m_UserName.Length > 0)
		{
			m_pSocket.BeginWriteLine("-ERR username is already specified, please specify password", EndSend);
			return;
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Plain) == 0)
		{
			m_pSocket.BeginWriteLine("-ERR USER/PASS command disabled", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (argsText.Length > 0 && array.Length == 1)
		{
			string text = array[0];
			if (!m_pServer.IsUserLoggedIn(text))
			{
				m_UserName = text;
				m_pSocket.BeginWriteLine("+OK User:'" + text + "' ok", EndSend);
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR User:'" + text + "' already logged in", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{USER username}", EndSend);
		}
	}

	private void PASS(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You are already authenticated", EndSend);
			return;
		}
		if (m_UserName.Length == 0)
		{
			m_pSocket.BeginWriteLine("-ERR please specify username first", EndSend);
			return;
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Plain) == 0)
		{
			m_pSocket.BeginWriteLine("-ERR USER/PASS command disabled", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (array.Length == 1)
		{
			string text = array[0];
			AuthUser_EventArgs authUser_EventArgs = m_pServer.OnAuthUser(this, m_UserName, text, "", AuthType.Plain);
			if (authUser_EventArgs.ErrorText != null)
			{
				m_pSocket.BeginWriteLine("-ERR " + authUser_EventArgs.ErrorText, EndSend);
			}
			else if (authUser_EventArgs.Validated)
			{
				m_Password = text;
				m_Authenticated = true;
				m_pServer.OnGetMessagesInfo(this, m_POP3_Messages);
				m_pSocket.BeginWriteLine("+OK Password ok", EndSend);
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR UserName or Password is incorrect", EndSend);
				m_UserName = "";
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{PASS userName}", EndSend);
		}
	}

	private void STAT()
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
			return;
		}
		m_pSocket.BeginWriteLine("+OK " + m_POP3_Messages.Count.ToString() + " " + m_POP3_Messages.GetTotalMessagesSize(), EndSend);
	}

	private void LIST(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (argsText.Length == 0)
		{
			string text = "+OK " + m_POP3_Messages.Count + " messages\r\n";
			POP3_Message[] activeMessages = m_POP3_Messages.ActiveMessages;
			foreach (POP3_Message pOP3_Message in activeMessages)
			{
				object obj = text;
				text = string.Concat(obj, pOP3_Message.MessageNr.ToString(), " ", pOP3_Message.MessageSize, "\r\n");
			}
			text += ".\r\n";
			m_pSocket.BeginWriteLine(text, null, EndSend);
		}
		else if (array.Length == 1)
		{
			if (Core.IsNumber(array[0]))
			{
				int num = Convert.ToInt32(array[0]);
				if (m_POP3_Messages.MessageExists(num))
				{
					POP3_Message pOP3_Message = m_POP3_Messages[num];
					m_pSocket.BeginWriteLine("+OK " + num.ToString() + " " + pOP3_Message.MessageSize, EndSend);
				}
				else
				{
					m_pSocket.BeginWriteLine("-ERR no such message, or marked for deletion", EndSend);
				}
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR message-number is invalid", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{LIST [messageNr]}", EndSend);
		}
	}

	private void RETR(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
		}
		string[] array = argsText.Split(' ');
		if (argsText.Length > 0 && array.Length == 1)
		{
			if (Core.IsNumber(array[0]))
			{
				int num = Convert.ToInt32(array[0]);
				if (m_POP3_Messages.MessageExists(num))
				{
					POP3_Message messageInfo = m_POP3_Messages[num];
					POP3_eArgs_GetMessageStream pOP3_eArgs_GetMessageStream = m_pServer.OnGetMessageStream(this, messageInfo);
					if (pOP3_eArgs_GetMessageStream.MessageExists && pOP3_eArgs_GetMessageStream.MessageStream != null)
					{
						m_pSocket.WriteLine("+OK " + pOP3_eArgs_GetMessageStream.MessageSize + " octets");
						m_pSocket.BeginWritePeriodTerminated(pOP3_eArgs_GetMessageStream.MessageStream, pOP3_eArgs_GetMessageStream.CloseMessageStream, null, EndSend);
					}
					else
					{
						m_pSocket.BeginWriteLine("-ERR no such message", EndSend);
					}
				}
				else
				{
					m_pSocket.BeginWriteLine("-ERR no such message", EndSend);
				}
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR message-number is invalid", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{RETR messageNr}", EndSend);
		}
	}

	private void DELE(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (argsText.Length > 0 && array.Length == 1)
		{
			if (Core.IsNumber(array[0]))
			{
				int num = Convert.ToInt32(array[0]);
				if (m_POP3_Messages.MessageExists(num))
				{
					POP3_Message pOP3_Message = m_POP3_Messages[num];
					pOP3_Message.MarkedForDelete = true;
					m_pSocket.BeginWriteLine("+OK marked for delete", EndSend);
				}
				else
				{
					m_pSocket.BeginWriteLine("-ERR no such message", EndSend);
				}
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR message-number is invalid", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{DELE messageNr}", EndSend);
		}
	}

	private void NOOP()
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
		}
		else
		{
			m_pSocket.BeginWriteLine("+OK", EndSend);
		}
	}

	private void RSET()
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
			return;
		}
		Reset();
		m_pServer.OnSessionResetted(this);
		m_pSocket.BeginWriteLine("+OK", EndSend);
	}

	private void QUIT()
	{
		Update();
		m_pSocket.WriteLine("+OK POP3 server signing off");
	}

	private void TOP(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
		}
		string[] array = argsText.Split(' ');
		if (array.Length == 2)
		{
			if (Core.IsNumber(array[0]) && Core.IsNumber(array[1]))
			{
				int num = Convert.ToInt32(array[0]);
				if (m_POP3_Messages.MessageExists(num))
				{
					POP3_Message message = m_POP3_Messages[num];
					byte[] array2 = m_pServer.OnGetTopLines(this, message, Convert.ToInt32(array[1]));
					if (array2 != null)
					{
						m_pSocket.WriteLine("+OK " + array2.Length + " octets");
						m_pSocket.BeginWritePeriodTerminated(new MemoryStream(array2), null, EndSend);
					}
					else
					{
						m_pSocket.BeginWriteLine("-ERR no such message", EndSend);
					}
				}
				else
				{
					m_pSocket.BeginWriteLine("-ERR no such message", EndSend);
				}
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR message-number or number of lines is invalid", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{TOP messageNr nrLines}", EndSend);
		}
	}

	private void UIDL(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You must authenticate first", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (argsText.Length == 0)
		{
			string text = "+OK\r\n";
			POP3_Message[] activeMessages = m_POP3_Messages.ActiveMessages;
			foreach (POP3_Message pOP3_Message in activeMessages)
			{
				string text2 = text;
				text = text2 + pOP3_Message.MessageNr + " " + pOP3_Message.MessageUID + "\r\n";
			}
			text += ".\r\n";
			m_pSocket.BeginWriteLine(text, null, EndSend);
		}
		else if (array.Length == 1)
		{
			if (Core.IsNumber(array[0]))
			{
				int num = Convert.ToInt32(array[0]);
				if (m_POP3_Messages.MessageExists(num))
				{
					POP3_Message pOP3_Message = m_POP3_Messages[num];
					m_pSocket.BeginWriteLine("+OK " + num + " " + pOP3_Message.MessageUID, EndSend);
				}
				else
				{
					m_pSocket.BeginWriteLine("-ERR no such message", EndSend);
				}
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR message-number is invalid", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR Syntax error. Syntax:{UIDL [messageNr]}", EndSend);
		}
	}

	private void APOP(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR You are already authenticated", EndSend);
			return;
		}
		string[] array = argsText.Split(' ');
		if (array.Length == 2)
		{
			string text = array[0];
			string passwData = array[1];
			if (m_pServer.IsUserLoggedIn(text))
			{
				m_pSocket.BeginWriteLine("-ERR User:'" + text + "' already logged in", EndSend);
				return;
			}
			AuthUser_EventArgs authUser_EventArgs = m_pServer.OnAuthUser(this, text, passwData, m_MD5_prefix, AuthType.APOP);
			if (authUser_EventArgs.Validated)
			{
				m_UserName = text;
				m_Authenticated = true;
				m_pServer.OnGetMessagesInfo(this, m_POP3_Messages);
				m_pSocket.BeginWriteLine("+OK authentication was successful", EndSend);
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR authentication failed", EndSend);
			}
		}
		else
		{
			m_pSocket.BeginWriteLine("-ERR syntax error. Syntax:{APOP userName md5HexHash}", EndSend);
		}
	}

	private void AUTH(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.BeginWriteLine("-ERR already authenticated", EndSend);
			return;
		}
		string userName = "";
		string passwData = "";
		AuthUser_EventArgs authUser_EventArgs = null;
		string[] array = argsText.Split(' ');
		switch (array[0].ToUpper())
		{
		case "PLAIN":
			m_pSocket.BeginWriteLine("-ERR Unrecognized authentication type.", EndSend);
			break;
		case "LOGIN":
		{
			m_pSocket.WriteLine("+ VXNlcm5hbWU6");
			string text6 = m_pSocket.ReadLine();
			if (text6.Length > 0)
			{
				userName = Encoding.Default.GetString(Convert.FromBase64String(text6));
			}
			m_pSocket.WriteLine("+ UGFzc3dvcmQ6");
			string text7 = m_pSocket.ReadLine();
			if (text7.Length > 0)
			{
				passwData = Encoding.Default.GetString(Convert.FromBase64String(text7));
			}
			authUser_EventArgs = m_pServer.OnAuthUser(this, userName, passwData, "", AuthType.Plain);
			if (authUser_EventArgs.ErrorText != null)
			{
				m_pSocket.BeginWriteLine("-ERR " + authUser_EventArgs.ErrorText, EndSend);
			}
			else if (authUser_EventArgs.Validated)
			{
				m_pSocket.BeginWriteLine("+OK Authentication successful.", EndSend);
				m_UserName = userName;
				m_Authenticated = true;
				m_pServer.OnGetMessagesInfo(this, m_POP3_Messages);
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR Authentication failed", EndSend);
			}
			break;
		}
		case "CRAM-MD5":
		{
			string text5 = "<" + Guid.NewGuid().ToString().ToLower() + ">";
			m_pSocket.WriteLine("+ " + Convert.ToBase64String(Encoding.ASCII.GetBytes(text5)));
			string s = m_pSocket.ReadLine();
			s = Encoding.Default.GetString(Convert.FromBase64String(s));
			string[] array3 = s.Split(' ');
			userName = array3[0];
			authUser_EventArgs = m_pServer.OnAuthUser(this, userName, array3[1], text5, AuthType.CRAM_MD5);
			if (authUser_EventArgs.ErrorText != null)
			{
				m_pSocket.BeginWriteLine("-ERR " + authUser_EventArgs.ErrorText, EndSend);
			}
			else if (authUser_EventArgs.Validated)
			{
				m_pSocket.BeginWriteLine("+OK Authentication successful.", EndSend);
				m_UserName = userName;
				m_Authenticated = true;
				m_pServer.OnGetMessagesInfo(this, m_POP3_Messages);
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR Authentication failed", EndSend);
			}
			break;
		}
		case "DIGEST-MD5":
		{
			string hostName = m_pServer.HostName;
			string text = AuthHelper.GenerateNonce();
			m_pSocket.WriteLine("+ " + AuthHelper.Base64en(AuthHelper.Create_Digest_Md5_ServerResponse(hostName, text)));
			string text2 = AuthHelper.Base64de(m_pSocket.ReadLine());
			if (text2.IndexOf("realm=\"" + hostName + "\"") > -1 && text2.IndexOf("nonce=\"" + text + "\"") > -1)
			{
				string passwData2 = "";
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
						passwData2 = text4.Split(new char[1] { '=' }, 2)[1];
					}
					else if (text4.StartsWith("cnonce="))
					{
						text3 = text4.Split(new char[1] { '=' }, 2)[1].Replace("\"", "");
					}
				}
				authUser_EventArgs = m_pServer.OnAuthUser(this, userName, passwData2, text2, AuthType.DIGEST_MD5);
				if (authUser_EventArgs.ErrorText != null)
				{
					m_pSocket.BeginWriteLine("-ERR " + authUser_EventArgs.ErrorText, EndSend);
				}
				else if (authUser_EventArgs.Validated)
				{
					m_pSocket.WriteLine("+ " + AuthHelper.Base64en("rspauth=" + authUser_EventArgs.ReturnData));
					text2 = m_pSocket.ReadLine();
					if (text2 == "")
					{
						m_pSocket.BeginWriteLine("+OK Authentication successful.", EndSend);
					}
					else
					{
						m_pSocket.BeginWriteLine("-ERR Authentication failed", EndSend);
					}
				}
				else
				{
					m_pSocket.BeginWriteLine("-ERR Authentication failed", EndSend);
				}
			}
			else
			{
				m_pSocket.BeginWriteLine("-ERR Authentication failed", EndSend);
			}
			break;
		}
		default:
			m_pSocket.BeginWriteLine("-ERR Unrecognized authentication type.", EndSend);
			break;
		}
	}

	private void CAPA(string argsText)
	{
		string text = "";
		text += "+OK Capability list follows\r\n";
		text += "PIPELINING\r\n";
		text += "UIDL\r\n";
		text += "TOP\r\n";
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Plain) != 0)
		{
			text += "USER\r\n";
		}
		text += "SASL";
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Cram_md5) != 0)
		{
			text += " CRAM-MD5";
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Digest_md5) != 0)
		{
			text += " DIGEST-MD5";
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Login) != 0)
		{
			text += " LOGIN";
		}
		text += "\r\n";
		if (!m_pSocket.SSL && m_pBindInfo.SSL_Certificate != null)
		{
			text += "STLS\r\n";
		}
		text += ".\r\n";
		m_pSocket.BeginWriteLine(text, EndSend);
	}

	private void STLS(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine("-ERR STLS command is only permitted in AUTHORIZATION state !");
			return;
		}
		if (m_pBindInfo.SSL_Certificate == null)
		{
			m_pSocket.WriteLine("-ERR TLS not available, SSL certificate isn't specified !");
			return;
		}
		m_pSocket.WriteLine("+OK Ready to start TLS");
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
			m_pSocket.WriteLine("-ERR TLS handshake failed ! " + ex.Message);
		}
		Reset();
		BeginRecieveCmd();
	}

	private void Reset()
	{
		m_POP3_Messages.ResetDeleteFlags();
	}

	private void Update()
	{
		if (!m_Authenticated)
		{
			return;
		}
		foreach (POP3_Message message in m_POP3_Messages.Messages)
		{
			if (message.MarkedForDelete)
			{
				m_pServer.OnDeleteMessage(this, message);
			}
		}
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

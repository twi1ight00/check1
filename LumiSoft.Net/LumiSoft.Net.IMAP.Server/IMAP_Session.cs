using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LumiSoft.Net.AUTH;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Session : ISocketServerSession
{
	private SocketEx m_pSocket = null;

	private BindInfo m_pBindInfo = null;

	private IMAP_Server m_pServer = null;

	private string m_SessionID = "";

	private string m_UserName = "";

	private string m_SelectedMailbox = "";

	private IMAP_Messages m_Messages = null;

	private bool m_Authenticated = false;

	private int m_BadCmdCount = 0;

	private DateTime m_SessionStartTime;

	private object m_Tag = null;

	public string SessionID => m_SessionID;

	public bool Authenticated => m_Authenticated;

	public string UserName => m_UserName;

	public string SelectedMailbox => m_SelectedMailbox;

	public IPEndPoint RemoteEndPoint => (IPEndPoint)m_pSocket.RemoteEndPoint;

	public IPEndPoint LocalEndPoint => (IPEndPoint)m_pSocket.LocalEndPoint;

	public DateTime SessionStartTime => m_SessionStartTime;

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

	internal IMAP_Session(Socket clientSocket, BindInfo bindInfo, IMAP_Server server, SocketLogger logWriter)
	{
		m_pSocket = new SocketEx(clientSocket);
		m_pBindInfo = bindInfo;
		m_pServer = server;
		m_SessionID = Guid.NewGuid().ToString();
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
				if (m_pServer.GreetingText == "")
				{
					m_pSocket.WriteLine("* OK " + m_pServer.HostName + " IMAP Server ready");
				}
				else
				{
					m_pSocket.WriteLine("* OK " + m_pServer.GreetingText);
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
			m_pSocket.WriteLine("* BYE Session timeout, closing transmission channel");
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
				m_pSocket.WriteLine("* BAD Line too long.");
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

	private bool SwitchCommand(string IMAP_commandTxt)
	{
		string[] array = IMAP_commandTxt.TrimStart().Split(' ');
		if (array.Length < 2)
		{
			array = new string[2] { "", "" };
		}
		string text = array[0].Trim().Trim();
		string text2 = array[1].ToUpper().Trim();
		string argsText = Core.GetArgsText(IMAP_commandTxt, array[0] + " " + array[1]);
		bool flag = true;
		switch (text2)
		{
		case "STARTTLS":
			STARTTLS(text, argsText);
			break;
		case "AUTHENTICATE":
			Authenticate(text, argsText);
			break;
		case "LOGIN":
			LogIn(text, argsText);
			break;
		case "SELECT":
			Select(text, argsText);
			break;
		case "EXAMINE":
			Examine(text, argsText);
			break;
		case "CREATE":
			Create(text, argsText);
			break;
		case "DELETE":
			Delete(text, argsText);
			break;
		case "RENAME":
			Rename(text, argsText);
			break;
		case "SUBSCRIBE":
			Suscribe(text, argsText);
			break;
		case "UNSUBSCRIBE":
			UnSuscribe(text, argsText);
			break;
		case "LIST":
			List(text, argsText);
			break;
		case "LSUB":
			LSub(text, argsText);
			break;
		case "STATUS":
			Status(text, argsText);
			break;
		case "APPEND":
			flag = BeginAppendCmd(text, argsText);
			break;
		case "NAMESPACE":
			Namespace(text, argsText);
			break;
		case "GETACL":
			GETACL(text, argsText);
			break;
		case "SETACL":
			SETACL(text, argsText);
			break;
		case "DELETEACL":
			DELETEACL(text, argsText);
			break;
		case "LISTRIGHTS":
			LISTRIGHTS(text, argsText);
			break;
		case "MYRIGHTS":
			MYRIGHTS(text, argsText);
			break;
		case "CHECK":
			Check(text);
			break;
		case "CLOSE":
			Close(text);
			break;
		case "EXPUNGE":
			Expunge(text);
			break;
		case "SEARCH":
			Search(text, argsText, uidSearch: false);
			break;
		case "FETCH":
			Fetch(text, argsText, uidFetch: false);
			break;
		case "STORE":
			Store(text, argsText, uidStore: false);
			break;
		case "COPY":
			Copy(text, argsText, uidCopy: false);
			break;
		case "UID":
			Uid(text, argsText);
			break;
		case "CAPABILITY":
			Capability(text);
			break;
		case "NOOP":
			Noop(text);
			break;
		case "LOGOUT":
			LogOut(text);
			return true;
		default:
			m_pSocket.WriteLine(text + " BAD command unrecognized");
			if (m_BadCmdCount > m_pServer.MaxBadCommands - 1)
			{
				m_pSocket.WriteLine("* BAD Too many bad commands, closing transmission channel");
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

	private void STARTTLS(string cmdTag, string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO The STARTTLS command is only valid in non-authenticated state !");
			return;
		}
		if (m_pSocket.SSL)
		{
			m_pSocket.WriteLine(cmdTag + " NO The STARTTLS already started !");
			return;
		}
		if (m_pBindInfo.SSL_Certificate == null)
		{
			m_pSocket.WriteLine(cmdTag + " NO TLS not available, SSL certificate isn't specified !");
			return;
		}
		m_pSocket.WriteLine(cmdTag + " OK Ready to start TLS");
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
			m_pSocket.WriteLine(cmdTag + " NO TLS handshake failed ! " + ex.Message);
		}
	}

	private void Authenticate(string cmdTag, string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO AUTH you are already logged in");
			return;
		}
		string userName = "";
		AuthUser_EventArgs authUser_EventArgs = null;
		switch (argsText.ToUpper())
		{
		case "CRAM-MD5":
		{
			string text5 = "<" + Guid.NewGuid().ToString().ToLower() + ">";
			m_pSocket.WriteLine("+ " + Convert.ToBase64String(Encoding.ASCII.GetBytes(text5)));
			string s = m_pSocket.ReadLine();
			s = Encoding.Default.GetString(Convert.FromBase64String(s));
			string[] array2 = s.Split(' ');
			userName = array2[0];
			authUser_EventArgs = m_pServer.OnAuthUser(this, userName, array2[1], text5, AuthType.CRAM_MD5);
			if (authUser_EventArgs.ErrorText != null)
			{
				m_pSocket.WriteLine(cmdTag + " NO " + authUser_EventArgs.ErrorText);
			}
			else if (authUser_EventArgs.Validated)
			{
				m_pSocket.WriteLine(cmdTag + " OK Authentication successful.");
				m_Authenticated = true;
				m_UserName = userName;
			}
			else
			{
				m_pSocket.WriteLine(cmdTag + " NO Authentication failed");
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
				string passwordData = "";
				string text3 = "";
				string[] array = text2.Split(',');
				foreach (string text4 in array)
				{
					if (text4.StartsWith("username="))
					{
						userName = text4.Split(new char[1] { '=' }, 2)[1].Replace("\"", "");
					}
					else if (text4.StartsWith("response="))
					{
						passwordData = text4.Split(new char[1] { '=' }, 2)[1];
					}
					else if (text4.StartsWith("cnonce="))
					{
						text3 = text4.Split(new char[1] { '=' }, 2)[1].Replace("\"", "");
					}
				}
				authUser_EventArgs = m_pServer.OnAuthUser(this, userName, passwordData, text2, AuthType.DIGEST_MD5);
				if (authUser_EventArgs.ErrorText != null)
				{
					m_pSocket.WriteLine(cmdTag + " NO " + authUser_EventArgs.ErrorText);
				}
				else if (authUser_EventArgs.Validated)
				{
					m_pSocket.WriteLine("+ " + AuthHelper.Base64en("rspauth=" + authUser_EventArgs.ReturnData));
					text2 = m_pSocket.ReadLine();
					if (text2 == "")
					{
						m_pSocket.WriteLine(cmdTag + " OK Authentication successful.");
					}
					else
					{
						m_pSocket.WriteLine(cmdTag + " NO Authentication failed");
					}
				}
				else
				{
					m_pSocket.WriteLine(cmdTag + " NO Authentication failed");
				}
			}
			else
			{
				m_pSocket.WriteLine(cmdTag + " NO Authentication failed");
			}
			break;
		}
		default:
			m_pSocket.WriteLine(cmdTag + " NO unsupported authentication mechanism");
			break;
		}
	}

	private void LogIn(string cmdTag, string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Reauthentication error, you are already logged in");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD Invalid arguments, syntax: {<command-tag> LOGIN \"<user-name>\" \"<password>\"}");
			return;
		}
		string userName = array[0];
		string passwordData = array[1];
		AuthUser_EventArgs authUser_EventArgs = m_pServer.OnAuthUser(this, userName, passwordData, "", AuthType.Plain);
		if (authUser_EventArgs.ErrorText != null)
		{
			m_pSocket.WriteLine(cmdTag + " NO " + authUser_EventArgs.ErrorText);
		}
		else if (authUser_EventArgs.Validated)
		{
			m_pSocket.WriteLine(cmdTag + " OK LOGIN completed");
			m_UserName = userName;
			m_Authenticated = true;
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO LOGIN failed");
		}
	}

	private void Select(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD SELECT invalid arguments. Syntax: {<command-tag> SELECT \"mailboxName\"}");
			return;
		}
		long ticks = DateTime.Now.Ticks;
		IMAP_Messages iMAP_Messages = m_pServer.OnGetMessagesInfo(this, Core.Decode_IMAP_UTF7_String(array[0]));
		if (iMAP_Messages.ErrorText == null)
		{
			m_Messages = iMAP_Messages;
			m_SelectedMailbox = Core.Decode_IMAP_UTF7_String(array[0]);
			string text = "";
			text += "* FLAGS (\\Answered \\Flagged \\Deleted \\Seen \\Draft)\r\n";
			object obj = text;
			text = string.Concat(obj, "* ", m_Messages.Count, " EXISTS\r\n");
			obj = text;
			text = string.Concat(obj, "* ", m_Messages.RecentCount, " RECENT\r\n");
			obj = text;
			text = string.Concat(obj, "* OK [UNSEEN ", m_Messages.FirstUnseen, "] Message ", m_Messages.FirstUnseen, " is first unseen\r\n");
			obj = text;
			text = string.Concat(obj, "* OK [UIDVALIDITY ", m_Messages.MailboxUID, "] UIDs valid\r\n");
			obj = text;
			text = string.Concat(obj, "* OK [UIDNEXT ", m_Messages.UID_Next, "] Predicted next UID\r\n");
			text += "* OK [PERMANENTFLAGS (\\Answered \\Flagged \\Deleted \\Seen \\Draft)] Available permanent flags\r\n";
			string text2 = text;
			text = text2 + cmdTag + " OK [" + (m_Messages.ReadOnly ? "READ-ONLY" : "READ-WRITE") + "] SELECT Completed in " + ((decimal)(DateTime.Now.Ticks - ticks) / 10000000m).ToString("f2") + " seconds\r\n";
			m_pSocket.Write(text);
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + iMAP_Messages.ErrorText);
		}
	}

	private void Examine(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD EXAMINE invalid arguments. Syntax: {<command-tag> EXAMINE \"mailboxName\"}");
			return;
		}
		IMAP_Messages iMAP_Messages = m_pServer.OnGetMessagesInfo(this, Core.Decode_IMAP_UTF7_String(array[0]));
		if (iMAP_Messages.ErrorText == null)
		{
			iMAP_Messages.ReadOnly = true;
			m_Messages = iMAP_Messages;
			m_SelectedMailbox = argsText;
			string text = "";
			text += "* FLAGS (\\Answered \\Flagged \\Deleted \\Seen \\Draft)\r\n";
			object obj = text;
			text = string.Concat(obj, "* ", m_Messages.Count, " EXISTS\r\n");
			obj = text;
			text = string.Concat(obj, "* ", m_Messages.RecentCount, " RECENT\r\n");
			obj = text;
			text = string.Concat(obj, "* OK [UNSEEN ", m_Messages.FirstUnseen, "] Message ", m_Messages.FirstUnseen, " is first unseen\r\n");
			obj = text;
			text = string.Concat(obj, "* OK [UIDVALIDITY ", m_Messages.MailboxUID, "] UIDs valid\r\n");
			obj = text;
			text = string.Concat(obj, "* OK [UIDNEXT ", m_Messages.UID_Next, "] Predicted next UID\r\n");
			text += "* OK [PERMANENTFLAGS (\\Answered \\Flagged \\Deleted \\Seen \\Draft)] Available permanent falgs\r\n";
			text = text + cmdTag + " OK [READ-ONLY] EXAMINE Completed\r\n";
			m_pSocket.Write(text);
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + iMAP_Messages.ErrorText);
		}
	}

	private void Create(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD CREATE invalid arguments. Syntax: {<command-tag> CREATE \"mailboxName\"}");
			return;
		}
		string text = m_pServer.OnCreateMailbox(this, Core.Decode_IMAP_UTF7_String(array[0]));
		if (text == null)
		{
			m_pSocket.WriteLine(cmdTag + " OK CREATE completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + text);
		}
	}

	private void Delete(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD DELETE invalid arguments. Syntax: {<command-tag> DELETE \"mailboxName\"}");
			return;
		}
		string text = m_pServer.OnDeleteMailbox(this, Core.Decode_IMAP_UTF7_String(array[0]));
		if (text == null)
		{
			m_pSocket.WriteLine(cmdTag + " OK DELETE Completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + text);
		}
	}

	private void Rename(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD RENAME invalid arguments. Syntax: {<command-tag> RENAME \"mailboxName\" \"newMailboxName\"}");
			return;
		}
		string mailbox = Core.Decode_IMAP_UTF7_String(array[0]);
		string newMailboxName = Core.Decode_IMAP_UTF7_String(array[1]);
		string text = m_pServer.OnRenameMailbox(this, mailbox, newMailboxName);
		if (text == null)
		{
			m_pSocket.WriteLine(cmdTag + " OK RENAME Completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + text);
		}
	}

	private void Suscribe(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD SUBSCRIBE invalid arguments. Syntax: {<command-tag> SUBSCRIBE \"mailboxName\"}");
			return;
		}
		string text = m_pServer.OnSubscribeMailbox(this, Core.Decode_IMAP_UTF7_String(array[0]));
		if (text == null)
		{
			m_pSocket.WriteLine(cmdTag + " OK SUBSCRIBE completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + text);
		}
	}

	private void UnSuscribe(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD UNSUBSCRIBE invalid arguments. Syntax: {<command-tag> UNSUBSCRIBE \"mailboxName\"}");
			return;
		}
		string text = m_pServer.OnUnSubscribeMailbox(this, Core.Decode_IMAP_UTF7_String(array[0]));
		if (text == null)
		{
			m_pSocket.WriteLine(cmdTag + " OK UNSUBSCRIBE completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + text);
		}
	}

	private void List(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD Invalid LIST arguments. Syntax: {<command-tag> LIST \"<reference-name>\" \"<mailbox-name>\"}");
			return;
		}
		long ticks = DateTime.Now.Ticks;
		string referenceName = Core.Decode_IMAP_UTF7_String(array[0]);
		string text = Core.Decode_IMAP_UTF7_String(array[1]);
		string text2 = "";
		if (text.Length == 0)
		{
			text2 += "* LIST (\\Noselect) \"/\" \"\"\r\n";
		}
		else
		{
			IMAP_Folders iMAP_Folders = m_pServer.OnGetMailboxes(this, referenceName, text);
			IMAP_Folder[] folders = iMAP_Folders.Folders;
			foreach (IMAP_Folder iMAP_Folder in folders)
			{
				text2 = ((!iMAP_Folder.Selectable) ? (text2 + "* LIST (\\Noselect) \"/\" \"" + Core.Encode_IMAP_UTF7_String(iMAP_Folder.Folder) + "\" \r\n") : (text2 + "* LIST () \"/\" \"" + Core.Encode_IMAP_UTF7_String(iMAP_Folder.Folder) + "\" \r\n"));
			}
		}
		string text3 = text2;
		text2 = text3 + cmdTag + " OK LIST Completed in " + ((decimal)(DateTime.Now.Ticks - ticks) / 10000000m).ToString("f2") + " seconds\r\n";
		m_pSocket.Write(text2);
	}

	private void LSub(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD LSUB invalid arguments");
			return;
		}
		string referenceName = Core.Decode_IMAP_UTF7_String(array[0]);
		string mailBox = Core.Decode_IMAP_UTF7_String(array[1]);
		string text = "";
		IMAP_Folders iMAP_Folders = m_pServer.OnGetSubscribedMailboxes(this, referenceName, mailBox);
		IMAP_Folder[] folders = iMAP_Folders.Folders;
		foreach (IMAP_Folder iMAP_Folder in folders)
		{
			text = text + "* LSUB () \"/\" \"" + Core.Encode_IMAP_UTF7_String(iMAP_Folder.Folder) + "\" \r\n";
		}
		text = text + cmdTag + " OK LSUB Completed\r\n";
		m_pSocket.Write(text);
	}

	private void Status(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD Invalid STATUS arguments. Syntax: {<command-tag> STATUS \"<mailbox-name>\" \"(status-data-items)\"}");
			return;
		}
		string mailbox = Core.Decode_IMAP_UTF7_String(array[0]);
		string text = array[1].ToUpper();
		if (text.Replace("MESSAGES", "").Replace("RECENT", "").Replace("UIDNEXT", "")
			.Replace("UIDVALIDITY", "")
			.Replace("UNSEEN", "")
			.Trim()
			.Length > 0)
		{
			m_pSocket.WriteLine(cmdTag + " BAD STATUS invalid arguments");
			return;
		}
		IMAP_Messages iMAP_Messages = m_pServer.OnGetMessagesInfo(this, mailbox);
		if (iMAP_Messages.ErrorText == null)
		{
			string text2 = "";
			if (text.IndexOf("MESSAGES") > -1)
			{
				text2 = text2 + " MESSAGES " + iMAP_Messages.Count;
			}
			if (text.IndexOf("RECENT") > -1)
			{
				text2 = text2 + " RECENT " + iMAP_Messages.RecentCount;
			}
			if (text.IndexOf("UNSEEN") > -1)
			{
				text2 = text2 + " UNSEEN " + iMAP_Messages.UnSeenCount;
			}
			if (text.IndexOf("UIDVALIDITY") > -1)
			{
				text2 = text2 + " UIDVALIDITY " + iMAP_Messages.MailboxUID;
			}
			if (text.IndexOf("UIDNEXT") > -1)
			{
				text2 = text2 + " UIDNEXT " + iMAP_Messages.UID_Next;
			}
			text2 = text2.Trim();
			m_pSocket.WriteLine("* STATUS " + iMAP_Messages.Mailbox + " (" + text2 + ")");
			m_pSocket.WriteLine(cmdTag + " OK STATUS completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + iMAP_Messages.ErrorText);
		}
	}

	private bool BeginAppendCmd(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return true;
		}
		string[] array = ParseParams(argsText);
		if (array.Length < 2 || array.Length > 4)
		{
			m_pSocket.WriteLine(cmdTag + " BAD APPEND Invalid arguments");
			return true;
		}
		string value = Core.Decode_IMAP_UTF7_String(array[0]);
		IMAP_MessageFlags iMAP_MessageFlags = (IMAP_MessageFlags)0;
		DateTime dateTime = DateTime.Now;
		long num = Convert.ToInt64(array[array.Length - 1].Replace("{", "").Replace("}", ""));
		if (array.Length == 4)
		{
			string text = array[1].ToUpper();
			if (text.Replace("\\ANSWERED", "").Replace("\\FLAGGED", "").Replace("\\DELETED", "")
				.Replace("\\SEEN", "")
				.Replace("\\DRAFT", "")
				.Trim()
				.Length > 0)
			{
				m_pSocket.WriteLine(cmdTag + " BAD arguments invalid");
				return false;
			}
			iMAP_MessageFlags = IMAP_Utils.ParseMessageFlags(text);
			dateTime = MimeUtils.ParseDate(array[2]);
		}
		else if (array.Length == 3)
		{
			try
			{
				dateTime = MimeUtils.ParseDate(array[1]);
			}
			catch
			{
				string text = array[1].ToUpper();
				if (text.Replace("\\ANSWERED", "").Replace("\\FLAGGED", "").Replace("\\DELETED", "")
					.Replace("\\SEEN", "")
					.Replace("\\DRAFT", "")
					.Trim()
					.Length > 0)
				{
					m_pSocket.WriteLine(cmdTag + " BAD arguments invalid");
					return false;
				}
				iMAP_MessageFlags = IMAP_Utils.ParseMessageFlags(text);
			}
		}
		m_pSocket.WriteLine("+ Ready for literal data");
		MemoryStream memoryStream = new MemoryStream();
		Hashtable hashtable = new Hashtable();
		hashtable.Add("cmdTag", cmdTag);
		hashtable.Add("mailbox", value);
		hashtable.Add("mFlags", iMAP_MessageFlags);
		hashtable.Add("date", dateTime);
		hashtable.Add("strm", memoryStream);
		m_pSocket.BeginReadSpecifiedLength(memoryStream, (int)num + 2, hashtable, EndAppendCmd);
		return false;
	}

	private void EndAppendCmd(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		try
		{
			switch (result)
			{
			case SocketCallBackResult.Ok:
			{
				Hashtable hashtable = (Hashtable)tag;
				string text = (string)hashtable["cmdTag"];
				string folder = (string)hashtable["mailbox"];
				IMAP_MessageFlags flags = (IMAP_MessageFlags)hashtable["mFlags"];
				DateTime internalDate = (DateTime)hashtable["date"];
				MemoryStream memoryStream = (MemoryStream)hashtable["strm"];
				IMAP_Message msg = new IMAP_Message(null, "", 0, flags, 0L, internalDate);
				string text2 = m_pServer.OnStoreMessage(this, folder, msg, memoryStream.ToArray());
				if (text2 == null)
				{
					m_pSocket.WriteLine(text + " OK APPEND completed, recieved " + memoryStream.Length + " bytes");
				}
				else
				{
					m_pSocket.WriteLine(text + " NO " + text2);
				}
				break;
			}
			case SocketCallBackResult.SocketClosed:
				EndSession();
				return;
			case SocketCallBackResult.Exception:
				OnError(exception);
				return;
			}
			BeginRecieveCmd();
		}
		catch (Exception x)
		{
			OnError(x);
		}
	}

	private void Namespace(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		SharedRootFolders_EventArgs sharedRootFolders_EventArgs = m_pServer.OnGetSharedRootFolders(this);
		string text = "NIL";
		if (sharedRootFolders_EventArgs.PublicRootFolders != null && sharedRootFolders_EventArgs.PublicRootFolders.Length > 0)
		{
			text = "(";
			string[] publicRootFolders = sharedRootFolders_EventArgs.PublicRootFolders;
			foreach (string text2 in publicRootFolders)
			{
				text = text + "(\"" + text2 + "/\" \"/\")";
			}
			text += ")";
		}
		string text3 = "NIL";
		if (sharedRootFolders_EventArgs.SharedRootFolders != null && sharedRootFolders_EventArgs.SharedRootFolders.Length > 0)
		{
			text3 = "(";
			string[] publicRootFolders = sharedRootFolders_EventArgs.SharedRootFolders;
			foreach (string text4 in publicRootFolders)
			{
				text3 = text3 + "(\"" + text4 + "/\" \"/\")";
			}
			text3 += ")";
		}
		string text5 = "* NAMESPACE ((\"\" \"/\")) " + text3 + " " + text + "\r\n";
		text5 = text5 + cmdTag + " OK CHECK completed";
		m_pSocket.WriteLine(text5);
	}

	private void GETACL(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD GETACL invalid arguments. Syntax: GETACL<SP>FolderName<CRLF>");
			return;
		}
		IMAP_GETACL_eArgs iMAP_GETACL_eArgs = m_pServer.OnGetFolderACL(this, Core.Decode_IMAP_UTF7_String(IMAP_Utils.NormalizeFolder(array[0])));
		if (iMAP_GETACL_eArgs.ErrorText.Length > 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO GETACL " + iMAP_GETACL_eArgs.ErrorText);
			return;
		}
		string text = "";
		if (iMAP_GETACL_eArgs.ACL.Count > 0)
		{
			text = text + "* ACL \"" + array[0] + "\"";
			foreach (DictionaryEntry item in iMAP_GETACL_eArgs.ACL)
			{
				string text2 = IMAP_Utils.ACL_to_String((IMAP_ACL_Flags)item.Value);
				if (text2.Length == 0)
				{
					text2 = "\"\"";
				}
				object obj = text;
				text = string.Concat(obj, " \"", item.Key, "\" ", text2);
			}
			text += "\r\n";
		}
		text = text + cmdTag + " OK Getacl complete\r\n";
		m_pSocket.Write(text);
	}

	private void SETACL(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 3)
		{
			m_pSocket.WriteLine(cmdTag + " BAD GETACL invalid arguments. Syntax: SETACL<SP>FolderName<SP>UserName<SP>ACL_Flags<CRLF>");
			return;
		}
		string text = array[2];
		IMAP_Flags_SetType flagsSetType = IMAP_Flags_SetType.Replace;
		if (text.StartsWith("+"))
		{
			flagsSetType = IMAP_Flags_SetType.Add;
		}
		else if (text.StartsWith("-"))
		{
			flagsSetType = IMAP_Flags_SetType.Remove;
		}
		IMAP_SETACL_eArgs iMAP_SETACL_eArgs = m_pServer.OnSetFolderACL(this, IMAP_Utils.NormalizeFolder(array[0]), array[1], flagsSetType, IMAP_Utils.ACL_From_String(text));
		if (iMAP_SETACL_eArgs.ErrorText.Length > 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO SETACL " + iMAP_SETACL_eArgs.ErrorText);
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " OK SETACL completed");
		}
	}

	private void DELETEACL(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD GETACL invalid arguments. Syntax: DELETEACL<SP>FolderName<SP>UserName<CRLF>");
			return;
		}
		IMAP_DELETEACL_eArgs iMAP_DELETEACL_eArgs = m_pServer.OnDeleteFolderACL(this, IMAP_Utils.NormalizeFolder(array[0]), array[1]);
		if (iMAP_DELETEACL_eArgs.ErrorText.Length > 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO DELETEACL " + iMAP_DELETEACL_eArgs.ErrorText);
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " OK DELETEACL completed");
		}
	}

	private void LISTRIGHTS(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD GETACL invalid arguments. Syntax: LISTRIGHTS<SP>FolderName<SP>UserName<CRLF>");
			return;
		}
		string text = "* LISTRIGHTS \"" + array[0] + "\" \"" + array[1] + "\" l r s w i p c d a\r\n";
		text = text + cmdTag + " OK MYRIGHTS Completed\r\n";
		m_pSocket.Write(text);
	}

	private void MYRIGHTS(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 1)
		{
			m_pSocket.WriteLine(cmdTag + " BAD GETACL invalid arguments. Syntax: MYRIGHTS<SP>FolderName<CRLF>");
			return;
		}
		IMAP_GetUserACL_eArgs iMAP_GetUserACL_eArgs = m_pServer.OnGetUserACL(this, IMAP_Utils.NormalizeFolder(array[0]), UserName);
		if (iMAP_GetUserACL_eArgs.ErrorText.Length > 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO MYRIGHTS " + iMAP_GetUserACL_eArgs.ErrorText);
			return;
		}
		string text = IMAP_Utils.ACL_to_String(iMAP_GetUserACL_eArgs.ACL);
		if (text.Length == 0)
		{
			text = "\"\"";
		}
		string text2 = "* MYRIGHTS \"" + array[0] + "\" " + text + "\r\n";
		text2 = text2 + cmdTag + " OK MYRIGHTS Completed\r\n";
		m_pSocket.Write(text2);
	}

	private void Check(string cmdTag)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
		}
		else if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " OK CHECK completed");
		}
	}

	private void Close(string cmdTag)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		if (!m_Messages.ReadOnly)
		{
			IMAP_Message[] deleteMessages = m_Messages.GetDeleteMessages();
			IMAP_Message[] array = deleteMessages;
			foreach (IMAP_Message message in array)
			{
				m_pServer.OnDeleteMessage(this, message);
			}
		}
		m_SelectedMailbox = "";
		m_Messages = null;
		m_pSocket.WriteLine(cmdTag + " OK CLOSE completed");
	}

	private void Expunge(string cmdTag)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		IMAP_Message[] deleteMessages = m_Messages.GetDeleteMessages();
		foreach (IMAP_Message iMAP_Message in deleteMessages)
		{
			string text = m_pServer.OnDeleteMessage(this, iMAP_Message);
			if (text == null)
			{
				m_pSocket.WriteLine("* " + iMAP_Message.MessageNo + " EXPUNGE");
				m_Messages.RemoveMessage(iMAP_Message);
				continue;
			}
			m_pSocket.WriteLine(cmdTag + " NO " + text);
			return;
		}
		m_Messages = m_pServer.OnGetMessagesInfo(this, SelectedMailbox);
		m_pSocket.WriteLine(cmdTag + " OK EXPUNGE completed");
	}

	private void Search(string cmdTag, string argsText, bool uidSearch)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		long ticks = DateTime.Now.Ticks;
		string name = "ASCII";
		if (argsText.ToUpper().StartsWith("CHARSET"))
		{
			argsText = argsText.Substring(7).Trim();
			string text = IMAP_Utils.ParseQuotedParam(ref argsText);
			try
			{
				Encoding.GetEncoding(text);
				name = text;
			}
			catch
			{
				m_pSocket.WriteLine(cmdTag + " NO [BADCHARSET UTF-8] " + text + " is not supported");
				return;
			}
		}
		argsText = argsText.Trim();
		while (argsText.EndsWith("}") && argsText.IndexOf("{") > -1)
		{
			long num = 0L;
			try
			{
				num = Convert.ToInt64(argsText.Substring(argsText.LastIndexOf("{") + 1, argsText.Length - argsText.LastIndexOf("{") - 2));
			}
			catch
			{
				break;
			}
			MemoryStream memoryStream = new MemoryStream();
			m_pSocket.WriteLine("+ Continue");
			m_pSocket.ReadSpecifiedLength((int)num, memoryStream);
			string text2 = m_pSocket.ReadLine().TrimEnd();
			argsText = argsText + Encoding.GetEncoding(name).GetString(memoryStream.ToArray()) + text2;
			if (text2 == "")
			{
				break;
			}
		}
		SearchGroup searchGroup = new SearchGroup();
		try
		{
			searchGroup.Parse(new StringReader(argsText));
		}
		catch (Exception ex)
		{
			m_pSocket.WriteLine(cmdTag + " NO " + ex.Message);
			return;
		}
		m_pSocket.Write("* SEARCH");
		string text3 = "";
		IMAP_MessageItems_enum iMAP_MessageItems_enum = IMAP_MessageItems_enum.None;
		if (searchGroup.IsBodyTextNeeded())
		{
			iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Message;
		}
		else if (searchGroup.IsHeaderNeeded())
		{
			iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Header;
		}
		for (int i = 0; i < m_Messages.Count; i++)
		{
			IMAP_Message iMAP_Message = m_Messages[i];
			LumiSoft.Net.Mime.Mime mime = null;
			if ((iMAP_MessageItems_enum & IMAP_MessageItems_enum.Message) != 0 || (iMAP_MessageItems_enum & IMAP_MessageItems_enum.Header) != 0)
			{
				IMAP_eArgs_MessageItems iMAP_eArgs_MessageItems = m_pServer.OnGetMessageItems(this, iMAP_Message, iMAP_MessageItems_enum);
				if (!iMAP_eArgs_MessageItems.MessageExists)
				{
					continue;
				}
				try
				{
					iMAP_eArgs_MessageItems.Validate();
				}
				catch (Exception ex)
				{
					m_pServer.OnSysError(ex.Message, ex);
					m_pSocket.WriteLine(cmdTag + " NO Internal IMAP server component error: " + ex.Message);
					return;
				}
				try
				{
					mime = ((iMAP_eArgs_MessageItems.MessageStream == null) ? LumiSoft.Net.Mime.Mime.Parse(iMAP_eArgs_MessageItems.Header) : LumiSoft.Net.Mime.Mime.Parse(iMAP_eArgs_MessageItems.MessageStream));
				}
				catch (Exception ex)
				{
					mime = LumiSoft.Net.Mime.Mime.CreateSimple(new AddressList(), new AddressList(), "[BAD MESSAGE] Bad message, message parsing failed !", "NOTE: Bad message, message parsing failed !\r\n\r\n" + ex.Message, "");
				}
			}
			string bodyText = "";
			if (searchGroup.IsBodyTextNeeded())
			{
				bodyText = mime.BodyText;
			}
			if (searchGroup.Match(i, iMAP_Message.MessageUID, (int)iMAP_Message.Size, iMAP_Message.Date, iMAP_Message.Flags, mime, bodyText))
			{
				if (uidSearch)
				{
					m_pSocket.Write(" " + iMAP_Message.MessageUID);
				}
				else
				{
					m_pSocket.Write(" " + i);
				}
			}
		}
		text3 += "\r\n";
		string text4 = text3;
		text3 = text4 + cmdTag + " OK SEARCH completed in " + ((decimal)(DateTime.Now.Ticks - ticks) / 10000000m).ToString("f2") + " seconds\r\n";
		m_pSocket.Write(text3);
	}

	private void Fetch(string cmdTag, string argsText, bool uidFetch)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		long ticks = DateTime.Now.Ticks;
		IMAP_MessageItems_enum iMAP_MessageItems_enum = IMAP_MessageItems_enum.None;
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD Invalid arguments");
			return;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		try
		{
			iMAP_SequenceSet.Parse(array[0]);
		}
		catch
		{
			m_pSocket.WriteLine(cmdTag + "BAD Invalid <sequnce-set> value '" + array[0] + "' Syntax: {<command-tag> FETCH <sequnce-set> (<fetch-keys>)}!");
			return;
		}
		string text = array[1].ToUpper();
		text = text.Replace("ALL", "FLAGS INTERNALDATE RFC822.SIZE ENVELOPE");
		text = text.Replace("FAST", "FLAGS INTERNALDATE RFC822.SIZE");
		text = text.Replace("FULL", "FLAGS INTERNALDATE RFC822.SIZE ENVELOPE BODY");
		if (uidFetch && text.ToUpper().IndexOf("UID") == -1)
		{
			text += " UID";
		}
		ArrayList arrayList = new ArrayList();
		StringReader stringReader = new StringReader(text.Trim());
		while (stringReader.Available > 0)
		{
			stringReader.ReadToFirstChar();
			if (stringReader.StartsWith("BODYSTRUCTURE"))
			{
				stringReader.ReadSpecifiedLength("BODYSTRUCTURE".Length);
				arrayList.Add(new object[1] { "BODYSTRUCTURE" });
				iMAP_MessageItems_enum |= IMAP_MessageItems_enum.BodyStructure;
			}
			else if (stringReader.StartsWith("BODY"))
			{
				stringReader.ReadSpecifiedLength("BODY".Length);
				bool flag = false;
				if (stringReader.StartsWith(".PEEK"))
				{
					stringReader.ReadSpecifiedLength(".PEEK".Length);
					flag = true;
				}
				if (stringReader.StartsWith("["))
				{
					string text2 = "";
					try
					{
						text2 = stringReader.ReadParenthesized();
					}
					catch
					{
						m_pSocket.WriteLine(cmdTag + " BAD Invalid BODY[], closing ] parenthesize is missing !");
						return;
					}
					string text3 = text2;
					string text4 = "";
					string text5 = "";
					string text6 = "";
					if (text2.Length > 0)
					{
						string[] array2 = text2.Split(new char[1] { ' ' }, 2);
						text2 = array2[0];
						if (array2.Length == 2)
						{
							text6 = array2[1];
						}
						if (text2.EndsWith("HEADER"))
						{
							text2 = text2.Substring(0, text2.Length - "HEADER".Length);
							text5 = "HEADER";
							iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Header;
						}
						else if (text2.EndsWith("HEADER.FIELDS"))
						{
							text2 = text2.Substring(0, text2.Length - "HEADER.FIELDS".Length);
							text5 = "HEADER.FIELDS";
							iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Header;
						}
						else if (text2.EndsWith("HEADER.FIELDS.NOT"))
						{
							text2 = text2.Substring(0, text2.Length - "HEADER.FIELDS.NOT".Length);
							text5 = "HEADER.FIELDS.NOT";
							iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Header;
						}
						else if (text2.EndsWith("TEXT"))
						{
							text2 = text2.Substring(0, text2.Length - "TEXT".Length);
							text5 = "TEXT";
							iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Message;
						}
						else if (text2.EndsWith("MIME"))
						{
							text2 = text2.Substring(0, text2.Length - "MIME".Length);
							text5 = "MIME";
							iMAP_MessageItems_enum = IMAP_MessageItems_enum.Header;
						}
						if (text2.EndsWith("."))
						{
							text2 = text2.Substring(0, text2.Length - 1);
						}
						if (text2.Length > 0)
						{
							iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Message;
							string[] array3 = text2.Split('.');
							string[] array4 = array3;
							foreach (string str in array4)
							{
								if (!Core.IsNumber(str))
								{
									m_pSocket.WriteLine(cmdTag + " BAD Invalid BODY[<section>] argument. Invalid <section>: " + text2);
									return;
								}
							}
							text4 = text2;
						}
					}
					else
					{
						iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Message;
					}
					long num = -1L;
					long num2 = -1L;
					if (stringReader.StartsWith("<"))
					{
						string text7 = "";
						try
						{
							text7 = stringReader.ReadParenthesized();
						}
						catch
						{
							m_pSocket.WriteLine(cmdTag + " BAD Invalid BODY[]<start[.length]>, closing > parenthesize is missing !");
							return;
						}
						string[] array5 = text7.Split('.');
						if (array5.Length == 0 || array5.Length > 2 || !Core.IsNumber(array5[0]) || (array5.Length == 2 && !Core.IsNumber(array5[1])))
						{
							m_pSocket.WriteLine(cmdTag + " BAD Invalid BODY[]<partial> argument. Invalid <partial>: " + text7);
							return;
						}
						num = Convert.ToInt64(array5[0]);
						if (array5.Length == 2)
						{
							num2 = Convert.ToInt64(array5[1]);
						}
					}
					arrayList.Add(new object[8] { "BODY[]", flag, text4, text3, text5, text6, num, num2 });
				}
				else
				{
					arrayList.Add(new object[1] { "BODY" });
					iMAP_MessageItems_enum |= IMAP_MessageItems_enum.BodyStructure;
				}
			}
			else if (stringReader.StartsWith("ENVELOPE"))
			{
				stringReader.ReadSpecifiedLength("ENVELOPE".Length);
				arrayList.Add(new object[1] { "ENVELOPE" });
				iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Envelope;
			}
			else if (stringReader.StartsWith("FLAGS"))
			{
				stringReader.ReadSpecifiedLength("FLAGS".Length);
				arrayList.Add(new object[1] { "FLAGS" });
			}
			else if (stringReader.StartsWith("INTERNALDATE"))
			{
				stringReader.ReadSpecifiedLength("INTERNALDATE".Length);
				arrayList.Add(new object[1] { "INTERNALDATE" });
			}
			else if (stringReader.StartsWith("RFC822.HEADER"))
			{
				stringReader.ReadSpecifiedLength("RFC822.HEADER".Length);
				arrayList.Add(new object[1] { "RFC822.HEADER" });
				iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Header;
			}
			else if (stringReader.StartsWith("RFC822.SIZE"))
			{
				stringReader.ReadSpecifiedLength("RFC822.SIZE".Length);
				arrayList.Add(new object[1] { "RFC822.SIZE" });
			}
			else if (stringReader.StartsWith("RFC822.TEXT"))
			{
				stringReader.ReadSpecifiedLength("RFC822.TEXT".Length);
				arrayList.Add(new object[1] { "RFC822.TEXT" });
				iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Message;
			}
			else if (stringReader.StartsWith("RFC822"))
			{
				stringReader.ReadSpecifiedLength("RFC822".Length);
				arrayList.Add(new object[1] { "RFC822" });
				iMAP_MessageItems_enum |= IMAP_MessageItems_enum.Message;
			}
			else
			{
				if (!stringReader.StartsWith("UID"))
				{
					m_pSocket.WriteLine(cmdTag + " BAD Invalid fetch-items argument. Unkown part starts from: " + stringReader.SourceString);
					return;
				}
				stringReader.ReadSpecifiedLength("UID".Length);
				arrayList.Add(new object[1] { "UID" });
			}
		}
		for (int j = 0; j < m_Messages.Count; j++)
		{
			IMAP_Message iMAP_Message = m_Messages[j];
			bool flag2 = false;
			if (!((!uidFetch) ? iMAP_SequenceSet.Contains(j + 1, m_Messages.Count) : iMAP_SequenceSet.Contains(iMAP_Message.MessageUID, m_Messages[m_Messages.Count - 1].MessageUID)))
			{
				continue;
			}
			m_pSocket.Write("* " + iMAP_Message.MessageNo + " FETCH (");
			IMAP_eArgs_MessageItems iMAP_eArgs_MessageItems = null;
			if (iMAP_MessageItems_enum != 0)
			{
				iMAP_eArgs_MessageItems = m_pServer.OnGetMessageItems(this, iMAP_Message, iMAP_MessageItems_enum);
				if (!iMAP_eArgs_MessageItems.MessageExists)
				{
					continue;
				}
				try
				{
					iMAP_eArgs_MessageItems.Validate();
				}
				catch (Exception ex)
				{
					m_pServer.OnSysError(ex.Message, ex);
					m_pSocket.WriteLine(cmdTag + " NO Internal IMAP server component error: " + ex.Message);
					return;
				}
			}
			IMAP_MessageFlags flags = iMAP_Message.Flags;
			int num3 = 0;
			foreach (object[] item in arrayList)
			{
				switch ((string)item[0])
				{
				case "BODY":
					iMAP_Message.SetFlags(iMAP_Message.Flags | IMAP_MessageFlags.Seen);
					m_pSocket.Write("BODY " + iMAP_eArgs_MessageItems.BodyStructure);
					break;
				case "BODY[]":
				{
					bool flag3 = (bool)item[1];
					string text4 = (string)item[2];
					string text3 = (string)item[3];
					string text5 = (string)item[4];
					string text6 = (string)item[5];
					long num = (long)item[6];
					long num2 = (long)item[7];
					if (!flag3)
					{
						iMAP_Message.SetFlags(iMAP_Message.Flags | IMAP_MessageFlags.Seen);
					}
					Stream stream = null;
					if (text5 == "" && text4 == "")
					{
						stream = iMAP_eArgs_MessageItems.MessageStream;
					}
					else
					{
						LumiSoft.Net.Mime.Mime mime = null;
						mime = ((iMAP_eArgs_MessageItems.MessageStream != null) ? LumiSoft.Net.Mime.Mime.Parse(iMAP_eArgs_MessageItems.MessageStream) : LumiSoft.Net.Mime.Mime.Parse(iMAP_eArgs_MessageItems.Header));
						MimeEntity mimeEntity3 = mime.MainEntity;
						if (text4 != "")
						{
							mimeEntity3 = FetchHelper.GetMimeEntity(mime, text4);
						}
						if (mimeEntity3 != null)
						{
							switch (text5)
							{
							case "HEADER":
								stream = new MemoryStream(FetchHelper.GetMimeEntityHeader(mimeEntity3));
								break;
							case "HEADER.FIELDS":
								stream = new MemoryStream(FetchHelper.ParseHeaderFields(text6, mimeEntity3));
								break;
							case "HEADER.FIELDS.NOT":
								stream = new MemoryStream(FetchHelper.ParseHeaderFieldsNot(text6, mimeEntity3));
								break;
							case "TEXT":
								try
								{
									stream = new MemoryStream(mimeEntity3.DataEncoded);
								}
								catch
								{
								}
								break;
							case "MIME":
								stream = new MemoryStream(FetchHelper.GetMimeEntityHeader(mimeEntity3));
								break;
							case "":
								try
								{
									stream = new MemoryStream(mimeEntity3.DataEncoded);
								}
								catch
								{
								}
								break;
							}
						}
					}
					if (num > -1)
					{
						if (stream == null)
						{
							m_pSocket.Write("BODY[" + text3 + "]<" + num + "> \"\"\r\n");
							break;
						}
						long num4 = num2;
						if (num4 == -1)
						{
							num4 = stream.Length - stream.Position - num;
						}
						if (num4 + num > stream.Length - stream.Position)
						{
							num4 = stream.Length - stream.Position - num;
						}
						if (num >= stream.Length - stream.Position)
						{
							m_pSocket.Write("BODY[" + text3 + "]<" + num + "> \"\"\r\n");
						}
						else
						{
							m_pSocket.Write("BODY[" + text3 + "]<" + num.ToString() + "> {" + num4 + "}\r\n");
							stream.Position += num;
							m_pSocket.Write(stream, num4);
						}
					}
					else if (stream == null)
					{
						m_pSocket.Write("BODY[" + text3 + "] \"\"\r\n");
					}
					else
					{
						m_pSocket.Write("BODY[" + text3 + "] {" + (stream.Length - stream.Position) + "}\r\n");
						m_pSocket.Write(stream);
					}
					break;
				}
				case "BODYSTRUCTURE":
					m_pSocket.Write("BODYSTRUCTURE " + iMAP_eArgs_MessageItems.BodyStructure);
					break;
				case "ENVELOPE":
					m_pSocket.Write("ENVELOPE " + iMAP_eArgs_MessageItems.Envelope);
					break;
				case "FLAGS":
					m_pSocket.Write("FLAGS (" + iMAP_Message.FlagsToString() + ")");
					break;
				case "INTERNALDATE":
					m_pSocket.Write("INTERNALDATE \"" + IMAP_Utils.DateTimeToString(iMAP_Message.Date) + "\"");
					break;
				case "RFC822":
					iMAP_Message.SetFlags(iMAP_Message.Flags | IMAP_MessageFlags.Seen);
					m_pSocket.Write("RFC822 {" + iMAP_eArgs_MessageItems.MessageSize + "}\r\n");
					m_pSocket.Write(iMAP_eArgs_MessageItems.MessageStream);
					break;
				case "RFC822.HEADER":
					m_pSocket.Write("RFC822.HEADER {" + iMAP_eArgs_MessageItems.Header.Length + "}\r\n");
					m_pSocket.Write(iMAP_eArgs_MessageItems.Header);
					break;
				case "RFC822.SIZE":
					m_pSocket.Write("RFC822.SIZE " + iMAP_Message.Size);
					break;
				case "RFC822.TEXT":
				{
					iMAP_Message.SetFlags(iMAP_Message.Flags | IMAP_MessageFlags.Seen);
					LumiSoft.Net.Mime.Mime mime = LumiSoft.Net.Mime.Mime.Parse(iMAP_eArgs_MessageItems.MessageStream);
					MimeEntity mimeEntity = null;
					if (mime.MainEntity.ContentType == MediaType_enum.NotSpecified)
					{
						if (mime.MainEntity.DataEncoded != null)
						{
							mimeEntity = mime.MainEntity;
						}
					}
					else
					{
						MimeEntity[] mimeEntities = mime.MimeEntities;
						MimeEntity[] array7 = mimeEntities;
						foreach (MimeEntity mimeEntity2 in array7)
						{
							if (mimeEntity2.ContentType == MediaType_enum.Text_plain)
							{
								mimeEntity = mimeEntity2;
								break;
							}
						}
					}
					byte[] array8 = null;
					array8 = ((mimeEntity == null) ? Encoding.ASCII.GetBytes("") : mimeEntity.DataEncoded);
					m_pSocket.Write("RFC822.TEXT {" + array8.Length + "}\r\n");
					m_pSocket.Write(array8);
					break;
				}
				case "UID":
					m_pSocket.Write("UID " + iMAP_Message.MessageUID);
					break;
				}
				num3++;
				if (num3 < arrayList.Count)
				{
					m_pSocket.Write(" ");
				}
			}
			m_pSocket.Write(")\r\n");
			iMAP_eArgs_MessageItems?.Dispose();
			if ((IMAP_MessageFlags.Recent & iMAP_Message.Flags) != 0 || flags != iMAP_Message.Flags)
			{
				iMAP_Message.SetFlags(iMAP_Message.Flags & (IMAP_MessageFlags)(-65));
				m_pServer.OnStoreMessageFlags(this, iMAP_Message);
			}
		}
		m_pSocket.WriteLine(cmdTag + " OK FETCH completed in " + ((decimal)(DateTime.Now.Ticks - ticks) / 10000000m).ToString("f2") + " seconds");
	}

	private void Store(string cmdTag, string argsText, bool uidStore)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		if (m_Messages.ReadOnly)
		{
			m_pSocket.WriteLine(cmdTag + " NO Mailbox is read-only");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 3)
		{
			m_pSocket.WriteLine(cmdTag + " BAD STORE invalid arguments. Syntax: {<command-tag> STORE <sequnce-set> <data-item> (<message-flags>)}");
			return;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		try
		{
			iMAP_SequenceSet.Parse(array[0]);
		}
		catch
		{
			m_pSocket.WriteLine(cmdTag + "BAD Invalid <sequnce-set> value '" + array[0] + "' Syntax: {<command-tag> STORE <sequnce-set> <data-item> (<message-flags>)}!");
			return;
		}
		string text = "";
		bool flag = false;
		switch (array[1].ToUpper())
		{
		case "FLAGS":
			text = "REPLACE";
			break;
		case "FLAGS.SILENT":
			text = "REPLACE";
			flag = true;
			break;
		case "+FLAGS":
			text = "ADD";
			break;
		case "+FLAGS.SILENT":
			text = "ADD";
			flag = true;
			break;
		case "-FLAGS":
			text = "REMOVE";
			break;
		case "-FLAGS.SILENT":
			text = "REMOVE";
			flag = true;
			break;
		default:
			m_pSocket.WriteLine(cmdTag + " BAD arguments invalid");
			return;
		}
		string text2 = array[2].ToUpper();
		if (text2.Replace("\\ANSWERED", "").Replace("\\FLAGGED", "").Replace("\\DELETED", "")
			.Replace("\\SEEN", "")
			.Replace("\\DRAFT", "")
			.Trim()
			.Length > 0)
		{
			m_pSocket.WriteLine(cmdTag + " BAD arguments invalid");
			return;
		}
		IMAP_MessageFlags iMAP_MessageFlags = IMAP_Utils.ParseMessageFlags(text2);
		for (int i = 0; i < m_Messages.Count; i++)
		{
			IMAP_Message iMAP_Message = m_Messages[i];
			bool flag2 = false;
			if (!((!uidStore) ? iMAP_SequenceSet.Contains(iMAP_Message.MessageNo, m_Messages[m_Messages.Count - 1].MessageNo) : iMAP_SequenceSet.Contains(iMAP_Message.MessageUID, m_Messages[m_Messages.Count - 1].MessageUID)))
			{
				continue;
			}
			switch (text)
			{
			case "REPLACE":
				iMAP_Message.SetFlags(iMAP_MessageFlags);
				break;
			case "ADD":
				iMAP_Message.SetFlags(iMAP_Message.Flags | iMAP_MessageFlags);
				break;
			case "REMOVE":
				iMAP_Message.SetFlags(iMAP_Message.Flags & ~iMAP_MessageFlags);
				break;
			}
			string text3 = m_pServer.OnStoreMessageFlags(this, iMAP_Message);
			if (text3 == null)
			{
				if (!flag)
				{
					if (!uidStore)
					{
						m_pSocket.WriteLine("* " + (i + 1) + " FETCH FLAGS (" + iMAP_Message.FlagsToString() + ")");
					}
					else
					{
						m_pSocket.WriteLine("* " + (i + 1) + " FETCH (FLAGS (" + iMAP_Message.FlagsToString() + ") UID " + iMAP_Message.MessageUID + "))");
					}
				}
				continue;
			}
			m_pSocket.WriteLine(cmdTag + " NO " + text3);
			return;
		}
		m_pSocket.WriteLine(cmdTag + " OK STORE completed");
	}

	private void Copy(string cmdTag, string argsText, bool uidCopy)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length != 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD Invalid arguments");
			return;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		try
		{
			iMAP_SequenceSet.Parse(array[0]);
		}
		catch
		{
			m_pSocket.WriteLine(cmdTag + "BAD Invalid <sequnce-set> value '" + array[0] + "' Syntax: {<command-tag> COPY <sequnce-set> \"<mailbox-name>\"}!");
			return;
		}
		string text = "";
		for (int i = 0; i < m_Messages.Count; i++)
		{
			IMAP_Message iMAP_Message = m_Messages[i];
			bool flag = false;
			if ((!uidCopy) ? iMAP_SequenceSet.Contains(iMAP_Message.MessageNo, m_Messages[m_Messages.Count - 1].MessageNo) : iMAP_SequenceSet.Contains(iMAP_Message.MessageUID, m_Messages[m_Messages.Count - 1].MessageUID))
			{
				text = m_pServer.OnCopyMessage(this, iMAP_Message, Core.Decode_IMAP_UTF7_String(array[1]));
				if (text != null)
				{
					break;
				}
			}
		}
		if (text == null)
		{
			m_pSocket.WriteLine(cmdTag + " OK COPY completed");
		}
		else
		{
			m_pSocket.WriteLine(cmdTag + " NO " + text);
		}
	}

	private void Uid(string cmdTag, string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine(cmdTag + " NO Authenticate first !");
			return;
		}
		if (m_SelectedMailbox.Length == 0)
		{
			m_pSocket.WriteLine(cmdTag + " NO Select mailbox first !");
			return;
		}
		string[] array = ParseParams(argsText);
		if (array.Length < 2)
		{
			m_pSocket.WriteLine(cmdTag + " BAD Invalid arguments");
			return;
		}
		string argsText2 = Core.GetArgsText(argsText, array[0]);
		switch (array[0].ToUpper())
		{
		case "COPY":
			Copy(cmdTag, argsText2, uidCopy: true);
			break;
		case "FETCH":
			Fetch(cmdTag, argsText2, uidFetch: true);
			break;
		case "STORE":
			Store(cmdTag, argsText2, uidStore: true);
			break;
		case "SEARCH":
			Search(cmdTag, argsText2, uidSearch: true);
			break;
		default:
			m_pSocket.WriteLine(cmdTag + " BAD Invalid arguments");
			break;
		}
	}

	private void Capability(string cmdTag)
	{
		string text = "* CAPABILITY IMAP4rev1";
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Digest_md5) != 0)
		{
			text += " AUTH=DIGEST-MD5";
		}
		if ((m_pServer.SupportedAuthentications & SaslAuthTypes.Cram_md5) != 0)
		{
			text += " AUTH=CRAM-MD5";
		}
		if (!m_pSocket.SSL && m_pBindInfo.SSL_Certificate != null)
		{
			text += " STARTTLS";
		}
		text += " NAMESPACE ACL\r\n";
		text = text + cmdTag + " OK CAPABILITY completed\r\n";
		m_pSocket.Write(text);
	}

	private void Noop(string cmdTag)
	{
		if (m_SelectedMailbox.Length > 0)
		{
			IMAP_Messages iMAP_Messages = m_pServer.OnGetMessagesInfo(this, m_SelectedMailbox);
			if (iMAP_Messages.Count != m_Messages.Count || iMAP_Messages.RecentCount != m_Messages.RecentCount)
			{
				m_Messages = iMAP_Messages;
				string text = "";
				object obj = text;
				text = string.Concat(obj, "* ", m_Messages.Count, " EXISTS\r\n");
				obj = text;
				text = string.Concat(obj, "* ", m_Messages.RecentCount, " RECENT\r\n");
				m_pSocket.Write(text);
			}
		}
		m_pSocket.WriteLine(cmdTag + " OK NOOP completed");
	}

	private void LogOut(string cmdTag)
	{
		string text = "* BYE IMAP4rev1 Server logging out\r\n";
		text = text + cmdTag + " OK LOGOUT completed\r\n";
		m_pSocket.Write(text);
	}

	private string[] ParseParams(string argsText)
	{
		ArrayList arrayList = new ArrayList();
		try
		{
			while (argsText.Length > 0)
			{
				if (argsText.StartsWith("\""))
				{
					arrayList.Add(argsText.Substring(1, argsText.IndexOf("\"", 1) - 1));
					argsText = argsText.Substring(argsText.IndexOf("\"", 1) + 1).Trim();
				}
				else if (argsText.StartsWith("("))
				{
					arrayList.Add(argsText.Substring(1, argsText.LastIndexOf(")") - 1));
					argsText = argsText.Substring(argsText.LastIndexOf(")") + 1).Trim();
				}
				else if (argsText.IndexOf(" ") > -1 && argsText.IndexOfAny(new char[2] { '(', '[' }, 0, argsText.IndexOf(" ")) == -1)
				{
					arrayList.Add(argsText.Substring(0, argsText.IndexOf(" ")));
					argsText = argsText.Substring(argsText.IndexOf(" ") + 1).Trim();
				}
				else
				{
					arrayList.Add(argsText);
					argsText = "";
				}
			}
		}
		catch
		{
		}
		string[] array = new string[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}
}

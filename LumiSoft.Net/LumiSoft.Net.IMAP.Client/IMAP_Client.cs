using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumiSoft.Net.IMAP.Server;

namespace LumiSoft.Net.IMAP.Client;

public class IMAP_Client : IDisposable
{
	private SocketEx m_pSocket = null;

	private bool m_Connected = false;

	private bool m_Authenticated = false;

	private string m_SelectedFolder = "";

	private int m_MsgCount = 0;

	private int m_NewMsgCount = 0;

	private long m_UIDNext = 0L;

	private long m_UIDValidity = 0L;

	public bool Connected => m_Connected;

	public bool Authenticated => m_Authenticated;

	public string SelectedFolder => m_SelectedFolder;

	public long UIDValidity => m_UIDValidity;

	public long UIDNext => m_UIDNext;

	public int RecentMessagesCount => m_NewMsgCount;

	public int MessagesCount => m_MsgCount;

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

	public void Dispose()
	{
		Disconnect();
	}

	public void Connect(string host, int port)
	{
		Connect(host, port, ssl: false);
	}

	public void Connect(string host, int port, bool ssl)
	{
		if (!m_Connected)
		{
			m_pSocket = new SocketEx();
			m_pSocket.Connect(host, port, ssl);
			string text = m_pSocket.ReadLine();
			text = text.Substring(text.IndexOf(" ")).Trim();
			if (!text.ToUpper().StartsWith("OK"))
			{
				m_pSocket.Disconnect();
				m_pSocket = null;
				throw new Exception("Server returned:" + text);
			}
			m_Connected = true;
		}
	}

	public void Disconnect()
	{
		if (m_pSocket != null && m_pSocket.Connected)
		{
			m_pSocket.WriteLine("a1 LOGOUT");
			m_pSocket = null;
		}
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
			throw new Exception("The STARTTLS command is only valid in non-authenticated state !");
		}
		if (m_pSocket.SSL)
		{
			throw new Exception("Connection is already secure !");
		}
		m_pSocket.WriteLine("a1 STARTTLS");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_pSocket.SwitchToSSL_AsClient();
	}

	public void Authenticate(string userName, string password)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (m_Authenticated)
		{
			throw new Exception("You are already authenticated !");
		}
		m_pSocket.WriteLine("a1 LOGIN \"" + userName + "\" \"" + password + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (text.ToUpper().StartsWith("OK"))
		{
			m_Authenticated = true;
			return;
		}
		throw new Exception("Server returned:" + text);
	}

	public void CreateFolder(string folderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 CREATE \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void DeleteFolder(string folderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 DELETE \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void RenameFolder(string sourceFolderName, string destinationFolderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 RENAME \"" + Core.Encode_IMAP_UTF7_String(sourceFolderName) + "\" \"" + Core.Encode_IMAP_UTF7_String(destinationFolderName) + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public string[] GetFolders()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		ArrayList arrayList = new ArrayList();
		m_pSocket.WriteLine("a1 LIST \"\" \"*\"");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("*"))
		{
			while (text.StartsWith("*"))
			{
				if (text.ToLower().IndexOf("\\noselect") == -1)
				{
					text = text.Substring(text.IndexOf(")") + 1).Trim();
					text = text.Substring(text.IndexOf(" ")).Trim();
					if (text.IndexOf("\"") > -1)
					{
						arrayList.Add(Core.Decode_IMAP_UTF7_String(text.Substring(text.IndexOf("\"") + 1, text.Length - text.IndexOf("\"") - 2)));
					}
					else
					{
						arrayList.Add(Core.Decode_IMAP_UTF7_String(text.Trim()));
					}
				}
				text = m_pSocket.ReadLine();
			}
		}
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		string[] array = new string[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}

	public string[] GetSubscribedFolders()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		ArrayList arrayList = new ArrayList();
		m_pSocket.WriteLine("a1 LSUB \"\" \"*\"");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("*"))
		{
			while (text.StartsWith("*"))
			{
				if (text.ToLower().IndexOf("\\noselect") == -1)
				{
					text = text.Substring(text.IndexOf(")") + 1).Trim();
					text = text.Substring(text.IndexOf(" ")).Trim();
					if (text.IndexOf("\"") > -1)
					{
						arrayList.Add(Core.Decode_IMAP_UTF7_String(text.Substring(text.IndexOf("\"") + 1, text.Length - text.IndexOf("\"") - 2)));
					}
					else
					{
						arrayList.Add(Core.Decode_IMAP_UTF7_String(text.Trim()));
					}
				}
				text = m_pSocket.ReadLine();
			}
		}
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		string[] array = new string[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}

	public void SubscribeFolder(string folderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 SUBSCRIBE \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void UnSubscribeFolder(string folderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 UNSUBSCRIBE \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void SelectFolder(string folderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 SELECT \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\"");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("*"))
		{
			while (text.StartsWith("*"))
			{
				text = text.Substring(1).Trim();
				if (text.ToUpper().IndexOf("EXISTS") > -1 && text.ToUpper().IndexOf("FLAGS") == -1)
				{
					m_MsgCount = Convert.ToInt32(text.Substring(0, text.IndexOf(" ")).Trim());
				}
				else if (text.ToUpper().IndexOf("RECENT") > -1 && text.ToUpper().IndexOf("FLAGS") == -1)
				{
					m_NewMsgCount = Convert.ToInt32(text.Substring(0, text.IndexOf(" ")).Trim());
				}
				else if (text.ToUpper().IndexOf("UIDNEXT") > -1)
				{
					m_UIDNext = Convert.ToInt64(text.Substring(text.ToUpper().IndexOf("UIDNEXT") + 8, text.IndexOf(']') - text.ToUpper().IndexOf("UIDNEXT") - 8));
				}
				else if (text.ToUpper().IndexOf("UIDVALIDITY") > -1)
				{
					m_UIDValidity = Convert.ToInt64(text.Substring(text.ToUpper().IndexOf("UIDVALIDITY") + 12, text.IndexOf(']') - text.ToUpper().IndexOf("UIDVALIDITY") - 12));
				}
				text = m_pSocket.ReadLine();
			}
		}
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_SelectedFolder = folderName;
	}

	public void GetFolderACL(string folderName)
	{
		throw new Exception("TODO:");
	}

	public void SetFolderACL(string folderName, string userName, IMAP_ACL_Flags acl)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 SETACL \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\" \"" + userName + "\" " + IMAP_Utils.ACL_to_String(acl));
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void DeleteFolderACL(string folderName, string userName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 DELETEACL \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\" \"" + userName + "\"");
		string text = m_pSocket.ReadLine();
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public IMAP_ACL_Flags GetFolderMyrights(string folderName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		IMAP_ACL_Flags result = IMAP_ACL_Flags.None;
		m_pSocket.WriteLine("a1 MYRIGHTS \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\"");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("*"))
		{
			while (text.StartsWith("*"))
			{
				text = text.Substring(1).Trim();
				if (text.ToUpper().IndexOf("MYRIGHTS") > -1)
				{
					result = IMAP_Utils.ACL_From_String(text.Substring(0, text.IndexOf(" ")).Trim());
				}
				text = m_pSocket.ReadLine();
			}
		}
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		return result;
	}

	[Obsolete("Use CopyMessages(IMAP_SequenceSet sequence_set,string destFolder,bool uidCopy) instead !")]
	public void CopyMessages(int startMsgNo, int endMsgNo, string destFolder, bool uidCopy)
	{
		string text = startMsgNo.ToString();
		if (endMsgNo == -1)
		{
			text += ":*";
		}
		else if (startMsgNo != endMsgNo)
		{
			text = text + ":" + endMsgNo;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		iMAP_SequenceSet.Parse(text);
		CopyMessages(iMAP_SequenceSet, destFolder, uidCopy);
	}

	public void CopyMessages(IMAP_SequenceSet sequence_set, string destFolder, bool uidCopy)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		if (uidCopy)
		{
			m_pSocket.WriteLine("a1 UID COPY " + sequence_set.ToSequenceSetString() + " \"" + Core.Encode_IMAP_UTF7_String(destFolder) + "\"");
		}
		else
		{
			m_pSocket.WriteLine("a1 COPY " + sequence_set.ToSequenceSetString() + " \"" + Core.Encode_IMAP_UTF7_String(destFolder) + "\"");
		}
		string text = m_pSocket.ReadLine();
		while (text.StartsWith("*"))
		{
			ProcessStatusResponse(text);
			text = m_pSocket.ReadLine();
		}
		if (!RemoveCmdTag(text).ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	[Obsolete("Use MoveMessages(IMAP_SequenceSet sequence_set,string destFolder,bool uidMove) instead !")]
	public void MoveMessages(int startMsgNo, int endMsgNo, string destFolder, bool uidMove)
	{
		string text = startMsgNo.ToString();
		if (endMsgNo == -1)
		{
			text += ":*";
		}
		else if (startMsgNo != endMsgNo)
		{
			text = text + ":" + endMsgNo;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		iMAP_SequenceSet.Parse(text);
		MoveMessages(iMAP_SequenceSet, destFolder, uidMove);
	}

	public void MoveMessages(IMAP_SequenceSet sequence_set, string destFolder, bool uidMove)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		CopyMessages(sequence_set, destFolder, uidMove);
		DeleteMessages(sequence_set, uidMove);
	}

	[Obsolete("Use DeleteMessages(IMAP_SequenceSet sequence_set,bool uidDelete) instead !")]
	public void DeleteMessages(int startMsgNo, int endMsgNo, bool uidDelete)
	{
		string text = startMsgNo.ToString();
		if (endMsgNo == -1)
		{
			text += ":*";
		}
		else if (startMsgNo != endMsgNo)
		{
			text = text + ":" + endMsgNo;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		iMAP_SequenceSet.Parse(text);
		DeleteMessages(iMAP_SequenceSet, uidDelete);
	}

	public void DeleteMessages(IMAP_SequenceSet sequence_set, bool uidDelete)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		if (uidDelete)
		{
			m_pSocket.WriteLine("a1 UID STORE " + sequence_set.ToSequenceSetString() + " +FLAGS.SILENT (\\Deleted)");
		}
		else
		{
			m_pSocket.WriteLine("a1 STORE " + sequence_set.ToSequenceSetString() + " +FLAGS.SILENT (\\Deleted)");
		}
		string text = m_pSocket.ReadLine();
		while (text.StartsWith("*"))
		{
			ProcessStatusResponse(text);
			text = m_pSocket.ReadLine();
		}
		if (!RemoveCmdTag(text).ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_pSocket.WriteLine("a1 EXPUNGE");
		text = m_pSocket.ReadLine();
		while (text.StartsWith("*"))
		{
			ProcessStatusResponse(text);
			text = m_pSocket.ReadLine();
		}
		if (!RemoveCmdTag(text).ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void StoreMessage(string folderName, byte[] data)
	{
		StoreMessage(folderName, IMAP_MessageFlags.Seen, DateTime.Now, data);
	}

	public void StoreMessage(string folderName, IMAP_MessageFlags messageFlags, DateTime inernalDate, byte[] data)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("a1 APPEND \"" + Core.Encode_IMAP_UTF7_String(folderName) + "\" (" + IMAP_Utils.MessageFlagsToString(messageFlags) + ") \"" + IMAP_Utils.DateTimeToString(inernalDate) + "\" {" + data.Length + "}");
		string text = m_pSocket.ReadLine();
		while (text.StartsWith("*"))
		{
			ProcessStatusResponse(text);
			text = m_pSocket.ReadLine();
		}
		if (text.StartsWith("+"))
		{
			m_pSocket.Write(data);
			m_pSocket.Write(new byte[2] { 13, 10 });
			text = m_pSocket.ReadLine();
			while (text.StartsWith("*"))
			{
				ProcessStatusResponse(text);
				text = m_pSocket.ReadLine();
			}
			if (!RemoveCmdTag(text).ToUpper().StartsWith("OK"))
			{
				throw new Exception("Server returned:" + text);
			}
			return;
		}
		throw new Exception("Server returned:" + text);
	}

	private int[] Search()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		return null;
	}

	[Obsolete("Use FetchMessages(IMAP_SequenceSet sequence_set,IMAP_FetchItem_Flags fetchFlags,bool setSeenFlag,bool uidFetch) instead !")]
	public IMAP_FetchItem[] FetchMessages(int startMsgNo, int endMsgNo, bool uidFetch, bool headersOnly, bool setSeenFlag)
	{
		string text = startMsgNo.ToString();
		if (endMsgNo == -1)
		{
			text += ":*";
		}
		else if (startMsgNo != endMsgNo)
		{
			text = text + ":" + endMsgNo;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		iMAP_SequenceSet.Parse(text);
		if (headersOnly)
		{
			return FetchMessages(iMAP_SequenceSet, (IMAP_FetchItem_Flags)27, setSeenFlag, uidFetch);
		}
		return FetchMessages(iMAP_SequenceSet, (IMAP_FetchItem_Flags)43, setSeenFlag, uidFetch);
	}

	public IMAP_FetchItem[] FetchMessages(IMAP_SequenceSet sequence_set, IMAP_FetchItem_Flags fetchFlags, bool setSeenFlag, bool uidFetch)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		List<IMAP_FetchItem> list = new List<IMAP_FetchItem>();
		string text = "a1";
		if (uidFetch)
		{
			text += " UID";
		}
		text = text + " FETCH " + sequence_set.ToSequenceSetString() + " (UID";
		if ((fetchFlags & IMAP_FetchItem_Flags.MessageFlags) != 0)
		{
			text += " FLAGS";
		}
		if ((fetchFlags & IMAP_FetchItem_Flags.Size) != 0)
		{
			text += " RFC822.SIZE";
		}
		if ((fetchFlags & IMAP_FetchItem_Flags.InternalDate) != 0)
		{
			text += " INTERNALDATE";
		}
		if ((fetchFlags & IMAP_FetchItem_Flags.Envelope) != 0)
		{
			text += " ENVELOPE";
		}
		if ((fetchFlags & IMAP_FetchItem_Flags.BodyStructure) != 0)
		{
			text += " BODYSTRUCTURE";
		}
		if ((fetchFlags & IMAP_FetchItem_Flags.Message) != 0)
		{
			text = ((!setSeenFlag) ? (text + " BODY.PEEK[]") : (text + " BODY[]"));
		}
		if ((fetchFlags & IMAP_FetchItem_Flags.Message) == 0 && (fetchFlags & IMAP_FetchItem_Flags.Header) != 0)
		{
			text = ((!setSeenFlag) ? (text + " BODY.PEEK[HEADER]") : (text + " BODY[HEADER]"));
		}
		text += ")";
		m_pSocket.WriteLine(text);
		string text2 = m_pSocket.ReadLine(50000);
		while (text2.StartsWith("*"))
		{
			if (IsStatusResponse(text2))
			{
				text2 = m_pSocket.ReadLine(50000);
				continue;
			}
			int num = 0;
			int uid = 0;
			int size = 0;
			byte[] data = null;
			IMAP_MessageFlags flags = IMAP_MessageFlags.Recent;
			string envelope = "";
			string bodyStructure = "";
			string internalDate = "";
			text2 = text2.Substring(1).TrimStart();
			num = Convert.ToInt32(text2.Substring(0, text2.IndexOf(" ")));
			text2 = text2.Substring(text2.IndexOf("FETCH (") + 7);
			StringReader stringReader = new StringReader(text2);
			while (stringReader.Available > 0)
			{
				stringReader.ReadToFirstChar();
				if (stringReader.SourceString == ")")
				{
					break;
				}
				if (stringReader.StartsWith("UID", case_sensitive: false))
				{
					stringReader.ReadSpecifiedLength("UID".Length);
					stringReader.ReadToFirstChar();
					string text3 = stringReader.ReadWord();
					if (text3 == null)
					{
						throw new Exception("IMAP server didn't return UID <value> !");
					}
					uid = Convert.ToInt32(text3);
				}
				else if (stringReader.StartsWith("RFC822.SIZE", case_sensitive: false))
				{
					stringReader.ReadSpecifiedLength("RFC822.SIZE".Length);
					stringReader.ReadToFirstChar();
					string text3 = stringReader.ReadWord();
					if (text3 == null)
					{
						throw new Exception("IMAP server didn't return RFC822.SIZE <value> !");
					}
					try
					{
						size = Convert.ToInt32(text3);
					}
					catch
					{
						throw new Exception("IMAP server returned invalid RFC822.SIZE <value> '" + text3 + "' !");
					}
				}
				else if (stringReader.StartsWith("INTERNALDATE", case_sensitive: false))
				{
					stringReader.ReadSpecifiedLength("INTERNALDATE".Length);
					stringReader.ReadToFirstChar();
					string text3 = stringReader.ReadWord();
					if (text3 == null)
					{
						throw new Exception("IMAP server didn't return INTERNALDATE <value> !");
					}
					internalDate = text3;
				}
				else if (stringReader.StartsWith("ENVELOPE", case_sensitive: false))
				{
					stringReader.ReadSpecifiedLength("ENVELOPE".Length);
					stringReader.ReadToFirstChar();
					while (true)
					{
						bool flag = true;
						try
						{
							envelope = stringReader.ReadParenthesized();
						}
						catch (Exception ex)
						{
							string text4 = stringReader.ReadToEnd();
							if (text4.EndsWith("}"))
							{
								stringReader.AppenString(text4.Substring(0, text4.LastIndexOf('{')));
								int lengthToRead = Convert.ToInt32(text4.Substring(text4.LastIndexOf('{') + 1, text4.LastIndexOf('}') - text4.LastIndexOf('{') - 1));
								MemoryStream memoryStream = new MemoryStream();
								m_pSocket.ReadSpecifiedLength(lengthToRead, memoryStream);
								stringReader.AppenString(TextUtils.QuoteString(Encoding.Default.GetString(memoryStream.ToArray())));
								stringReader.AppenString(m_pSocket.ReadLine(50000));
								continue;
							}
							throw ex;
						}
						break;
					}
				}
				else if (stringReader.StartsWith("BODYSTRUCTURE", case_sensitive: false))
				{
					stringReader.ReadSpecifiedLength("BODYSTRUCTURE".Length);
					stringReader.ReadToFirstChar();
					bodyStructure = stringReader.ReadParenthesized();
				}
				else if (stringReader.StartsWith("BODY", case_sensitive: false))
				{
					if (stringReader.StartsWith("BODY[]", case_sensitive: false))
					{
						stringReader.ReadSpecifiedLength("BODY[]".Length);
					}
					else
					{
						if (!stringReader.StartsWith("BODY[HEADER]", case_sensitive: false))
						{
							throw new Exception("Invalid FETCH response: " + stringReader.SourceString);
						}
						stringReader.ReadSpecifiedLength("BODY[HEADER]".Length);
					}
					stringReader.ReadToFirstChar();
					if (!stringReader.StartsWith("{"))
					{
						throw new Exception("Invalid FETCH BODY[] or BODY[HEADER] response: " + stringReader.SourceString);
					}
					int num2 = Convert.ToInt32(stringReader.ReadParenthesized());
					MemoryStream memoryStream2 = new MemoryStream(num2);
					m_pSocket.ReadSpecifiedLength(num2, memoryStream2);
					data = memoryStream2.ToArray();
					stringReader.AppenString(m_pSocket.ReadLine(50000).Trim());
				}
				else
				{
					if (!stringReader.StartsWith("FLAGS", case_sensitive: false))
					{
						throw new Exception("Not supported fetch reply: " + stringReader.SourceString);
					}
					stringReader.ReadSpecifiedLength("FLAGS".Length);
					stringReader.ReadToFirstChar();
					string text5 = stringReader.ReadParenthesized();
					if (text5 == null)
					{
						throw new Exception("IMAP server didn't return FLAGS (<flags-list>) !");
					}
					flags = IMAP_Utils.ParseMessageFlags(text5);
				}
			}
			list.Add(new IMAP_FetchItem(num, uid, size, data, flags, internalDate, envelope, bodyStructure, fetchFlags));
			text2 = m_pSocket.ReadLine(50000);
		}
		if (!RemoveCmdTag(text2).ToUpper().StartsWith("OK") && !text2.ToUpper().StartsWith("NO"))
		{
			throw new Exception("Server returned:" + text2);
		}
		return list.ToArray();
	}

	[Obsolete("Use StoreMessageFlags(IMAP_SequenceSet sequence_set,IMAP_MessageFlags msgFlags,bool uidStore) instead !")]
	public void StoreMessageFlags(int startMsgNo, int endMsgNo, bool uidStore, IMAP_MessageFlags msgFlags)
	{
		string text = startMsgNo.ToString();
		if (endMsgNo == -1)
		{
			text += ":*";
		}
		else if (startMsgNo != endMsgNo)
		{
			text = text + ":" + endMsgNo;
		}
		IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
		iMAP_SequenceSet.Parse(text);
		StoreMessageFlags(iMAP_SequenceSet, msgFlags, uidStore);
	}

	public void StoreMessageFlags(IMAP_SequenceSet sequence_set, IMAP_MessageFlags msgFlags, bool uidStore)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		if (uidStore)
		{
			m_pSocket.WriteLine("a1 UID STORE " + sequence_set.ToSequenceSetString() + " FLAGS (" + IMAP_Utils.MessageFlagsToString(msgFlags) + ")");
		}
		else
		{
			m_pSocket.WriteLine("a1 STORE " + sequence_set.ToSequenceSetString() + " FLAGS (" + IMAP_Utils.MessageFlagsToString(msgFlags) + ")");
		}
		string text = m_pSocket.ReadLine();
		while (text.StartsWith("*"))
		{
			ProcessStatusResponse(text);
			text = m_pSocket.ReadLine();
		}
		if (!RemoveCmdTag(text).ToUpper().StartsWith("OK"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public int GetMessagesTotalSize()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		int num = 0;
		m_pSocket.WriteLine("a1 FETCH 1:* (RFC822.SIZE)");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("*"))
		{
			while (text.StartsWith("*"))
			{
				text = text.Substring(text.IndexOf("FETCH (") + 7);
				if (text.ToUpper().StartsWith("RFC822.SIZE"))
				{
					text = text.Substring(11).Trim();
					num += Convert.ToInt32(text.Substring(0, text.Length - 1).Trim());
				}
				text = m_pSocket.ReadLine();
			}
		}
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK") && !text.ToUpper().StartsWith("NO"))
		{
			throw new Exception("Server returned:" + text);
		}
		return num;
	}

	public int GetUnseenMessagesCount()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		if (m_SelectedFolder.Length == 0)
		{
			throw new Exception("You must select folder first !");
		}
		int num = 0;
		m_pSocket.WriteLine("a1 FETCH 1:* (FLAGS)");
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("*"))
		{
			while (text.StartsWith("*"))
			{
				text = text.Substring(text.IndexOf("FETCH (") + 7);
				if (text.ToUpper().IndexOf("\\SEEN") == -1)
				{
					num++;
				}
				text = m_pSocket.ReadLine();
			}
		}
		text = text.Substring(text.IndexOf(" ")).Trim();
		if (!text.ToUpper().StartsWith("OK") && !text.ToUpper().StartsWith("NO"))
		{
			throw new Exception("Server returned:" + text);
		}
		return num;
	}

	public string GetFolderSeparator()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		string text = "";
		m_pSocket.WriteLine("a1 LIST \"\" \"\"");
		string text2 = m_pSocket.ReadLine();
		if (text2.StartsWith("*"))
		{
			while (text2.StartsWith("*"))
			{
				text2 = text2.Substring(text2.IndexOf(")") + 1).Trim();
				text = text2.Substring(0, text2.IndexOf(" ")).Trim();
				text2 = m_pSocket.ReadLine();
			}
		}
		text2 = text2.Substring(text2.IndexOf(" ")).Trim();
		if (!text2.ToUpper().StartsWith("OK") && !text2.ToUpper().StartsWith("NO"))
		{
			throw new Exception("Server returned:" + text2);
		}
		text2 = text2.Substring(text2.IndexOf(")") + 1).Trim();
		return text.Replace("\"", "");
	}

	private string RemoveCmdTag(string responseLine)
	{
		return responseLine.Substring(responseLine.IndexOf(" ")).Trim();
	}

	private void ProcessStatusResponse(string statusResponse)
	{
		statusResponse = statusResponse.ToUpper();
		statusResponse = statusResponse.Substring(1).Trim();
		if (statusResponse.IndexOf("EXISTS") > -1 && statusResponse.IndexOf("FLAGS") == -1)
		{
			m_MsgCount = Convert.ToInt32(statusResponse.Substring(0, statusResponse.IndexOf(" ")).Trim());
		}
		else if (statusResponse.IndexOf("RECENT") > -1 && statusResponse.IndexOf("FLAGS") == -1)
		{
			m_NewMsgCount = Convert.ToInt32(statusResponse.Substring(0, statusResponse.IndexOf(" ")).Trim());
		}
	}

	private bool IsStatusResponse(string line)
	{
		if (!line.StartsWith("*"))
		{
			return false;
		}
		line = line.Substring(1).TrimStart();
		if (line.ToUpper().StartsWith("NO"))
		{
			return true;
		}
		if (line.ToUpper().StartsWith("BAD"))
		{
			return true;
		}
		if (line.ToLower().IndexOf("exists") > -1)
		{
			return true;
		}
		if (line.ToLower().IndexOf("recent") > -1 && line.ToLower().IndexOf("flags") == -1)
		{
			return true;
		}
		return false;
	}
}

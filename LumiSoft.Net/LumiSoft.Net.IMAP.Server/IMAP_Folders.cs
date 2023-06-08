using System.Collections;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Folders
{
	private IMAP_Session m_pSession = null;

	private ArrayList m_Mailboxes = null;

	private string m_RefName = "";

	private string m_Mailbox = "";

	public IMAP_Session Session => m_pSession;

	public IMAP_Folder[] Folders
	{
		get
		{
			IMAP_Folder[] array = new IMAP_Folder[m_Mailboxes.Count];
			m_Mailboxes.CopyTo(array);
			return array;
		}
	}

	public IMAP_Folders(IMAP_Session session, string referenceName, string folder)
	{
		m_pSession = session;
		m_Mailboxes = new ArrayList();
		m_RefName = referenceName;
		m_Mailbox = folder.Replace("\\", "/");
	}

	public void Add(string folder, bool selectable)
	{
		folder = folder.Replace("\\", "/");
		string folderPattern = m_RefName + m_Mailbox;
		if (m_RefName != "" && !m_RefName.EndsWith("/") && !m_Mailbox.StartsWith("/"))
		{
			folderPattern = m_RefName + "/" + m_Mailbox;
		}
		if (FolderMatches(folderPattern, Core.Decode_IMAP_UTF7_String(folder)))
		{
			m_Mailboxes.Add(new IMAP_Folder(folder, selectable));
		}
	}

	public bool AstericMatch(string pattern, string text)
	{
		pattern = pattern.ToLower();
		text = text.ToLower();
		if (pattern == "")
		{
			pattern = "*";
		}
		while (pattern.Length > 0)
		{
			if (pattern.StartsWith("*"))
			{
				if (pattern.IndexOf("*", 1) > -1)
				{
					string text2 = pattern.Substring(1, pattern.IndexOf("*", 1) - 1);
					if (text.IndexOf(text2) == -1)
					{
						return false;
					}
					text = text.Substring(text.IndexOf(text2) + text2.Length + 1);
					pattern = pattern.Substring(pattern.IndexOf("*", 1) + 1);
					continue;
				}
				return text.EndsWith(pattern.Substring(1));
			}
			if (pattern.IndexOfAny(new char[1] { '*' }) > -1)
			{
				string text3 = pattern.Substring(0, pattern.IndexOfAny(new char[1] { '*' }));
				if (!text.StartsWith(text3))
				{
					return false;
				}
				text = text.Substring(text.IndexOf(text3) + text3.Length);
				pattern = pattern.Substring(pattern.IndexOfAny(new char[1] { '*' }));
				continue;
			}
			return text == pattern;
		}
		return true;
	}

	private bool FolderMatches(string folderPattern, string folder)
	{
		folderPattern = folderPattern.ToLower();
		folder = folder.ToLower();
		string[] array = folder.Split('/');
		string[] array2 = folderPattern.Split('/');
		if (array.Length < array2.Length)
		{
			return false;
		}
		if (array.Length > array2.Length && !folderPattern.EndsWith("*"))
		{
			return false;
		}
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i].Replace("%", "*");
			if (text.IndexOf('*') > -1)
			{
				if (!AstericMatch(text, array[i]))
				{
					return false;
				}
			}
			else if (array[i] != text)
			{
				return false;
			}
		}
		return true;
	}
}

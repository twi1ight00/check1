using System;
using System.Collections;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Server;

internal class SearchGroup
{
	private ArrayList m_pSearchKeys = null;

	public SearchGroup()
	{
		m_pSearchKeys = new ArrayList();
	}

	public void Parse(StringReader reader)
	{
		reader.ReadToFirstChar();
		if (reader.StartsWith("("))
		{
			reader = new StringReader(reader.ReadParenthesized().Trim());
		}
		while (reader.Available > 0)
		{
			object obj = ParseSearchKey(reader);
			if (obj != null)
			{
				m_pSearchKeys.Add(obj);
			}
		}
	}

	public bool IsHeaderNeeded()
	{
		foreach (object pSearchKey in m_pSearchKeys)
		{
			if (IsHeaderNeededForKey(pSearchKey))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsBodyTextNeeded()
	{
		foreach (object pSearchKey in m_pSearchKeys)
		{
			if (IsBodyTextNeededForKey(pSearchKey))
			{
				return true;
			}
		}
		return false;
	}

	internal static object ParseSearchKey(StringReader reader)
	{
		reader.ReadToFirstChar();
		if (reader.StartsWith("("))
		{
			SearchGroup searchGroup = new SearchGroup();
			searchGroup.Parse(reader);
			return searchGroup;
		}
		return SearchKey.Parse(reader);
	}

	internal static bool Match_Key_Value(object searchKey, int no, int uid, int size, DateTime internalDate, IMAP_MessageFlags flags, LumiSoft.Net.Mime.Mime mime, string bodyText)
	{
		if (searchKey.GetType() == typeof(SearchKey))
		{
			if (!((SearchKey)searchKey).Match(no, uid, size, internalDate, flags, mime, bodyText))
			{
				return false;
			}
		}
		else if (searchKey.GetType() == typeof(SearchGroup) && !((SearchGroup)searchKey).Match(no, uid, size, internalDate, flags, mime, bodyText))
		{
			return false;
		}
		return true;
	}

	internal static bool IsHeaderNeededForKey(object searchKey)
	{
		if (searchKey.GetType() == typeof(SearchKey))
		{
			if (((SearchKey)searchKey).IsHeaderNeeded())
			{
				return true;
			}
		}
		else if (searchKey.GetType() == typeof(SearchGroup) && ((SearchGroup)searchKey).IsHeaderNeeded())
		{
			return true;
		}
		return false;
	}

	internal static bool IsBodyTextNeededForKey(object searchKey)
	{
		if (searchKey.GetType() == typeof(SearchKey))
		{
			if (((SearchKey)searchKey).IsBodyTextNeeded())
			{
				return true;
			}
		}
		else if (searchKey.GetType() == typeof(SearchGroup) && ((SearchGroup)searchKey).IsBodyTextNeeded())
		{
			return true;
		}
		return false;
	}

	public bool Match(int no, int uid, int size, DateTime internalDate, IMAP_MessageFlags flags, LumiSoft.Net.Mime.Mime mime, string bodyText)
	{
		foreach (object pSearchKey in m_pSearchKeys)
		{
			if (!Match_Key_Value(pSearchKey, no, uid, size, internalDate, flags, mime, bodyText))
			{
				return false;
			}
		}
		return true;
	}
}

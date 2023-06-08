using System;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_SearchMatcher
{
	private SearchGroup m_pSearchCriteria = null;

	public bool IsHeaderNeeded => m_pSearchCriteria.IsHeaderNeeded();

	public bool IsBodyTextNeeded => m_pSearchCriteria.IsBodyTextNeeded();

	internal IMAP_SearchMatcher(SearchGroup mainSearchGroup)
	{
		m_pSearchCriteria = mainSearchGroup;
	}

	public bool Matches(int no, int uid, int size, DateTime internalDate, IMAP_MessageFlags flags, string header, string bodyText)
	{
		LumiSoft.Net.Mime.Mime mime = null;
		if (m_pSearchCriteria.IsHeaderNeeded())
		{
			mime = new LumiSoft.Net.Mime.Mime();
			mime.MainEntity.Header.Parse(header);
		}
		return m_pSearchCriteria.Match(no, uid, size, internalDate, flags, mime, bodyText);
	}
}

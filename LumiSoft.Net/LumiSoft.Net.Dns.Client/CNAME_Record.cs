using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class CNAME_Record : DnsRecordBase
{
	private string m_Alias = "";

	public string Alias => m_Alias;

	public CNAME_Record(string alias, int ttl)
		: base(QTYPE.CNAME, ttl)
	{
		m_Alias = alias;
	}
}

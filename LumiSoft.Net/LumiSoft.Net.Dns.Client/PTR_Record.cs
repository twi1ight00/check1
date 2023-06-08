using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class PTR_Record : DnsRecordBase
{
	private string m_DomainName = "";

	public string DomainName => m_DomainName;

	public PTR_Record(string domainName, int ttl)
		: base(QTYPE.PTR, ttl)
	{
		m_DomainName = domainName;
	}
}

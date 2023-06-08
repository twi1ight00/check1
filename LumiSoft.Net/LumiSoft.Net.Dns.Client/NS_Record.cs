using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class NS_Record : DnsRecordBase
{
	private string m_NameServer = "";

	public string NameServer => m_NameServer;

	public NS_Record(string nameServer, int ttl)
		: base(QTYPE.NS, ttl)
	{
		m_NameServer = nameServer;
	}
}

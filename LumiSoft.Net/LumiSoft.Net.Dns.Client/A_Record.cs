using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class A_Record : DnsRecordBase
{
	private string m_IP = "";

	public string IP => m_IP;

	public A_Record(string IP, int ttl)
		: base(QTYPE.A, ttl)
	{
		m_IP = IP;
	}
}

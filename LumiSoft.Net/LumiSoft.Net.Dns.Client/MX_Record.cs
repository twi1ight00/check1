using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class MX_Record : DnsRecordBase
{
	private int m_Preference = 0;

	private string m_Host = "";

	public int Preference => m_Preference;

	public string Host => m_Host;

	public MX_Record(int preference, string host, int ttl)
		: base(QTYPE.MX, ttl)
	{
		m_Preference = preference;
		m_Host = host;
	}
}

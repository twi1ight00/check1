using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class SOA_Record : DnsRecordBase
{
	private string m_NameServer = "";

	private string m_AdminEmail = "";

	private long m_Serial = 0L;

	private long m_Refresh = 0L;

	private long m_Retry = 0L;

	private long m_Expire = 0L;

	private long m_Minimum = 0L;

	public string NameServer => m_NameServer;

	public string AdminEmail => m_AdminEmail;

	public long Serial => m_Serial;

	public long Refresh => m_Refresh;

	public long Retry => m_Retry;

	public long Expire => m_Expire;

	public long Minimum => m_Minimum;

	public SOA_Record(string nameServer, string adminEmail, long serial, long refresh, long retry, long expire, long minimum, int ttl)
		: base(QTYPE.SOA, ttl)
	{
		m_NameServer = nameServer;
		m_AdminEmail = adminEmail;
		m_Serial = serial;
		m_Refresh = refresh;
		m_Retry = retry;
		m_Expire = expire;
		m_Minimum = minimum;
	}
}

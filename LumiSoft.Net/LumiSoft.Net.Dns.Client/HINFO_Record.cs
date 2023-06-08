namespace LumiSoft.Net.Dns.Client;

public class HINFO_Record : DnsRecordBase
{
	private string m_CPU = "";

	private string m_OS = "";

	public string CPU => m_CPU;

	public string OS => m_OS;

	public HINFO_Record(string cpu, string os, int ttl)
		: base(QTYPE.HINFO, ttl)
	{
		m_CPU = cpu;
		m_OS = os;
	}
}

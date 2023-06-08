namespace LumiSoft.Net.Dns.Client;

public abstract class DnsRecordBase
{
	private QTYPE m_Type = QTYPE.A;

	private int m_TTL = -1;

	public QTYPE RecordType => m_Type;

	public int TTL => m_TTL;

	public DnsRecordBase(QTYPE recordType, int ttl)
	{
		m_Type = recordType;
		m_TTL = ttl;
	}
}

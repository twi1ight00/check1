using System;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class TXT_Record : DnsRecordBase
{
	private string m_Text = "";

	public string Text => m_Text;

	public TXT_Record(string text, int ttl)
		: base(QTYPE.TXT, ttl)
	{
		m_Text = text;
	}
}

namespace LumiSoft.Net.ICMP;

public class EchoMessage
{
	private string m_IP = "";

	private int m_TTL = 0;

	private int m_Time = 0;

	public EchoMessage(string ip, int ttl, int time)
	{
		m_IP = ip;
		m_TTL = ttl;
		m_Time = time;
	}

	public string ToStringEx()
	{
		return "TTL=" + m_TTL + "\tTime=" + m_Time + "ms\tIP=" + m_IP;
	}

	public static string ToStringEx(EchoMessage[] messages)
	{
		string text = "";
		foreach (EchoMessage echoMessage in messages)
		{
			text = text + echoMessage.ToStringEx() + "\r\n";
		}
		return text;
	}
}

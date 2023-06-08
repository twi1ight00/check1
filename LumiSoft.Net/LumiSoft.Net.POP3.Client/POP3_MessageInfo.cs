using System;

namespace LumiSoft.Net.POP3.Client;

public class POP3_MessageInfo
{
	private string m_MessageID = "";

	private int m_MessageNo = 0;

	private long m_MessageSize = 0L;

	[Obsolete("Use MessageUID instead !", true)]
	public string MessegeID => m_MessageID;

	[Obsolete("Use MessageNumber instead !", true)]
	public int MessageNr => m_MessageNo;

	public string MessageUID => m_MessageID;

	public int MessageNumber => m_MessageNo;

	public long MessageSize => m_MessageSize;

	public POP3_MessageInfo(string messageID, int messageNo, long messageSize)
	{
		m_MessageID = messageID;
		m_MessageNo = messageNo;
		m_MessageSize = messageSize;
	}
}

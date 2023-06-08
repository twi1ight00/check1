using System;

namespace LumiSoft.Net;

public class ReadException : Exception
{
	private ReadReplyCode m_ReadReplyCode;

	public ReadReplyCode ReadReplyCode => m_ReadReplyCode;

	public ReadException(ReadReplyCode code, string message)
		: base(message)
	{
		m_ReadReplyCode = code;
	}
}

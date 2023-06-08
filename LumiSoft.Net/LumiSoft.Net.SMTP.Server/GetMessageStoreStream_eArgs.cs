using System;
using System.IO;

namespace LumiSoft.Net.SMTP.Server;

public class GetMessageStoreStream_eArgs
{
	private SMTP_Session m_pSession = null;

	private Stream m_pStoreStream = null;

	public SMTP_Session Session => m_pSession;

	public Stream StoreStream
	{
		get
		{
			return m_pStoreStream;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Property StoreStream value can't be null !");
			}
			m_pStoreStream = value;
		}
	}

	public GetMessageStoreStream_eArgs(SMTP_Session session)
	{
		m_pSession = session;
		m_pStoreStream = new MemoryStream();
	}
}

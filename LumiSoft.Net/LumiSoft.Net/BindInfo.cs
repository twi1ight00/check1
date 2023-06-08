using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace LumiSoft.Net;

public class BindInfo
{
	private IPAddress m_pIP = null;

	private int m_Port = 0;

	private bool m_SSL = false;

	private X509Certificate m_pCertificate = null;

	private object m_Tag = null;

	public IPAddress IP => m_pIP;

	public int Port => m_Port;

	public bool SSL => m_SSL;

	public X509Certificate SSL_Certificate => m_pCertificate;

	public object Tag
	{
		get
		{
			return m_Tag;
		}
		set
		{
			m_Tag = value;
		}
	}

	public BindInfo(IPAddress ip, int port, bool ssl, X509Certificate sslCertificate)
	{
		m_pIP = ip;
		m_Port = port;
		m_SSL = ssl;
		m_pCertificate = sslCertificate;
	}
}

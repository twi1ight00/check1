using System.Net;

namespace LumiSoft.Net;

public class ValidateIP_EventArgs
{
	private IPEndPoint m_pLocalEndPoint = null;

	private IPEndPoint m_pRemoteEndPoint = null;

	private bool m_Validated = true;

	private object m_SessionTag = null;

	private string m_ErrorText = "";

	public string ConnectedIP => m_pRemoteEndPoint.Address.ToString();

	public IPEndPoint LocalEndPoint => m_pLocalEndPoint;

	public IPEndPoint RemoteEndPoint => m_pRemoteEndPoint;

	public bool Validated
	{
		get
		{
			return m_Validated;
		}
		set
		{
			m_Validated = value;
		}
	}

	public object SessionTag
	{
		get
		{
			return m_SessionTag;
		}
		set
		{
			m_SessionTag = value;
		}
	}

	public string ErrorText
	{
		get
		{
			return m_ErrorText;
		}
		set
		{
			m_ErrorText = value;
		}
	}

	public ValidateIP_EventArgs(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
	{
		m_pLocalEndPoint = localEndPoint;
		m_pRemoteEndPoint = remoteEndPoint;
	}
}

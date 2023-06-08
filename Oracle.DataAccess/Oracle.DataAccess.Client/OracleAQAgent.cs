using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleAQAgent
{
	internal string m_name;

	internal string m_address;

	public string Name => m_name;

	public string Address => m_address;

	static OracleAQAgent()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleAQAgent(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "name"));
		}
		m_name = name;
	}

	public OracleAQAgent(string name, string address)
	{
		if (address == null)
		{
			throw new ArgumentNullException("address");
		}
		if (address.Length == 0)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "address"));
		}
		m_name = name;
		m_address = address;
	}
}

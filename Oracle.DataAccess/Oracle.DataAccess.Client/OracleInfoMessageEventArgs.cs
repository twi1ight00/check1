using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleInfoMessageEventArgs : EventArgs
{
	private OracleErrorCollection m_oraErrors;

	private string m_message;

	private string m_source;

	public OracleErrorCollection Errors => m_oraErrors;

	public string Message => m_message;

	public string Source => m_source;

	static OracleInfoMessageEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleInfoMessageEventArgs(OracleErrorCollection oraErrors)
	{
		m_oraErrors = oraErrors;
		m_message = oraErrors[0].Message;
		m_source = oraErrors[0].Source;
	}

	public override string ToString()
	{
		return m_message;
	}
}

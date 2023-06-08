using System;

namespace Oracle.DataAccess.Client;

[Serializable]
public sealed class OracleError
{
	private string m_dataSource;

	private string m_procedure;

	private string m_message;

	private int m_number;

	private int m_status;

	private int m_arrayBindIndex;

	public string DataSource => m_dataSource;

	public string Message => m_message;

	public int Number => m_number;

	public string Procedure => m_procedure;

	public string Source => "Oracle Data Provider for .NET";

	public int ArrayBindIndex => m_arrayBindIndex;

	static OracleError()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleError(int errNumber, string dataSrc, string procedure, string errMsg)
	{
		m_number = errNumber;
		m_dataSource = dataSrc;
		m_procedure = procedure;
		if (errMsg == null || errMsg.Length == 0)
		{
			m_message = OpoErrResManager.GetErrorMesg(errNumber);
		}
		else
		{
			m_message = errMsg;
		}
	}

	internal OracleError(OpoErrCtx opoErrCtx, string procedure, string dataSrc)
	{
		m_dataSource = dataSrc;
		m_procedure = procedure;
		m_message = opoErrCtx.m_message;
		m_number = opoErrCtx.m_errNumber;
		m_status = opoErrCtx.m_status;
		m_arrayBindIndex = opoErrCtx.m_arrayBindIndex;
	}

	public override string ToString()
	{
		return m_message;
	}
}

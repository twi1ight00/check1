using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleNullValueException : OracleTypeException
{
	static OracleNullValueException()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleNullValueException()
	{
		m_number = ErrRes.TYP_NULLVALUE;
		m_mesg = OpoErrResManager.GetErrorMesg(ErrRes.TYP_NULLVALUE);
	}

	public OracleNullValueException(string message)
		: base(message)
	{
		m_number = 0;
		m_mesg = message;
	}
}

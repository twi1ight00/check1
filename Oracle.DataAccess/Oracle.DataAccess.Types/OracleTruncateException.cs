using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public sealed class OracleTruncateException : OracleTypeException
{
	internal static readonly string DefMesg;

	static OracleTruncateException()
	{
		DefMesg = GetDefMesg();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleTruncateException()
	{
		m_number = 16550;
		m_mesg = DefMesg;
	}

	public OracleTruncateException(string message)
		: base(message)
	{
		m_number = 0;
		m_mesg = message;
	}

	internal static string GetDefMesg()
	{
		string errMsg = "";
		int num = 0;
		try
		{
			num = OpsErr.GetOraMesg(16550, out errMsg);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		if (num == 0)
		{
			return errMsg;
		}
		return "";
	}
}

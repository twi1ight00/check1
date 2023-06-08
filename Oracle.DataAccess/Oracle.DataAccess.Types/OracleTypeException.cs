using System;
using System.Runtime.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public class OracleTypeException : SystemException
{
	protected string m_mesg;

	protected int m_number;

	public override string Message
	{
		get
		{
			if (m_mesg != null)
			{
				return m_mesg;
			}
			return base.Message;
		}
	}

	public int Number => m_number;

	public override string Source => "Oracle Data Provider for .NET";

	static OracleTypeException()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleTypeException(string message)
		: base(message)
	{
		m_mesg = message;
	}

	protected OracleTypeException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override string ToString()
	{
		return base.ToString();
	}

	internal OracleTypeException(int mesgNum, params object[] args)
		: base(GetTypeMsg(mesgNum, args))
	{
		m_number = mesgNum;
		m_mesg = GetTypeMsg(mesgNum, args);
	}

	internal OracleTypeException()
	{
	}

	internal static string GetTypeMsg(int errCode, params object[] args)
	{
		string typMsg = "";
		string text = "";
		int num = 0;
		if (errCode >= OracleException.CoreError)
		{
			if (errCode == 1727)
			{
				try
				{
					num = OpsErr.GetTypeMsg(errCode, out typMsg);
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
				if (num != 0)
				{
					text = OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR_CORE_MESG_GET);
				}
				text = typMsg;
			}
			else
			{
				try
				{
					num = OpsErr.GetTypeMsg(errCode, out typMsg);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				if (num != 0)
				{
					text = OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR_CORE_MESG_GET);
				}
				text = OracleException.AddOraMesgPrefix(errCode, typMsg);
			}
		}
		else
		{
			text = OpoErrResManager.GetErrorMesg(errCode);
		}
		if (args.Length > 0)
		{
			text = string.Format(text, args);
		}
		return text;
	}
}

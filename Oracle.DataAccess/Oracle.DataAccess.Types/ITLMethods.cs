using System;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class ITLMethods
{
	private ITLMethods()
	{
	}

	public unsafe static string ToString(OpoITLValCtx* pValCtx1, int leadPrec, int trailPrec)
	{
		int num = 0;
		IntPtr strCtx;
		try
		{
			num = OpsITL.ToString(pValCtx1, leadPrec, trailPrec, out strCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		string result = Marshal.PtrToStringUni(strCtx);
		Marshal.FreeCoTaskMem(strCtx);
		if (num != 0)
		{
			throw new OracleTypeException(num);
		}
		return result;
	}

	internal unsafe static int Compare(OpoITLValCtx* pITLValCtx1, OpoITLValCtx* pITLValCtx2)
	{
		int result = 0;
		try
		{
			OpsITL.Compare(pITLValCtx1, pITLValCtx2, ref result);
			return result;
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
	}

	internal unsafe static void FreeCtx(ref OpoITLValCtx* valCtx)
	{
		if (valCtx == null)
		{
			return;
		}
		try
		{
			OpsIDS.FreeValCtx(valCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		valCtx = null;
	}
}

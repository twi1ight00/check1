using System;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OpoIYMCtx : IDisposable
{
	internal unsafe OpoITLValCtx* m_pValCtx;

	internal int m_error;

	public unsafe OpoIYMCtx(int years, int months)
	{
		int num = 0;
		try
		{
			num = OpsIYM.AllocValCtxFromData(years, months, ref m_pValCtx);
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
		finally
		{
			if (num != 0)
			{
				ITLMethods.FreeCtx(ref m_pValCtx);
			}
		}
		m_error = num;
	}

	public unsafe OpoIYMCtx(double years)
	{
		int num = 0;
		try
		{
			num = OpsIYM.AllocValCtxFromYears(years, ref m_pValCtx);
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
		finally
		{
			if (num != 0)
			{
				ITLMethods.FreeCtx(ref m_pValCtx);
			}
		}
		m_error = num;
	}

	internal unsafe OpoIYMCtx(byte[] binData)
	{
		int num = 0;
		try
		{
			num = OpsIYM.AllocValCtxFromBytes(binData, out m_pValCtx, 9);
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
		finally
		{
			if (num != 0)
			{
				ITLMethods.FreeCtx(ref m_pValCtx);
			}
		}
		m_error = num;
	}

	public unsafe OpoIYMCtx(string data)
	{
		int num = 0;
		IntPtr intPtr = Marshal.StringToCoTaskMemUni(data);
		try
		{
			num = OpsIYM.AllocValCtxFromStr(intPtr, ref m_pValCtx);
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
		finally
		{
			if (num != 0)
			{
				ITLMethods.FreeCtx(ref m_pValCtx);
			}
		}
		Marshal.FreeCoTaskMem(intPtr);
		m_error = num;
	}

	internal unsafe OpoIYMCtx(OpoITLValCtx* ctx)
	{
		m_pValCtx = ctx;
	}

	~OpoIYMCtx()
	{
		Dispose();
	}

	public unsafe void Dispose()
	{
		ITLMethods.FreeCtx(ref m_pValCtx);
		try
		{
			GC.SuppressFinalize(this);
		}
		catch
		{
		}
	}
}

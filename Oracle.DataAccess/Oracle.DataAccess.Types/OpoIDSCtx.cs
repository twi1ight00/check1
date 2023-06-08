using System;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OpoIDSCtx : IDisposable
{
	internal unsafe OpoITLValCtx* m_pValCtx;

	internal int m_error;

	public unsafe OpoIDSCtx(int days, int hours, int minutes, int seconds, int fSeconds)
	{
		int num = 0;
		try
		{
			num = OpsIDS.AllocValCtxFromData(days, hours, minutes, seconds, fSeconds, ref m_pValCtx);
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

	public unsafe OpoIDSCtx(TimeSpan ts)
	{
		int num = 0;
		try
		{
			num = OpsIDS.AllocValCtx(ref m_pValCtx);
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
				m_error = num;
			}
		}
		if (num == 0)
		{
			OracleIntervalDS.FillValCtxFromTimeSpan(m_pValCtx, ts);
			m_error = num;
		}
	}

	public unsafe OpoIDSCtx(double days)
	{
		int num = 0;
		try
		{
			num = OpsIDS.AllocValCtxFromDays(days, ref m_pValCtx);
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

	public unsafe OpoIDSCtx(string data)
	{
		int num = 0;
		IntPtr intPtr = Marshal.StringToCoTaskMemUni(data);
		try
		{
			num = OpsIDS.AllocValCtxFromStr(intPtr, ref m_pValCtx);
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

	internal unsafe OpoIDSCtx(byte[] binData)
	{
		int num = 0;
		try
		{
			num = OpsIDS.AllocValCtxFromBytes(binData, out m_pValCtx, 9, 9);
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

	internal unsafe OpoIDSCtx(OpoITLValCtx* ctx)
	{
		m_pValCtx = ctx;
	}

	~OpoIDSCtx()
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

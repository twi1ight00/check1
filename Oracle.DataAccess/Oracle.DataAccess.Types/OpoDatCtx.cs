using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OpoDatCtx : IDisposable
{
	internal unsafe OpoDatValCtx* m_pValCtx;

	internal int m_error;

	public unsafe OpoDatCtx(int year, int month, int day, int hour, int minute, int second)
	{
		int num = 0;
		try
		{
			num = OpsDat.AllocValCtxFromData(year, month, day, hour, minute, second, out m_pValCtx);
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
			if (num != 0 && m_pValCtx != null)
			{
				try
				{
					OpsDat.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_pValCtx = null;
			}
		}
		m_error = num;
	}

	internal unsafe OpoDatCtx(byte[] binData)
	{
		int num = 0;
		try
		{
			num = OpsDat.AllocValCtxFromBytes(binData, out m_pValCtx);
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
			if (num != 0 && m_pValCtx != null)
			{
				try
				{
					OpsDat.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_pValCtx = null;
			}
		}
		m_error = num;
	}

	public unsafe OpoDatCtx(string datStr)
	{
		int num = 0;
		try
		{
			num = OpsDat.AllocValCtxFromStr(datStr, out m_pValCtx);
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
			if (num != 0 && m_pValCtx != null)
			{
				try
				{
					OpsDat.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_pValCtx = null;
			}
		}
		m_error = num;
	}

	internal unsafe OpoDatCtx(OpoDatValCtx* pCtx)
	{
		m_pValCtx = pCtx;
	}

	~OpoDatCtx()
	{
		Dispose();
	}

	public unsafe void Dispose()
	{
		if (m_pValCtx != null)
		{
			try
			{
				OpsDat.FreeValCtx(m_pValCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			m_pValCtx = null;
		}
		try
		{
			GC.SuppressFinalize(this);
		}
		catch
		{
		}
	}
}

using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OpoTSCtx : IDisposable
{
	internal unsafe OpoTSValCtx* m_pValCtx;

	internal int m_error;

	public unsafe OpoTSCtx(int year, int month, int day, int hour, int minute, int second, int fSecond, int tzHours, int tzMinutes, TimeStampType tsType)
	{
		int num = 0;
		try
		{
			switch (tsType)
			{
			case TimeStampType.TSType_TS:
				try
				{
					num = OpsTS.AllocValCtxFromData(year, month, day, hour, minute, second, fSecond, out m_pValCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				break;
			case TimeStampType.TSType_TSL:
				try
				{
					num = OpsTSL.AllocValCtxFromData(year, month, day, hour, minute, second, fSecond, tzHours, tzMinutes, out m_pValCtx);
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
				break;
			default:
				try
				{
					num = OpsTSZ.AllocValCtxFromData(year, month, day, hour, minute, second, fSecond, tzHours, tzMinutes, null, out m_pValCtx);
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
				break;
			}
		}
		finally
		{
			if (num != 0 && m_pValCtx != null)
			{
				try
				{
					OpsTS.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
				m_pValCtx = null;
			}
		}
		m_error = num;
	}

	public unsafe OpoTSCtx(int year, int month, int day, int hour, int minute, int second, int fSecond, string regionName)
	{
		int num = 0;
		try
		{
			num = OpsTSZ.AllocValCtxFromData(year, month, day, hour, minute, second, fSecond, 0, 0, regionName, out m_pValCtx);
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
				try
				{
					OpsTS.FreeValCtx(m_pValCtx);
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

	public OpoTSCtx(int year, int month, int day, int hour, int minute, int second, double milliSecond, int tzHours, int tzMinutes, TimeStampType tsType)
		: this(year, month, day, hour, minute, second, (int)(milliSecond * 1000000.0), tzHours, tzMinutes, tsType)
	{
	}

	internal unsafe OpoTSCtx(byte[] binData, TimeStampType tsType)
	{
		int num = 0;
		try
		{
			num = tsType switch
			{
				TimeStampType.TSType_TS => OpsTS.AllocValCtxFromBytes(binData, out m_pValCtx, 9), 
				TimeStampType.TSType_TSL => OpsTSL.AllocValCtxFromBytes(binData, out m_pValCtx, 9), 
				TimeStampType.TSType_TSZ => OpsTSZ.AllocValCtxFromBytes(binData, out m_pValCtx, 9), 
				_ => OpsTSZ.AllocValCtxFromBytes(binData, out m_pValCtx, 9), 
			};
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
					OpsTS.FreeValCtx(m_pValCtx);
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

	public unsafe OpoTSCtx(DateTime dt, int tzHours, int tzMinutes, TimeStampType tsType)
	{
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		TimeStamp.FillValCtxFromDateTime(&opoTSValCtx, dt);
		int num = 0;
		try
		{
			switch (tsType)
			{
			case TimeStampType.TSType_TS:
				try
				{
					num = OpsTS.AllocValCtxFromData(opoTSValCtx.m_year, opoTSValCtx.m_month, opoTSValCtx.m_day, opoTSValCtx.m_hour, opoTSValCtx.m_minute, opoTSValCtx.m_second, opoTSValCtx.m_fSecond, out m_pValCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				break;
			case TimeStampType.TSType_TSL:
				try
				{
					num = OpsTSL.AllocValCtxFromData(opoTSValCtx.m_year, opoTSValCtx.m_month, opoTSValCtx.m_day, opoTSValCtx.m_hour, opoTSValCtx.m_minute, opoTSValCtx.m_second, opoTSValCtx.m_fSecond, TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, out m_pValCtx);
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
				break;
			default:
				try
				{
					num = OpsTSZ.AllocValCtxFromData(opoTSValCtx.m_year, opoTSValCtx.m_month, opoTSValCtx.m_day, opoTSValCtx.m_hour, opoTSValCtx.m_minute, opoTSValCtx.m_second, opoTSValCtx.m_fSecond, tzHours, tzMinutes, null, out m_pValCtx);
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
				break;
			}
		}
		finally
		{
			if (num != 0 && m_pValCtx != null)
			{
				try
				{
					OpsTS.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
				m_pValCtx = null;
			}
		}
		m_error = num;
	}

	public unsafe OpoTSCtx(DateTime dt, string regionName)
	{
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		TimeStamp.FillValCtxFromDateTime(&opoTSValCtx, dt);
		int num = 0;
		try
		{
			num = OpsTSZ.AllocValCtxFromData(opoTSValCtx.m_year, opoTSValCtx.m_month, opoTSValCtx.m_day, opoTSValCtx.m_hour, opoTSValCtx.m_minute, opoTSValCtx.m_second, opoTSValCtx.m_fSecond, 0, 0, regionName, out m_pValCtx);
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
					OpsTS.FreeValCtx(m_pValCtx);
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

	public unsafe OpoTSCtx(string tsStr, TimeStampType tsType)
	{
		int num = 0;
		try
		{
			switch (tsType)
			{
			case TimeStampType.TSType_TS:
				try
				{
					num = OpsTS.AllocValCtxFromStr(tsStr, out m_pValCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				break;
			case TimeStampType.TSType_TSL:
			{
				OracleIntervalDS oracleIntervalDS2 = new OracleIntervalDS(0, TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, 0, 0);
				try
				{
					num = OpsTSL.AllocValCtxFromStr(tsStr, oracleIntervalDS2.GetValCtx(), out m_pValCtx);
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
				break;
			}
			default:
			{
				OracleIntervalDS oracleIntervalDS = new OracleIntervalDS(0, TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, 0, 0);
				try
				{
					num = OpsTSZ.AllocValCtxFromStr(tsStr, oracleIntervalDS.GetValCtx(), out m_pValCtx);
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
				break;
			}
			}
		}
		finally
		{
			if (num != 0 && m_pValCtx != null)
			{
				try
				{
					OpsTS.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
				m_pValCtx = null;
			}
		}
		m_error = num;
	}

	internal unsafe OpoTSCtx(TimeStampType tsType)
	{
		int num = 0;
		if ((num = AllocValCtx(ref m_pValCtx, tsType)) != 0)
		{
			m_pValCtx = null;
		}
		m_error = num;
	}

	internal unsafe OpoTSCtx(OpoTSValCtx* pCtx)
	{
		m_pValCtx = pCtx;
	}

	~OpoTSCtx()
	{
		Dispose();
	}

	public unsafe void Dispose()
	{
		if (m_pValCtx != null)
		{
			switch (m_pValCtx->m_type)
			{
			case 3:
				try
				{
					OpsTS.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
				break;
			case 7:
				try
				{
					OpsTSL.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				break;
			case 5:
				try
				{
					OpsTSZ.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				break;
			default:
				try
				{
					OpsTSZ.FreeValCtx(m_pValCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				break;
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

	internal unsafe static int AllocValCtx(ref OpoTSValCtx* pValCtx, TimeStampType tsType)
	{
		int num = 0;
		try
		{
			return tsType switch
			{
				TimeStampType.TSType_TS => OpsTS.AllocValCtx(ref pValCtx), 
				TimeStampType.TSType_TSL => OpsTSL.AllocValCtx(ref pValCtx), 
				TimeStampType.TSType_TSZ => OpsTSZ.AllocValCtx(ref pValCtx), 
				_ => OpsTSZ.AllocValCtx(ref pValCtx), 
			};
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
}

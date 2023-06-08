using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class TimeSpanConv
{
	internal const int FSecondsPerMilliSecond = 1000000;

	internal const int FSecondsPerTick = 100;

	internal const double TicksPerFSecond = 0.01;

	private TimeSpanConv()
	{
	}

	internal unsafe static decimal ValCtxToTicks(OpoITLValCtx* pValCtx)
	{
		return (decimal)pValCtx->m_ds.m_days * 864000000000m + (decimal)(pValCtx->m_ds.m_hours * 36000000000L) + (decimal)((long)pValCtx->m_ds.m_minutes * 600000000L) + (decimal)((long)pValCtx->m_ds.m_seconds * 10000000L) + (decimal)pValCtx->m_ds.m_fSeconds * 0.01m;
	}

	public unsafe static TimeSpan GetTimeSpan(OpoITLValCtx* pValCtx, OracleDbType oraType)
	{
		if (oraType != OracleDbType.IntervalDS)
		{
			throw new OracleTypeException(ErrRes.INT_ERR);
		}
		if (Math.Abs(pValCtx->m_ds.m_fSeconds) % 100 > 0)
		{
			throw new OracleTypeException(ErrRes.TYP_GETDOTNETTYPE_FAIL);
		}
		decimal num = ValCtxToTicks(pValCtx);
		if (num < -9223372036854775808m || num > 9223372036854775807m)
		{
			throw new OracleTypeException(ErrRes.TYP_GETDOTNETTYPE_FAIL);
		}
		return new TimeSpan((long)num);
	}
}

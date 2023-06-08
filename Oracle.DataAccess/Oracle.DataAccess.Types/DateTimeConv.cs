using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class DateTimeConv
{
	private DateTimeConv()
	{
	}

	public unsafe static DateTime GetDateTime(OpoDatValCtx* pValCtx, OracleDbType oraType, bool bCheck)
	{
		if (oraType != OracleDbType.Date)
		{
			throw new OracleTypeException(ErrRes.INT_ERR);
		}
		return new DateTime(pValCtx->m_year, pValCtx->m_month, pValCtx->m_day, pValCtx->m_hour, pValCtx->m_minute, pValCtx->m_second);
	}

	public unsafe static DateTime GetDateTime(byte* pDate)
	{
		int year = (*pDate - 100) * 100 + pDate[1] - 100;
		int month = pDate[2];
		int day = pDate[3];
		int hour = pDate[4] - 1;
		int minute = pDate[5] - 1;
		int second = pDate[6] - 1;
		return new DateTime(year, month, day, hour, minute, second);
	}

	public unsafe static DateTime GetDateTime(OpoTSValCtx* pValCtx, OracleDbType oraType, bool bCheck)
	{
		if (oraType == OracleDbType.TimeStamp || oraType == OracleDbType.TimeStampLTZ || oraType == OracleDbType.TimeStampTZ)
		{
			if (oraType == OracleDbType.TimeStampTZ)
			{
				int num = 0;
				OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
				try
				{
					num = OpsTSZ.ConvertToTSL(pValCtx, &opoTSValCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (num != 0)
				{
					throw new OracleTypeException(num);
				}
				pValCtx = &opoTSValCtx;
			}
			DateTime result = new DateTime(pValCtx->m_year, pValCtx->m_month, pValCtx->m_day, pValCtx->m_hour, pValCtx->m_minute, pValCtx->m_second);
			if (pValCtx->m_fSecond > 0)
			{
				return result.AddTicks(pValCtx->m_fSecond / 100);
			}
			return result;
		}
		throw new OracleTypeException(ErrRes.INT_ERR);
	}

	public unsafe static DateTimeOffset GetDateTimeOffset(OpoTSValCtx* pValCtx, OracleDbType oraType, bool bCheck)
	{
		if (oraType == OracleDbType.TimeStamp || oraType == OracleDbType.TimeStampLTZ || oraType == OracleDbType.TimeStampTZ)
		{
			if (oraType == OracleDbType.TimeStampTZ)
			{
				int num = 0;
				OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
				try
				{
					num = OpsTSZ.ConvertToTSL(pValCtx, &opoTSValCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (num != 0)
				{
					throw new OracleTypeException(num);
				}
				pValCtx = &opoTSValCtx;
			}
			return new DateTimeOffset(pValCtx->m_year, pValCtx->m_month, pValCtx->m_day, pValCtx->m_hour, pValCtx->m_minute, pValCtx->m_second, new TimeSpan(pValCtx->m_tzHour, pValCtx->m_tzMinute, 0));
		}
		throw new OracleTypeException(ErrRes.INT_ERR);
	}

	internal unsafe static void ToBytes(DateTime data, byte* bytes)
	{
		*bytes = (byte)(data.Year / 100 + 100);
		bytes[1] = (byte)(data.Year % 100 + 100);
		bytes[2] = (byte)data.Month;
		bytes[3] = (byte)data.Day;
		bytes[4] = (byte)(data.Hour + 1);
		bytes[5] = (byte)(data.Minute + 1);
		bytes[6] = (byte)(data.Second + 1);
	}

	internal unsafe static OpoTSValCtx* AllocTSValCtx(DateTime data)
	{
		OpoTSValCtx* ctx = null;
		try
		{
			OpsTS.AllocValCtx(ref ctx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		TimeStamp.FillValCtxFromDateTime(ctx, data);
		return ctx;
	}

	internal unsafe static OpoTSValCtx* AllocTSLValCtx(DateTime data)
	{
		OpoTSValCtx* ctx = null;
		try
		{
			OpsTSL.AllocValCtx(ref ctx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		TimeStamp.FillValCtxFromDateTime(ctx, data);
		ctx->m_tzHour = (sbyte)TimeStamp.LocalTZOffset.m_tzHours;
		ctx->m_tzMinute = (sbyte)TimeStamp.LocalTZOffset.m_tzMinutes;
		return ctx;
	}

	internal unsafe static OpoTSValCtx* AllocTSZValCtx(DateTime data)
	{
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		TimeStamp.FillValCtxFromDateTime(&opoTSValCtx, data);
		try
		{
			OpsTSZ.AllocValCtxFromData(opoTSValCtx.m_year, opoTSValCtx.m_month, opoTSValCtx.m_day, opoTSValCtx.m_hour, opoTSValCtx.m_minute, opoTSValCtx.m_second, opoTSValCtx.m_fSecond, 0, 0, null, out var pValCtx);
			return pValCtx;
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

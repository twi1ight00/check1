using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class TimeStamp
{
	internal const short MaxYear = 9999;

	internal const byte MaxMonth = 12;

	internal const byte MaxDay = 31;

	internal const byte MaxHour = 23;

	internal const byte MaxMinute = 59;

	internal const byte MaxSecond = 59;

	internal const double MaxMillisecond = 999.999999;

	internal const int MaxFSecond = 999999999;

	internal const int MaxTZHours = 14;

	internal const int MaxTZMinutes = 59;

	internal const short MinYear = -4712;

	internal const byte MinMonth = 1;

	internal const byte MinDay = 1;

	internal const byte MinHour = 0;

	internal const byte MinMinute = 0;

	internal const byte MinSecond = 0;

	internal const double MinMillisecond = 0.0;

	internal const byte MinFSecond = 0;

	internal const int MinTZHours = -12;

	internal const int MinTZMinutes = -59;

	internal const byte MaxFSecondPrec = 9;

	internal const byte MinFSecondPrec = 0;

	internal const byte YEAR = 0;

	internal const byte MONTH = 1;

	internal const byte DAY = 2;

	internal const byte HOUR = 3;

	internal const byte MINUTE = 4;

	internal const byte SECOND = 5;

	internal const byte MILLISECOND = 6;

	internal const byte FSECOND = 7;

	internal const byte TZHOURS = 8;

	internal const byte TZMINUTES = 9;

	internal static readonly TZInfo LocalTZOffset = GetLocalTZOffset();

	internal static readonly string LocalTZName = GetLocalTZName();

	private TimeStamp()
	{
	}

	internal unsafe static int Compare(OpoTSCtx TSCtx1, OpoTSCtx TSCtx2)
	{
		int result = 0;
		int num = 0;
		try
		{
			num = OpsTSA.Compare(TSCtx1.m_pValCtx, TSCtx2.m_pValCtx, ref result);
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
		return result;
	}

	internal unsafe static void FillValCtxFromDateTime(OpoTSValCtx* pValCtx, DateTime dt)
	{
		int year = dt.Year;
		int month = dt.Month;
		int day = dt.Day;
		int hour = dt.Hour;
		int minute = dt.Minute;
		int second = dt.Second;
		DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
		long num = dt.Ticks - dateTime.Ticks;
		pValCtx->m_year = (short)year;
		pValCtx->m_month = (byte)month;
		pValCtx->m_day = (byte)day;
		pValCtx->m_hour = (byte)hour;
		pValCtx->m_minute = (byte)minute;
		pValCtx->m_second = (byte)second;
		pValCtx->m_fSecond = (int)(num * 100);
	}

	internal unsafe static int GetTSData(OpoTSValCtx* pValCtx, byte tsComponent)
	{
		int result = 0;
		switch (tsComponent)
		{
		case 0:
			result = pValCtx->m_year;
			break;
		case 1:
			result = pValCtx->m_month;
			break;
		case 2:
			result = pValCtx->m_day;
			break;
		case 3:
			result = pValCtx->m_hour;
			break;
		case 4:
			result = pValCtx->m_minute;
			break;
		case 5:
			result = pValCtx->m_second;
			break;
		case 6:
			result = pValCtx->m_fSecond / 1000000;
			break;
		case 7:
			result = pValCtx->m_fSecond;
			break;
		case 8:
			result = pValCtx->m_tzHour;
			break;
		case 9:
			result = pValCtx->m_tzMinute;
			break;
		}
		return result;
	}

	internal unsafe static OracleTimeStampTZ ToUniversalTime(OpoTSCtx ctx1)
	{
		int num = 0;
		OpoTSValCtx* pCtx;
		try
		{
			num = OpsTSA.AllocValCtxForToUTC(ctx1.m_pValCtx, out pCtx);
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
		OpoTSCtx ctx2 = new OpoTSCtx(pCtx);
		return new OracleTimeStampTZ(ctx2);
	}

	internal static bool IsValidDateTime(int year, int month, int day, int hour, int minute, int second, int nanosecond)
	{
		if (year < -4712 || year > 9999)
		{
			return false;
		}
		if (month < 1 || month > 12)
		{
			return false;
		}
		if (day < 1 || day > 31)
		{
			return false;
		}
		if (hour < 0 || hour > 23)
		{
			return false;
		}
		if (minute < 0 || minute > 59)
		{
			return false;
		}
		if (second < 0 || second > 59)
		{
			return false;
		}
		if (nanosecond < 0 || nanosecond > 999999999)
		{
			return false;
		}
		return true;
	}

	internal unsafe static string ToTSString(OpoTSCtx ctx, int fSecondPrec, TimeStampType tsType)
	{
		int num = 0;
		string tsStr;
		switch (tsType)
		{
		case TimeStampType.TSType_TS:
			try
			{
				num = OpsTS.ToString(ctx.m_pValCtx, fSecondPrec, out tsStr);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			break;
		case TimeStampType.TSType_TSL:
		{
			OracleIntervalDS oracleIntervalDS = new OracleIntervalDS(0, LocalTZOffset.m_tzHours, LocalTZOffset.m_tzMinutes, 0, 0);
			try
			{
				num = OpsTSL.ToString(ctx.m_pValCtx, oracleIntervalDS.GetValCtx(), fSecondPrec, out tsStr);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			break;
		}
		default:
			try
			{
				num = OpsTSZ.ToString(ctx.m_pValCtx, fSecondPrec, out tsStr);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			break;
		}
		if (num != 0)
		{
			throw new OracleTypeException(num);
		}
		return tsStr;
	}

	internal unsafe static TZInfo GetLocalTZOffset()
	{
		int num = 0;
		int tzHours = default(int);
		int tzMinutes = default(int);
		try
		{
			num = OpsTSA.GetTimeZoneOffset(&tzHours, &tzMinutes);
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
		return new TZInfo(tzHours, tzMinutes);
	}

	internal static string GetLocalTZName()
	{
		int num = 0;
		string tzStr;
		try
		{
			num = OpsTSA.GetSysTZName(out tzStr);
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
		return tzStr;
	}
}

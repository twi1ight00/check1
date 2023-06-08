using System;

namespace Oracle.DataAccess.Types;

internal class Interval
{
	internal const int MaxYears = 999999999;

	internal const int TotalMaxYears = 1000000000;

	internal const byte MaxMonths = 11;

	internal const long TotalMaxMonths = 12000000000L;

	internal const int MaxDays = 999999999;

	internal const double TotalMaxDays = 1000000000.0;

	internal const byte MaxHours = 23;

	internal const double TotalMaxHours = 24000000000.0;

	internal const byte MaxMinutes = 59;

	internal const double TotalMaxMinutes = 1440000000000.0;

	internal const byte MaxSeconds = 59;

	internal const double TotalMaxSeconds = 86400000000000.0;

	internal const double MaxMilliseconds = 999.999999;

	internal const double TotalMaxMilliseconds = 86400000000000000.0;

	internal const int MaxFSeconds = 999999999;

	internal const int MinYears = -999999999;

	internal const int TotalMinYears = -1000000000;

	internal const short MinMonths = -11;

	internal const long TotalMinMonths = -12000000000L;

	internal const int MinDays = -999999999;

	internal const double TotalMinDays = -1000000000.0;

	internal const short MinHours = -23;

	internal const double TotalMinHours = -24000000000.0;

	internal const short MinMinutes = -59;

	internal const double TotalMinMinutes = -1440000000000.0;

	internal const short MinSeconds = -59;

	internal const double TotalMinSeconds = -86400000000000.0;

	internal const double MinMilliseconds = -999.999999;

	internal const double TotalMinMilliseconds = -86400000000000000.0;

	internal const int MinFSeconds = -999999999;

	internal const byte MonthsPerYear = 12;

	internal const byte MaxYearPrec = 9;

	internal const byte MaxDayPrec = 9;

	internal const byte MaxFSecondPrec = 9;

	internal const byte MinYearPrec = 0;

	internal const byte MinDayPrec = 0;

	internal const byte MinFSecondPrec = 0;

	private Interval()
	{
	}

	internal static bool IsValidYears(int years)
	{
		if (years < -999999999 || years > 999999999)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidMonths(int months)
	{
		if (months < -11 || months > 11)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidYMMonths(long ymMonths)
	{
		long num = 11999999999L;
		long num2 = -((long)Math.Abs(-999999999) * 12L + Math.Abs((short)(-11)));
		if (ymMonths < num2 || ymMonths > num)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidYMYears(double years)
	{
		if (years <= -1000000000.0 || years >= 1000000000.0)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidYM(int years, int months)
	{
		if (!IsValidYears(years))
		{
			return false;
		}
		if (!IsValidMonths(months))
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidDays(int days)
	{
		if (days < -999999999 || days > 999999999)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidHours(int hours)
	{
		if (hours < -23 || hours > 23)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidMinutes(int minutes)
	{
		if (minutes < -59 || minutes > 59)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidSeconds(int seconds)
	{
		if (seconds < -59 || seconds > 59)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidNanoseconds(int nanoseconds)
	{
		if (nanoseconds < -999999999 || nanoseconds > 999999999)
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidDS(int days, int hours, int minutes, int seconds, int nanoseconds)
	{
		if (!IsValidDays(days))
		{
			return false;
		}
		if (!IsValidHours(hours))
		{
			return false;
		}
		if (!IsValidMinutes(minutes))
		{
			return false;
		}
		if (!IsValidSeconds(seconds))
		{
			return false;
		}
		if (!IsValidNanoseconds(nanoseconds))
		{
			return false;
		}
		return true;
	}

	internal static bool IsValidDSDays(double days)
	{
		if (days <= -1000000000.0 || days >= 1000000000.0)
		{
			return false;
		}
		return true;
	}
}

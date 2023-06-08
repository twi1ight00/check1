using System;

namespace cn.jpush.api.common;

public class ServiceHelper
{
	private const int MAX_BADGE_NUMBER = 99999;

	private const int MIN = 100000;

	private const int MAX = int.MaxValue;

	public static int generateSendno()
	{
		return new Random().Next(2147383648) + 100000;
	}

	public static bool isValidIntBadge(int intBadge)
	{
		if (intBadge < 0 || intBadge > 99999)
		{
			return false;
		}
		return true;
	}
}

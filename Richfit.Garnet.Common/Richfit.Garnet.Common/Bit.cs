using System;

namespace Richfit.Garnet.Common;

public class Bit
{
	public static long pro(long value, string option)
	{
		if (string.IsNullOrEmpty(option))
		{
			return 0L;
		}
		string[] op = option.Split('|');
		return (value >> int.Parse(op[0])) & (long)(Math.Pow(2.0, int.Parse(op[1])) - 1.0);
	}
}

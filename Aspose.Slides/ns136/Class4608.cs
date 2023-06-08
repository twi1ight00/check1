namespace ns136;

internal class Class4608
{
	public static bool smethod_0(double arg1, double arg2, double precision)
	{
		if (arg1 != arg2 && (!(arg1 < arg2) || !(arg1 > arg2 - precision)))
		{
			if (arg1 > arg2)
			{
				return arg1 < arg2 + precision;
			}
			return false;
		}
		return true;
	}
}

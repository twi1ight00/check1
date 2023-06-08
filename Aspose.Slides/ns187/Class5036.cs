using ns176;

namespace ns187;

internal class Class5036 : Class5034
{
	public const string string_1 = "pc";

	public const string string_2 = "pt";

	public const string string_3 = "mm";

	public const string string_4 = "cm";

	public const string string_5 = "in";

	public const string string_6 = "mpt";

	private static Class5749 class5749_0 = new Class5749();

	public static Class5036 class5036_0 = new Class5036(0.0, "mpt", 1f);

	private int int_0;

	private Class5036(double numUnits, string units, float res)
	{
		int_0 = smethod_3(numUnits, units, res);
	}

	public static Class5036 smethod_0(double numUnits, string units, float sourceResolution)
	{
		if (numUnits == 0.0)
		{
			return class5036_0;
		}
		return (Class5036)class5749_0.method_0(new Class5036(numUnits, units, sourceResolution));
	}

	public static Class5036 smethod_1(double numUnits, string units)
	{
		return smethod_0(numUnits, units, 1f);
	}

	public static Class5036 smethod_2(double numUnits)
	{
		return smethod_0(numUnits, "mpt", 1f);
	}

	private static int smethod_3(double dvalue, string unit, float res)
	{
		if ("px".Equals(unit))
		{
			dvalue *= (double)(res * 1000f);
		}
		else if ("in".Equals(unit))
		{
			dvalue *= 72000.0;
		}
		else if ("cm".Equals(unit))
		{
			dvalue *= 28346.4567;
		}
		else if ("mm".Equals(unit))
		{
			dvalue *= 2834.64567;
		}
		else if ("pt".Equals(unit))
		{
			dvalue *= 1000.0;
		}
		else if ("pc".Equals(unit))
		{
			dvalue *= 12000.0;
		}
		else if (!"mpt".Equals(unit))
		{
			dvalue = 0.0;
		}
		return (int)dvalue;
	}

	public override int imethod_5()
	{
		return int_0;
	}

	public override int imethod_6(Interface172 context)
	{
		return int_0;
	}

	public override double imethod_1()
	{
		return int_0;
	}

	public override double imethod_2(Interface172 context)
	{
		return int_0;
	}

	public override bool imethod_4()
	{
		return true;
	}

	public override string ToString()
	{
		return int_0 + "mpt";
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is Class5036 @class)
		{
			return @class.int_0 == int_0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return int_0;
	}
}

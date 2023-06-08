using ns305;

namespace ns81;

internal class Class4037 : Class4029
{
	public Class4037()
		: base("out-of-range")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!Class4029.smethod_0(e))
		{
			return false;
		}
		if (!Class4029.smethod_1(e, "type", "number"))
		{
			return false;
		}
		if (!e.method_34("value"))
		{
			return false;
		}
		string s = e.method_20("value");
		if (!int.TryParse(s, out var result))
		{
			return false;
		}
		int result2;
		if (e.method_34("min"))
		{
			s = e.method_20("min");
			if (!int.TryParse(s, out result2))
			{
				result2 = int.MinValue;
			}
		}
		else
		{
			result2 = int.MinValue;
		}
		int result3;
		if (e.method_34("max"))
		{
			s = e.method_20("max");
			if (!int.TryParse(s, out result3))
			{
				result3 = int.MaxValue;
			}
		}
		else
		{
			result3 = int.MaxValue;
		}
		if (result >= result2)
		{
			return result3 < result;
		}
		return true;
	}
}

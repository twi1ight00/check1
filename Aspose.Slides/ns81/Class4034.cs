using ns305;

namespace ns81;

internal class Class4034 : Class4029
{
	public Class4034()
		: base("in-range")
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
			return true;
		}
		string s = e.method_20("value");
		if (!int.TryParse(s, out var result))
		{
			return true;
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
		if (result2 <= result)
		{
			return result <= result3;
		}
		return false;
	}
}

using ns305;

namespace ns81;

internal class Class4033 : Class4029
{
	public Class4033()
		: base("indeterminate")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!Class4029.smethod_0(e))
		{
			return false;
		}
		if (!e.method_34("indeterminate"))
		{
			return false;
		}
		string text = e.method_20("indeterminate").ToLowerInvariant();
		if (!text.Equals("true"))
		{
			return text.Equals("1");
		}
		return true;
	}
}

using ns305;

namespace ns81;

internal class Class4036 : Class4029
{
	public Class4036()
		: base("optional")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!Class4029.smethod_0(e))
		{
			return false;
		}
		return !e.method_34("required");
	}
}

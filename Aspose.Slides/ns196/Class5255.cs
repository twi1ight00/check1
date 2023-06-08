using System.Text;

namespace ns196;

internal class Class5255 : Class5254
{
	private Class5254 class5254_0;

	public Class5255(Interface173 lm, Class5254 sub)
		: base(lm)
	{
		class5254_0 = sub;
	}

	public override Class5254 vmethod_0()
	{
		return class5254_0;
	}

	public override bool vmethod_1()
	{
		if (class5254_0 == null)
		{
			return false;
		}
		return class5254_0.vmethod_1();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("NonLeafPos:").Append(method_4()).Append("(");
		stringBuilder.Append(method_5());
		stringBuilder.Append(", ");
		if (vmethod_0() != null)
		{
			stringBuilder.Append(vmethod_0().ToString());
		}
		else
		{
			stringBuilder.Append("null");
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}

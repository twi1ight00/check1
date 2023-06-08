using System.Text;
using ns205;

namespace ns196;

internal class Class5344 : Class5337
{
	private int int_2;

	private int int_3;

	private Class5682 class5682_0;

	public Class5344(Class5746 minOptMax, Class5254 pos, bool auxiliary)
		: base(minOptMax.method_2(), pos, auxiliary)
	{
		int_2 = minOptMax.method_5();
		int_3 = minOptMax.method_4();
		class5682_0 = Class5682.class5682_0;
	}

	public Class5344(int width, int stretch, int shrink, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
		int_2 = stretch;
		int_3 = shrink;
		class5682_0 = Class5682.class5682_0;
	}

	public Class5344(int width, int stretch, int shrink, Class5682 adjustmentClass, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
		int_2 = stretch;
		int_3 = shrink;
		class5682_0 = adjustmentClass;
	}

	public override bool vmethod_1()
	{
		return true;
	}

	public override int vmethod_6()
	{
		return int_2;
	}

	public override int vmethod_7()
	{
		return int_3;
	}

	public Class5682 method_6()
	{
		return class5682_0;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		if (method_3())
		{
			stringBuilder.Append("aux. ");
		}
		stringBuilder.Append("glue");
		stringBuilder.Append(" w=").Append(method_4());
		stringBuilder.Append(" stretch=").Append(vmethod_6());
		stringBuilder.Append(" shrink=").Append(vmethod_7());
		if (!method_6().Equals(Class5682.class5682_0))
		{
			stringBuilder.Append(" adj-class=").Append(method_6());
		}
		return stringBuilder.ToString();
	}
}

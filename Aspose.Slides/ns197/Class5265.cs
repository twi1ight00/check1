using System.Collections;
using System.Text;
using ns192;
using ns196;

namespace ns197;

internal class Class5265 : Class5254
{
	public static int int_1 = 1;

	public static int int_2 = 2;

	internal ArrayList arrayList_0;

	private Class5645 class5645_0;

	protected int int_3;

	private Class5645 class5645_1;

	internal Class5265(Interface173 lm, ArrayList cellParts, Class5645 row)
		: base(lm)
	{
		arrayList_0 = cellParts;
		class5645_0 = row;
		class5645_1 = row;
	}

	internal void method_6(Class5645 newPageRoW)
	{
		class5645_1 = newPageRoW;
	}

	internal Class5645 method_7()
	{
		return class5645_1;
	}

	internal Class5645 method_8()
	{
		return class5645_0;
	}

	internal Class5151 method_9()
	{
		return ((Class5649)arrayList_0[0]).class5631_0.method_19();
	}

	public bool method_10(int which)
	{
		return (int_3 & (1 << which)) != 0;
	}

	public void method_11(int which, bool value)
	{
		if (value)
		{
			int_3 |= 1 << which;
		}
		else
		{
			int_3 &= ~(1 << which);
		}
	}

	public override bool vmethod_1()
	{
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("TableContentPosition:");
		stringBuilder.Append(method_4());
		stringBuilder.Append("[");
		stringBuilder.Append(class5645_0.method_0()).Append("/");
		stringBuilder.Append(method_10(int_1) ? "F" : "-");
		stringBuilder.Append(method_10(int_2) ? "L" : "-").Append("]");
		stringBuilder.Append("(");
		stringBuilder.Append(arrayList_0);
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}

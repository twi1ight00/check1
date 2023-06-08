using System.Collections;
using System.Text;

namespace ns196;

internal class Class5336 : Class5329
{
	private int int_0;

	private int int_1;

	private int int_2 = -1;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	public Class5336(Class5254 position, int penaltyValue, Class5687 context)
		: this(position, penaltyValue, -1, context)
	{
	}

	public Class5336(Class5254 position, int penaltyValue, int breakClass, Class5687 context)
		: this(position, 0, penaltyValue, breakClass, context)
	{
	}

	public Class5336(Class5254 position, int penaltyWidth, int penaltyValue, int breakClass, Class5687 context)
		: base(position)
	{
		int_0 = penaltyWidth;
		int_1 = penaltyValue;
		int_2 = breakClass;
		arrayList_0 = context.method_27();
		arrayList_1 = context.method_24();
	}

	private static string smethod_0(int breakClass)
	{
		return Class5268.smethod_0(breakClass);
	}

	public override bool vmethod_5()
	{
		return false;
	}

	public int method_4()
	{
		return int_0;
	}

	public int method_5()
	{
		return int_1;
	}

	public void method_6(int p)
	{
		int_1 = p;
	}

	public override bool vmethod_3()
	{
		return int_1 == -Class5337.int_0;
	}

	public int method_7()
	{
		return int_2;
	}

	public void method_8(int breakClass)
	{
		int_2 = breakClass;
	}

	public ArrayList method_9()
	{
		return arrayList_0;
	}

	public ArrayList method_10()
	{
		return arrayList_1;
	}

	public void method_11()
	{
		arrayList_0 = null;
		arrayList_1 = null;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("BreakPossibility[p:");
		stringBuilder.Append(Class5342.smethod_1(int_1));
		if (vmethod_3())
		{
			stringBuilder.Append(" (forced break, ").Append(smethod_0(int_2)).Append(")");
		}
		else if (int_1 >= 0 && int_2 != -1)
		{
			stringBuilder.Append(" (keep constraint, ").Append(smethod_0(int_2)).Append(")");
		}
		stringBuilder.Append("; w:");
		stringBuilder.Append(int_0);
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}

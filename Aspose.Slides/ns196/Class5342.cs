using System;
using System.Text;

namespace ns196;

internal class Class5342 : Class5337
{
	public static int int_2 = 50;

	public static Class5342 class5342_0 = new Class5342(0, 0, penaltyFlagged: false, null, auxiliary: true);

	private int int_3;

	private bool bool_1;

	private int int_4 = -1;

	public Class5342(int width, int penalty, bool penaltyFlagged, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
		int_3 = penalty;
		bool_1 = penaltyFlagged;
	}

	public Class5342(int width, int penalty, bool penaltyFlagged, int breakClass, Class5254 pos, bool isAuxiliary)
		: this(width, penalty, penaltyFlagged, pos, isAuxiliary)
	{
		int_4 = breakClass;
	}

	private static string smethod_0(int breakClass)
	{
		return Class5268.smethod_0(breakClass);
	}

	internal static string smethod_1(int penaltyValue)
	{
		string text = ((penaltyValue < 0) ? "-" : string.Empty);
		int num = Math.Abs(penaltyValue);
		return text + ((num == Class5337.int_0) ? "INFINITE" : num.ToString());
	}

	public override bool vmethod_2()
	{
		return true;
	}

	public override int vmethod_5()
	{
		return int_3;
	}

	public void method_6(int penalty)
	{
		int_3 = penalty;
	}

	public bool method_7()
	{
		return bool_1;
	}

	public override bool vmethod_3()
	{
		return int_3 == -Class5337.int_0;
	}

	public int method_8()
	{
		return int_4;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		if (method_3())
		{
			stringBuilder.Append("aux. ");
		}
		stringBuilder.Append("penalty");
		stringBuilder.Append(" p=");
		stringBuilder.Append(smethod_1(int_3));
		if (bool_1)
		{
			stringBuilder.Append(" [flagged]");
		}
		stringBuilder.Append(" w=");
		stringBuilder.Append(method_4());
		if (vmethod_3())
		{
			stringBuilder.Append(" (forced break, ").Append(smethod_0(int_4)).Append(")");
		}
		else if (int_3 >= 0 && int_4 != -1)
		{
			stringBuilder.Append(" (keep constraint, ").Append(smethod_0(int_4)).Append(")");
		}
		return stringBuilder.ToString();
	}
}

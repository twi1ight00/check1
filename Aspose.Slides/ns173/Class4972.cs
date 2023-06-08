using System;
using System.Collections;
using ns171;
using ns181;

namespace ns173;

internal class Class4972 : Class4942
{
	private class Class5744
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal double double_0;

		internal bool bool_0;

		internal Class5744(int alignment, int diff, int stretch, int shrink)
		{
			int_0 = alignment;
			int_1 = diff;
			int_2 = stretch;
			int_3 = shrink;
			double_0 = 1.0;
			bool_0 = false;
		}

		public override string ToString()
		{
			return GetType().Name + ": diff=" + int_1 + ", variation=" + double_0 + ", stretch=" + int_2 + ", shrink=" + int_3;
		}
	}

	private int int_15;

	private Class5744 class5744_0;

	private ArrayList arrayList_1 = new ArrayList();

	internal int XOffset
	{
		get
		{
			return int_15;
		}
		set
		{
			int_15 = value;
		}
	}

	public Class4972()
	{
	}

	public Class4972(int alignment, int diff, int stretch, int shrink)
	{
		class5744_0 = new Class5744(alignment, diff, stretch, shrink);
	}

	public override void vmethod_2(Class4942 childArea)
	{
		if (childArea is Class4943)
		{
			method_37((Class4943)childArea);
			((Class4943)childArea).vmethod_3(this);
		}
	}

	public void method_37(Class4943 area)
	{
		arrayList_1.Add(area);
	}

	public void method_38(ArrayList inlineAreaS)
	{
		foreach (Class4943 inlineArea in inlineAreaS)
		{
			Class4942 class2 = inlineArea.method_28();
			if (class2 == null)
			{
				inlineArea.vmethod_3(this);
			}
		}
		arrayList_1 = inlineAreaS;
	}

	public ArrayList method_39()
	{
		return arrayList_1;
	}

	public int method_40()
	{
		if (method_34(Class5757.int_20))
		{
			return method_36(Class5757.int_20);
		}
		return 0;
	}

	public int method_41()
	{
		if (method_34(Class5757.int_21))
		{
			return method_36(Class5757.int_21);
		}
		return 0;
	}

	public void method_42()
	{
		int num = 0;
		int num2 = 0;
		int i = 0;
		for (int count = arrayList_1.Count; i < count; i++)
		{
			num = Math.Max(num, ((Class4943)arrayList_1[i]).method_14());
			num2 += ((Class4943)arrayList_1[i]).method_15();
		}
		method_11(num);
		method_13(num2);
	}

	public void method_43(int ipdVariation)
	{
		int num = method_40();
		int num2 = method_41();
		switch ((Enum679)class5744_0.int_0)
		{
		case Enum679.const_40:
			method_29(Class5757.int_20, num - ipdVariation);
			break;
		case Enum679.const_24:
			method_29(Class5757.int_20, num - ipdVariation / 2);
			method_29(Class5757.int_21, num2 - ipdVariation / 2);
			break;
		case Enum679.const_222:
			method_29(Class5757.int_21, num2 - ipdVariation);
			break;
		default:
			throw new Exception();
		case Enum679.const_71:
			class5744_0.double_0 *= (float)(class5744_0.int_1 - ipdVariation) / (float)class5744_0.int_1;
			class5744_0.int_1 -= ipdVariation;
			if (class5744_0.bool_0)
			{
				method_44();
			}
			break;
		}
	}

	public void method_44()
	{
		if (class5744_0.int_0 != 70)
		{
			return;
		}
		bool flag = false;
		int i = 0;
		for (int count = arrayList_1.Count; i < count; i++)
		{
			flag |= ((Class4943)arrayList_1[i]).vmethod_5(class5744_0.double_0, class5744_0.int_2, class5744_0.int_3);
		}
		if (!flag)
		{
			class5744_0 = null;
			return;
		}
		if (!class5744_0.bool_0)
		{
			class5744_0.bool_0 = true;
		}
		class5744_0.double_0 = 1.0;
	}
}

using System.Collections;
using ns173;
using ns182;

namespace ns181;

internal class Class4943 : Class4942
{
	internal class Class4976
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		public Class4976(int stretch, int shrink, int adj)
		{
			int_0 = stretch;
			int_1 = shrink;
			int_2 = adj;
		}

		internal int method_0(double variationFactor)
		{
			int num = int_2;
			int_2 = (int)((double)int_2 * variationFactor);
			return int_2 - num;
		}
	}

	protected int int_15;

	private int int_16;

	protected Class4976 class4976_0;

	public Class4943()
	{
		int_15 = 0;
		method_16(-1);
	}

	protected Class4943(int blockProgressionOffset, int bidiLevel)
	{
		int_15 = blockProgressionOffset;
		method_16(bidiLevel);
	}

	public Class4976 method_37()
	{
		return class4976_0;
	}

	public void method_38(int stretch, int shrink, int adjustment)
	{
		class4976_0 = new Class4976(stretch, shrink, adjustment);
	}

	public void method_39(int adjustment)
	{
		if (class4976_0 != null)
		{
			class4976_0.int_2 = adjustment;
		}
	}

	public void method_40(int ipd)
	{
		int_12 += ipd;
	}

	public void method_41(int blockProgressionOffset)
	{
		int_15 = blockProgressionOffset;
	}

	public int method_42()
	{
		return int_15;
	}

	public override void vmethod_2(Class4942 childArea)
	{
		base.vmethod_2(childArea);
		if (childArea is Class4943)
		{
			((Class4943)childArea).vmethod_3(this);
		}
	}

	public bool method_43()
	{
		return method_35(Class5757.int_7);
	}

	public bool method_44()
	{
		return method_35(Class5757.int_8);
	}

	public bool method_45()
	{
		return method_35(Class5757.int_9);
	}

	public bool method_46()
	{
		return method_35(Class5757.int_26);
	}

	public virtual bool vmethod_5(double variationFactor, int lineStretch, int lineShrink)
	{
		if (class4976_0 != null)
		{
			method_11(method_12() + class4976_0.method_0(variationFactor));
		}
		return false;
	}

	public void method_47(int ipdVariation)
	{
		method_40(ipdVariation);
		method_48(ipdVariation);
	}

	protected void method_48(int ipdVariation)
	{
		if (method_28() is Class4943)
		{
			((Class4943)method_28()).method_47(ipdVariation);
		}
		else if (method_28() is Class4972)
		{
			((Class4972)method_28()).method_43(ipdVariation);
		}
		else if (method_28() == null)
		{
			int_16 += ipdVariation;
		}
	}

	internal virtual int vmethod_6()
	{
		return method_42();
	}

	internal virtual int vmethod_7()
	{
		return vmethod_1();
	}

	public virtual ArrayList vmethod_8(ArrayList runs)
	{
		runs.Add(new Class5742(this, new int[1] { method_18() }));
		return runs;
	}

	public bool method_49(Class4943 ia)
	{
		if (ia != this)
		{
			return method_50(ia);
		}
		return true;
	}

	public bool method_50(Class4943 ia)
	{
		Class4942 @class = method_28();
		while (true)
		{
			if (@class != null)
			{
				if (@class == ia)
				{
					break;
				}
				@class = ((!(@class is Class4943)) ? null : ((Class4943)@class).method_28());
				continue;
			}
			return false;
		}
		return true;
	}
}

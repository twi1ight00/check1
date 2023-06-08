using System.Collections;
using ns190;
using ns205;

namespace ns173;

internal class Class4965 : Class4964
{
	private Class4958 class4958_0;

	private Class4966 class4966_0;

	private Class4960 class4960_0;

	private int int_16;

	private int int_17;

	private Class4959 class4959_0;

	public Class4959 method_44()
	{
		if (class4959_0 == null)
		{
			class4959_0 = new Class4959();
		}
		return class4959_0;
	}

	public Class4965(Class5143 rb, Class4971 parent)
		: this(rb.vmethod_24(), rb.method_53(), parent, rb.method_59(), rb.method_60())
	{
	}

	public Class4965(int regionClass, string regionName, Class4971 parent, int columnCount, int columnGap)
		: base(regionClass, regionName, parent)
	{
		int_17 = columnCount;
		int_16 = columnGap;
		class4966_0 = new Class4966(this);
	}

	public int method_45()
	{
		return int_17;
	}

	public int method_46()
	{
		return int_16;
	}

	public Class4966 method_47()
	{
		return class4966_0;
	}

	public bool method_48()
	{
		if ((class4966_0 != null && !class4966_0.method_41()) || (class4960_0 != null && !class4960_0.vmethod_6()))
		{
			return false;
		}
		if (class4958_0 != null)
		{
			return class4958_0.vmethod_6();
		}
		return true;
	}

	public Class4958 method_49()
	{
		if (class4958_0 == null)
		{
			class4958_0 = new Class4958();
		}
		return class4958_0;
	}

	public Class4960 method_50()
	{
		if (class4960_0 == null)
		{
			class4960_0 = new Class4960();
		}
		return class4960_0;
	}

	public int method_51()
	{
		int num = 0;
		ArrayList arrayList = method_47().method_38();
		int num2 = arrayList.Count - 1;
		for (int i = 0; i < num2; i++)
		{
			num += ((Class4967)arrayList[i]).method_40();
		}
		return vmethod_1() - num;
	}

	public override void vmethod_4(Interface231 wmtg)
	{
		if (method_47() != null)
		{
			method_47().vmethod_4(wmtg);
		}
	}

	public override object vmethod_5()
	{
		Class4965 @class = (Class4965)base.vmethod_5();
		@class.class4966_0 = new Class4966(@class);
		return @class;
	}
}

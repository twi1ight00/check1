using System.Collections;
using ns183;
using ns211;

namespace ns210;

internal class Class5582 : Class5580
{
	private int[] int_4;

	private Class5602 class5602_0;

	private ArrayList arrayList_0;

	private bool bool_0;

	public Class5582(Class5591 gs, string script, string language, string feature, Interface216 sct)
		: base(gs, script, language, feature, sct)
	{
		class5602_0 = Class5602.smethod_0(gs.method_8());
		arrayList_0 = new ArrayList(gs.method_8());
		bool_0 = gs.method_13();
	}

	public Class5582(Class5582 ss)
		: base(ss)
	{
		class5602_0 = Class5602.smethod_0(int_1);
		arrayList_0 = new ArrayList(int_1);
	}

	public void method_58(int[] alternates)
	{
		int_4 = alternates;
	}

	public int method_59(int ci)
	{
		if (int_4 == null)
		{
			return 0;
		}
		if (ci >= 0 && ci <= int_4.Length)
		{
			return int_4[ci];
		}
		return 0;
	}

	public void method_60(int glyph, Class5591.Class5592 a, object predication)
	{
		if (!class5602_0.method_18())
		{
			class5602_0 = smethod_0(class5602_0);
		}
		class5602_0.method_3(glyph);
		if (bool_0 && predication != null)
		{
			a.method_8(string_2, predication);
		}
		arrayList_0.Add(a);
	}

	public void method_61(int[] glyphs, Class5591.Class5592[] associations, object predication)
	{
		int i = 0;
		for (int num = glyphs.Length; i < num; i++)
		{
			method_60(glyphs[i], associations[i], predication);
		}
	}

	public Class5591 method_62()
	{
		int num = class5602_0.method_0();
		if (num > 0)
		{
			class5602_0.method_15(num);
			class5602_0.method_2();
			return new Class5591(class5591_0.method_0(), class5602_0, arrayList_0);
		}
		return class5591_0;
	}

	public bool method_63(Class5543 st)
	{
		method_7(st);
		bool result = st.imethod_0(this);
		method_8();
		return result;
	}

	public bool method_64(Class5563.Class5570[] lookups, int nig)
	{
		int num = int_1 - (int_0 + nig);
		int count = 0;
		if (lookups != null && lookups.Length > 0)
		{
			int i = 0;
			for (int num2 = lookups.Length; i < num2; i++)
			{
				Class5563.Class5570 @class = lookups[i];
				if (@class == null)
				{
					continue;
				}
				Class5563.Class5568 class2 = @class.method_2();
				if (class2 != null)
				{
					Class5582 ss = new Class5582(this);
					Class5591 class3 = class2.method_7(ss, @class.method_0());
					if (method_45(0, -1, class3))
					{
						count = class3.method_8() - num;
					}
				}
			}
			method_61(method_26(0, count, reverseOrder: false, null, null, null), method_38(0, count, reverseOrder: false, null, null, null), null);
			method_18(count);
			return true;
		}
		return false;
	}

	public override void vmethod_0()
	{
		base.vmethod_0();
		int num = method_22();
		if (num != 65535)
		{
			method_60(num, method_25(), null);
		}
	}

	private static Class5602 smethod_0(Class5602 ib)
	{
		int num = ib.method_1();
		int capacity = num * 2;
		Class5602 @class = Class5602.smethod_0(capacity);
		ib.method_2();
		return @class.method_7(ib);
	}
}

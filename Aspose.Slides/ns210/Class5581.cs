using System;
using ns211;

namespace ns210;

internal class Class5581 : Class5580
{
	private int int_4;

	private int[] int_5;

	private int[][] int_6;

	private bool bool_0;

	public Class5581(Class5591 gs, string script, string language, string feature, int fontSize, int[] widths, int[][] adjustments, Interface216 sct)
		: base(gs, script, language, feature, sct)
	{
		int_4 = fontSize;
		int_5 = widths;
		int_6 = adjustments;
	}

	public Class5581(Class5581 ps)
		: base(ps)
	{
		int_4 = ps.int_4;
		int_5 = ps.int_5;
		int_6 = ps.int_6;
	}

	public int method_58(int gi)
	{
		if (int_5 != null && gi < int_5.Length)
		{
			return int_5[gi];
		}
		return 0;
	}

	public bool method_59(Class5566.Class5605 v)
	{
		return method_60(v, 0);
	}

	public bool method_60(Class5566.Class5605 v, int offset)
	{
		if (int_0 + offset >= int_1)
		{
			throw new IndexOutOfRangeException();
		}
		return v.method_9(int_6[int_0 + offset], int_4);
	}

	public int[] method_61()
	{
		return method_62(0);
	}

	public int[] method_62(int offset)
	{
		if (int_0 + offset >= int_1)
		{
			throw new IndexOutOfRangeException();
		}
		return int_6[int_0 + offset];
	}

	public bool method_63(Class5520 st)
	{
		method_7(st);
		bool result = st.imethod_0(this);
		method_8();
		return result;
	}

	public bool method_64(Class5563.Class5570[] lookups, int nig)
	{
		if (lookups != null && lookups.Length > 0)
		{
			int i = 0;
			for (int num = lookups.Length; i < num; i++)
			{
				Class5563.Class5570 @class = lookups[i];
				if (@class == null)
				{
					continue;
				}
				Class5563.Class5568 class2 = @class.method_2();
				if (class2 != null)
				{
					Class5581 ps = new Class5581(this);
					if (class2.method_10(ps, @class.method_0()))
					{
						method_65(adjusted: true);
					}
				}
			}
			method_18(nig);
			return true;
		}
		return false;
	}

	public override void vmethod_0()
	{
		base.vmethod_0();
	}

	public void method_65(bool adjusted)
	{
		bool_0 = adjusted;
	}

	public bool method_66()
	{
		return bool_0;
	}
}

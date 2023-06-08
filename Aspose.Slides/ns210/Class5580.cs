using System;
using System.Collections;
using ns183;
using ns211;

namespace ns210;

internal class Class5580
{
	private class Class5583 : Interface213
	{
		private Class5580 class5580_0;

		public Class5583(Class5580 parent)
		{
			class5580_0 = parent;
		}

		public bool imethod_0(int gi, int flags)
		{
			return class5580_0.method_49(gi, flags);
		}
	}

	private class Class5584 : Interface213
	{
		private Class5580 class5580_0;

		public Class5584(Class5580 parent)
		{
			class5580_0 = parent;
		}

		public bool imethod_0(int gi, int flags)
		{
			return class5580_0.method_51(gi, flags);
		}
	}

	private class Class5585 : Interface213
	{
		private Class5580 class5580_0;

		public Class5585(Class5580 parent)
		{
			class5580_0 = parent;
		}

		public bool imethod_0(int gi, int flags)
		{
			return class5580_0.method_53(gi, flags);
		}
	}

	private class Class5586 : Interface213
	{
		private Interface213[] interface213_0;

		private int int_0;

		internal Class5586(Interface213[] gta, int ngt)
		{
			interface213_0 = gta;
			int_0 = ngt;
		}

		public bool imethod_0(int gi, int flags)
		{
			int num = 0;
			int num2 = int_0;
			while (true)
			{
				if (num < num2)
				{
					Interface213 @interface = interface213_0[num];
					if (@interface != null && @interface.imethod_0(gi, flags))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	private class Class5587 : Interface213
	{
		private Interface213[] interface213_0;

		private int int_0;

		internal Class5587(Interface213[] gta, int ngt)
		{
			interface213_0 = gta;
			int_0 = ngt;
		}

		public bool imethod_0(int gi, int flags)
		{
			int num = 0;
			int num2 = int_0;
			while (true)
			{
				if (num < num2)
				{
					Interface213 @interface = interface213_0[num];
					if (@interface != null && !@interface.imethod_0(gi, flags))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	private class Class5588 : Interface213
	{
		private Interface213 interface213_0;

		internal Class5588(Interface213 gt)
		{
			interface213_0 = gt;
		}

		public bool imethod_0(int gi, int flags)
		{
			if (interface213_0 != null && interface213_0.imethod_0(gi, flags))
			{
				return false;
			}
			return true;
		}
	}

	protected Class5564 class5564_0;

	protected string string_0;

	protected string string_1;

	protected string string_2;

	protected Class5591 class5591_0;

	protected int int_0;

	protected int int_1;

	protected int int_2;

	protected int int_3;

	protected Interface216 interface216_0;

	protected Interface215 interface215_0;

	protected Interface213 interface213_0;

	protected Interface213 interface213_1;

	protected Interface213 interface213_2;

	protected Interface213 interface213_3;

	protected Class5580(Class5591 gs, string script, string language, string feature, Interface216 sct)
	{
		string_0 = script;
		string_1 = language;
		string_2 = feature;
		class5591_0 = gs;
		int_1 = gs.method_8();
		interface216_0 = sct;
		interface215_0 = sct?.imethod_0(feature);
		interface213_0 = new Class5583(this);
		interface213_1 = new Class5584(this);
		interface213_2 = new Class5585(this);
	}

	protected Class5580(Class5580 s)
		: this(new Class5591(s.class5591_0), s.string_0, s.string_1, s.string_2, s.interface216_0)
	{
		method_10(s.int_0);
	}

	public void method_0(Class5564 gdef)
	{
		if (class5564_0 == null)
		{
			class5564_0 = gdef;
		}
		else if (gdef == null)
		{
			class5564_0 = null;
		}
	}

	public Class5564 method_1()
	{
		return class5564_0;
	}

	public void method_2(int flags)
	{
		if (int_3 == 0)
		{
			int_3 = flags;
		}
		else if (flags == 0)
		{
			int_3 = 0;
		}
	}

	public int method_3()
	{
		return int_3;
	}

	public int method_4(int gi)
	{
		return 0;
	}

	public void method_5(Interface213 ignoreDefault)
	{
		if (interface213_3 == null)
		{
			interface213_3 = ignoreDefault;
		}
		else if (ignoreDefault == null)
		{
			interface213_3 = null;
		}
	}

	public Interface213 method_6()
	{
		return interface213_3;
	}

	public void method_7(Class5510 st)
	{
		method_0(st.method_4());
		method_2(st.method_2());
		method_5(method_54(method_3()));
	}

	public void method_8()
	{
		method_0(null);
		method_2(0);
		method_5(null);
	}

	public int method_9()
	{
		return int_0;
	}

	public void method_10(int index)
	{
		if (index < 0 || index > int_1)
		{
			throw new IndexOutOfRangeException();
		}
		int_0 = index;
	}

	public int method_11()
	{
		return int_1;
	}

	public bool method_12()
	{
		return method_13(1);
	}

	public bool method_13(int count)
	{
		return int_0 + count <= int_1;
	}

	public int method_14()
	{
		if (int_0 < int_1)
		{
			if (int_2 == 0)
			{
				int_2 = 1;
			}
			int_0 += int_2;
			int_2 = 0;
			if (int_0 > int_1)
			{
				int_0 = int_1;
			}
		}
		return int_0;
	}

	public bool method_15()
	{
		return method_16(1);
	}

	public bool method_16(int count)
	{
		return int_0 - count >= 0;
	}

	public int method_17()
	{
		if (int_0 > 0)
		{
			if (int_2 == 0)
			{
				int_2 = 1;
			}
			int_0 -= int_2;
			int_2 = 0;
			if (int_0 < 0)
			{
				int_0 = 0;
			}
		}
		return int_0;
	}

	public int method_18(int count)
	{
		if (int_2 + count > int_1)
		{
			throw new IndexOutOfRangeException();
		}
		int_2 += count;
		return int_2;
	}

	public bool method_19()
	{
		return int_2 > 0;
	}

	public Class5591 method_20()
	{
		return class5591_0;
	}

	public int method_21(int offset)
	{
		int num = int_0 + offset;
		if (num < 0 || num >= int_1)
		{
			throw new IndexOutOfRangeException("attempting index at " + num);
		}
		return class5591_0.method_3(num);
	}

	public int method_22()
	{
		return method_21(0);
	}

	public void method_23(int offset, int glyph)
	{
		int num = int_0 + offset;
		if (num < 0 || num >= int_1)
		{
			throw new IndexOutOfRangeException("attempting index at " + num);
		}
		class5591_0.method_4(num, glyph);
	}

	public Class5591.Class5592 method_24(int offset)
	{
		int num = int_0 + offset;
		if (num < 0 || num >= int_1)
		{
			throw new IndexOutOfRangeException("attempting index at " + num);
		}
		return class5591_0.method_9(num);
	}

	public Class5591.Class5592 method_25()
	{
		return method_24(0);
	}

	public int[] method_26(int offset, int count, bool reverseOrder, Interface213 ignoreTester, int[] glyphs, int[] counts)
	{
		if (count < 0)
		{
			count = method_33(offset, reverseOrder, ignoreTester)[0];
		}
		int num = int_0 + offset;
		if (num < 0)
		{
			throw new IndexOutOfRangeException("will attempt index at " + num);
		}
		if (!reverseOrder && num + count > int_1)
		{
			throw new IndexOutOfRangeException("will attempt index at " + (num + count));
		}
		if (reverseOrder && num + 1 < count)
		{
			throw new IndexOutOfRangeException("will attempt index at " + (num - count));
		}
		if (glyphs == null)
		{
			glyphs = new int[count];
		}
		else if (glyphs.Length != count)
		{
			throw new ArgumentException("glyphs array is non-null, but its length (" + glyphs.Length + "), is not equal to count (" + count + ")");
		}
		if (!reverseOrder)
		{
			return method_27(num, count, ignoreTester, glyphs, counts);
		}
		return method_28(num, count, ignoreTester, glyphs, counts);
	}

	private int[] method_27(int start, int count, Interface213 ignoreTester, int[] glyphs, int[] counts)
	{
		int num = 0;
		int num2 = 0;
		int i = start;
		int num3 = int_1;
		int num4 = 0;
		for (; i < num3; i++)
		{
			int num5 = method_21(i - int_0);
			if (num5 == 65535)
			{
				num2++;
				continue;
			}
			if (ignoreTester != null && ignoreTester.imethod_0(num5, method_3()))
			{
				num2++;
				continue;
			}
			if (num4 >= count)
			{
				break;
			}
			glyphs[num4++] = num5;
			num++;
		}
		if (counts != null && counts.Length > 1)
		{
			counts[0] = num;
			counts[1] = num2;
		}
		return glyphs;
	}

	private int[] method_28(int start, int count, Interface213 ignoreTester, int[] glyphs, int[] counts)
	{
		int num = 0;
		int num2 = 0;
		int num3 = start;
		int num4 = 0;
		while (num3 >= 0)
		{
			int num5 = method_21(num3 - int_0);
			if (num5 == 65535)
			{
				num2++;
			}
			else if (ignoreTester != null && ignoreTester.imethod_0(num5, method_3()))
			{
				num2++;
			}
			else
			{
				if (num4 >= count)
				{
					break;
				}
				glyphs[num4++] = num5;
				num++;
			}
			num3--;
		}
		if (counts != null && counts.Length > 1)
		{
			counts[0] = num;
			counts[1] = num2;
		}
		return glyphs;
	}

	public int[] method_29(int offset, int count, int[] glyphs, int[] counts)
	{
		return method_26(offset, count, offset < 0, interface213_3, glyphs, counts);
	}

	public int[] method_30()
	{
		return method_26(0, int_1 - int_0, reverseOrder: false, null, null, null);
	}

	public int[] method_31(int offset, int count, bool reverseOrder, Interface213 ignoreTester, int[] glyphs, int[] counts)
	{
		return method_26(offset, count, reverseOrder, new Class5588(ignoreTester), glyphs, counts);
	}

	public int[] method_32(int offset, int count)
	{
		return method_31(offset, count, offset < 0, interface213_3, null, null);
	}

	public int[] method_33(int offset, bool reverseOrder, Interface213 ignoreTester)
	{
		int num = int_0 + offset;
		if (num >= 0 && num <= int_1)
		{
			if (!reverseOrder)
			{
				return method_34(num, ignoreTester);
			}
			return method_35(num, ignoreTester);
		}
		return new int[2];
	}

	private int[] method_34(int start, Interface213 ignoreTester)
	{
		int num = 0;
		int num2 = 0;
		if (ignoreTester == null)
		{
			num = int_1 - start;
		}
		else
		{
			int i = start;
			for (int num3 = int_1; i < num3; i++)
			{
				int num4 = method_21(i - int_0);
				if (num4 == 65535)
				{
					num2++;
				}
				else if (ignoreTester.imethod_0(num4, method_3()))
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		return new int[2] { num, num2 };
	}

	private int[] method_35(int start, Interface213 ignoreTester)
	{
		int num = 0;
		int num2 = 0;
		if (ignoreTester == null)
		{
			num = start + 1;
		}
		else
		{
			for (int num3 = start; num3 >= 0; num3--)
			{
				int num4 = method_21(num3 - int_0);
				if (num4 == 65535)
				{
					num2++;
				}
				else if (ignoreTester.imethod_0(num4, method_3()))
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		return new int[2] { num, num2 };
	}

	public int[] method_36(int offset, bool reverseOrder)
	{
		return method_33(offset, reverseOrder, interface213_3);
	}

	public int[] method_37(int offset)
	{
		return method_36(offset, offset < 0);
	}

	public Class5591.Class5592[] method_38(int offset, int count, bool reverseOrder, Interface213 ignoreTester, Class5591.Class5592[] associations, int[] counts)
	{
		if (count < 0)
		{
			count = method_33(offset, reverseOrder, ignoreTester)[0];
		}
		int num = int_0 + offset;
		if (num < 0)
		{
			throw new IndexOutOfRangeException("will attempt index at " + num);
		}
		if (!reverseOrder && num + count > int_1)
		{
			throw new IndexOutOfRangeException("will attempt index at " + (num + count));
		}
		if (reverseOrder && num + 1 < count)
		{
			throw new IndexOutOfRangeException("will attempt index at " + (num - count));
		}
		if (associations == null)
		{
			associations = new Class5591.Class5592[count];
		}
		else if (associations.Length != count)
		{
			throw new ArgumentException("associations array is non-null, but its length (" + associations.Length + "), is not equal to count (" + count + ")");
		}
		if (!reverseOrder)
		{
			return method_39(num, count, ignoreTester, associations, counts);
		}
		return method_40(num, count, ignoreTester, associations, counts);
	}

	private Class5591.Class5592[] method_39(int start, int count, Interface213 ignoreTester, Class5591.Class5592[] associations, int[] counts)
	{
		int num = 0;
		int num2 = 0;
		int i = start;
		int num3 = int_1;
		int num4 = 0;
		for (; i < num3; i++)
		{
			int num5 = method_21(i - int_0);
			if (num5 == 65535)
			{
				num2++;
				continue;
			}
			if (ignoreTester != null && ignoreTester.imethod_0(num5, method_3()))
			{
				num2++;
				continue;
			}
			if (num4 >= count)
			{
				break;
			}
			associations[num4++] = method_24(i - int_0);
			num++;
		}
		if (counts != null && counts.Length > 1)
		{
			counts[0] = num;
			counts[1] = num2;
		}
		return associations;
	}

	private Class5591.Class5592[] method_40(int start, int count, Interface213 ignoreTester, Class5591.Class5592[] associations, int[] counts)
	{
		int num = 0;
		int num2 = 0;
		int num3 = start;
		int num4 = 0;
		while (num3 >= 0)
		{
			int num5 = method_21(num3 - int_0);
			if (num5 == 65535)
			{
				num2++;
			}
			else if (ignoreTester != null && ignoreTester.imethod_0(num5, method_3()))
			{
				num2++;
			}
			else
			{
				if (num4 >= count)
				{
					break;
				}
				associations[num4++] = method_24(num3 - int_0);
				num++;
			}
			num3--;
		}
		if (counts != null && counts.Length > 1)
		{
			counts[0] = num;
			counts[1] = num2;
		}
		return associations;
	}

	public Class5591.Class5592[] method_41(int offset, int count)
	{
		return method_38(offset, count, offset < 0, interface213_3, null, null);
	}

	public Class5591.Class5592[] method_42(int offset, int count, bool reverseOrder, Interface213 ignoreTester, Class5591.Class5592[] associations, int[] counts)
	{
		return method_38(offset, count, reverseOrder, new Class5588(ignoreTester), associations, counts);
	}

	public Class5591.Class5592[] method_43(int offset, int count)
	{
		return method_42(offset, count, offset < 0, interface213_3, null, null);
	}

	public bool method_44(int offset, int count, Class5591 gs, int gsOffset, int gsCount)
	{
		int num = ((class5591_0 != null) ? class5591_0.method_8() : 0);
		int num2 = method_9() + offset;
		if (num2 < 0)
		{
			num2 = 0;
		}
		else if (num2 > num)
		{
			num2 = num;
		}
		if (count < 0 || num2 + count > num)
		{
			count = num - num2;
		}
		int num3 = gs?.method_8() ?? 0;
		if (gsOffset < 0)
		{
			gsOffset = 0;
		}
		else if (gsOffset > num3)
		{
			gsOffset = num3;
		}
		if (gsCount < 0 || gsOffset + gsCount > num3)
		{
			gsCount = num3 - gsOffset;
		}
		int capacity = num + gsCount - count;
		Class5602 @class = Class5602.smethod_0(capacity);
		ArrayList arrayList = new ArrayList(capacity);
		int i = 0;
		for (int num4 = num2; i < num4; i++)
		{
			@class.method_3(class5591_0.method_3(i));
			arrayList.Add(class5591_0.method_9(i));
		}
		int j = gsOffset;
		for (int num5 = gsOffset + gsCount; j < num5; j++)
		{
			@class.method_3(gs.method_3(j));
			arrayList.Add(gs.method_9(j));
		}
		int k = num2 + count;
		for (int num6 = num; k < num6; k++)
		{
			@class.method_3(class5591_0.method_3(k));
			arrayList.Add(class5591_0.method_9(k));
		}
		@class.method_19();
		if (class5591_0.method_16(@class) != 0)
		{
			class5591_0 = new Class5591(class5591_0.method_0(), @class, arrayList);
			int_1 = @class.method_16();
			return true;
		}
		return false;
	}

	public bool method_45(int offset, int count, Class5591 gs)
	{
		return method_44(offset, count, gs, 0, gs.method_8());
	}

	public int method_46(int offset, int[] glyphs)
	{
		int num = int_0 + offset;
		if (num >= 0 && num <= int_1)
		{
			int num2 = 0;
			int i = num - int_0;
			for (int num3 = int_1 - num; i < num3; i++)
			{
				int num4 = method_21(i);
				if (num4 == glyphs[num2])
				{
					method_23(i, 65535);
					num2++;
				}
			}
			return num2;
		}
		throw new IndexOutOfRangeException("will attempt index at " + num);
	}

	public bool method_47()
	{
		if (interface215_0 == null)
		{
			return true;
		}
		return interface215_0.imethod_0(string_0, string_1, string_2, class5591_0, int_0, method_3());
	}

	public virtual void vmethod_0()
	{
		int_2++;
	}

	public bool method_48(int gi)
	{
		if (class5564_0 != null)
		{
			return class5564_0.method_10(gi, 1);
		}
		return false;
	}

	public bool method_49(int gi, int flags)
	{
		if ((flags & Class5510.int_1) != 0)
		{
			return method_48(gi);
		}
		return false;
	}

	public bool method_50(int gi)
	{
		if (class5564_0 != null)
		{
			return class5564_0.method_10(gi, 2);
		}
		return false;
	}

	public bool method_51(int gi, int flags)
	{
		if ((flags & Class5510.int_2) != 0)
		{
			return method_50(gi);
		}
		return false;
	}

	public bool method_52(int gi)
	{
		if (class5564_0 != null)
		{
			return class5564_0.method_10(gi, 3);
		}
		return false;
	}

	public bool method_53(int gi, int flags)
	{
		if ((flags & Class5510.int_3) != 0)
		{
			return method_52(gi);
		}
		if ((flags & Class5510.int_6) != 0)
		{
			int num = (flags & Class5510.int_6) >> 8;
			int num2 = class5564_0.method_13(gi);
			return num2 != num;
		}
		return false;
	}

	public Interface213 method_54(int flags)
	{
		if ((flags & Class5510.int_1) != 0)
		{
			if ((flags & (Class5510.int_2 | Class5510.int_3)) == 0)
			{
				return interface213_0;
			}
			return method_55(flags);
		}
		if ((flags & Class5510.int_2) != 0)
		{
			if ((flags & (Class5510.int_1 | Class5510.int_3)) == 0)
			{
				return interface213_1;
			}
			return method_55(flags);
		}
		if ((flags & Class5510.int_3) != 0)
		{
			if ((flags & (Class5510.int_1 | Class5510.int_2)) == 0)
			{
				return interface213_2;
			}
			return method_55(flags);
		}
		return null;
	}

	public Interface213 method_55(int flags)
	{
		Interface213[] array = new Interface213[3];
		int ngt = 0;
		if ((flags & Class5510.int_1) != 0)
		{
			array[ngt++] = interface213_0;
		}
		if ((flags & Class5510.int_2) != 0)
		{
			array[ngt++] = interface213_1;
		}
		if ((flags & Class5510.int_3) != 0)
		{
			array[ngt++] = interface213_2;
		}
		return method_56(array, ngt);
	}

	public Interface213 method_56(Interface213[] gta, int ngt)
	{
		if (ngt > 0)
		{
			return new Class5586(gta, ngt);
		}
		return null;
	}

	public Interface213 method_57(Interface213[] gta, int ngt)
	{
		if (ngt > 0)
		{
			return new Class5587(gta, ngt);
		}
		return null;
	}
}

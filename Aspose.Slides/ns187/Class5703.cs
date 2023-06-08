using System;
using System.Drawing;
using System.Text;
using ns171;
using ns175;
using ns176;
using ns183;
using ns195;

namespace ns187;

internal class Class5703
{
	internal class Class5704
	{
		internal Class5702 class5702_0;

		private static Class5749 class5749_0 = new Class5749();

		internal int int_0;

		private Color color_0;

		internal Class5032 class5032_0;

		private int int_1 = -1;

		private Class5704(int style, Class5032 width, Color color)
		{
			int_0 = style;
			class5032_0 = width;
			color_0 = color;
		}

		public static Class5704 smethod_0(int style, Class5032 width, Color color)
		{
			return (Class5704)class5749_0.method_0(new Class5704(style, width, color));
		}

		public int method_0()
		{
			return int_0;
		}

		public Color method_1()
		{
			return color_0;
		}

		public Class5032 method_2()
		{
			return class5032_0;
		}

		public int method_3()
		{
			if (int_0 != 95 && int_0 != 57)
			{
				return class5032_0.vmethod_17();
			}
			return 0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("BorderInfo");
			stringBuilder.Append(" {");
			stringBuilder.Append(int_0);
			stringBuilder.Append(", ");
			stringBuilder.Append(color_0);
			stringBuilder.Append(", ");
			stringBuilder.Append(class5032_0);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is Class5704 @class))
			{
				return false;
			}
			if (Class5721.smethod_0(color_0, @class.color_0) && int_0 == @class.int_0)
			{
				return Class5721.smethod_0(class5032_0, @class.class5032_0);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (int_1 == -1)
			{
				int num = 17;
				num = 629 + ((!color_0.IsEmpty) ? color_0.GetHashCode() : 0);
				num = 37 * num + int_0;
				num = 37 * num + ((class5032_0 != null) ? class5032_0.GetHashCode() : 0);
				int_1 = num;
			}
			return int_1;
		}
	}

	private class Class5033 : Class5032
	{
		public override Class5024 imethod_2(int cmpId)
		{
			throw new NotSupportedException();
		}

		public override Class5024 vmethod_14()
		{
			throw new NotSupportedException();
		}

		public override Interface182 vmethod_0()
		{
			throw new NotSupportedException();
		}

		public override Class5024 vmethod_15()
		{
			throw new NotSupportedException();
		}

		public override int vmethod_17()
		{
			return 0;
		}

		public override int vmethod_18(Interface172 context)
		{
			return 0;
		}

		public override bool vmethod_16()
		{
			return true;
		}

		public override void imethod_1(int cmpId, Class5024 cmpnValue, bool isDefault)
		{
			throw new NotSupportedException();
		}

		public override string ToString()
		{
			return "CondLength[0mpt, discard]";
		}
	}

	public const int int_0 = 0;

	public const int int_1 = 1;

	public const int int_2 = 2;

	public const int int_3 = 3;

	private static Class5749 class5749_0 = new Class5749();

	private int int_4 = -1;

	public int int_5;

	public Color color_0;

	public string string_0;

	public int int_6;

	public Interface182 interface182_0;

	public Interface182 interface182_1;

	private Class5741 class5741_0;

	public bool bool_0;

	private static Class5704 class5704_0 = Class5704.smethod_0(95, new Class5033(), Color.Empty);

	private Class5704[] class5704_1 = new Class5704[4];

	private Class5032[] class5032_0 = new Class5032[4];

	public static Class5704 smethod_0()
	{
		return class5704_0;
	}

	private Class5703(Class5634 pList)
	{
		int_5 = pList.method_5(8).imethod_0();
		Color color = pList.method_5(9).vmethod_1(pList.method_0().method_2());
		if (color.A == 0)
		{
			color_0 = Color.Empty;
		}
		else
		{
			color_0 = color;
		}
		bool_0 = pList.method_5(297).imethod_0() == 149;
		string text = pList.method_5(10).vmethod_13();
		if (text != null && !"none".Equals(text))
		{
			string_0 = text;
			int_6 = pList.method_5(14).imethod_0();
			interface182_0 = pList.method_5(12).vmethod_0();
			interface182_1 = pList.method_5(13).vmethod_0();
		}
		else
		{
			string_0 = string.Empty;
			int_6 = -1;
			interface182_0 = null;
			interface182_1 = null;
		}
		method_0(pList, 0, 23, 25, 26, 172);
		method_0(pList, 1, 19, 21, 22, 171);
		method_0(pList, 2, 47, 49, 50, 177);
		method_0(pList, 3, 33, 35, 36, 174);
		Class5702 @class = new Class5702();
		@class.method_1(pList);
		if (@class.method_0())
		{
			if (class5704_1[0] != null)
			{
				class5704_1[0].class5702_0 = @class;
			}
			if (class5704_1[1] != null)
			{
				class5704_1[1].class5702_0 = @class;
			}
			if (class5704_1[2] != null)
			{
				class5704_1[2].class5702_0 = @class;
			}
			if (class5704_1[3] != null)
			{
				class5704_1[3].class5702_0 = @class;
			}
		}
	}

	public static Class5703 smethod_1(Class5634 pList)
	{
		Class5703 @class = new Class5703(pList);
		Class5703 class2 = null;
		if ((@class.class5032_0[0] == null || @class.class5032_0[0].vmethod_0().imethod_4()) && (@class.class5032_0[1] == null || @class.class5032_0[1].vmethod_0().imethod_4()) && (@class.class5032_0[2] == null || @class.class5032_0[2].vmethod_0().imethod_4()) && (@class.class5032_0[3] == null || @class.class5032_0[3].vmethod_0().imethod_4()) && (@class.interface182_0 == null || @class.interface182_0.imethod_4()) && (@class.interface182_1 == null || @class.interface182_1.imethod_4()))
		{
			class2 = (Class5703)class5749_0.method_0(@class);
		}
		if ((class2 == null || class2 == @class) && !string.IsNullOrEmpty(@class.string_0))
		{
			string uri = Class5409.smethod_0(@class.string_0);
			Class5738 class3 = pList.method_0().method_2();
			Class5253 class4 = class3.method_0().method_14();
			Interface170 session = class3.method_35();
			Class5741 class5 = class4.method_0(uri, session);
			@class.class5741_0 = class5;
		}
		if (class2 == null)
		{
			return @class;
		}
		return class2;
	}

	private void method_0(Class5634 pList, int side, int colorProp, int styleProp, int widthProp, int paddingProp)
	{
		class5032_0[side] = pList.method_5(paddingProp).vmethod_2();
		int num = pList.method_5(styleProp).imethod_0();
		if (num != 95)
		{
			Class5738 foUserAgent = pList.method_0().method_2();
			method_1(Class5704.smethod_0(num, pList.method_5(widthProp).vmethod_2(), pList.method_5(colorProp).vmethod_1(foUserAgent)), side);
		}
	}

	private void method_1(Class5704 info, int side)
	{
		class5704_1[side] = info;
	}

	public Class5704 method_2(int side)
	{
		if (class5704_1[side] == null)
		{
			return smethod_0();
		}
		return class5704_1[side];
	}

	public Class5741 method_3()
	{
		return class5741_0;
	}

	public int method_4(bool discard)
	{
		return method_12(2, discard);
	}

	public int method_5(bool discard)
	{
		return method_12(3, discard);
	}

	public int method_6(bool discard)
	{
		return method_12(0, discard);
	}

	public int method_7(bool discard)
	{
		return method_12(1, discard);
	}

	public int method_8(bool discard, Interface172 context)
	{
		return method_16(2, discard, context);
	}

	public int method_9(bool discard, Interface172 context)
	{
		return method_16(3, discard, context);
	}

	public int method_10(bool discard, Interface172 context)
	{
		return method_16(0, discard, context);
	}

	public int method_11(bool discard, Interface172 context)
	{
		return method_16(1, discard, context);
	}

	public int method_12(int side, bool discard)
	{
		if (class5704_1[side] != null && class5704_1[side].int_0 != 95 && class5704_1[side].int_0 != 57 && (!discard || !class5704_1[side].class5032_0.vmethod_16()))
		{
			return class5704_1[side].class5032_0.vmethod_17();
		}
		return 0;
	}

	public Color method_13(int side)
	{
		if (class5704_1[side] != null)
		{
			return class5704_1[side].method_1();
		}
		return Color.Empty;
	}

	public int method_14(int side)
	{
		if (class5704_1[side] != null)
		{
			return class5704_1[side].int_0;
		}
		return 95;
	}

	public Class5702 method_15(int side)
	{
		if (class5704_1[side] != null)
		{
			return class5704_1[side].class5702_0;
		}
		return null;
	}

	public int method_16(int side, bool discard, Interface172 context)
	{
		if (class5032_0[side] != null && (!discard || !class5032_0[side].vmethod_16()))
		{
			return class5032_0[side].vmethod_18(context);
		}
		return 0;
	}

	public Class5032 method_17(int side)
	{
		return class5032_0[side];
	}

	public int method_18(bool discard, Interface172 context)
	{
		return method_8(discard, context) + method_9(discard, context) + method_4(discard) + method_5(discard);
	}

	public int method_19(bool discard, Interface172 context)
	{
		return method_10(discard, context) + method_11(discard, context) + method_6(discard) + method_7(discard);
	}

	public override string ToString()
	{
		return string.Concat("CommonBordersAndPadding (Before, After, Start, End):\nBorders: (", method_6(discard: false), ", ", method_7(discard: false), ", ", method_4(discard: false), ", ", method_5(discard: false), ")\nBorder Colors: (", method_13(0), ", ", method_13(1), ", ", method_13(2), ", ", method_13(3), ")\nPadding: (", method_10(discard: false, null), ", ", method_11(discard: false, null), ", ", method_8(discard: false, null), ", ", method_9(discard: false, null), ")\n");
	}

	public bool method_20()
	{
		if (color_0.IsEmpty)
		{
			return method_3() != null;
		}
		return true;
	}

	public bool method_21()
	{
		return method_6(discard: false) + method_7(discard: false) + method_4(discard: false) + method_5(discard: false) > 0;
	}

	public bool method_22(Interface172 context)
	{
		return method_10(discard: false, context) + method_11(discard: false, context) + method_8(discard: false, context) + method_9(discard: false, context) > 0;
	}

	public bool method_23()
	{
		if (class5704_1[0] == null && class5704_1[1] == null && class5704_1[2] == null)
		{
			return class5704_1[3] != null;
		}
		return true;
	}

	public Color method_24()
	{
		return color_0;
	}

	public int method_25()
	{
		return int_5;
	}

	public string method_26()
	{
		return string_0;
	}

	public int method_27()
	{
		return int_6;
	}

	public Interface182 method_28()
	{
		return interface182_0;
	}

	public Interface182 method_29()
	{
		return interface182_1;
	}

	public Class5741 method_30()
	{
		return class5741_0;
	}

	public Class5704[] method_31()
	{
		return class5704_1;
	}

	public Class5032[] method_32()
	{
		return class5032_0;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5703 @class))
		{
			return false;
		}
		if (int_5 == @class.int_5 && Class5721.smethod_0(color_0, @class.color_0) && Class5721.smethod_0(string_0, @class.string_0) && Class5721.smethod_0(interface182_0, interface182_0) && Class5721.smethod_0(interface182_1, @class.interface182_1) && int_6 == @class.int_6 && object.Equals(class5704_1, @class.class5704_1))
		{
			return object.Equals(class5032_0, @class.class5032_0);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (int_4 == -1)
		{
			int num = smethod_2(color_0, string_0, interface182_0, interface182_1, class5704_1[0], class5704_1[1], class5704_1[2], class5704_1[3], class5032_0[0], class5032_0[1], class5032_0[2], class5032_0[3]);
			num = 37 * num + int_5;
			num = 37 * num + int_6;
			int_4 = num;
		}
		return int_4;
	}

	private static int smethod_2(params object[] objects)
	{
		int num = 17;
		for (int i = 0; i < objects.Length; i++)
		{
			num = 37 * num + (objects[i]?.GetHashCode() ?? 0);
		}
		return num;
	}
}

using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using ns174;
using ns176;
using ns178;
using ns182;
using ns183;
using ns187;
using ns189;

namespace ns171;

internal class Class5172 : Class5088, Interface238
{
	private class Class5660 : Class5656
	{
		private Class5172 class5172_0;

		private int int_0;

		private bool bool_0;

		private bool bool_1;

		public Class5660(Class5172 parent)
		{
			class5172_0 = parent;
		}

		public override bool imethod_0()
		{
			return int_0 < class5172_0.class5707_0.method_14();
		}

		public override char vmethod_0()
		{
			if (int_0 >= class5172_0.class5707_0.method_14())
			{
				throw new Exception("Element was not found");
			}
			bool_0 = true;
			bool_1 = true;
			return class5172_0.class5707_0.method_9(int_0++);
		}

		public override void imethod_6()
		{
			if (!bool_0)
			{
				throw new InvalidOperationException();
			}
			class5172_0.class5707_0.method_1(int_0);
			class5172_0.class5707_0.method_15();
			int_0--;
			bool_0 = false;
		}

		public override void vmethod_1(char c)
		{
			if (!bool_1)
			{
				throw new InvalidOperationException();
			}
			class5172_0.class5707_0.method_5(int_0 - 1, c);
		}
	}

	internal class Class5736
	{
		private int int_0;

		private int int_1;

		internal Class5736(int start, int end)
		{
			int_0 = start;
			int_1 = end;
		}

		public override int GetHashCode()
		{
			return int_0 * 31 + int_1;
		}

		public override bool Equals(object o)
		{
			if (o is Class5736)
			{
				Class5736 @class = (Class5736)o;
				if (@class.int_0 == int_0)
				{
					return @class.int_1 == int_1;
				}
				return false;
			}
			return false;
		}
	}

	private const int int_0 = 0;

	private const int int_1 = 1;

	private const int int_2 = 2;

	internal Class5707 class5707_0;

	private Class5716 class5716_0;

	private Class5717 class5717_0;

	private Color color_0;

	private Class5043 class5043_0;

	private Class5024 class5024_0;

	private Class5046 class5046_0;

	private int int_3;

	private int int_4;

	private int int_5;

	private Class5024 class5024_1;

	private int int_6;

	private Interface182 interface182_0;

	private string string_2;

	private string string_3;

	private string string_4;

	private Class5172 class5172_0;

	private Class5106 class5106_0;

	private Class5720 class5720_0;

	private Interface244 interface244_0;

	private int[] int_7;

	private Hashtable hashtable_0;

	public Class5172(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_9(char[] data, int start, int length, Class5634 list, Interface243 locatoR)
	{
		if (class5707_0 == null)
		{
			int capacity = ((length < 16) ? 16 : length);
			class5707_0 = Class5707.smethod_0(capacity);
		}
		else
		{
			int num = class5707_0.method_0() + length;
			int num2 = class5707_0.method_2();
			if (num > num2)
			{
				int num3 = num2 * 2;
				if (num > num3)
				{
					num3 = num;
				}
				Class5707 @class = Class5707.smethod_0(num3);
				class5707_0.method_3();
				@class.method_7(class5707_0);
				class5707_0 = @class;
			}
		}
		class5707_0.method_13(class5707_0.method_2());
		class5707_0.method_6(data, start, length);
		class5707_0.method_13(class5707_0.method_0());
	}

	public Interface238 method_25()
	{
		if (class5707_0 == null)
		{
			return null;
		}
		class5707_0.method_3();
		return class5707_0.method_12(0, class5707_0.method_14());
	}

	public override Class5088 vmethod_0(Class5088 parent, bool removeChildren)
	{
		Class5172 @class = (Class5172)base.vmethod_0(parent, removeChildren);
		if (removeChildren && class5707_0 != null)
		{
			@class.class5707_0 = Class5707.smethod_0(class5707_0.method_14());
			class5707_0.method_3();
			@class.class5707_0.method_7(class5707_0);
			@class.class5707_0.method_3();
		}
		@class.class5172_0 = null;
		@class.class5106_0 = null;
		return @class;
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5716_0 = pList.method_25();
		class5717_0 = pList.method_19();
		color_0 = pList.method_5(72).vmethod_1(method_2());
		class5043_0 = pList.method_5(131).vmethod_6();
		class5046_0 = pList.method_5(144).vmethod_5();
		class5024_0 = pList.method_5(141);
		int_4 = pList.method_5(261).imethod_0();
		int_3 = pList.method_5(262).imethod_0();
		int_5 = pList.method_5(252).imethod_0();
		class5024_1 = pList.method_5(265);
		int_6 = pList.method_5(266).imethod_0();
		class5720_0 = pList.method_26();
		interface182_0 = pList.method_5(15).vmethod_0();
		string_2 = pList.method_5(81).vmethod_13();
		string_3 = pList.method_5(134).vmethod_13();
		string_4 = pList.method_5(218).vmethod_13();
	}

	internal override void vmethod_11()
	{
		if (class5707_0 != null)
		{
			class5707_0.method_3();
		}
		base.vmethod_11();
		vmethod_3().vmethod_63(this);
	}

	public override void vmethod_14()
	{
		method_28();
	}

	public bool method_26()
	{
		if (int_4 == 48 && class5707_0.method_14() > 0)
		{
			return true;
		}
		class5707_0.method_3();
		char c;
		do
		{
			if (class5707_0.method_16())
			{
				c = class5707_0.method_8();
				continue;
			}
			return false;
		}
		while (c == ' ' || c == '\n' || c == '\r' || c == '\t');
		class5707_0.method_3();
		return true;
	}

	public override Class5656 vmethod_17()
	{
		return new Class5660(this);
	}

	internal void method_27(Class5106 ancestorBlock)
	{
		class5106_0 = ancestorBlock;
		if (ancestorBlock.class5172_1 != null)
		{
			if (ancestorBlock.class5172_1.class5106_0 == class5106_0)
			{
				class5172_0 = ancestorBlock.class5172_1;
			}
			else
			{
				class5172_0 = null;
			}
		}
	}

	private void method_28()
	{
		if (vmethod_4().method_5() || int_5 == 95)
		{
			return;
		}
		class5707_0.method_3();
		int num = class5707_0.method_14();
		int num2 = -1;
		while (++num2 < num)
		{
			char c = class5707_0.method_8();
			class5707_0.method_10();
			switch ((Enum679)int_5)
			{
			case Enum679.const_242:
				class5707_0.method_4(char.ToUpper(c));
				break;
			case Enum679.const_79:
				class5707_0.method_4(char.ToLower(c));
				break;
			case Enum679.const_23:
				if (method_29(num2))
				{
					CultureInfo cultureInfo = new CultureInfo("en-US", useUserOverride: false);
					try
					{
						if (string_3 != null)
						{
							cultureInfo = ((string_2 == null) ? new CultureInfo(string_3) : new CultureInfo(string_3 + "-" + string_2));
						}
					}
					catch (Exception)
					{
					}
					TextInfo textInfo = cultureInfo.TextInfo;
					class5707_0.method_4(textInfo.ToTitleCase(c.ToString()).ToCharArray()[0]);
				}
				else
				{
					class5707_0.method_4(c);
				}
				break;
			}
		}
	}

	private bool method_29(int i)
	{
		char inputChar = method_30(i, -1);
		switch (smethod_9(inputChar))
		{
		default:
			return false;
		case 0:
			return true;
		case 1:
			return false;
		case 2:
		{
			char inputChar2 = method_30(i, -2);
			return smethod_9(inputChar2) switch
			{
				0 => true, 
				1 => false, 
				2 => true, 
				_ => false, 
			};
		}
		}
	}

	private char method_30(int i, int offset)
	{
		int num = i + offset;
		if (num >= 0 && num < imethod_0())
		{
			return imethod_1(i + offset);
		}
		if (offset > 0)
		{
			return '\0';
		}
		bool flag = false;
		char result = '\0';
		Class5172 @class = this;
		int num2 = offset + i;
		while (!flag && @class.class5172_0 != null)
		{
			@class = @class.class5172_0;
			int num3 = @class.imethod_0() + num2 - 1;
			if (num3 >= 0)
			{
				result = @class.imethod_1(num3);
				flag = true;
			}
			else
			{
				num2 += num3;
			}
		}
		return result;
	}

	private static int smethod_9(char inputChar)
	{
		switch (char.GetUnicodeCategory(inputChar))
		{
		case UnicodeCategory.UppercaseLetter:
			return 1;
		case UnicodeCategory.LowercaseLetter:
			return 1;
		case UnicodeCategory.TitlecaseLetter:
			return 1;
		case UnicodeCategory.ModifierLetter:
			return 1;
		case UnicodeCategory.OtherLetter:
			return 1;
		case UnicodeCategory.NonSpacingMark:
			return 1;
		case UnicodeCategory.SpacingCombiningMark:
			return 1;
		case UnicodeCategory.EnclosingMark:
			return 0;
		case UnicodeCategory.DecimalDigitNumber:
			return 1;
		case UnicodeCategory.LetterNumber:
			return 1;
		case UnicodeCategory.OtherNumber:
			return 1;
		case UnicodeCategory.SpaceSeparator:
			return 0;
		case UnicodeCategory.LineSeparator:
			return 0;
		case UnicodeCategory.ParagraphSeparator:
			return 0;
		case UnicodeCategory.Control:
			return 0;
		case UnicodeCategory.Format:
			return 0;
		case UnicodeCategory.Surrogate:
			return 0;
		case UnicodeCategory.PrivateUse:
			return 0;
		case UnicodeCategory.ConnectorPunctuation:
			return 1;
		case UnicodeCategory.DashPunctuation:
			if (inputChar == '-')
			{
				return 1;
			}
			return 0;
		case UnicodeCategory.OpenPunctuation:
			return 0;
		case UnicodeCategory.ClosePunctuation:
			if (inputChar == '’')
			{
				return 2;
			}
			return 0;
		default:
			return 0;
		case UnicodeCategory.OtherPunctuation:
			if (inputChar == '\'')
			{
				return 2;
			}
			return 0;
		case UnicodeCategory.MathSymbol:
			return 0;
		case UnicodeCategory.CurrencySymbol:
			return 1;
		case UnicodeCategory.ModifierSymbol:
			return 1;
		case UnicodeCategory.OtherSymbol:
			return 1;
		case UnicodeCategory.OtherNotAssigned:
			return 0;
		}
	}

	public Class5716 method_31()
	{
		return class5716_0;
	}

	public Class5717 method_32()
	{
		return class5717_0;
	}

	public Color method_33()
	{
		return color_0;
	}

	public Class5043 method_34()
	{
		return class5043_0;
	}

	public Class5024 method_35()
	{
		return class5024_0;
	}

	public Class5046 method_36()
	{
		return class5046_0;
	}

	public int method_37()
	{
		return int_3;
	}

	public Class5024 method_38()
	{
		return class5024_1;
	}

	public int method_39()
	{
		return int_6;
	}

	public Class5720 method_40()
	{
		return class5720_0;
	}

	public Interface182 method_41()
	{
		return interface182_0;
	}

	public string method_42()
	{
		return string_2;
	}

	public string method_43()
	{
		return string_3;
	}

	public string method_44()
	{
		return string_4;
	}

	public override string ToString()
	{
		return string.Empty;
	}

	public override string vmethod_21()
	{
		return "#PCDATA";
	}

	public override string vmethod_22()
	{
		return null;
	}

	internal override string vmethod_19()
	{
		if (interface243_0 != null)
		{
			return base.vmethod_19();
		}
		return ToString();
	}

	public char imethod_1(int position)
	{
		return class5707_0.method_9(position);
	}

	public Interface238 imethod_2(int start, int end)
	{
		return class5707_0.method_12(start, end);
	}

	public int imethod_0()
	{
		return class5707_0.method_14();
	}

	public void method_45()
	{
		if (class5707_0 != null)
		{
			class5707_0.method_3();
		}
	}

	public override bool vmethod_26(int boundary)
	{
		return false;
	}

	public override void vmethod_29(Interface244 structureTreeElement)
	{
		interface244_0 = structureTreeElement;
	}

	public Interface244 method_46()
	{
		return interface244_0;
	}

	public void method_47(int level, int start, int end)
	{
		if (start < end)
		{
			if (int_7 == null)
			{
				int_7 = new int[imethod_0()];
			}
			for (int i = start; i < end; i++)
			{
				int_7[i] = level;
			}
			if (class5088_0 != null)
			{
				((Class5094)class5088_0).method_40(level);
			}
		}
	}

	public int[] method_48()
	{
		return int_7;
	}

	public int[] method_49(int start, int end)
	{
		if (int_7 != null)
		{
			int num = end - start;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = int_7[start + i];
			}
			return array;
		}
		return null;
	}

	public int method_50(int position)
	{
		if (position >= 0 && position < imethod_0())
		{
			if (int_7 != null)
			{
				return int_7[position];
			}
			return -1;
		}
		throw new IndexOutOfRangeException();
	}

	public void method_51(int start, int end, Interface238 mappedChars)
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
		}
		hashtable_0.Add(new Class5736(start, end), mappedChars.ToString());
	}

	public bool method_52(int start, int end)
	{
		if (hashtable_0 != null)
		{
			return hashtable_0.ContainsKey(new Class5736(start, end));
		}
		return false;
	}

	public string method_53(int start, int end)
	{
		if (hashtable_0 != null)
		{
			return (string)hashtable_0[new Class5736(start, end)];
		}
		return null;
	}

	public int method_54(int start, int end)
	{
		if (hashtable_0 != null)
		{
			return ((string)hashtable_0[new Class5736(start, end)]).Length;
		}
		return 0;
	}

	public int[] method_55(int start, int end)
	{
		if (method_52(start, end))
		{
			int num = end - start;
			int num2 = method_54(start, end);
			int[] array = method_49(start, end);
			if (array == null)
			{
				return null;
			}
			if (num2 == num)
			{
				return array;
			}
			if (num2 > num)
			{
				int[] array2 = new int[num2];
				Array.Copy(array, 0, array2, 0, array.Length);
				int i = array.Length;
				int num3 = array2.Length;
				int num4 = ((i > 0) ? array[i - 1] : 0);
				for (; i < num3; i++)
				{
					array2[i] = num4;
				}
				return array2;
			}
			int[] array3 = new int[num2];
			Array.Copy(array, 0, array3, 0, array3.Length);
			return array3;
		}
		return method_49(start, end);
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		currentRange?.method_1(vmethod_17(), this);
		return ranges;
	}
}

using System;
using System.Collections;
using System.Text;
using ns171;
using ns173;
using ns181;
using ns183;
using ns184;
using ns195;
using ns196;
using ns205;
using ns210;
using ns211;
using ns213;

namespace ns198;

internal class Class5313 : Class5299
{
	internal class Class5615
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal int int_4;

		internal Class5746 class5746_0;

		internal bool bool_0;

		internal bool bool_1;

		internal bool bool_2;

		internal Class5729 class5729_0;

		internal int int_5;

		internal int[][] int_6;

		private Class5313 class5313_0;

		internal Class5615(int startIndex, int breakIndex, int wordSpaceCount, int letterSpaceCount, Class5746 areaIPD, bool isHyphenated, bool isSpace, bool breakOppAfter, Class5729 font, int level, int[][] gposAdjustments, Class5313 parent)
		{
			int_0 = startIndex;
			int_1 = breakIndex;
			int_2 = -1;
			int_3 = wordSpaceCount;
			int_4 = letterSpaceCount;
			class5746_0 = areaIPD;
			bool_0 = isHyphenated;
			bool_1 = isSpace;
			bool_2 = breakOppAfter;
			class5729_0 = font;
			int_5 = level;
			int_6 = gposAdjustments;
			class5313_0 = parent;
		}

		internal int method_0()
		{
			if (int_2 == -1)
			{
				if (class5313_0.class5172_0.method_52(int_0, int_1))
				{
					int_2 = class5313_0.class5172_0.method_53(int_0, int_1).Length;
				}
				else
				{
					int_2 = int_1 - int_0;
				}
			}
			return int_2;
		}

		internal void method_1(Class5746 idp)
		{
			class5746_0 = class5746_0.method_6(idp);
		}

		public override string ToString()
		{
			return string.Concat(base.ToString(), "{interval = [", int_0, ",", int_1, "], isSpace = ", bool_1, ", level = ", int_5, ", areaIPD = ", class5746_0, ", letterSpaceCount = ", int_4, ", wordSpaceCount = ", int_3, ", isHyphenated = ", bool_0, ", font = ", class5729_0, "}");
		}
	}

	private class Class5616
	{
		internal Class5615 class5615_0;

		internal int int_0;

		internal Class5616(Class5615 areaInfo, int index)
		{
			class5615_0 = areaInfo;
			int_0 = index;
		}
	}

	private class Class5617
	{
		private Class5746 class5746_0;

		private int int_0;

		private Class5687 class5687_0;

		private int int_1;

		private int int_2;

		private bool bool_0;

		private Class5729 class5729_0;

		private Class4948 class4948_0;

		private int int_3;

		private Class5615 class5615_0;

		private StringBuilder stringBuilder_0;

		private int[] int_4;

		private int int_5;

		private int[] int_6;

		private int int_7;

		private int int_8;

		private int[][] int_9;

		private int int_10;

		private Class5313 class5313_0;

		internal Class5617(Class5746 width, int adjust, Class5687 context, int firstIndex, int lastIndex, bool isLastArea, Class5729 font, Class5313 parent)
		{
			class5746_0 = width;
			int_0 = adjust;
			class5687_0 = context;
			int_1 = firstIndex;
			int_2 = lastIndex;
			bool_0 = isLastArea;
			class5729_0 = font;
			class5313_0 = parent;
		}

		internal Class4948 method_0()
		{
			method_1();
			method_2();
			method_3();
			method_4();
			method_5();
			method_6();
			method_7();
			Class5677.smethod_18(class4948_0, class5729_0);
			class4948_0.method_29(Class5757.int_4, class5313_0.class5172_0.method_33());
			Class5677.smethod_19(class4948_0, class5313_0.class5172_0.method_40());
			Class5677.smethod_20(class4948_0, class5313_0.class5172_0.method_46());
			return class4948_0;
		}

		private void method_1()
		{
			if (class5687_0.method_40() == 0.0)
			{
				class4948_0 = new Class4948();
			}
			else
			{
				class4948_0 = new Class4948(class5746_0.method_5(), class5746_0.method_4(), int_0);
			}
		}

		private void method_2()
		{
			class4948_0.method_11(class5746_0.method_2() + int_0);
		}

		private void method_3()
		{
			int_3 = class5729_0.method_1() - class5729_0.method_3();
		}

		private void method_4()
		{
			class4948_0.method_13(int_3);
		}

		private void method_5()
		{
			class4948_0.method_59(class5729_0.method_1());
		}

		private void method_6()
		{
			if (int_3 == class5313_0.class5684_1.method_15())
			{
				class4948_0.method_41(0);
			}
			else
			{
				class4948_0.method_41(class5313_0.class5684_1.method_21());
			}
		}

		private void method_7()
		{
			int num = -1;
			int num2 = 0;
			for (int i = int_1; i <= int_2; i++)
			{
				class5615_0 = class5313_0.method_37(i);
				if (class5615_0.bool_1)
				{
					method_18();
					continue;
				}
				if (num == -1)
				{
					num = i;
					num2 = 0;
				}
				num2 += class5615_0.method_0();
				if (method_8(i))
				{
					method_9(num, i, num2);
					num = -1;
				}
			}
		}

		private bool method_8(int areaInfoIndex)
		{
			if (areaInfoIndex != int_2)
			{
				return class5313_0.method_37(areaInfoIndex + 1).bool_1;
			}
			return true;
		}

		private void method_9(int startIndex, int endIndex, int wordLength)
		{
			int blockProgressionOffseT = 0;
			bool flag = false;
			if (method_12(endIndex))
			{
				wordLength++;
			}
			method_11(wordLength);
			for (int i = startIndex; i <= endIndex; i++)
			{
				Class5615 wordAreaInfo = class5313_0.method_37(i);
				method_14(wordAreaInfo);
				method_16(wordAreaInfo);
				if (method_17(wordAreaInfo))
				{
					flag = true;
				}
			}
			if (method_12(endIndex))
			{
				method_13();
			}
			if (!flag)
			{
				int_9 = null;
			}
			class4948_0.method_63(stringBuilder_0.ToString(), int_8, int_4, method_10(), int_9, blockProgressionOffseT);
		}

		private int[] method_10()
		{
			if (int_6 != null)
			{
				bool flag = true;
				int i = 0;
				for (int num = int_7; i < num; i++)
				{
					if (int_6[i] >= 0)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					return int_6;
				}
				return null;
			}
			return null;
		}

		private void method_11(int wordLength)
		{
			stringBuilder_0 = new StringBuilder(wordLength);
			int_4 = new int[wordLength];
			int_5 = 0;
			int_6 = new int[wordLength];
			int_7 = 0;
			for (int i = 0; i < int_6.Length; i++)
			{
				int_6[i] = -1;
			}
			int_9 = new int[wordLength][];
			for (int j = 0; j < wordLength; j++)
			{
				int_9[j] = new int[4];
			}
			int_10 = 0;
			int_8 = 0;
		}

		private bool method_12(int endIndex)
		{
			if (bool_0 && endIndex == int_2)
			{
				return class5615_0.bool_0;
			}
			return false;
		}

		private void method_13()
		{
			stringBuilder_0.Append(class5313_0.class5172_0.method_32().method_0(class5729_0));
		}

		private void method_14(Class5615 wordAreaInfo)
		{
			int num = wordAreaInfo.int_0;
			int num2 = wordAreaInfo.int_1;
			if (class5313_0.class5172_0.method_52(num, num2))
			{
				stringBuilder_0.Append(class5313_0.class5172_0.method_53(num, num2));
				method_15(class5313_0.class5172_0.method_55(num, num2));
			}
			else
			{
				for (int i = num; i < num2; i++)
				{
					stringBuilder_0.Append(class5313_0.class5172_0.imethod_1(i));
				}
				method_15(class5313_0.class5172_0.method_49(num, num2));
			}
			int_8 += wordAreaInfo.class5746_0.method_2();
		}

		private void method_15(int[] levels)
		{
			int num = ((levels != null) ? levels.Length : 0);
			if (num > 0)
			{
				int num2 = int_7 + num;
				if (num2 > int_6.Length)
				{
					throw new InvalidOperationException("word levels array too short: expect at least " + num2 + " entries, but has only " + int_6.Length + " entries");
				}
				Array.Copy(levels, 0, int_6, int_7, num);
			}
			int_7 += num;
		}

		private void method_16(Class5615 wordAreaInfo)
		{
			int num = wordAreaInfo.int_4;
			int num2 = wordAreaInfo.method_0();
			int num3 = class4948_0.method_55();
			int i = 0;
			for (int num4 = num2; i < num4; i++)
			{
				int num5 = int_5 + i;
				if (num5 > 0)
				{
					int num6 = wordAreaInfo.int_0 + i;
					Class5746 obj = ((num6 < class5313_0.class5746_0.Length) ? class5313_0.class5746_0[num6] : null);
					int_4[num5] = obj?.method_2() ?? 0;
				}
				if (num > 0)
				{
					int_4[num5] += num3;
					num--;
				}
			}
			int_5 += num2;
		}

		private bool method_17(Class5615 wordAreaInfo)
		{
			bool result = false;
			int[][] array = wordAreaInfo.int_6;
			int num = ((array != null) ? array.Length : 0);
			int num2 = wordAreaInfo.method_0();
			if (num > 0)
			{
				int num3 = int_10 + num;
				if (num3 > int_9.Length)
				{
					throw new InvalidOperationException("gpos adjustments array too short: expect at least " + num3 + " entries, but has only " + int_9.Length + " entries");
				}
				int i = 0;
				int num4 = num2;
				int num5 = 0;
				for (; i < num4; i++)
				{
					if (i >= num)
					{
						continue;
					}
					int[] array2 = int_9[int_10 + i];
					int[] array3 = array[num5++];
					for (int j = 0; j < 4; j++)
					{
						int num6 = array3[j];
						if (num6 != 0)
						{
							array2[j] += num6;
							result = true;
						}
					}
				}
			}
			int_10 += num2;
			return result;
		}

		private void method_18()
		{
			int blockProgressionOffseT = 0;
			int num = 0;
			for (int i = class5615_0.int_0; i < class5615_0.int_1; i++)
			{
				char c = class5313_0.class5172_0.imethod_1(i);
				if (Class5710.smethod_2(c))
				{
					num++;
				}
			}
			int num2 = class5615_0.int_1 - class5615_0.int_0 - num;
			int ipD = class5615_0.class5746_0.method_2() / ((num2 <= 0) ? 1 : num2);
			for (int j = class5615_0.int_0; j < class5615_0.int_1; j++)
			{
				char c2 = class5313_0.class5172_0.imethod_1(j);
				int level = class5313_0.class5172_0.method_50(j);
				if (!Class5710.smethod_2(c2))
				{
					class4948_0.method_64(c2, ipD, Class5710.smethod_5(c2), blockProgressionOffseT, level);
				}
			}
		}
	}

	private static int int_2 = 1;

	private ArrayList arrayList_1;

	private static string string_0 = "-/";

	private Class5172 class5172_0;

	private Class5746[] class5746_0;

	private Class5729 class5729_0;

	private int int_3;

	private int int_4;

	private Class5746 class5746_1;

	private Class5746 class5746_2;

	private int int_5;

	private bool bool_4;

	private int[] int_6 = new int[2];

	private int int_7;

	private int int_8;

	private int int_9;

	private ArrayList arrayList_2 = new ArrayList();

	internal Class5684 class5684_1;

	private int int_10;

	private int int_11;

	private bool bool_5;

	private Class5254 class5254_0;

	public Class5313(Class5172 node)
	{
		class5254_0 = new Class5258(this, -1);
		class5172_0 = node;
		class5746_0 = new Class5746[node.imethod_0() + 1];
		arrayList_1 = new ArrayList();
	}

	private Class5342 method_31(int penaltyValue)
	{
		return new Class5342(0, penaltyValue, penaltyFlagged: false, class5254_0, auxiliary: true);
	}

	private Class5338 method_32()
	{
		return new Class5339(0, null, imethod_22(new Class5258(this, -1)), auxiliary: true);
	}

	public override void imethod_3()
	{
		class5172_0.method_45();
		class5729_0 = Class5603.smethod_2(' ', class5172_0, this);
		int_4 = class5729_0.method_16(' ');
		int_5 = class5172_0.method_32().method_1(class5729_0);
		Class5697 @class = Class5697.smethod_2(class5172_0.method_35());
		Class5697 class2 = Class5697.smethod_1(class5172_0.method_38(), @class, class5729_0);
		class5746_2 = @class.method_3();
		class5746_1 = Class5746.smethod_1(int_4).method_6(class2.method_3());
		bool_5 = class5172_0.method_34().method_6().imethod_0() == 7;
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		int num = 0;
		int num2 = 0;
		int firstAreaInfoIndex = -1;
		int lastAreaInfoIndex = 0;
		Class5746 @class = Class5746.class5746_0;
		Class5615 class2 = null;
		while (posIter.imethod_0())
		{
			Class5258 class3 = (Class5258)posIter.imethod_1();
			if (class3 == null || class3.method_6() == -1)
			{
				continue;
			}
			Class5615 class4 = (Class5615)arrayList_1[class3.method_6()];
			if (class2 == null || class4.class5729_0 != class2.class5729_0 || class4.int_5 != class2.int_5)
			{
				if (class2 != null)
				{
					method_33(class2, num, num2, firstAreaInfoIndex, lastAreaInfoIndex, @class, context);
				}
				firstAreaInfoIndex = class3.method_6();
				num = 0;
				num2 = 0;
				@class = Class5746.class5746_0;
			}
			num += class4.int_3;
			num2 += class4.int_4;
			@class = @class.method_6(class4.class5746_0);
			lastAreaInfoIndex = class3.method_6();
			class2 = class4;
		}
		if (class2 != null)
		{
			method_33(class2, num, num2, firstAreaInfoIndex, lastAreaInfoIndex, @class, context);
		}
	}

	private void method_33(Class5615 areaInfo, int wordSpaceCount, int letterSpaceCount, int firstAreaInfoIndex, int lastAreaInfoIndex, Class5746 realWidth, Class5687 context)
	{
		int num = areaInfo.method_0();
		if (areaInfo.int_4 == num && !areaInfo.bool_0 && context.method_7())
		{
			realWidth = realWidth.method_8(class5746_2);
			letterSpaceCount--;
		}
		for (int i = areaInfo.int_0; i < areaInfo.int_1; i++)
		{
			Class5746 @class = class5746_0[i + 1];
			if (@class != null && @class.method_18())
			{
				letterSpaceCount++;
			}
		}
		if (context.method_7() && areaInfo.bool_0)
		{
			realWidth = realWidth.method_7(int_5);
		}
		double num2 = context.method_40();
		int num3 = ((!(num2 > 0.0)) ? ((int)((double)realWidth.method_4() * num2)) : ((int)((double)realWidth.method_5() * num2)));
		int num4 = class5746_2.method_2();
		num4 = ((!(num2 > 0.0)) ? (num4 + (int)((double)class5746_2.method_4() * num2)) : (num4 + (int)((double)class5746_2.method_5() * num2)));
		int num5 = (num4 - class5746_2.method_2()) * letterSpaceCount;
		int num6 = class5746_1.method_2();
		if (wordSpaceCount > 0)
		{
			num6 += (num3 - num5) / wordSpaceCount;
		}
		num5 += (num6 - class5746_1.method_2()) * wordSpaceCount;
		if (num5 != num3)
		{
			num5 = num3;
		}
		Class4948 class2 = new Class5617(realWidth, num5, context, firstAreaInfoIndex, lastAreaInfoIndex, context.method_7(), areaInfo.class5729_0, this).method_0();
		class2.method_56(num4);
		class2.method_54(num6 - int_4 - 2 * class2.method_55());
		if (context.method_40() != 0.0)
		{
			class2.method_57(class5746_1.method_2() - int_4 - 2 * class2.method_55());
		}
		interface173_0.imethod_8(class2);
	}

	private void method_34(Class5615 ai)
	{
		method_35(arrayList_1.Count, ai);
	}

	private void method_35(int index, Class5615 ai)
	{
		arrayList_1.Insert(index, ai);
	}

	private void method_36(int index)
	{
		arrayList_1.Remove(index);
	}

	internal Class5615 method_37(int index)
	{
		return (Class5615)arrayList_1[index];
	}

	private void method_38(int index, int width)
	{
		if (class5746_0[index] == null)
		{
			class5746_0[index] = Class5746.smethod_1(width);
		}
		else
		{
			class5746_0[index] = class5746_0[index].method_7(width);
		}
	}

	private static bool smethod_1(char ch)
	{
		if (ch != ' ' && !Class5710.smethod_4(ch))
		{
			return Class5710.smethod_3(ch);
		}
		return true;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		int_10 = context.method_44();
		int_11 = context.method_46();
		class5684_1 = context.method_42();
		ArrayList arrayList = new ArrayList();
		Class5274 @class = new Class5277();
		Class5615 class2 = null;
		Class5615 prevAreaInfo = null;
		arrayList.Add(@class);
		Class5613 class3 = new Class5613();
		int_8 = int_3;
		bool flag = false;
		bool flag2 = false;
		char c = '\0';
		int num = -1;
		int num2 = -1;
		while (int_3 < class5172_0.imethod_0())
		{
			c = class5172_0.imethod_1(int_3);
			num = class5172_0.method_50(int_3);
			bool flag3 = false;
			byte b = (byte)(bool_5 ? 4 : class3.method_1(c));
			switch (b)
			{
			case 0:
			case 1:
			case 2:
				flag3 = true;
				break;
			}
			if (flag)
			{
				if (flag3 || smethod_1(c) || Class5710.smethod_7(c) || (num2 != -1 && num != num2))
				{
					prevAreaInfo = method_45(alignment, @class, prevAreaInfo, c, flag3, checkEndsWithHyphen: true, num2);
				}
			}
			else if (flag2)
			{
				if (c != ' ' || flag3)
				{
					prevAreaInfo = method_41(alignment, @class, flag3, num2);
				}
			}
			else
			{
				if (class2 != null)
				{
					prevAreaInfo = class2;
					method_40(alignment, @class, class2, c == ' ' || flag3);
					class2 = null;
				}
				if (b == 5)
				{
					@class = method_39(arrayList, @class);
				}
			}
			if ((c == ' ' && class5172_0.method_37() == 108) || c == '\u00a0')
			{
				class2 = new Class5615(int_3, int_3 + 1, 1, 0, class5746_1, isHyphenated: false, isSpace: true, flag3, class5729_0, num, null, this);
				int_8 = int_3 + 1;
			}
			else if (!Class5710.smethod_3(c) && !Class5710.smethod_2(c))
			{
				if (Class5710.smethod_7(c))
				{
					int_8 = int_3 + 1;
				}
			}
			else
			{
				Class5729 class4 = Class5603.smethod_2(c, class5172_0, this);
				Class5746 areaIPD = Class5746.smethod_1(class4.method_16(c));
				class2 = new Class5615(int_3, int_3 + 1, 0, 0, areaIPD, isHyphenated: false, isSpace: true, flag3, class4, num, null, this);
				int_8 = int_3 + 1;
			}
			flag = !smethod_1(c) && !Class5710.smethod_7(c);
			flag2 = c == ' ' && class5172_0.method_37() != 108;
			num2 = num;
			int_3++;
		}
		if (flag)
		{
			method_45(alignment, @class, prevAreaInfo, c, breakOpportunity: false, checkEndsWithHyphen: false, num2);
		}
		else if (flag2)
		{
			method_41(alignment, @class, !bool_5, num2);
		}
		else if (class2 != null)
		{
			method_40(alignment, @class, class2, c == '\u200b');
		}
		else if (Class5710.smethod_7(c))
		{
			method_39(arrayList, @class);
		}
		if (((ArrayList)Class5693.smethod_0(arrayList)).Count == 0)
		{
			Class5693.smethod_1(arrayList);
		}
		imethod_6(fin: true);
		if (arrayList.Count == 0)
		{
			return null;
		}
		return arrayList;
	}

	private Class5274 method_39(ArrayList returnList, Class5274 sequence)
	{
		if (int_11 != 0)
		{
			sequence.Add(new Class5344(int_11, 0, 0, class5254_0, auxiliary: true));
		}
		sequence.vmethod_1();
		sequence = new Class5277();
		returnList.Add(sequence);
		return sequence;
	}

	private void method_40(int alignment, Class5274 sequence, Class5615 areaInfo, bool breakOpportunityAfter)
	{
		method_34(areaInfo);
		areaInfo.bool_2 = breakOpportunityAfter;
		method_46(sequence, alignment, areaInfo, arrayList_1.Count - 1);
	}

	private Class5615 method_41(int alignment, Class5274 sequence, bool breakOpportunity, int level)
	{
		Class5615 @class = new Class5615(int_8, int_3, int_3 - int_8, 0, class5746_1.method_15(int_3 - int_8), isHyphenated: false, isSpace: true, breakOpportunity, class5729_0, level, null, this);
		method_34(@class);
		method_46(sequence, alignment, @class, arrayList_1.Count - 1);
		int_8 = int_3;
		return @class;
	}

	private Class5615 method_42(int lastIndex, Class5729 font, Class5615 prevAreaInfo, char breakOpportunityChar, bool endsWithHyphen, int level)
	{
		int num = int_8;
		int letterSpaceCount = 0;
		string text = class5172_0.method_44();
		string text2 = class5172_0.method_43();
		Interface238 @interface = class5172_0.imethod_2(num, lastIndex);
		if (text == null || "auto".Equals(text))
		{
			text = Class5594.smethod_36(Class5594.smethod_33(@interface));
		}
		if (text2 == null || "none".Equals(text2))
		{
			text2 = "dflt";
		}
		Interface238 interface2 = font.imethod_1(@interface, text, text2);
		int[][] array = (font.imethod_3() ? font.imethod_5(interface2, text, text2) : ((!font.method_9()) ? null : method_43(interface2, font)));
		interface2 = font.imethod_2(interface2, array, text, text2);
		if (!Class5710.smethod_12(interface2, @interface))
		{
			class5172_0.method_51(num, lastIndex, interface2);
		}
		Class5746 @class = Class5746.class5746_0;
		int i = 0;
		for (int num2 = interface2.imethod_0(); i < num2; i++)
		{
			int c = interface2.imethod_1(i);
			int num3 = font.method_17(c);
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (array != null)
			{
				num3 += array[i][Class5566.Class5605.int_10];
			}
			@class = @class.method_7(num3);
		}
		return new Class5615(num, lastIndex, 0, letterSpaceCount, @class, endsWithHyphen, isSpace: false, breakOpportunityChar != '\0', font, level, array, this);
	}

	private int[][] method_43(Interface238 mcs, Class5729 font)
	{
		int num = mcs.imethod_0();
		int[] array = new int[num];
		int i = 0;
		int num2 = num;
		int num3 = -1;
		for (; i < num2; i++)
		{
			int num4 = mcs.imethod_1(i);
			if (num3 >= 0)
			{
				array[i] = font.method_12(num3, num4);
			}
			num3 = num4;
		}
		bool flag = false;
		int j = 0;
		for (int num5 = num; j < num5; j++)
		{
			if (array[j] != 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			int[][] array2 = new int[num][];
			for (int k = 0; k < num; k++)
			{
				array2[k] = new int[4];
			}
			int l = 0;
			for (int num6 = num; l < num6; l++)
			{
				if (l > 0)
				{
					array2[l - 1][Class5566.Class5605.int_10] = array[l];
				}
			}
			return array2;
		}
		return null;
	}

	private Class5615 method_44(int lastIndex, Class5729 font, Class5615 prevAreaInfo, char breakOpportunityChar, bool endsWithHyphen, int level)
	{
		bool flag = font.method_9();
		Class5746 @class = Class5746.class5746_0;
		for (int i = int_8; i < lastIndex; i++)
		{
			char c = class5172_0.imethod_1(i);
			int value = font.method_16(c);
			@class = @class.method_7(value);
			if (flag)
			{
				int num = 0;
				if (i > int_8)
				{
					char ch = class5172_0.imethod_1(i - 1);
					num = font.method_11(ch, c);
				}
				else if (prevAreaInfo != null && !prevAreaInfo.bool_1 && prevAreaInfo.int_1 > 0)
				{
					char ch2 = class5172_0.imethod_1(prevAreaInfo.int_1 - 1);
					num = font.method_11(ch2, c);
				}
				if (num != 0)
				{
					method_38(i, num);
					@class = @class.method_7(num);
				}
			}
		}
		if (flag && breakOpportunityChar != 0 && !smethod_1(breakOpportunityChar) && lastIndex > 0 && endsWithHyphen)
		{
			int num2 = font.method_11(class5172_0.imethod_1(lastIndex - 1), breakOpportunityChar);
			if (num2 != 0)
			{
				method_38(lastIndex, num2);
			}
		}
		int num3 = lastIndex - int_8;
		int num4 = 0;
		if (num3 != 0)
		{
			num4 = num3 - 1;
			if (breakOpportunityChar != 0 && !smethod_1(breakOpportunityChar))
			{
				num4++;
			}
		}
		@class = @class.method_6(class5746_2.method_15(num4));
		return new Class5615(int_8, lastIndex, 0, num4, @class, endsWithHyphen, isSpace: false, breakOpportunityChar != '\0', font, level, null, this);
	}

	private Class5615 method_45(int alignment, Class5274 sequence, Class5615 prevAreaInfo, char ch, bool breakOpportunity, bool checkEndsWithHyphen, int level)
	{
		int num = int_3;
		while (num > 0 && class5172_0.imethod_1(num - 1) == '\u00ad')
		{
			num--;
		}
		bool endsWithHyphen = checkEndsWithHyphen && class5172_0.imethod_1(num) == '\u00ad';
		Class5729 @class = Class5603.smethod_3(class5172_0, int_8, num, class5172_0, this);
		Class5615 class2 = ((@class.imethod_0() || @class.imethod_3()) ? method_42(num, @class, prevAreaInfo, breakOpportunity ? ch : '\0', endsWithHyphen, level) : method_44(num, @class, prevAreaInfo, breakOpportunity ? ch : '\0', endsWithHyphen, level));
		prevAreaInfo = class2;
		method_34(class2);
		int_9 = int_3;
		method_49(sequence, alignment, class2, arrayList_1.Count - 1);
		int_8 = int_3;
		return prevAreaInfo;
	}

	public override ArrayList imethod_27(ArrayList oldList)
	{
		return imethod_28(oldList, 0);
	}

	public override ArrayList imethod_28(ArrayList oldList, int depth)
	{
		Interface168 @interface = new Class5495(oldList);
		Class5337 @class = (Class5337)@interface.imethod_1();
		Class5254 class2 = @class.method_0();
		Class5258 class3 = (Class5258)class2.method_2(depth);
		int num = class3.method_6();
		if (num > -1)
		{
			Class5615 class4 = method_37(num);
			class4.int_4++;
			class4.method_1(class5746_2);
			if (string_0.IndexOf(class5172_0.imethod_1(int_9 - 1)) >= 0)
			{
				@interface = new Class5495(oldList, oldList.Count);
				@interface.imethod_8(new Class5342(0, Class5342.int_2, penaltyFlagged: true, class5254_0, auxiliary: false));
				@interface.imethod_8(new Class5344(class5746_2, class5254_0, auxiliary: false));
			}
			else if (class5746_2.method_17())
			{
				try
				{
					@interface.imethod_7(new Class5339(class4.class5746_0.method_2(), class5684_1, class2, auxiliary: false));
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				@interface.imethod_1();
				@interface.imethod_1();
				@interface.imethod_7(new Class5344(class5746_2.method_15(class4.int_4), class5254_0, auxiliary: true));
			}
		}
		return oldList;
	}

	public override void imethod_30(Class5254 pos, Class5685 hyphContext)
	{
		Class5615 @class = method_37(((Class5258)pos).method_6() + int_7);
		int num = @class.int_0;
		bool flag = true;
		Class5729 class2 = @class.class5729_0;
		while (num < @class.int_1)
		{
			Class5746 class3 = Class5746.class5746_0;
			int num2 = num + hyphContext.method_0();
			bool flag2;
			if (hyphContext.method_1() && num2 <= @class.int_1)
			{
				flag2 = true;
			}
			else
			{
				flag2 = false;
				num2 = @class.int_1;
			}
			hyphContext.method_2(num2 - num);
			for (int i = num; i < num2; i++)
			{
				char c = class5172_0.imethod_1(i);
				class3 = class3.method_7(class2.method_16(c));
				if (i < num2)
				{
					Class5746 class4 = class5746_0[i + 1];
					if (i == num2 - 1 && flag2)
					{
						class4 = null;
					}
					if (class4 != null)
					{
						class3 = class3.method_6(class4);
					}
				}
			}
			int num3 = ((num2 == @class.int_1 && @class.int_4 < @class.method_0()) ? (num2 - num - 1) : (num2 - num));
			class3 = class3.method_6(class5746_2.method_15(num3));
			if (!flag || num2 != @class.int_1 || flag2)
			{
				arrayList_2.Add(new Class5616(new Class5615(num, num2, 0, num3, class3, flag2, isSpace: false, breakOppAfter: false, class2, -1, null, this), ((Class5258)pos).method_6() + int_7));
				flag = false;
			}
			num = num2;
		}
		bool_4 |= !flag;
	}

	public override bool imethod_31(ArrayList oldList)
	{
		return imethod_32(oldList, 0);
	}

	public override bool imethod_32(ArrayList oldList, int depth)
	{
		imethod_6(fin: false);
		if (oldList.Count == 0)
		{
			return false;
		}
		Class5258 @class = null;
		Class5258 class2 = null;
		Interface168 @interface = new Class5495(oldList);
		while (@interface.imethod_0())
		{
			Class5254 class3 = ((Class5337)@interface.imethod_1()).method_0();
			@class = (Class5258)class3.method_2(depth);
			if (@class != null && @class.method_6() != -1)
			{
				break;
			}
		}
		@interface = new Class5495(oldList, oldList.Count);
		while (@interface.imethod_2())
		{
			Class5254 class4 = ((Class5337)@interface.imethod_3()).method_0();
			class2 = (Class5258)class4.method_2(depth);
			if (class2 != null && class2.method_6() != -1)
			{
				break;
			}
		}
		int_6[0] = (@class?.method_6() ?? (-1)) + int_7;
		int_6[1] = (class2?.method_6() ?? (-1)) + int_7;
		int num = 0;
		int num2 = 0;
		if (arrayList_2.Count != 0)
		{
			int num3 = -1;
			Interface168 interface2 = new Class5495(arrayList_2);
			while (interface2.imethod_0())
			{
				Class5616 class5 = (Class5616)interface2.imethod_1();
				int index;
				if (class5.int_0 == num3)
				{
					num++;
					index = class5.int_0 + num - num2;
				}
				else
				{
					num2++;
					num++;
					num3 = class5.int_0;
					index = class5.int_0 + num - num2;
					method_36(index);
				}
				method_35(index, class5.class5615_0);
			}
			arrayList_2.Clear();
		}
		int_6[1] += num - num2;
		int_7 += num - num2;
		return bool_4;
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		if (imethod_5())
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		while (int_6[0] <= int_6[1])
		{
			Class5615 @class = method_37(int_6[0]);
			if (@class.int_3 == 0)
			{
				method_49(arrayList, alignment, @class, int_6[0]);
			}
			else
			{
				method_46(arrayList, alignment, @class, int_6[0]);
			}
			int_6[0]++;
		}
		imethod_6(int_6[0] == arrayList_1.Count - 1);
		return arrayList;
	}

	public override string imethod_29(Class5254 pos)
	{
		int num = ((Class5258)pos).method_6() + int_7;
		if (num != -1)
		{
			Class5615 @class = method_37(num);
			StringBuilder stringBuilder = new StringBuilder(@class.method_0());
			for (int i = @class.int_0; i < @class.int_1; i++)
			{
				stringBuilder.Append(class5172_0.imethod_1(i));
			}
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	private void method_46(ArrayList baseList, int alignment, Class5615 areaInfo, int leafValue)
	{
		Class5258 @class = new Class5258(this, leafValue);
		if (!areaInfo.bool_2)
		{
			if (alignment == 70)
			{
				baseList.Add(method_32());
				baseList.Add(method_31(Class5337.int_0));
				baseList.Add(new Class5344(areaInfo.class5746_0, @class, auxiliary: false));
			}
			else
			{
				baseList.Add(new Class5339(areaInfo.class5746_0.method_2(), null, @class, auxiliary: true));
			}
		}
		else if (class5172_0.imethod_1(areaInfo.int_0) == ' ' && class5172_0.method_37() != 108)
		{
			baseList.AddRange(method_47(alignment, areaInfo, @class, areaInfo.class5746_0.method_2(), class5254_0, 0, skipZeroCheck: false));
		}
		else
		{
			baseList.AddRange(method_47(alignment, areaInfo, class5254_0, 0, @class, areaInfo.class5746_0.method_2(), skipZeroCheck: true));
		}
	}

	private ArrayList method_47(int alignment, Class5615 areaInfo, Class5254 pos2, int p2WidthOffset, Class5254 pos3, int p3WidthOffset, bool skipZeroCheck)
	{
		ArrayList arrayList = new ArrayList();
		switch ((Enum679)alignment)
		{
		case Enum679.const_24:
			arrayList.Add(new Class5344(int_11, 3 * Class5319.int_2, 0, class5254_0, auxiliary: false));
			arrayList.Add(method_31(0));
			arrayList.Add(new Class5344(p2WidthOffset - (int_10 + int_11), -6 * Class5319.int_2, 0, pos2, auxiliary: false));
			arrayList.Add(method_32());
			arrayList.Add(method_31(Class5337.int_0));
			arrayList.Add(new Class5344(int_10 + p3WidthOffset, 3 * Class5319.int_2, 0, pos3, auxiliary: false));
			break;
		default:
			arrayList.AddRange(method_48(areaInfo, pos2, p2WidthOffset, pos3, p3WidthOffset, skipZeroCheck, 0));
			break;
		case Enum679.const_40:
		case Enum679.const_222:
			if (!skipZeroCheck && int_10 == 0 && int_11 == 0)
			{
				Class5344 value = new Class5344(0, 3 * Class5319.int_2, 0, class5254_0, auxiliary: false);
				arrayList.Add(value);
				arrayList.Add(method_31(0));
				value = new Class5344(areaInfo.class5746_0.method_2(), -3 * Class5319.int_2, 0, pos2, auxiliary: false);
				arrayList.Add(value);
			}
			else
			{
				Class5344 value = new Class5344(int_11, 3 * Class5319.int_2, 0, class5254_0, auxiliary: false);
				arrayList.Add(value);
				arrayList.Add(method_31(0));
				value = new Class5344(p2WidthOffset - (int_10 + int_11), -3 * Class5319.int_2, 0, pos2, auxiliary: false);
				arrayList.Add(value);
				arrayList.Add(method_32());
				arrayList.Add(method_31(Class5337.int_0));
				value = new Class5344(int_10 + p3WidthOffset, 0, 0, pos3, auxiliary: false);
				arrayList.Add(value);
			}
			break;
		case Enum679.const_71:
			arrayList.AddRange(method_48(areaInfo, pos2, p2WidthOffset, pos3, p3WidthOffset, skipZeroCheck, areaInfo.class5746_0.method_4()));
			break;
		}
		return arrayList;
	}

	private ArrayList method_48(Class5615 areaInfo, Class5254 pos2, int p2WidthOffset, Class5254 pos3, int p3WidthOffset, bool skipZeroCheck, int shrinkability)
	{
		int stretch = areaInfo.class5746_0.method_5();
		ArrayList arrayList = new ArrayList();
		if (!skipZeroCheck && int_10 == 0 && int_11 == 0)
		{
			arrayList.Add(new Class5344(areaInfo.class5746_0.method_2(), stretch, shrinkability, pos2, auxiliary: false));
		}
		else
		{
			arrayList.Add(new Class5344(int_11, 0, 0, class5254_0, auxiliary: false));
			arrayList.Add(method_31(0));
			arrayList.Add(new Class5344(p2WidthOffset - (int_10 + int_11), stretch, shrinkability, pos2, auxiliary: false));
			arrayList.Add(method_32());
			arrayList.Add(method_31(Class5337.int_0));
			arrayList.Add(new Class5344(int_10 + p3WidthOffset, 0, 0, pos3, auxiliary: false));
		}
		return arrayList;
	}

	private void method_49(ArrayList baseList, int alignment, Class5615 areaInfo, int leafValue)
	{
		Class5258 pos = new Class5258(this, leafValue);
		bool flag = areaInfo.bool_2 && !areaInfo.bool_0;
		if (class5746_2.method_17())
		{
			baseList.Add(new Class5339(flag ? (areaInfo.class5746_0.method_2() - class5746_2.method_2()) : areaInfo.class5746_0.method_2(), class5684_1, imethod_22(pos), auxiliary: false));
		}
		else
		{
			int factor = (flag ? (areaInfo.int_4 - 1) : areaInfo.int_4);
			baseList.Add(new Class5339(areaInfo.class5746_0.method_2() - areaInfo.int_4 * class5746_2.method_2(), class5684_1, imethod_22(pos), auxiliary: false));
			baseList.Add(method_31(Class5337.int_0));
			baseList.Add(new Class5344(class5746_2.method_15(factor), class5254_0, auxiliary: true));
			baseList.Add(method_32());
		}
		if (areaInfo.bool_0)
		{
			Class5746 widthIfNoBreakOccurs = null;
			if (areaInfo.int_1 < class5172_0.imethod_0())
			{
				widthIfNoBreakOccurs = class5746_0[areaInfo.int_1];
			}
			method_50(baseList, alignment, int_5, widthIfNoBreakOccurs, areaInfo.bool_2 && areaInfo.bool_0);
		}
		else if (flag)
		{
			method_50(baseList, alignment, 0, class5746_2, unflagged: true);
		}
	}

	private void method_50(ArrayList baseList, int alignment, int widthIfBreakOccurs, Class5746 widthIfNoBreakOccurs, bool unflagged)
	{
		if (widthIfNoBreakOccurs == null)
		{
			widthIfNoBreakOccurs = Class5746.class5746_0;
		}
		switch ((Enum679)alignment)
		{
		case Enum679.const_40:
		case Enum679.const_222:
			if (int_10 == 0 && int_11 == 0)
			{
				baseList.Add(method_31(Class5337.int_0));
				baseList.Add(new Class5344(0, 3 * Class5319.int_2, 0, class5254_0, auxiliary: false));
				baseList.Add(new Class5342(widthIfBreakOccurs, unflagged ? int_2 : Class5342.int_2, !unflagged, class5254_0, auxiliary: false));
				baseList.Add(new Class5344(widthIfNoBreakOccurs.method_2(), -3 * Class5319.int_2, 0, class5254_0, auxiliary: false));
			}
			else
			{
				baseList.Add(method_31(Class5337.int_0));
				baseList.Add(new Class5344(int_11, 3 * Class5319.int_2, 0, class5254_0, auxiliary: false));
				baseList.Add(new Class5342(widthIfBreakOccurs, unflagged ? int_2 : Class5342.int_2, !unflagged, class5254_0, auxiliary: false));
				baseList.Add(new Class5344(widthIfNoBreakOccurs.method_2() - (int_10 + int_11), -3 * Class5319.int_2, 0, class5254_0, auxiliary: false));
				baseList.Add(method_32());
				baseList.Add(method_31(Class5337.int_0));
				baseList.Add(new Class5344(int_10, 0, 0, class5254_0, auxiliary: false));
			}
			return;
		case Enum679.const_24:
			baseList.Add(method_31(Class5337.int_0));
			baseList.Add(new Class5344(int_11, 3 * Class5319.int_2, 0, class5254_0, auxiliary: true));
			baseList.Add(new Class5342(int_5, unflagged ? int_2 : Class5342.int_2, !unflagged, class5254_0, auxiliary: false));
			baseList.Add(new Class5344(-(int_11 + int_10), -6 * Class5319.int_2, 0, class5254_0, auxiliary: false));
			baseList.Add(method_32());
			baseList.Add(method_31(Class5337.int_0));
			baseList.Add(new Class5344(int_10, 3 * Class5319.int_2, 0, class5254_0, auxiliary: true));
			return;
		}
		if (int_10 == 0 && int_11 == 0)
		{
			baseList.Add(new Class5342(widthIfBreakOccurs, unflagged ? int_2 : Class5342.int_2, !unflagged, class5254_0, auxiliary: false));
			if (widthIfNoBreakOccurs.method_16())
			{
				baseList.Add(new Class5344(widthIfNoBreakOccurs, class5254_0, auxiliary: false));
			}
			return;
		}
		baseList.Add(method_31(Class5337.int_0));
		baseList.Add(new Class5344(int_11, 0, 0, class5254_0, auxiliary: false));
		baseList.Add(new Class5342(widthIfBreakOccurs, unflagged ? int_2 : Class5342.int_2, !unflagged, class5254_0, auxiliary: false));
		if (widthIfNoBreakOccurs.method_16())
		{
			baseList.Add(new Class5344(widthIfNoBreakOccurs.method_2() - (int_10 + int_11), widthIfNoBreakOccurs.method_5(), widthIfNoBreakOccurs.method_4(), class5254_0, auxiliary: false));
		}
		else
		{
			baseList.Add(new Class5344(-(int_10 + int_11), 0, 0, class5254_0, auxiliary: false));
		}
		baseList.Add(method_32());
		baseList.Add(method_31(Class5337.int_0));
		baseList.Add(new Class5344(int_10, 0, 0, class5254_0, auxiliary: false));
	}

	public override string ToString()
	{
		return base.ToString() + "{chars = '" + Class5710.smethod_9(class5172_0.method_25().ToString()) + "', len = " + class5172_0.imethod_0() + "}";
	}
}

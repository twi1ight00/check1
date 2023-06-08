using System;
using System.Text;
using ns171;
using ns176;
using ns184;
using ns205;

namespace ns198;

internal class Class5684
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private Class5694 class5694_0;

	private Class5694 class5694_1;

	private Class5684 class5684_0;

	public int AlignmentPoint
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	internal Class5684(int height, Interface182 alignmentAdjust, int alignmentBaseline, Interface182 baselineShift, int dominantBaseline, Class5684 parentAlignmentContext)
		: this(height, 0, height, height, alignmentAdjust, alignmentBaseline, baselineShift, dominantBaseline, parentAlignmentContext)
	{
	}

	internal Class5684(Class5729 font, int lineHeight, Interface182 alignmentAdjust, int alignmentBaseline, Interface182 baselineShift, int dominantBaseline, Class5684 parentAlignmentContext)
		: this(font.method_1(), font.method_3(), lineHeight, font.method_8(), alignmentAdjust, alignmentBaseline, baselineShift, dominantBaseline, parentAlignmentContext)
	{
	}

	private Class5684(int altitude, int depth, int lineHeight, int xHeight, Interface182 alignmentAdjust, int alignmentBaseline, Interface182 baselineShift, int dominantBaseline, Class5684 parentAlignmentContext)
	{
		int_0 = altitude - depth;
		int_1 = lineHeight;
		int_5 = xHeight;
		class5684_0 = parentAlignmentContext;
		class5694_0 = parentAlignmentContext.method_5();
		method_3(alignmentBaseline, parentAlignmentContext.method_6());
		method_7(baselineShift);
		int dominantBaselineIdentifier = parentAlignmentContext.method_6();
		bool flag = false;
		if (int_3 != 0)
		{
			flag = true;
		}
		switch ((Enum679)dominantBaseline)
		{
		case Enum679.const_10:
			flag = int_3 != 0;
			break;
		default:
			flag = true;
			dominantBaselineIdentifier = dominantBaseline;
			break;
		case Enum679.const_203:
			flag = true;
			break;
		case Enum679.const_174:
		case Enum679.const_244:
			break;
		}
		class5694_1 = new Class5694(altitude, depth, xHeight, dominantBaselineIdentifier, class5694_0.method_1());
		if (flag)
		{
			class5694_0 = new Class5694(altitude, depth, xHeight, dominantBaselineIdentifier, class5694_0.method_1());
		}
		method_4(alignmentAdjust);
	}

	internal Class5684(Class5729 font, int lineHeight, Class5445 writingMode)
	{
		int_0 = font.method_1() - font.method_3();
		int_1 = lineHeight;
		int_5 = font.method_8();
		class5694_0 = new Class5694(font.method_1(), font.method_3(), font.method_8(), 6, writingMode);
		class5694_1 = class5694_0;
		int_4 = method_6();
		int_2 = font.method_1();
		int_3 = 0;
	}

	public int method_0()
	{
		return int_2;
	}

	public int method_1()
	{
		return int_3;
	}

	public int method_2()
	{
		return int_4;
	}

	private void method_3(int alignmentBaseline, int parentDominantBaselineIdentifier)
	{
		switch ((Enum679)alignmentBaseline)
		{
		case Enum679.const_10:
		case Enum679.const_13:
			int_4 = parentDominantBaselineIdentifier;
			break;
		default:
			throw new ArgumentException(alignmentBaseline.ToString());
		case Enum679.const_5:
		case Enum679.const_7:
		case Enum679.const_15:
		case Enum679.const_25:
		case Enum679.const_57:
		case Enum679.const_60:
		case Enum679.const_169:
		case Enum679.const_171:
		case Enum679.const_228:
		case Enum679.const_229:
			int_4 = alignmentBaseline;
			break;
		}
	}

	private void method_4(Interface182 alignmentAdjust)
	{
		int num = class5694_1.method_2(14);
		switch ((Enum679)alignmentAdjust.imethod_0())
		{
		case Enum679.const_10:
			int_2 = num - class5694_1.method_2(int_4);
			break;
		case Enum679.const_13:
			int_2 = num;
			break;
		default:
			int_2 = num + alignmentAdjust.imethod_6(new Class5753(null, 12, int_1));
			break;
		case Enum679.const_5:
		case Enum679.const_7:
		case Enum679.const_15:
		case Enum679.const_25:
		case Enum679.const_57:
		case Enum679.const_60:
		case Enum679.const_169:
		case Enum679.const_171:
		case Enum679.const_228:
		case Enum679.const_229:
			int_2 = num - class5694_1.method_2(alignmentAdjust.imethod_0());
			break;
		}
	}

	private Class5694 method_5()
	{
		return class5694_0;
	}

	private int method_6()
	{
		return class5694_1.method_0();
	}

	private void method_7(Interface182 baselineShift)
	{
		int_3 = 0;
		switch ((Enum679)baselineShift.imethod_0())
		{
		default:
			throw new ArgumentException(baselineShift.imethod_0().ToString());
		case Enum679.const_224:
			int_3 = (int)Math.Round((double)(-(int_5 / 2) + class5684_0.method_13(6)));
			break;
		case Enum679.const_225:
			int_3 = (int)Math.Round((double)(class5684_0.method_19() + class5684_0.method_13(6)));
			break;
		case Enum679.const_13:
			break;
		case Enum679.const_0:
			int_3 = baselineShift.imethod_6(new Class5753(null, 0, class5684_0.method_16()));
			break;
		}
	}

	public Class5684 method_8()
	{
		return class5684_0;
	}

	private int method_9()
	{
		if (class5684_0 == null)
		{
			return 0;
		}
		return class5684_0.method_5().method_2(int_4) - class5694_0.method_6(class5684_0.method_6()).method_2(int_4) - class5694_0.method_2(class5684_0.method_6()) + int_3;
	}

	private int method_10()
	{
		int result = 0;
		if (class5684_0 != null)
		{
			result = method_9() + class5684_0.method_10();
		}
		return result;
	}

	public int method_11()
	{
		return method_12(int_4);
	}

	private int method_12(int alignmentBaselineId)
	{
		int result = int_3;
		if (class5684_0 != null)
		{
			result = class5684_0.method_10() + class5684_0.method_5().method_2(alignmentBaselineId) + int_3;
		}
		return result;
	}

	private int method_13(int baselineIdentifier)
	{
		int num = method_11() - method_10();
		return num + class5694_1.method_6(int_4).method_2(baselineIdentifier);
	}

	private int method_14()
	{
		return method_11() + method_17();
	}

	public int method_15()
	{
		return int_0;
	}

	private int method_16()
	{
		return int_1;
	}

	public int method_17()
	{
		return int_2;
	}

	public int method_18()
	{
		return method_15() - int_2;
	}

	private int method_19()
	{
		return int_5;
	}

	public void method_20(int newLineHeight, int newAlignmentPoint)
	{
		int_0 = newLineHeight;
		int_2 = newAlignmentPoint;
		class5694_0.method_5(int_2, int_2 - int_0);
	}

	public int method_21()
	{
		int num = 0;
		if (class5684_0 != null)
		{
			return class5684_0.method_14() - method_14();
		}
		return method_17() - class5694_0.method_2(142);
	}

	public bool method_22()
	{
		if (class5684_0 != null)
		{
			if (class5694_0 == class5684_0.method_5())
			{
				return class5684_0.method_22();
			}
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("areaHeight=").Append(int_0);
		stringBuilder.Append(" lineHeight=").Append(int_1);
		stringBuilder.Append(" alignmentPoint=").Append(int_2);
		stringBuilder.Append(" alignmentBaselineID=").Append(int_4);
		stringBuilder.Append(" baselineShift=").Append(int_3);
		return stringBuilder.ToString();
	}
}

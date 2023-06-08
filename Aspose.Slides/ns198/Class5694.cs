using System;
using ns171;
using ns205;

namespace ns198;

internal class Class5694
{
	private const float float_0 = 0.8f;

	private const float float_1 = 0.5f;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private Class5445 class5445_0;

	private int int_4;

	private int int_5;

	private int int_6;

	internal Class5694(int altitude, int depth, int xHeight, int dominantBaselineIdentifier, Class5445 writingMode)
	{
		int_0 = altitude;
		int_1 = depth;
		int_2 = xHeight;
		int_3 = dominantBaselineIdentifier;
		class5445_0 = writingMode;
		int_4 = method_4(int_3);
		int_5 = altitude - int_4;
		int_6 = depth - int_4;
	}

	internal int method_0()
	{
		return int_3;
	}

	internal Class5445 method_1()
	{
		return class5445_0;
	}

	internal int method_2(int baselineIdentifier)
	{
		int num = 0;
		if (!method_3())
		{
			switch ((Enum679)baselineIdentifier)
			{
			case Enum679.const_21:
			case Enum679.const_230:
			case Enum679.const_231:
			case Enum679.const_232:
				throw new ArgumentException("Baseline " + baselineIdentifier + " only supported for horizontal writing modes");
			}
		}
		switch ((Enum679)baselineIdentifier)
		{
		case Enum679.const_5:
		case Enum679.const_21:
			return int_6;
		case Enum679.const_15:
		case Enum679.const_232:
			return int_5;
		default:
			throw new ArgumentException(baselineIdentifier.ToString());
		case Enum679.const_7:
		case Enum679.const_25:
		case Enum679.const_57:
		case Enum679.const_60:
		case Enum679.const_169:
		case Enum679.const_171:
		case Enum679.const_228:
		case Enum679.const_229:
		case Enum679.const_230:
		case Enum679.const_231:
			return method_4(baselineIdentifier) - int_4;
		}
	}

	private bool method_3()
	{
		return class5445_0.method_3();
	}

	private int method_4(int baselineIdentifier)
	{
		int num = 0;
		switch ((Enum679)baselineIdentifier)
		{
		case Enum679.const_57:
			return (int)Math.Round((float)int_0 * 0.8f);
		case Enum679.const_25:
			return (int_0 - int_1) / 2 + int_1;
		case Enum679.const_7:
			return 0;
		case Enum679.const_229:
			return int_0;
		case Enum679.const_169:
			return (int)Math.Round((float)int_0 * 0.5f);
		default:
			throw new ArgumentException(baselineIdentifier.ToString());
		case Enum679.const_171:
			return int_2 / 2;
		case Enum679.const_60:
		case Enum679.const_228:
			return int_1;
		}
	}

	internal void method_5(int beforeBaseline, int afterBaseline)
	{
		int_5 = beforeBaseline;
		int_6 = afterBaseline;
	}

	internal Class5694 method_6(int baselineIdentifier)
	{
		return new Class5694(int_0, int_1, int_2, baselineIdentifier, class5445_0);
	}
}

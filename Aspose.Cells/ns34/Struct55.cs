using System.Drawing;
using System.Runtime.InteropServices;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct55
{
	private static readonly float float_0 = 0.4f;

	public static Color smethod_0(Enum50 enum50_0, Color color_0)
	{
		if (enum50_0 == Enum50.const_7 || enum50_0 == Enum50.const_8)
		{
			enum50_0 = smethod_1(color_0, enum50_0);
		}
		float float_ = 0f;
		switch (enum50_0)
		{
		case Enum50.const_0:
			return Color.Transparent;
		case Enum50.const_1:
			return SystemColors.WindowText;
		case Enum50.const_2:
			return color_0;
		case Enum50.const_3:
			float_ = 0f - Struct54.float_0;
			goto default;
		case Enum50.const_4:
			float_ = 0f - Struct54.float_1;
			goto default;
		case Enum50.const_5:
			float_ = Struct54.float_0;
			goto default;
		case Enum50.const_6:
			float_ = Struct54.float_1;
			goto default;
		default:
			return Struct54.smethod_0(color_0, float_);
		case Enum50.const_9:
			return smethod_2(color_0);
		}
	}

	private static Enum50 smethod_1(Color color_0, Enum50 enum50_0)
	{
		if (color_0.GetBrightness() > float_0)
		{
			if (enum50_0 == Enum50.const_7)
			{
				return Enum50.const_3;
			}
			return Enum50.const_4;
		}
		if (enum50_0 == Enum50.const_7)
		{
			return Enum50.const_5;
		}
		return Enum50.const_6;
	}

	private static Color smethod_2(Color color_0)
	{
		if (color_0.GetBrightness() > float_0)
		{
			return Color.Black;
		}
		return Color.White;
	}
}

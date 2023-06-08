using System.Drawing;
using System.Runtime.InteropServices;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct31
{
	private static readonly float float_0 = 0.4f;

	public static Color smethod_0(Enum48 enum48_0, Color color_0)
	{
		if (enum48_0 == Enum48.const_7 || enum48_0 == Enum48.const_8)
		{
			enum48_0 = smethod_1(color_0, enum48_0);
		}
		float float_ = 0f;
		switch (enum48_0)
		{
		case Enum48.const_0:
			return Color.Transparent;
		case Enum48.const_1:
			return SystemColors.WindowText;
		case Enum48.const_2:
			return color_0;
		case Enum48.const_3:
			float_ = 0f - Struct30.float_0;
			goto default;
		case Enum48.const_4:
			float_ = 0f - Struct30.float_1;
			goto default;
		case Enum48.const_5:
			float_ = Struct30.float_0;
			goto default;
		case Enum48.const_6:
			float_ = Struct30.float_1;
			goto default;
		default:
			return Struct30.smethod_0(color_0, float_);
		case Enum48.const_9:
			return smethod_2(color_0);
		}
	}

	private static Enum48 smethod_1(Color color_0, Enum48 enum48_0)
	{
		if (color_0.GetBrightness() > float_0)
		{
			if (enum48_0 == Enum48.const_7)
			{
				return Enum48.const_3;
			}
			return Enum48.const_4;
		}
		if (enum48_0 == Enum48.const_7)
		{
			return Enum48.const_5;
		}
		return Enum48.const_6;
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

using System.Drawing;
using System.Runtime.InteropServices;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct54
{
	public static readonly float float_0 = 0.3f;

	public static readonly float float_1 = 0.5f;

	public static Color smethod_0(Color color_0, float float_2)
	{
		if (float_2 == 0f)
		{
			return color_0;
		}
		float num = (int)color_0.R;
		float num2 = (int)color_0.G;
		float num3 = (int)color_0.B;
		if (float_2 < 0f)
		{
			float_2 = 1f + float_2;
			num *= float_2;
			num2 *= float_2;
			num3 *= float_2;
		}
		else
		{
			num = (255f - num) * float_2 + num;
			num2 = (255f - num2) * float_2 + num2;
			num3 = (255f - num3) * float_2 + num3;
		}
		return Color.FromArgb(color_0.A, (int)num, (int)num2, (int)num3);
	}
}
